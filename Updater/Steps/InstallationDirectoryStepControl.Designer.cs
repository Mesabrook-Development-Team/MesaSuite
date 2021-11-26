
namespace Updater.Steps
{
    partial class InstallationDirectoryStepControl
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
            this.txtInstallDirectory = new System.Windows.Forms.TextBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please specify where you want MesaSuite installed:\r\n";
            // 
            // txtInstallDirectory
            // 
            this.txtInstallDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInstallDirectory.Location = new System.Drawing.Point(22, 234);
            this.txtInstallDirectory.Name = "txtInstallDirectory";
            this.txtInstallDirectory.Size = new System.Drawing.Size(413, 20);
            this.txtInstallDirectory.TabIndex = 1;
            this.txtInstallDirectory.TextChanged += new System.EventHandler(this.txtInstallDirectory_TextChanged);
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowse.Location = new System.Drawing.Point(441, 232);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowse.TabIndex = 2;
            this.cmdBrowse.Text = "Browse...";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Welcome to the Mesasuite Installer!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 52);
            this.label3.TabIndex = 4;
            this.label3.Text = "MesaSuite is Mesabrook\'s official companion program.\r\n\r\nIt contains all kinds of " +
    "useful tools that allow you to\r\nmake the most out of your time playing on Mesabr" +
    "ook.";
            // 
            // InstallationDirectoryStepControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.txtInstallDirectory);
            this.Controls.Add(this.label1);
            this.Name = "InstallationDirectoryStepControl";
            this.Size = new System.Drawing.Size(538, 318);
            this.Load += new System.EventHandler(this.InstallationDirectoryStepControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.TextBox txtInstallDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
