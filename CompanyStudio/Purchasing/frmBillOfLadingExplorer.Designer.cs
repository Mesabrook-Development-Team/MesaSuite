namespace CompanyStudio.Purchasing
{
    partial class frmBillOfLadingExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBillOfLadingExplorer));
            this.treBOLs = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.loader = new CompanyStudio.Loader();
            this.SuspendLayout();
            // 
            // treBOLs
            // 
            this.treBOLs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treBOLs.ImageIndex = 0;
            this.treBOLs.ImageList = this.imageList;
            this.treBOLs.Location = new System.Drawing.Point(0, 0);
            this.treBOLs.Name = "treBOLs";
            this.treBOLs.SelectedImageIndex = 0;
            this.treBOLs.ShowNodeToolTips = true;
            this.treBOLs.Size = new System.Drawing.Size(514, 501);
            this.treBOLs.TabIndex = 0;
            this.treBOLs.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treBOLs_NodeMouseDoubleClick);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // loader
            // 
            this.loader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(159, 200);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(196, 101);
            this.loader.TabIndex = 1;
            this.loader.Visible = false;
            // 
            // frmBillOfLadingExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 501);
            this.Controls.Add(this.loader);
            this.Controls.Add(this.treBOLs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBillOfLadingExplorer";
            this.Text = "Bill Of Lading Explorer";
            this.Load += new System.EventHandler(this.frmBillOfLadingExplorer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treBOLs;
        private System.Windows.Forms.ImageList imageList;
        private Loader loader;
    }
}