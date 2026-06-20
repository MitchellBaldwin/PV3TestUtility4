namespace PV3TestUtility4
{
    partial class CompCalibDialog
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
            this.connectionErrorLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cc0TextBox = new System.Windows.Forms.TextBox();
            this.cc1TextBox = new System.Windows.Forms.TextBox();
            this.cc2TextBox = new System.Windows.Forms.TextBox();
            this.cc3TextBox = new System.Windows.Forms.TextBox();
            this.writeCCDataButton = new System.Windows.Forms.Button();
            this.readCCDataButton = new System.Windows.Forms.Button();
            this.cc0DisplayLabel = new System.Windows.Forms.Label();
            this.cc1DisplayLabel = new System.Windows.Forms.Label();
            this.cc2DisplayLabel = new System.Windows.Forms.Label();
            this.cc3DisplayLabel = new System.Windows.Forms.Label();
            this.ccdToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.progCompDisplayLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rightRadioButton = new System.Windows.Forms.RadioButton();
            this.leftRadioButton = new System.Windows.Forms.RadioButton();
            this.ccdToolStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectionErrorLabel
            // 
            this.connectionErrorLabel.AutoSize = true;
            this.connectionErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.connectionErrorLabel.Location = new System.Drawing.Point(12, 239);
            this.connectionErrorLabel.Name = "connectionErrorLabel";
            this.connectionErrorLabel.Size = new System.Drawing.Size(529, 13);
            this.connectionErrorLabel.TabIndex = 64;
            this.connectionErrorLabel.Text = "No valid connection to the PneuView system detected; Close this dialog and connec" +
    "t through USB to proceed.";
            this.connectionErrorLabel.Visible = false;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(582, 234);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 63;
            this.okButton.Text = "Close";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cc0TextBox
            // 
            this.cc0TextBox.Location = new System.Drawing.Point(15, 87);
            this.cc0TextBox.Name = "cc0TextBox";
            this.cc0TextBox.Size = new System.Drawing.Size(100, 20);
            this.cc0TextBox.TabIndex = 0;
            this.cc0TextBox.Text = "0.0";
            this.cc0TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cc1TextBox
            // 
            this.cc1TextBox.Location = new System.Drawing.Point(15, 113);
            this.cc1TextBox.Name = "cc1TextBox";
            this.cc1TextBox.Size = new System.Drawing.Size(100, 20);
            this.cc1TextBox.TabIndex = 1;
            this.cc1TextBox.Text = "1.1";
            this.cc1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cc2TextBox
            // 
            this.cc2TextBox.Location = new System.Drawing.Point(15, 139);
            this.cc2TextBox.Name = "cc2TextBox";
            this.cc2TextBox.Size = new System.Drawing.Size(100, 20);
            this.cc2TextBox.TabIndex = 2;
            this.cc2TextBox.Text = "2.2";
            this.cc2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cc3TextBox
            // 
            this.cc3TextBox.Location = new System.Drawing.Point(15, 165);
            this.cc3TextBox.Name = "cc3TextBox";
            this.cc3TextBox.Size = new System.Drawing.Size(100, 20);
            this.cc3TextBox.TabIndex = 3;
            this.cc3TextBox.Text = "3.3";
            this.cc3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // writeCCDataButton
            // 
            this.writeCCDataButton.Location = new System.Drawing.Point(121, 110);
            this.writeCCDataButton.Name = "writeCCDataButton";
            this.writeCCDataButton.Size = new System.Drawing.Size(104, 23);
            this.writeCCDataButton.TabIndex = 4;
            this.writeCCDataButton.Text = "Write CC Data";
            this.writeCCDataButton.UseVisualStyleBackColor = true;
            this.writeCCDataButton.Click += new System.EventHandler(this.writeCCDataButton_Click);
            // 
            // readCCDataButton
            // 
            this.readCCDataButton.Location = new System.Drawing.Point(231, 111);
            this.readCCDataButton.Name = "readCCDataButton";
            this.readCCDataButton.Size = new System.Drawing.Size(104, 23);
            this.readCCDataButton.TabIndex = 5;
            this.readCCDataButton.Text = "Read CC Data";
            this.readCCDataButton.UseVisualStyleBackColor = true;
            this.readCCDataButton.Click += new System.EventHandler(this.readCCDataButton_Click);
            // 
            // cc0DisplayLabel
            // 
            this.cc0DisplayLabel.Location = new System.Drawing.Point(347, 90);
            this.cc0DisplayLabel.Name = "cc0DisplayLabel";
            this.cc0DisplayLabel.Size = new System.Drawing.Size(100, 17);
            this.cc0DisplayLabel.TabIndex = 71;
            this.cc0DisplayLabel.Text = "CC[0} not read";
            this.cc0DisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cc1DisplayLabel
            // 
            this.cc1DisplayLabel.Location = new System.Drawing.Point(347, 116);
            this.cc1DisplayLabel.Name = "cc1DisplayLabel";
            this.cc1DisplayLabel.Size = new System.Drawing.Size(100, 17);
            this.cc1DisplayLabel.TabIndex = 72;
            this.cc1DisplayLabel.Text = "CC[1] not read";
            this.cc1DisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cc2DisplayLabel
            // 
            this.cc2DisplayLabel.Location = new System.Drawing.Point(347, 142);
            this.cc2DisplayLabel.Name = "cc2DisplayLabel";
            this.cc2DisplayLabel.Size = new System.Drawing.Size(100, 17);
            this.cc2DisplayLabel.TabIndex = 73;
            this.cc2DisplayLabel.Text = "CC[2} not read";
            this.cc2DisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cc3DisplayLabel
            // 
            this.cc3DisplayLabel.Location = new System.Drawing.Point(347, 168);
            this.cc3DisplayLabel.Name = "cc3DisplayLabel";
            this.cc3DisplayLabel.Size = new System.Drawing.Size(100, 17);
            this.cc3DisplayLabel.TabIndex = 74;
            this.cc3DisplayLabel.Text = "CC[3} not read";
            this.cc3DisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ccdToolStrip
            // 
            this.ccdToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton10,
            this.toolStripButton9,
            this.toolStripButton8,
            this.toolStripButton7,
            this.toolStripButton6,
            this.toolStripButton5,
            this.toolStripButton4,
            this.toolStripButton3,
            this.toolStripButton2});
            this.ccdToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ccdToolStrip.Name = "ccdToolStrip";
            this.ccdToolStrip.Size = new System.Drawing.Size(669, 25);
            this.ccdToolStrip.TabIndex = 75;
            this.ccdToolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton1.Tag = "1";
            this.toolStripButton1.Text = "0.01";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.AutoSize = false;
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton10.Tag = "2";
            this.toolStripButton10.Text = "0.02";
            this.toolStripButton10.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripButton10.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.AutoSize = false;
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton9.Tag = "3";
            this.toolStripButton9.Text = "0.03";
            this.toolStripButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.AutoSize = false;
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton8.Tag = "4";
            this.toolStripButton8.Text = "0.04";
            this.toolStripButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.AutoSize = false;
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton7.Tag = "5";
            this.toolStripButton7.Text = "0.05";
            this.toolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton6.Tag = "6";
            this.toolStripButton6.Text = "0.06";
            this.toolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AutoSize = false;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton5.Tag = "7";
            this.toolStripButton5.Text = "0.07";
            this.toolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton4.Tag = "8";
            this.toolStripButton4.Text = "0.08";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton3.Tag = "9";
            this.toolStripButton3.Text = "0.09";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton2.Tag = "10";
            this.toolStripButton2.Text = "0.10";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // progCompDisplayLabel
            // 
            this.progCompDisplayLabel.AutoSize = true;
            this.progCompDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progCompDisplayLabel.Location = new System.Drawing.Point(12, 60);
            this.progCompDisplayLabel.Name = "progCompDisplayLabel";
            this.progCompDisplayLabel.Size = new System.Drawing.Size(218, 13);
            this.progCompDisplayLabel.TabIndex = 76;
            this.progCompDisplayLabel.Text = "Porgramming compliance setting 0.01";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rightRadioButton);
            this.groupBox1.Controls.Add(this.leftRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(15, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 17);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Lung:";
            // 
            // rightRadioButton
            // 
            this.rightRadioButton.AutoSize = true;
            this.rightRadioButton.Location = new System.Drawing.Point(126, 0);
            this.rightRadioButton.Name = "rightRadioButton";
            this.rightRadioButton.Size = new System.Drawing.Size(50, 17);
            this.rightRadioButton.TabIndex = 1;
            this.rightRadioButton.Text = "Right";
            this.rightRadioButton.UseVisualStyleBackColor = true;
            this.rightRadioButton.Click += new System.EventHandler(this.leftRadioButton_CheckedChanged);
            // 
            // leftRadioButton
            // 
            this.leftRadioButton.AutoSize = true;
            this.leftRadioButton.Checked = true;
            this.leftRadioButton.Location = new System.Drawing.Point(77, 0);
            this.leftRadioButton.Name = "leftRadioButton";
            this.leftRadioButton.Size = new System.Drawing.Size(43, 17);
            this.leftRadioButton.TabIndex = 0;
            this.leftRadioButton.TabStop = true;
            this.leftRadioButton.Text = "Left";
            this.leftRadioButton.UseVisualStyleBackColor = true;
            this.leftRadioButton.Click += new System.EventHandler(this.leftRadioButton_CheckedChanged);
            // 
            // CompCalibDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 261);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progCompDisplayLabel);
            this.Controls.Add(this.ccdToolStrip);
            this.Controls.Add(this.cc3DisplayLabel);
            this.Controls.Add(this.cc2DisplayLabel);
            this.Controls.Add(this.cc1DisplayLabel);
            this.Controls.Add(this.cc0DisplayLabel);
            this.Controls.Add(this.readCCDataButton);
            this.Controls.Add(this.writeCCDataButton);
            this.Controls.Add(this.cc3TextBox);
            this.Controls.Add(this.cc2TextBox);
            this.Controls.Add(this.cc1TextBox);
            this.Controls.Add(this.cc0TextBox);
            this.Controls.Add(this.connectionErrorLabel);
            this.Controls.Add(this.okButton);
            this.Name = "CompCalibDialog";
            this.Text = "Compliance Calibration";
            this.Load += new System.EventHandler(this.CompCalibDialog_Load);
            this.ccdToolStrip.ResumeLayout(false);
            this.ccdToolStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label connectionErrorLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox cc0TextBox;
        private System.Windows.Forms.TextBox cc1TextBox;
        private System.Windows.Forms.TextBox cc2TextBox;
        private System.Windows.Forms.TextBox cc3TextBox;
        private System.Windows.Forms.Button writeCCDataButton;
        private System.Windows.Forms.Button readCCDataButton;
        private System.Windows.Forms.Label cc0DisplayLabel;
        private System.Windows.Forms.Label cc1DisplayLabel;
        private System.Windows.Forms.Label cc2DisplayLabel;
        private System.Windows.Forms.Label cc3DisplayLabel;
        private System.Windows.Forms.ToolStrip ccdToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label progCompDisplayLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rightRadioButton;
        private System.Windows.Forms.RadioButton leftRadioButton;
    }
}