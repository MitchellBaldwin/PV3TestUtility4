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

    Stopwatch dataStopwatch = new Stopwatch();

    PV3DataTypes pv3Data = new PV3DataTypes();

    internal PV3DataTypes PV3Data
    {
      get { return pv3Data; }
      set { pv3Data = value; }
    }

    PV3DataTypes.PV3CommandType cmd;
    public PV3TU4Main()
    {
      InitializeComponent();
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
      //usbOutDisplayLabel.Text = usbOutString;
      //usbInDisplayLabel.Text = usbInString;
    }

  }
}
