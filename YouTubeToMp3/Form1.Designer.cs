namespace YouTubeToMp3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtUrl = new TextBox();
            btnConvert = new Button();
            lblStatus = new Label();
            cmbBitrate = new ComboBox();
            saveFileDialog1 = new SaveFileDialog();
            btnPaste = new Button();
            SuspendLayout();
            // 
            // txtUrl
            // 
            txtUrl.AllowDrop = true;
            txtUrl.BackColor = SystemColors.ScrollBar;
            txtUrl.BorderStyle = BorderStyle.FixedSingle;
            txtUrl.Location = new Point(12, 179);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(776, 31);
            txtUrl.TabIndex = 1;
            txtUrl.Text = "Please Paste In A Youtube Video Link";
            txtUrl.TextChanged += txtUrl_TextChanged;
            // 
            // btnConvert
            // 
            btnConvert.BackColor = SystemColors.ButtonShadow;
            btnConvert.ForeColor = SystemColors.ActiveCaptionText;
            btnConvert.Location = new Point(676, 312);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(112, 34);
            btnConvert.TabIndex = 1;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = false;
            btnConvert.Click += btnConvert_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 416);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(69, 25);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Output";
            // 
            // cmbBitrate
            // 
            cmbBitrate.AccessibleRole = AccessibleRole.None;
            cmbBitrate.BackColor = SystemColors.Info;
            cmbBitrate.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBitrate.FlatStyle = FlatStyle.System;
            cmbBitrate.FormattingEnabled = true;
            cmbBitrate.Location = new Point(12, 216);
            cmbBitrate.Name = "cmbBitrate";
            cmbBitrate.Size = new Size(182, 33);
            cmbBitrate.Sorted = true;
            cmbBitrate.TabIndex = 3;
            // 
            // btnPaste
            // 
            btnPaste.BackColor = SystemColors.AppWorkspace;
            btnPaste.ForeColor = SystemColors.ActiveCaptionText;
            btnPaste.Location = new Point(676, 47);
            btnPaste.Name = "btnPaste";
            btnPaste.Size = new Size(112, 34);
            btnPaste.TabIndex = 4;
            btnPaste.Text = "Paste";
            btnPaste.UseVisualStyleBackColor = false;
            btnPaste.Click += btnPaste_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = SystemColors.ControlDarkDark;
            CausesValidation = false;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPaste);
            Controls.Add(cmbBitrate);
            Controls.Add(lblStatus);
            Controls.Add(btnConvert);
            Controls.Add(txtUrl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "YouTubeToMp3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUrl;
        private Button btnConvert;
        private Label lblStatus;
        private ComboBox cmbBitrate;
        private SaveFileDialog saveFileDialog1;
        private Button btnPaste;
    }
}
