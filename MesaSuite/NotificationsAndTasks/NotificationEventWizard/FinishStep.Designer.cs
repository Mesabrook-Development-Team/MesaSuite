namespace MesaSuite.NotificationsAndTasks.NotificationEventWizard
{
    partial class FinishStep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinishStep));
            this.label8 = new System.Windows.Forms.Label();
            this.bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(329, 65);
            this.label8.TabIndex = 6;
            this.label8.Text = resources.GetString("label8.Text");
            // 
            // bigLabel2
            // 
            this.bigLabel2.AutoSize = true;
            this.bigLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel2.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.bigLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel2.Location = new System.Drawing.Point(3, 0);
            this.bigLabel2.Name = "bigLabel2";
            this.bigLabel2.Size = new System.Drawing.Size(215, 46);
            this.bigLabel2.TabIndex = 5;
            this.bigLabel2.Text = "Almost Done";
            // 
            // FinishStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bigLabel2);
            this.Name = "FinishStep";
            this.Size = new System.Drawing.Size(364, 136);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
    }
}
