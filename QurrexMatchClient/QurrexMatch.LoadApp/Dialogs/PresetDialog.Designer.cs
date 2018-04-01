namespace QurrexMatch.LoadApp.Dialogs
{
    partial class PresetDialog
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
            this.tbPayload = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.RichTextBox();
            this.tbPayloadHint = new System.Windows.Forms.RichTextBox();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbPayload)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPayload
            // 
            this.tbPayload.Location = new System.Drawing.Point(12, 149);
            this.tbPayload.Minimum = 1;
            this.tbPayload.Name = "tbPayload";
            this.tbPayload.Size = new System.Drawing.Size(247, 45);
            this.tbPayload.TabIndex = 0;
            this.tbPayload.Value = 1;
            this.tbPayload.Scroll += new System.EventHandler(this.tbPayload_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "low";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "high";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Set the payload here";
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDescription.Location = new System.Drawing.Point(12, 12);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            this.tbDescription.Size = new System.Drawing.Size(481, 106);
            this.tbDescription.TabIndex = 4;
            this.tbDescription.Text = "";
            // 
            // tbPayloadHint
            // 
            this.tbPayloadHint.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbPayloadHint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPayloadHint.Location = new System.Drawing.Point(12, 216);
            this.tbPayloadHint.Name = "tbPayloadHint";
            this.tbPayloadHint.ReadOnly = true;
            this.tbPayloadHint.Size = new System.Drawing.Size(481, 95);
            this.tbPayloadHint.TabIndex = 5;
            this.tbPayloadHint.Text = "";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(7, 327);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(133, 30);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // PresetDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 363);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbPayloadHint);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPayload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PresetDialog";
            this.Text = "Preset";
            ((System.ComponentModel.ISupportInitialize)(this.tbPayload)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tbPayload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox tbDescription;
        private System.Windows.Forms.RichTextBox tbPayloadHint;
        private System.Windows.Forms.Button btnStart;
    }
}