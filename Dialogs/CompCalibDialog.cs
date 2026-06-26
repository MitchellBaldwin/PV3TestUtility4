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
    public partial class CompCalibDialog : Form
    {
        PV3TU4Main pv3tu4Main;
        USBClass pv3Connection;
        PV3DataTypes pv3Data;
        PV3DataTypes.PV3CommandType cmd;

        byte currentCompliance = 0x01;

        byte[] byteGain = new byte[2];

        public CompCalibDialog()
        {
            InitializeComponent();
        }

        private void CompCalibDialog_Load(object sender, EventArgs e)
        {
            pv3tu4Main = (PV3TU4Main)Owner;
            pv3Connection = pv3tu4Main.USBConnection;
            pv3Data = pv3tu4Main.PV3Data;

            if (pv3Connection.connectionState == USBClass.CONNECTION_SUCCESSFUL)
            {
                connectionErrorLabel.Visible = false;
                foreach (Control button in this.Controls)
                {
                    if (button is Button && button != okButton)
                    {
                        button.Enabled = true;
                    }
                }

                // Read & display compliance coefficients:
                cmd = PV3DataTypes.PV3CommandType.RD_HSSCD;
                pv3Connection.OutBuffer[1] = (byte)cmd;
                pv3Connection.SendViaUSB();

                pv3Connection.ReceiveViaUSB();

                
            }
            else
            {
                connectionErrorLabel.Visible = true;
                foreach (Control button in this.Controls)
                {
                    if (button is Button && button != okButton)
                    {
                        button.Enabled = false;
                    }
                }
            }

        }

        private void writeCCDataButton_Click(object sender, EventArgs e)
        {
            double[] CC;
            CC = new double[4];

            byte command = 0xB0;

            if (leftRadioButton.Checked)
            {
                command = 0xB0;
            }
            else
            {
                command = 0xD0;
            }

            pv3Connection.OutBuffer[1] = (byte)(command + currentCompliance);
 
            CC[0] = Convert.ToDouble(cc0TextBox.Text);
            CC[1] = Convert.ToDouble(cc1TextBox.Text);
            CC[2] = Convert.ToDouble(cc2TextBox.Text);
            CC[3] = Convert.ToDouble(cc3TextBox.Text);

            for (int i = 0; i < 4; ++i)
            {
                byte[] byteArray = BitConverter.GetBytes(CC[i]);
                for (int j = 0; j < 8; ++j)
                {
                    pv3Connection.OutBuffer[i*8 + j + 2] = byteArray[j];
                }
            }
            pv3Connection.SendViaUSB();
            pv3Connection.ReceiveViaUSB();
            pv3tu4Main.DisplayUSBBufferData();

        }

        private void readCCDataButton_Click(object sender, EventArgs e)
        {
            byte command = 0xC0;

            if (leftRadioButton.Checked)
            {
                command = 0xC0;
            }
            else
            {
                command = 0xE0;
            }

            pv3Connection.OutBuffer[1] = (byte)(command + currentCompliance);

            pv3Connection.SendViaUSB();

            pv3Connection.ReceiveViaUSB();
            cc0DisplayLabel.Text = BitConverter.ToDouble(pv3Connection.InBuffer, 2).ToString();
            cc1DisplayLabel.Text = BitConverter.ToDouble(pv3Connection.InBuffer, 10).ToString();
            cc2DisplayLabel.Text = BitConverter.ToDouble(pv3Connection.InBuffer, 18).ToString();
            cc3DisplayLabel.Text = BitConverter.ToDouble(pv3Connection.InBuffer, 26).ToString();

            pv3tu4Main.DisplayUSBBufferData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string side;
            if (leftRadioButton.Checked)
            {
                side = "LEFT";
            }
            else
            {
                side = "RIGHT";
            }

            progCompDisplayLabel.Text = "Programming compliance setting " + ((ToolStripButton)sender).Text + " " + side;
            currentCompliance = Convert.ToByte(((ToolStripButton)sender).Tag);
            readCCDataButton_Click(sender, new EventArgs());
        }

        private void leftRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            double compliance = (double)currentCompliance / 100.0;
            if (leftRadioButton.Checked)
            {
                progCompDisplayLabel.Text = string.Format("Programming compliance setting {0:0.00} LEFT", compliance);
            }
            else
            {
                progCompDisplayLabel.Text = string.Format("Programming compliance setting {0:0.000} RIGHT", compliance);
            }

            readCCDataButton_Click(sender, new EventArgs());
        }

    }
}
