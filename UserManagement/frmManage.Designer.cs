namespace UserManagement
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
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Permissions", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManage));
            this.lstSecurities = new System.Windows.Forms.ListView();
            this.ctxSecurities = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLargeIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSmallIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.imlLarge = new System.Windows.Forms.ImageList(this.components);
            this.imlSmall = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmdAddUser = new System.Windows.Forms.Button();
            this.ctxSecurities.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSecurities
            // 
            this.lstSecurities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSecurities.ContextMenuStrip = this.ctxSecurities;
            this.lstSecurities.FullRowSelect = true;
            listViewGroup1.Header = "Users";
            listViewGroup1.Name = "grpUsers";
            listViewGroup2.Header = "Permissions";
            listViewGroup2.Name = "grpPermissions";
            this.lstSecurities.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lstSecurities.HideSelection = false;
            this.lstSecurities.LargeImageList = this.imlLarge;
            this.lstSecurities.Location = new System.Drawing.Point(0, 0);
            this.lstSecurities.Name = "lstSecurities";
            this.lstSecurities.Size = new System.Drawing.Size(638, 411);
            this.lstSecurities.SmallImageList = this.imlSmall;
            this.lstSecurities.TabIndex = 0;
            this.lstSecurities.UseCompatibleStateImageBehavior = false;
            this.lstSecurities.View = System.Windows.Forms.View.SmallIcon;
            this.lstSecurities.DoubleClick += new System.EventHandler(this.lstSecurities_DoubleClick);
            this.lstSecurities.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSecurities_KeyDown);
            // 
            // ctxSecurities
            // 
            this.ctxSecurities.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuView,
            this.toolStripMenuItem1,
            this.mnuDeleteUser});
            this.ctxSecurities.Name = "ctxSecurities";
            this.ctxSecurities.Size = new System.Drawing.Size(147, 54);
            this.ctxSecurities.Opening += new System.ComponentModel.CancelEventHandler(this.ctxSecurities_Opening);
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
            this.mnuView.Size = new System.Drawing.Size(146, 22);
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
            // 
            // mnuDeleteUser
            // 
            this.mnuDeleteUser.Name = "mnuDeleteUser";
            this.mnuDeleteUser.Size = new System.Drawing.Size(146, 22);
            this.mnuDeleteUser.Text = "Delete User(s)";
            this.mnuDeleteUser.Click += new System.EventHandler(this.mnuDeleteUser_Click);
            // 
            // imlLarge
            // 
            this.imlLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLarge.ImageStream")));
            this.imlLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imlLarge.Images.SetKeyName(0, "permission");
            this.imlLarge.Images.SetKeyName(1, "user");
            // 
            // imlSmall
            // 
            this.imlSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmall.ImageStream")));
            this.imlSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSmall.Images.SetKeyName(0, "permission");
            this.imlSmall.Images.SetKeyName(1, "user");
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
            // cmdAddUser
            // 
            this.cmdAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddUser.Location = new System.Drawing.Point(551, 417);
            this.cmdAddUser.Name = "cmdAddUser";
            this.cmdAddUser.Size = new System.Drawing.Size(75, 23);
            this.cmdAddUser.TabIndex = 2;
            this.cmdAddUser.Text = "Add User";
            this.cmdAddUser.UseVisualStyleBackColor = true;
            this.cmdAddUser.Click += new System.EventHandler(this.cmdAddUser_Click);
            // 
            // frmManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 445);
            this.Controls.Add(this.cmdAddUser);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstSecurities);
            this.Enabled = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Management";
            this.Load += new System.EventHandler(this.frmManage_Load);
            this.ctxSecurities.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstSecurities;
        private System.Windows.Forms.ImageList imlSmall;
        private System.Windows.Forms.ImageList imlLarge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button cmdAddUser;
        private System.Windows.Forms.ContextMenuStrip ctxSecurities;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuLargeIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuSmallIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuTile;
        private System.Windows.Forms.ToolStripMenuItem mnuList;
        private System.Windows.Forms.ToolStripMenuItem mnuDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteUser;
    }
}