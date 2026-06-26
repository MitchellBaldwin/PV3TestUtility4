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
    public partial class HSSCalibDialog : Form
    {
        PV3TU4Main pv3tu4Main;
        USBClass pv3Connection;
        PV3DataTypes pv3Data;
        PV3DataTypes.PV3CommandType cmd;

        byte[] byteGain = new byte[2];

        
        public HSSCalibDialog()
        {
            InitializeComponent();

        }

        private void HSSCalibDialog_Load(object sender, EventArgs e)
        {
            pv3tu4Main = (PV3TU4Main)Owner;
            pv3Connection = pv3tu4Main.USBConnection;
            pv3Data = pv3tu4Main.PV3Data;

            if (pv3Connection.connectionState == USBClass.CONNECTION_SUCCESSFUL)
            {
                connectionErrorLabel.Visible = false;
                // Enable low speed data acquisition timer
                //lpsTimer.Enabled = true;
                // Enable controls
                foreach (Control button in this.Controls)
                {
                    if (button is Button && button != okButton)
                    {
                        button.Enabled = true;
                    }
                }

                // Read & display low speed sensor calibration data:
                cmd = PV3DataTypes.PV3CommandType.RD_HSSCD;
                pv3Connection.OutBuffer[1] = (byte)cmd;
                pv3Connection.SendViaUSB();

                pv3Connection.ReceiveViaUSB();

                pv3Data.PPROXGain = (ushort)((uint)(pv3Connection.InBuffer[3] << 8) + (uint)pv3Connection.InBuffer[2]);
                pproxGainDisplayLabel.Text = pv3Data.PPROXGain.ToString();
                pv3Data.PLEFTGain = (ushort)((uint)(pv3Connection.InBuffer[5] << 8) + (uint)pv3Connection.InBuffer[4]);
                pleftGainDisplayLabel.Text = pv3Data.PLEFTGain.ToString();
                pv3Data.PRGHTGain = (ushort)((uint)(pv3Connection.InBuffer[7] << 8) + (uint)pv3Connection.InBuffer[6]);
                prghtGainDisplayLabel.Text = pv3Data.PRGHTGain.ToString();
                pv3Data.PHIGHGain = (ushort)((uint)(pv3Connection.InBuffer[9] << 8) + (uint)pv3Connection.InBuffer[8]);
                phighGainDisplayLabel.Text = pv3Data.PHIGHGain.ToString();
                pv3Data.AUXINGain = (ushort)((uint)(pv3Connection.InBuffer[11] << 8) + (uint)pv3Connection.InBuffer[10]);
                auxinGainDisplayLabel.Text = pv3Data.AUXINGain.ToString();

            }
            else
            {
                connectionErrorLabel.Visible = true;
                // Disable low speed data acquisition timer
                //lpsTimer.Enabled = false;
                // Disable controls
                foreach (Control button in this.Controls)
                {
                    if (button is Button && button != okButton)
                    {
                        button.Enabled = false;
                    }
                }
            }
        }

        private void zeroAllButton_Click(object sender, EventArgs e)
        {
            cmd = PV3DataTypes.PV3CommandType.RD_HSSDP;
            pv3Connection.OutBuffer[1] = (byte)cmd;
            pv3Connection.SendViaUSB();

            pv3Connection.ReceiveViaUSB();
            pv3Data.PPROXRaw = (ushort)((uint)(pv3Connection.InBuffer[5] << 8) + (uint)pv3Connection.InBuffer[4]);
            pproxZeroDisplayLabel.Text = pv3Data.PPROXRaw.ToString();
            pv3Data.PPROXZero = pv3Data.PPROXRaw;
            pv3Data.PLEFTRaw = (ushort)((uint)(pv3Connection.InBuffer[7] << 8) + (uint)pv3Connection.InBuffer[6]);
            pleftZeroDisplayLabel.Text = pv3Data.PLEFTRaw.ToString();
            pv3Data.PLEFTZero = pv3Data.PLEFTRaw;
            pv3Data.PRGHTRaw = (ushort)((uint)(pv3Connection.InBuffer[9] << 8) + (uint)pv3Connection.InBuffer[8]);
            prghtZeroDisplayLabel.Text = pv3Data.PRGHTRaw.ToString();
            pv3Data.PRGHTZero = pv3Data.PRGHTRaw;
            pv3Data.PHIGHRaw = (ushort)((uint)(pv3Connection.InBuffer[11] << 8) + (uint)pv3Connection.InBuffer[10]);
            phighZeroDisplayLabel.Text = pv3Data.PHIGHRaw.ToString();
            pv3Data.PHIGHZero = pv3Data.PHIGHRaw;
            pv3Data.AUXINRaw = (ushort)((uint)(pv3Connection.InBuffer[13] << 8) + (uint)pv3Connection.InBuffer[12]);
            auxinZeroDisplayLabel.Text = pv3Data.AUXINRaw.ToString();
            pv3Data.AUXINZero = pv3Data.AUXINRaw;
        }

        private void pproxZeroButton_Click(object sender, EventArgs e)
        {
            pv3Data.PPROXZero = pv3Data.PPROXRaw;
            pproxZeroDisplayLabel.Text = pv3Data.PPROXRaw.ToString();
        }

        private void pleftZeroButton_Click(object sender, EventArgs e)
        {
            pv3Data.PLEFTZero = pv3Data.PLEFTRaw;
            pleftZeroDisplayLabel.Text = pv3Data.PLEFTRaw.ToString();
        }

        private void prghtZeroButton_Click(object sender, EventArgs e)
        {
            pv3Data.PRGHTZero = pv3Data.PRGHTRaw;
            prghtZeroDisplayLabel.Text = pv3Data.PRGHTRaw.ToString();
        }

        private void phighZeroButton_Click(object sender, EventArgs e)
        {
            pv3Data.PHIGHZero = pv3Data.PHIGHRaw;
            phighZeroDisplayLabel.Text = pv3Data.PHIGHRaw.ToString();
        }

        private void auxinZeroButton_Click(object sender, EventArgs e)
        {
            pv3Data.AUXINZero = pv3Data.AUXINRaw;
            auxinZeroDisplayLabel.Text = pv3Data.AUXINRaw.ToString();
        }

        private void setPPROXGainButton_Click(object sender, EventArgs e)
        {
            cmd = PV3DataTypes.PV3CommandType.SET_CH0_GAIN;
            pv3Connection.OutBuffer[1] = (byte)cmd;
            ushort intGain = Convert.ToUInt16(pproxGainTextBox.Text);
            pv3Data.PPROXGain = intGain;
            pproxGainDisplayLabel.Text = pv3Data.PPROXGain.ToString();
            byteGain[1] = (byte)(intGain / 256);
            byteGain[0] = (byte)(intGain % 256);
            pv3Connection.OutBuffer[2] = byteGain[0];
            pv3Connection.OutBuffer[3] = byteGain[1];
            pv3Connection.SendViaUSB();
            pv3Connection.ReceiveViaUSB();
        }

        private void setPLEFTGainButton_Click(object sender, EventArgs e)
        {
            cmd = PV3DataTypes.PV3CommandType.SET_CH1_GAIN;
            pv3Connection.OutBuffer[1] = (byte)cmd;
            ushort intGain = Convert.ToUInt16(pleftGainTextBox.Text);
            pv3Data.PPROXGain = intGain;
            pleftGainDisplayLabel.Text = pv3Data.PLEFTGain.ToString();
            byteGain[1] = (byte)(intGain / 256);
            byteGain[0] = (byte)(intGain % 256);
            pv3Connection.OutBuffer[2] = byteGain[0];
            pv3Connection.OutBuffer[3] = byteGain[1];
            pv3Connection.SendViaUSB();
            pv3Connection.ReceiveViaUSB();
        }

        private void setPRGHTGainButton_Click(object sender, EventArgs e)
        {
            cmd = PV3DataTypes.PV3CommandType.SET_CH2_GAIN;
            pv3Connection.OutBuffer[1] = (byte)cmd;
            ushort intGain = Convert.ToUInt16(prghtGainTextBox.Text);
            pv3Data.PPROXGain = intGain;
            prghtGainDisplayLabel.Text = pv3Data.PRGHTGain.ToString();
            byteGain[1] = (byte)(intGain / 256);
            byteGain[0] = (byte)(intGain % 256);
            pv3Connection.OutBuffer[2] = byteGain[0];
            pv3Connection.OutBuffer[3] = byteGain[1];
            pv3Connection.SendViaUSB();
            pv3Connection.ReceiveViaUSB();
        }

        private void setPHIGHGainButton_Click(object sender, EventArgs e)
        {
            cmd = PV3DataTypes.PV3CommandType.SET_CH3_GAIN;
            pv3Connection.OutBuffer[1] = (byte)cmd;
            ushort intGain = Convert.ToUInt16(phighGainTextBox.Text);
            pv3Data.PHIGHGain = intGain;
            phighGainDisplayLabel.Text = pv3Data.PHIGHGain.ToString();
            byteGain[1] = (byte)(intGain / 256);
            byteGain[0] = (byte)(intGain % 256);
            pv3Connection.OutBuffer[2] = byteGain[0];
            pv3Connection.OutBuffer[3] = byteGain[1];
            pv3Connection.SendViaUSB();
            pv3Connection.ReceiveViaUSB();
        }

        private void setAUXINGainButton_Click(object sender, EventArgs e)
        {
            cmd = PV3DataTypes.PV3CommandType.SET_CH4_GAIN;
            pv3Connection.OutBuffer[1] = (byte)cmd;
            ushort intGain = Convert.ToUInt16(auxinGainTextBox.Text);
            pv3Data.AUXINGain = intGain;
            auxinGainDisplayLabel.Text = pv3Data.AUXINGain.ToString();
            byteGain[1] = (byte)(intGain / 256);
            byteGain[0] = (byte)(intGain % 256);
            pv3Connection.OutBuffer[2] = byteGain[0];
            pv3Connection.OutBuffer[3] = byteGain[1];
            pv3Connection.SendViaUSB();
            pv3Connection.ReceiveViaUSB();
        }

        private void readAllGainValuesButton_Click(object sender, EventArgs e)
        {
            cmd = PV3DataTypes.PV3CommandType.RD_HSSCD;
            pv3Connection.OutBuffer[1] = (byte)cmd;
            pv3Connection.SendViaUSB();
            
            pv3Connection.ReceiveViaUSB();
            pv3Data.PPROXGain = (ushort)((uint)(pv3Connection.InBuffer[3] << 8) + (uint)pv3Connection.InBuffer[2]);
            pproxGainDisplayLabel.Text = pv3Data.PPROXGain.ToString();
            pv3Data.PLEFTGain = (ushort)((uint)(pv3Connection.InBuffer[5] << 8) + (uint)pv3Connection.InBuffer[4]);
            pleftGainDisplayLabel.Text = pv3Data.PLEFTGain.ToString();
            pv3Data.PRGHTGain = (ushort)((uint)(pv3Connection.InBuffer[7] << 8) + (uint)pv3Connection.InBuffer[6]);
            prghtGainDisplayLabel.Text = pv3Data.PRGHTGain.ToString();
            pv3Data.PHIGHGain = (ushort)((uint)(pv3Connection.InBuffer[9] << 8) + (uint)pv3Connection.InBuffer[8]);
            phighGainDisplayLabel.Text = pv3Data.PHIGHGain.ToString();
            pv3Data.AUXINGain = (ushort)((uint)(pv3Connection.InBuffer[11] << 8) + (uint)pv3Connection.InBuffer[10]);
            auxinGainDisplayLabel.Text = pv3Data.AUXINGain.ToString();
        }
    }
}
