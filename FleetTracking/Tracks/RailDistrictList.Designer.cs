namespace FleetTracking.Tracks
{
    partial class RailDistrictList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RailDistrictList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dgvDistricts = new System.Windows.Forms.DataGridView();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            this.loader = new FleetTracking.Loader();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolAddDistrict = new System.Windows.Forms.ToolStripButton();
            this.toolDeleteDistricts = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistricts)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddDistrict,
            this.toolDeleteDistricts});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(618, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // dgvDistricts
            // 
            this.dgvDistricts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDistricts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colOperator});
            this.dgvDistricts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDistricts.Location = new System.Drawing.Point(0, 38);
            this.dgvDistricts.Name = "dgvDistricts";
            this.dgvDistricts.Size = new System.Drawing.Size(618, 324);
            this.dgvDistricts.TabIndex = 1;
            this.dgvDistricts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDistricts_CellDoubleClick);
            this.dgvDistricts.SelectionChanged += new System.EventHandler(this.dgvDistricts_SelectionChanged);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(618, 362);
            this.loader.TabIndex = 2;
            this.loader.Visible = false;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 200;
            // 
            // colOperator
            // 
            this.colOperator.HeaderText = "Operator";
            this.colOperator.Name = "colOperator";
            this.colOperator.Width = 200;
            // 
            // toolAddDistrict
            // 
            this.toolAddDistrict.Image = ((System.Drawing.Image)(resources.GetObject("toolAddDistrict.Image")));
            this.toolAddDistrict.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddDistrict.Name = "toolAddDistrict";
            this.toolAddDistrict.Size = new System.Drawing.Size(73, 35);
            this.toolAddDistrict.Text = "Add District";
            this.toolAddDistrict.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolAddDistrict.Click += new System.EventHandler(this.toolAddDistrict_Click);
            // 
            // toolDeleteDistricts
            // 
            this.toolDeleteDistricts.Enabled = false;
            this.toolDeleteDistricts.Image = ((System.Drawing.Image)(resources.GetObject("toolDeleteDistricts.Image")));
            this.toolDeleteDistricts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDeleteDistricts.Name = "toolDeleteDistricts";
            this.toolDeleteDistricts.Size = new System.Drawing.Size(97, 35);
            this.toolDeleteDistricts.Text = "Delete District(s)";
            this.toolDeleteDistricts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolDeleteDistricts.Click += new System.EventHandler(this.toolDeleteDistricts_Click);
            // 
            // RailDistrictList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDistricts);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.loader);
            this.Name = "RailDistrictList";
            this.Size = new System.Drawing.Size(618, 362);
            this.Load += new System.EventHandler(this.RailDistrictList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistricts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAddDistrict;
        private System.Windows.Forms.ToolStripButton toolDeleteDistricts;
        private System.Windows.Forms.DataGridView dgvDistricts;
        private DataGridViewStylizer dataGridViewStylizer;
        private Loader loader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperator;
    }
}
