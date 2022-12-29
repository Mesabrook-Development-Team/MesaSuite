namespace FleetTracking.Rates
{
    partial class CarHandlingRateList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarHandlingRateList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.dgvRates = new System.Windows.Forms.DataGridView();
            this.loader = new FleetTracking.Loader();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            this.colEffectiveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIntraDistrictRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInterDistrictRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlacementRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAdd,
            this.toolDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(611, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAdd
            // 
            this.toolAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolAdd.Image")));
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(59, 35);
            this.toolAdd.Text = "Add Rate";
            this.toolAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(70, 35);
            this.toolDelete.Text = "Delete Rate";
            this.toolDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // dgvRates
            // 
            this.dgvRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEffectiveTime,
            this.colIntraDistrictRate,
            this.colInterDistrictRate,
            this.colPlacementRate});
            this.dgvRates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRates.Location = new System.Drawing.Point(0, 38);
            this.dgvRates.Name = "dgvRates";
            this.dgvRates.Size = new System.Drawing.Size(611, 245);
            this.dgvRates.TabIndex = 1;
            this.dgvRates.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRates_CellDoubleClick);
            this.dgvRates.SelectionChanged += new System.EventHandler(this.dgvRates_SelectionChanged);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(611, 283);
            this.loader.TabIndex = 2;
            this.loader.Visible = false;
            // 
            // colEffectiveTime
            // 
            this.colEffectiveTime.HeaderText = "EffectiveTime";
            this.colEffectiveTime.Name = "colEffectiveTime";
            this.colEffectiveTime.Width = 150;
            // 
            // colIntraDistrictRate
            // 
            this.colIntraDistrictRate.HeaderText = "Intradistrict Rate";
            this.colIntraDistrictRate.Name = "colIntraDistrictRate";
            this.colIntraDistrictRate.Width = 150;
            // 
            // colInterDistrictRate
            // 
            this.colInterDistrictRate.HeaderText = "Interdistrict Rate";
            this.colInterDistrictRate.Name = "colInterDistrictRate";
            this.colInterDistrictRate.Width = 150;
            // 
            // colPlacementRate
            // 
            this.colPlacementRate.HeaderText = "Placement Rate";
            this.colPlacementRate.Name = "colPlacementRate";
            this.colPlacementRate.Width = 150;
            // 
            // CarHandlingRateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvRates);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.loader);
            this.Name = "CarHandlingRateList";
            this.Size = new System.Drawing.Size(611, 283);
            this.Load += new System.EventHandler(this.CarHandlingRateList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridViewStylizer dataGridViewStylizer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.DataGridView dgvRates;
        private Loader loader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEffectiveTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIntraDistrictRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInterDistrictRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlacementRate;
    }
}
