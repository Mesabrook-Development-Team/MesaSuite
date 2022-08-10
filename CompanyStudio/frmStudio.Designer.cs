﻿namespace CompanyStudio
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
            this.mnuLocationExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmailExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployeeExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.financeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAccountExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.invoicingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInvoicePayables = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInvoicingReceivables = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.emailConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInvoicingEmailPayableReceived = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInvoicingEmailReceivableReady = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWireTransfers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWireTransferHistoryExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuWireTransferEmailConfiguration = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolLocationDropDown = new System.Windows.Forms.ToolStripComboBox();
            this.tmrLocationUpdater = new System.Windows.Forms.Timer(this.components);
            this.loader = new CompanyStudio.Loader();
            this.studioFormExtender = new CompanyStudio.StudioFormExtender(this.components);
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
            this.dockPanel.Location = new System.Drawing.Point(0, 80);
            this.dockPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(1200, 612);
            this.dockPanel.TabIndex = 0;
            // 
            // mnuBanner
            // 
            this.mnuBanner.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuBanner.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuBanner.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyToolStripMenuItem,
            this.emailToolStripMenuItem,
            this.employeesToolStripMenuItem,
            this.financeToolStripMenuItem,
            this.wIndowToolStripMenuItem});
            this.mnuBanner.Location = new System.Drawing.Point(0, 0);
            this.mnuBanner.Name = "mnuBanner";
            this.mnuBanner.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.mnuBanner.Size = new System.Drawing.Size(1200, 36);
            this.mnuBanner.TabIndex = 2;
            this.mnuBanner.Text = "Banner";
            // 
            // companyToolStripMenuItem
            // 
            this.companyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCompanyExplorer,
            this.mnuLocationExplorer});
            this.companyToolStripMenuItem.Name = "companyToolStripMenuItem";
            this.companyToolStripMenuItem.Size = new System.Drawing.Size(105, 32);
            this.companyToolStripMenuItem.Text = "Company";
            // 
            // mnuCompanyExplorer
            // 
            this.mnuCompanyExplorer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mnuCompanyExplorer.Image = global::CompanyStudio.Properties.Resources.icn_com;
            this.mnuCompanyExplorer.Name = "mnuCompanyExplorer";
            this.mnuCompanyExplorer.Size = new System.Drawing.Size(260, 34);
            this.mnuCompanyExplorer.Text = "Company Explorer";
            this.mnuCompanyExplorer.Click += new System.EventHandler(this.mnuCompanyExplorer_Click);
            // 
            // mnuLocationExplorer
            // 
            this.mnuLocationExplorer.Image = global::CompanyStudio.Properties.Resources.icn_earth;
            this.mnuLocationExplorer.Name = "mnuLocationExplorer";
            this.mnuLocationExplorer.Size = new System.Drawing.Size(260, 34);
            this.mnuLocationExplorer.Text = "Location Explorer";
            this.mnuLocationExplorer.Click += new System.EventHandler(this.mnuLocationExplorer_Click);
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEmailExplorer});
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(70, 29);
            this.emailToolStripMenuItem.Text = "Email";
            this.emailToolStripMenuItem.Visible = false;
            // 
            // mnuEmailExplorer
            // 
            this.mnuEmailExplorer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mnuEmailExplorer.Image = global::CompanyStudio.Properties.Resources.mail_explorer;
            this.mnuEmailExplorer.Name = "mnuEmailExplorer";
            this.mnuEmailExplorer.Size = new System.Drawing.Size(225, 34);
            this.mnuEmailExplorer.Text = "Email Explorer";
            this.mnuEmailExplorer.Click += new System.EventHandler(this.mnuEmailExplorer_Click);
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEmployeeExplorer});
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(114, 29);
            this.employeesToolStripMenuItem.Text = "Employees";
            this.employeesToolStripMenuItem.Visible = false;
            // 
            // mnuEmployeeExplorer
            // 
            this.mnuEmployeeExplorer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mnuEmployeeExplorer.Image = global::CompanyStudio.Properties.Resources.icn_hire;
            this.mnuEmployeeExplorer.Name = "mnuEmployeeExplorer";
            this.mnuEmployeeExplorer.Size = new System.Drawing.Size(261, 34);
            this.mnuEmployeeExplorer.Text = "Employee Explorer";
            this.mnuEmployeeExplorer.Click += new System.EventHandler(this.mnuEmployeeExplorer_Click);
            // 
            // financeToolStripMenuItem
            // 
            this.financeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountsToolStripMenuItem,
            this.invoicingToolStripMenuItem,
            this.mnuWireTransfers});
            this.financeToolStripMenuItem.Name = "financeToolStripMenuItem";
            this.financeToolStripMenuItem.Size = new System.Drawing.Size(87, 29);
            this.financeToolStripMenuItem.Text = "Finance";
            this.financeToolStripMenuItem.Visible = false;
            this.financeToolStripMenuItem.DropDownOpening += new System.EventHandler(this.financeToolStripMenuItem_DropDownOpening);
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAccountExplorer,
            this.mnuCategories});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.accountsToolStripMenuItem.Text = "Accounts";
            // 
            // mnuAccountExplorer
            // 
            this.mnuAccountExplorer.Image = global::CompanyStudio.Properties.Resources.icn_mbd_slim;
            this.mnuAccountExplorer.Name = "mnuAccountExplorer";
            this.mnuAccountExplorer.Size = new System.Drawing.Size(248, 34);
            this.mnuAccountExplorer.Text = "Account Explorer";
            this.mnuAccountExplorer.Click += new System.EventHandler(this.mnuAccountExplorer_Click);
            // 
            // mnuCategories
            // 
            this.mnuCategories.Image = global::CompanyStudio.Properties.Resources.icn_category;
            this.mnuCategories.Name = "mnuCategories";
            this.mnuCategories.Size = new System.Drawing.Size(248, 34);
            this.mnuCategories.Text = "Categories";
            this.mnuCategories.Click += new System.EventHandler(this.mnuCategories_Click);
            // 
            // invoicingToolStripMenuItem
            // 
            this.invoicingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInvoicePayables,
            this.mnuInvoicingReceivables,
            this.toolStripMenuItem1,
            this.emailConfigurationToolStripMenuItem});
            this.invoicingToolStripMenuItem.Name = "invoicingToolStripMenuItem";
            this.invoicingToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.invoicingToolStripMenuItem.Text = "Invoicing";
            // 
            // mnuInvoicePayables
            // 
            this.mnuInvoicePayables.Image = global::CompanyStudio.Properties.Resources.icn_dollar_out;
            this.mnuInvoicePayables.Name = "mnuInvoicePayables";
            this.mnuInvoicePayables.Size = new System.Drawing.Size(270, 34);
            this.mnuInvoicePayables.Text = "Payables";
            this.mnuInvoicePayables.Click += new System.EventHandler(this.mnuInvoicePayables_Click);
            // 
            // mnuInvoicingReceivables
            // 
            this.mnuInvoicingReceivables.Image = global::CompanyStudio.Properties.Resources.icn_dollar_in;
            this.mnuInvoicingReceivables.Name = "mnuInvoicingReceivables";
            this.mnuInvoicingReceivables.Size = new System.Drawing.Size(270, 34);
            this.mnuInvoicingReceivables.Text = "Receivables";
            this.mnuInvoicingReceivables.Click += new System.EventHandler(this.mnuInvoicingReceivables_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(267, 6);
            // 
            // emailConfigurationToolStripMenuItem
            // 
            this.emailConfigurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInvoicingEmailPayableReceived,
            this.mnuInvoicingEmailReceivableReady});
            this.emailConfigurationToolStripMenuItem.Name = "emailConfigurationToolStripMenuItem";
            this.emailConfigurationToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.emailConfigurationToolStripMenuItem.Text = "Email Configuration";
            // 
            // mnuInvoicingEmailPayableReceived
            // 
            this.mnuInvoicingEmailPayableReceived.Name = "mnuInvoicingEmailPayableReceived";
            this.mnuInvoicingEmailPayableReceived.Size = new System.Drawing.Size(249, 34);
            this.mnuInvoicingEmailPayableReceived.Text = "Payable Received";
            this.mnuInvoicingEmailPayableReceived.Click += new System.EventHandler(this.mnuInvoicingEmailPayableReceived_Click);
            // 
            // mnuInvoicingEmailReceivableReady
            // 
            this.mnuInvoicingEmailReceivableReady.Name = "mnuInvoicingEmailReceivableReady";
            this.mnuInvoicingEmailReceivableReady.Size = new System.Drawing.Size(249, 34);
            this.mnuInvoicingEmailReceivableReady.Text = "Receivable Ready";
            this.mnuInvoicingEmailReceivableReady.Click += new System.EventHandler(this.mnuInvoicingEmailReceivableReady_Click);
            // 
            // mnuWireTransfers
            // 
            this.mnuWireTransfers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWireTransferHistoryExplorer,
            this.toolStripMenuItem2,
            this.mnuWireTransferEmailConfiguration});
            this.mnuWireTransfers.Name = "mnuWireTransfers";
            this.mnuWireTransfers.Size = new System.Drawing.Size(224, 34);
            this.mnuWireTransfers.Text = "Wire Transfers";
            this.mnuWireTransfers.Visible = false;
            // 
            // mnuWireTransferHistoryExplorer
            // 
            this.mnuWireTransferHistoryExplorer.Name = "mnuWireTransferHistoryExplorer";
            this.mnuWireTransferHistoryExplorer.Size = new System.Drawing.Size(270, 34);
            this.mnuWireTransferHistoryExplorer.Text = "History Explorer";
            this.mnuWireTransferHistoryExplorer.Click += new System.EventHandler(this.mnuWireTransfersHistoryExplorer_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(267, 6);
            // 
            // mnuWireTransferEmailConfiguration
            // 
            this.mnuWireTransferEmailConfiguration.Name = "mnuWireTransferEmailConfiguration";
            this.mnuWireTransferEmailConfiguration.Size = new System.Drawing.Size(270, 34);
            this.mnuWireTransferEmailConfiguration.Text = "Email Configuration";
            this.mnuWireTransferEmailConfiguration.Click += new System.EventHandler(this.mnuWireTransferEmailConfiguration_Click);
            // 
            // wIndowToolStripMenuItem
            // 
            this.wIndowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThemes});
            this.wIndowToolStripMenuItem.Name = "wIndowToolStripMenuItem";
            this.wIndowToolStripMenuItem.Size = new System.Drawing.Size(94, 32);
            this.wIndowToolStripMenuItem.Text = "Window";
            // 
            // mnuThemes
            // 
            this.mnuThemes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLightTheme,
            this.mnuDarkTheme,
            this.mnuBlueTheme});
            this.mnuThemes.Image = global::CompanyStudio.Properties.Resources.icn_theme;
            this.mnuThemes.Name = "mnuThemes";
            this.mnuThemes.Size = new System.Drawing.Size(167, 34);
            this.mnuThemes.Text = "Theme";
            // 
            // mnuLightTheme
            // 
            this.mnuLightTheme.Name = "mnuLightTheme";
            this.mnuLightTheme.Size = new System.Drawing.Size(153, 34);
            this.mnuLightTheme.Tag = "light";
            this.mnuLightTheme.Text = "Light";
            this.mnuLightTheme.Click += new System.EventHandler(this.mnuTheme_Click);
            // 
            // mnuDarkTheme
            // 
            this.mnuDarkTheme.Name = "mnuDarkTheme";
            this.mnuDarkTheme.Size = new System.Drawing.Size(153, 34);
            this.mnuDarkTheme.Tag = "dark";
            this.mnuDarkTheme.Text = "Dark";
            this.mnuDarkTheme.Click += new System.EventHandler(this.mnuTheme_Click);
            // 
            // mnuBlueTheme
            // 
            this.mnuBlueTheme.Name = "mnuBlueTheme";
            this.mnuBlueTheme.Size = new System.Drawing.Size(153, 34);
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
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolSaveAll,
            this.toolStripLabel1,
            this.toolCompanyDropDown,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolLocationDropDown});
            this.toolStrip.Location = new System.Drawing.Point(0, 36);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip.Size = new System.Drawing.Size(1200, 38);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolSave
            // 
            this.toolSave.Image = global::CompanyStudio.Properties.Resources.icn_save;
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(77, 33);
            this.toolSave.Text = "Save";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolSaveAll
            // 
            this.toolSaveAll.Image = global::CompanyStudio.Properties.Resources.icn_saveall;
            this.toolSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveAll.Name = "toolSaveAll";
            this.toolSaveAll.Size = new System.Drawing.Size(102, 33);
            this.toolSaveAll.Text = "Save All";
            this.toolSaveAll.Click += new System.EventHandler(this.toolSaveAll_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Image = global::CompanyStudio.Properties.Resources.icn_com;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(117, 33);
            this.toolStripLabel1.Text = "Company:";
            // 
            // toolCompanyDropDown
            // 
            this.toolCompanyDropDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.toolCompanyDropDown.Name = "toolCompanyDropDown";
            this.toolCompanyDropDown.Size = new System.Drawing.Size(180, 38);
            this.toolCompanyDropDown.SelectedIndexChanged += new System.EventHandler(this.toolCompanyDropDown_SelectedIndexChanged);
            this.toolCompanyDropDown.Enter += new System.EventHandler(this.toolCompanyDropDown_Enter);
            this.toolCompanyDropDown.Leave += new System.EventHandler(this.toolCompanyDropDown_Leave);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Image = global::CompanyStudio.Properties.Resources.icn_earth;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(107, 33);
            this.toolStripLabel2.Text = "Location:";
            // 
            // toolLocationDropDown
            // 
            this.toolLocationDropDown.Name = "toolLocationDropDown";
            this.toolLocationDropDown.Size = new System.Drawing.Size(180, 38);
            this.toolLocationDropDown.SelectedIndexChanged += new System.EventHandler(this.toolLocationDropDown_SelectedIndexChanged);
            this.toolLocationDropDown.Enter += new System.EventHandler(this.toolLocationDropDown_Enter);
            this.toolLocationDropDown.Leave += new System.EventHandler(this.toolLocationDropDown_Leave);
            // 
            // tmrLocationUpdater
            // 
            this.tmrLocationUpdater.Enabled = true;
            this.tmrLocationUpdater.Interval = 1000;
            this.tmrLocationUpdater.Tick += new System.EventHandler(this.tmrLocationUpdater_Tick);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(1200, 692);
            this.loader.TabIndex = 7;
            this.loader.Visible = false;
            // 
            // frmStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.mnuBanner);
            this.Controls.Add(this.loader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuBanner;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmStudio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Studio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStudio_FormClosing);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolLocationDropDown;
        private System.Windows.Forms.ToolStripMenuItem mnuLocationExplorer;
        private System.Windows.Forms.Timer tmrLocationUpdater;
        private System.Windows.Forms.ToolStripMenuItem financeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAccountExplorer;
        private System.Windows.Forms.ToolStripMenuItem mnuCategories;
        private System.Windows.Forms.ToolStripMenuItem invoicingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuInvoicePayables;
        private System.Windows.Forms.ToolStripMenuItem mnuInvoicingReceivables;
        private System.Windows.Forms.ToolStripMenuItem mnuWireTransfers;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem emailConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuWireTransferHistoryExplorer;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuWireTransferEmailConfiguration;
        private System.Windows.Forms.ToolStripMenuItem mnuInvoicingEmailPayableReceived;
        private System.Windows.Forms.ToolStripMenuItem mnuInvoicingEmailReceivableReady;
        private Loader loader;
        private StudioFormExtender studioFormExtender;
    }
}

