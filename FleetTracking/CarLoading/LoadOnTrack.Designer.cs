namespace FleetTracking.CarLoading
{
    partial class LoadOnTrack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadOnTrack));
            this.label1 = new System.Windows.Forms.Label();
            this.cboTrack = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMassLoadDetails = new System.Windows.Forms.Label();
            this.lblRailcars = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvRailcars = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentLoad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClear = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvLoads = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolCheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolUncheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolClearLoads = new System.Windows.Forms.ToolStripButton();
            this.toolApplyLoad = new System.Windows.Forms.ToolStripButton();
            this.itemSelect = new FleetTracking.ItemSelectorInput();
            this.loader = new FleetTracking.Loader();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIndClear = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRailcars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoads)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Track:";
            // 
            // cboTrack
            // 
            this.cboTrack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTrack.FormattingEnabled = true;
            this.cboTrack.Location = new System.Drawing.Point(58, 81);
            this.cboTrack.Name = "cboTrack";
            this.cboTrack.Size = new System.Drawing.Size(674, 21);
            this.cboTrack.TabIndex = 2;
            this.cboTrack.SelectedIndexChanged += new System.EventHandler(this.cboTrack_SelectedIndexChanged);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(58, 42);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(80, 20);
            this.txtQuantity.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantity:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Item:";
            // 
            // lblMassLoadDetails
            // 
            this.lblMassLoadDetails.AutoSize = true;
            this.lblMassLoadDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMassLoadDetails.Location = new System.Drawing.Point(3, 0);
            this.lblMassLoadDetails.Name = "lblMassLoadDetails";
            this.lblMassLoadDetails.Size = new System.Drawing.Size(111, 13);
            this.lblMassLoadDetails.TabIndex = 5;
            this.lblMassLoadDetails.Text = "Mass Load Details";
            // 
            // lblRailcars
            // 
            this.lblRailcars.AutoSize = true;
            this.lblRailcars.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRailcars.Location = new System.Drawing.Point(3, 65);
            this.lblRailcars.Name = "lblRailcars";
            this.lblRailcars.Size = new System.Drawing.Size(53, 13);
            this.lblRailcars.TabIndex = 5;
            this.lblRailcars.Text = "Railcars";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Location = new System.Drawing.Point(3, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(729, 330);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvRailcars);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvLoads);
            this.splitContainer1.Size = new System.Drawing.Size(723, 286);
            this.splitContainer1.SplitterDistance = 537;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvRailcars
            // 
            this.dgvRailcars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRailcars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colReportingMark,
            this.colCurrentLoad,
            this.colClear});
            this.dgvRailcars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRailcars.Location = new System.Drawing.Point(0, 0);
            this.dgvRailcars.Name = "dgvRailcars";
            this.dgvRailcars.RowHeadersVisible = false;
            this.dgvRailcars.Size = new System.Drawing.Size(537, 286);
            this.dgvRailcars.TabIndex = 1;
            this.dgvRailcars.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRailcars_CellClick);
            this.dgvRailcars.SelectionChanged += new System.EventHandler(this.dgvRailcars_SelectionChanged);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 30;
            // 
            // colReportingMark
            // 
            this.colReportingMark.HeaderText = "Reporting Mark";
            this.colReportingMark.Name = "colReportingMark";
            this.colReportingMark.ReadOnly = true;
            this.colReportingMark.Width = 125;
            // 
            // colCurrentLoad
            // 
            this.colCurrentLoad.HeaderText = "Current Load";
            this.colCurrentLoad.Name = "colCurrentLoad";
            this.colCurrentLoad.ReadOnly = true;
            this.colCurrentLoad.Width = 300;
            // 
            // colClear
            // 
            this.colClear.HeaderText = "Clear Load";
            this.colClear.Name = "colClear";
            this.colClear.ReadOnly = true;
            this.colClear.Text = "Clear Load";
            this.colClear.UseColumnTextForButtonValue = true;
            // 
            // dgvLoads
            // 
            this.dgvLoads.AllowUserToAddRows = false;
            this.dgvLoads.AllowUserToDeleteRows = false;
            this.dgvLoads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.colItem,
            this.colQuantity,
            this.colIndClear});
            this.dgvLoads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoads.Location = new System.Drawing.Point(0, 0);
            this.dgvLoads.Name = "dgvLoads";
            this.dgvLoads.RowHeadersVisible = false;
            this.dgvLoads.Size = new System.Drawing.Size(182, 286);
            this.dgvLoads.TabIndex = 0;
            this.dgvLoads.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoads_CellClick);
            this.dgvLoads.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoads_CellValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCheckAll,
            this.toolUncheckAll,
            this.toolStripSeparator1,
            this.toolClearLoads,
            this.toolApplyLoad});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(723, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolCheckAll
            // 
            this.toolCheckAll.Image = global::FleetTracking.Properties.Resources.checkall;
            this.toolCheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCheckAll.Name = "toolCheckAll";
            this.toolCheckAll.Size = new System.Drawing.Size(77, 22);
            this.toolCheckAll.Text = "Check All";
            this.toolCheckAll.Click += new System.EventHandler(this.toolCheckAll_Click);
            // 
            // toolUncheckAll
            // 
            this.toolUncheckAll.Image = global::FleetTracking.Properties.Resources.uncheckall;
            this.toolUncheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUncheckAll.Name = "toolUncheckAll";
            this.toolUncheckAll.Size = new System.Drawing.Size(90, 22);
            this.toolUncheckAll.Text = "Uncheck All";
            this.toolUncheckAll.Click += new System.EventHandler(this.toolUncheckAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolClearLoads
            // 
            this.toolClearLoads.Image = ((System.Drawing.Image)(resources.GetObject("toolClearLoads.Image")));
            this.toolClearLoads.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClearLoads.Name = "toolClearLoads";
            this.toolClearLoads.Size = new System.Drawing.Size(88, 22);
            this.toolClearLoads.Text = "Clear Loads";
            this.toolClearLoads.Click += new System.EventHandler(this.toolClearLoads_Click);
            // 
            // toolApplyLoad
            // 
            this.toolApplyLoad.Image = ((System.Drawing.Image)(resources.GetObject("toolApplyLoad.Image")));
            this.toolApplyLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolApplyLoad.Name = "toolApplyLoad";
            this.toolApplyLoad.Size = new System.Drawing.Size(87, 22);
            this.toolApplyLoad.Text = "Apply Load";
            this.toolApplyLoad.Click += new System.EventHandler(this.toolApplyLoad_Click);
            // 
            // itemSelect
            // 
            this.itemSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemSelect.Location = new System.Drawing.Point(58, 16);
            this.itemSelect.Name = "itemSelect";
            this.itemSelect.SelectedID = null;
            this.itemSelect.Size = new System.Drawing.Size(674, 20);
            this.itemSelect.TabIndex = 0;
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(741, 440);
            this.loader.TabIndex = 6;
            this.loader.Visible = false;
            // 
            // colImage
            // 
            this.colImage.HeaderText = "Img";
            this.colImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            this.colImage.Width = 34;
            // 
            // colItem
            // 
            this.colItem.HeaderText = "Item";
            this.colItem.Name = "colItem";
            this.colItem.ReadOnly = true;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Qty";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Width = 40;
            // 
            // colIndClear
            // 
            this.colIndClear.HeaderText = "Clear";
            this.colIndClear.Name = "colIndClear";
            this.colIndClear.ReadOnly = true;
            this.colIndClear.Text = "Clear";
            this.colIndClear.UseColumnTextForButtonValue = true;
            this.colIndClear.Width = 70;
            // 
            // LoadOnTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.itemSelect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblRailcars);
            this.Controls.Add(this.lblMassLoadDetails);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTrack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loader);
            this.Name = "LoadOnTrack";
            this.Size = new System.Drawing.Size(741, 440);
            this.Load += new System.EventHandler(this.LoadOnTrack_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LoadOnTrack_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRailcars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoads)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTrack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label3;
        private ItemSelectorInput itemSelect;
        private System.Windows.Forms.Label lblMassLoadDetails;
        private System.Windows.Forms.Label lblRailcars;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolCheckAll;
        private System.Windows.Forms.ToolStripButton toolUncheckAll;
        private System.Windows.Forms.DataGridView dgvRailcars;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolClearLoads;
        private System.Windows.Forms.ToolStripButton toolApplyLoad;
        private Loader loader;
        private DataGridViewStylizer dataGridViewStylizer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentLoad;
        private System.Windows.Forms.DataGridViewButtonColumn colClear;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvLoads;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn colIndClear;
    }
}
