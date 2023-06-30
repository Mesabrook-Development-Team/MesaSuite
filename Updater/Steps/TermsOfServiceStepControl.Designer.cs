namespace Updater.Steps
{
    partial class TermsOfServiceStepControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.chkBoxAccept = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Please review our Terms of Service.";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(22, 57);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(496, 179);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "Adam pls put terms here thx uwu <3";
            // 
            // chkBoxAccept
            // 
            this.chkBoxAccept.AutoSize = true;
            this.chkBoxAccept.Location = new System.Drawing.Point(22, 293);
            this.chkBoxAccept.Name = "chkBoxAccept";
            this.chkBoxAccept.Size = new System.Drawing.Size(167, 17);
            this.chkBoxAccept.TabIndex = 7;
            this.chkBoxAccept.Text = "I Accept the Terms of Service";
            this.chkBoxAccept.UseVisualStyleBackColor = true;
            this.chkBoxAccept.CheckedChanged += new System.EventHandler(this.chkBoxAccept_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "To install MesaSuite, you must accept our Terms of Service. By checking the box b" +
    "elow,\r\nyou acknowledge that you have read, understand, and accept our Terms of S" +
    "ervice.";
            // 
            // TermsOfServiceStepControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkBoxAccept);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Name = "TermsOfServiceStepControl";
            this.Size = new System.Drawing.Size(538, 318);
            this.Load += new System.EventHandler(this.TermsOfServiceStepControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox chkBoxAccept;
        private System.Windows.Forms.Label label1;
    }
}
