﻿namespace FleetTracking.Roster
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
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loader = new FleetTracking.Loader();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdLast = new System.Windows.Forms.Button();
            this.cmdPrevious = new System.Windows.Forms.Button();
            this.cmdFirst = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocomotives)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLocomotives
            // 
            this.dgvLocomotives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocomotives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocomotives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.colReportingMark,
            this.colModel,
            this.colCurrentLocation,
            this.colOwner});
            this.dgvLocomotives.Location = new System.Drawing.Point(0, 0);
            this.dgvLocomotives.Name = "dgvLocomotives";
            this.dgvLocomotives.Size = new System.Drawing.Size(869, 303);
            this.dgvLocomotives.TabIndex = 0;
            this.dgvLocomotives.SelectionChanged += new System.EventHandler(this.dgvLocomotives_SelectionChanged);
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
            // lblRecordCount
            // 
            this.lblRecordCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.Location = new System.Drawing.Point(63, 306);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(743, 23);
            this.lblRecordCount.TabIndex = 15;
            this.lblRecordCount.Text = "Displaying 0-0 of 0";
            this.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdNext
            // 
            this.cmdNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNext.Image = global::FleetTracking.Properties.Resources.resultset_next;
            this.cmdNext.Location = new System.Drawing.Point(812, 305);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(24, 24);
            this.cmdNext.TabIndex = 13;
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdLast
            // 
            this.cmdLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLast.Image = global::FleetTracking.Properties.Resources.resultset_last;
            this.cmdLast.Location = new System.Drawing.Point(842, 305);
            this.cmdLast.Name = "cmdLast";
            this.cmdLast.Size = new System.Drawing.Size(24, 24);
            this.cmdLast.TabIndex = 14;
            this.cmdLast.UseVisualStyleBackColor = true;
            this.cmdLast.Click += new System.EventHandler(this.cmdLast_Click);
            // 
            // cmdPrevious
            // 
            this.cmdPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrevious.Image = global::FleetTracking.Properties.Resources.resultset_previous;
            this.cmdPrevious.Location = new System.Drawing.Point(33, 305);
            this.cmdPrevious.Name = "cmdPrevious";
            this.cmdPrevious.Size = new System.Drawing.Size(24, 24);
            this.cmdPrevious.TabIndex = 12;
            this.cmdPrevious.UseVisualStyleBackColor = true;
            this.cmdPrevious.Click += new System.EventHandler(this.cmdPrevious_Click);
            // 
            // cmdFirst
            // 
            this.cmdFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdFirst.Image = global::FleetTracking.Properties.Resources.resultset_first;
            this.cmdFirst.Location = new System.Drawing.Point(3, 305);
            this.cmdFirst.Name = "cmdFirst";
            this.cmdFirst.Size = new System.Drawing.Size(24, 24);
            this.cmdFirst.TabIndex = 11;
            this.cmdFirst.UseVisualStyleBackColor = true;
            this.cmdFirst.Click += new System.EventHandler(this.cmdFirst_Click);
            // 
            // LocomotiveList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.cmdLast);
            this.Controls.Add(this.cmdPrevious);
            this.Controls.Add(this.cmdFirst);
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
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdLast;
        private System.Windows.Forms.Button cmdPrevious;
        private System.Windows.Forms.Button cmdFirst;
    }
}
