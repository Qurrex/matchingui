namespace QurrexMatch.LoadApp.Dialogs
{
    partial class MoneyManagementDialog
    {
        private System.Windows.Forms.ErrorProvider tbLotsMinErrorProvider;
        private System.Windows.Forms.ErrorProvider tbLotsMaxErrorProvider;

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
            this.tabPageContracts = new System.Windows.Forms.TabPage();
            this.tbContracts = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFixedContractId = new System.Windows.Forms.TextBox();
            this.cbTradeRandomContract = new System.Windows.Forms.CheckBox();
            this.tabPageVolumes = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLotsMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLotsMin = new System.Windows.Forms.TextBox();
            this.panelBottom.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageContracts.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageVolumes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.button1);
            this.panelBottom.Controls.Add(this.btnOk);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 316);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(521, 36);
            this.panelBottom.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(119, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(7, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageContracts);
            this.tabControl.Controls.Add(this.tabPageVolumes);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(521, 316);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageContracts
            // 
            this.tabPageContracts.Controls.Add(this.tbContracts);
            this.tabPageContracts.Controls.Add(this.panel1);
            this.tabPageContracts.Location = new System.Drawing.Point(4, 22);
            this.tabPageContracts.Name = "tabPageContracts";
            this.tabPageContracts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageContracts.Size = new System.Drawing.Size(513, 290);
            this.tabPageContracts.TabIndex = 0;
            this.tabPageContracts.Text = "Contracts";
            this.tabPageContracts.UseVisualStyleBackColor = true;
            // 
            // tbContracts
            // 
            this.tbContracts.BackColor = System.Drawing.Color.Black;
            this.tbContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContracts.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbContracts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbContracts.Location = new System.Drawing.Point(3, 54);
            this.tbContracts.Name = "tbContracts";
            this.tbContracts.Size = new System.Drawing.Size(507, 233);
            this.tbContracts.TabIndex = 1;
            this.tbContracts.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbFixedContractId);
            this.panel1.Controls.Add(this.cbTradeRandomContract);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 51);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fixed Contract (Index in list):";
            // 
            // tbFixedContractId
            // 
            this.tbFixedContractId.Location = new System.Drawing.Point(5, 25);
            this.tbFixedContractId.Name = "tbFixedContractId";
            this.tbFixedContractId.Size = new System.Drawing.Size(70, 20);
            this.tbFixedContractId.TabIndex = 1;
            // 
            // cbTradeRandomContract
            // 
            this.cbTradeRandomContract.AutoSize = true;
            this.cbTradeRandomContract.Location = new System.Drawing.Point(133, 27);
            this.cbTradeRandomContract.Name = "cbTradeRandomContract";
            this.cbTradeRandomContract.Size = new System.Drawing.Size(134, 17);
            this.cbTradeRandomContract.TabIndex = 0;
            this.cbTradeRandomContract.Text = "Trade random contract";
            this.cbTradeRandomContract.UseVisualStyleBackColor = true;
            this.cbTradeRandomContract.CheckedChanged += new System.EventHandler(this.cbTradeRandomContract_CheckedChanged);
            // 
            // tabPageVolumes
            // 
            this.tabPageVolumes.Controls.Add(this.label4);
            this.tabPageVolumes.Controls.Add(this.tbLotsMax);
            this.tabPageVolumes.Controls.Add(this.label3);
            this.tabPageVolumes.Controls.Add(this.label2);
            this.tabPageVolumes.Controls.Add(this.tbLotsMin);
            this.tabPageVolumes.Location = new System.Drawing.Point(4, 22);
            this.tabPageVolumes.Name = "tabPageVolumes";
            this.tabPageVolumes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVolumes.Size = new System.Drawing.Size(513, 290);
            this.tabPageVolumes.TabIndex = 1;
            this.tabPageVolumes.Text = "Volumes";
            this.tabPageVolumes.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "lots";
            // 
            // tbLotsMax
            // 
            this.tbLotsMax.Location = new System.Drawing.Point(199, 12);
            this.tbLotsMax.Name = "tbLotsMax";
            this.tbLotsMax.Size = new System.Drawing.Size(56, 20);
            this.tbLotsMax.TabIndex = 6;
            this.tbLotsMax.Validated += new System.EventHandler(this.tbLotsMax_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "to";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "order volume: from";
            // 
            // tbLotsMin
            // 
            this.tbLotsMin.Location = new System.Drawing.Point(115, 12);
            this.tbLotsMin.Name = "tbLotsMin";
            this.tbLotsMin.Size = new System.Drawing.Size(56, 20);
            this.tbLotsMin.TabIndex = 3;
            this.tbLotsMin.Validated += new System.EventHandler(this.tbLotsMin_Validated);
            // 
            // MoneyManagementDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 352);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MoneyManagementDialog";
            this.Text = "Money Management";
            this.panelBottom.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageContracts.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageVolumes.ResumeLayout(false);
            this.tabPageVolumes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageContracts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPageVolumes;
        private System.Windows.Forms.RichTextBox tbContracts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFixedContractId;
        private System.Windows.Forms.CheckBox cbTradeRandomContract;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLotsMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLotsMin;
    }
}