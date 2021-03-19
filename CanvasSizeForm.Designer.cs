namespace Paint
{
    partial class CanvasSizeForm
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
            this.OkButton = new System.Windows.Forms.Button();
            this.CanselButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.largeSizeRadioBottom = new System.Windows.Forms.RadioButton();
            this.mediumSizeRadioButtom = new System.Windows.Forms.RadioButton();
            this.smallSizeRadioButton = new System.Windows.Forms.RadioButton();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.customSizeCheckBox = new System.Windows.Forms.CheckBox();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(12, 184);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CanselButton
            // 
            this.CanselButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CanselButton.Location = new System.Drawing.Point(253, 184);
            this.CanselButton.Name = "CanselButton";
            this.CanselButton.Size = new System.Drawing.Size(75, 23);
            this.CanselButton.TabIndex = 1;
            this.CanselButton.Text = "Cansel";
            this.CanselButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.largeSizeRadioBottom);
            this.groupBox1.Controls.Add(this.mediumSizeRadioButtom);
            this.groupBox1.Controls.Add(this.smallSizeRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 67);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Size of picture";
            // 
            // largeSizeRadioBottom
            // 
            this.largeSizeRadioBottom.AutoSize = true;
            this.largeSizeRadioBottom.Location = new System.Drawing.Point(216, 30);
            this.largeSizeRadioBottom.Name = "largeSizeRadioBottom";
            this.largeSizeRadioBottom.Size = new System.Drawing.Size(66, 17);
            this.largeSizeRadioBottom.TabIndex = 2;
            this.largeSizeRadioBottom.TabStop = true;
            this.largeSizeRadioBottom.Text = "800x600";
            this.largeSizeRadioBottom.UseVisualStyleBackColor = true;
            // 
            // mediumSizeRadioButtom
            // 
            this.mediumSizeRadioButtom.AutoSize = true;
            this.mediumSizeRadioButtom.Location = new System.Drawing.Point(125, 30);
            this.mediumSizeRadioButtom.Name = "mediumSizeRadioButtom";
            this.mediumSizeRadioButtom.Size = new System.Drawing.Size(66, 17);
            this.mediumSizeRadioButtom.TabIndex = 1;
            this.mediumSizeRadioButtom.TabStop = true;
            this.mediumSizeRadioButtom.Text = "640x480";
            this.mediumSizeRadioButtom.UseVisualStyleBackColor = true;
            // 
            // smallSizeRadioButton
            // 
            this.smallSizeRadioButton.AutoSize = true;
            this.smallSizeRadioButton.Location = new System.Drawing.Point(34, 30);
            this.smallSizeRadioButton.Name = "smallSizeRadioButton";
            this.smallSizeRadioButton.Size = new System.Drawing.Size(66, 17);
            this.smallSizeRadioButton.TabIndex = 0;
            this.smallSizeRadioButton.TabStop = true;
            this.smallSizeRadioButton.Text = "320x240";
            this.smallSizeRadioButton.UseVisualStyleBackColor = true;
            // 
            // widthTextBox
            // 
            this.widthTextBox.Enabled = false;
            this.widthTextBox.Location = new System.Drawing.Point(46, 131);
            this.widthTextBox.MaxLength = 4;
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(100, 20);
            this.widthTextBox.TabIndex = 3;
            this.widthTextBox.TextChanged += new System.EventHandler(this.WidthSizeTextBox_TextChanged);
            this.widthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WidthSizeTextBox_KeyPress);
            // 
            // heightTextBox
            // 
            this.heightTextBox.Enabled = false;
            this.heightTextBox.Location = new System.Drawing.Point(194, 131);
            this.heightTextBox.MaxLength = 4;
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(100, 20);
            this.heightTextBox.TabIndex = 4;
            this.heightTextBox.TextChanged += new System.EventHandler(this.HeightSizeTextBox_TextChanged);
            this.heightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HeightSizeTextBox_KeyPress);
            // 
            // customSizeCheckBox
            // 
            this.customSizeCheckBox.AutoSize = true;
            this.customSizeCheckBox.Location = new System.Drawing.Point(12, 95);
            this.customSizeCheckBox.Name = "customSizeCheckBox";
            this.customSizeCheckBox.Size = new System.Drawing.Size(82, 17);
            this.customSizeCheckBox.TabIndex = 5;
            this.customSizeCheckBox.Text = "Custom size";
            this.customSizeCheckBox.UseVisualStyleBackColor = true;
            this.customSizeCheckBox.CheckedChanged += new System.EventHandler(this.CustomSizeCheckBox_CheckedChanged);
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Enabled = false;
            this.heightLabel.Location = new System.Drawing.Point(225, 115);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(38, 13);
            this.heightLabel.TabIndex = 6;
            this.heightLabel.Text = "Height";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Enabled = false;
            this.widthLabel.Location = new System.Drawing.Point(77, 115);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 7;
            this.widthLabel.Text = "Width";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Enabled = false;
            this.xLabel.Location = new System.Drawing.Point(164, 134);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(14, 13);
            this.xLabel.TabIndex = 8;
            this.xLabel.Text = "X";
            // 
            // CanvasSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 219);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.customSizeCheckBox);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CanselButton);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "CanvasSizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Canvas size";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CanselButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton largeSizeRadioBottom;
        private System.Windows.Forms.RadioButton mediumSizeRadioButtom;
        private System.Windows.Forms.RadioButton smallSizeRadioButton;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.CheckBox customSizeCheckBox;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label xLabel;
    }
}