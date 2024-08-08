namespace MesaSuite.NotificationsAndTasks.NotificationEventWizard
{
    partial class WelcomeStep
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
            this.label1 = new System.Windows.Forms.Label();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 65);
            this.label1.TabIndex = 4;
            this.label1.Text = "to the Notification Creation Wizard.\r\n\r\nThis Wizard will help you compose a custo" +
    "m Notification.\r\n\r\nTo begin, click the Next button.";
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel1.Location = new System.Drawing.Point(3, 0);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(160, 46);
            this.bigLabel1.TabIndex = 3;
            this.bigLabel1.Text = "Welcome";
            // 
            // WelcomeStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bigLabel1);
            this.Name = "WelcomeStep";
            this.Size = new System.Drawing.Size(309, 147);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
    }
}
