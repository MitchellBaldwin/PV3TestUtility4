using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PV3TestUtility4
{
  public partial class PV3TU4Main : Form
  {
    //Constant definitions for certain WM_DEVICECHANGE messages
    internal const uint WM_DEVICECHANGE = 0x0219;
    internal const uint DBT_DEVICEARRIVAL = 0x8000;
    internal const uint DBT_DEVICEREMOVEPENDING = 0x8003;
    internal const uint DBT_DEVICEREMOVECOMPLETE = 0x8004;
    internal const uint DBT_DEVNODES_CHANGED = 0x0007;
    internal const uint DBT_CONFIGCHANGED = 0x0018;

    USBClass usbConnection;                         // Normal working connection (non-bootloader)
    public USBClass USBConnection
    {
      get { return usbConnection; }
      set { usbConnection = value; }
    }

    USBClass blConnection;                          // Bootloader connection
    public USBClass BLConnection
    {
      get { return blConnection; }
      set { blConnection = value; }
    }

    readonly Stopwatch dataStopwatch = new Stopwatch();

    PV3DataTypes pv3Data = new PV3DataTypes();

    internal PV3DataTypes PV3Data
    {
      get { return pv3Data; }
      set { pv3Data = value; }
    }
    
    DataStreamer PProxDataStreamer;
    DataStreamer VolumeDataStreamer;
    DataStreamer FlowDataStreamer;

    PV3DataTypes.PV3CommandType cmd;

    public PV3TU4Main()
    {
      InitializeComponent();
      usbConnection = new USBClass
      {
        deviceID = "Vid_04D8&Pid_FCB6"
      };
      blConnection = new USBClass
      {
        deviceID = "Vid_04D8&Pid_003C"
      };
    }

    // This is a callback function that gets called when a Windows message is received by the form.
    // We will receive various different types of messages, but the ones we really want to use are the WM_DEVICECHANGE messages.
    protected override void WndProc(ref Message m)
    {
      if (m.Msg == WM_DEVICECHANGE)
      {
        if (((int)m.WParam == DBT_DEVICEARRIVAL)
         || ((int)m.WParam == DBT_DEVICEREMOVEPENDING)
         || ((int)m.WParam == DBT_DEVICEREMOVECOMPLETE)
         || ((int)m.WParam == DBT_DEVNODES_CHANGED)
         || ((int)m.WParam == DBT_CONFIGCHANGED))
        {
          // Added DBT_DEVNODES_CHANGED wParam
          // This was done to work around the issue encountered with the ARRIVAL, REMOVAL or CONFIGCHANGE
          //parameters apparently no longer arriving after the MSD functions were removed from the firmware
          ConnectToUSB();
        }

      } //end of: if(m.Msg == WM_DEVICECHANGE)
      base.WndProc(ref m);
    } //end of: WndProc() function

    #region Form Load and Closing
    private void PV3TU4Main_Load(object sender, EventArgs e)
    {
      if (usbConnection.connectionState == USBClass.CONNECTION_NOT_SUCCESSFUL || blConnection.connectionState == USBClass.CONNECTION_NOT_SUCCESSFUL)
      {
        ConnectToUSB();
      }

      PProxDataStreamer = PressuresPlot.Plot.Add.DataStreamer(1000, 0.010);
      //PProxDataStreamer.LegendText = "PProx";
      VolumeDataStreamer = VolFlowPlot.Plot.Add.DataStreamer(1000, 0.010);
      //VolumeDataStreamer.LegendText = "Volume";
      //VolFlowPlot.Refresh();
      FlowDataStreamer = VolFlowPlot.Plot.Add.DataStreamer(1000, 0.010);
      //FlowDataStreamer.LegendText = "Flow";
      //VolFlowPlot.Refresh();

      PressuresPlot.Plot.Axes.Bottom.Label.Text = "Time (s)";
      PressuresPlot.Plot.Axes.Bottom.Label.Bold = false;
      PressuresPlot.Plot.Axes.Bottom.Label.FontSize = 9;
      PressuresPlot.Plot.Axes.Bottom.Min = 0.0;
      PressuresPlot.Plot.Axes.Bottom.Max = 10.0;
      PressuresPlot.Plot.Axes.Left.Label.Text = "Pressure (cmH2O)";
      PressuresPlot.Plot.Axes.Left.Label.Bold = false;
      PressuresPlot.Plot.Axes.Left.Label.FontSize = 9;
      PressuresPlot.Plot.Axes.Left.Min = -20.0;
      PressuresPlot.Plot.Axes.Left.Max = 120.00;
      PressuresPlot.Plot.Axes.Left.Label.ForeColor = ScottPlot.Color.FromARGB(pproxDisplayLabel.ForeColor.ToArgb());

      VolFlowPlot.Plot.Axes.Bottom.Label.Text = "Time (s)";
      VolFlowPlot.Plot.Axes.Bottom.Label.Bold = false;
      VolFlowPlot.Plot.Axes.Bottom.Label.FontSize = 9;
      VolFlowPlot.Plot.Axes.Bottom.Min = 0.0;
      VolFlowPlot.Plot.Axes.Bottom.Max = 10.0;
      VolFlowPlot.Plot.Axes.Left.Label.Text = "Volume (mL)";
      VolFlowPlot.Plot.Axes.Left.Label.Bold = false;
      VolFlowPlot.Plot.Axes.Left.Label.FontSize = 9;
      VolFlowPlot.Plot.Axes.Left.Min = 0.0;
      VolFlowPlot.Plot.Axes.Left.Max = 1000.0;
      VolFlowPlot.Plot.Axes.Left.Label.ForeColor = ScottPlot.Color.FromARGB(VolumeLEFTDisplayLabel.ForeColor.ToArgb());
      FlowDataStreamer.Axes.YAxis = VolFlowPlot.Plot.Axes.Right;
      VolFlowPlot.Plot.Axes.Right.Label.Text = "Flow (L/min)";
      VolFlowPlot.Plot.Axes.Right.Label.Bold = false;
      VolFlowPlot.Plot.Axes.Right.Label.FontSize = 9;
      VolFlowPlot.Plot.Axes.Right.Min = -60.0;
      VolFlowPlot.Plot.Axes.Right.Max = 60.0;
      VolFlowPlot.Plot.Axes.Right.Label.ForeColor = ScottPlot.Color.FromARGB(RIGHTAirwayDisplayLabel.ForeColor.ToArgb());

      PProxDataStreamer.ViewWipeRight(0.010);
      PProxDataStreamer.Color = ScottPlot.Color.FromARGB(pproxDisplayLabel.ForeColor.ToArgb());

      VolumeDataStreamer.ViewWipeRight(0.010);
      VolumeDataStreamer.Color = ScottPlot.Color.FromARGB(VolumeRIGHTDisplayLabel.ForeColor.ToArgb());

      FlowDataStreamer.IsVisible = true;
      FlowDataStreamer.ViewWipeRight(0.010);
      FlowDataStreamer.Color = ScottPlot.Color.FromARGB(RIGHTAirwayDisplayLabel.ForeColor.ToArgb());


    }

    #endregion Form Load and Closing

    #region Form event handlers
    private void connectionStateLabel_Click(object sender, EventArgs e)
    {
      ConnectToUSB();
    }
    private void usbCommTimer_Tick(object sender, EventArgs e)
    {
      byte packetNum = 0;
      byte nextPacketNum = 0;
      long avgPackageInterval = 0;
      long maxPackageInterval = 0;

      cmd = PV3DataTypes.PV3CommandType.RD_POT;
      usbConnection.OutBuffer[1] = (byte)cmd;
      usbConnection.SendViaUSB();
      usbConnection.ReceiveViaUSB();

      Stopwatch stopwatch = Stopwatch.StartNew();

      cmd = PV3DataTypes.PV3CommandType.RD_HSSDP;
      usbConnection.OutBuffer[1] = (byte)cmd;
      usbConnection.SendViaUSB();
      usbConnection.ReceiveViaUSB();

      int sampleSetsInPacket = usbConnection.InBuffer[3];

      for (int i = 0; i < sampleSetsInPacket; ++i)
      {
        if (i == 0)
        {
          pv3Data.PPROXRaw = (ushort)((uint)(usbConnection.InBuffer[5] << 8) + (uint)usbConnection.InBuffer[4]);
          pv3Data.PLEFTRaw = (ushort)((uint)(usbConnection.InBuffer[7] << 8) + (uint)usbConnection.InBuffer[6]);
          pv3Data.PRGHTRaw = (ushort)((uint)(usbConnection.InBuffer[9] << 8) + (uint)usbConnection.InBuffer[8]);
          pv3Data.PHIGHRaw = (ushort)((uint)(usbConnection.InBuffer[11] << 8) + (uint)usbConnection.InBuffer[10]);
          pv3Data.AUXINRaw = (ushort)((uint)(usbConnection.InBuffer[13] << 8) + (uint)usbConnection.InBuffer[12]);

          // TODO: Smooth pressure data streams
          // TODO: Reset missed package count when restarting data acquisition
          // DONE: Use stopwatch to set data sample position in data stream arrays
          // DONE: Interpolate missed samples - in progress
          // TODO: Handle first data sample

          //long sampleNumber = dataStopwatch.ElapsedMilliseconds / 2;
          //pv3Data.AddSampleSet(sampleNumber);

        }

        long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
        if (elapsedMilliseconds > maxPackageInterval)
        {
          maxPackageInterval = elapsedMilliseconds;
        }
        avgPackageInterval += elapsedMilliseconds;

        stopwatch.Restart();
        packetNum = nextPacketNum;
      }

      nextPacketNum = usbConnection.InBuffer[2];

      if ((packetNum != 0) && (packetNum != 255))
      {
        packagesMissedDisplayLabel.Text = (nextPacketNum - packetNum - 1).ToString();
      }
      else
      {
        packagesMissedDisplayLabel.Text = "0";
      }

      packageCountDisplayLabel.Text = nextPacketNum.ToString();
      sizeDisplayLabel.Text = sampleSetsInPacket.ToString();

      packageIntervalDisplayLabel.Text = ((double)avgPackageInterval / sampleSetsInPacket).ToString("0.0");
      avgPackageInterval = 0;

      maxPackageIntervalDisplayLabel.Text = maxPackageInterval.ToString();

      ch0DisplayLabel.Text = pv3Data.PPROXRaw.ToString();
      if (pv3Data.PPROXRaw < 500)
      {
        //ch0ZeroDetectedLabel.Visible = true;
      }
      pproxDisplayLabel.Text = string.Format("{0:0.00}", pv3Data.PPROX);
      ch1DisplayLabel.Text = pv3Data.PLEFTRaw.ToString();
      pleftDisplayLabel.Text = pv3Data.PLEFT.ToString("0.00");
      ch2DisplayLabel.Text = pv3Data.PRGHTRaw.ToString();
      prghtDisplayLabel.Text = pv3Data.PRGHT.ToString("0.00");
      ch3DisplayLabel.Text = pv3Data.PHIGHRaw.ToString();
      phighDisplayLabel.Text = pv3Data.PHIGH.ToString("0.00");
      ch4DisplayLabel.Text = pv3Data.AUXINRaw.ToString();
      auxinDisplayLabel.Text = pv3Data.AUXIN.ToString("0.00");

      VolumeLEFTDisplayLabel.Text = pv3Data.VLEFT.ToString("0");
      VolumeRIGHTDisplayLabel.Text = pv3Data.VRIGHT.ToString("0");

      LEFTAirwayDisplayLabel.Text = pv3Data.FAWLEFT.ToString("0.0");
      RIGHTAirwayDisplayLabel.Text = pv3Data.FAWRIGHT.ToString("0.0");

      cmd = PV3DataTypes.PV3CommandType.RD_LSSDP;
      usbConnection.OutBuffer[1] = (byte)cmd;
      usbConnection.SendViaUSB();
      usbConnection.ReceiveViaUSB();

      pv3Data.TLEFTRaw = (ushort)((uint)(usbConnection.InBuffer[3] << 8) + (uint)usbConnection.InBuffer[2]);
      pv3Data.TRGHTRaw = (ushort)((uint)(usbConnection.InBuffer[5] << 8) + (uint)usbConnection.InBuffer[4]);
      pv3Data.FiO2Raw = (ushort)((uint)(usbConnection.InBuffer[7] << 8) + (uint)usbConnection.InBuffer[6]);

      lltRawDisplayLabel.Text = pv3Data.TLEFTRaw.ToString("X4");
      leftLungTemperatureDisplayLabel.Text = pv3Data.TLEFT.ToString("0.000");
      rltRawDisplayLabel.Text = pv3Data.TRGHTRaw.ToString("X4");
      rightLungTemperatureDisplayLabel.Text = pv3Data.TRGHT.ToString("0.000");
      fio2RawDisplayLabel.Text = pv3Data.FiO2Raw.ToString("X4");
      fio2DisplayLabel.Text = pv3Data.FiO2.ToString("0.0");

      // Add new data points to the scrolling data stream plots and data structures:
      PProxDataStreamer.Add(pv3Data.PPROX);
      VolumeDataStreamer.Add(pv3Data.VLEFT + pv3Data.VRIGHT);
      FlowDataStreamer.Add(pv3Data.FAWLEFT + pv3Data.FAWRIGHT);

      // Refresh plot displays:
      PressuresPlot.Refresh();
      VolFlowPlot.Refresh();

    }
    private void ZeroAllButton_Click(object sender, EventArgs e)
    {
      cmd = PV3DataTypes.PV3CommandType.RD_HSSDP;
      usbConnection.OutBuffer[1] = (byte)cmd;
      usbConnection.SendViaUSB();
      usbConnection.ReceiveViaUSB();
      pv3Data.PPROXRaw = (ushort)((uint)(usbConnection.InBuffer[5] << 8) + (uint)usbConnection.InBuffer[4]);
      pv3Data.PPROXZero = pv3Data.PPROXRaw;
      pv3Data.PLEFTRaw = (ushort)((uint)(usbConnection.InBuffer[7] << 8) + (uint)usbConnection.InBuffer[6]);
      pv3Data.PLEFTZero = pv3Data.PLEFTRaw;
      pv3Data.PRGHTRaw = (ushort)((uint)(usbConnection.InBuffer[9] << 8) + (uint)usbConnection.InBuffer[8]);
      pv3Data.PRGHTZero = pv3Data.PRGHTRaw;
      pv3Data.PHIGHRaw = (ushort)((uint)(usbConnection.InBuffer[11] << 8) + (uint)usbConnection.InBuffer[10]);
      pv3Data.PHIGHZero = pv3Data.PHIGHRaw;
      pv3Data.AUXINRaw = (ushort)((uint)(usbConnection.InBuffer[13] << 8) + (uint)usbConnection.InBuffer[12]);
      pv3Data.AUXINZero = pv3Data.AUXINRaw;
    }
    private void StartDAQButton_Click(object sender, EventArgs e)
    {
      if (usbCommTimer.Enabled == false)
      {
        // Start data acquisition:
        cmd = PV3DataTypes.PV3CommandType.START_DATA_ACQ;
        usbConnection.OutBuffer[1] = (byte)cmd;
        usbConnection.SendViaUSB();
        usbConnection.ReceiveViaUSB();
        DisplayUSBBufferData();
        usbCommTimer.Enabled = true;
        dataStopwatch.Start();

        // Change button text & appearence to indicate data acquisition is in progress:
        StartDAQButton.BackColor = Color.Red;
        StartDAQButton.Text = "Stop DAQ";

      }
      else
      {
        // End data acquisition:
        cmd = PV3DataTypes.PV3CommandType.STOP_DATA_ACQ;
        usbConnection.OutBuffer[1] = (byte)cmd;
        usbConnection.SendViaUSB();
        usbConnection.ReceiveViaUSB();
        DisplayUSBBufferData();
        usbCommTimer.Enabled = false;
        dataStopwatch.Stop();
        //dataStopwatch.Reset();

        // Change button text & appearence to indicate data acquisition can be started:
        StartDAQButton.BackColor = Color.Lime;
        StartDAQButton.Text = "Start DAQ";

      }
    }
    private void LeftComplianceComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      byte command = 0xC0;    // Left lung

      ComboBox cb = (ComboBox)sender;
      byte currentCompliance = (byte)(cb.SelectedIndex + 1);

      usbConnection.OutBuffer[1] = (byte)(command + currentCompliance);
      usbConnection.SendViaUSB();
      usbConnection.ReceiveViaUSB();

      pv3Data.ccLeft[0] = BitConverter.ToDouble(usbConnection.InBuffer, 2);
      pv3Data.ccLeft[1] = BitConverter.ToDouble(usbConnection.InBuffer, 10);
      pv3Data.ccLeft[2] = BitConverter.ToDouble(usbConnection.InBuffer, 18);
      pv3Data.ccLeft[3] = BitConverter.ToDouble(usbConnection.InBuffer, 26);

    }
    private void RightComplianceComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      byte command = 0xE0;    // Right lung

      ComboBox cb = (ComboBox)sender;
      byte currentCompliance = (byte)(cb.SelectedIndex + 1);

      usbConnection.OutBuffer[1] = (byte)(command + currentCompliance);
      usbConnection.SendViaUSB();
      usbConnection.ReceiveViaUSB();

      pv3Data.ccRight[0] = BitConverter.ToDouble(usbConnection.InBuffer, 2);
      pv3Data.ccRight[1] = BitConverter.ToDouble(usbConnection.InBuffer, 10);
      pv3Data.ccRight[2] = BitConverter.ToDouble(usbConnection.InBuffer, 18);
      pv3Data.ccRight[3] = BitConverter.ToDouble(usbConnection.InBuffer, 26);

    }
    private void LeftResistorComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      ComboBox cb = (ComboBox)sender;
      byte resistorValue = (byte)(cb.SelectedIndex);
      pv3Data.LeftResistanceChanged(resistorValue);
    }
    private void RightResistorComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      ComboBox cb = (ComboBox)sender;
      byte resistorValue = (byte)(cb.SelectedIndex);
      pv3Data.RightResistanceChanged(resistorValue);
    }
    private void SetReadHSCalibrationParametersButton_Click(object sender, EventArgs e)
    {
      HSSCalibDialog hsscd = new HSSCalibDialog();
      hsscd.ShowDialog(this);
    }
    private void SetReadLSCalibrationParametersButton_Click(object sender, EventArgs e)
    {
      LSSCalibDialog lsscd = new LSSCalibDialog();
      lsscd.ShowDialog(this);
    }
    private void ReadSetComplianceCalibrationCoefficientsButton_Click(object sender, EventArgs e)
    {
      CompCalibDialog ccd = new CompCalibDialog();
      ccd.ShowDialog(this);
    }

    #endregion Form event handlers

    #region USB Communications
    // Connect to PV3 embedded system over USB
    public bool ConnectToUSB()
    {
      System.Threading.Thread.Sleep(500);
      usbConnection.connectionState = usbConnection.AttemptUSBConnection();
      if (usbConnection.connectionState == USBClass.CONNECTION_SUCCESSFUL)
      {
        connectionStateLabel.BackColor = Color.LimeGreen;
        connectionStateLabel.Text = "Connected to: " + usbConnection.deviceID;
        usbCommTimer.Enabled = false;

        // Configure the form controls for a connected device:
        StartDAQButton.Enabled = true;
        ZeroAllButton.Enabled = true;

        // Read and display lung model:
        cmd = PV3DataTypes.PV3CommandType.RD_LUNG_MODEL;
        usbConnection.OutBuffer[1] = (byte)cmd;
        usbConnection.SendViaUSB();
        usbConnection.ReceiveViaUSB();
        pv3Data.ttlModel = usbConnection.InBuffer[2];
        switch (pv3Data.ttlModel)
        {
          case 1:
            lungModelDisplayLabel.Text = "Single Lung";
            break;
          case 2:
            lungModelDisplayLabel.Text = "Adult / Infant";
            break;
          case 4:
            lungModelDisplayLabel.Text = "Dual Adult";
            break;

          default:
            lungModelDisplayLabel.Text = string.Format("Invalid flag set: {0:X2}", pv3Data.ttlModel);
            break;
        }

        // Read and display lung serial number:
        cmd = PV3DataTypes.PV3CommandType.RD_LUNG_SN;
        usbConnection.OutBuffer[1] = (byte)cmd;
        usbConnection.SendViaUSB();
        usbConnection.ReceiveViaUSB();
        pv3Data.ttlSN[0] = usbConnection.InBuffer[2];
        pv3Data.ttlSN[1] = usbConnection.InBuffer[3];
        lungSerialNumberDisplayLabel.Text = "SN " + (BitConverter.ToUInt16(pv3Data.ttlSN, 0)).ToString();

        // Read high speed sensor channel calibration data:
        cmd = PV3DataTypes.PV3CommandType.RD_HSSCD;
        usbConnection.OutBuffer[1] = (byte)cmd;
        usbConnection.SendViaUSB();
        usbConnection.ReceiveViaUSB();
        pv3Data.PPROXGain = (ushort)((uint)(usbConnection.InBuffer[3] << 8) + (uint)usbConnection.InBuffer[2]);
        pv3Data.PLEFTGain = (ushort)((uint)(usbConnection.InBuffer[5] << 8) + (uint)usbConnection.InBuffer[4]);
        pv3Data.PRGHTGain = (ushort)((uint)(usbConnection.InBuffer[7] << 8) + (uint)usbConnection.InBuffer[6]);
        pv3Data.PHIGHGain = (ushort)((uint)(usbConnection.InBuffer[9] << 8) + (uint)usbConnection.InBuffer[8]);
        pv3Data.AUXINGain = (ushort)((uint)(usbConnection.InBuffer[11] << 8) + (uint)usbConnection.InBuffer[10]);

        // Test code: Force PProx offset to a value simulating an elevated proximal pressure for testing purposes:
        pv3Data.PPROXZero = 400;

        // Load initial compliance coefficient sets:
        LeftComplianceComboBox_SelectedIndexChanged(LeftComplianceComboBox, new EventArgs());
        RightComplianceComboBox_SelectedIndexChanged(RightComplianceComboBox, new EventArgs());

        return true;
      }

      blConnection.connectionState = blConnection.AttemptUSBConnection();
      if (blConnection.connectionState == USBClass.CONNECTION_SUCCESSFUL)
      {
        connectionStateLabel.BackColor = Color.LightBlue;
        connectionStateLabel.Text = "Connected to: " + blConnection.blDeviceID;
        usbCommTimer.Enabled = false;

        // Configure the form controls as appropriate for being connected to the HID Bootloader:


        return true;
      }
      else
      {
        connectionStateLabel.BackColor = Color.Red;
        connectionStateLabel.Text = "NOT Connected - click to retry...";
        usbCommTimer.Enabled = false;

        // Configure the form controls as appropriate while waiting for device to connect:
        StartDAQButton.Enabled = false;
        ZeroAllButton.Enabled = false;

        return false;
      }

    }
    public void DisplayUSBBufferData()
    {
      string usbOutString = "";
      string usbInString = "";

      for (int i = 1; i < 17; ++i)
      {
        usbOutString += string.Format("{0:X2} ", usbConnection.OutBuffer[i]);
        usbInString += string.Format("{0:X2} ", usbConnection.InBuffer[i]);
      }
      usbOutDisplayLabel.Text = usbOutString;
      usbInDisplayLabel.Text = usbInString;
    }

    #endregion USB Communications

  }
}
