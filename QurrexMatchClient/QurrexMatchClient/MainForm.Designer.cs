namespace QurrexMatchClient
{
    partial class MainForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.tbUri = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.cbAutoCancel = new System.Windows.Forms.ComboBox();
            this.btnSendOrderReq = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbFlags = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTimeInForce = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTradingApp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbClearingAcc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSide = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInstrument = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.tbCancelExOrdId = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbCancelOriginReq = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbCancelTrading = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbCancelClearing = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbCancelSide = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbCancelInstr = new System.Windows.Forms.TextBox();
            this.btnSendOrderCancel = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label23 = new System.Windows.Forms.Label();
            this.tbMassInstrumentId = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbMassTradingAccount = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbMassClearingAccount = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbMassCancelMode = new System.Windows.Forms.ComboBox();
            this.btnSendMassCancel = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.panelTop.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.tbUri);
            this.panelTop.Controls.Add(this.tabControl);
            this.panelTop.Controls.Add(this.btnConnect);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(389, 423);
            this.panelTop.TabIndex = 0;
            // 
            // tbUri
            // 
            this.tbUri.Location = new System.Drawing.Point(7, 12);
            this.tbUri.Name = "tbUri";
            this.tbUri.Size = new System.Drawing.Size(220, 20);
            this.tbUri.TabIndex = 17;
            this.tbUri.Text = "145.239.142.30:5001";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(3, 41);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(386, 256);
            this.tabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.cbAutoCancel);
            this.tabPage1.Controls.Add(this.btnSendOrderReq);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.tbComment);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.tbFlags);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.cbTimeInForce);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.tbTradingApp);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tbClearingAcc);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cbType);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbPrice);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbAmount);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cbSide);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbInstrument);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(378, 230);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New Order";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(116, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "auto cancel";
            // 
            // cbAutoCancel
            // 
            this.cbAutoCancel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAutoCancel.FormattingEnabled = true;
            this.cbAutoCancel.Location = new System.Drawing.Point(6, 138);
            this.cbAutoCancel.Name = "cbAutoCancel";
            this.cbAutoCancel.Size = new System.Drawing.Size(100, 21);
            this.cbAutoCancel.TabIndex = 21;
            // 
            // btnSendOrderReq
            // 
            this.btnSendOrderReq.Location = new System.Drawing.Point(5, 177);
            this.btnSendOrderReq.Name = "btnSendOrderReq";
            this.btnSendOrderReq.Size = new System.Drawing.Size(276, 23);
            this.btnSendOrderReq.TabIndex = 20;
            this.btnSendOrderReq.Text = "Send";
            this.btnSendOrderReq.UseVisualStyleBackColor = true;
            this.btnSendOrderReq.Click += new System.EventHandler(this.btnSendOrderReq_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(292, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "comment";
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(182, 112);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(100, 20);
            this.tbComment.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(116, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "flags";
            // 
            // tbFlags
            // 
            this.tbFlags.Location = new System.Drawing.Point(6, 112);
            this.tbFlags.Name = "tbFlags";
            this.tbFlags.Size = new System.Drawing.Size(100, 20);
            this.tbFlags.TabIndex = 16;
            this.tbFlags.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(292, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "time in force";
            // 
            // cbTimeInForce
            // 
            this.cbTimeInForce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeInForce.FormattingEnabled = true;
            this.cbTimeInForce.Location = new System.Drawing.Point(182, 61);
            this.cbTimeInForce.Name = "cbTimeInForce";
            this.cbTimeInForce.Size = new System.Drawing.Size(100, 21);
            this.cbTimeInForce.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "trading acc";
            // 
            // tbTradingApp
            // 
            this.tbTradingApp.Location = new System.Drawing.Point(182, 86);
            this.tbTradingApp.Name = "tbTradingApp";
            this.tbTradingApp.Size = new System.Drawing.Size(100, 20);
            this.tbTradingApp.TabIndex = 12;
            this.tbTradingApp.Text = "T01";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "clearing acc";
            // 
            // tbClearingAcc
            // 
            this.tbClearingAcc.Location = new System.Drawing.Point(6, 86);
            this.tbClearingAcc.Name = "tbClearingAcc";
            this.tbClearingAcc.Size = new System.Drawing.Size(100, 20);
            this.tbClearingAcc.TabIndex = 10;
            this.tbClearingAcc.Text = "C01";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "type";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(6, 59);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(100, 21);
            this.cbType.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "price";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(182, 35);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(100, 20);
            this.tbPrice.TabIndex = 6;
            this.tbPrice.Text = "10000000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "amount";
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(182, 6);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(100, 20);
            this.tbAmount.TabIndex = 4;
            this.tbAmount.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "side";
            // 
            // cbSide
            // 
            this.cbSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSide.FormattingEnabled = true;
            this.cbSide.Location = new System.Drawing.Point(6, 32);
            this.cbSide.Name = "cbSide";
            this.cbSide.Size = new System.Drawing.Size(100, 21);
            this.cbSide.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ticker code";
            // 
            // tbInstrument
            // 
            this.tbInstrument.Location = new System.Drawing.Point(6, 6);
            this.tbInstrument.Name = "tbInstrument";
            this.tbInstrument.Size = new System.Drawing.Size(100, 20);
            this.tbInstrument.TabIndex = 0;
            this.tbInstrument.Text = "1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.tbCancelExOrdId);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.tbCancelOriginReq);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.tbCancelTrading);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.tbCancelClearing);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.cbCancelSide);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.tbCancelInstr);
            this.tabPage2.Controls.Add(this.btnSendOrderCancel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(378, 230);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cancel Order";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(116, 63);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = "ex ord Id";
            // 
            // tbCancelExOrdId
            // 
            this.tbCancelExOrdId.Location = new System.Drawing.Point(6, 60);
            this.tbCancelExOrdId.Name = "tbCancelExOrdId";
            this.tbCancelExOrdId.Size = new System.Drawing.Size(100, 20);
            this.tbCancelExOrdId.TabIndex = 34;
            this.tbCancelExOrdId.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(292, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "origin req";
            // 
            // tbCancelOriginReq
            // 
            this.tbCancelOriginReq.Location = new System.Drawing.Point(182, 6);
            this.tbCancelOriginReq.Name = "tbCancelOriginReq";
            this.tbCancelOriginReq.Size = new System.Drawing.Size(100, 20);
            this.tbCancelOriginReq.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(292, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "trading acc";
            // 
            // tbCancelTrading
            // 
            this.tbCancelTrading.Location = new System.Drawing.Point(182, 35);
            this.tbCancelTrading.Name = "tbCancelTrading";
            this.tbCancelTrading.Size = new System.Drawing.Size(100, 20);
            this.tbCancelTrading.TabIndex = 28;
            this.tbCancelTrading.Text = "T01";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(292, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "clearing acc";
            // 
            // tbCancelClearing
            // 
            this.tbCancelClearing.Location = new System.Drawing.Point(182, 63);
            this.tbCancelClearing.Name = "tbCancelClearing";
            this.tbCancelClearing.Size = new System.Drawing.Size(100, 20);
            this.tbCancelClearing.TabIndex = 26;
            this.tbCancelClearing.Text = "C01";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(116, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "side";
            // 
            // cbCancelSide
            // 
            this.cbCancelSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCancelSide.FormattingEnabled = true;
            this.cbCancelSide.Location = new System.Drawing.Point(6, 32);
            this.cbCancelSide.Name = "cbCancelSide";
            this.cbCancelSide.Size = new System.Drawing.Size(100, 21);
            this.cbCancelSide.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(116, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "ticker code";
            // 
            // tbCancelInstr
            // 
            this.tbCancelInstr.Location = new System.Drawing.Point(6, 6);
            this.tbCancelInstr.Name = "tbCancelInstr";
            this.tbCancelInstr.Size = new System.Drawing.Size(100, 20);
            this.tbCancelInstr.TabIndex = 22;
            this.tbCancelInstr.Text = "1";
            // 
            // btnSendOrderCancel
            // 
            this.btnSendOrderCancel.Location = new System.Drawing.Point(6, 201);
            this.btnSendOrderCancel.Name = "btnSendOrderCancel";
            this.btnSendOrderCancel.Size = new System.Drawing.Size(276, 23);
            this.btnSendOrderCancel.TabIndex = 21;
            this.btnSendOrderCancel.Text = "Send";
            this.btnSendOrderCancel.UseVisualStyleBackColor = true;
            this.btnSendOrderCancel.Click += new System.EventHandler(this.btnSendOrderCancel_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.tbMassInstrumentId);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.tbMassTradingAccount);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.tbMassClearingAccount);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.cbMassCancelMode);
            this.tabPage3.Controls.Add(this.btnSendMassCancel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(378, 230);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Mass Cancel";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(291, 32);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 13);
            this.label23.TabIndex = 39;
            this.label23.Text = "ticker code";
            // 
            // tbMassInstrumentId
            // 
            this.tbMassInstrumentId.Location = new System.Drawing.Point(181, 29);
            this.tbMassInstrumentId.Name = "tbMassInstrumentId";
            this.tbMassInstrumentId.Size = new System.Drawing.Size(100, 20);
            this.tbMassInstrumentId.TabIndex = 38;
            this.tbMassInstrumentId.Text = "1";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(291, 6);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 13);
            this.label19.TabIndex = 35;
            this.label19.Text = "trading acc";
            // 
            // tbMassTradingAccount
            // 
            this.tbMassTradingAccount.Location = new System.Drawing.Point(181, 3);
            this.tbMassTradingAccount.Name = "tbMassTradingAccount";
            this.tbMassTradingAccount.Size = new System.Drawing.Size(100, 20);
            this.tbMassTradingAccount.TabIndex = 34;
            this.tbMassTradingAccount.Text = "T01";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(115, 6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 13);
            this.label20.TabIndex = 33;
            this.label20.Text = "clearing acc";
            // 
            // tbMassClearingAccount
            // 
            this.tbMassClearingAccount.Location = new System.Drawing.Point(5, 3);
            this.tbMassClearingAccount.Name = "tbMassClearingAccount";
            this.tbMassClearingAccount.Size = new System.Drawing.Size(100, 20);
            this.tbMassClearingAccount.TabIndex = 32;
            this.tbMassClearingAccount.Text = "C01";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(115, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(26, 13);
            this.label21.TabIndex = 31;
            this.label21.Text = "side";
            // 
            // cbMassCancelMode
            // 
            this.cbMassCancelMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMassCancelMode.FormattingEnabled = true;
            this.cbMassCancelMode.Location = new System.Drawing.Point(5, 29);
            this.cbMassCancelMode.Name = "cbMassCancelMode";
            this.cbMassCancelMode.Size = new System.Drawing.Size(100, 21);
            this.cbMassCancelMode.TabIndex = 30;
            // 
            // btnSendMassCancel
            // 
            this.btnSendMassCancel.Location = new System.Drawing.Point(5, 204);
            this.btnSendMassCancel.Name = "btnSendMassCancel";
            this.btnSendMassCancel.Size = new System.Drawing.Size(276, 23);
            this.btnSendMassCancel.TabIndex = 22;
            this.btnSendMassCancel.Text = "Send";
            this.btnSendMassCancel.UseVisualStyleBackColor = true;
            this.btnSendMassCancel.Click += new System.EventHandler(this.btnSendMassCancel_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(233, 11);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLog.Location = new System.Drawing.Point(389, 0);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(270, 423);
            this.tbLog.TabIndex = 1;
            this.tbLog.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 423);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.panelTop);
            this.Name = "MainForm";
            this.Text = "Qurrex Client";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.RichTextBox tbLog;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInstrument;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTradingApp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbClearingAcc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTimeInForce;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbFlags;
        private System.Windows.Forms.TextBox tbUri;
        private System.Windows.Forms.Button btnSendOrderReq;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbAutoCancel;
        private System.Windows.Forms.Button btnSendOrderCancel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbCancelTrading;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbCancelClearing;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbCancelSide;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbCancelInstr;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbCancelExOrdId;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbCancelOriginReq;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnSendMassCancel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbMassTradingAccount;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbMassClearingAccount;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbMassCancelMode;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbMassInstrumentId;
    }
}

