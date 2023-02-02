namespace FleetTracking.Leasing
{
    partial class LeaseContractDetails
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pboxImage = new System.Windows.Forms.PictureBox();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkReportingMark = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.txtTerms = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboChargedTo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPaidTo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRecurring = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRecurringAmount = new System.Windows.Forms.TextBox();
            this.txtInitialAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLessee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.loader = new FleetTracking.Loader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.colIssued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(766, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rolling Stock";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pboxImage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtOwner);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.lnkReportingMark);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(760, 101);
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.TabIndex = 0;
            // 
            // pboxImage
            // 
            this.pboxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pboxImage.Location = new System.Drawing.Point(0, 0);
            this.pboxImage.Name = "pboxImage";
            this.pboxImage.Size = new System.Drawing.Size(208, 101);
            this.pboxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxImage.TabIndex = 0;
            this.pboxImage.TabStop = false;
            // 
            // txtOwner
            // 
            this.txtOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwner.Location = new System.Drawing.Point(95, 48);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.ReadOnly = true;
            this.txtOwner.Size = new System.Drawing.Size(450, 20);
            this.txtOwner.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Owner:";
            // 
            // lnkReportingMark
            // 
            this.lnkReportingMark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lnkReportingMark.AutoSize = true;
            this.lnkReportingMark.Location = new System.Drawing.Point(92, 32);
            this.lnkReportingMark.Name = "lnkReportingMark";
            this.lnkReportingMark.Size = new System.Drawing.Size(0, 13);
            this.lnkReportingMark.TabIndex = 0;
            this.lnkReportingMark.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReportingMark_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reporting Mark:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dtpEnd);
            this.groupBox2.Controls.Add(this.dtpStart);
            this.groupBox2.Controls.Add(this.txtTerms);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cboChargedTo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cboPaidTo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtRecurring);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtRecurringAmount);
            this.groupBox2.Controls.Add(this.txtInitialAmount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtLessee);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(0, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(766, 277);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contract";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEnd.CustomFormat = "dddd MM/dd/yyyy HH:mm";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(361, 151);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(399, 20);
            this.dtpEnd.TabIndex = 7;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "dddd MM/dd/yyyy HH:mm";
            this.dtpStart.Enabled = false;
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(85, 151);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(203, 20);
            this.dtpStart.TabIndex = 6;
            // 
            // txtTerms
            // 
            this.txtTerms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTerms.Location = new System.Drawing.Point(6, 196);
            this.txtTerms.Multiline = true;
            this.txtTerms.Name = "txtTerms";
            this.txtTerms.ReadOnly = true;
            this.txtTerms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTerms.Size = new System.Drawing.Size(751, 75);
            this.txtTerms.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Terms:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(294, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Lease End:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Lease Start:";
            // 
            // cboChargedTo
            // 
            this.cboChargedTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboChargedTo.FormattingEnabled = true;
            this.cboChargedTo.Location = new System.Drawing.Point(127, 124);
            this.cboChargedTo.Name = "cboChargedTo";
            this.cboChargedTo.Size = new System.Drawing.Size(633, 21);
            this.cboChargedTo.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Recurring Charged To:";
            // 
            // cboPaidTo
            // 
            this.cboPaidTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPaidTo.FormattingEnabled = true;
            this.cboPaidTo.Location = new System.Drawing.Point(127, 97);
            this.cboPaidTo.Name = "cboPaidTo";
            this.cboPaidTo.Size = new System.Drawing.Size(633, 21);
            this.cboPaidTo.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Recurring Paid To:";
            // 
            // txtRecurring
            // 
            this.txtRecurring.Location = new System.Drawing.Point(85, 71);
            this.txtRecurring.Name = "txtRecurring";
            this.txtRecurring.ReadOnly = true;
            this.txtRecurring.Size = new System.Drawing.Size(102, 20);
            this.txtRecurring.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Recurring?";
            // 
            // txtRecurringAmount
            // 
            this.txtRecurringAmount.Location = new System.Drawing.Point(294, 71);
            this.txtRecurringAmount.Name = "txtRecurringAmount";
            this.txtRecurringAmount.ReadOnly = true;
            this.txtRecurringAmount.Size = new System.Drawing.Size(102, 20);
            this.txtRecurringAmount.TabIndex = 3;
            // 
            // txtInitialAmount
            // 
            this.txtInitialAmount.Location = new System.Drawing.Point(85, 45);
            this.txtInitialAmount.Name = "txtInitialAmount";
            this.txtInitialAmount.ReadOnly = true;
            this.txtInitialAmount.Size = new System.Drawing.Size(102, 20);
            this.txtInitialAmount.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Recurring Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Initial Amount:";
            // 
            // txtLessee
            // 
            this.txtLessee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLessee.Location = new System.Drawing.Point(85, 19);
            this.txtLessee.Name = "txtLessee";
            this.txtLessee.ReadOnly = true;
            this.txtLessee.Size = new System.Drawing.Size(675, 20);
            this.txtLessee.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Lessee:";
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(682, 550);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReset.Location = new System.Drawing.Point(601, 550);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(75, 23);
            this.cmdReset.TabIndex = 4;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(766, 578);
            this.loader.TabIndex = 4;
            this.loader.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvInvoices);
            this.groupBox3.Location = new System.Drawing.Point(0, 400);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(766, 144);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Invoices";
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIssued,
            this.colType,
            this.colAmount});
            this.dgvInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoices.Location = new System.Drawing.Point(3, 16);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.Size = new System.Drawing.Size(760, 125);
            this.dgvInvoices.TabIndex = 0;
            // 
            // colIssued
            // 
            this.colIssued.HeaderText = "Issued";
            this.colIssued.Name = "colIssued";
            // 
            // colType
            // 
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            // 
            // LeaseContractDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loader);
            this.Name = "LeaseContractDetails";
            this.Size = new System.Drawing.Size(766, 578);
            this.Load += new System.EventHandler(this.LeaseContractDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pboxImage;
        private System.Windows.Forms.LinkLabel lnkReportingMark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLessee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInitialAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRecurring;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRecurringAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboPaidTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboChargedTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTerms;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdReset;
        private Loader loader;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssued;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private DataGridViewStylizer dataGridViewStylizer;
    }
}
