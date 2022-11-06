namespace FleetTracking.Leasing
{
    partial class LeaseContracts
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
            this.dgvContracts = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoCurrent = new System.Windows.Forms.RadioButton();
            this.rdoHistoric = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.loader = new FleetTracking.Loader();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeasedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeaseStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeaseEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContracts
            // 
            this.dgvContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContracts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.colReportingMark,
            this.colLeasedTo,
            this.colLeaseStart,
            this.colLeaseEnd});
            this.dgvContracts.Location = new System.Drawing.Point(0, 0);
            this.dgvContracts.Name = "dgvContracts";
            this.dgvContracts.Size = new System.Drawing.Size(862, 396);
            this.dgvContracts.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter";
            // 
            // rdoCurrent
            // 
            this.rdoCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoCurrent.AutoSize = true;
            this.rdoCurrent.Checked = true;
            this.rdoCurrent.Location = new System.Drawing.Point(44, 402);
            this.rdoCurrent.Name = "rdoCurrent";
            this.rdoCurrent.Size = new System.Drawing.Size(59, 17);
            this.rdoCurrent.TabIndex = 2;
            this.rdoCurrent.TabStop = true;
            this.rdoCurrent.Text = "Current";
            this.rdoCurrent.UseVisualStyleBackColor = true;
            this.rdoCurrent.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // rdoHistoric
            // 
            this.rdoHistoric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoHistoric.AutoSize = true;
            this.rdoHistoric.Location = new System.Drawing.Point(109, 402);
            this.rdoHistoric.Name = "rdoHistoric";
            this.rdoHistoric.Size = new System.Drawing.Size(68, 17);
            this.rdoHistoric.TabIndex = 2;
            this.rdoHistoric.Text = "Historical";
            this.rdoHistoric.UseVisualStyleBackColor = true;
            this.rdoHistoric.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // rdoAll
            // 
            this.rdoAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(183, 402);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 2;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(862, 422);
            this.loader.TabIndex = 3;
            this.loader.Visible = false;
            // 
            // colImage
            // 
            this.colImage.HeaderText = "Image";
            this.colImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colImage.Name = "colImage";
            // 
            // colReportingMark
            // 
            this.colReportingMark.HeaderText = "Reporting Mark";
            this.colReportingMark.Name = "colReportingMark";
            this.colReportingMark.Width = 120;
            // 
            // colLeasedTo
            // 
            this.colLeasedTo.HeaderText = "Leased To";
            this.colLeasedTo.Name = "colLeasedTo";
            this.colLeasedTo.Width = 140;
            // 
            // colLeaseStart
            // 
            this.colLeaseStart.HeaderText = "Lease Start Date";
            this.colLeaseStart.Name = "colLeaseStart";
            this.colLeaseStart.Width = 120;
            // 
            // colLeaseEnd
            // 
            this.colLeaseEnd.HeaderText = "Lease End Date";
            this.colLeaseEnd.Name = "colLeaseEnd";
            this.colLeaseEnd.Width = 120;
            // 
            // LeaseContracts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdoAll);
            this.Controls.Add(this.rdoHistoric);
            this.Controls.Add(this.rdoCurrent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvContracts);
            this.Controls.Add(this.loader);
            this.Name = "LeaseContracts";
            this.Size = new System.Drawing.Size(862, 422);
            this.Load += new System.EventHandler(this.LeaseContracts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContracts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoCurrent;
        private System.Windows.Forms.RadioButton rdoHistoric;
        private System.Windows.Forms.RadioButton rdoAll;
        private Loader loader;
        private DataGridViewStylizer dataGridViewStylizer;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeasedTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeaseStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeaseEnd;
    }
}
