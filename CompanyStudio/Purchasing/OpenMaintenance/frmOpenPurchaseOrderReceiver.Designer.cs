namespace CompanyStudio.Purchasing.OpenMaintenance
{
    partial class frmOpenPurchaseOrderReceiver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpenPurchaseOrderReceiver));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlUnfulfilledLines = new System.Windows.Forms.Panel();
            this.lblPONumber = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblOrderFrom = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblOrderDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDescription = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvFulfillments = new System.Windows.Forms.DataGridView();
            this.colFulfillmentTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRailcar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFulfillmentItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFulfillmentReceived = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuAddFulfilllmentWizard = new System.Windows.Forms.ToolStripSplitButton();
            this.manualEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.loader = new CompanyStudio.Loader();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFulfillments)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlUnfulfilledLines);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unfulfilled Purchase Order Lines";
            // 
            // pnlUnfulfilledLines
            // 
            this.pnlUnfulfilledLines.AutoScroll = true;
            this.pnlUnfulfilledLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUnfulfilledLines.Location = new System.Drawing.Point(3, 16);
            this.pnlUnfulfilledLines.Name = "pnlUnfulfilledLines";
            this.pnlUnfulfilledLines.Size = new System.Drawing.Size(590, 179);
            this.pnlUnfulfilledLines.TabIndex = 0;
            // 
            // lblPONumber
            // 
            this.lblPONumber.AutoSize = true;
            this.lblPONumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPONumber.Location = new System.Drawing.Point(12, 9);
            this.lblPONumber.Name = "lblPONumber";
            this.lblPONumber.Size = new System.Drawing.Size(163, 20);
            this.lblPONumber.TabIndex = 1;
            this.lblPONumber.Text = "Open Purchase Order";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblOrderFrom,
            this.toolStripStatusLabel2,
            this.lblOrderDate,
            this.toolStripStatusLabel3,
            this.lblDescription});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(66, 17);
            this.toolStripStatusLabel1.Text = "Order From:";
            // 
            // lblOrderFrom
            // 
            this.lblOrderFrom.Name = "lblOrderFrom";
            this.lblOrderFrom.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(69, 17);
            this.toolStripStatusLabel2.Text = "Order Date:";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel3.Text = "Description:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = false;
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(200, 17);
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 32);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(776, 393);
            this.splitContainer1.SplitterDistance = 596;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(596, 393);
            this.splitContainer2.SplitterDistance = 198;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvFulfillments);
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(596, 191);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fulfillments";
            // 
            // dgvFulfillments
            // 
            this.dgvFulfillments.AllowUserToAddRows = false;
            this.dgvFulfillments.AllowUserToDeleteRows = false;
            this.dgvFulfillments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFulfillments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFulfillmentTime,
            this.colRailcar,
            this.colFulfillmentItems,
            this.colFulfillmentReceived});
            this.dgvFulfillments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFulfillments.Location = new System.Drawing.Point(3, 41);
            this.dgvFulfillments.Name = "dgvFulfillments";
            this.dgvFulfillments.ReadOnly = true;
            this.dgvFulfillments.RowHeadersVisible = false;
            this.dgvFulfillments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFulfillments.Size = new System.Drawing.Size(590, 147);
            this.dgvFulfillments.TabIndex = 0;
            // 
            // colFulfillmentTime
            // 
            this.colFulfillmentTime.HeaderText = "Fulfillment Time";
            this.colFulfillmentTime.Name = "colFulfillmentTime";
            this.colFulfillmentTime.ReadOnly = true;
            this.colFulfillmentTime.Width = 120;
            // 
            // colRailcar
            // 
            this.colRailcar.HeaderText = "Railcar";
            this.colRailcar.Name = "colRailcar";
            this.colRailcar.ReadOnly = true;
            // 
            // colFulfillmentItems
            // 
            this.colFulfillmentItems.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFulfillmentItems.HeaderText = "Item";
            this.colFulfillmentItems.Name = "colFulfillmentItems";
            this.colFulfillmentItems.ReadOnly = true;
            // 
            // colFulfillmentReceived
            // 
            this.colFulfillmentReceived.HeaderText = "Is Received";
            this.colFulfillmentReceived.Name = "colFulfillmentReceived";
            this.colFulfillmentReceived.ReadOnly = true;
            this.colFulfillmentReceived.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFulfillmentReceived.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddFulfilllmentWizard});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(590, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuAddFulfilllmentWizard
            // 
            this.mnuAddFulfilllmentWizard.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualEntryToolStripMenuItem});
            this.mnuAddFulfilllmentWizard.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddFulfilllmentWizard.Image")));
            this.mnuAddFulfilllmentWizard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAddFulfilllmentWizard.Name = "mnuAddFulfilllmentWizard";
            this.mnuAddFulfilllmentWizard.Size = new System.Drawing.Size(145, 22);
            this.mnuAddFulfilllmentWizard.Text = "Add Fulfillment Wizard";
            this.mnuAddFulfilllmentWizard.ButtonClick += new System.EventHandler(this.mnuAddFulfilllmentWizard_ButtonClick);
            // 
            // manualEntryToolStripMenuItem
            // 
            this.manualEntryToolStripMenuItem.Name = "manualEntryToolStripMenuItem";
            this.manualEntryToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.manualEntryToolStripMenuItem.Text = "Manual Entry";
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(176, 393);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Invoices";
            // 
            // loader
            // 
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(302, 175);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(196, 101);
            this.loader.TabIndex = 4;
            this.loader.Visible = false;
            // 
            // frmOpenPurchaseOrderReceiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblPONumber);
            this.Controls.Add(this.loader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOpenPurchaseOrderReceiver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open Purchase Order";
            this.Load += new System.EventHandler(this.frmOpenPurchaseOrderReceiver_Load);
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFulfillments)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPONumber;
        private System.Windows.Forms.Panel pnlUnfulfilledLines;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblOrderFrom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblOrderDate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblDescription;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Loader loader;
        private System.Windows.Forms.DataGridView dgvFulfillments;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton mnuAddFulfilllmentWizard;
        private System.Windows.Forms.ToolStripMenuItem manualEntryToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFulfillmentTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRailcar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFulfillmentItems;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFulfillmentReceived;
    }
}