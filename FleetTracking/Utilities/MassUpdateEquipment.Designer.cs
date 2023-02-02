namespace FleetTracking.Utilities
{
    partial class MassUpdateEquipment
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
            this.dgvEquipment = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReleaseToCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReleaseTo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDestinationCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestination = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colStrategicTrackCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStrategic = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTrackTrain = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolCheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolUncheckAll = new System.Windows.Forms.ToolStripButton();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.cboStrategicTrack = new System.Windows.Forms.ComboBox();
            this.chkStrategicTrack = new System.Windows.Forms.CheckBox();
            this.cboDestination = new System.Windows.Forms.ComboBox();
            this.chkDestination = new System.Windows.Forms.CheckBox();
            this.cboReleasedTo = new System.Windows.Forms.ComboBox();
            this.chkReleasedTo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            this.loader = new FleetTracking.Loader();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEquipment
            // 
            this.dgvEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colImage,
            this.colReportingMark,
            this.colReleaseToCurrent,
            this.colReleaseTo,
            this.colDestinationCurrent,
            this.colDestination,
            this.colStrategicTrackCurrent,
            this.colStrategic});
            this.dgvEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipment.Location = new System.Drawing.Point(0, 25);
            this.dgvEquipment.Name = "dgvEquipment";
            this.dgvEquipment.Size = new System.Drawing.Size(834, 280);
            this.dgvEquipment.TabIndex = 1;
            this.dgvEquipment.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCars_CellValueChanged);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 30;
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
            this.colReportingMark.Width = 125;
            // 
            // colReleaseToCurrent
            // 
            this.colReleaseToCurrent.HeaderText = "Currently Released To";
            this.colReleaseToCurrent.Name = "colReleaseToCurrent";
            this.colReleaseToCurrent.Width = 150;
            // 
            // colReleaseTo
            // 
            this.colReleaseTo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colReleaseTo.HeaderText = "Released To";
            this.colReleaseTo.Name = "colReleaseTo";
            this.colReleaseTo.Width = 150;
            // 
            // colDestinationCurrent
            // 
            this.colDestinationCurrent.HeaderText = "Current Destination";
            this.colDestinationCurrent.Name = "colDestinationCurrent";
            this.colDestinationCurrent.Width = 150;
            // 
            // colDestination
            // 
            this.colDestination.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colDestination.HeaderText = "Destination";
            this.colDestination.Name = "colDestination";
            this.colDestination.Width = 150;
            // 
            // colStrategicTrackCurrent
            // 
            this.colStrategicTrackCurrent.HeaderText = "Current Strategic Track";
            this.colStrategicTrackCurrent.Name = "colStrategicTrackCurrent";
            this.colStrategicTrackCurrent.Width = 150;
            // 
            // colStrategic
            // 
            this.colStrategic.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colStrategic.HeaderText = "Strategic Track";
            this.colStrategic.Name = "colStrategic";
            this.colStrategic.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Track/Train";
            // 
            // cboTrackTrain
            // 
            this.cboTrackTrain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTrackTrain.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTrackTrain.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTrackTrain.FormattingEnabled = true;
            this.cboTrackTrain.Location = new System.Drawing.Point(84, 3);
            this.cboTrackTrain.Name = "cboTrackTrain";
            this.cboTrackTrain.Size = new System.Drawing.Size(753, 21);
            this.cboTrackTrain.TabIndex = 0;
            this.cboTrackTrain.SelectedIndexChanged += new System.EventHandler(this.cboTrackTrain_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 30);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvEquipment);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.cmdSave);
            this.splitContainer1.Panel2.Controls.Add(this.cmdApply);
            this.splitContainer1.Panel2.Controls.Add(this.cboStrategicTrack);
            this.splitContainer1.Panel2.Controls.Add(this.chkStrategicTrack);
            this.splitContainer1.Panel2.Controls.Add(this.cboDestination);
            this.splitContainer1.Panel2.Controls.Add(this.chkDestination);
            this.splitContainer1.Panel2.Controls.Add(this.cboReleasedTo);
            this.splitContainer1.Panel2.Controls.Add(this.chkReleasedTo);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(834, 464);
            this.splitContainer1.SplitterDistance = 305;
            this.splitContainer1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCheckAll,
            this.toolUncheckAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(834, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolCheckAll
            // 
            this.toolCheckAll.Image = global::FleetTracking.Properties.Resources.checkall;
            this.toolCheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCheckAll.Name = "toolCheckAll";
            this.toolCheckAll.Size = new System.Drawing.Size(77, 22);
            this.toolCheckAll.Text = "Check All";
            this.toolCheckAll.Click += new System.EventHandler(this.toolCheckAll_Click);
            // 
            // toolUncheckAll
            // 
            this.toolUncheckAll.Image = global::FleetTracking.Properties.Resources.uncheckall;
            this.toolUncheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUncheckAll.Name = "toolUncheckAll";
            this.toolUncheckAll.Size = new System.Drawing.Size(90, 22);
            this.toolUncheckAll.Text = "Uncheck All";
            this.toolUncheckAll.Click += new System.EventHandler(this.toolUncheckAll_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(701, 97);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(130, 23);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "Save Changes && Close";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdApply
            // 
            this.cmdApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdApply.Location = new System.Drawing.Point(609, 97);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(86, 23);
            this.cmdApply.TabIndex = 6;
            this.cmdApply.Text = "Apply Updates";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // cboStrategicTrack
            // 
            this.cboStrategicTrack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStrategicTrack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboStrategicTrack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStrategicTrack.Enabled = false;
            this.cboStrategicTrack.FormattingEnabled = true;
            this.cboStrategicTrack.Location = new System.Drawing.Point(111, 70);
            this.cboStrategicTrack.Name = "cboStrategicTrack";
            this.cboStrategicTrack.Size = new System.Drawing.Size(720, 21);
            this.cboStrategicTrack.TabIndex = 5;
            // 
            // chkStrategicTrack
            // 
            this.chkStrategicTrack.AutoSize = true;
            this.chkStrategicTrack.Location = new System.Drawing.Point(3, 72);
            this.chkStrategicTrack.Name = "chkStrategicTrack";
            this.chkStrategicTrack.Size = new System.Drawing.Size(102, 17);
            this.chkStrategicTrack.TabIndex = 4;
            this.chkStrategicTrack.Text = "Strategic Track:";
            this.chkStrategicTrack.UseVisualStyleBackColor = true;
            this.chkStrategicTrack.CheckedChanged += new System.EventHandler(this.chkStrategicTrack_CheckedChanged);
            // 
            // cboDestination
            // 
            this.cboDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDestination.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDestination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDestination.Enabled = false;
            this.cboDestination.FormattingEnabled = true;
            this.cboDestination.Location = new System.Drawing.Point(111, 43);
            this.cboDestination.Name = "cboDestination";
            this.cboDestination.Size = new System.Drawing.Size(720, 21);
            this.cboDestination.TabIndex = 3;
            // 
            // chkDestination
            // 
            this.chkDestination.AutoSize = true;
            this.chkDestination.Location = new System.Drawing.Point(3, 45);
            this.chkDestination.Name = "chkDestination";
            this.chkDestination.Size = new System.Drawing.Size(82, 17);
            this.chkDestination.TabIndex = 2;
            this.chkDestination.Text = "Destination:";
            this.chkDestination.UseVisualStyleBackColor = true;
            this.chkDestination.CheckedChanged += new System.EventHandler(this.chkDestination_CheckedChanged);
            // 
            // cboReleasedTo
            // 
            this.cboReleasedTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReleasedTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboReleasedTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReleasedTo.Enabled = false;
            this.cboReleasedTo.FormattingEnabled = true;
            this.cboReleasedTo.Location = new System.Drawing.Point(111, 16);
            this.cboReleasedTo.Name = "cboReleasedTo";
            this.cboReleasedTo.Size = new System.Drawing.Size(720, 21);
            this.cboReleasedTo.TabIndex = 1;
            // 
            // chkReleasedTo
            // 
            this.chkReleasedTo.AutoSize = true;
            this.chkReleasedTo.Location = new System.Drawing.Point(3, 18);
            this.chkReleasedTo.Name = "chkReleasedTo";
            this.chkReleasedTo.Size = new System.Drawing.Size(90, 17);
            this.chkReleasedTo.TabIndex = 0;
            this.chkReleasedTo.Text = "Released To:";
            this.chkReleasedTo.UseVisualStyleBackColor = true;
            this.chkReleasedTo.CheckedChanged += new System.EventHandler(this.chkReleasedTo_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mass Update Details";
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(840, 494);
            this.loader.TabIndex = 4;
            this.loader.Visible = false;
            // 
            // MassUpdateEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cboTrackTrain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loader);
            this.Name = "MassUpdateEquipment";
            this.Size = new System.Drawing.Size(840, 494);
            this.Load += new System.EventHandler(this.MassUpdateRailcars_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEquipment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTrackTrain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.ComboBox cboStrategicTrack;
        private System.Windows.Forms.CheckBox chkStrategicTrack;
        private System.Windows.Forms.ComboBox cboDestination;
        private System.Windows.Forms.CheckBox chkDestination;
        private System.Windows.Forms.ComboBox cboReleasedTo;
        private System.Windows.Forms.CheckBox chkReleasedTo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolCheckAll;
        private System.Windows.Forms.ToolStripButton toolUncheckAll;
        private DataGridViewStylizer dataGridViewStylizer;
        private Loader loader;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReleaseToCurrent;
        private System.Windows.Forms.DataGridViewComboBoxColumn colReleaseTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestinationCurrent;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStrategicTrackCurrent;
        private System.Windows.Forms.DataGridViewComboBoxColumn colStrategic;
        private System.Windows.Forms.Button cmdSave;
    }
}
