using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PV3TestUtility4
{
    public partial class LSSCalibDialog : Form
    {
        PV3TU4Main pv3tu4Main;
        USBClass pv3Connection;
        PV3DataTypes pv3Data;
        PV3DataTypes.PV3CommandType cmd;

        byte[] byteGain = new byte[2];
        byte[] byteOffset = new byte[2];

        public LSSCalibDialog()
        {
            InitializeComponent();
        }

        private void LSSCalibDialog_Load(object sender, EventArgs e)
        {
            pv3tu4Main = (PV3TU4Main)Owner;
            pv3Connection = pv3tu4Main.USBConnection;
            pv3Data = pv3tu4Main.PV3Data;

            if (pv3Connection.connectionState == USBClass.CONNECTION_SUCCESSFUL)
            {
                connectionErrorLabel.Visible = false;
                // Enable low speed data acquisition timer
                lpsTimer.Enabled = true;
                // Enable controls
                setFiO2GainButton.Enabled = true;
                setTLEFTGainButton.Enabled = true;
                setTRGHTGainButton.Enabled = true;

                // Read & display low speed sensor calibration data:
                cmd = PV3DataTypes.PV3CommandType.RD_LSSCD;
                pv3Connection.OutBuffer[1] = (byte)cmd;
                pv3Connection.sendViaUSB();

                pv3Connection.receiveViaUSB();

                pv3Data.FiO2Zero = (ushort)((uint)(pv3Connection.InBuffer[11] << 8) + (uint)pv3Connection.InBuffer[10]);
                fio2OffsetDisplayLabel.Text = pv3Data.FiO2Zero.ToString();
                pv3Data.FiO2Gain = (ushort)((uint)(pv3Connection.InBuffer[13] << 8) + (uint)pv3Connection.InBuffer[12]);
                fio2GainDisplayLabel.Text = pv3Data.FiO2Gain.ToString();

                pv3Data.TLEFTZero = (ushort)((uint)(pv3Connection.InBuffer[3] << 8) + (uint)pv3Connection.InBuffer[2]);
                tleftOffsetDisplayLabel.Text = pv3Data.TLEFTZero.ToString();
                pv3Data.TLEFTGain = (ushort)((uint)(pv3Connection.InBuffer[5] << 8) + (uint)pv3Connection.InBuffer[4]);
                tleftGainDisplayLabel.Text = pv3Data.TLEFTGain.ToString();

                pv3Data.TRGHTZero = (ushort)((uint)(pv3Connection.InBuffer[7] << 8) + (uint)pv3Connection.InBuffer[6]);
                trghtOffsetDisplayLabel.Text = pv3Data.TRGHTZero.ToString();
                pv3Data.TRGHTGain = (ushort)((uint)(pv3Connection.InBuffer[9] << 8) + (uint)pv3Connection.InBuffer[8]);
                trghtGainDisplayLabel.Text = pv3Data.TRGHTGain.ToString();
            }
            else
            {
                connectionErrorLabel.Visible = true;
                // Disable low speed data acquisition timer
                lpsTimer.Enabled = false;
                // Disable controls
                setFiO2GainButton.Enabled = true;
                setTLEFTGainButton.Enabled = true;
                setTRGHTGainButton.Enabled = true;
            }
        }

        private void lpsTimer_Tick(object sender, EventArgs e)
        {
            if (pv3Connection.connectionState == USBClass.CONNECTION_SUCCESSFUL)
            {
                // Read & display low speed sensor measurements:
                cmd = PV3DataTypes.PV3CommandType.RD_LSSDP;
                pv3Connection.OutBuffer[1] = (byte)cmd;
                pv3Connection.sendViaUSB();

                pv3Connection.receiveViaUSB();
                pv3Data.FiO2Raw = (ushort)((uint)(pv3Connection.InBuffer[7] << 8) + (uint)pv3Connection.InBuffer[6]);
                fio2RawDisplayLabel.Text = pv3Data.FiO2Raw.ToString();
                fio2MeasurementDisplayLabel.Text = pv3Data.FiO2.ToString("0.0");
                pv3Data.TLEFTRaw = (ushort)((uint)(pv3Connection.InBuffer[3] << 8) + (uint)pv3Connection.InBuffer[2]);
                tleftRawDisplayLabel.Text = pv3Data.TLEFTRaw.ToString("X4");
                tleftMeasurementDisplayLabel.Text = pv3Data.TLEFT.ToString("0.000");
                pv3Data.TRGHTRaw = (ushort)((uint)(pv3Connection.InBuffer[5] << 8) + (uint)pv3Connection.InBuffer[4]);
                trghtRawDisplayLabel.Text = pv3Data.TRGHTRaw.ToString("X4");
                trghtMeasurementDisplayLabel.Text = pv3Data.TRGHT.ToString("0.000");
            }

        }

        private void setFiO2OffsetButton_Click(object sender, EventArgs e)
        {
            cmd = PV3DataTypes.PV3CommandType.SET_O2O;
            pv3Connection.OutBuffer[1] = (byte)cmd;
            ushort intOffset = Convert.ToUInt16(fio2OffsetTextBox.Text);
            pv3Data.FiO2Zero = intOffset;
            fio2OffsetDisplayLabel.Text = pv3Data.FiO2Zero.ToString();
            byteOffset[1] = (byte)(intOffset / 256);
            byteOffset[0] = (byte)(intOffset % 256);
            pv3Connection.OutBuffer[2] = byteOffset[0];
            pv3Connection.OutBuffer[3] = byteOffset[1];
            pv3Connection.sendViaUSB();
            pv3Connection.receiveViaUSB();
        }

        private void setFiO2GainButton_Click(object sender, EventArgs e)
        {
            cmd = PV3DataTypes.PV3CommandType.SET_O2G;
            pv3Connection.OutBuffer[1] = (byte)cmd;
            ushort intGain = Convert.ToUInt16(fio2GainTextBox.Text);
            pv3Data.FiO2Gain = intGain;
            fio2GainDisplayLabel.Text = pv3Data.FiO2Gain.ToString();
            byteGain[1] = (byte)(intGain / 256);
            byteGain[0] = (byte)(intGain % 256);
            pv3Connection.OutBuffer[2] = byteGain[0];
            pv3Connection.OutBuffer[3] = byteGain[1];
            pv3Connection.sendViaUSB();
            pv3Connection.receiveViaUSB();
        }

        private void setTLEFTGainButton_Click(object sender, EventArgs e)
        {
            cmd = PV3DataTypes.PV3CommandType.SET_LLTG;
            pv3Connection.OutBuffer[1] = (byte)cmd;
            ushort intGain = Convert.ToUInt16(tleftGainTextBox.Text);
            pv3Data.TLEFTGain = intGain;
            tleftGainDisplayLabel.Text = pv3Data.TLEFTGain.ToString();
            byteGain[1] = (byte)(intGain / 256);
            byteGain[0] = (byte)(intGain % 256);
            pv3Connection.OutBuffer[2] = byteGain[0];
            pv3Connection.OutBuffer[3] = byteGain[1];
            pv3Connection.sendViaUSB();
            pv3Connection.receiveViaUSB();
        }

        private void setTRGHTGainButton_Click(object sender, EventArgs e)
        {
            cmd = PV3DataTypes.PV3CommandType.SET_RLTG;
            pv3Connection.OutBuffer[1] = (byte)cmd;
            ushort intGain = Convert.ToUInt16(trghtGainTextBox.Text);
            pv3Data.TRGHTGain = intGain;
            trghtGainDisplayLabel.Text = pv3Data.TRGHTGain.ToString();
            byteGain[1] = (byte)(intGain / 256);
            byteGain[0] = (byte)(intGain % 256);
            pv3Connection.OutBuffer[2] = byteGain[0];
            pv3Connection.OutBuffer[3] = byteGain[1];
            pv3Connection.sendViaUSB();
            pv3Connection.receiveViaUSB();
        }
    }
}
