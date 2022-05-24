namespace CompanyStudio.Invoicing
{
    partial class frmAccountsReceivableExplorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountsReceivableExplorer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuAdd = new System.Windows.Forms.ToolStripButton();
            this.mnuDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuFilterWIP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilterSent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilterReadyToReceive = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilterCompleted = new System.Windows.Forms.ToolStripMenuItem();
            this.lstInvoices = new System.Windows.Forms.ListView();
            this.colInvoiceNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPayor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loader = new CompanyStudio.Loader();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd,
            this.mnuDelete,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 23);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuAdd
            // 
            this.mnuAdd.Image = ((System.Drawing.Image)(resources.GetObject("mnuAdd.Image")));
            this.mnuAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(108, 20);
            this.mnuAdd.Text = "Add Receivable";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Enabled = false;
            this.mnuDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuDelete.Image")));
            this.mnuDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(119, 20);
            this.mnuDelete.Text = "Delete Receivable";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFilterWIP,
            this.mnuFilterSent,
            this.mnuFilterReadyToReceive,
            this.mnuFilterCompleted});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(62, 20);
            this.toolStripDropDownButton1.Text = "Filter";
            // 
            // mnuFilterWIP
            // 
            this.mnuFilterWIP.CheckOnClick = true;
            this.mnuFilterWIP.Name = "mnuFilterWIP";
            this.mnuFilterWIP.Size = new System.Drawing.Size(164, 22);
            this.mnuFilterWIP.Text = "Work In Progress";
            this.mnuFilterWIP.CheckedChanged += new System.EventHandler(this.FilterItem_CheckedChanged);
            // 
            // mnuFilterSent
            // 
            this.mnuFilterSent.CheckOnClick = true;
            this.mnuFilterSent.Name = "mnuFilterSent";
            this.mnuFilterSent.Size = new System.Drawing.Size(164, 22);
            this.mnuFilterSent.Text = "Sent";
            this.mnuFilterSent.CheckedChanged += new System.EventHandler(this.FilterItem_CheckedChanged);
            // 
            // mnuFilterReadyToReceive
            // 
            this.mnuFilterReadyToReceive.CheckOnClick = true;
            this.mnuFilterReadyToReceive.Name = "mnuFilterReadyToReceive";
            this.mnuFilterReadyToReceive.Size = new System.Drawing.Size(164, 22);
            this.mnuFilterReadyToReceive.Text = "Ready To Receive";
            this.mnuFilterReadyToReceive.Click += new System.EventHandler(this.FilterItem_CheckedChanged);
            // 
            // mnuFilterCompleted
            // 
            this.mnuFilterCompleted.CheckOnClick = true;
            this.mnuFilterCompleted.Name = "mnuFilterCompleted";
            this.mnuFilterCompleted.Size = new System.Drawing.Size(164, 22);
            this.mnuFilterCompleted.Text = "Completed";
            this.mnuFilterCompleted.CheckedChanged += new System.EventHandler(this.FilterItem_CheckedChanged);
            // 
            // lstInvoices
            // 
            this.lstInvoices.AllowColumnReorder = true;
            this.lstInvoices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInvoiceNumber,
            this.colPayor,
            this.colAmount,
            this.colStatus});
            this.lstInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInvoices.FullRowSelect = true;
            this.lstInvoices.HideSelection = false;
            this.lstInvoices.Location = new System.Drawing.Point(0, 23);
            this.lstInvoices.Name = "lstInvoices";
            this.lstInvoices.Size = new System.Drawing.Size(800, 427);
            this.lstInvoices.TabIndex = 1;
            this.lstInvoices.UseCompatibleStateImageBehavior = false;
            this.lstInvoices.View = System.Windows.Forms.View.Details;
            this.lstInvoices.SelectedIndexChanged += new System.EventHandler(this.lstInvoices_SelectedIndexChanged);
            this.lstInvoices.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstInvoices_KeyDown);
            this.lstInvoices.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstInvoices_MouseDoubleClick);
            // 
            // colInvoiceNumber
            // 
            this.colInvoiceNumber.Text = "Invoice Number";
            this.colInvoiceNumber.Width = 100;
            // 
            // colPayor
            // 
            this.colPayor.Text = "Payor";
            this.colPayor.Width = 200;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.Width = 100;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 120;
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
            // frmAccountsReceivableExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstInvoices);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.loader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmAccountsReceivableExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receivables";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccountsReceivableExplorer_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAccountsReceivableExplorer_FormClosed);
            this.Load += new System.EventHandler(this.frmAccountsReceivableExplorer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAccountsReceivableExplorer_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuAdd;
        private System.Windows.Forms.ToolStripButton mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ListView lstInvoices;
        private System.Windows.Forms.ColumnHeader colInvoiceNumber;
        private System.Windows.Forms.ColumnHeader colPayor;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colStatus;
        private Loader loader;
        private System.Windows.Forms.ToolStripMenuItem mnuFilterWIP;
        private System.Windows.Forms.ToolStripMenuItem mnuFilterSent;
        private System.Windows.Forms.ToolStripMenuItem mnuFilterCompleted;
        private System.Windows.Forms.ToolStripMenuItem mnuFilterReadyToReceive;
    }
}