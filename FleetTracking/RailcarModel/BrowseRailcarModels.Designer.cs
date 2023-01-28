namespace FleetTracking.RailcarModel
{
    partial class BrowseRailcarModels
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuAddRailcarModel = new System.Windows.Forms.ToolStripButton();
            this.mnuDeleteRailcarModel = new System.Windows.Forms.ToolStripButton();
            this.loader = new FleetTracking.Loader();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer.Size = new System.Drawing.Size(882, 345);
            this.splitContainer.SplitterDistance = 160;
            this.splitContainer.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddRailcarModel,
            this.mnuDeleteRailcarModel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(882, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuAddRailcarModel
            // 
            this.mnuAddRailcarModel.Image = global::FleetTracking.Properties.Resources.add;
            this.mnuAddRailcarModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAddRailcarModel.Name = "mnuAddRailcarModel";
            this.mnuAddRailcarModel.Size = new System.Drawing.Size(108, 35);
            this.mnuAddRailcarModel.Text = "Add Railcar Model";
            this.mnuAddRailcarModel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuAddRailcarModel.Click += new System.EventHandler(this.mnuAddRailcarModel_Click);
            // 
            // mnuDeleteRailcarModel
            // 
            this.mnuDeleteRailcarModel.Enabled = false;
            this.mnuDeleteRailcarModel.Image = global::FleetTracking.Properties.Resources.delete;
            this.mnuDeleteRailcarModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDeleteRailcarModel.Name = "mnuDeleteRailcarModel";
            this.mnuDeleteRailcarModel.Size = new System.Drawing.Size(119, 35);
            this.mnuDeleteRailcarModel.Text = "Delete Railcar Model";
            this.mnuDeleteRailcarModel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuDeleteRailcarModel.Click += new System.EventHandler(this.mnuDeleteRailcarModel_Click);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(882, 345);
            this.loader.TabIndex = 1;
            this.loader.Visible = false;
            // 
            // BrowseRailcarModels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.loader);
            this.Name = "BrowseRailcarModels";
            this.Size = new System.Drawing.Size(882, 345);
            this.Load += new System.EventHandler(this.BrowseRailcarModels_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuAddRailcarModel;
        private System.Windows.Forms.ToolStripButton mnuDeleteRailcarModel;
        private Loader loader;
    }
}
