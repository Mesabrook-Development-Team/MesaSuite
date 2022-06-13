namespace CompanyStudio.Invoicing
{
    partial class frmPayableExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayableExplorer));
            this.lstPayables = new System.Windows.Forms.ListView();
            this.colInvoiceNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPayee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDueDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loader = new CompanyStudio.Loader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuSent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReadyForReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComplete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPayables
            // 
            this.lstPayables.AllowColumnReorder = true;
            this.lstPayables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPayables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInvoiceNumber,
            this.colPayee,
            this.colDueDate,
            this.colAmount,
            this.colStatus});
            this.lstPayables.FullRowSelect = true;
            this.lstPayables.HideSelection = false;
            this.lstPayables.Location = new System.Drawing.Point(0, 28);
            this.lstPayables.Name = "lstPayables";
            this.lstPayables.Size = new System.Drawing.Size(800, 422);
            this.lstPayables.TabIndex = 0;
            this.lstPayables.UseCompatibleStateImageBehavior = false;
            this.lstPayables.View = System.Windows.Forms.View.Details;
            this.lstPayables.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstPayables_MouseDoubleClick);
            // 
            // colInvoiceNumber
            // 
            this.colInvoiceNumber.Text = "Invoice Number";
            this.colInvoiceNumber.Width = 120;
            // 
            // colPayee
            // 
            this.colPayee.Text = "Payee";
            this.colPayee.Width = 150;
            // 
            // colDueDate
            // 
            this.colDueDate.Text = "Due Date";
            this.colDueDate.Width = 100;
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
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(800, 450);
            this.loader.TabIndex = 1;
            this.loader.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSent,
            this.mnuReadyForReceipt,
            this.mnuComplete});
            this.toolStripDropDownButton1.Image = global::CompanyStudio.Properties.Resources.icn_view;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(62, 22);
            this.toolStripDropDownButton1.Text = "Filter";
            // 
            // mnuSent
            // 
            this.mnuSent.CheckOnClick = true;
            this.mnuSent.Name = "mnuSent";
            this.mnuSent.Size = new System.Drawing.Size(180, 22);
            this.mnuSent.Text = "Sent";
            this.mnuSent.CheckedChanged += new System.EventHandler(this.FilterCheckChanged);
            // 
            // mnuReadyForReceipt
            // 
            this.mnuReadyForReceipt.CheckOnClick = true;
            this.mnuReadyForReceipt.Name = "mnuReadyForReceipt";
            this.mnuReadyForReceipt.Size = new System.Drawing.Size(180, 22);
            this.mnuReadyForReceipt.Text = "Ready For Receipt";
            this.mnuReadyForReceipt.CheckedChanged += new System.EventHandler(this.FilterCheckChanged);
            // 
            // mnuComplete
            // 
            this.mnuComplete.CheckOnClick = true;
            this.mnuComplete.Name = "mnuComplete";
            this.mnuComplete.Size = new System.Drawing.Size(180, 22);
            this.mnuComplete.Text = "Complete";
            this.mnuComplete.CheckedChanged += new System.EventHandler(this.FilterCheckChanged);
            // 
            // frmPayableExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lstPayables);
            this.Controls.Add(this.loader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPayableExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payables";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPayableExplorer_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPayableExplorer_FormClosed);
            this.Load += new System.EventHandler(this.frmPayableExplorer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPayableExplorer_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstPayables;
        private System.Windows.Forms.ColumnHeader colInvoiceNumber;
        private System.Windows.Forms.ColumnHeader colPayee;
        private System.Windows.Forms.ColumnHeader colDueDate;
        private System.Windows.Forms.ColumnHeader colAmount;
        private Loader loader;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem mnuSent;
        private System.Windows.Forms.ToolStripMenuItem mnuReadyForReceipt;
        private System.Windows.Forms.ToolStripMenuItem mnuComplete;
    }
}