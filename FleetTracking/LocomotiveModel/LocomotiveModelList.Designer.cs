namespace FleetTracking.LocomotiveModel
{
    partial class LocomotiveModelList
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
            this.dgvLocomotiveModels = new System.Windows.Forms.DataGridView();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSteamPowered = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.loader = new FleetTracking.Loader();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocomotiveModels)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLocomotiveModels
            // 
            this.dgvLocomotiveModels.AllowUserToAddRows = false;
            this.dgvLocomotiveModels.AllowUserToDeleteRows = false;
            this.dgvLocomotiveModels.AllowUserToOrderColumns = true;
            this.dgvLocomotiveModels.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocomotiveModels.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocomotiveModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocomotiveModels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.colName,
            this.colLength,
            this.colSteamPowered});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocomotiveModels.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocomotiveModels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLocomotiveModels.Location = new System.Drawing.Point(0, 0);
            this.dgvLocomotiveModels.MultiSelect = false;
            this.dgvLocomotiveModels.Name = "dgvLocomotiveModels";
            this.dgvLocomotiveModels.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocomotiveModels.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLocomotiveModels.RowHeadersVisible = false;
            this.dgvLocomotiveModels.RowHeadersWidth = 62;
            this.dgvLocomotiveModels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocomotiveModels.Size = new System.Drawing.Size(701, 260);
            this.dgvLocomotiveModels.TabIndex = 0;
            this.dgvLocomotiveModels.SelectionChanged += new System.EventHandler(this.dgvLocomotiveModels_SelectionChanged);
            // 
            // colImage
            // 
            this.colImage.HeaderText = "Image";
            this.colImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colImage.MinimumWidth = 8;
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            this.colImage.Width = 150;
            // 
            // colName
            // 
            this.colName.HeaderText = "Model";
            this.colName.MinimumWidth = 8;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colName.Width = 200;
            // 
            // colLength
            // 
            this.colLength.HeaderText = "Length";
            this.colLength.MinimumWidth = 8;
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Width = 150;
            // 
            // colSteamPowered
            // 
            this.colSteamPowered.HeaderText = "Steam Powered";
            this.colSteamPowered.MinimumWidth = 8;
            this.colSteamPowered.Name = "colSteamPowered";
            this.colSteamPowered.ReadOnly = true;
            this.colSteamPowered.Width = 120;
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
            this.loader.Size = new System.Drawing.Size(701, 260);
            this.loader.TabIndex = 1;
            this.loader.Visible = false;
            // 
            // LocomotiveModelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvLocomotiveModels);
            this.Controls.Add(this.loader);
            this.Name = "LocomotiveModelList";
            this.Size = new System.Drawing.Size(701, 260);
            this.Load += new System.EventHandler(this.LocomotiveModelList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocomotiveModels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLocomotiveModels;
        private Loader loader;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSteamPowered;
    }
}
