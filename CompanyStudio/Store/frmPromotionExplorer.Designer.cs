namespace CompanyStudio.Store
{
    partial class frmPromotionExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPromotionExplorer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuAddPromo = new System.Windows.Forms.ToolStripButton();
            this.mnuDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dgvPromotions = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductsAffected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.mnuShowActive = new System.Windows.Forms.ToolStripButton();
            this.mnuShowHistorical = new System.Windows.Forms.ToolStripButton();
            this.loader = new CompanyStudio.Loader();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotions)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddPromo,
            this.mnuDelete,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(429, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuAddPromo
            // 
            this.mnuAddPromo.Image = global::CompanyStudio.Properties.Resources.add;
            this.mnuAddPromo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuAddPromo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAddPromo.Name = "mnuAddPromo";
            this.mnuAddPromo.Size = new System.Drawing.Size(97, 22);
            this.mnuAddPromo.Text = "Add Promotion";
            this.mnuAddPromo.Click += new System.EventHandler(this.mnuAddPromo_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Enabled = false;
            this.mnuDelete.Image = global::CompanyStudio.Properties.Resources.delete;
            this.mnuDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(109, 22);
            this.mnuDelete.Text = "Delete Promotion";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // dgvPromotions
            // 
            this.dgvPromotions.AllowUserToAddRows = false;
            this.dgvPromotions.AllowUserToDeleteRows = false;
            this.dgvPromotions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPromotions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPromotions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromotions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colStartDate,
            this.colEndTime,
            this.colProductsAffected});
            this.dgvPromotions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPromotions.Location = new System.Drawing.Point(0, 50);
            this.dgvPromotions.Name = "dgvPromotions";
            this.dgvPromotions.ReadOnly = true;
            this.dgvPromotions.RowHeadersVisible = false;
            this.dgvPromotions.RowTemplate.Height = 15;
            this.dgvPromotions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPromotions.Size = new System.Drawing.Size(429, 400);
            this.dgvPromotions.TabIndex = 1;
            this.dgvPromotions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPromotions_CellDoubleClick);
            this.dgvPromotions.SelectionChanged += new System.EventHandler(this.dgvPromotions_SelectionChanged);
            // 
            // colName
            // 
            this.colName.HeaderText = "Promotion Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
            // 
            // colStartDate
            // 
            this.colStartDate.HeaderText = "Start Time";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.ReadOnly = true;
            // 
            // colEndTime
            // 
            this.colEndTime.HeaderText = "End Time";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.ReadOnly = true;
            // 
            // colProductsAffected
            // 
            this.colProductsAffected.HeaderText = "Products Affected";
            this.colProductsAffected.Name = "colProductsAffected";
            this.colProductsAffected.ReadOnly = true;
            this.colProductsAffected.Width = 150;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowActive,
            this.mnuShowHistorical});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(429, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // mnuShowActive
            // 
            this.mnuShowActive.Checked = true;
            this.mnuShowActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuShowActive.Image = global::CompanyStudio.Properties.Resources.tick;
            this.mnuShowActive.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuShowActive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuShowActive.Name = "mnuShowActive";
            this.mnuShowActive.Size = new System.Drawing.Size(86, 22);
            this.mnuShowActive.Text = "Show Active";
            this.mnuShowActive.Click += new System.EventHandler(this.mnuShowActive_Click);
            // 
            // mnuShowHistorical
            // 
            this.mnuShowHistorical.Image = global::CompanyStudio.Properties.Resources.clock;
            this.mnuShowHistorical.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuShowHistorical.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuShowHistorical.Name = "mnuShowHistorical";
            this.mnuShowHistorical.Size = new System.Drawing.Size(99, 22);
            this.mnuShowHistorical.Text = "Show Historical";
            this.mnuShowHistorical.Click += new System.EventHandler(this.mnuShowHistorical_Click);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(429, 450);
            this.loader.TabIndex = 3;
            this.loader.Visible = false;
            // 
            // frmPromotionExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 450);
            this.Controls.Add(this.dgvPromotions);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.loader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPromotionExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promotion Explorer";
            this.Load += new System.EventHandler(this.frmPromotionExplorer_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotions)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuAddPromo;
        private System.Windows.Forms.ToolStripButton mnuDelete;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridView dgvPromotions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductsAffected;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton mnuShowActive;
        private System.Windows.Forms.ToolStripButton mnuShowHistorical;
        private Loader loader;
    }
}