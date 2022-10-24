namespace FleetTracking.Leasing
{
    partial class LeaseRequestDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeaseRequestDetail));
            this.grpLeaseRequest = new System.Windows.Forms.GroupBox();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboRailcarType = new System.Windows.Forms.ComboBox();
            this.cboLeaseType = new System.Windows.Forms.ComboBox();
            this.lblRailcarType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.txtDeliveryLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRequester = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBids = new System.Windows.Forms.GroupBox();
            this.dgvBids = new System.Windows.Forms.DataGridView();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecurring = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsmiAccept = new System.Windows.Forms.ToolStripButton();
            this.tsmiSubmitBid = new System.Windows.Forms.ToolStripButton();
            this.tsmiDeleteBid = new System.Windows.Forms.ToolStripButton();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdClone = new System.Windows.Forms.Button();
            this.loader = new FleetTracking.Loader();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            this.grpLeaseRequest.SuspendLayout();
            this.grpBids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBids)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLeaseRequest
            // 
            this.grpLeaseRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLeaseRequest.Controls.Add(this.dtpEndTime);
            this.grpLeaseRequest.Controls.Add(this.label6);
            this.grpLeaseRequest.Controls.Add(this.label5);
            this.grpLeaseRequest.Controls.Add(this.cboRailcarType);
            this.grpLeaseRequest.Controls.Add(this.cboLeaseType);
            this.grpLeaseRequest.Controls.Add(this.lblRailcarType);
            this.grpLeaseRequest.Controls.Add(this.label2);
            this.grpLeaseRequest.Controls.Add(this.txtPurpose);
            this.grpLeaseRequest.Controls.Add(this.txtDeliveryLocation);
            this.grpLeaseRequest.Controls.Add(this.label4);
            this.grpLeaseRequest.Controls.Add(this.txtRequester);
            this.grpLeaseRequest.Controls.Add(this.label1);
            this.grpLeaseRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLeaseRequest.Location = new System.Drawing.Point(4, 5);
            this.grpLeaseRequest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLeaseRequest.Name = "grpLeaseRequest";
            this.grpLeaseRequest.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLeaseRequest.Size = new System.Drawing.Size(942, 408);
            this.grpLeaseRequest.TabIndex = 0;
            this.grpLeaseRequest.TabStop = false;
            this.grpLeaseRequest.Text = "Lease Request";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndTime.CustomFormat = "dddd MM/dd/yyyy HH:mm";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(130, 357);
            this.dtpEndTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(800, 26);
            this.dtpEndTime.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 363);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Bid End Time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 174);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Purpose:";
            // 
            // cboRailcarType
            // 
            this.cboRailcarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRailcarType.FormattingEnabled = true;
            this.cboRailcarType.Location = new System.Drawing.Point(422, 69);
            this.cboRailcarType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboRailcarType.Name = "cboRailcarType";
            this.cboRailcarType.Size = new System.Drawing.Size(180, 28);
            this.cboRailcarType.TabIndex = 2;
            this.cboRailcarType.Visible = false;
            // 
            // cboLeaseType
            // 
            this.cboLeaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLeaseType.FormattingEnabled = true;
            this.cboLeaseType.Location = new System.Drawing.Point(117, 69);
            this.cboLeaseType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboLeaseType.Name = "cboLeaseType";
            this.cboLeaseType.Size = new System.Drawing.Size(180, 28);
            this.cboLeaseType.TabIndex = 1;
            this.cboLeaseType.SelectedIndexChanged += new System.EventHandler(this.cboLeaseType_SelectedIndexChanged);
            // 
            // lblRailcarType
            // 
            this.lblRailcarType.AutoSize = true;
            this.lblRailcarType.Location = new System.Drawing.Point(308, 74);
            this.lblRailcarType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRailcarType.Name = "lblRailcarType";
            this.lblRailcarType.Size = new System.Drawing.Size(108, 20);
            this.lblRailcarType.TabIndex = 2;
            this.lblRailcarType.Text = "Railcar Type:";
            this.lblRailcarType.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lease Type:";
            // 
            // txtPurpose
            // 
            this.txtPurpose.AcceptsReturn = true;
            this.txtPurpose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPurpose.Location = new System.Drawing.Point(14, 198);
            this.txtPurpose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPurpose.Multiline = true;
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPurpose.Size = new System.Drawing.Size(918, 147);
            this.txtPurpose.TabIndex = 4;
            // 
            // txtDeliveryLocation
            // 
            this.txtDeliveryLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliveryLocation.Location = new System.Drawing.Point(117, 122);
            this.txtDeliveryLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDeliveryLocation.Name = "txtDeliveryLocation";
            this.txtDeliveryLocation.Size = new System.Drawing.Size(814, 26);
            this.txtDeliveryLocation.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 40);
            this.label4.TabIndex = 0;
            this.label4.Text = "Delivery \r\nLocation:";
            // 
            // txtRequester
            // 
            this.txtRequester.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequester.Location = new System.Drawing.Point(117, 29);
            this.txtRequester.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRequester.Name = "txtRequester";
            this.txtRequester.ReadOnly = true;
            this.txtRequester.Size = new System.Drawing.Size(814, 26);
            this.txtRequester.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Requester:";
            // 
            // grpBids
            // 
            this.grpBids.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBids.Controls.Add(this.dgvBids);
            this.grpBids.Controls.Add(this.toolStrip1);
            this.grpBids.Location = new System.Drawing.Point(4, 422);
            this.grpBids.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpBids.Name = "grpBids";
            this.grpBids.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpBids.Size = new System.Drawing.Size(942, 392);
            this.grpBids.TabIndex = 1;
            this.grpBids.TabStop = false;
            this.grpBids.Text = "Bids";
            // 
            // dgvBids
            // 
            this.dgvBids.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBids.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.colReportingMark,
            this.colAmount,
            this.colRecurring});
            this.dgvBids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBids.Location = new System.Drawing.Point(4, 82);
            this.dgvBids.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvBids.Name = "dgvBids";
            this.dgvBids.RowHeadersWidth = 62;
            this.dgvBids.Size = new System.Drawing.Size(934, 305);
            this.dgvBids.TabIndex = 0;
            this.dgvBids.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBids_CellDoubleClick);
            this.dgvBids.SelectionChanged += new System.EventHandler(this.dgvBids_SelectionChanged);
            // 
            // colImage
            // 
            this.colImage.HeaderText = "Image";
            this.colImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colImage.MinimumWidth = 8;
            this.colImage.Name = "colImage";
            this.colImage.Width = 150;
            // 
            // colReportingMark
            // 
            this.colReportingMark.HeaderText = "Reporting Mark";
            this.colReportingMark.MinimumWidth = 8;
            this.colReportingMark.Name = "colReportingMark";
            this.colReportingMark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colReportingMark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colReportingMark.Width = 150;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.MinimumWidth = 8;
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 150;
            // 
            // colRecurring
            // 
            this.colRecurring.HeaderText = "Recurring?";
            this.colRecurring.MinimumWidth = 8;
            this.colRecurring.Name = "colRecurring";
            this.colRecurring.Width = 150;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAccept,
            this.tsmiSubmitBid,
            this.tsmiDeleteBid});
            this.toolStrip1.Location = new System.Drawing.Point(4, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(934, 58);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsmiAccept
            // 
            this.tsmiAccept.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAccept.Image")));
            this.tsmiAccept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiAccept.Name = "tsmiAccept";
            this.tsmiAccept.Size = new System.Drawing.Size(100, 53);
            this.tsmiAccept.Text = "Accept Bid";
            this.tsmiAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsmiSubmitBid
            // 
            this.tsmiSubmitBid.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSubmitBid.Image")));
            this.tsmiSubmitBid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiSubmitBid.Name = "tsmiSubmitBid";
            this.tsmiSubmitBid.Size = new System.Drawing.Size(103, 53);
            this.tsmiSubmitBid.Text = "Submit Bid";
            this.tsmiSubmitBid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsmiSubmitBid.Click += new System.EventHandler(this.tsmiSubmitBid_Click);
            // 
            // tsmiDeleteBid
            // 
            this.tsmiDeleteBid.Image = ((System.Drawing.Image)(resources.GetObject("tsmiDeleteBid.Image")));
            this.tsmiDeleteBid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiDeleteBid.Name = "tsmiDeleteBid";
            this.tsmiDeleteBid.Size = new System.Drawing.Size(96, 53);
            this.tsmiDeleteBid.Text = "Delete Bid";
            this.tsmiDeleteBid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // cmdReset
            // 
            this.cmdReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReset.Location = new System.Drawing.Point(699, 417);
            this.cmdReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(112, 35);
            this.cmdReset.TabIndex = 3;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(820, 417);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(112, 35);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClone
            // 
            this.cmdClone.Location = new System.Drawing.Point(9, 417);
            this.cmdClone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdClone.Name = "cmdClone";
            this.cmdClone.Size = new System.Drawing.Size(112, 35);
            this.cmdClone.TabIndex = 3;
            this.cmdClone.Text = "Clone";
            this.cmdClone.UseVisualStyleBackColor = true;
            this.cmdClone.Click += new System.EventHandler(this.cmdClone_Click);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(951, 815);
            this.loader.TabIndex = 2;
            this.loader.Visible = false;
            // 
            // LeaseRequestDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdClone);
            this.Controls.Add(this.grpLeaseRequest);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.grpBids);
            this.Controls.Add(this.loader);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LeaseRequestDetail";
            this.Size = new System.Drawing.Size(951, 815);
            this.Load += new System.EventHandler(this.LeaseRequestDetail_Load);
            this.grpLeaseRequest.ResumeLayout(false);
            this.grpLeaseRequest.PerformLayout();
            this.grpBids.ResumeLayout(false);
            this.grpBids.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBids)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLeaseRequest;
        private System.Windows.Forms.TextBox txtRequester;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLeaseType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRailcarType;
        private System.Windows.Forms.Label lblRailcarType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeliveryLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPurpose;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpBids;
        private System.Windows.Forms.DataGridView dgvBids;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsmiAccept;
        private DataGridViewStylizer dataGridViewStylizer;
        private Loader loader;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.ToolStripButton tsmiDeleteBid;
        private System.Windows.Forms.ToolStripButton tsmiSubmitBid;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecurring;
        private System.Windows.Forms.Button cmdClone;
    }
}
