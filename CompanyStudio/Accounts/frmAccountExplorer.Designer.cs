
namespace CompanyStudio.Accounts
{
    partial class frmAccountExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountExplorer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.cmdClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCreateAccount = new System.Windows.Forms.ToolStripButton();
            this.mnuCloseAccount = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuView = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuViewAccountNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSort = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuSortDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSortCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSortBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGrouping = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuGroupNone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGroupCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripExtender = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.treAccounts = new System.Windows.Forms.TreeView();
            this.ctxAccounts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxViewAccountNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxViewDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxViewCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxViewBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSort = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSortDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSortCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSortBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.groupingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxNoGrouping = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxCategoryGrouping = new System.Windows.Forms.ToolStripMenuItem();
            this.loader = new CompanyStudio.Loader();
            this.toolStrip1.SuspendLayout();
            this.ctxAccounts.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSearch,
            this.cmdClear,
            this.toolStripSeparator1,
            this.mnuCreateAccount,
            this.mnuCloseAccount,
            this.toolStripSeparator3,
            this.mnuView,
            this.mnuSort,
            this.mnuGrouping});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 23);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 23);
            this.txtSearch.Text = "Search...";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmdClear
            // 
            this.cmdClear.Image = global::CompanyStudio.Properties.Resources.arrow_in;
            this.cmdClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(54, 20);
            this.cmdClear.Text = "Clear";
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // mnuCreateAccount
            // 
            this.mnuCreateAccount.Image = global::CompanyStudio.Properties.Resources.chart_bar_add;
            this.mnuCreateAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCreateAccount.Name = "mnuCreateAccount";
            this.mnuCreateAccount.Size = new System.Drawing.Size(61, 20);
            this.mnuCreateAccount.Text = "Create";
            this.mnuCreateAccount.Click += new System.EventHandler(this.mnuCreateAccount_Click);
            // 
            // mnuCloseAccount
            // 
            this.mnuCloseAccount.Enabled = false;
            this.mnuCloseAccount.Image = global::CompanyStudio.Properties.Resources.chart_bar_delete;
            this.mnuCloseAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCloseAccount.Name = "mnuCloseAccount";
            this.mnuCloseAccount.Size = new System.Drawing.Size(56, 20);
            this.mnuCloseAccount.Text = "Close";
            this.mnuCloseAccount.Click += new System.EventHandler(this.mnuCloseAccount_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewAccountNumber,
            this.mnuViewDescription,
            this.mnuViewCategory,
            this.mnuViewBalance});
            this.mnuView.Image = global::CompanyStudio.Properties.Resources.eye;
            this.mnuView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(61, 20);
            this.mnuView.Text = "View";
            this.mnuView.DropDownOpening += new System.EventHandler(this.mnuView_DropDownOpening);
            this.mnuView.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuViewColumn_DropDownItemClicked);
            // 
            // mnuViewAccountNumber
            // 
            this.mnuViewAccountNumber.Name = "mnuViewAccountNumber";
            this.mnuViewAccountNumber.Size = new System.Drawing.Size(180, 22);
            this.mnuViewAccountNumber.Text = "Account Number";
            // 
            // mnuViewDescription
            // 
            this.mnuViewDescription.Name = "mnuViewDescription";
            this.mnuViewDescription.Size = new System.Drawing.Size(180, 22);
            this.mnuViewDescription.Text = "Description";
            // 
            // mnuViewCategory
            // 
            this.mnuViewCategory.Name = "mnuViewCategory";
            this.mnuViewCategory.Size = new System.Drawing.Size(180, 22);
            this.mnuViewCategory.Text = "Category";
            // 
            // mnuViewBalance
            // 
            this.mnuViewBalance.Name = "mnuViewBalance";
            this.mnuViewBalance.Size = new System.Drawing.Size(180, 22);
            this.mnuViewBalance.Text = "Balance";
            // 
            // mnuSort
            // 
            this.mnuSort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSortDescription,
            this.mnuSortCategory,
            this.mnuSortBalance});
            this.mnuSort.Image = global::CompanyStudio.Properties.Resources.table_sort;
            this.mnuSort.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSort.Name = "mnuSort";
            this.mnuSort.Size = new System.Drawing.Size(57, 20);
            this.mnuSort.Text = "Sort";
            this.mnuSort.DropDownOpening += new System.EventHandler(this.mnuSort_DropDownOpening);
            this.mnuSort.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuSort_DropDownItemClicked);
            // 
            // mnuSortDescription
            // 
            this.mnuSortDescription.Name = "mnuSortDescription";
            this.mnuSortDescription.Size = new System.Drawing.Size(180, 22);
            this.mnuSortDescription.Text = "Description";
            // 
            // mnuSortCategory
            // 
            this.mnuSortCategory.Name = "mnuSortCategory";
            this.mnuSortCategory.Size = new System.Drawing.Size(180, 22);
            this.mnuSortCategory.Text = "Category";
            // 
            // mnuSortBalance
            // 
            this.mnuSortBalance.Name = "mnuSortBalance";
            this.mnuSortBalance.Size = new System.Drawing.Size(180, 22);
            this.mnuSortBalance.Text = "Balance";
            // 
            // mnuGrouping
            // 
            this.mnuGrouping.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGroupNone,
            this.toolStripSeparator2,
            this.mnuGroupCategory});
            this.mnuGrouping.Image = global::CompanyStudio.Properties.Resources.group;
            this.mnuGrouping.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuGrouping.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuGrouping.Name = "mnuGrouping";
            this.mnuGrouping.Size = new System.Drawing.Size(69, 20);
            this.mnuGrouping.Text = "Group";
            this.mnuGrouping.DropDownOpening += new System.EventHandler(this.mnuGrouping_DropDownOpening);
            this.mnuGrouping.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuGrouping_DropDownItemClicked);
            // 
            // mnuGroupNone
            // 
            this.mnuGroupNone.Name = "mnuGroupNone";
            this.mnuGroupNone.Size = new System.Drawing.Size(180, 22);
            this.mnuGroupNone.Text = "No Grouping";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuGroupCategory
            // 
            this.mnuGroupCategory.Name = "mnuGroupCategory";
            this.mnuGroupCategory.Size = new System.Drawing.Size(180, 22);
            this.mnuGroupCategory.Text = "By Category";
            // 
            // toolStripExtender
            // 
            this.toolStripExtender.DefaultRenderer = null;
            // 
            // treAccounts
            // 
            this.treAccounts.ContextMenuStrip = this.ctxAccounts;
            this.treAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treAccounts.Location = new System.Drawing.Point(0, 23);
            this.treAccounts.Name = "treAccounts";
            this.treAccounts.Size = new System.Drawing.Size(800, 427);
            this.treAccounts.TabIndex = 1;
            this.treAccounts.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treAccounts_AfterSelect);
            this.treAccounts.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treAccounts_NodeMouseDoubleClick);
            // 
            // ctxAccounts
            // 
            this.ctxAccounts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxCreate,
            this.ctxClose,
            this.toolStripMenuItem1,
            this.viewToolStripMenuItem,
            this.ctxSort,
            this.groupingToolStripMenuItem});
            this.ctxAccounts.Name = "ctxAccounts";
            this.ctxAccounts.Size = new System.Drawing.Size(125, 120);
            // 
            // ctxCreate
            // 
            this.ctxCreate.Name = "ctxCreate";
            this.ctxCreate.Size = new System.Drawing.Size(124, 22);
            this.ctxCreate.Text = "Create";
            this.ctxCreate.Click += new System.EventHandler(this.mnuCreateAccount_Click);
            // 
            // ctxClose
            // 
            this.ctxClose.Name = "ctxClose";
            this.ctxClose.Size = new System.Drawing.Size(124, 22);
            this.ctxClose.Text = "Close";
            this.ctxClose.Click += new System.EventHandler(this.mnuCloseAccount_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxViewAccountNumber,
            this.ctxViewDescription,
            this.ctxViewCategory,
            this.ctxViewBalance});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this.mnuView_DropDownOpening);
            this.viewToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuViewColumn_DropDownItemClicked);
            // 
            // ctxViewAccountNumber
            // 
            this.ctxViewAccountNumber.Name = "ctxViewAccountNumber";
            this.ctxViewAccountNumber.Size = new System.Drawing.Size(166, 22);
            this.ctxViewAccountNumber.Text = "Account Number";
            // 
            // ctxViewDescription
            // 
            this.ctxViewDescription.Name = "ctxViewDescription";
            this.ctxViewDescription.Size = new System.Drawing.Size(166, 22);
            this.ctxViewDescription.Text = "Description";
            // 
            // ctxViewCategory
            // 
            this.ctxViewCategory.Name = "ctxViewCategory";
            this.ctxViewCategory.Size = new System.Drawing.Size(166, 22);
            this.ctxViewCategory.Text = "Category";
            // 
            // ctxViewBalance
            // 
            this.ctxViewBalance.Name = "ctxViewBalance";
            this.ctxViewBalance.Size = new System.Drawing.Size(166, 22);
            this.ctxViewBalance.Text = "Balance";
            // 
            // ctxSort
            // 
            this.ctxSort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxSortDescription,
            this.ctxSortCategory,
            this.ctxSortBalance});
            this.ctxSort.Name = "ctxSort";
            this.ctxSort.Size = new System.Drawing.Size(124, 22);
            this.ctxSort.Text = "Sort";
            this.ctxSort.DropDownOpening += new System.EventHandler(this.mnuSort_DropDownOpening);
            this.ctxSort.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuSort_DropDownItemClicked);
            // 
            // ctxSortDescription
            // 
            this.ctxSortDescription.Name = "ctxSortDescription";
            this.ctxSortDescription.Size = new System.Drawing.Size(134, 22);
            this.ctxSortDescription.Text = "Description";
            // 
            // ctxSortCategory
            // 
            this.ctxSortCategory.Name = "ctxSortCategory";
            this.ctxSortCategory.Size = new System.Drawing.Size(134, 22);
            this.ctxSortCategory.Text = "Category";
            // 
            // ctxSortBalance
            // 
            this.ctxSortBalance.Name = "ctxSortBalance";
            this.ctxSortBalance.Size = new System.Drawing.Size(134, 22);
            this.ctxSortBalance.Text = "Balance";
            // 
            // groupingToolStripMenuItem
            // 
            this.groupingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxNoGrouping,
            this.toolStripSeparator4,
            this.ctxCategoryGrouping});
            this.groupingToolStripMenuItem.Name = "groupingToolStripMenuItem";
            this.groupingToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.groupingToolStripMenuItem.Text = "Grouping";
            this.groupingToolStripMenuItem.DropDownOpening += new System.EventHandler(this.mnuGrouping_DropDownOpening);
            this.groupingToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuGrouping_DropDownItemClicked);
            // 
            // ctxNoGrouping
            // 
            this.ctxNoGrouping.Name = "ctxNoGrouping";
            this.ctxNoGrouping.Size = new System.Drawing.Size(143, 22);
            this.ctxNoGrouping.Text = "No Grouping";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(140, 6);
            // 
            // ctxCategoryGrouping
            // 
            this.ctxCategoryGrouping.Name = "ctxCategoryGrouping";
            this.ctxCategoryGrouping.Size = new System.Drawing.Size(143, 22);
            this.ctxCategoryGrouping.Text = "By Category";
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(800, 450);
            this.loader.TabIndex = 2;
            this.loader.Visible = false;
            // 
            // frmAccountExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treAccounts);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.loader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAccountExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Explorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccountExplorer_FormClosing);
            this.Load += new System.EventHandler(this.frmAccountExplorer_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ctxAccounts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender toolStripExtender;
        private System.Windows.Forms.ToolStripButton cmdClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TreeView treAccounts;
        private System.Windows.Forms.ToolStripDropDownButton mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuViewAccountNumber;
        private System.Windows.Forms.ToolStripMenuItem mnuViewDescription;
        private System.Windows.Forms.ToolStripMenuItem mnuViewCategory;
        private System.Windows.Forms.ToolStripMenuItem mnuViewBalance;
        private System.Windows.Forms.ToolStripDropDownButton mnuSort;
        private System.Windows.Forms.ToolStripMenuItem mnuSortDescription;
        private System.Windows.Forms.ToolStripMenuItem mnuSortCategory;
        private System.Windows.Forms.ToolStripMenuItem mnuSortBalance;
        private System.Windows.Forms.ToolStripDropDownButton mnuGrouping;
        private System.Windows.Forms.ToolStripMenuItem mnuGroupNone;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuGroupCategory;
        private Loader loader;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton mnuCreateAccount;
        private System.Windows.Forms.ToolStripButton mnuCloseAccount;
        private System.Windows.Forms.ContextMenuStrip ctxAccounts;
        private System.Windows.Forms.ToolStripMenuItem ctxCreate;
        private System.Windows.Forms.ToolStripMenuItem ctxClose;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctxViewAccountNumber;
        private System.Windows.Forms.ToolStripMenuItem ctxViewDescription;
        private System.Windows.Forms.ToolStripMenuItem ctxViewCategory;
        private System.Windows.Forms.ToolStripMenuItem ctxViewBalance;
        private System.Windows.Forms.ToolStripMenuItem ctxSort;
        private System.Windows.Forms.ToolStripMenuItem ctxSortDescription;
        private System.Windows.Forms.ToolStripMenuItem ctxSortCategory;
        private System.Windows.Forms.ToolStripMenuItem ctxSortBalance;
        private System.Windows.Forms.ToolStripMenuItem groupingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctxNoGrouping;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ctxCategoryGrouping;
    }
}