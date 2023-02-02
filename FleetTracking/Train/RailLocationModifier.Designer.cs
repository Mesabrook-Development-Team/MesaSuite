namespace FleetTracking.Train
{
    partial class RailLocationModifier
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmdMoveDown = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdMoveUp = new System.Windows.Forms.Button();
            this.dgvFromList = new System.Windows.Forms.DataGridView();
            this.colFromImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colFromReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromPossession = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromDestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromStrategic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlFrom = new System.Windows.Forms.TabControl();
            this.tabTrackFrom = new System.Windows.Forms.TabPage();
            this.cboFromTrack = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFromDistrict = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabTrainFrom = new System.Windows.Forms.TabPage();
            this.cboFromTrain = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboFromSymbol = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.loaderFrom = new FleetTracking.Loader();
            this.dgvToList = new System.Windows.Forms.DataGridView();
            this.colToImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colToReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToPossession = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToDestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToStrategic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlTo = new System.Windows.Forms.TabControl();
            this.tabTrackTo = new System.Windows.Forms.TabPage();
            this.cboToTrack = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboToDistrict = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabTrainTo = new System.Windows.Forms.TabPage();
            this.cboToTrain = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboToSymbol = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.loaderTo = new FleetTracking.Loader();
            this.loaderFull = new FleetTracking.Loader();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFromList)).BeginInit();
            this.tabControlFrom.SuspendLayout();
            this.tabTrackFrom.SuspendLayout();
            this.tabTrainFrom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToList)).BeginInit();
            this.tabControlTo.SuspendLayout();
            this.tabTrackTo.SuspendLayout();
            this.tabTrainTo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time Moved:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CustomFormat = "dddd MM/dd/yyyy HH:mm";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(89, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(784, 22);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 29);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmdMoveDown);
            this.splitContainer1.Panel1.Controls.Add(this.cmdRemove);
            this.splitContainer1.Panel1.Controls.Add(this.cmdAdd);
            this.splitContainer1.Panel1.Controls.Add(this.cmdMoveUp);
            this.splitContainer1.Panel1.Controls.Add(this.dgvFromList);
            this.splitContainer1.Panel1.Controls.Add(this.tabControlFrom);
            this.splitContainer1.Panel1.Controls.Add(this.loaderFrom);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvToList);
            this.splitContainer1.Panel2.Controls.Add(this.tabControlTo);
            this.splitContainer1.Panel2.Controls.Add(this.loaderTo);
            this.splitContainer1.Size = new System.Drawing.Size(876, 555);
            this.splitContainer1.SplitterDistance = 411;
            this.splitContainer1.TabIndex = 2;
            // 
            // cmdMoveDown
            // 
            this.cmdMoveDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdMoveDown.BackgroundImage = global::FleetTracking.Properties.Resources.arrow_down;
            this.cmdMoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdMoveDown.Location = new System.Drawing.Point(366, 318);
            this.cmdMoveDown.Name = "cmdMoveDown";
            this.cmdMoveDown.Size = new System.Drawing.Size(32, 32);
            this.cmdMoveDown.TabIndex = 2;
            this.cmdMoveDown.UseVisualStyleBackColor = true;
            this.cmdMoveDown.Click += new System.EventHandler(this.cmdMoveDown_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdRemove.BackgroundImage = global::FleetTracking.Properties.Resources.arrow_left;
            this.cmdRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRemove.Location = new System.Drawing.Point(366, 280);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(32, 32);
            this.cmdRemove.TabIndex = 2;
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdAdd.BackgroundImage = global::FleetTracking.Properties.Resources.arrow_right;
            this.cmdAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdAdd.Location = new System.Drawing.Point(366, 242);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(32, 32);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdMoveUp
            // 
            this.cmdMoveUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdMoveUp.BackgroundImage = global::FleetTracking.Properties.Resources.arrow_up;
            this.cmdMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdMoveUp.Location = new System.Drawing.Point(366, 204);
            this.cmdMoveUp.Name = "cmdMoveUp";
            this.cmdMoveUp.Size = new System.Drawing.Size(32, 32);
            this.cmdMoveUp.TabIndex = 2;
            this.cmdMoveUp.UseVisualStyleBackColor = true;
            this.cmdMoveUp.Click += new System.EventHandler(this.cmdMoveUp_Click);
            // 
            // dgvFromList
            // 
            this.dgvFromList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFromList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFromList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFromImage,
            this.colFromReportingMark,
            this.colFromType,
            this.colFromPossession,
            this.colFromPos,
            this.colFromDestination,
            this.colFromStrategic});
            this.dgvFromList.Location = new System.Drawing.Point(0, 89);
            this.dgvFromList.Name = "dgvFromList";
            this.dgvFromList.Size = new System.Drawing.Size(360, 463);
            this.dgvFromList.TabIndex = 1;
            this.dgvFromList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            // 
            // colFromImage
            // 
            this.colFromImage.HeaderText = "Image";
            this.colFromImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colFromImage.Name = "colFromImage";
            // 
            // colFromReportingMark
            // 
            this.colFromReportingMark.HeaderText = "Reporting Mark";
            this.colFromReportingMark.Name = "colFromReportingMark";
            // 
            // colFromType
            // 
            this.colFromType.HeaderText = "Type";
            this.colFromType.Name = "colFromType";
            // 
            // colFromPossession
            // 
            this.colFromPossession.HeaderText = "Possesed By";
            this.colFromPossession.Name = "colFromPossession";
            // 
            // colFromPos
            // 
            this.colFromPos.HeaderText = "Pos";
            this.colFromPos.Name = "colFromPos";
            this.colFromPos.Width = 40;
            // 
            // colFromDestination
            // 
            this.colFromDestination.HeaderText = "Destination";
            this.colFromDestination.Name = "colFromDestination";
            // 
            // colFromStrategic
            // 
            this.colFromStrategic.HeaderText = "Strategic Dest";
            this.colFromStrategic.Name = "colFromStrategic";
            // 
            // tabControlFrom
            // 
            this.tabControlFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlFrom.Controls.Add(this.tabTrackFrom);
            this.tabControlFrom.Controls.Add(this.tabTrainFrom);
            this.tabControlFrom.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlFrom.Location = new System.Drawing.Point(0, 0);
            this.tabControlFrom.Name = "tabControlFrom";
            this.tabControlFrom.SelectedIndex = 0;
            this.tabControlFrom.Size = new System.Drawing.Size(408, 87);
            this.tabControlFrom.TabIndex = 0;
            this.tabControlFrom.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlFrom_Selected);
            // 
            // tabTrackFrom
            // 
            this.tabTrackFrom.Controls.Add(this.cboFromTrack);
            this.tabTrackFrom.Controls.Add(this.label3);
            this.tabTrackFrom.Controls.Add(this.cboFromDistrict);
            this.tabTrackFrom.Controls.Add(this.label2);
            this.tabTrackFrom.Location = new System.Drawing.Point(4, 22);
            this.tabTrackFrom.Name = "tabTrackFrom";
            this.tabTrackFrom.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrackFrom.Size = new System.Drawing.Size(400, 61);
            this.tabTrackFrom.TabIndex = 0;
            this.tabTrackFrom.Text = "Track";
            this.tabTrackFrom.UseVisualStyleBackColor = true;
            // 
            // cboFromTrack
            // 
            this.cboFromTrack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFromTrack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFromTrack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFromTrack.FormattingEnabled = true;
            this.cboFromTrack.Location = new System.Drawing.Point(48, 33);
            this.cboFromTrack.Name = "cboFromTrack";
            this.cboFromTrack.Size = new System.Drawing.Size(346, 21);
            this.cboFromTrack.TabIndex = 1;
            this.cboFromTrack.SelectedValueChanged += new System.EventHandler(this.FromCombo_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Track:";
            // 
            // cboFromDistrict
            // 
            this.cboFromDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFromDistrict.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFromDistrict.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFromDistrict.FormattingEnabled = true;
            this.cboFromDistrict.Location = new System.Drawing.Point(48, 6);
            this.cboFromDistrict.Name = "cboFromDistrict";
            this.cboFromDistrict.Size = new System.Drawing.Size(346, 21);
            this.cboFromDistrict.TabIndex = 1;
            this.cboFromDistrict.SelectedIndexChanged += new System.EventHandler(this.cboDistrict_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "District:";
            // 
            // tabTrainFrom
            // 
            this.tabTrainFrom.Controls.Add(this.cboFromTrain);
            this.tabTrainFrom.Controls.Add(this.label4);
            this.tabTrainFrom.Controls.Add(this.cboFromSymbol);
            this.tabTrainFrom.Controls.Add(this.label5);
            this.tabTrainFrom.Location = new System.Drawing.Point(4, 22);
            this.tabTrainFrom.Name = "tabTrainFrom";
            this.tabTrainFrom.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrainFrom.Size = new System.Drawing.Size(400, 61);
            this.tabTrainFrom.TabIndex = 1;
            this.tabTrainFrom.Text = "Train";
            this.tabTrainFrom.UseVisualStyleBackColor = true;
            // 
            // cboFromTrain
            // 
            this.cboFromTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFromTrain.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFromTrain.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFromTrain.FormattingEnabled = true;
            this.cboFromTrain.Location = new System.Drawing.Point(51, 33);
            this.cboFromTrain.Name = "cboFromTrain";
            this.cboFromTrain.Size = new System.Drawing.Size(346, 21);
            this.cboFromTrain.TabIndex = 4;
            this.cboFromTrain.SelectedIndexChanged += new System.EventHandler(this.FromCombo_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Train:";
            // 
            // cboFromSymbol
            // 
            this.cboFromSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFromSymbol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFromSymbol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFromSymbol.FormattingEnabled = true;
            this.cboFromSymbol.Location = new System.Drawing.Point(51, 6);
            this.cboFromSymbol.Name = "cboFromSymbol";
            this.cboFromSymbol.Size = new System.Drawing.Size(346, 21);
            this.cboFromSymbol.TabIndex = 5;
            this.cboFromSymbol.SelectedIndexChanged += new System.EventHandler(this.cboSymbol_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Symbol:";
            // 
            // loaderFrom
            // 
            this.loaderFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loaderFrom.BackColor = System.Drawing.Color.Transparent;
            this.loaderFrom.Location = new System.Drawing.Point(0, 89);
            this.loaderFrom.Name = "loaderFrom";
            this.loaderFrom.Size = new System.Drawing.Size(360, 463);
            this.loaderFrom.TabIndex = 3;
            this.loaderFrom.Visible = false;
            this.loaderFrom.VisibleChanged += new System.EventHandler(this.loader_VisibleChanged);
            // 
            // dgvToList
            // 
            this.dgvToList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvToList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colToImage,
            this.colToReportingMark,
            this.colToType,
            this.colToPossession,
            this.colToPos,
            this.colToDestination,
            this.colToStrategic});
            this.dgvToList.Location = new System.Drawing.Point(0, 89);
            this.dgvToList.Name = "dgvToList";
            this.dgvToList.Size = new System.Drawing.Size(455, 463);
            this.dgvToList.TabIndex = 1;
            this.dgvToList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            // 
            // colToImage
            // 
            this.colToImage.HeaderText = "Image";
            this.colToImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colToImage.Name = "colToImage";
            // 
            // colToReportingMark
            // 
            this.colToReportingMark.HeaderText = "Reporting Mark";
            this.colToReportingMark.Name = "colToReportingMark";
            // 
            // colToType
            // 
            this.colToType.HeaderText = "Type";
            this.colToType.Name = "colToType";
            // 
            // colToPossession
            // 
            this.colToPossession.HeaderText = "Possesed By";
            this.colToPossession.Name = "colToPossession";
            // 
            // colToPos
            // 
            this.colToPos.HeaderText = "Pos";
            this.colToPos.Name = "colToPos";
            this.colToPos.Width = 40;
            // 
            // colToDestination
            // 
            this.colToDestination.HeaderText = "Destination";
            this.colToDestination.Name = "colToDestination";
            // 
            // colToStrategic
            // 
            this.colToStrategic.HeaderText = "Strategic Dest";
            this.colToStrategic.Name = "colToStrategic";
            // 
            // tabControlTo
            // 
            this.tabControlTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlTo.Controls.Add(this.tabTrackTo);
            this.tabControlTo.Controls.Add(this.tabTrainTo);
            this.tabControlTo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlTo.Location = new System.Drawing.Point(0, 0);
            this.tabControlTo.Name = "tabControlTo";
            this.tabControlTo.SelectedIndex = 0;
            this.tabControlTo.Size = new System.Drawing.Size(459, 87);
            this.tabControlTo.TabIndex = 1;
            this.tabControlTo.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlTo_Selected);
            // 
            // tabTrackTo
            // 
            this.tabTrackTo.Controls.Add(this.cboToTrack);
            this.tabTrackTo.Controls.Add(this.label6);
            this.tabTrackTo.Controls.Add(this.cboToDistrict);
            this.tabTrackTo.Controls.Add(this.label7);
            this.tabTrackTo.Location = new System.Drawing.Point(4, 22);
            this.tabTrackTo.Name = "tabTrackTo";
            this.tabTrackTo.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrackTo.Size = new System.Drawing.Size(451, 61);
            this.tabTrackTo.TabIndex = 0;
            this.tabTrackTo.Text = "Track";
            this.tabTrackTo.UseVisualStyleBackColor = true;
            // 
            // cboToTrack
            // 
            this.cboToTrack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboToTrack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboToTrack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboToTrack.FormattingEnabled = true;
            this.cboToTrack.Location = new System.Drawing.Point(48, 33);
            this.cboToTrack.Name = "cboToTrack";
            this.cboToTrack.Size = new System.Drawing.Size(397, 21);
            this.cboToTrack.TabIndex = 1;
            this.cboToTrack.SelectedIndexChanged += new System.EventHandler(this.ToCombo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Track:";
            // 
            // cboToDistrict
            // 
            this.cboToDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboToDistrict.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboToDistrict.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboToDistrict.FormattingEnabled = true;
            this.cboToDistrict.Location = new System.Drawing.Point(48, 6);
            this.cboToDistrict.Name = "cboToDistrict";
            this.cboToDistrict.Size = new System.Drawing.Size(397, 21);
            this.cboToDistrict.TabIndex = 1;
            this.cboToDistrict.SelectedIndexChanged += new System.EventHandler(this.cboDistrict_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "District:";
            // 
            // tabTrainTo
            // 
            this.tabTrainTo.Controls.Add(this.cboToTrain);
            this.tabTrainTo.Controls.Add(this.label8);
            this.tabTrainTo.Controls.Add(this.cboToSymbol);
            this.tabTrainTo.Controls.Add(this.label9);
            this.tabTrainTo.Location = new System.Drawing.Point(4, 22);
            this.tabTrainTo.Name = "tabTrainTo";
            this.tabTrainTo.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrainTo.Size = new System.Drawing.Size(451, 61);
            this.tabTrainTo.TabIndex = 1;
            this.tabTrainTo.Text = "Train";
            this.tabTrainTo.UseVisualStyleBackColor = true;
            // 
            // cboToTrain
            // 
            this.cboToTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboToTrain.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboToTrain.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboToTrain.FormattingEnabled = true;
            this.cboToTrain.Location = new System.Drawing.Point(51, 33);
            this.cboToTrain.Name = "cboToTrain";
            this.cboToTrain.Size = new System.Drawing.Size(394, 21);
            this.cboToTrain.TabIndex = 4;
            this.cboToTrain.SelectedIndexChanged += new System.EventHandler(this.ToCombo_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Train:";
            // 
            // cboToSymbol
            // 
            this.cboToSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboToSymbol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboToSymbol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboToSymbol.FormattingEnabled = true;
            this.cboToSymbol.Location = new System.Drawing.Point(51, 6);
            this.cboToSymbol.Name = "cboToSymbol";
            this.cboToSymbol.Size = new System.Drawing.Size(394, 21);
            this.cboToSymbol.TabIndex = 5;
            this.cboToSymbol.SelectedIndexChanged += new System.EventHandler(this.cboSymbol_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Symbol:";
            // 
            // loaderTo
            // 
            this.loaderTo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loaderTo.BackColor = System.Drawing.Color.Transparent;
            this.loaderTo.Location = new System.Drawing.Point(0, 89);
            this.loaderTo.Name = "loaderTo";
            this.loaderTo.Size = new System.Drawing.Size(455, 463);
            this.loaderTo.TabIndex = 4;
            this.loaderTo.Visible = false;
            this.loaderTo.VisibleChanged += new System.EventHandler(this.loader_VisibleChanged);
            // 
            // loaderFull
            // 
            this.loaderFull.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loaderFull.BackColor = System.Drawing.Color.Transparent;
            this.loaderFull.Location = new System.Drawing.Point(0, 0);
            this.loaderFull.Name = "loaderFull";
            this.loaderFull.Size = new System.Drawing.Size(876, 616);
            this.loaderFull.TabIndex = 2;
            this.loaderFull.Visible = false;
            this.loaderFull.VisibleChanged += new System.EventHandler(this.loader_VisibleChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(798, 590);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Location = new System.Drawing.Point(717, 590);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Yellow;
            this.label10.Location = new System.Drawing.Point(265, 595);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(446, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Moving Railcars and saving will charge customers. Be sure of all your changes bef" +
    "ore saving.";
            // 
            // RailLocationModifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loaderFull);
            this.Name = "RailLocationModifier";
            this.Size = new System.Drawing.Size(876, 616);
            this.Load += new System.EventHandler(this.RailLocationModifier_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFromList)).EndInit();
            this.tabControlFrom.ResumeLayout(false);
            this.tabTrackFrom.ResumeLayout(false);
            this.tabTrackFrom.PerformLayout();
            this.tabTrainFrom.ResumeLayout(false);
            this.tabTrainFrom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToList)).EndInit();
            this.tabControlTo.ResumeLayout(false);
            this.tabTrackTo.ResumeLayout(false);
            this.tabTrackTo.PerformLayout();
            this.tabTrainTo.ResumeLayout(false);
            this.tabTrainTo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlFrom;
        private System.Windows.Forms.TabPage tabTrackFrom;
        private System.Windows.Forms.TabPage tabTrainFrom;
        private System.Windows.Forms.ComboBox cboFromTrack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFromDistrict;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFromTrain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboFromSymbol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControlTo;
        private System.Windows.Forms.TabPage tabTrackTo;
        private System.Windows.Forms.ComboBox cboToTrack;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboToDistrict;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabTrainTo;
        private System.Windows.Forms.ComboBox cboToTrain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboToSymbol;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvFromList;
        private System.Windows.Forms.DataGridView dgvToList;
        private System.Windows.Forms.Button cmdMoveDown;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdMoveUp;
        private Loader loaderFull;
        private Loader loaderFrom;
        private Loader loaderTo;
        private DataGridViewStylizer dataGridViewStylizer;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewImageColumn colFromImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromReportingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromPossession;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromStrategic;
        private System.Windows.Forms.DataGridViewImageColumn colToImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToReportingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToPossession;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToStrategic;
    }
}
