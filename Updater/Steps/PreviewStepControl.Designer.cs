
namespace Updater.Steps
{
    partial class PreviewStepControl
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
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.chkDesktop = new System.Windows.Forms.CheckBox();
            this.chkStartMenu = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "directory:";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(3, 16);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.ReadOnly = true;
            this.txtDirectory.Size = new System.Drawing.Size(532, 20);
            this.txtDirectory.TabIndex = 1;
            // 
            // chkDesktop
            // 
            this.chkDesktop.AutoSize = true;
            this.chkDesktop.Enabled = false;
            this.chkDesktop.Location = new System.Drawing.Point(3, 42);
            this.chkDesktop.Name = "chkDesktop";
            this.chkDesktop.Size = new System.Drawing.Size(72, 17);
            this.chkDesktop.TabIndex = 2;
            this.chkDesktop.Text = "desk icon";
            this.chkDesktop.UseVisualStyleBackColor = true;
            // 
            // chkStartMenu
            // 
            this.chkStartMenu.AutoSize = true;
            this.chkStartMenu.Enabled = false;
            this.chkStartMenu.Location = new System.Drawing.Point(3, 65);
            this.chkStartMenu.Name = "chkStartMenu";
            this.chkStartMenu.Size = new System.Drawing.Size(69, 17);
            this.chkStartMenu.TabIndex = 2;
            this.chkStartMenu.Text = "start icon";
            this.chkStartMenu.UseVisualStyleBackColor = true;
            // 
            // PreviewStepControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkStartMenu);
            this.Controls.Add(this.chkDesktop);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "PreviewStepControl";
            this.Size = new System.Drawing.Size(538, 318);
            this.Load += new System.EventHandler(this.PreviewStepControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.CheckBox chkDesktop;
        private System.Windows.Forms.CheckBox chkStartMenu;
    }
}
