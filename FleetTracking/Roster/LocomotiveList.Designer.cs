namespace FleetTracking.Roster
{
    partial class LocomotiveList
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
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            this.dgvLocomotives = new System.Windows.Forms.DataGridView();
            this.loader = new FleetTracking.Loader();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocomotives)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLocomotives
            // 
            this.dgvLocomotives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocomotives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.colReportingMark,
            this.colModel,
            this.colCurrentLocation,
            this.colOwner});
            this.dgvLocomotives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLocomotives.Location = new System.Drawing.Point(0, 0);
            this.dgvLocomotives.Name = "dgvLocomotives";
            this.dgvLocomotives.Size = new System.Drawing.Size(869, 332);
            this.dgvLocomotives.TabIndex = 0;
            this.dgvLocomotives.SelectionChanged += new System.EventHandler(this.dgvLocomotives_SelectionChanged);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(869, 332);
            this.loader.TabIndex = 1;
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
            // 
            // colModel
            // 
            this.colModel.HeaderText = "Model";
            this.colModel.Name = "colModel";
            // 
            // colCurrentLocation
            // 
            this.colCurrentLocation.HeaderText = "Current Location";
            this.colCurrentLocation.Name = "colCurrentLocation";
            this.colCurrentLocation.Width = 300;
            // 
            // colOwner
            // 
            this.colOwner.HeaderText = "Owner";
            this.colOwner.Name = "colOwner";
            this.colOwner.Width = 150;
            // 
            // LocomotiveList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvLocomotives);
            this.Controls.Add(this.loader);
            this.Name = "LocomotiveList";
            this.Size = new System.Drawing.Size(869, 332);
            this.Load += new System.EventHandler(this.LocomotiveList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocomotives)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewStylizer dataGridViewStylizer;
        private System.Windows.Forms.DataGridView dgvLocomotives;
        private Loader loader;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOwner;
    }
}
