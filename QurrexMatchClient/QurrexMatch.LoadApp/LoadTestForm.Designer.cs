namespace QurrexMatch.LoadApp
{
    partial class LoadTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadTestForm));
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreset08 = new System.Windows.Forms.Button();
            this.imgListPresets = new System.Windows.Forms.ImageList(this.components);
            this.btnPreset07 = new System.Windows.Forms.Button();
            this.btnPreset06 = new System.Windows.Forms.Button();
            this.btnPreset05 = new System.Windows.Forms.Button();
            this.btnPreset04 = new System.Windows.Forms.Button();
            this.btnPreset03 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnManTest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCommonSets = new System.Windows.Forms.Button();
            this.btnSetupConnection = new System.Windows.Forms.Button();
            this.btnPreset02 = new System.Windows.Forms.Button();
            this.btnPreset01 = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.tabPageReport = new System.Windows.Forms.TabPage();
            this.cbReports = new System.Windows.Forms.ComboBox();
            this.btnOpenReport = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelLeft.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.tabPageReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.lblConnectionStatus);
            this.panelLeft.Controls.Add(this.label2);
            this.panelLeft.Controls.Add(this.label1);
            this.panelLeft.Controls.Add(this.btnPreset08);
            this.panelLeft.Controls.Add(this.btnPreset07);
            this.panelLeft.Controls.Add(this.btnPreset06);
            this.panelLeft.Controls.Add(this.btnPreset05);
            this.panelLeft.Controls.Add(this.btnPreset04);
            this.panelLeft.Controls.Add(this.btnPreset03);
            this.panelLeft.Controls.Add(this.btnStop);
            this.panelLeft.Controls.Add(this.btnManTest);
            this.panelLeft.Controls.Add(this.groupBox1);
            this.panelLeft.Controls.Add(this.btnPreset02);
            this.panelLeft.Controls.Add(this.btnPreset01);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(233, 508);
            this.panelLeft.TabIndex = 0;
            this.panelLeft.Tag = "0";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(78, 340);
            this.lblConnectionStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(13, 17);
            this.lblConnectionStatus.TabIndex = 21;
            this.lblConnectionStatus.Text = "-";
            this.lblConnectionStatus.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "payload modulations";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "trading strategies";
            // 
            // btnPreset08
            // 
            this.btnPreset08.ImageIndex = 0;
            this.btnPreset08.ImageList = this.imgListPresets;
            this.btnPreset08.Location = new System.Drawing.Point(81, 180);
            this.btnPreset08.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreset08.Name = "btnPreset08";
            this.btnPreset08.Size = new System.Drawing.Size(63, 52);
            this.btnPreset08.TabIndex = 18;
            this.btnPreset08.Tag = "0";
            this.btnPreset08.UseVisualStyleBackColor = true;
            // 
            // imgListPresets
            // 
            this.imgListPresets.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListPresets.ImageStream")));
            this.imgListPresets.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListPresets.Images.SetKeyName(0, "icon_tune.png");
            this.imgListPresets.Images.SetKeyName(1, "icon_stop.png");
            this.imgListPresets.Images.SetKeyName(2, "icon_takerpool.png");
            this.imgListPresets.Images.SetKeyName(3, "icon_makertaker.png");
            this.imgListPresets.Images.SetKeyName(4, "icon_fadein.png");
            this.imgListPresets.Images.SetKeyName(5, "icon_oneshot.png");
            this.imgListPresets.Images.SetKeyName(6, "icon_sinusoid.png");
            this.imgListPresets.Images.SetKeyName(7, "icon_surge.png");
            this.imgListPresets.Images.SetKeyName(8, "icon_stairs.png");
            this.imgListPresets.Images.SetKeyName(9, "icon_downstair.png");
            // 
            // btnPreset07
            // 
            this.btnPreset07.ImageIndex = 0;
            this.btnPreset07.ImageList = this.imgListPresets;
            this.btnPreset07.Location = new System.Drawing.Point(11, 180);
            this.btnPreset07.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreset07.Name = "btnPreset07";
            this.btnPreset07.Size = new System.Drawing.Size(63, 52);
            this.btnPreset07.TabIndex = 17;
            this.btnPreset07.Tag = "0";
            this.btnPreset07.UseVisualStyleBackColor = true;
            // 
            // btnPreset06
            // 
            this.btnPreset06.ImageIndex = 0;
            this.btnPreset06.ImageList = this.imgListPresets;
            this.btnPreset06.Location = new System.Drawing.Point(151, 121);
            this.btnPreset06.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreset06.Name = "btnPreset06";
            this.btnPreset06.Size = new System.Drawing.Size(63, 52);
            this.btnPreset06.TabIndex = 16;
            this.btnPreset06.Tag = "0";
            this.btnPreset06.UseVisualStyleBackColor = true;
            // 
            // btnPreset05
            // 
            this.btnPreset05.ImageIndex = 0;
            this.btnPreset05.ImageList = this.imgListPresets;
            this.btnPreset05.Location = new System.Drawing.Point(81, 121);
            this.btnPreset05.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreset05.Name = "btnPreset05";
            this.btnPreset05.Size = new System.Drawing.Size(63, 52);
            this.btnPreset05.TabIndex = 15;
            this.btnPreset05.Tag = "0";
            this.btnPreset05.UseVisualStyleBackColor = true;
            // 
            // btnPreset04
            // 
            this.btnPreset04.ImageIndex = 0;
            this.btnPreset04.ImageList = this.imgListPresets;
            this.btnPreset04.Location = new System.Drawing.Point(11, 121);
            this.btnPreset04.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreset04.Name = "btnPreset04";
            this.btnPreset04.Size = new System.Drawing.Size(63, 52);
            this.btnPreset04.TabIndex = 14;
            this.btnPreset04.Tag = "0";
            this.btnPreset04.UseVisualStyleBackColor = true;
            // 
            // btnPreset03
            // 
            this.btnPreset03.ImageIndex = 0;
            this.btnPreset03.ImageList = this.imgListPresets;
            this.btnPreset03.Location = new System.Drawing.Point(151, 181);
            this.btnPreset03.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreset03.Name = "btnPreset03";
            this.btnPreset03.Size = new System.Drawing.Size(63, 52);
            this.btnPreset03.TabIndex = 13;
            this.btnPreset03.Tag = "0";
            this.btnPreset03.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.ImageIndex = 1;
            this.btnStop.ImageList = this.imgListPresets;
            this.btnStop.Location = new System.Drawing.Point(11, 322);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(63, 52);
            this.btnStop.TabIndex = 12;
            this.btnStop.Tag = "0";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnManTest
            // 
            this.btnManTest.ImageIndex = 0;
            this.btnManTest.ImageList = this.imgListPresets;
            this.btnManTest.Location = new System.Drawing.Point(11, 262);
            this.btnManTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnManTest.Name = "btnManTest";
            this.btnManTest.Size = new System.Drawing.Size(63, 52);
            this.btnManTest.TabIndex = 11;
            this.btnManTest.Tag = "0";
            this.btnManTest.UseVisualStyleBackColor = true;
            this.btnManTest.Click += new System.EventHandler(this.btnManualTest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCommonSets);
            this.groupBox1.Controls.Add(this.btnSetupConnection);
            this.groupBox1.Location = new System.Drawing.Point(11, 382);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(212, 102);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "settings";
            // 
            // btnCommonSets
            // 
            this.btnCommonSets.Location = new System.Drawing.Point(5, 31);
            this.btnCommonSets.Margin = new System.Windows.Forms.Padding(4);
            this.btnCommonSets.Name = "btnCommonSets";
            this.btnCommonSets.Size = new System.Drawing.Size(199, 28);
            this.btnCommonSets.TabIndex = 7;
            this.btnCommonSets.Text = "Common Settings ...";
            this.btnCommonSets.UseVisualStyleBackColor = true;
            this.btnCommonSets.Click += new System.EventHandler(this.btnCommonSets_Click);
            // 
            // btnSetupConnection
            // 
            this.btnSetupConnection.Location = new System.Drawing.Point(5, 66);
            this.btnSetupConnection.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetupConnection.Name = "btnSetupConnection";
            this.btnSetupConnection.Size = new System.Drawing.Size(199, 28);
            this.btnSetupConnection.TabIndex = 6;
            this.btnSetupConnection.Text = "Connection Settings ...";
            this.btnSetupConnection.UseVisualStyleBackColor = true;
            this.btnSetupConnection.Click += new System.EventHandler(this.btnSetupConnection_Click);
            // 
            // btnPreset02
            // 
            this.btnPreset02.ImageIndex = 0;
            this.btnPreset02.ImageList = this.imgListPresets;
            this.btnPreset02.Location = new System.Drawing.Point(81, 31);
            this.btnPreset02.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreset02.Name = "btnPreset02";
            this.btnPreset02.Size = new System.Drawing.Size(63, 52);
            this.btnPreset02.TabIndex = 8;
            this.btnPreset02.Tag = "0";
            this.btnPreset02.UseVisualStyleBackColor = true;
            // 
            // btnPreset01
            // 
            this.btnPreset01.ImageIndex = 0;
            this.btnPreset01.ImageList = this.imgListPresets;
            this.btnPreset01.Location = new System.Drawing.Point(11, 31);
            this.btnPreset01.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreset01.Name = "btnPreset01";
            this.btnPreset01.Size = new System.Drawing.Size(63, 52);
            this.btnPreset01.TabIndex = 7;
            this.btnPreset01.Tag = "0";
            this.btnPreset01.UseVisualStyleBackColor = true;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageLog);
            this.tabControlMain.Controls.Add(this.tabPageReport);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(233, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(828, 508);
            this.tabControlMain.TabIndex = 1;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.tbLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 25);
            this.tabPageLog.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageLog.Size = new System.Drawing.Size(820, 479);
            this.tabPageLog.TabIndex = 0;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.Black;
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbLog.Location = new System.Drawing.Point(4, 4);
            this.tbLog.Margin = new System.Windows.Forms.Padding(4);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(812, 471);
            this.tbLog.TabIndex = 0;
            this.tbLog.Text = "";
            // 
            // tabPageReport
            // 
            this.tabPageReport.Controls.Add(this.cbReports);
            this.tabPageReport.Controls.Add(this.btnOpenReport);
            this.tabPageReport.Location = new System.Drawing.Point(4, 25);
            this.tabPageReport.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageReport.Name = "tabPageReport";
            this.tabPageReport.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageReport.Size = new System.Drawing.Size(820, 479);
            this.tabPageReport.TabIndex = 1;
            this.tabPageReport.Text = "Report";
            this.tabPageReport.UseVisualStyleBackColor = true;
            // 
            // cbReports
            // 
            this.cbReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReports.FormattingEnabled = true;
            this.cbReports.Location = new System.Drawing.Point(8, 48);
            this.cbReports.Margin = new System.Windows.Forms.Padding(4);
            this.cbReports.Name = "cbReports";
            this.cbReports.Size = new System.Drawing.Size(241, 24);
            this.cbReports.TabIndex = 1;
            // 
            // btnOpenReport
            // 
            this.btnOpenReport.Location = new System.Drawing.Point(8, 12);
            this.btnOpenReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenReport.Name = "btnOpenReport";
            this.btnOpenReport.Size = new System.Drawing.Size(243, 28);
            this.btnOpenReport.TabIndex = 0;
            this.btnOpenReport.Text = "Open Report";
            this.btnOpenReport.UseVisualStyleBackColor = true;
            this.btnOpenReport.Click += new System.EventHandler(this.btnOpenReport_Click);
            // 
            // LoadTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 508);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.panelLeft);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoadTestForm";
            this.Text = "Qurrex Match Load Test";
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageLog.ResumeLayout(false);
            this.tabPageReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.RichTextBox tbLog;
        private System.Windows.Forms.TabPage tabPageReport;
        private System.Windows.Forms.ComboBox cbReports;
        private System.Windows.Forms.Button btnOpenReport;
        private System.Windows.Forms.Button btnPreset01;
        private System.Windows.Forms.ImageList imgListPresets;
        private System.Windows.Forms.Button btnPreset02;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCommonSets;
        private System.Windows.Forms.Button btnSetupConnection;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnManTest;
        private System.Windows.Forms.Button btnPreset03;
        private System.Windows.Forms.Button btnPreset04;
        private System.Windows.Forms.Button btnPreset05;
        private System.Windows.Forms.Button btnPreset06;
        private System.Windows.Forms.Button btnPreset07;
        private System.Windows.Forms.Button btnPreset08;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConnectionStatus;
    }
}