namespace GovernmentPortal.Accounts
{
    partial class AccountExplorerControl
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabTransactions = new System.Windows.Forms.TabPage();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdTransNext = new System.Windows.Forms.Button();
            this.cmdTransLast = new System.Windows.Forms.Button();
            this.cmdTransPrev = new System.Windows.Forms.Button();
            this.cmdTransFirst = new System.Windows.Forms.Button();
            this.tabFiscalQuarters = new System.Windows.Forms.TabPage();
            this.dgvFiscalQuarters = new System.Windows.Forms.DataGridView();
            this.colYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuarter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartBal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNetChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNetPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdTransfer = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.loader = new GovernmentPortal.Loader();
            this.tabControl.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.tabFiscalQuarters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiscalQuarters)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabDetails);
            this.tabControl.Controls.Add(this.tabTransactions);
            this.tabControl.Controls.Add(this.tabFiscalQuarters);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(591, 262);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.cboCategory);
            this.tabDetails.Controls.Add(this.txtBalance);
            this.tabDetails.Controls.Add(this.label4);
            this.tabDetails.Controls.Add(this.label3);
            this.tabDetails.Controls.Add(this.txtDescription);
            this.tabDetails.Controls.Add(this.label2);
            this.tabDetails.Controls.Add(this.txtAccountNumber);
            this.tabDetails.Controls.Add(this.label1);
            this.tabDetails.Location = new System.Drawing.Point(4, 22);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(583, 236);
            this.tabDetails.TabIndex = 0;
            this.tabDetails.Text = "Details";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(102, 58);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(475, 21);
            this.cboCategory.TabIndex = 2;
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(102, 84);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(475, 20);
            this.txtBalance.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Balance:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Category:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(102, 32);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(475, 20);
            this.txtDescription.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Description:";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(102, 6);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.ReadOnly = true;
            this.txtAccountNumber.Size = new System.Drawing.Size(475, 20);
            this.txtAccountNumber.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Number:";
            // 
            // tabTransactions
            // 
            this.tabTransactions.Controls.Add(this.dgvTransactions);
            this.tabTransactions.Controls.Add(this.cmdTransNext);
            this.tabTransactions.Controls.Add(this.cmdTransLast);
            this.tabTransactions.Controls.Add(this.cmdTransPrev);
            this.tabTransactions.Controls.Add(this.cmdTransFirst);
            this.tabTransactions.Location = new System.Drawing.Point(4, 22);
            this.tabTransactions.Name = "tabTransactions";
            this.tabTransactions.Size = new System.Drawing.Size(583, 236);
            this.tabTransactions.TabIndex = 2;
            this.tabTransactions.Text = "Transactions";
            this.tabTransactions.UseVisualStyleBackColor = true;
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colAmount,
            this.colDescription});
            this.dgvTransactions.Location = new System.Drawing.Point(0, -1);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(583, 202);
            this.dgvTransactions.TabIndex = 6;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Date/Time";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 375;
            // 
            // cmdTransNext
            // 
            this.cmdTransNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTransNext.Enabled = false;
            this.cmdTransNext.Location = new System.Drawing.Point(516, 207);
            this.cmdTransNext.Name = "cmdTransNext";
            this.cmdTransNext.Size = new System.Drawing.Size(29, 23);
            this.cmdTransNext.TabIndex = 4;
            this.cmdTransNext.Text = ">";
            this.cmdTransNext.UseVisualStyleBackColor = true;
            // 
            // cmdTransLast
            // 
            this.cmdTransLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTransLast.Enabled = false;
            this.cmdTransLast.Location = new System.Drawing.Point(551, 207);
            this.cmdTransLast.Name = "cmdTransLast";
            this.cmdTransLast.Size = new System.Drawing.Size(29, 23);
            this.cmdTransLast.TabIndex = 5;
            this.cmdTransLast.Text = ">>";
            this.cmdTransLast.UseVisualStyleBackColor = true;
            // 
            // cmdTransPrev
            // 
            this.cmdTransPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdTransPrev.Enabled = false;
            this.cmdTransPrev.Location = new System.Drawing.Point(38, 207);
            this.cmdTransPrev.Name = "cmdTransPrev";
            this.cmdTransPrev.Size = new System.Drawing.Size(29, 23);
            this.cmdTransPrev.TabIndex = 2;
            this.cmdTransPrev.Text = "<";
            this.cmdTransPrev.UseVisualStyleBackColor = true;
            // 
            // cmdTransFirst
            // 
            this.cmdTransFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdTransFirst.Enabled = false;
            this.cmdTransFirst.Location = new System.Drawing.Point(3, 207);
            this.cmdTransFirst.Name = "cmdTransFirst";
            this.cmdTransFirst.Size = new System.Drawing.Size(29, 23);
            this.cmdTransFirst.TabIndex = 3;
            this.cmdTransFirst.Text = "<<";
            this.cmdTransFirst.UseVisualStyleBackColor = true;
            // 
            // tabFiscalQuarters
            // 
            this.tabFiscalQuarters.Controls.Add(this.dgvFiscalQuarters);
            this.tabFiscalQuarters.Location = new System.Drawing.Point(4, 22);
            this.tabFiscalQuarters.Name = "tabFiscalQuarters";
            this.tabFiscalQuarters.Padding = new System.Windows.Forms.Padding(3);
            this.tabFiscalQuarters.Size = new System.Drawing.Size(583, 236);
            this.tabFiscalQuarters.TabIndex = 1;
            this.tabFiscalQuarters.Text = "Fiscal Quarters";
            this.tabFiscalQuarters.UseVisualStyleBackColor = true;
            // 
            // dgvFiscalQuarters
            // 
            this.dgvFiscalQuarters.AllowUserToAddRows = false;
            this.dgvFiscalQuarters.AllowUserToDeleteRows = false;
            this.dgvFiscalQuarters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFiscalQuarters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiscalQuarters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colYear,
            this.colQuarter,
            this.colStartDate,
            this.colEndDate,
            this.colStartBal,
            this.colEndBalance,
            this.colNetChange,
            this.colNetPercent});
            this.dgvFiscalQuarters.Location = new System.Drawing.Point(0, 0);
            this.dgvFiscalQuarters.Name = "dgvFiscalQuarters";
            this.dgvFiscalQuarters.ReadOnly = true;
            this.dgvFiscalQuarters.RowHeadersVisible = false;
            this.dgvFiscalQuarters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiscalQuarters.Size = new System.Drawing.Size(583, 236);
            this.dgvFiscalQuarters.TabIndex = 3;
            // 
            // colYear
            // 
            this.colYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colYear.HeaderText = "Year";
            this.colYear.Name = "colYear";
            this.colYear.ReadOnly = true;
            this.colYear.Width = 54;
            // 
            // colQuarter
            // 
            this.colQuarter.HeaderText = "Quarter";
            this.colQuarter.Name = "colQuarter";
            this.colQuarter.ReadOnly = true;
            this.colQuarter.Width = 30;
            // 
            // colStartDate
            // 
            this.colStartDate.HeaderText = "Start Date";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.ReadOnly = true;
            // 
            // colEndDate
            // 
            this.colEndDate.HeaderText = "End Date";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.ReadOnly = true;
            // 
            // colStartBal
            // 
            this.colStartBal.HeaderText = "Starting Balance";
            this.colStartBal.Name = "colStartBal";
            this.colStartBal.ReadOnly = true;
            // 
            // colEndBalance
            // 
            this.colEndBalance.HeaderText = "Ending Balance";
            this.colEndBalance.Name = "colEndBalance";
            this.colEndBalance.ReadOnly = true;
            // 
            // colNetChange
            // 
            this.colNetChange.HeaderText = "Net Change";
            this.colNetChange.Name = "colNetChange";
            this.colNetChange.ReadOnly = true;
            // 
            // colNetPercent
            // 
            this.colNetPercent.HeaderText = "Net Percent";
            this.colNetPercent.Name = "colNetPercent";
            this.colNetPercent.ReadOnly = true;
            this.colNetPercent.Width = 90;
            // 
            // cmdTransfer
            // 
            this.cmdTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTransfer.Location = new System.Drawing.Point(497, 268);
            this.cmdTransfer.Name = "cmdTransfer";
            this.cmdTransfer.Size = new System.Drawing.Size(87, 23);
            this.cmdTransfer.TabIndex = 1;
            this.cmdTransfer.Text = "Transfer Funds";
            this.cmdTransfer.UseVisualStyleBackColor = true;
            this.cmdTransfer.Click += new System.EventHandler(this.cmdTransfer_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.Color.Red;
            this.cmdClose.Location = new System.Drawing.Point(4, 268);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(102, 23);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "Close Account";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(591, 294);
            this.loader.TabIndex = 3;
            this.loader.Visible = false;
            // 
            // AccountExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdTransfer);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.loader);
            this.Name = "AccountExplorerControl";
            this.Size = new System.Drawing.Size(591, 294);
            this.Load += new System.EventHandler(this.AccountExplorerControl_Load);
            this.tabControl.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            this.tabTransactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.tabFiscalQuarters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiscalQuarters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.TabPage tabTransactions;
        private System.Windows.Forms.TabPage tabFiscalQuarters;
        private System.Windows.Forms.Button cmdTransfer;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label label1;
        private Loader loader;
        private System.Windows.Forms.Button cmdTransPrev;
        private System.Windows.Forms.Button cmdTransFirst;
        private System.Windows.Forms.Button cmdTransNext;
        private System.Windows.Forms.Button cmdTransLast;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridView dgvFiscalQuarters;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuarter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartBal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNetChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNetPercent;
    }
}
