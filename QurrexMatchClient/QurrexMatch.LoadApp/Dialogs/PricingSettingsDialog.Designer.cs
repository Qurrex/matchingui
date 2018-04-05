namespace QurrexMatch.LoadApp.Dialogs
{
    partial class PricingSettingsDialog
    {
        private System.Windows.Forms.ErrorProvider amplitudeErrorProvider;

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
            this.gbMode = new System.Windows.Forms.GroupBox();
            this.rbPriceSinusoidal = new System.Windows.Forms.RadioButton();
            this.rbPriceFixed = new System.Windows.Forms.RadioButton();
            this.panelPriceSinus = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAmplitude = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelPriceFixed = new System.Windows.Forms.Panel();
            this.cbSinusPeriod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gbMode.SuspendLayout();
            this.panelPriceSinus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelPriceFixed.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMode
            // 
            this.gbMode.Controls.Add(this.rbPriceSinusoidal);
            this.gbMode.Controls.Add(this.rbPriceFixed);
            this.gbMode.Location = new System.Drawing.Point(6, 3);
            this.gbMode.Name = "gbMode";
            this.gbMode.Size = new System.Drawing.Size(123, 108);
            this.gbMode.TabIndex = 6;
            this.gbMode.TabStop = false;
            this.gbMode.Text = "Pricing Mode";
            // 
            // rbPriceSinusoidal
            // 
            this.rbPriceSinusoidal.AutoSize = true;
            this.rbPriceSinusoidal.Location = new System.Drawing.Point(13, 51);
            this.rbPriceSinusoidal.Name = "rbPriceSinusoidal";
            this.rbPriceSinusoidal.Size = new System.Drawing.Size(73, 17);
            this.rbPriceSinusoidal.TabIndex = 1;
            this.rbPriceSinusoidal.Text = "Sinusoidal";
            this.rbPriceSinusoidal.UseVisualStyleBackColor = true;
            this.rbPriceSinusoidal.CheckedChanged += new System.EventHandler(this.tbDistrEven_CheckedChanged);
            this.rbPriceSinusoidal.ClientSizeChanged += new System.EventHandler(this.rbPriceFixed_ClientSizeChanged);
            // 
            // rbPriceFixed
            // 
            this.rbPriceFixed.AutoSize = true;
            this.rbPriceFixed.Checked = true;
            this.rbPriceFixed.Location = new System.Drawing.Point(13, 28);
            this.rbPriceFixed.Name = "rbPriceFixed";
            this.rbPriceFixed.Size = new System.Drawing.Size(50, 17);
            this.rbPriceFixed.TabIndex = 0;
            this.rbPriceFixed.TabStop = true;
            this.rbPriceFixed.Text = "Fixed";
            this.rbPriceFixed.UseVisualStyleBackColor = true;
            this.rbPriceFixed.CheckedChanged += new System.EventHandler(this.tbDistrEven_CheckedChanged);
            this.rbPriceFixed.ClientSizeChanged += new System.EventHandler(this.rbPriceFixed_ClientSizeChanged);
            // 
            // panelPriceSinus
            // 
            this.panelPriceSinus.Controls.Add(this.label2);
            this.panelPriceSinus.Controls.Add(this.label1);
            this.panelPriceSinus.Controls.Add(this.tbAmplitude);
            this.panelPriceSinus.Controls.Add(this.label5);
            this.panelPriceSinus.Controls.Add(this.label4);
            this.panelPriceSinus.Controls.Add(this.pictureBox1);
            this.panelPriceSinus.Controls.Add(this.panelPriceFixed);
            this.panelPriceSinus.Location = new System.Drawing.Point(135, 9);
            this.panelPriceSinus.Name = "panelPriceSinus";
            this.panelPriceSinus.Size = new System.Drawing.Size(270, 187);
            this.panelPriceSinus.TabIndex = 7;
            this.panelPriceSinus.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "- from contract\'s specs";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "period, ms";
            // 
            // tbAmplitude
            // 
            this.tbAmplitude.Location = new System.Drawing.Point(75, 104);
            this.tbAmplitude.Name = "tbAmplitude";
            this.tbAmplitude.Size = new System.Drawing.Size(62, 20);
            this.tbAmplitude.TabIndex = 9;
            this.tbAmplitude.Validated += new System.EventHandler(this.tbAmplitude_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "amplitude, %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "mid price";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QurrexMatch.LoadApp.Properties.Resources.price_sinus;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 88);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelPriceFixed
            // 
            this.panelPriceFixed.Controls.Add(this.cbSinusPeriod);
            this.panelPriceFixed.Controls.Add(this.label6);
            this.panelPriceFixed.Location = new System.Drawing.Point(0, 0);
            this.panelPriceFixed.Name = "panelPriceFixed";
            this.panelPriceFixed.Size = new System.Drawing.Size(270, 187);
            this.panelPriceFixed.TabIndex = 10;
            // 
            // cbSinusPeriod
            // 
            this.cbSinusPeriod.FormattingEnabled = true;
            this.cbSinusPeriod.Items.AddRange(new object[] {
            "15000",
            "30000",
            "60000",
            "120000",
            "300000"});
            this.cbSinusPeriod.Location = new System.Drawing.Point(75, 154);
            this.cbSinusPeriod.Name = "cbSinusPeriod";
            this.cbSinusPeriod.Size = new System.Drawing.Size(62, 21);
            this.cbSinusPeriod.TabIndex = 12;
            this.cbSinusPeriod.Text = "3000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "fixed price";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(6, 207);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(120, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // PricingSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 235);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.panelPriceSinus);
            this.Controls.Add(this.gbMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PricingSettingsDialog";
            this.Text = "Pricing Settings";
            this.gbMode.ResumeLayout(false);
            this.gbMode.PerformLayout();
            this.panelPriceSinus.ResumeLayout(false);
            this.panelPriceSinus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelPriceFixed.ResumeLayout(false);
            this.panelPriceFixed.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbMode;
        private System.Windows.Forms.RadioButton rbPriceSinusoidal;
        private System.Windows.Forms.RadioButton rbPriceFixed;
        private System.Windows.Forms.Panel panelPriceSinus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAmplitude;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelPriceFixed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSinusPeriod;
    }
}