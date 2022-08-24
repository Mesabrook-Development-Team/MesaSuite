namespace GovernmentPortal.Invoicing
{
    partial class PayableInvoiceControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInvoiceInfo = new System.Windows.Forms.TabPage();
            this.cboPayableAccount = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInvoiceTotalInfoTab = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPayor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabInvoiceLines = new System.Windows.Forms.TabPage();
            this.txtInvoiceTotalLinesTab = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.colInvoiceLineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdAuthorizePayment = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.loader = new GovernmentPortal.Loader();
            this.tabControl1.SuspendLayout();
            this.tabInvoiceInfo.SuspendLayout();
            this.tabInvoiceLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabInvoiceInfo);
            this.tabControl1.Controls.Add(this.tabInvoiceLines);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(562, 317);
            this.tabControl1.TabIndex = 0;
            // 
            // tabInvoiceInfo
            // 
            this.tabInvoiceInfo.Controls.Add(this.cboPayableAccount);
            this.tabInvoiceInfo.Controls.Add(this.label7);
            this.tabInvoiceInfo.Controls.Add(this.txtDescription);
            this.tabInvoiceInfo.Controls.Add(this.dtpDueDate);
            this.tabInvoiceInfo.Controls.Add(this.label6);
            this.tabInvoiceInfo.Controls.Add(this.label5);
            this.tabInvoiceInfo.Controls.Add(this.dtpInvoiceDate);
            this.tabInvoiceInfo.Controls.Add(this.label4);
            this.tabInvoiceInfo.Controls.Add(this.txtInvoiceTotalInfoTab);
            this.tabInvoiceInfo.Controls.Add(this.label8);
            this.tabInvoiceInfo.Controls.Add(this.txtInvoiceNumber);
            this.tabInvoiceInfo.Controls.Add(this.label3);
            this.tabInvoiceInfo.Controls.Add(this.txtPayor);
            this.tabInvoiceInfo.Controls.Add(this.label2);
            this.tabInvoiceInfo.Controls.Add(this.txtPayee);
            this.tabInvoiceInfo.Controls.Add(this.label1);
            this.tabInvoiceInfo.Location = new System.Drawing.Point(4, 22);
            this.tabInvoiceInfo.Name = "tabInvoiceInfo";
            this.tabInvoiceInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInvoiceInfo.Size = new System.Drawing.Size(554, 291);
            this.tabInvoiceInfo.TabIndex = 0;
            this.tabInvoiceInfo.Text = "Invoice Info";
            this.tabInvoiceInfo.UseVisualStyleBackColor = true;
            // 
            // cboPayableAccount
            // 
            this.cboPayableAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPayableAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayableAccount.FormattingEnabled = true;
            this.cboPayableAccount.Location = new System.Drawing.Point(103, 264);
            this.cboPayableAccount.Name = "cboPayableAccount";
            this.cboPayableAccount.Size = new System.Drawing.Size(445, 21);
            this.cboPayableAccount.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Payable Account:";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(6, 149);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(542, 83);
            this.txtDescription.TabIndex = 5;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDueDate.Enabled = false;
            this.dtpDueDate.Location = new System.Drawing.Point(103, 110);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(445, 20);
            this.dtpDueDate.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Due Date:";
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpInvoiceDate.Enabled = false;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(103, 84);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(445, 20);
            this.dtpInvoiceDate.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Invoice Date:";
            // 
            // txtInvoiceTotalInfoTab
            // 
            this.txtInvoiceTotalInfoTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceTotalInfoTab.Location = new System.Drawing.Point(103, 238);
            this.txtInvoiceTotalInfoTab.Name = "txtInvoiceTotalInfoTab";
            this.txtInvoiceTotalInfoTab.ReadOnly = true;
            this.txtInvoiceTotalInfoTab.Size = new System.Drawing.Size(445, 20);
            this.txtInvoiceTotalInfoTab.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Invoice Total:";
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceNumber.Location = new System.Drawing.Point(103, 58);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.ReadOnly = true;
            this.txtInvoiceNumber.Size = new System.Drawing.Size(445, 20);
            this.txtInvoiceNumber.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Invoice Number:";
            // 
            // txtPayor
            // 
            this.txtPayor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPayor.Location = new System.Drawing.Point(103, 32);
            this.txtPayor.Name = "txtPayor";
            this.txtPayor.ReadOnly = true;
            this.txtPayor.Size = new System.Drawing.Size(445, 20);
            this.txtPayor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Payor:";
            // 
            // txtPayee
            // 
            this.txtPayee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPayee.Location = new System.Drawing.Point(103, 6);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.ReadOnly = true;
            this.txtPayee.Size = new System.Drawing.Size(445, 20);
            this.txtPayee.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payee:";
            // 
            // tabInvoiceLines
            // 
            this.tabInvoiceLines.Controls.Add(this.txtInvoiceTotalLinesTab);
            this.tabInvoiceLines.Controls.Add(this.label9);
            this.tabInvoiceLines.Controls.Add(this.dgvLines);
            this.tabInvoiceLines.Location = new System.Drawing.Point(4, 22);
            this.tabInvoiceLines.Name = "tabInvoiceLines";
            this.tabInvoiceLines.Padding = new System.Windows.Forms.Padding(3);
            this.tabInvoiceLines.Size = new System.Drawing.Size(554, 291);
            this.tabInvoiceLines.TabIndex = 1;
            this.tabInvoiceLines.Text = "Invoice Lines";
            this.tabInvoiceLines.UseVisualStyleBackColor = true;
            // 
            // txtInvoiceTotalLinesTab
            // 
            this.txtInvoiceTotalLinesTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceTotalLinesTab.Location = new System.Drawing.Point(103, 265);
            this.txtInvoiceTotalLinesTab.Name = "txtInvoiceTotalLinesTab";
            this.txtInvoiceTotalLinesTab.ReadOnly = true;
            this.txtInvoiceTotalLinesTab.Size = new System.Drawing.Size(445, 20);
            this.txtInvoiceTotalLinesTab.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Invoice Total:";
            // 
            // dgvLines
            // 
            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInvoiceLineID,
            this.colDescription,
            this.colQuantity,
            this.colUnitCost,
            this.colTotal});
            this.dgvLines.Location = new System.Drawing.Point(-1, 0);
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.ReadOnly = true;
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.Size = new System.Drawing.Size(552, 259);
            this.dgvLines.TabIndex = 1;
            // 
            // colInvoiceLineID
            // 
            this.colInvoiceLineID.HeaderText = "";
            this.colInvoiceLineID.Name = "colInvoiceLineID";
            this.colInvoiceLineID.ReadOnly = true;
            this.colInvoiceLineID.Visible = false;
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
            // 
            // colQuantity
            // 
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.colQuantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // colUnitCost
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colUnitCost.DefaultCellStyle = dataGridViewCellStyle2;
            this.colUnitCost.HeaderText = "Unit Cost";
            this.colUnitCost.Name = "colUnitCost";
            this.colUnitCost.ReadOnly = true;
            // 
            // colTotal
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // cmdAuthorizePayment
            // 
            this.cmdAuthorizePayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAuthorizePayment.Location = new System.Drawing.Point(452, 323);
            this.cmdAuthorizePayment.Name = "cmdAuthorizePayment";
            this.cmdAuthorizePayment.Size = new System.Drawing.Size(110, 23);
            this.cmdAuthorizePayment.TabIndex = 1;
            this.cmdAuthorizePayment.Text = "Authorize Payment";
            this.cmdAuthorizePayment.UseVisualStyleBackColor = true;
            this.cmdAuthorizePayment.Click += new System.EventHandler(this.cmdAuthorizePayment_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 328);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(41, 328);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 2;
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(562, 346);
            this.loader.TabIndex = 3;
            this.loader.Visible = false;
            // 
            // PayableInvoiceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmdAuthorizePayment);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.loader);
            this.Name = "PayableInvoiceControl";
            this.Size = new System.Drawing.Size(562, 346);
            this.Load += new System.EventHandler(this.PayableInvoiceControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabInvoiceInfo.ResumeLayout(false);
            this.tabInvoiceInfo.PerformLayout();
            this.tabInvoiceLines.ResumeLayout(false);
            this.tabInvoiceLines.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInvoiceInfo;
        private System.Windows.Forms.TabPage tabInvoiceLines;
        private System.Windows.Forms.Button cmdAuthorizePayment;
        private System.Windows.Forms.TextBox txtPayor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPayee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboPayableAccount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInvoiceTotalInfoTab;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInvoiceTotalLinesTab;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceLineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblStatus;
        private Loader loader;
    }
}
