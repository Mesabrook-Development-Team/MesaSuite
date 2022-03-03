namespace CompanyStudio.CompanyForms
{
    partial class LocationGovernments
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
            this.dgvGovernments = new System.Windows.Forms.DataGridView();
            this.colLocationGovernmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGovernment = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colHasSalesTax = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.loader = new CompanyStudio.Loader();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGovernments)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGovernments
            // 
            this.dgvGovernments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGovernments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLocationGovernmentID,
            this.colGovernment,
            this.colHasSalesTax});
            this.dgvGovernments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGovernments.Location = new System.Drawing.Point(0, 0);
            this.dgvGovernments.Name = "dgvGovernments";
            this.dgvGovernments.Size = new System.Drawing.Size(649, 248);
            this.dgvGovernments.TabIndex = 0;
            // 
            // colLocationGovernmentID
            // 
            this.colLocationGovernmentID.HeaderText = "";
            this.colLocationGovernmentID.Name = "colLocationGovernmentID";
            this.colLocationGovernmentID.Visible = false;
            // 
            // colGovernment
            // 
            this.colGovernment.HeaderText = "Government";
            this.colGovernment.Name = "colGovernment";
            // 
            // colHasSalesTax
            // 
            this.colHasSalesTax.HeaderText = "Sales Tax";
            this.colHasSalesTax.Name = "colHasSalesTax";
            this.colHasSalesTax.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(649, 248);
            this.loader.TabIndex = 1;
            this.loader.Visible = false;
            // 
            // LocationGovernments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvGovernments);
            this.Controls.Add(this.loader);
            this.Name = "LocationGovernments";
            this.Size = new System.Drawing.Size(649, 248);
            this.Load += new System.EventHandler(this.LocationGovernments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGovernments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGovernments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocationGovernmentID;
        private System.Windows.Forms.DataGridViewComboBoxColumn colGovernment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colHasSalesTax;
        private Loader loader;
    }
}
