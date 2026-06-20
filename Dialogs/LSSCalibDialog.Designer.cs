namespace PV3TestUtility4
{
    partial class LSSCalibDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gainTBLabel = new System.Windows.Forms.Label();
            this.gainLabel = new System.Windows.Forms.Label();
            this.rawLabel = new System.Windows.Forms.Label();
            this.setFiO2GainButton = new System.Windows.Forms.Button();
            this.fio2GainDisplayLabel = new System.Windows.Forms.Label();
            this.fio2GainTextBox = new System.Windows.Forms.TextBox();
            this.fio2RawDisplayLabel = new System.Windows.Forms.Label();
            this.fio2MeasurementDisplayLabel = new System.Windows.Forms.Label();
            this.measurementLabel = new System.Windows.Forms.Label();
            this.offsetDisplayBalel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.fio2OffsetDisplayLabel = new System.Windows.Forms.Label();
            this.tleftOffsetDisplayLabel = new System.Windows.Forms.Label();
            this.tleftMeasurementDisplayLabel = new System.Windows.Forms.Label();
            this.setTLEFTGainButton = new System.Windows.Forms.Button();
            this.tleftGainDisplayLabel = new System.Windows.Forms.Label();
            this.tleftGainTextBox = new System.Windows.Forms.TextBox();
            this.tleftRawDisplayLabel = new System.Windows.Forms.Label();
            this.trghtOffsetDisplayLabel = new System.Windows.Forms.Label();
            this.trghtMeasurementDisplayLabel = new System.Windows.Forms.Label();
            this.setTRGHTGainButton = new System.Windows.Forms.Button();
            this.trghtGainDisplayLabel = new System.Windows.Forms.Label();
            this.trghtGainTextBox = new System.Windows.Forms.TextBox();
            this.trghtRawDisplayLabel = new System.Windows.Forms.Label();
            this.lpsTimer = new System.Windows.Forms.Timer(this.components);
            this.connectionErrorLabel = new System.Windows.Forms.Label();
            this.setFiO2OffsetButton = new System.Windows.Forms.Button();
            this.fio2OffsetTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // gainTBLabel
            // 
            this.gainTBLabel.Location = new System.Drawing.Point(296, 11);
            this.gainTBLabel.Name = "gainTBLabel";
            this.gainTBLabel.Size = new System.Drawing.Size(52, 23);
            this.gainTBLabel.TabIndex = 43;
            this.gainTBLabel.Text = "Gain";
            this.gainTBLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gainLabel
            // 
            this.gainLabel.Location = new System.Drawing.Point(458, 9);
            this.gainLabel.Name = "gainLabel";
            this.gainLabel.Size = new System.Drawing.Size(73, 23);
            this.gainLabel.TabIndex = 42;
            this.gainLabel.Text = "Gain";
            this.gainLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rawLabel
            // 
            this.rawLabel.Location = new System.Drawing.Point(12, 9);
            this.rawLabel.Name = "rawLabel";
            this.rawLabel.Size = new System.Drawing.Size(44, 23);
            this.rawLabel.TabIndex = 41;
            this.rawLabel.Text = "Raw";
            this.rawLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // setFiO2GainButton
            // 
            this.setFiO2GainButton.Location = new System.Drawing.Point(354, 35);
            this.setFiO2GainButton.Name = "setFiO2GainButton";
            this.setFiO2GainButton.Size = new System.Drawing.Size(98, 23);
            this.setFiO2GainButton.TabIndex = 40;
            this.setFiO2GainButton.Text = "Set Gain FiO2";
            this.setFiO2GainButton.UseVisualStyleBackColor = true;
            this.setFiO2GainButton.Click += new System.EventHandler(this.setFiO2GainButton_Click);
            // 
            // fio2GainDisplayLabel
            // 
            this.fio2GainDisplayLabel.Location = new System.Drawing.Point(458, 40);
            this.fio2GainDisplayLabel.Name = "fio2GainDisplayLabel";
            this.fio2GainDisplayLabel.Size = new System.Drawing.Size(73, 23);
            this.fio2GainDisplayLabel.TabIndex = 39;
            this.fio2GainDisplayLabel.Text = "Not set/read";
            this.fio2GainDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fio2GainTextBox
            // 
            this.fio2GainTextBox.Location = new System.Drawing.Point(296, 37);
            this.fio2GainTextBox.Name = "fio2GainTextBox";
            this.fio2GainTextBox.Size = new System.Drawing.Size(52, 20);
            this.fio2GainTextBox.TabIndex = 38;
            this.fio2GainTextBox.Text = "2394";
            this.fio2GainTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // fio2RawDisplayLabel
            // 
            this.fio2RawDisplayLabel.Location = new System.Drawing.Point(9, 38);
            this.fio2RawDisplayLabel.Name = "fio2RawDisplayLabel";
            this.fio2RawDisplayLabel.Size = new System.Drawing.Size(47, 23);
            this.fio2RawDisplayLabel.TabIndex = 37;
            this.fio2RawDisplayLabel.Text = "0";
            this.fio2RawDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fio2MeasurementDisplayLabel
            // 
            this.fio2MeasurementDisplayLabel.Location = new System.Drawing.Point(537, 40);
            this.fio2MeasurementDisplayLabel.Name = "fio2MeasurementDisplayLabel";
            this.fio2MeasurementDisplayLabel.Size = new System.Drawing.Size(75, 23);
            this.fio2MeasurementDisplayLabel.TabIndex = 44;
            this.fio2MeasurementDisplayLabel.Text = "0.0";
            this.fio2MeasurementDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // measurementLabel
            // 
            this.measurementLabel.Location = new System.Drawing.Point(531, 9);
            this.measurementLabel.Name = "measurementLabel";
            this.measurementLabel.Size = new System.Drawing.Size(81, 23);
            this.measurementLabel.TabIndex = 45;
            this.measurementLabel.Text = "Measurement";
            this.measurementLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // offsetDisplayBalel
            // 
            this.offsetDisplayBalel.Location = new System.Drawing.Point(223, 11);
            this.offsetDisplayBalel.Name = "offsetDisplayBalel";
            this.offsetDisplayBalel.Size = new System.Drawing.Size(67, 23);
            this.offsetDisplayBalel.TabIndex = 46;
            this.offsetDisplayBalel.Text = "Offset";
            this.offsetDisplayBalel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(537, 171);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 47;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // fio2OffsetDisplayLabel
            // 
            this.fio2OffsetDisplayLabel.Location = new System.Drawing.Point(223, 40);
            this.fio2OffsetDisplayLabel.Name = "fio2OffsetDisplayLabel";
            this.fio2OffsetDisplayLabel.Size = new System.Drawing.Size(67, 23);
            this.fio2OffsetDisplayLabel.TabIndex = 48;
            this.fio2OffsetDisplayLabel.Text = "Not set/read";
            this.fio2OffsetDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tleftOffsetDisplayLabel
            // 
            this.tleftOffsetDisplayLabel.Location = new System.Drawing.Point(223, 99);
            this.tleftOffsetDisplayLabel.Name = "tleftOffsetDisplayLabel";
            this.tleftOffsetDisplayLabel.Size = new System.Drawing.Size(67, 23);
            this.tleftOffsetDisplayLabel.TabIndex = 54;
            this.tleftOffsetDisplayLabel.Text = "0";
            this.tleftOffsetDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tleftMeasurementDisplayLabel
            // 
            this.tleftMeasurementDisplayLabel.Location = new System.Drawing.Point(537, 99);
            this.tleftMeasurementDisplayLabel.Name = "tleftMeasurementDisplayLabel";
            this.tleftMeasurementDisplayLabel.Size = new System.Drawing.Size(75, 23);
            this.tleftMeasurementDisplayLabel.TabIndex = 53;
            this.tleftMeasurementDisplayLabel.Text = "0.0";
            this.tleftMeasurementDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // setTLEFTGainButton
            // 
            this.setTLEFTGainButton.Location = new System.Drawing.Point(354, 94);
            this.setTLEFTGainButton.Name = "setTLEFTGainButton";
            this.setTLEFTGainButton.Size = new System.Drawing.Size(98, 23);
            this.setTLEFTGainButton.TabIndex = 52;
            this.setTLEFTGainButton.Text = "Set Gain TLEFT";
            this.setTLEFTGainButton.UseVisualStyleBackColor = true;
            this.setTLEFTGainButton.Click += new System.EventHandler(this.setTLEFTGainButton_Click);
            // 
            // tleftGainDisplayLabel
            // 
            this.tleftGainDisplayLabel.Location = new System.Drawing.Point(458, 99);
            this.tleftGainDisplayLabel.Name = "tleftGainDisplayLabel";
            this.tleftGainDisplayLabel.Size = new System.Drawing.Size(73, 23);
            this.tleftGainDisplayLabel.TabIndex = 51;
            this.tleftGainDisplayLabel.Text = "Not set/read";
            this.tleftGainDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tleftGainTextBox
            // 
            this.tleftGainTextBox.Location = new System.Drawing.Point(296, 96);
            this.tleftGainTextBox.Name = "tleftGainTextBox";
            this.tleftGainTextBox.Size = new System.Drawing.Size(52, 20);
            this.tleftGainTextBox.TabIndex = 50;
            this.tleftGainTextBox.Text = "1";
            this.tleftGainTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tleftRawDisplayLabel
            // 
            this.tleftRawDisplayLabel.Location = new System.Drawing.Point(9, 97);
            this.tleftRawDisplayLabel.Name = "tleftRawDisplayLabel";
            this.tleftRawDisplayLabel.Size = new System.Drawing.Size(47, 23);
            this.tleftRawDisplayLabel.TabIndex = 49;
            this.tleftRawDisplayLabel.Text = "0";
            this.tleftRawDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // trghtOffsetDisplayLabel
            // 
            this.trghtOffsetDisplayLabel.Location = new System.Drawing.Point(223, 125);
            this.trghtOffsetDisplayLabel.Name = "trghtOffsetDisplayLabel";
            this.trghtOffsetDisplayLabel.Size = new System.Drawing.Size(67, 23);
            this.trghtOffsetDisplayLabel.TabIndex = 60;
            this.trghtOffsetDisplayLabel.Text = "0";
            this.trghtOffsetDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // trghtMeasurementDisplayLabel
            // 
            this.trghtMeasurementDisplayLabel.Location = new System.Drawing.Point(537, 125);
            this.trghtMeasurementDisplayLabel.Name = "trghtMeasurementDisplayLabel";
            this.trghtMeasurementDisplayLabel.Size = new System.Drawing.Size(75, 23);
            this.trghtMeasurementDisplayLabel.TabIndex = 59;
            this.trghtMeasurementDisplayLabel.Text = "0.0";
            this.trghtMeasurementDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // setTRGHTGainButton
            // 
            this.setTRGHTGainButton.Location = new System.Drawing.Point(354, 120);
            this.setTRGHTGainButton.Name = "setTRGHTGainButton";
            this.setTRGHTGainButton.Size = new System.Drawing.Size(98, 23);
            this.setTRGHTGainButton.TabIndex = 58;
            this.setTRGHTGainButton.Text = "Set Gain TRGHT";
            this.setTRGHTGainButton.UseVisualStyleBackColor = true;
            this.setTRGHTGainButton.Click += new System.EventHandler(this.setTRGHTGainButton_Click);
            // 
            // trghtGainDisplayLabel
            // 
            this.trghtGainDisplayLabel.Location = new System.Drawing.Point(458, 125);
            this.trghtGainDisplayLabel.Name = "trghtGainDisplayLabel";
            this.trghtGainDisplayLabel.Size = new System.Drawing.Size(73, 23);
            this.trghtGainDisplayLabel.TabIndex = 57;
            this.trghtGainDisplayLabel.Text = "Not set/read";
            this.trghtGainDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // trghtGainTextBox
            // 
            this.trghtGainTextBox.Location = new System.Drawing.Point(296, 122);
            this.trghtGainTextBox.Name = "trghtGainTextBox";
            this.trghtGainTextBox.Size = new System.Drawing.Size(52, 20);
            this.trghtGainTextBox.TabIndex = 56;
            this.trghtGainTextBox.Text = "1";
            this.trghtGainTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // trghtRawDisplayLabel
            // 
            this.trghtRawDisplayLabel.Location = new System.Drawing.Point(9, 123);
            this.trghtRawDisplayLabel.Name = "trghtRawDisplayLabel";
            this.trghtRawDisplayLabel.Size = new System.Drawing.Size(47, 23);
            this.trghtRawDisplayLabel.TabIndex = 55;
            this.trghtRawDisplayLabel.Text = "0";
            this.trghtRawDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lpsTimer
            // 
            this.lpsTimer.Interval = 1000;
            this.lpsTimer.Tick += new System.EventHandler(this.lpsTimer_Tick);
            // 
            // connectionErrorLabel
            // 
            this.connectionErrorLabel.AutoSize = true;
            this.connectionErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.connectionErrorLabel.Location = new System.Drawing.Point(9, 176);
            this.connectionErrorLabel.Name = "connectionErrorLabel";
            this.connectionErrorLabel.Size = new System.Drawing.Size(529, 13);
            this.connectionErrorLabel.TabIndex = 61;
            this.connectionErrorLabel.Text = "No valid connection to the PneuView system detected; Close this dialog and connec" +
    "t through USB to proceed.";
            this.connectionErrorLabel.Visible = false;
            // 
            // setFiO2OffsetButton
            // 
            this.setFiO2OffsetButton.Location = new System.Drawing.Point(120, 33);
            this.setFiO2OffsetButton.Name = "setFiO2OffsetButton";
            this.setFiO2OffsetButton.Size = new System.Drawing.Size(98, 23);
            this.setFiO2OffsetButton.TabIndex = 63;
            this.setFiO2OffsetButton.Text = "Set Offset FiO2";
            this.setFiO2OffsetButton.UseVisualStyleBackColor = true;
            this.setFiO2OffsetButton.Click += new System.EventHandler(this.setFiO2OffsetButton_Click);
            // 
            // fio2OffsetTextBox
            // 
            this.fio2OffsetTextBox.Location = new System.Drawing.Point(62, 35);
            this.fio2OffsetTextBox.Name = "fio2OffsetTextBox";
            this.fio2OffsetTextBox.Size = new System.Drawing.Size(52, 20);
            this.fio2OffsetTextBox.TabIndex = 62;
            this.fio2OffsetTextBox.Text = "5";
            this.fio2OffsetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LSSCalibDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 206);
            this.Controls.Add(this.setFiO2OffsetButton);
            this.Controls.Add(this.fio2OffsetTextBox);
            this.Controls.Add(this.connectionErrorLabel);
            this.Controls.Add(this.trghtOffsetDisplayLabel);
            this.Controls.Add(this.trghtMeasurementDisplayLabel);
            this.Controls.Add(this.setTRGHTGainButton);
            this.Controls.Add(this.trghtGainDisplayLabel);
            this.Controls.Add(this.trghtGainTextBox);
            this.Controls.Add(this.trghtRawDisplayLabel);
            this.Controls.Add(this.tleftOffsetDisplayLabel);
            this.Controls.Add(this.tleftMeasurementDisplayLabel);
            this.Controls.Add(this.setTLEFTGainButton);
            this.Controls.Add(this.tleftGainDisplayLabel);
            this.Controls.Add(this.tleftGainTextBox);
            this.Controls.Add(this.tleftRawDisplayLabel);
            this.Controls.Add(this.fio2OffsetDisplayLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.offsetDisplayBalel);
            this.Controls.Add(this.measurementLabel);
            this.Controls.Add(this.fio2MeasurementDisplayLabel);
            this.Controls.Add(this.gainTBLabel);
            this.Controls.Add(this.gainLabel);
            this.Controls.Add(this.rawLabel);
            this.Controls.Add(this.setFiO2GainButton);
            this.Controls.Add(this.fio2GainDisplayLabel);
            this.Controls.Add(this.fio2GainTextBox);
            this.Controls.Add(this.fio2RawDisplayLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LSSCalibDialog";
            this.Text = "Low Speed Sensor Calibration";
            this.Load += new System.EventHandler(this.LSSCalibDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gainTBLabel;
        private System.Windows.Forms.Label gainLabel;
        private System.Windows.Forms.Label rawLabel;
        private System.Windows.Forms.Button setFiO2GainButton;
        private System.Windows.Forms.Label fio2GainDisplayLabel;
        private System.Windows.Forms.TextBox fio2GainTextBox;
        private System.Windows.Forms.Label fio2RawDisplayLabel;
        private System.Windows.Forms.Label fio2MeasurementDisplayLabel;
        private System.Windows.Forms.Label measurementLabel;
        private System.Windows.Forms.Label offsetDisplayBalel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label fio2OffsetDisplayLabel;
        private System.Windows.Forms.Label tleftOffsetDisplayLabel;
        private System.Windows.Forms.Label tleftMeasurementDisplayLabel;
        private System.Windows.Forms.Button setTLEFTGainButton;
        private System.Windows.Forms.Label tleftGainDisplayLabel;
        private System.Windows.Forms.TextBox tleftGainTextBox;
        private System.Windows.Forms.Label tleftRawDisplayLabel;
        private System.Windows.Forms.Label trghtOffsetDisplayLabel;
        private System.Windows.Forms.Label trghtMeasurementDisplayLabel;
        private System.Windows.Forms.Button setTRGHTGainButton;
        private System.Windows.Forms.Label trghtGainDisplayLabel;
        private System.Windows.Forms.TextBox trghtGainTextBox;
        private System.Windows.Forms.Label trghtRawDisplayLabel;
        private System.Windows.Forms.Timer lpsTimer;
        private System.Windows.Forms.Label connectionErrorLabel;
        private System.Windows.Forms.Button setFiO2OffsetButton;
        private System.Windows.Forms.TextBox fio2OffsetTextBox;
    }
}