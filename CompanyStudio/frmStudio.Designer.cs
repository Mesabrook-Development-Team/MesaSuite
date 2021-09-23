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
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.mnuBanner = new System.Windows.Forms.MenuStrip();
            this.companyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCompanyExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmailExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.wIndowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThemes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLightTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDarkTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBlueTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripExtender = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.vS2015LightTheme = new WeifenLuo.WinFormsUI.Docking.VS2015LightTheme();
            this.vS2015DarkTheme = new WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme();
            this.vS2015BlueTheme = new WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolSaveAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolCompanyDropDown = new System.Windows.Forms.ToolStripComboBox();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployeeExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBanner.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanel
            // 
            this.dockPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanel.DockBottomPortion = 0.15D;
            this.dockPanel.DockLeftPortion = 0.15D;
            this.dockPanel.DockRightPortion = 0.15D;
            this.dockPanel.DockTopPortion = 0.15D;
            this.dockPanel.Location = new System.Drawing.Point(0, 52);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(800, 398);
            this.dockPanel.TabIndex = 0;
            // 
            // mnuBanner
            // 
            this.mnuBanner.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyToolStripMenuItem,
            this.emailToolStripMenuItem,
            this.employeesToolStripMenuItem,
            this.wIndowToolStripMenuItem});
            this.mnuBanner.Location = new System.Drawing.Point(0, 0);
            this.mnuBanner.Name = "mnuBanner";
            this.mnuBanner.Size = new System.Drawing.Size(800, 24);
            this.mnuBanner.TabIndex = 2;
            this.mnuBanner.Text = "Banner";
            // 
            // companyToolStripMenuItem
            // 
            this.companyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCompanyExplorer});
            this.companyToolStripMenuItem.Name = "companyToolStripMenuItem";
            this.companyToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.companyToolStripMenuItem.Text = "Company";
            // 
            // mnuCompanyExplorer
            // 
            this.mnuCompanyExplorer.Name = "mnuCompanyExplorer";
            this.mnuCompanyExplorer.Size = new System.Drawing.Size(172, 22);
            this.mnuCompanyExplorer.Text = "Company Explorer";
            this.mnuCompanyExplorer.Click += new System.EventHandler(this.mnuCompanyExplorer_Click);
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
            this.mnuEmailExplorer.Image = global::CompanyStudio.Properties.Resources.mail_explorer;
            this.mnuEmailExplorer.Name = "mnuEmailExplorer";
            this.mnuEmailExplorer.Size = new System.Drawing.Size(180, 22);
            this.mnuEmailExplorer.Text = "Email Explorer";
            this.mnuEmailExplorer.Click += new System.EventHandler(this.mnuEmailExplorer_Click);
            // 
            // wIndowToolStripMenuItem
            // 
            this.wIndowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThemes});
            this.wIndowToolStripMenuItem.Name = "wIndowToolStripMenuItem";
            this.wIndowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.wIndowToolStripMenuItem.Text = "Window";
            // 
            // mnuThemes
            // 
            this.mnuThemes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLightTheme,
            this.mnuDarkTheme,
            this.mnuBlueTheme});
            this.mnuThemes.Name = "mnuThemes";
            this.mnuThemes.Size = new System.Drawing.Size(180, 22);
            this.mnuThemes.Text = "Theme";
            // 
            // mnuLightTheme
            // 
            this.mnuLightTheme.Name = "mnuLightTheme";
            this.mnuLightTheme.Size = new System.Drawing.Size(101, 22);
            this.mnuLightTheme.Tag = "light";
            this.mnuLightTheme.Text = "Light";
            this.mnuLightTheme.Click += new System.EventHandler(this.mnuTheme_Click);
            // 
            // mnuDarkTheme
            // 
            this.mnuDarkTheme.Name = "mnuDarkTheme";
            this.mnuDarkTheme.Size = new System.Drawing.Size(101, 22);
            this.mnuDarkTheme.Tag = "dark";
            this.mnuDarkTheme.Text = "Dark";
            this.mnuDarkTheme.Click += new System.EventHandler(this.mnuTheme_Click);
            // 
            // mnuBlueTheme
            // 
            this.mnuBlueTheme.Name = "mnuBlueTheme";
            this.mnuBlueTheme.Size = new System.Drawing.Size(101, 22);
            this.mnuBlueTheme.Tag = "blue";
            this.mnuBlueTheme.Text = "Blue";
            this.mnuBlueTheme.Click += new System.EventHandler(this.mnuTheme_Click);
            // 
            // toolStripExtender
            // 
            this.toolStripExtender.DefaultRenderer = null;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolSaveAll,
            this.toolStripLabel1,
            this.toolCompanyDropDown});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 25);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolSave
            // 
            this.toolSave.Image = global::CompanyStudio.Properties.Resources.icn_save;
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(51, 22);
            this.toolSave.Text = "Save";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolSaveAll
            // 
            this.toolSaveAll.Image = global::CompanyStudio.Properties.Resources.icn_saveall;
            this.toolSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveAll.Name = "toolSaveAll";
            this.toolSaveAll.Size = new System.Drawing.Size(68, 22);
            this.toolSaveAll.Text = "Save All";
            this.toolSaveAll.Click += new System.EventHandler(this.toolSaveAll_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(62, 22);
            this.toolStripLabel1.Text = "Company:";
            // 
            // toolCompanyDropDown
            // 
            this.toolCompanyDropDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.toolCompanyDropDown.Name = "toolCompanyDropDown";
            this.toolCompanyDropDown.Size = new System.Drawing.Size(121, 25);
            this.toolCompanyDropDown.SelectedIndexChanged += new System.EventHandler(this.toolCompanyDropDown_SelectedIndexChanged);
            this.toolCompanyDropDown.Enter += new System.EventHandler(this.toolCompanyDropDown_Enter);
            this.toolCompanyDropDown.Leave += new System.EventHandler(this.toolCompanyDropDown_Leave);
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEmployeeExplorer});
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.employeesToolStripMenuItem.Text = "Employees";
            // 
            // mnuEmployeeExplorer
            // 
            this.mnuEmployeeExplorer.Name = "mnuEmployeeExplorer";
            this.mnuEmployeeExplorer.Size = new System.Drawing.Size(180, 22);
            this.mnuEmployeeExplorer.Text = "Employee Explorer";
            this.mnuEmployeeExplorer.Click += new System.EventHandler(this.mnuEmployeeExplorer_Click);
            // 
            // frmStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.mnuBanner);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuBanner;
            this.Name = "frmStudio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Studio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStudio_Load);
            this.mnuBanner.ResumeLayout(false);
            this.mnuBanner.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnuBanner;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEmailExplorer;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender toolStripExtender;
        private System.Windows.Forms.ToolStripMenuItem wIndowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuThemes;
        private System.Windows.Forms.ToolStripMenuItem mnuLightTheme;
        private System.Windows.Forms.ToolStripMenuItem mnuDarkTheme;
        private System.Windows.Forms.ToolStripMenuItem mnuBlueTheme;
        private WeifenLuo.WinFormsUI.Docking.VS2015LightTheme vS2015LightTheme;
        private WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme vS2015DarkTheme;
        private WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme vS2015BlueTheme;
        private System.Windows.Forms.ToolStripMenuItem companyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCompanyExplorer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripComboBox toolCompanyDropDown;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        public WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolSaveAll;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEmployeeExplorer;
    }
}

