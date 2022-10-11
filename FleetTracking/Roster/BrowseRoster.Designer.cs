namespace FleetTracking.Roster
{
    partial class BrowseRoster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowseRoster));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAll = new System.Windows.Forms.TabPage();
            this.tabOnProperty = new System.Windows.Forms.TabPage();
            this.tabOwned = new System.Windows.Forms.TabPage();
            this.tabLeased = new System.Windows.Forms.TabPage();
            this.toolStripStock = new System.Windows.Forms.ToolStrip();
            this.mnuAddLocomotive = new System.Windows.Forms.ToolStripButton();
            this.mnuDeleteLocomotive = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAddRailcar = new System.Windows.Forms.ToolStripButton();
            this.mnuDeleteRailcar = new System.Windows.Forms.ToolStripButton();
            this.loader = new FleetTracking.Loader();
            this.tabPossessed = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.toolStripStock.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 38);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(1071, 517);
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabAll);
            this.tabControl.Controls.Add(this.tabOnProperty);
            this.tabControl.Controls.Add(this.tabPossessed);
            this.tabControl.Controls.Add(this.tabOwned);
            this.tabControl.Controls.Add(this.tabLeased);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1071, 265);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabAll
            // 
            this.tabAll.Location = new System.Drawing.Point(4, 22);
            this.tabAll.Name = "tabAll";
            this.tabAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabAll.Size = new System.Drawing.Size(1063, 239);
            this.tabAll.TabIndex = 0;
            this.tabAll.Text = "System Wide";
            this.tabAll.UseVisualStyleBackColor = true;
            // 
            // tabOnProperty
            // 
            this.tabOnProperty.Location = new System.Drawing.Point(4, 22);
            this.tabOnProperty.Name = "tabOnProperty";
            this.tabOnProperty.Size = new System.Drawing.Size(1063, 239);
            this.tabOnProperty.TabIndex = 3;
            this.tabOnProperty.Text = "On Property";
            this.tabOnProperty.UseVisualStyleBackColor = true;
            // 
            // tabOwned
            // 
            this.tabOwned.Location = new System.Drawing.Point(4, 22);
            this.tabOwned.Name = "tabOwned";
            this.tabOwned.Padding = new System.Windows.Forms.Padding(3);
            this.tabOwned.Size = new System.Drawing.Size(1063, 239);
            this.tabOwned.TabIndex = 1;
            this.tabOwned.Text = "Owned";
            this.tabOwned.UseVisualStyleBackColor = true;
            // 
            // tabLeased
            // 
            this.tabLeased.Location = new System.Drawing.Point(4, 22);
            this.tabLeased.Name = "tabLeased";
            this.tabLeased.Size = new System.Drawing.Size(1063, 239);
            this.tabLeased.TabIndex = 2;
            this.tabLeased.Text = "Leased";
            this.tabLeased.UseVisualStyleBackColor = true;
            // 
            // toolStripStock
            // 
            this.toolStripStock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddLocomotive,
            this.mnuDeleteLocomotive,
            this.toolStripSeparator1,
            this.mnuAddRailcar,
            this.mnuDeleteRailcar});
            this.toolStripStock.Location = new System.Drawing.Point(0, 0);
            this.toolStripStock.Name = "toolStripStock";
            this.toolStripStock.Size = new System.Drawing.Size(1071, 38);
            this.toolStripStock.TabIndex = 0;
            this.toolStripStock.Text = "toolStrip1";
            // 
            // mnuAddLocomotive
            // 
            this.mnuAddLocomotive.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddLocomotive.Image")));
            this.mnuAddLocomotive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAddLocomotive.Name = "mnuAddLocomotive";
            this.mnuAddLocomotive.Size = new System.Drawing.Size(99, 35);
            this.mnuAddLocomotive.Text = "Add Locomotive";
            this.mnuAddLocomotive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuAddLocomotive.Click += new System.EventHandler(this.mnuAddLocomotive_Click);
            // 
            // mnuDeleteLocomotive
            // 
            this.mnuDeleteLocomotive.Enabled = false;
            this.mnuDeleteLocomotive.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteLocomotive.Image")));
            this.mnuDeleteLocomotive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDeleteLocomotive.Name = "mnuDeleteLocomotive";
            this.mnuDeleteLocomotive.Size = new System.Drawing.Size(123, 35);
            this.mnuDeleteLocomotive.Text = "Delete Locomotive(s)";
            this.mnuDeleteLocomotive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuDeleteLocomotive.Click += new System.EventHandler(this.mnuDeleteLocomotive_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // mnuAddRailcar
            // 
            this.mnuAddRailcar.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddRailcar.Image")));
            this.mnuAddRailcar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAddRailcar.Name = "mnuAddRailcar";
            this.mnuAddRailcar.Size = new System.Drawing.Size(71, 35);
            this.mnuAddRailcar.Text = "Add Railcar";
            this.mnuAddRailcar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuAddRailcar.Click += new System.EventHandler(this.mnuAddRailcar_Click);
            // 
            // mnuDeleteRailcar
            // 
            this.mnuDeleteRailcar.Enabled = false;
            this.mnuDeleteRailcar.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteRailcar.Image")));
            this.mnuDeleteRailcar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDeleteRailcar.Name = "mnuDeleteRailcar";
            this.mnuDeleteRailcar.Size = new System.Drawing.Size(95, 35);
            this.mnuDeleteRailcar.Text = "Delete Railcar(s)";
            this.mnuDeleteRailcar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuDeleteRailcar.Click += new System.EventHandler(this.mnuDeleteRailcar_Click);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(1071, 555);
            this.loader.TabIndex = 1;
            this.loader.Visible = false;
            // 
            // tabPossessed
            // 
            this.tabPossessed.Location = new System.Drawing.Point(4, 22);
            this.tabPossessed.Name = "tabPossessed";
            this.tabPossessed.Size = new System.Drawing.Size(1063, 239);
            this.tabPossessed.TabIndex = 4;
            this.tabPossessed.Text = "In Possession";
            this.tabPossessed.UseVisualStyleBackColor = true;
            // 
            // BrowseRoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripStock);
            this.Controls.Add(this.loader);
            this.Name = "BrowseRoster";
            this.Size = new System.Drawing.Size(1071, 555);
            this.Load += new System.EventHandler(this.BrowseRoster_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.toolStripStock.ResumeLayout(false);
            this.toolStripStock.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAll;
        private System.Windows.Forms.TabPage tabOwned;
        private System.Windows.Forms.TabPage tabLeased;
        private System.Windows.Forms.ToolStrip toolStripStock;
        private System.Windows.Forms.ToolStripButton mnuAddLocomotive;
        private System.Windows.Forms.ToolStripButton mnuDeleteLocomotive;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuAddRailcar;
        private System.Windows.Forms.ToolStripButton mnuDeleteRailcar;
        private Loader loader;
        private System.Windows.Forms.TabPage tabOnProperty;
        private System.Windows.Forms.TabPage tabPossessed;
    }
}
