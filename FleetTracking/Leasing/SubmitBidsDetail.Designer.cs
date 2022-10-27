namespace FleetTracking.Leasing
{
    partial class SubmitBidsDetail
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtTerms = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRecurringBilling = new System.Windows.Forms.ComboBox();
            this.cboReceivedTo = new System.Windows.Forms.ComboBox();
            this.lblReceivedTo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecurringAmount = new System.Windows.Forms.TextBox();
            this.txtLeaseAmount = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colLeaseRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurpose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRollingStock = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.txtTerms);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cboRecurringBilling);
            this.splitContainer1.Panel1.Controls.Add(this.cboReceivedTo);
            this.splitContainer1.Panel1.Controls.Add(this.lblReceivedTo);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtRecurringAmount);
            this.splitContainer1.Panel1.Controls.Add(this.txtLeaseAmount);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(753, 317);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtTerms
            // 
            this.txtTerms.AcceptsReturn = true;
            this.txtTerms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTerms.Location = new System.Drawing.Point(5, 103);
            this.txtTerms.Multiline = true;
            this.txtTerms.Name = "txtTerms";
            this.txtTerms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTerms.Size = new System.Drawing.Size(745, 110);
            this.txtTerms.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Terms:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Recurring Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Recurring Billing:";
            // 
            // cboRecurringBilling
            // 
            this.cboRecurringBilling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRecurringBilling.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRecurringBilling.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRecurringBilling.FormattingEnabled = true;
            this.cboRecurringBilling.Location = new System.Drawing.Point(106, 30);
            this.cboRecurringBilling.Name = "cboRecurringBilling";
            this.cboRecurringBilling.Size = new System.Drawing.Size(644, 21);
            this.cboRecurringBilling.TabIndex = 11;
            // 
            // cboReceivedTo
            // 
            this.cboReceivedTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReceivedTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboReceivedTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReceivedTo.FormattingEnabled = true;
            this.cboReceivedTo.Location = new System.Drawing.Point(298, 3);
            this.cboReceivedTo.Name = "cboReceivedTo";
            this.cboReceivedTo.Size = new System.Drawing.Size(452, 21);
            this.cboReceivedTo.TabIndex = 10;
            this.cboReceivedTo.Visible = false;
            // 
            // lblReceivedTo
            // 
            this.lblReceivedTo.AutoSize = true;
            this.lblReceivedTo.Location = new System.Drawing.Point(188, 6);
            this.lblReceivedTo.Name = "lblReceivedTo";
            this.lblReceivedTo.Size = new System.Drawing.Size(104, 13);
            this.lblReceivedTo.TabIndex = 13;
            this.lblReceivedTo.Text = "Receive Invoice To:";
            this.lblReceivedTo.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Lease Amount:";
            // 
            // txtRecurringAmount
            // 
            this.txtRecurringAmount.Location = new System.Drawing.Point(106, 57);
            this.txtRecurringAmount.Name = "txtRecurringAmount";
            this.txtRecurringAmount.Size = new System.Drawing.Size(76, 20);
            this.txtRecurringAmount.TabIndex = 14;
            // 
            // txtLeaseAmount
            // 
            this.txtLeaseAmount.Location = new System.Drawing.Point(106, 3);
            this.txtLeaseAmount.Name = "txtLeaseAmount";
            this.txtLeaseAmount.Size = new System.Drawing.Size(76, 20);
            this.txtLeaseAmount.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLeaseRequest,
            this.colType,
            this.colEndTime,
            this.colPurpose,
            this.colRollingStock});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(753, 97);
            this.dataGridView1.TabIndex = 0;
            // 
            // colLeaseRequest
            // 
            this.colLeaseRequest.HeaderText = "Lease Request";
            this.colLeaseRequest.Name = "colLeaseRequest";
            this.colLeaseRequest.ReadOnly = true;
            this.colLeaseRequest.Width = 130;
            // 
            // colType
            // 
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            // 
            // colEndTime
            // 
            this.colEndTime.HeaderText = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.ReadOnly = true;
            // 
            // colPurpose
            // 
            this.colPurpose.HeaderText = "Purpose";
            this.colPurpose.Name = "colPurpose";
            this.colPurpose.ReadOnly = true;
            // 
            // colRollingStock
            // 
            this.colRollingStock.HeaderText = "Bidded Reporting Mark";
            this.colRollingStock.Name = "colRollingStock";
            this.colRollingStock.ReadOnly = true;
            this.colRollingStock.Width = 200;
            // 
            // SubmitBidsDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SubmitBidsDetail";
            this.Size = new System.Drawing.Size(753, 317);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtTerms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRecurringBilling;
        private System.Windows.Forms.ComboBox cboReceivedTo;
        private System.Windows.Forms.Label lblReceivedTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRecurringAmount;
        private System.Windows.Forms.TextBox txtLeaseAmount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeaseRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurpose;
        private System.Windows.Forms.DataGridViewComboBoxColumn colRollingStock;
    }
}
