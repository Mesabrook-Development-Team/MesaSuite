namespace CompanyStudio.Purchasing.DraftEntry
{
    partial class frmSelectFulfillmentPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectFulfillmentPlan));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvFulfillmentPlans = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRailcar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.loader = new CompanyStudio.Loader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolCheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolUncheckAll = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFulfillmentPlans)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Fulfillment Plans that this Purchase Order Line will apply to:";
            // 
            // dgvFulfillmentPlans
            // 
            this.dgvFulfillmentPlans.AllowUserToAddRows = false;
            this.dgvFulfillmentPlans.AllowUserToDeleteRows = false;
            this.dgvFulfillmentPlans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFulfillmentPlans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colRailcar,
            this.colRoute});
            this.dgvFulfillmentPlans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFulfillmentPlans.Location = new System.Drawing.Point(3, 41);
            this.dgvFulfillmentPlans.MultiSelect = false;
            this.dgvFulfillmentPlans.Name = "dgvFulfillmentPlans";
            this.dgvFulfillmentPlans.RowHeadersVisible = false;
            this.dgvFulfillmentPlans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFulfillmentPlans.Size = new System.Drawing.Size(470, 172);
            this.dgvFulfillmentPlans.TabIndex = 1;
            // 
            // colSelect
            // 
            this.colSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colSelect.HeaderText = "Select";
            this.colSelect.Name = "colSelect";
            this.colSelect.Width = 43;
            // 
            // colRailcar
            // 
            this.colRailcar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRailcar.HeaderText = "Railcar";
            this.colRailcar.MinimumWidth = 100;
            this.colRailcar.Name = "colRailcar";
            this.colRailcar.ReadOnly = true;
            // 
            // colRoute
            // 
            this.colRoute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRoute.HeaderText = "Route";
            this.colRoute.MinimumWidth = 100;
            this.colRoute.Name = "colRoute";
            this.colRoute.ReadOnly = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(413, 247);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(332, 247);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // loader
            // 
            this.loader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(152, 88);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(196, 101);
            this.loader.TabIndex = 3;
            this.loader.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvFulfillmentPlans);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCheckAll,
            this.toolUncheckAll});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(470, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolCheckAll
            // 
            this.toolCheckAll.Image = global::CompanyStudio.Properties.Resources.checkall;
            this.toolCheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCheckAll.Name = "toolCheckAll";
            this.toolCheckAll.Size = new System.Drawing.Size(75, 22);
            this.toolCheckAll.Text = "Select All";
            this.toolCheckAll.Click += new System.EventHandler(this.toolCheckAll_Click);
            // 
            // toolUncheckAll
            // 
            this.toolUncheckAll.Image = global::CompanyStudio.Properties.Resources.uncheckall;
            this.toolUncheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUncheckAll.Name = "toolUncheckAll";
            this.toolUncheckAll.Size = new System.Drawing.Size(89, 22);
            this.toolUncheckAll.Text = "Unselect All";
            this.toolUncheckAll.Click += new System.EventHandler(this.toolUncheckAll_Click);
            // 
            // frmSelectFulfillmentPlan
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(500, 277);
            this.Controls.Add(this.loader);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSelectFulfillmentPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Fulfillment Plans";
            this.Load += new System.EventHandler(this.frmSelectFulfillmentPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFulfillmentPlans)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvFulfillmentPlans;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRailcar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoute;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private Loader loader;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolCheckAll;
        private System.Windows.Forms.ToolStripButton toolUncheckAll;
    }
}