
namespace CompanyStudio.Email
{
    partial class frmEmailExplorer
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Aliases");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Distribution Lists");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmailExplorer));
            this.treEmailExplorer = new System.Windows.Forms.TreeView();
            this.ctxEmailExplorer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddAlias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddDistList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddRecipient = new System.Windows.Forms.ToolStripMenuItem();
            this.separator = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteAlias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteDistList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteRecipient = new System.Windows.Forms.ToolStripMenuItem();
            this.loader = new CompanyStudio.Loader();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolAddAlias = new System.Windows.Forms.ToolStripButton();
            this.toolAddDistList = new System.Windows.Forms.ToolStripButton();
            this.visualStudioToolStripExtender = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.ctxEmailExplorer.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treEmailExplorer
            // 
            this.treEmailExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treEmailExplorer.ContextMenuStrip = this.ctxEmailExplorer;
            this.treEmailExplorer.Location = new System.Drawing.Point(0, 28);
            this.treEmailExplorer.Name = "treEmailExplorer";
            treeNode1.Name = "nodAliases";
            treeNode1.Text = "Aliases";
            treeNode2.Name = "nodDistLists";
            treeNode2.Text = "Distribution Lists";
            this.treEmailExplorer.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treEmailExplorer.Size = new System.Drawing.Size(461, 274);
            this.treEmailExplorer.TabIndex = 0;
            this.treEmailExplorer.DoubleClick += new System.EventHandler(this.treEmailExplorer_DoubleClick);
            this.treEmailExplorer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treEmailExplorer_KeyDown);
            // 
            // ctxEmailExplorer
            // 
            this.ctxEmailExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddAlias,
            this.mnuAddDistList,
            this.mnuAddRecipient,
            this.separator,
            this.mnuDeleteAlias,
            this.mnuDeleteDistList,
            this.mnuDeleteRecipient});
            this.ctxEmailExplorer.Name = "ctxEmailExplorer";
            this.ctxEmailExplorer.Size = new System.Drawing.Size(246, 142);
            this.ctxEmailExplorer.Opening += new System.ComponentModel.CancelEventHandler(this.ctxEmailExplorer_Opening);
            // 
            // mnuAddAlias
            // 
            this.mnuAddAlias.Name = "mnuAddAlias";
            this.mnuAddAlias.Size = new System.Drawing.Size(245, 22);
            this.mnuAddAlias.Text = "Add Alias";
            this.mnuAddAlias.Click += new System.EventHandler(this.mnuAddAlias_Click);
            // 
            // mnuAddDistList
            // 
            this.mnuAddDistList.Name = "mnuAddDistList";
            this.mnuAddDistList.Size = new System.Drawing.Size(245, 22);
            this.mnuAddDistList.Text = "Add Distribution List";
            this.mnuAddDistList.Click += new System.EventHandler(this.mnuAddDistList_Click);
            // 
            // mnuAddRecipient
            // 
            this.mnuAddRecipient.Name = "mnuAddRecipient";
            this.mnuAddRecipient.Size = new System.Drawing.Size(245, 22);
            this.mnuAddRecipient.Text = "Add Distribution List Recipient";
            this.mnuAddRecipient.Click += new System.EventHandler(this.mnuAddRecipient_Click);
            // 
            // separator
            // 
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(242, 6);
            // 
            // mnuDeleteAlias
            // 
            this.mnuDeleteAlias.Name = "mnuDeleteAlias";
            this.mnuDeleteAlias.Size = new System.Drawing.Size(245, 22);
            this.mnuDeleteAlias.Text = "Delete Alias";
            this.mnuDeleteAlias.Click += new System.EventHandler(this.mnuDeleteAlias_Click);
            // 
            // mnuDeleteDistList
            // 
            this.mnuDeleteDistList.Name = "mnuDeleteDistList";
            this.mnuDeleteDistList.Size = new System.Drawing.Size(245, 22);
            this.mnuDeleteDistList.Text = "Delete Distribution List";
            this.mnuDeleteDistList.Click += new System.EventHandler(this.mnuDeleteDistList_Click);
            // 
            // mnuDeleteRecipient
            // 
            this.mnuDeleteRecipient.Name = "mnuDeleteRecipient";
            this.mnuDeleteRecipient.Size = new System.Drawing.Size(245, 22);
            this.mnuDeleteRecipient.Text = "Delete Distribution List Recipient";
            this.mnuDeleteRecipient.Click += new System.EventHandler(this.mnuDeleteRecipient_Click);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(461, 302);
            this.loader.TabIndex = 1;
            this.loader.Visible = false;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddAlias,
            this.toolAddDistList});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(461, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolAddAlias
            // 
            this.toolAddAlias.Image = global::CompanyStudio.Properties.Resources.icn_alias;
            this.toolAddAlias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddAlias.Name = "toolAddAlias";
            this.toolAddAlias.Size = new System.Drawing.Size(77, 22);
            this.toolAddAlias.Text = "Add Alias";
            this.toolAddAlias.Click += new System.EventHandler(this.toolAddAlias_Click);
            // 
            // toolAddDistList
            // 
            this.toolAddDistList.Image = global::CompanyStudio.Properties.Resources.icn_list;
            this.toolAddDistList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddDistList.Name = "toolAddDistList";
            this.toolAddDistList.Size = new System.Drawing.Size(135, 22);
            this.toolAddDistList.Text = "Add Distribution List";
            this.toolAddDistList.Click += new System.EventHandler(this.toolAddDistList_Click);
            // 
            // visualStudioToolStripExtender
            // 
            this.visualStudioToolStripExtender.DefaultRenderer = null;
            // 
            // frmEmailExplorer
            // 
            this.ClientSize = new System.Drawing.Size(461, 302);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.treEmailExplorer);
            this.Controls.Add(this.loader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmailExplorer";
            this.Text = "Email Explorer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEmailExplorer_FormClosed);
            this.Load += new System.EventHandler(this.frmEmailExplorer_Load);
            this.Shown += new System.EventHandler(this.frmEmailExplorer_Shown);
            this.ctxEmailExplorer.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treEmailExplorer;
        private Loader loader;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolAddAlias;
        private System.Windows.Forms.ToolStripButton toolAddDistList;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender visualStudioToolStripExtender;
        private System.Windows.Forms.ContextMenuStrip ctxEmailExplorer;
        private System.Windows.Forms.ToolStripMenuItem mnuAddAlias;
        private System.Windows.Forms.ToolStripMenuItem mnuAddDistList;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRecipient;
        private System.Windows.Forms.ToolStripSeparator separator;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteAlias;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteDistList;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteRecipient;
    }
}