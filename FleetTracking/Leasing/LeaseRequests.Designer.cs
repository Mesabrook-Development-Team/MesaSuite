namespace FleetTracking.Leasing
{
    partial class LeaseRequests
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeaseRequests));
            this.rdoRequestsFromOthers = new System.Windows.Forms.RadioButton();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.colLeaseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeaseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBidPlaced = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPurpose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdoFilterMyRequests = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoFilterAll = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuAddRequest = new System.Windows.Forms.ToolStripButton();
            this.mnuDeleteRequests = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSubmitBids = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.loader = new FleetTracking.Loader();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSentBids = new System.Windows.Forms.TabPage();
            this.dgvSent = new System.Windows.Forms.DataGridView();
            this.colSentRequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSentImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colSentReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSentRecurringType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSentTerms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.mnuDeleteBids = new System.Windows.Forms.ToolStripButton();
            this.tabReceivedBids = new System.Windows.Forms.TabPage();
            this.dgvReceivedBids = new System.Windows.Forms.DataGridView();
            this.colReceivedRequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivedImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReceivedReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivedRecurringType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivedTerms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.mnuAcceptBids = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabSentBids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSent)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tabReceivedBids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceivedBids)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoRequestsFromOthers
            // 
            this.rdoRequestsFromOthers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoRequestsFromOthers.AutoSize = true;
            this.rdoRequestsFromOthers.Location = new System.Drawing.Point(184, 316);
            this.rdoRequestsFromOthers.Name = "rdoRequestsFromOthers";
            this.rdoRequestsFromOthers.Size = new System.Drawing.Size(130, 17);
            this.rdoRequestsFromOthers.TabIndex = 6;
            this.rdoRequestsFromOthers.Text = "Requests From Others";
            this.rdoRequestsFromOthers.UseVisualStyleBackColor = true;
            this.rdoRequestsFromOthers.CheckedChanged += new System.EventHandler(this.FilterCheckedChanged);
            // 
            // dgvRequests
            // 
            this.dgvRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLeaseID,
            this.colRequester,
            this.colLeaseType,
            this.colEndTime,
            this.colBidPlaced,
            this.colPurpose});
            this.dgvRequests.Location = new System.Drawing.Point(0, 41);
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.Size = new System.Drawing.Size(1029, 269);
            this.dgvRequests.TabIndex = 4;
            this.dgvRequests.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequests_CellDoubleClick);
            this.dgvRequests.SelectionChanged += new System.EventHandler(this.dgvRequests_SelectionChanged);
            // 
            // colLeaseID
            // 
            this.colLeaseID.HeaderText = "Request Number";
            this.colLeaseID.Name = "colLeaseID";
            this.colLeaseID.Width = 50;
            // 
            // colRequester
            // 
            this.colRequester.HeaderText = "Requester";
            this.colRequester.Name = "colRequester";
            this.colRequester.Width = 150;
            // 
            // colLeaseType
            // 
            this.colLeaseType.HeaderText = "Lease Type";
            this.colLeaseType.Name = "colLeaseType";
            // 
            // colEndTime
            // 
            this.colEndTime.HeaderText = "End Time";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Width = 125;
            // 
            // colBidPlaced
            // 
            this.colBidPlaced.HeaderText = "Bid Placed";
            this.colBidPlaced.Name = "colBidPlaced";
            this.colBidPlaced.Width = 80;
            // 
            // colPurpose
            // 
            this.colPurpose.HeaderText = "Purpose";
            this.colPurpose.Name = "colPurpose";
            this.colPurpose.Width = 500;
            // 
            // rdoFilterMyRequests
            // 
            this.rdoFilterMyRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoFilterMyRequests.AutoSize = true;
            this.rdoFilterMyRequests.Location = new System.Drawing.Point(91, 316);
            this.rdoFilterMyRequests.Name = "rdoFilterMyRequests";
            this.rdoFilterMyRequests.Size = new System.Drawing.Size(87, 17);
            this.rdoFilterMyRequests.TabIndex = 7;
            this.rdoFilterMyRequests.Text = "My Requests";
            this.rdoFilterMyRequests.UseVisualStyleBackColor = true;
            this.rdoFilterMyRequests.CheckedChanged += new System.EventHandler(this.FilterCheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter";
            // 
            // rdoFilterAll
            // 
            this.rdoFilterAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoFilterAll.AutoSize = true;
            this.rdoFilterAll.Checked = true;
            this.rdoFilterAll.Location = new System.Drawing.Point(49, 316);
            this.rdoFilterAll.Name = "rdoFilterAll";
            this.rdoFilterAll.Size = new System.Drawing.Size(36, 17);
            this.rdoFilterAll.TabIndex = 8;
            this.rdoFilterAll.TabStop = true;
            this.rdoFilterAll.Text = "All";
            this.rdoFilterAll.UseVisualStyleBackColor = true;
            this.rdoFilterAll.CheckedChanged += new System.EventHandler(this.FilterCheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddRequest,
            this.mnuDeleteRequests,
            this.toolStripSeparator1,
            this.mnuSubmitBids});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1029, 38);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuAddRequest
            // 
            this.mnuAddRequest.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddRequest.Image")));
            this.mnuAddRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAddRequest.Name = "mnuAddRequest";
            this.mnuAddRequest.Size = new System.Drawing.Size(110, 35);
            this.mnuAddRequest.Text = "Add Lease Request";
            this.mnuAddRequest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuAddRequest.Click += new System.EventHandler(this.mnuAddRequest_Click);
            // 
            // mnuDeleteRequests
            // 
            this.mnuDeleteRequests.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteRequests.Image")));
            this.mnuDeleteRequests.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDeleteRequests.Name = "mnuDeleteRequests";
            this.mnuDeleteRequests.Size = new System.Drawing.Size(126, 35);
            this.mnuDeleteRequests.Text = "Delete Lease Requests";
            this.mnuDeleteRequests.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuDeleteRequests.Click += new System.EventHandler(this.mnuDeleteRequests_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // mnuSubmitBids
            // 
            this.mnuSubmitBids.Image = ((System.Drawing.Image)(resources.GetObject("mnuSubmitBids.Image")));
            this.mnuSubmitBids.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSubmitBids.Name = "mnuSubmitBids";
            this.mnuSubmitBids.Size = new System.Drawing.Size(74, 35);
            this.mnuSubmitBids.Text = "Submit Bids";
            this.mnuSubmitBids.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuSubmitBids.Click += new System.EventHandler(this.mnuSubmitBids_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvRequests);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.rdoRequestsFromOthers);
            this.splitContainer1.Panel1.Controls.Add(this.rdoFilterAll);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.rdoFilterMyRequests);
            this.splitContainer1.Panel1.Controls.Add(this.loader);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1029, 689);
            this.splitContainer1.SplitterDistance = 336;
            this.splitContainer1.TabIndex = 11;
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(1026, 336);
            this.loader.TabIndex = 10;
            this.loader.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSentBids);
            this.tabControl1.Controls.Add(this.tabReceivedBids);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1029, 349);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSentBids
            // 
            this.tabSentBids.Controls.Add(this.dgvSent);
            this.tabSentBids.Controls.Add(this.toolStrip2);
            this.tabSentBids.Location = new System.Drawing.Point(4, 22);
            this.tabSentBids.Name = "tabSentBids";
            this.tabSentBids.Padding = new System.Windows.Forms.Padding(3);
            this.tabSentBids.Size = new System.Drawing.Size(1021, 323);
            this.tabSentBids.TabIndex = 0;
            this.tabSentBids.Text = "Sent Bids";
            this.tabSentBids.UseVisualStyleBackColor = true;
            // 
            // dgvSent
            // 
            this.dgvSent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSentRequestID,
            this.colSentImage,
            this.colSentReportingMark,
            this.colSentAmount,
            this.colSentRecurringType,
            this.colSentTerms});
            this.dgvSent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSent.Location = new System.Drawing.Point(3, 41);
            this.dgvSent.Name = "dgvSent";
            this.dgvSent.Size = new System.Drawing.Size(1015, 279);
            this.dgvSent.TabIndex = 1;
            this.dgvSent.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LeaseBid_CellDoubleClick);
            this.dgvSent.SelectionChanged += new System.EventHandler(this.dgvSent_SelectionChanged);
            // 
            // colSentRequestID
            // 
            this.colSentRequestID.HeaderText = "Request Number";
            this.colSentRequestID.Name = "colSentRequestID";
            this.colSentRequestID.Width = 50;
            // 
            // colSentImage
            // 
            this.colSentImage.HeaderText = "Image";
            this.colSentImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colSentImage.Name = "colSentImage";
            // 
            // colSentReportingMark
            // 
            this.colSentReportingMark.HeaderText = "Reporting Mark";
            this.colSentReportingMark.Name = "colSentReportingMark";
            // 
            // colSentAmount
            // 
            this.colSentAmount.HeaderText = "Amount";
            this.colSentAmount.Name = "colSentAmount";
            // 
            // colSentRecurringType
            // 
            this.colSentRecurringType.HeaderText = "Recurring?";
            this.colSentRecurringType.Name = "colSentRecurringType";
            // 
            // colSentTerms
            // 
            this.colSentTerms.HeaderText = "Terms";
            this.colSentTerms.Name = "colSentTerms";
            this.colSentTerms.Width = 400;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteBids});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1015, 38);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // mnuDeleteBids
            // 
            this.mnuDeleteBids.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteBids.Image")));
            this.mnuDeleteBids.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDeleteBids.Name = "mnuDeleteBids";
            this.mnuDeleteBids.Size = new System.Drawing.Size(69, 35);
            this.mnuDeleteBids.Text = "Delete Bids";
            this.mnuDeleteBids.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuDeleteBids.Click += new System.EventHandler(this.mnuDeleteBids_Click);
            // 
            // tabReceivedBids
            // 
            this.tabReceivedBids.Controls.Add(this.dgvReceivedBids);
            this.tabReceivedBids.Controls.Add(this.toolStrip3);
            this.tabReceivedBids.Location = new System.Drawing.Point(4, 22);
            this.tabReceivedBids.Name = "tabReceivedBids";
            this.tabReceivedBids.Padding = new System.Windows.Forms.Padding(3);
            this.tabReceivedBids.Size = new System.Drawing.Size(1021, 323);
            this.tabReceivedBids.TabIndex = 1;
            this.tabReceivedBids.Text = "Received Bids";
            this.tabReceivedBids.UseVisualStyleBackColor = true;
            // 
            // dgvReceivedBids
            // 
            this.dgvReceivedBids.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceivedBids.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReceivedRequestID,
            this.colReceivedImage,
            this.colReceivedReportingMark,
            this.colReceivedAmount,
            this.colReceivedRecurringType,
            this.colReceivedTerms});
            this.dgvReceivedBids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceivedBids.Location = new System.Drawing.Point(3, 41);
            this.dgvReceivedBids.Name = "dgvReceivedBids";
            this.dgvReceivedBids.Size = new System.Drawing.Size(1015, 279);
            this.dgvReceivedBids.TabIndex = 3;
            this.dgvReceivedBids.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LeaseBid_CellDoubleClick);
            this.dgvReceivedBids.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvReceivedBids_RowCountChanged);
            this.dgvReceivedBids.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvReceivedBids_RowCountChanged);
            // 
            // colReceivedRequestID
            // 
            this.colReceivedRequestID.HeaderText = "Request Number";
            this.colReceivedRequestID.Name = "colReceivedRequestID";
            this.colReceivedRequestID.Width = 50;
            // 
            // colReceivedImage
            // 
            this.colReceivedImage.HeaderText = "Image";
            this.colReceivedImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colReceivedImage.Name = "colReceivedImage";
            // 
            // colReceivedReportingMark
            // 
            this.colReceivedReportingMark.HeaderText = "Reporting Mark";
            this.colReceivedReportingMark.Name = "colReceivedReportingMark";
            // 
            // colReceivedAmount
            // 
            this.colReceivedAmount.HeaderText = "Amount";
            this.colReceivedAmount.Name = "colReceivedAmount";
            // 
            // colReceivedRecurringType
            // 
            this.colReceivedRecurringType.HeaderText = "Recurring?";
            this.colReceivedRecurringType.Name = "colReceivedRecurringType";
            // 
            // colReceivedTerms
            // 
            this.colReceivedTerms.HeaderText = "Terms";
            this.colReceivedTerms.Name = "colReceivedTerms";
            this.colReceivedTerms.Width = 400;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAcceptBids});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1015, 38);
            this.toolStrip3.TabIndex = 2;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // mnuAcceptBids
            // 
            this.mnuAcceptBids.Image = ((System.Drawing.Image)(resources.GetObject("mnuAcceptBids.Image")));
            this.mnuAcceptBids.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAcceptBids.Name = "mnuAcceptBids";
            this.mnuAcceptBids.Size = new System.Drawing.Size(73, 35);
            this.mnuAcceptBids.Text = "Accept Bids";
            this.mnuAcceptBids.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // LeaseRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "LeaseRequests";
            this.Size = new System.Drawing.Size(1029, 689);
            this.Load += new System.EventHandler(this.LeaseRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabSentBids.ResumeLayout(false);
            this.tabSentBids.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSent)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabReceivedBids.ResumeLayout(false);
            this.tabReceivedBids.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceivedBids)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoRequestsFromOthers;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.RadioButton rdoFilterMyRequests;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoFilterAll;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuAddRequest;
        private System.Windows.Forms.ToolStripButton mnuDeleteRequests;
        private DataGridViewStylizer dataGridViewStylizer;
        private Loader loader;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSentBids;
        private System.Windows.Forms.TabPage tabReceivedBids;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeaseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequester;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeaseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colBidPlaced;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurpose;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton mnuDeleteBids;
        private System.Windows.Forms.DataGridView dgvSent;
        private System.Windows.Forms.DataGridView dgvReceivedBids;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSentRequestID;
        private System.Windows.Forms.DataGridViewImageColumn colSentImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSentReportingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSentRecurringType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSentTerms;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceivedRequestID;
        private System.Windows.Forms.DataGridViewImageColumn colReceivedImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceivedReportingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceivedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceivedRecurringType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceivedTerms;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuSubmitBids;
        private System.Windows.Forms.ToolStripButton mnuAcceptBids;
    }
}
