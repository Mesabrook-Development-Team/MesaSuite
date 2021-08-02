
namespace CompanyStudio
{
    partial class frmCompanyExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompanyExplorer));
            this.lstCompanies = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colManageEmails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colManageEmployees = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxCompanies = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuConnect = new System.Windows.Forms.ToolStripButton();
            this.mnuDisconnect = new System.Windows.Forms.ToolStripButton();
            this.visualStudioToolStripExtender = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.loader = new CompanyStudio.Loader();
            this.imlSmall = new System.Windows.Forms.ImageList(this.components);
            this.ctxCompanies.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCompanies
            // 
            this.lstCompanies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCompanies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colManageEmails,
            this.colManageEmployees});
            this.lstCompanies.ContextMenuStrip = this.ctxCompanies;
            this.lstCompanies.FullRowSelect = true;
            this.lstCompanies.HideSelection = false;
            this.lstCompanies.Location = new System.Drawing.Point(0, 28);
            this.lstCompanies.Name = "lstCompanies";
            this.lstCompanies.Size = new System.Drawing.Size(632, 434);
            this.lstCompanies.TabIndex = 0;
            this.lstCompanies.UseCompatibleStateImageBehavior = false;
            this.lstCompanies.View = System.Windows.Forms.View.Details;
            this.lstCompanies.SelectedIndexChanged += new System.EventHandler(this.lstCompanies_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 120;
            // 
            // colManageEmails
            // 
            this.colManageEmails.Text = "Manage Emails";
            this.colManageEmails.Width = 120;
            // 
            // colManageEmployees
            // 
            this.colManageEmployees.Text = "Manage Employees";
            this.colManageEmployees.Width = 120;
            // 
            // ctxCompanies
            // 
            this.ctxCompanies.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.ctxCompanies.Name = "contextMenuStrip1";
            this.ctxCompanies.Size = new System.Drawing.Size(134, 48);
            this.ctxCompanies.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectToolStripMenuItem.Text = "Connect...";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnect,
            this.mnuDisconnect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(632, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuConnect
            // 
            this.mnuConnect.Image = global::CompanyStudio.Properties.Resources.company_connect;
            this.mnuConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuConnect.Name = "mnuConnect";
            this.mnuConnect.Size = new System.Drawing.Size(72, 22);
            this.mnuConnect.Text = "Connect";
            this.mnuConnect.Click += new System.EventHandler(this.mnuConnect_Click);
            // 
            // mnuDisconnect
            // 
            this.mnuDisconnect.Enabled = false;
            this.mnuDisconnect.Image = global::CompanyStudio.Properties.Resources.company_disconnect;
            this.mnuDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDisconnect.Name = "mnuDisconnect";
            this.mnuDisconnect.Size = new System.Drawing.Size(86, 22);
            this.mnuDisconnect.Text = "Disconnect";
            this.mnuDisconnect.Click += new System.EventHandler(this.mnuDisconnect_Click);
            // 
            // visualStudioToolStripExtender
            // 
            this.visualStudioToolStripExtender.DefaultRenderer = null;
            // 
            // loader
            // 
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(632, 462);
            this.loader.TabIndex = 2;
            // 
            // imlSmall
            // 
            this.imlSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imlSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmCompanyExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 462);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lstCompanies);
            this.Controls.Add(this.loader);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCompanyExplorer";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Unknown;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Explorer";
            this.Load += new System.EventHandler(this.frmCompanyExplorer_Load);
            this.ctxCompanies.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstCompanies;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colManageEmails;
        private System.Windows.Forms.ColumnHeader colManageEmployees;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuConnect;
        private System.Windows.Forms.ToolStripButton mnuDisconnect;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender visualStudioToolStripExtender;
        private Loader loader;
        private System.Windows.Forms.ImageList imlSmall;
        private System.Windows.Forms.ContextMenuStrip ctxCompanies;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
    }
}