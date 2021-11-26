
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
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "Installation has completed successfully.\r\n\r\n\r\nThank you for installing Mesasuite." +
    " We hope you enjoy it!\r\n\r\n~The Mesabrook Development Team.";
            // 
            // chkLaunch
            // 
            this.chkLaunch.AutoSize = true;
            this.chkLaunch.Checked = true;
            this.chkLaunch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLaunch.Location = new System.Drawing.Point(22, 231);
            this.chkLaunch.Name = "chkLaunch";
            this.chkLaunch.Size = new System.Drawing.Size(158, 17);
            this.chkLaunch.TabIndex = 1;
            this.chkLaunch.Text = "Launch MesaSuite on close";
            this.chkLaunch.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Installation Complete";
            // 
            // InstallationCompleteStepControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
    }
}
