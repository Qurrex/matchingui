namespace QurrexMatch.LoadApp.Dialogs
{
    partial class CustomTestDialog
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
            this.btnMoneyManagement = new System.Windows.Forms.Button();
            this.btnTradingSets = new System.Windows.Forms.Button();
            this.btnPricingSets = new System.Windows.Forms.Button();
            this.btnLoadSettings = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMoneyManagement
            // 
            this.btnMoneyManagement.Location = new System.Drawing.Point(12, 99);
            this.btnMoneyManagement.Name = "btnMoneyManagement";
            this.btnMoneyManagement.Size = new System.Drawing.Size(172, 23);
            this.btnMoneyManagement.TabIndex = 10;
            this.btnMoneyManagement.Text = "Money Management ...";
            this.btnMoneyManagement.UseVisualStyleBackColor = true;
            this.btnMoneyManagement.Click += new System.EventHandler(this.btnMoneyManagement_Click);
            // 
            // btnTradingSets
            // 
            this.btnTradingSets.Location = new System.Drawing.Point(12, 70);
            this.btnTradingSets.Name = "btnTradingSets";
            this.btnTradingSets.Size = new System.Drawing.Size(172, 23);
            this.btnTradingSets.TabIndex = 9;
            this.btnTradingSets.Text = "Trading Settings ...";
            this.btnTradingSets.UseVisualStyleBackColor = true;
            this.btnTradingSets.Click += new System.EventHandler(this.btnTradingSets_Click);
            // 
            // btnPricingSets
            // 
            this.btnPricingSets.Location = new System.Drawing.Point(12, 41);
            this.btnPricingSets.Name = "btnPricingSets";
            this.btnPricingSets.Size = new System.Drawing.Size(172, 23);
            this.btnPricingSets.TabIndex = 8;
            this.btnPricingSets.Text = "Pricing Settings ...";
            this.btnPricingSets.UseVisualStyleBackColor = true;
            this.btnPricingSets.Click += new System.EventHandler(this.btnPricingSets_Click);
            // 
            // btnLoadSettings
            // 
            this.btnLoadSettings.Location = new System.Drawing.Point(12, 12);
            this.btnLoadSettings.Name = "btnLoadSettings";
            this.btnLoadSettings.Size = new System.Drawing.Size(172, 23);
            this.btnLoadSettings.TabIndex = 7;
            this.btnLoadSettings.Text = "Payload Settings ...";
            this.btnLoadSettings.UseVisualStyleBackColor = true;
            this.btnLoadSettings.Click += new System.EventHandler(this.btnLoadSettings_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStartStop.Location = new System.Drawing.Point(12, 218);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(172, 38);
            this.btnStartStop.TabIndex = 11;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            // 
            // CustomTestDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 278);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.btnMoneyManagement);
            this.Controls.Add(this.btnTradingSets);
            this.Controls.Add(this.btnPricingSets);
            this.Controls.Add(this.btnLoadSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CustomTestDialog";
            this.Text = "Custom Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMoneyManagement;
        private System.Windows.Forms.Button btnTradingSets;
        private System.Windows.Forms.Button btnPricingSets;
        private System.Windows.Forms.Button btnLoadSettings;
        private System.Windows.Forms.Button btnStartStop;
    }
}