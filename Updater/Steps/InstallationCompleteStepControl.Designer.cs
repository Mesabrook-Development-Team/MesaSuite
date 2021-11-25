
namespace Updater.Steps
{
    partial class InstallationCompleteStepControl
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
            this.chkLaunch = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Install complete";
            // 
            // chkLaunch
            // 
            this.chkLaunch.AutoSize = true;
            this.chkLaunch.Checked = true;
            this.chkLaunch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLaunch.Location = new System.Drawing.Point(0, 16);
            this.chkLaunch.Name = "chkLaunch";
            this.chkLaunch.Size = new System.Drawing.Size(158, 17);
            this.chkLaunch.TabIndex = 1;
            this.chkLaunch.Text = "Launch MesaSuite on close";
            this.chkLaunch.UseVisualStyleBackColor = true;
            // 
            // InstallationCompleteStepControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkLaunch);
            this.Controls.Add(this.label1);
            this.Name = "InstallationCompleteStepControl";
            this.Size = new System.Drawing.Size(538, 318);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkLaunch;
    }
}
