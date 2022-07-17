namespace CompanyStudio.WireTransfers
{
    partial class frmWireTransferHistoryExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWireTransferHistoryExplorer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSendWireTransfer = new System.Windows.Forms.ToolStripButton();
            this.lstWireTransfers = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFromAccount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colToAccount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMemo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loader = new CompanyStudio.Loader();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSendWireTransfer});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1125, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSendWireTransfer
            // 
            this.toolSendWireTransfer.Image = global::CompanyStudio.Properties.Resources.icn_dollar_out;
            this.toolSendWireTransfer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSendWireTransfer.Name = "toolSendWireTransfer";
            this.toolSendWireTransfer.Size = new System.Drawing.Size(132, 28);
            this.toolSendWireTransfer.Text = "Send Wire Transfer";
            this.toolSendWireTransfer.Click += new System.EventHandler(this.toolSendWireTransfer_Click);
            // 
            // lstWireTransfers
            // 
            this.lstWireTransfers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colFrom,
            this.colTo,
            this.colFromAccount,
            this.colToAccount,
            this.colAmount,
            this.colMemo});
            this.lstWireTransfers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstWireTransfers.FullRowSelect = true;
            this.lstWireTransfers.HideSelection = false;
            this.lstWireTransfers.Location = new System.Drawing.Point(0, 31);
            this.lstWireTransfers.Name = "lstWireTransfers";
            this.lstWireTransfers.Size = new System.Drawing.Size(1125, 537);
            this.lstWireTransfers.TabIndex = 1;
            this.lstWireTransfers.UseCompatibleStateImageBehavior = false;
            this.lstWireTransfers.View = System.Windows.Forms.View.Details;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 100;
            // 
            // colFrom
            // 
            this.colFrom.Text = "From";
            this.colFrom.Width = 100;
            // 
            // colTo
            // 
            this.colTo.Text = "To";
            this.colTo.Width = 100;
            // 
            // colFromAccount
            // 
            this.colFromAccount.Text = "From Account";
            this.colFromAccount.Width = 160;
            // 
            // colToAccount
            // 
            this.colToAccount.Text = "Destination Account";
            this.colToAccount.Width = 160;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.Width = 100;
            // 
            // colMemo
            // 
            this.colMemo.Text = "Memo";
            this.colMemo.Width = 160;
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(1125, 568);
            this.loader.TabIndex = 2;
            this.loader.Visible = false;
            // 
            // frmWireTransferHistoryExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 568);
            this.Controls.Add(this.lstWireTransfers);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.loader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWireTransferHistoryExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wire Transfer History";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWireTransferHistoryExplorer_FormClosing);
            this.Load += new System.EventHandler(this.frmWireTransferHistoryExplorer_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSendWireTransfer;
        private System.Windows.Forms.ListView lstWireTransfers;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colTo;
        private System.Windows.Forms.ColumnHeader colFromAccount;
        private System.Windows.Forms.ColumnHeader colToAccount;
        private System.Windows.Forms.ColumnHeader colAmount;
        private Loader loader;
        private System.Windows.Forms.ColumnHeader colFrom;
        private System.Windows.Forms.ColumnHeader colMemo;
    }
}