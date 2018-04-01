namespace QurrexMatch.LoadApp.Dialogs
{
    partial class CommonSettingsDialog
    {
        private System.Windows.Forms.ErrorProvider tbStatTimeframeErrorProvider;

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
            this.button1 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbStatTimeframe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLoggingLevel = new System.Windows.Forms.ComboBox();
            this.cbSaveServersStat = new System.Windows.Forms.CheckBox();
            this.tbTestDuration = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(124, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 164);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tbStatTimeframe
            // 
            this.tbStatTimeframe.Location = new System.Drawing.Point(188, 49);
            this.tbStatTimeframe.Name = "tbStatTimeframe";
            this.tbStatTimeframe.Size = new System.Drawing.Size(62, 20);
            this.tbStatTimeframe.TabIndex = 13;
            this.tbStatTimeframe.Validated += new System.EventHandler(this.tbStatTimeframe_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "charts\' timeframe, sec";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "logging level";
            // 
            // cbLoggingLevel
            // 
            this.cbLoggingLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoggingLevel.FormattingEnabled = true;
            this.cbLoggingLevel.Location = new System.Drawing.Point(188, 75);
            this.cbLoggingLevel.Name = "cbLoggingLevel";
            this.cbLoggingLevel.Size = new System.Drawing.Size(121, 21);
            this.cbLoggingLevel.TabIndex = 15;
            // 
            // cbSaveServersStat
            // 
            this.cbSaveServersStat.AutoSize = true;
            this.cbSaveServersStat.Location = new System.Drawing.Point(71, 107);
            this.cbSaveServersStat.Name = "cbSaveServersStat";
            this.cbSaveServersStat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbSaveServersStat.Size = new System.Drawing.Size(131, 17);
            this.cbSaveServersStat.TabIndex = 16;
            this.cbSaveServersStat.Text = "save server\'s statistics";
            this.cbSaveServersStat.UseVisualStyleBackColor = true;
            // 
            // tbTestDuration
            // 
            this.tbTestDuration.Location = new System.Drawing.Point(188, 23);
            this.tbTestDuration.Name = "tbTestDuration";
            this.tbTestDuration.Size = new System.Drawing.Size(62, 20);
            this.tbTestDuration.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "test duration, sec";
            // 
            // CommonSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 194);
            this.Controls.Add(this.tbTestDuration);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSaveServersStat);
            this.Controls.Add(this.cbLoggingLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbStatTimeframe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CommonSettingsDialog";
            this.Text = "Common Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbStatTimeframe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLoggingLevel;
        private System.Windows.Forms.CheckBox cbSaveServersStat;
        private System.Windows.Forms.TextBox tbTestDuration;
        private System.Windows.Forms.Label label3;
    }
}