
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
            this.toolStripExtender = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.cmdClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.accountNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.balanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.descriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.balanceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton3 = new System.Windows.Forms.ToolStripSplitButton();
            this.noGroupingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.byCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSearch,
            this.cmdClear,
            this.toolStripSeparator1,
            this.toolStripSplitButton1,
            this.toolStripSplitButton2,
            this.toolStripSplitButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 25);
            this.txtSearch.Text = "Search...";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // toolStripExtender
            // 
            this.toolStripExtender.DefaultRenderer = null;
            // 
            // cmdClear
            // 
            this.cmdClear.Image = ((System.Drawing.Image)(resources.GetObject("cmdClear.Image")));
            this.cmdClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(54, 22);
            this.cmdClear.Text = "Clear";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountNumberToolStripMenuItem,
            this.nameToolStripMenuItem,
            this.categoryToolStripMenuItem,
            this.balanceToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(64, 22);
            this.toolStripSplitButton1.Text = "View";
            // 
            // accountNumberToolStripMenuItem
            // 
            this.accountNumberToolStripMenuItem.Name = "accountNumberToolStripMenuItem";
            this.accountNumberToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.accountNumberToolStripMenuItem.Text = "Account Number";
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nameToolStripMenuItem.Text = "Description";
            // 
            // balanceToolStripMenuItem
            // 
            this.balanceToolStripMenuItem.Name = "balanceToolStripMenuItem";
            this.balanceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.balanceToolStripMenuItem.Text = "Balance";
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.categoryToolStripMenuItem.Text = "Category";
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.descriptionToolStripMenuItem,
            this.categoryToolStripMenuItem1,
            this.balanceToolStripMenuItem1});
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(60, 22);
            this.toolStripSplitButton2.Text = "Sort";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // descriptionToolStripMenuItem
            // 
            this.descriptionToolStripMenuItem.Name = "descriptionToolStripMenuItem";
            this.descriptionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.descriptionToolStripMenuItem.Text = "Description";
            // 
            // categoryToolStripMenuItem1
            // 
            this.categoryToolStripMenuItem1.Name = "categoryToolStripMenuItem1";
            this.categoryToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.categoryToolStripMenuItem1.Text = "Category";
            // 
            // balanceToolStripMenuItem1
            // 
            this.balanceToolStripMenuItem1.Name = "balanceToolStripMenuItem1";
            this.balanceToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.balanceToolStripMenuItem1.Text = "Balance";
            // 
            // toolStripSplitButton3
            // 
            this.toolStripSplitButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noGroupingToolStripMenuItem,
            this.toolStripMenuItem1,
            this.byCategoryToolStripMenuItem});
            this.toolStripSplitButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton3.Image")));
            this.toolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton3.Name = "toolStripSplitButton3";
            this.toolStripSplitButton3.Size = new System.Drawing.Size(72, 22);
            this.toolStripSplitButton3.Text = "Group";
            // 
            // noGroupingToolStripMenuItem
            // 
            this.noGroupingToolStripMenuItem.Name = "noGroupingToolStripMenuItem";
            this.noGroupingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.noGroupingToolStripMenuItem.Text = "No Grouping";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // byCategoryToolStripMenuItem
            // 
            this.byCategoryToolStripMenuItem.Name = "byCategoryToolStripMenuItem";
            this.byCategoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.byCategoryToolStripMenuItem.Text = "By Category";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(800, 425);
            this.treeView1.TabIndex = 1;
            // 
            // frmAccountExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAccountExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Explorer";
            this.Load += new System.EventHandler(this.frmAccountExplorer_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender toolStripExtender;
        private System.Windows.Forms.ToolStripButton cmdClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem accountNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem balanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem descriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem balanceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton3;
        private System.Windows.Forms.ToolStripMenuItem noGroupingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem byCategoryToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
    }
}