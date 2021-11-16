namespace SystemManagement
{
    partial class frmManage
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Users", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Governments", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Companies", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Email Domains", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Crash Reports", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManage));
            this.lstSecurities = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imlLarge = new System.Windows.Forms.ImageList(this.components);
            this.imlSmall = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewGovernment = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewDomain = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLargeIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSmallIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSecurities
            // 
            this.lstSecurities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSecurities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colType});
            this.lstSecurities.FullRowSelect = true;
            listViewGroup1.Header = "Users";
            listViewGroup1.Name = "grpUsers";
            listViewGroup2.Header = "Governments";
            listViewGroup2.Name = "grpGovernments";
            listViewGroup3.Header = "Companies";
            listViewGroup3.Name = "grpCompanies";
            listViewGroup4.Header = "Email Domains";
            listViewGroup4.Name = "grpDomains";
            listViewGroup5.Header = "Crash Reports";
            listViewGroup5.Name = "grpCrashReports";
            this.lstSecurities.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5});
            this.lstSecurities.HideSelection = false;
            this.lstSecurities.LargeImageList = this.imlLarge;
            this.lstSecurities.Location = new System.Drawing.Point(0, 27);
            this.lstSecurities.Name = "lstSecurities";
            this.lstSecurities.Size = new System.Drawing.Size(753, 384);
            this.lstSecurities.SmallImageList = this.imlSmall;
            this.lstSecurities.TabIndex = 0;
            this.lstSecurities.UseCompatibleStateImageBehavior = false;
            this.lstSecurities.View = System.Windows.Forms.View.SmallIcon;
            this.lstSecurities.DoubleClick += new System.EventHandler(this.lstSecurities_DoubleClick);
            this.lstSecurities.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSecurities_KeyDown);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 200;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 100;
            // 
            // imlLarge
            // 
            this.imlLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlLarge.ImageSize = new System.Drawing.Size(64, 64);
            this.imlLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imlSmall
            // 
            this.imlSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlSmall.ImageSize = new System.Drawing.Size(32, 32);
            this.imlSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearch.Location = new System.Drawing.Point(62, 417);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(117, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mnuView});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(753, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.mnuDelete});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewUser,
            this.mnuNewGovernment,
            this.mnuNewCompany,
            this.mnuNewDomain});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // mnuNewUser
            // 
            this.mnuNewUser.Name = "mnuNewUser";
            this.mnuNewUser.Size = new System.Drawing.Size(140, 22);
            this.mnuNewUser.Text = "User";
            this.mnuNewUser.Click += new System.EventHandler(this.mnuNewUser_Click);
            // 
            // mnuNewGovernment
            // 
            this.mnuNewGovernment.Name = "mnuNewGovernment";
            this.mnuNewGovernment.Size = new System.Drawing.Size(140, 22);
            this.mnuNewGovernment.Text = "Government";
            this.mnuNewGovernment.Click += new System.EventHandler(this.mnuNewGovernment_Click);
            // 
            // mnuNewCompany
            // 
            this.mnuNewCompany.Name = "mnuNewCompany";
            this.mnuNewCompany.Size = new System.Drawing.Size(140, 22);
            this.mnuNewCompany.Text = "Company";
            this.mnuNewCompany.Click += new System.EventHandler(this.mnuNewCompany_Click);
            // 
            // mnuNewDomain
            // 
            this.mnuNewDomain.Name = "mnuNewDomain";
            this.mnuNewDomain.Size = new System.Drawing.Size(140, 22);
            this.mnuNewDomain.Text = "Domain";
            this.mnuNewDomain.Click += new System.EventHandler(this.mnuNewDomain_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(107, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLargeIcon,
            this.mnuSmallIcon,
            this.mnuTile,
            this.mnuList,
            this.mnuDetails});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(44, 20);
            this.mnuView.Text = "View";
            // 
            // mnuLargeIcon
            // 
            this.mnuLargeIcon.Name = "mnuLargeIcon";
            this.mnuLargeIcon.Size = new System.Drawing.Size(129, 22);
            this.mnuLargeIcon.Text = "Large Icon";
            this.mnuLargeIcon.Click += new System.EventHandler(this.ListViewTypeUpdate);
            // 
            // mnuSmallIcon
            // 
            this.mnuSmallIcon.Checked = true;
            this.mnuSmallIcon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuSmallIcon.Name = "mnuSmallIcon";
            this.mnuSmallIcon.Size = new System.Drawing.Size(129, 22);
            this.mnuSmallIcon.Text = "Small Icon";
            this.mnuSmallIcon.Click += new System.EventHandler(this.ListViewTypeUpdate);
            // 
            // mnuTile
            // 
            this.mnuTile.Name = "mnuTile";
            this.mnuTile.Size = new System.Drawing.Size(129, 22);
            this.mnuTile.Text = "Tile";
            this.mnuTile.Click += new System.EventHandler(this.ListViewTypeUpdate);
            // 
            // mnuList
            // 
            this.mnuList.Name = "mnuList";
            this.mnuList.Size = new System.Drawing.Size(129, 22);
            this.mnuList.Text = "List";
            this.mnuList.Click += new System.EventHandler(this.ListViewTypeUpdate);
            // 
            // mnuDetails
            // 
            this.mnuDetails.Name = "mnuDetails";
            this.mnuDetails.Size = new System.Drawing.Size(129, 22);
            this.mnuDetails.Text = "Details";
            this.mnuDetails.Click += new System.EventHandler(this.ListViewTypeUpdate);
            // 
            // frmManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 445);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstSecurities);
            this.Enabled = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Management";
            this.Load += new System.EventHandler(this.frmManage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstSecurities;
        private System.Windows.Forms.ImageList imlSmall;
        private System.Windows.Forms.ImageList imlLarge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuNewUser;
        private System.Windows.Forms.ToolStripMenuItem mnuNewGovernment;
        private System.Windows.Forms.ToolStripMenuItem mnuNewCompany;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuLargeIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuSmallIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuTile;
        private System.Windows.Forms.ToolStripMenuItem mnuList;
        private System.Windows.Forms.ToolStripMenuItem mnuDetails;
        private System.Windows.Forms.ToolStripMenuItem mnuNewDomain;
    }
}