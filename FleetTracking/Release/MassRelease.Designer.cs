namespace FleetTracking.Release
{
    partial class MassRelease
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
            this.dgvRailLocations = new System.Windows.Forms.DataGridView();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTrackTrain = new System.Windows.Forms.ComboBox();
            this.loader = new FleetTracking.Loader();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentPossessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewPossessor = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRailLocations)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRailLocations
            // 
            this.dgvRailLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRailLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRailLocations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.colReportingMark,
            this.colCurrentPossessor,
            this.colNewPossessor,
            this.colPosition});
            this.dgvRailLocations.Location = new System.Drawing.Point(0, 30);
            this.dgvRailLocations.Name = "dgvRailLocations";
            this.dgvRailLocations.Size = new System.Drawing.Size(706, 249);
            this.dgvRailLocations.TabIndex = 0;
            this.dgvRailLocations.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRailLocations_CellValueChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(628, 285);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(547, 285);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Track/Train:";
            // 
            // cboTrackTrain
            // 
            this.cboTrackTrain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTrackTrain.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTrackTrain.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTrackTrain.FormattingEnabled = true;
            this.cboTrackTrain.Location = new System.Drawing.Point(88, 3);
            this.cboTrackTrain.Name = "cboTrackTrain";
            this.cboTrackTrain.Size = new System.Drawing.Size(615, 21);
            this.cboTrackTrain.TabIndex = 3;
            this.cboTrackTrain.SelectedIndexChanged += new System.EventHandler(this.cboTrackTrain_SelectedIndexChanged);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(706, 311);
            this.loader.TabIndex = 4;
            this.loader.Visible = false;
            // 
            // colImage
            // 
            this.colImage.HeaderText = "Image";
            this.colImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            // 
            // colReportingMark
            // 
            this.colReportingMark.HeaderText = "Reporting Mark";
            this.colReportingMark.Name = "colReportingMark";
            this.colReportingMark.ReadOnly = true;
            this.colReportingMark.Width = 125;
            // 
            // colCurrentPossessor
            // 
            this.colCurrentPossessor.HeaderText = "Currently Released To";
            this.colCurrentPossessor.Name = "colCurrentPossessor";
            this.colCurrentPossessor.ReadOnly = true;
            this.colCurrentPossessor.Width = 150;
            // 
            // colNewPossessor
            // 
            this.colNewPossessor.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colNewPossessor.HeaderText = "Release To";
            this.colNewPossessor.Name = "colNewPossessor";
            this.colNewPossessor.Width = 150;
            // 
            // colPosition
            // 
            this.colPosition.HeaderText = "Pos";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            this.colPosition.Width = 40;
            // 
            // MassRelease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboTrackTrain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.dgvRailLocations);
            this.Controls.Add(this.loader);
            this.Name = "MassRelease";
            this.Size = new System.Drawing.Size(706, 311);
            this.Load += new System.EventHandler(this.MassRelease_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRailLocations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRailLocations;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTrackTrain;
        private Loader loader;
        private DataGridViewStylizer dataGridViewStylizer;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentPossessor;
        private System.Windows.Forms.DataGridViewComboBoxColumn colNewPossessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
    }
}
