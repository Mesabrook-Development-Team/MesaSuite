namespace SystemManagement
{
    partial class frmItemManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemManager));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.chkNamespaces = new System.Windows.Forms.CheckedListBox();
            this.ctxNamespace = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditNamespace = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteNamespace = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lstItems = new System.Windows.Forms.ListView();
            this.ctxItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAddNamespace = new System.Windows.Forms.ToolStripButton();
            this.toolAddItem = new System.Windows.Forms.ToolStripButton();
            this.toolImportItems = new System.Windows.Forms.ToolStripButton();
            this.loader = new SystemManagement.Loader();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.ctxNamespace.SuspendLayout();
            this.ctxItem.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.chkNamespaces);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lstItems);
            this.splitContainer.Size = new System.Drawing.Size(704, 318);
            this.splitContainer.SplitterDistance = 186;
            this.splitContainer.TabIndex = 0;
            // 
            // chkNamespaces
            // 
            this.chkNamespaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNamespaces.ContextMenuStrip = this.ctxNamespace;
            this.chkNamespaces.FormattingEnabled = true;
            this.chkNamespaces.Location = new System.Drawing.Point(3, 25);
            this.chkNamespaces.Name = "chkNamespaces";
            this.chkNamespaces.Size = new System.Drawing.Size(180, 289);
            this.chkNamespaces.TabIndex = 1;
            this.chkNamespaces.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkNamespaces_ItemCheck);
            // 
            // ctxNamespace
            // 
            this.ctxNamespace.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditNamespace,
            this.mnuDeleteNamespace});
            this.ctxNamespace.Name = "ctxNamespace";
            this.ctxNamespace.Size = new System.Drawing.Size(173, 48);
            this.ctxNamespace.Opening += new System.ComponentModel.CancelEventHandler(this.ctxNamespace_Opening);
            // 
            // mnuEditNamespace
            // 
            this.mnuEditNamespace.Name = "mnuEditNamespace";
            this.mnuEditNamespace.Size = new System.Drawing.Size(172, 22);
            this.mnuEditNamespace.Text = "Edit Namespace";
            this.mnuEditNamespace.Click += new System.EventHandler(this.mnuEditNamespace_Click);
            // 
            // mnuDeleteNamespace
            // 
            this.mnuDeleteNamespace.Name = "mnuDeleteNamespace";
            this.mnuDeleteNamespace.Size = new System.Drawing.Size(172, 22);
            this.mnuDeleteNamespace.Text = "Delete Namespace";
            this.mnuDeleteNamespace.Click += new System.EventHandler(this.mnuDeleteNamespace_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Namespaces:";
            // 
            // lstItems
            // 
            this.lstItems.ContextMenuStrip = this.ctxItem;
            this.lstItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstItems.HideSelection = false;
            this.lstItems.LargeImageList = this.imageList;
            this.lstItems.Location = new System.Drawing.Point(0, 0);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(514, 318);
            this.lstItems.SmallImageList = this.imageList;
            this.lstItems.TabIndex = 0;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstItems_MouseDoubleClick);
            // 
            // ctxItem
            // 
            this.ctxItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditItem,
            this.mnuDeleteItem});
            this.ctxItem.Name = "ctxNamespace";
            this.ctxItem.Size = new System.Drawing.Size(135, 48);
            this.ctxItem.Opening += new System.ComponentModel.CancelEventHandler(this.ctxItem_Opening);
            // 
            // mnuEditItem
            // 
            this.mnuEditItem.Name = "mnuEditItem";
            this.mnuEditItem.Size = new System.Drawing.Size(134, 22);
            this.mnuEditItem.Text = "Edit Item";
            this.mnuEditItem.Click += new System.EventHandler(this.mnuEditItem_Click);
            // 
            // mnuDeleteItem
            // 
            this.mnuDeleteItem.Name = "mnuDeleteItem";
            this.mnuDeleteItem.Size = new System.Drawing.Size(134, 22);
            this.mnuDeleteItem.Text = "Delete Item";
            this.mnuDeleteItem.Click += new System.EventHandler(this.mnuDeleteItem_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtSearch,
            this.toolStripSeparator1,
            this.toolAddNamespace,
            this.toolAddItem,
            this.toolImportItems});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(704, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel1.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 25);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAddNamespace
            // 
            this.toolAddNamespace.Image = global::SystemManagement.Properties.Resources.asterisk_orange;
            this.toolAddNamespace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddNamespace.Name = "toolAddNamespace";
            this.toolAddNamespace.Size = new System.Drawing.Size(114, 22);
            this.toolAddNamespace.Text = "Add Namespace";
            this.toolAddNamespace.Click += new System.EventHandler(this.toolAddNamespace_Click);
            // 
            // toolAddItem
            // 
            this.toolAddItem.Image = global::SystemManagement.Properties.Resources._new;
            this.toolAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddItem.Name = "toolAddItem";
            this.toolAddItem.Size = new System.Drawing.Size(76, 22);
            this.toolAddItem.Text = "Add Item";
            this.toolAddItem.Click += new System.EventHandler(this.toolAddItem_Click);
            // 
            // toolImportItems
            // 
            this.toolImportItems.Image = global::SystemManagement.Properties.Resources.folder_add;
            this.toolImportItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolImportItems.Name = "toolImportItems";
            this.toolImportItems.Size = new System.Drawing.Size(95, 22);
            this.toolImportItems.Text = "Import Items";
            this.toolImportItems.Click += new System.EventHandler(this.toolImportItems_Click);
            // 
            // loader
            // 
            this.loader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(254, 121);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(196, 101);
            this.loader.TabIndex = 2;
            // 
            // frmItemManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 343);
            this.Controls.Add(this.loader);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmItemManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Manager";
            this.Load += new System.EventHandler(this.frmItemManager_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ctxNamespace.ResumeLayout(false);
            this.ctxItem.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.CheckedListBox chkNamespaces;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstItems;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolAddItem;
        private System.Windows.Forms.ToolStripButton toolImportItems;
        private Loader loader;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripButton toolAddNamespace;
        private System.Windows.Forms.ContextMenuStrip ctxNamespace;
        private System.Windows.Forms.ToolStripMenuItem mnuEditNamespace;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteNamespace;
        private System.Windows.Forms.ContextMenuStrip ctxItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEditItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteItem;
    }
}