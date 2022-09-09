namespace FleetTracking.LocomotiveModel
{
    partial class LocomotiveModelDetail
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.pboxImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFuelUnits = new System.Windows.Forms.Label();
            this.chkIsSteam = new System.Windows.Forms.CheckBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWater = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFuel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.loaderGeneralTab = new FleetTracking.Loader();
            this.tabLocomotives = new System.Windows.Forms.TabPage();
            this.dgvLocomotives = new System.Windows.Forms.DataGridView();
            this.loaderLocomotives = new FleetTracking.Loader();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).BeginInit();
            this.tabLocomotives.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocomotives)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabGeneral);
            this.tabControl.Controls.Add(this.tabLocomotives);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(916, 424);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.splitContainer1);
            this.tabGeneral.Controls.Add(this.loaderGeneralTab);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(908, 398);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmdUpdate);
            this.splitContainer1.Panel1.Controls.Add(this.pboxImage);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cmdReset);
            this.splitContainer1.Panel2.Controls.Add(this.cmdSave);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.lblFuelUnits);
            this.splitContainer1.Panel2.Controls.Add(this.chkIsSteam);
            this.splitContainer1.Panel2.Controls.Add(this.txtLength);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.txtWater);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.txtFuel);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.txtName);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(902, 392);
            this.splitContainer1.SplitterDistance = 326;
            this.splitContainer1.TabIndex = 0;
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpdate.Location = new System.Drawing.Point(3, 366);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(320, 23);
            this.cmdUpdate.TabIndex = 2;
            this.cmdUpdate.Text = "Update Image";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // pboxImage
            // 
            this.pboxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxImage.Location = new System.Drawing.Point(0, 16);
            this.pboxImage.Name = "pboxImage";
            this.pboxImage.Size = new System.Drawing.Size(323, 345);
            this.pboxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxImage.TabIndex = 1;
            this.pboxImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image";
            // 
            // cmdReset
            // 
            this.cmdReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReset.Location = new System.Drawing.Point(413, 366);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(75, 23);
            this.cmdReset.TabIndex = 4;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(494, 366);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(524, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "meters";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(524, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "buckets";
            // 
            // lblFuelUnits
            // 
            this.lblFuelUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFuelUnits.AutoSize = true;
            this.lblFuelUnits.Location = new System.Drawing.Point(524, 55);
            this.lblFuelUnits.Name = "lblFuelUnits";
            this.lblFuelUnits.Size = new System.Drawing.Size(45, 13);
            this.lblFuelUnits.TabIndex = 3;
            this.lblFuelUnits.Text = "buckets";
            // 
            // chkIsSteam
            // 
            this.chkIsSteam.AutoSize = true;
            this.chkIsSteam.Location = new System.Drawing.Point(6, 29);
            this.chkIsSteam.Name = "chkIsSteam";
            this.chkIsSteam.Size = new System.Drawing.Size(103, 17);
            this.chkIsSteam.TabIndex = 2;
            this.chkIsSteam.Text = "Is Steam Engine";
            this.chkIsSteam.UseVisualStyleBackColor = true;
            this.chkIsSteam.CheckedChanged += new System.EventHandler(this.chkIsSteam_CheckedChanged);
            // 
            // txtLength
            // 
            this.txtLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLength.Location = new System.Drawing.Point(92, 104);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(426, 20);
            this.txtLength.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Length:";
            // 
            // txtWater
            // 
            this.txtWater.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWater.Location = new System.Drawing.Point(92, 78);
            this.txtWater.Name = "txtWater";
            this.txtWater.Size = new System.Drawing.Size(426, 20);
            this.txtWater.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Water Capacity:";
            // 
            // txtFuel
            // 
            this.txtFuel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFuel.Location = new System.Drawing.Point(92, 52);
            this.txtFuel.Name = "txtFuel";
            this.txtFuel.Size = new System.Drawing.Size(426, 20);
            this.txtFuel.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fuel Capacity:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(92, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(477, 20);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // loaderGeneralTab
            // 
            this.loaderGeneralTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loaderGeneralTab.BackColor = System.Drawing.Color.Transparent;
            this.loaderGeneralTab.Location = new System.Drawing.Point(0, 0);
            this.loaderGeneralTab.Name = "loaderGeneralTab";
            this.loaderGeneralTab.Size = new System.Drawing.Size(906, 395);
            this.loaderGeneralTab.TabIndex = 1;
            this.loaderGeneralTab.Visible = false;
            // 
            // tabLocomotives
            // 
            this.tabLocomotives.Controls.Add(this.dgvLocomotives);
            this.tabLocomotives.Controls.Add(this.loaderLocomotives);
            this.tabLocomotives.Location = new System.Drawing.Point(4, 22);
            this.tabLocomotives.Name = "tabLocomotives";
            this.tabLocomotives.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocomotives.Size = new System.Drawing.Size(908, 398);
            this.tabLocomotives.TabIndex = 1;
            this.tabLocomotives.Text = "Locomotives";
            this.tabLocomotives.UseVisualStyleBackColor = true;
            // 
            // dgvLocomotives
            // 
            this.dgvLocomotives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocomotives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.colReportingMark,
            this.colOwner});
            this.dgvLocomotives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLocomotives.Location = new System.Drawing.Point(3, 3);
            this.dgvLocomotives.Name = "dgvLocomotives";
            this.dgvLocomotives.Size = new System.Drawing.Size(902, 392);
            this.dgvLocomotives.TabIndex = 1;
            // 
            // loaderLocomotives
            // 
            this.loaderLocomotives.BackColor = System.Drawing.Color.Transparent;
            this.loaderLocomotives.Location = new System.Drawing.Point(0, 0);
            this.loaderLocomotives.Name = "loaderLocomotives";
            this.loaderLocomotives.Size = new System.Drawing.Size(908, 399);
            this.loaderLocomotives.TabIndex = 0;
            this.loaderLocomotives.Visible = false;
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
            this.colReportingMark.Width = 130;
            // 
            // colOwner
            // 
            this.colOwner.HeaderText = "Owner";
            this.colOwner.Name = "colOwner";
            this.colOwner.Width = 300;
            // 
            // LocomotiveModelDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "LocomotiveModelDetail";
            this.Size = new System.Drawing.Size(916, 424);
            this.Load += new System.EventHandler(this.LocomotiveModelDetail_Load);
            this.tabControl.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).EndInit();
            this.tabLocomotives.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocomotives)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabLocomotives;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.PictureBox pboxImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFuelUnits;
        private System.Windows.Forms.CheckBox chkIsSteam;
        private System.Windows.Forms.TextBox txtWater;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFuel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSave;
        private Loader loaderGeneralTab;
        private Loader loaderLocomotives;
        private System.Windows.Forms.DataGridView dgvLocomotives;
        private DataGridViewStylizer dataGridViewStylizer;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOwner;
    }
}
