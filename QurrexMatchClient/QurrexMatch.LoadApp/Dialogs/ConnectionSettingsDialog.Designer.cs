using System.Windows.Forms;

namespace QurrexMatch.LoadApp.Dialogs
{
    partial class ConnectionSettingsDialog
    {
        private System.Windows.Forms.ErrorProvider uriErrorProvider;

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
            this.tbUri = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.uriErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbServerStatusURI = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uriErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tbUri
            // 
            this.tbUri.Location = new System.Drawing.Point(3, 21);
            this.tbUri.Name = "tbUri";
            this.tbUri.Size = new System.Drawing.Size(254, 20);
            this.tbUri.TabIndex = 0;
            this.tbUri.Text = "145.239.142.30:5001";
            this.tbUri.Validated += new System.EventHandler(this.tbUri_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Matching URI";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(3, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(112, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // uriErrorProvider
            // 
            this.uriErrorProvider.BlinkRate = 1000;
            this.uriErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.uriErrorProvider.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server Status URI";
            // 
            // tbServerStatusURI
            // 
            this.uriErrorProvider.SetIconPadding(this.tbServerStatusURI, 2);
            this.tbServerStatusURI.Location = new System.Drawing.Point(3, 64);
            this.tbServerStatusURI.Name = "tbServerStatusURI";
            this.tbServerStatusURI.Size = new System.Drawing.Size(254, 20);
            this.tbServerStatusURI.TabIndex = 4;
            this.tbServerStatusURI.Text = "145.239.142.30:8080/status/";
            //
            // ConnectionSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 129);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbServerStatusURI);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUri);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConnectionSettingsDialog";
            this.Text = "Connection Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Label label2;
        private TextBox tbServerStatusURI;
    }
}