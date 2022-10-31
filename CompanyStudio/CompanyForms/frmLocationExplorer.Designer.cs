namespace CompanyStudio.CompanyForms
{
    partial class frmLocationExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocationExplorer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAddLocation = new System.Windows.Forms.ToolStripButton();
            this.toolDeleteLocation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolUpdateEmployee = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolUpdateGovernment = new System.Windows.Forms.ToolStripButton();
            this.treLocations = new System.Windows.Forms.TreeView();
            this.loader = new CompanyStudio.Loader();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddLocation,
            this.toolDeleteLocation,
            this.toolStripSeparator1,
            this.toolUpdateEmployee,
            this.toolStripSeparator2,
            this.toolUpdateGovernment});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 23);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAddLocation
            // 
            this.toolAddLocation.Image = global::CompanyStudio.Properties.Resources.world_add;
            this.toolAddLocation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolAddLocation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddLocation.Name = "toolAddLocation";
            this.toolAddLocation.Size = new System.Drawing.Size(98, 20);
            this.toolAddLocation.Text = "Add Location";
            this.toolAddLocation.Click += new System.EventHandler(this.toolAddLocation_Click);
            // 
            // toolDeleteLocation
            // 
            this.toolDeleteLocation.Enabled = false;
            this.toolDeleteLocation.Image = global::CompanyStudio.Properties.Resources.world_delete;
            this.toolDeleteLocation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolDeleteLocation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDeleteLocation.Name = "toolDeleteLocation";
            this.toolDeleteLocation.Size = new System.Drawing.Size(109, 20);
            this.toolDeleteLocation.Text = "Delete Location";
            this.toolDeleteLocation.Click += new System.EventHandler(this.toolDeleteLocation_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolUpdateEmployee
            // 
            this.toolUpdateEmployee.Enabled = false;
            this.toolUpdateEmployee.Image = global::CompanyStudio.Properties.Resources.user_edit;
            this.toolUpdateEmployee.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolUpdateEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUpdateEmployee.Name = "toolUpdateEmployee";
            this.toolUpdateEmployee.Size = new System.Drawing.Size(125, 20);
            this.toolUpdateEmployee.Text = "Update Employees";
            this.toolUpdateEmployee.Click += new System.EventHandler(this.toolUpdateEmployee_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // toolUpdateGovernment
            // 
            this.toolUpdateGovernment.Enabled = false;
            this.toolUpdateGovernment.Image = global::CompanyStudio.Properties.Resources.house;
            this.toolUpdateGovernment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolUpdateGovernment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUpdateGovernment.Name = "toolUpdateGovernment";
            this.toolUpdateGovernment.Size = new System.Drawing.Size(133, 20);
            this.toolUpdateGovernment.Text = "Update Jurisdictions";
            this.toolUpdateGovernment.Click += new System.EventHandler(this.toolUpdateGovernment_Click);
            // 
            // treLocations
            // 
            this.treLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treLocations.Location = new System.Drawing.Point(0, 23);
            this.treLocations.Name = "treLocations";
            this.treLocations.Size = new System.Drawing.Size(800, 427);
            this.treLocations.TabIndex = 1;
            this.treLocations.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treLocations_AfterSelect);
            this.treLocations.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treLocations_NodeMouseDoubleClick);
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
            // frmLocationExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treLocations);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.loader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLocationExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Location Explorer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLocationExplorer_FormClosed);
            this.Load += new System.EventHandler(this.frmLocationExplorer_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAddLocation;
        private System.Windows.Forms.TreeView treLocations;
        private Loader loader;
        private System.Windows.Forms.ToolStripButton toolUpdateEmployee;
        private System.Windows.Forms.ToolStripButton toolUpdateGovernment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolDeleteLocation;
    }
}