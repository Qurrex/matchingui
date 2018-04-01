using System;

namespace QurrexMatch.LoadApp.Dialogs
{
    partial class SetupStrategiesDialog
    {
        private System.Windows.Forms.ErrorProvider tbShotIterationsErrorProvider;
        private System.Windows.Forms.ErrorProvider tbShotProbOfTakeErrorProvider;
        private System.Windows.Forms.ErrorProvider tbMMActionIntervalErrorProvider;
        private System.Windows.Forms.ErrorProvider tbMMOrdersCountErrorProvider;
        private System.Windows.Forms.ErrorProvider tbMMlotsPerOrderErrorProvider;

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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageOneShotTrader = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbShotProbOfTake = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbShotIterations = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageMarketMaker = new System.Windows.Forms.TabPage();
            this.tbMMlotsPerOrder = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMMOrdersCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbMMActionInterval = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelBottom.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageOneShotTrader.SuspendLayout();
            this.tabPageMarketMaker.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.button1);
            this.panelBottom.Controls.Add(this.btnOk);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 265);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(515, 32);
            this.panelBottom.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(117, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(3, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageOneShotTrader);
            this.tabControl.Controls.Add(this.tabPageMarketMaker);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(515, 265);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageOneShotTrader
            // 
            this.tabPageOneShotTrader.Controls.Add(this.label4);
            this.tabPageOneShotTrader.Controls.Add(this.label3);
            this.tabPageOneShotTrader.Controls.Add(this.tbShotProbOfTake);
            this.tabPageOneShotTrader.Controls.Add(this.label2);
            this.tabPageOneShotTrader.Controls.Add(this.tbShotIterations);
            this.tabPageOneShotTrader.Controls.Add(this.label1);
            this.tabPageOneShotTrader.Location = new System.Drawing.Point(4, 22);
            this.tabPageOneShotTrader.Name = "tabPageOneShotTrader";
            this.tabPageOneShotTrader.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOneShotTrader.Size = new System.Drawing.Size(507, 239);
            this.tabPageOneShotTrader.TabIndex = 1;
            this.tabPageOneShotTrader.Text = "One-Shot Trader";
            this.tabPageOneShotTrader.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "that spans all the order book";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "A trader who sometimes places an order";
            // 
            // tbShotProbOfTake
            // 
            this.tbShotProbOfTake.Location = new System.Drawing.Point(8, 160);
            this.tbShotProbOfTake.Name = "tbShotProbOfTake";
            this.tbShotProbOfTake.Size = new System.Drawing.Size(66, 20);
            this.tbShotProbOfTake.TabIndex = 3;
            this.tbShotProbOfTake.Validated += new System.EventHandler(this.tbShotProbOfTake_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "probability of taking the book (if the previous one is set to 0)";
            // 
            // tbShotIterations
            // 
            this.tbShotIterations.Location = new System.Drawing.Point(8, 114);
            this.tbShotIterations.Name = "tbShotIterations";
            this.tbShotIterations.Size = new System.Drawing.Size(66, 20);
            this.tbShotIterations.TabIndex = 1;
            this.tbShotIterations.TextChanged += new System.EventHandler(this.tbShotIterations_TextChanged);
            this.tbShotIterations.Validated += new System.EventHandler(this.tbShotIterations_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "iterations to skip before taking the book";
            // 
            // tabPageMarketMaker
            // 
            this.tabPageMarketMaker.Controls.Add(this.tbMMlotsPerOrder);
            this.tabPageMarketMaker.Controls.Add(this.label9);
            this.tabPageMarketMaker.Controls.Add(this.label5);
            this.tabPageMarketMaker.Controls.Add(this.label6);
            this.tabPageMarketMaker.Controls.Add(this.tbMMOrdersCount);
            this.tabPageMarketMaker.Controls.Add(this.label7);
            this.tabPageMarketMaker.Controls.Add(this.tbMMActionInterval);
            this.tabPageMarketMaker.Controls.Add(this.label8);
            this.tabPageMarketMaker.Location = new System.Drawing.Point(4, 22);
            this.tabPageMarketMaker.Name = "tabPageMarketMaker";
            this.tabPageMarketMaker.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMarketMaker.Size = new System.Drawing.Size(507, 239);
            this.tabPageMarketMaker.TabIndex = 0;
            this.tabPageMarketMaker.Text = "Market Maker";
            this.tabPageMarketMaker.UseVisualStyleBackColor = true;
            // 
            // tbMMlotsPerOrder
            // 
            this.tbMMlotsPerOrder.Location = new System.Drawing.Point(8, 169);
            this.tbMMlotsPerOrder.Name = "tbMMlotsPerOrder";
            this.tbMMlotsPerOrder.Size = new System.Drawing.Size(66, 20);
            this.tbMMlotsPerOrder.TabIndex = 13;
            this.tbMMlotsPerOrder.Validated += new System.EventHandler(this.tbMMlotsPerOrder_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "lots per order";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "above and below the market price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "A trader who places orders";
            // 
            // tbMMOrdersCount
            // 
            this.tbMMOrdersCount.Location = new System.Drawing.Point(8, 127);
            this.tbMMOrdersCount.Name = "tbMMOrdersCount";
            this.tbMMOrdersCount.Size = new System.Drawing.Size(66, 20);
            this.tbMMOrdersCount.TabIndex = 9;
            this.tbMMOrdersCount.Validated += new System.EventHandler(this.tbMMOrdersCount_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(258, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "count of orders placed above and below the market\'s";
            // 
            // tbMMActionInterval
            // 
            this.tbMMActionInterval.Location = new System.Drawing.Point(8, 87);
            this.tbMMActionInterval.Name = "tbMMActionInterval";
            this.tbMMActionInterval.Size = new System.Drawing.Size(66, 20);
            this.tbMMActionInterval.TabIndex = 7;
            this.tbMMActionInterval.Validated += new System.EventHandler(this.tbMMActionInterval_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(212, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "interval, ms, between orders\' update routine";
            // 
            // SetupStrategiesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 297);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SetupStrategiesDialog";
            this.Text = "Setup Strategies";
            this.panelBottom.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageOneShotTrader.ResumeLayout(false);
            this.tabPageOneShotTrader.PerformLayout();
            this.tabPageMarketMaker.ResumeLayout(false);
            this.tabPageMarketMaker.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageOneShotTrader;
        private System.Windows.Forms.TabPage tabPageMarketMaker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbShotProbOfTake;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbShotIterations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMMlotsPerOrder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbMMOrdersCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbMMActionInterval;
        private System.Windows.Forms.Label label8;
    }
}