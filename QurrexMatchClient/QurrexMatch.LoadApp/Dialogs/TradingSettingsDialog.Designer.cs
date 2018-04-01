using System;

namespace QurrexMatch.LoadApp.Dialogs
{
    partial class TradingSettingsDialog
    {
        private System.Windows.Forms.ErrorProvider tbMakersCountErrorProvider;
        private System.Windows.Forms.ErrorProvider tbOneShotCountErrorProvider;
        private System.Windows.Forms.ErrorProvider tbRandomPercCancelErrorProvider;
        private System.Windows.Forms.ErrorProvider tbRandomPercMassErrorProvider;
        private System.Windows.Forms.ErrorProvider tbRandomPercAboveErrorProvider;
        private System.Windows.Forms.ErrorProvider tbRandomPercBelowErrorProvider;
        private System.Windows.Forms.ErrorProvider tbErrorReqPercErrorProvider;


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
            this.panelRandom = new System.Windows.Forms.Panel();
            this.trbRandomPercMass = new System.Windows.Forms.TrackBar();
            this.trbRandomPercCancel = new System.Windows.Forms.TrackBar();
            this.tbErrorReqPerc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRandomPercNew = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRandomPercMass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRandomPercCancel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbMakersCount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbOneShotCount = new System.Windows.Forms.TextBox();
            this.btnSetupStrategies = new System.Windows.Forms.Button();
            this.panelRandom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbRandomPercMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbRandomPercCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRandom
            // 
            this.panelRandom.Controls.Add(this.trbRandomPercMass);
            this.panelRandom.Controls.Add(this.trbRandomPercCancel);
            this.panelRandom.Controls.Add(this.tbErrorReqPerc);
            this.panelRandom.Controls.Add(this.label9);
            this.panelRandom.Controls.Add(this.tbRandomPercNew);
            this.panelRandom.Controls.Add(this.label4);
            this.panelRandom.Controls.Add(this.tbRandomPercMass);
            this.panelRandom.Controls.Add(this.label3);
            this.panelRandom.Controls.Add(this.tbRandomPercCancel);
            this.panelRandom.Controls.Add(this.label5);
            this.panelRandom.Controls.Add(this.label2);
            this.panelRandom.Controls.Add(this.label1);
            this.panelRandom.Controls.Add(this.label6);
            this.panelRandom.Location = new System.Drawing.Point(176, 7);
            this.panelRandom.Name = "panelRandom";
            this.panelRandom.Size = new System.Drawing.Size(335, 287);
            this.panelRandom.TabIndex = 11;
            // 
            // trbRandomPercMass
            // 
            this.trbRandomPercMass.Location = new System.Drawing.Point(177, 109);
            this.trbRandomPercMass.Maximum = 50;
            this.trbRandomPercMass.Name = "trbRandomPercMass";
            this.trbRandomPercMass.Size = new System.Drawing.Size(132, 45);
            this.trbRandomPercMass.TabIndex = 23;
            this.trbRandomPercMass.ValueChanged += new System.EventHandler(this.trbRandomPercMass_ValueChanged);
            // 
            // trbRandomPercCancel
            // 
            this.trbRandomPercCancel.Location = new System.Drawing.Point(177, 74);
            this.trbRandomPercCancel.Maximum = 50;
            this.trbRandomPercCancel.Name = "trbRandomPercCancel";
            this.trbRandomPercCancel.Size = new System.Drawing.Size(132, 45);
            this.trbRandomPercCancel.TabIndex = 22;
            this.trbRandomPercCancel.ValueChanged += new System.EventHandler(this.trbRandomPercCancel_ValueChanged);
            // 
            // tbErrorReqPerc
            // 
            this.tbErrorReqPerc.Location = new System.Drawing.Point(137, 204);
            this.tbErrorReqPerc.Name = "tbErrorReqPerc";
            this.tbErrorReqPerc.Size = new System.Drawing.Size(62, 20);
            this.tbErrorReqPerc.TabIndex = 21;
            this.tbErrorReqPerc.Validated += new System.EventHandler(this.tbErrorReqPerc_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "percent of errors (amount)";
            // 
            // tbRandomPercNew
            // 
            this.tbRandomPercNew.Enabled = false;
            this.tbRandomPercNew.Location = new System.Drawing.Point(137, 160);
            this.tbRandomPercNew.Name = "tbRandomPercNew";
            this.tbRandomPercNew.Size = new System.Drawing.Size(62, 20);
            this.tbRandomPercNew.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "percent of mass cancel";
            // 
            // tbRandomPercMass
            // 
            this.tbRandomPercMass.Enabled = false;
            this.tbRandomPercMass.Location = new System.Drawing.Point(137, 119);
            this.tbRandomPercMass.Name = "tbRandomPercMass";
            this.tbRandomPercMass.Size = new System.Drawing.Size(34, 20);
            this.tbRandomPercMass.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "percent of order cancel";
            // 
            // tbRandomPercCancel
            // 
            this.tbRandomPercCancel.Enabled = false;
            this.tbRandomPercCancel.Location = new System.Drawing.Point(137, 77);
            this.tbRandomPercCancel.Name = "tbRandomPercCancel";
            this.tbRandomPercCancel.Size = new System.Drawing.Size(34, 20);
            this.tbRandomPercCancel.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "percent of new order";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "An order could target a level below, above or exact at the market\'s.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "- new order, cancel order or mass order cancel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "The trader places a number of orders:";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(122, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(8, 300);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "makers count";
            // 
            // tbMakersCount
            // 
            this.tbMakersCount.Location = new System.Drawing.Point(8, 33);
            this.tbMakersCount.Name = "tbMakersCount";
            this.tbMakersCount.Size = new System.Drawing.Size(62, 20);
            this.tbMakersCount.TabIndex = 14;
            this.tbMakersCount.Validated += new System.EventHandler(this.tbMakersCount_Validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "one-shot traders count";
            // 
            // tbOneShotCount
            // 
            this.tbOneShotCount.Location = new System.Drawing.Point(8, 87);
            this.tbOneShotCount.Name = "tbOneShotCount";
            this.tbOneShotCount.Size = new System.Drawing.Size(62, 20);
            this.tbOneShotCount.TabIndex = 16;
            this.tbOneShotCount.Validated += new System.EventHandler(this.tbOneShotCount_Validated);
            // 
            // btnSetupStrategies
            // 
            this.btnSetupStrategies.Location = new System.Drawing.Point(8, 129);
            this.btnSetupStrategies.Name = "btnSetupStrategies";
            this.btnSetupStrategies.Size = new System.Drawing.Size(136, 23);
            this.btnSetupStrategies.TabIndex = 18;
            this.btnSetupStrategies.Text = "Setup strategies...";
            this.btnSetupStrategies.UseVisualStyleBackColor = true;
            this.btnSetupStrategies.Click += new System.EventHandler(this.btnSetupStrategies_Click);
            // 
            // TradingSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 335);
            this.Controls.Add(this.btnSetupStrategies);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbOneShotCount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbMakersCount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.panelRandom);
            this.Name = "TradingSettingsDialog";
            this.Text = "Trading Settings";
            this.panelRandom.ResumeLayout(false);
            this.panelRandom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbRandomPercMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbRandomPercCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelRandom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbRandomPercNew;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRandomPercMass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRandomPercCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbErrorReqPerc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbMakersCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbOneShotCount;
        private System.Windows.Forms.Button btnSetupStrategies;
        private System.Windows.Forms.TrackBar trbRandomPercCancel;
        private System.Windows.Forms.TrackBar trbRandomPercMass;
    }
}