namespace CompanyStudio.Store
{
    partial class frmRegisters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegisters));
            this.lstRegisters = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolOnline = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOffline = new System.Windows.Forms.ToolStripMenuItem();
            this.loader = new CompanyStudio.Loader();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstRegisters
            // 
            this.lstRegisters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstRegisters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRegisters.HideSelection = false;
            this.lstRegisters.LargeImageList = this.imageList;
            this.lstRegisters.Location = new System.Drawing.Point(0, 25);
            this.lstRegisters.Name = "lstRegisters";
            this.lstRegisters.Size = new System.Drawing.Size(800, 425);
            this.lstRegisters.SmallImageList = this.imageList;
            this.lstRegisters.TabIndex = 0;
            this.lstRegisters.UseCompatibleStateImageBehavior = false;
            this.lstRegisters.View = System.Windows.Forms.View.Tile;
            this.lstRegisters.DoubleClick += new System.EventHandler(this.lstRegisters_DoubleClick);
            this.lstRegisters.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstRegisters_KeyUp);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(64, 64);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAdd,
            this.toolDelete,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAdd
            // 
            this.toolAdd.Image = global::CompanyStudio.Properties.Resources.add;
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(94, 22);
            this.toolAdd.Text = "Add Register";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = global::CompanyStudio.Properties.Resources.delete;
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(105, 22);
            this.toolDelete.Text = "Delete Register";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOnline,
            this.toolOffline});
            this.toolStripDropDownButton1.Image = global::CompanyStudio.Properties.Resources.cog;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(112, 22);
            this.toolStripDropDownButton1.Text = "Status Change";
            // 
            // toolOnline
            // 
            this.toolOnline.Image = global::CompanyStudio.Properties.Resources.accept;
            this.toolOnline.Name = "toolOnline";
            this.toolOnline.Size = new System.Drawing.Size(180, 22);
            this.toolOnline.Text = "Bring Online";
            this.toolOnline.Click += new System.EventHandler(this.toolOnline_Click);
            // 
            // toolOffline
            // 
            this.toolOffline.Image = global::CompanyStudio.Properties.Resources.stop;
            this.toolOffline.Name = "toolOffline";
            this.toolOffline.Size = new System.Drawing.Size(180, 22);
            this.toolOffline.Text = "Take Offline";
            this.toolOffline.Click += new System.EventHandler(this.toolOffline_Click);
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
            // frmRegisters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstRegisters);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.loader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRegisters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registers";
            this.Load += new System.EventHandler(this.frmRegisters_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstRegisters;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolOnline;
        private System.Windows.Forms.ToolStripMenuItem toolOffline;
        private Loader loader;
    }
}