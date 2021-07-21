namespace CompanyStudio
{
    partial class frmStudio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudio));
            this.dckPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.vS2015BlueTheme = new WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme();
            this.vS2015DarkTheme = new WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme();
            this.vS2015LightTheme = new WeifenLuo.WinFormsUI.Docking.VS2015LightTheme();
            this.mnuBanner = new System.Windows.Forms.MenuStrip();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmailExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripExtender = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.mnuBanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // dckPanel
            // 
            this.dckPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dckPanel.Location = new System.Drawing.Point(0, 24);
            this.dckPanel.Name = "dckPanel";
            this.dckPanel.Size = new System.Drawing.Size(800, 426);
            this.dckPanel.TabIndex = 0;
            // 
            // mnuBanner
            // 
            this.mnuBanner.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailToolStripMenuItem});
            this.mnuBanner.Location = new System.Drawing.Point(0, 0);
            this.mnuBanner.Name = "mnuBanner";
            this.mnuBanner.Size = new System.Drawing.Size(800, 24);
            this.mnuBanner.TabIndex = 2;
            this.mnuBanner.Text = "Banner";
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEmailExplorer});
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.emailToolStripMenuItem.Text = "Email";
            // 
            // mnuEmailExplorer
            // 
            this.mnuEmailExplorer.Name = "mnuEmailExplorer";
            this.mnuEmailExplorer.Size = new System.Drawing.Size(149, 22);
            this.mnuEmailExplorer.Text = "Email Explorer";
            // 
            // toolStripExtender
            // 
            this.toolStripExtender.DefaultRenderer = null;
            // 
            // frmStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dckPanel);
            this.Controls.Add(this.mnuBanner);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuBanner;
            this.Name = "frmStudio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Studio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStudio_Load);
            this.mnuBanner.ResumeLayout(false);
            this.mnuBanner.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel dckPanel;
        private WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme vS2015BlueTheme;
        private WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme vS2015DarkTheme;
        private WeifenLuo.WinFormsUI.Docking.VS2015LightTheme vS2015LightTheme;
        private System.Windows.Forms.MenuStrip mnuBanner;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEmailExplorer;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender toolStripExtender;
    }
}

