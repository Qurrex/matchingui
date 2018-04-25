using System;

namespace QurrexMatch.LoadApp.Dialogs
{
    partial class LoadSettingsDialog
    {
        private System.Windows.Forms.ErrorProvider tbThreadsCountErrorProvider;
        private System.Windows.Forms.ErrorProvider tbConnectionsCountErrorProvider;
        private System.Windows.Forms.ErrorProvider tbIntervalMsErrorProvider;
        private System.Windows.Forms.ErrorProvider tbPropOfPlacingOrderErrorProvider;
        private System.Windows.Forms.ErrorProvider tbFadeInPeriodErrorProvider;
        private System.Windows.Forms.ErrorProvider tbPayloadSinusPeriodMsErrorProvider;

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
            this.label1 = new System.Windows.Forms.Label();
            this.tbThreadsCount = new System.Windows.Forms.TextBox();
            this.tbIntervalMs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbPayloadDistr = new System.Windows.Forms.GroupBox();
            this.tbModeStairsDown = new System.Windows.Forms.RadioButton();
            this.tbModeStairsUp = new System.Windows.Forms.RadioButton();
            this.tbModeFadeIn = new System.Windows.Forms.RadioButton();
            this.tbDistrSinus = new System.Windows.Forms.RadioButton();
            this.tbDistrEven = new System.Windows.Forms.RadioButton();
            this.panelDistrSinus = new System.Windows.Forms.Panel();
            this.tbPayloadSinusPeriodMs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbPropOfPlacingOrder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelFadeIn = new System.Windows.Forms.Panel();
            this.tbFadeInPeriod = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelSetsSteps = new System.Windows.Forms.Panel();
            this.tbStairInterval = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbStairsCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.gbPayloadDistr.SuspendLayout();
            this.panelDistrSinus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelFadeIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelSetsSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "threads";
            // 
            // tbThreadsCount
            // 
            this.tbThreadsCount.Location = new System.Drawing.Point(67, 2);
            this.tbThreadsCount.Name = "tbThreadsCount";
            this.tbThreadsCount.Size = new System.Drawing.Size(62, 20);
            this.tbThreadsCount.TabIndex = 1;
            this.tbThreadsCount.Validated += new System.EventHandler(this.tbThreadsCount_Validated);
            // 
            // tbIntervalMs
            // 
            this.tbIntervalMs.Location = new System.Drawing.Point(67, 31);
            this.tbIntervalMs.Name = "tbIntervalMs";
            this.tbIntervalMs.Size = new System.Drawing.Size(62, 20);
            this.tbIntervalMs.TabIndex = 5;
            this.tbIntervalMs.Validated += new System.EventHandler(this.tbIntervalMs_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "interval, ms";
            // 
            // gbPayloadDistr
            // 
            this.gbPayloadDistr.Controls.Add(this.tbModeStairsDown);
            this.gbPayloadDistr.Controls.Add(this.tbModeStairsUp);
            this.gbPayloadDistr.Controls.Add(this.tbModeFadeIn);
            this.gbPayloadDistr.Controls.Add(this.tbDistrSinus);
            this.gbPayloadDistr.Controls.Add(this.tbDistrEven);
            this.gbPayloadDistr.Location = new System.Drawing.Point(6, 67);
            this.gbPayloadDistr.Name = "gbPayloadDistr";
            this.gbPayloadDistr.Size = new System.Drawing.Size(123, 144);
            this.gbPayloadDistr.TabIndex = 6;
            this.gbPayloadDistr.TabStop = false;
            this.gbPayloadDistr.Text = "Payload Mode";
            this.gbPayloadDistr.Enter += new System.EventHandler(this.gbPayloadDistr_Enter);
            // 
            // tbModeStairsDown
            // 
            this.tbModeStairsDown.AutoSize = true;
            this.tbModeStairsDown.Location = new System.Drawing.Point(13, 116);
            this.tbModeStairsDown.Name = "tbModeStairsDown";
            this.tbModeStairsDown.Size = new System.Drawing.Size(82, 17);
            this.tbModeStairsDown.TabIndex = 4;
            this.tbModeStairsDown.Text = "Stairs Down";
            this.tbModeStairsDown.UseVisualStyleBackColor = true;
            this.tbModeStairsDown.CheckedChanged += new System.EventHandler(this.tbDistrEven_CheckedChanged);
            // 
            // tbModeStairsUp
            // 
            this.tbModeStairsUp.AutoSize = true;
            this.tbModeStairsUp.Location = new System.Drawing.Point(13, 93);
            this.tbModeStairsUp.Name = "tbModeStairsUp";
            this.tbModeStairsUp.Size = new System.Drawing.Size(68, 17);
            this.tbModeStairsUp.TabIndex = 3;
            this.tbModeStairsUp.Text = "Stairs Up";
            this.tbModeStairsUp.UseVisualStyleBackColor = true;
            this.tbModeStairsUp.CheckedChanged += new System.EventHandler(this.tbDistrEven_CheckedChanged);
            // 
            // tbModeFadeIn
            // 
            this.tbModeFadeIn.AutoSize = true;
            this.tbModeFadeIn.Location = new System.Drawing.Point(13, 70);
            this.tbModeFadeIn.Name = "tbModeFadeIn";
            this.tbModeFadeIn.Size = new System.Drawing.Size(59, 17);
            this.tbModeFadeIn.TabIndex = 2;
            this.tbModeFadeIn.Text = "Growth";
            this.tbModeFadeIn.UseVisualStyleBackColor = true;
            this.tbModeFadeIn.ClientSizeChanged += new System.EventHandler(this.tbDistrEven_CheckedChanged);
            // 
            // tbDistrSinus
            // 
            this.tbDistrSinus.AutoSize = true;
            this.tbDistrSinus.Location = new System.Drawing.Point(13, 47);
            this.tbDistrSinus.Name = "tbDistrSinus";
            this.tbDistrSinus.Size = new System.Drawing.Size(73, 17);
            this.tbDistrSinus.TabIndex = 1;
            this.tbDistrSinus.Text = "Sinusoidal";
            this.tbDistrSinus.UseVisualStyleBackColor = true;
            this.tbDistrSinus.CheckedChanged += new System.EventHandler(this.tbDistrEven_CheckedChanged);
            // 
            // tbDistrEven
            // 
            this.tbDistrEven.AutoSize = true;
            this.tbDistrEven.Checked = true;
            this.tbDistrEven.Location = new System.Drawing.Point(13, 24);
            this.tbDistrEven.Name = "tbDistrEven";
            this.tbDistrEven.Size = new System.Drawing.Size(50, 17);
            this.tbDistrEven.TabIndex = 0;
            this.tbDistrEven.TabStop = true;
            this.tbDistrEven.Text = "Fixed";
            this.tbDistrEven.UseVisualStyleBackColor = true;
            this.tbDistrEven.CheckedChanged += new System.EventHandler(this.tbDistrEven_CheckedChanged);
            // 
            // panelDistrSinus
            // 
            this.panelDistrSinus.Controls.Add(this.tbPayloadSinusPeriodMs);
            this.panelDistrSinus.Controls.Add(this.label4);
            this.panelDistrSinus.Controls.Add(this.pictureBox1);
            this.panelDistrSinus.Location = new System.Drawing.Point(135, 73);
            this.panelDistrSinus.Name = "panelDistrSinus";
            this.panelDistrSinus.Size = new System.Drawing.Size(139, 82);
            this.panelDistrSinus.TabIndex = 7;
            this.panelDistrSinus.Visible = false;
            // 
            // tbPayloadSinusPeriodMs
            // 
            this.tbPayloadSinusPeriodMs.Location = new System.Drawing.Point(62, 52);
            this.tbPayloadSinusPeriodMs.Name = "tbPayloadSinusPeriodMs";
            this.tbPayloadSinusPeriodMs.Size = new System.Drawing.Size(62, 20);
            this.tbPayloadSinusPeriodMs.TabIndex = 7;
            this.tbPayloadSinusPeriodMs.Validated += new System.EventHandler(this.tbPayloadSinusPeriodMs_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "period, ms";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QurrexMatch.LoadApp.Properties.Resources.sinus_distr;
            this.pictureBox1.Location = new System.Drawing.Point(27, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 44);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(6, 246);
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
            this.button1.Location = new System.Drawing.Point(118, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbPropOfPlacingOrder
            // 
            this.tbPropOfPlacingOrder.Location = new System.Drawing.Point(162, 31);
            this.tbPropOfPlacingOrder.Name = "tbPropOfPlacingOrder";
            this.tbPropOfPlacingOrder.Size = new System.Drawing.Size(62, 20);
            this.tbPropOfPlacingOrder.TabIndex = 10;
            this.tbPropOfPlacingOrder.Validated += new System.EventHandler(this.tbPropOfPlacingOrder_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(159, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "probability of placing";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(159, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "order per iteration";
            // 
            // panelFadeIn
            // 
            this.panelFadeIn.Controls.Add(this.tbFadeInPeriod);
            this.panelFadeIn.Controls.Add(this.label7);
            this.panelFadeIn.Controls.Add(this.pictureBox2);
            this.panelFadeIn.Location = new System.Drawing.Point(135, 73);
            this.panelFadeIn.Name = "panelFadeIn";
            this.panelFadeIn.Size = new System.Drawing.Size(139, 82);
            this.panelFadeIn.TabIndex = 13;
            this.panelFadeIn.Visible = false;
            // 
            // tbFadeInPeriod
            // 
            this.tbFadeInPeriod.Location = new System.Drawing.Point(62, 52);
            this.tbFadeInPeriod.Name = "tbFadeInPeriod";
            this.tbFadeInPeriod.Size = new System.Drawing.Size(62, 20);
            this.tbFadeInPeriod.TabIndex = 7;
            this.tbFadeInPeriod.Validated += new System.EventHandler(this.tbFadeInPeriod_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "period, s";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QurrexMatch.LoadApp.Properties.Resources.fading_in;
            this.pictureBox2.Location = new System.Drawing.Point(27, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(99, 44);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panelSetsSteps
            // 
            this.panelSetsSteps.Controls.Add(this.pictureBox4);
            this.panelSetsSteps.Controls.Add(this.tbStairInterval);
            this.panelSetsSteps.Controls.Add(this.label9);
            this.panelSetsSteps.Controls.Add(this.tbStairsCount);
            this.panelSetsSteps.Controls.Add(this.label8);
            this.panelSetsSteps.Controls.Add(this.pictureBox3);
            this.panelSetsSteps.Location = new System.Drawing.Point(135, 73);
            this.panelSetsSteps.Name = "panelSetsSteps";
            this.panelSetsSteps.Size = new System.Drawing.Size(139, 104);
            this.panelSetsSteps.TabIndex = 14;
            this.panelSetsSteps.Visible = false;
            // 
            // tbStairInterval
            // 
            this.tbStairInterval.Location = new System.Drawing.Point(70, 75);
            this.tbStairInterval.Name = "tbStairInterval";
            this.tbStairInterval.Size = new System.Drawing.Size(54, 20);
            this.tbStairInterval.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "stair inter, s";
            // 
            // tbStairsCount
            // 
            this.tbStairsCount.Location = new System.Drawing.Point(70, 52);
            this.tbStairsCount.Name = "tbStairsCount";
            this.tbStairsCount.Size = new System.Drawing.Size(54, 20);
            this.tbStairsCount.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "stairs count";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::QurrexMatch.LoadApp.Properties.Resources.stairs;
            this.pictureBox3.Location = new System.Drawing.Point(27, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(99, 44);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::QurrexMatch.LoadApp.Properties.Resources.stairs_down;
            this.pictureBox4.Location = new System.Drawing.Point(27, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(99, 44);
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // LoadSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 273);
            this.Controls.Add(this.panelSetsSteps);
            this.Controls.Add(this.panelFadeIn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPropOfPlacingOrder);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.panelDistrSinus);
            this.Controls.Add(this.gbPayloadDistr);
            this.Controls.Add(this.tbIntervalMs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbThreadsCount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LoadSettingsDialog";
            this.Text = "Payload Settings";
            this.Load += new System.EventHandler(this.LoadSettingsDialog_Load);
            this.gbPayloadDistr.ResumeLayout(false);
            this.gbPayloadDistr.PerformLayout();
            this.panelDistrSinus.ResumeLayout(false);
            this.panelDistrSinus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelFadeIn.ResumeLayout(false);
            this.panelFadeIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelSetsSteps.ResumeLayout(false);
            this.panelSetsSteps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbThreadsCount;
        private System.Windows.Forms.TextBox tbIntervalMs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbPayloadDistr;
        private System.Windows.Forms.RadioButton tbDistrSinus;
        private System.Windows.Forms.RadioButton tbDistrEven;
        private System.Windows.Forms.Panel panelDistrSinus;
        private System.Windows.Forms.TextBox tbPayloadSinusPeriodMs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbPropOfPlacingOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton tbModeFadeIn;
        private System.Windows.Forms.Panel panelFadeIn;
        private System.Windows.Forms.TextBox tbFadeInPeriod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton tbModeStairsUp;
        private System.Windows.Forms.Panel panelSetsSteps;
        private System.Windows.Forms.TextBox tbStairsCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tbStairInterval;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton tbModeStairsDown;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}