namespace FleetTracking.Reports.RailActivity
{
    partial class RailActivityWizard
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Welcome"}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Date Selection");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Report Options");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Train Selection");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Track Selection");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Review");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RailActivityWizard));
            this.lstNav = new System.Windows.Forms.ListView();
            this.imlState = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdRun = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.pnlWelcome = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlDateSelection = new System.Windows.Forms.Panel();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.chkTrackToTrackMovement = new System.Windows.Forms.CheckBox();
            this.chkMovementByTrain = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlTrainSelection = new System.Windows.Forms.Panel();
            this.lstTrains = new System.Windows.Forms.ListBox();
            this.rdoSpecificTrains = new System.Windows.Forms.RadioButton();
            this.rdoAllTrains = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlTrackSelection = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lstTracks = new System.Windows.Forms.ListBox();
            this.rdoSpecificTracks = new System.Windows.Forms.RadioButton();
            this.rdoAllTracks = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlReview = new System.Windows.Forms.Panel();
            this.txtReview = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ldrTrack = new FleetTracking.Loader();
            this.ldrTrain = new FleetTracking.Loader();
            this.pnlWelcome.SuspendLayout();
            this.pnlDateSelection.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlTrainSelection.SuspendLayout();
            this.pnlTrackSelection.SuspendLayout();
            this.pnlReview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstNav
            // 
            this.lstNav.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lstNav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstNav.AutoArrange = false;
            this.lstNav.HideSelection = false;
            this.lstNav.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.lstNav.LargeImageList = this.imlState;
            this.lstNav.Location = new System.Drawing.Point(0, 33);
            this.lstNav.Name = "lstNav";
            this.lstNav.Size = new System.Drawing.Size(144, 396);
            this.lstNav.SmallImageList = this.imlState;
            this.lstNav.TabIndex = 0;
            this.lstNav.UseCompatibleStateImageBehavior = false;
            this.lstNav.View = System.Windows.Forms.View.SmallIcon;
            this.lstNav.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstNav_ItemSelectionChanged);
            // 
            // imlState
            // 
            this.imlState.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlState.ImageSize = new System.Drawing.Size(16, 16);
            this.imlState.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(2, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(561, 2);
            this.label1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(533, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rail Activity Report Wizard";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(3, 431);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(561, 2);
            this.label3.TabIndex = 3;
            // 
            // cmdRun
            // 
            this.cmdRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRun.Location = new System.Drawing.Point(488, 434);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(75, 23);
            this.cmdRun.TabIndex = 4;
            this.cmdRun.Text = "Run Report";
            this.cmdRun.UseVisualStyleBackColor = true;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNext.Location = new System.Drawing.Point(401, 434);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(75, 23);
            this.cmdNext.TabIndex = 4;
            this.cmdNext.Text = "Next >";
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBack.Location = new System.Drawing.Point(320, 434);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(75, 23);
            this.cmdBack.TabIndex = 4;
            this.cmdBack.Text = "< Back";
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(233, 434);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // pnlWelcome
            // 
            this.pnlWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWelcome.Controls.Add(this.label4);
            this.pnlWelcome.Location = new System.Drawing.Point(144, 34);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Size = new System.Drawing.Size(422, 395);
            this.pnlWelcome.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(0, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(420, 381);
            this.label4.TabIndex = 0;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // pnlDateSelection
            // 
            this.pnlDateSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDateSelection.Controls.Add(this.dtpEnd);
            this.pnlDateSelection.Controls.Add(this.label7);
            this.pnlDateSelection.Controls.Add(this.dtpStart);
            this.pnlDateSelection.Controls.Add(this.label6);
            this.pnlDateSelection.Controls.Add(this.label5);
            this.pnlDateSelection.Location = new System.Drawing.Point(144, 34);
            this.pnlDateSelection.Name = "pnlDateSelection";
            this.pnlDateSelection.Size = new System.Drawing.Size(422, 395);
            this.pnlDateSelection.TabIndex = 6;
            this.pnlDateSelection.Visible = false;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEnd.Location = new System.Drawing.Point(59, 42);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(360, 20);
            this.dtpEnd.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Through:";
            // 
            // dtpStart
            // 
            this.dtpStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStart.Location = new System.Drawing.Point(59, 16);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(360, 20);
            this.dtpStart.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "From:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(295, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "What Date Moved range should be displayed on your report?";
            // 
            // pnlOptions
            // 
            this.pnlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOptions.Controls.Add(this.chkTrackToTrackMovement);
            this.pnlOptions.Controls.Add(this.chkMovementByTrain);
            this.pnlOptions.Controls.Add(this.label10);
            this.pnlOptions.Location = new System.Drawing.Point(144, 34);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(422, 395);
            this.pnlOptions.TabIndex = 7;
            this.pnlOptions.Visible = false;
            // 
            // chkTrackToTrackMovement
            // 
            this.chkTrackToTrackMovement.AutoSize = true;
            this.chkTrackToTrackMovement.Checked = true;
            this.chkTrackToTrackMovement.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrackToTrackMovement.Location = new System.Drawing.Point(3, 39);
            this.chkTrackToTrackMovement.Name = "chkTrackToTrackMovement";
            this.chkTrackToTrackMovement.Size = new System.Drawing.Size(155, 17);
            this.chkTrackToTrackMovement.TabIndex = 8;
            this.chkTrackToTrackMovement.Text = "Track-to-Track Movements";
            this.chkTrackToTrackMovement.UseVisualStyleBackColor = true;
            this.chkTrackToTrackMovement.CheckedChanged += new System.EventHandler(this.chkTrackToTrackMovement_CheckedChanged);
            // 
            // chkMovementByTrain
            // 
            this.chkMovementByTrain.AutoSize = true;
            this.chkMovementByTrain.Checked = true;
            this.chkMovementByTrain.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMovementByTrain.Location = new System.Drawing.Point(3, 16);
            this.chkMovementByTrain.Name = "chkMovementByTrain";
            this.chkMovementByTrain.Size = new System.Drawing.Size(122, 17);
            this.chkMovementByTrain.TabIndex = 8;
            this.chkMovementByTrain.Text = "Movements by Train";
            this.chkMovementByTrain.UseVisualStyleBackColor = true;
            this.chkMovementByTrain.CheckedChanged += new System.EventHandler(this.chkMovementByTrain_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(328, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "What kinds of railcar movements do you want to see on your report?";
            // 
            // pnlTrainSelection
            // 
            this.pnlTrainSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTrainSelection.Controls.Add(this.ldrTrain);
            this.pnlTrainSelection.Controls.Add(this.lstTrains);
            this.pnlTrainSelection.Controls.Add(this.rdoSpecificTrains);
            this.pnlTrainSelection.Controls.Add(this.rdoAllTrains);
            this.pnlTrainSelection.Controls.Add(this.label8);
            this.pnlTrainSelection.Location = new System.Drawing.Point(144, 34);
            this.pnlTrainSelection.Name = "pnlTrainSelection";
            this.pnlTrainSelection.Size = new System.Drawing.Size(422, 395);
            this.pnlTrainSelection.TabIndex = 8;
            this.pnlTrainSelection.Visible = false;
            // 
            // lstTrains
            // 
            this.lstTrains.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTrains.Enabled = false;
            this.lstTrains.FormattingEnabled = true;
            this.lstTrains.Location = new System.Drawing.Point(3, 58);
            this.lstTrains.Name = "lstTrains";
            this.lstTrains.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTrains.Size = new System.Drawing.Size(417, 329);
            this.lstTrains.TabIndex = 2;
            // 
            // rdoSpecificTrains
            // 
            this.rdoSpecificTrains.AutoSize = true;
            this.rdoSpecificTrains.Location = new System.Drawing.Point(6, 35);
            this.rdoSpecificTrains.Name = "rdoSpecificTrains";
            this.rdoSpecificTrains.Size = new System.Drawing.Size(95, 17);
            this.rdoSpecificTrains.TabIndex = 1;
            this.rdoSpecificTrains.TabStop = true;
            this.rdoSpecificTrains.Text = "Specific Trains";
            this.rdoSpecificTrains.UseVisualStyleBackColor = true;
            this.rdoSpecificTrains.CheckedChanged += new System.EventHandler(this.rdoSpecificTrains_CheckedChanged);
            // 
            // rdoAllTrains
            // 
            this.rdoAllTrains.AutoSize = true;
            this.rdoAllTrains.Checked = true;
            this.rdoAllTrains.Location = new System.Drawing.Point(6, 16);
            this.rdoAllTrains.Name = "rdoAllTrains";
            this.rdoAllTrains.Size = new System.Drawing.Size(96, 17);
            this.rdoAllTrains.TabIndex = 1;
            this.rdoAllTrains.TabStop = true;
            this.rdoAllTrains.Text = "All of my Trains";
            this.rdoAllTrains.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(269, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Which trains should be shown for Movements by Train?";
            // 
            // pnlTrackSelection
            // 
            this.pnlTrackSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTrackSelection.Controls.Add(this.ldrTrack);
            this.pnlTrackSelection.Controls.Add(this.label11);
            this.pnlTrackSelection.Controls.Add(this.lstTracks);
            this.pnlTrackSelection.Controls.Add(this.rdoSpecificTracks);
            this.pnlTrackSelection.Controls.Add(this.rdoAllTracks);
            this.pnlTrackSelection.Controls.Add(this.label9);
            this.pnlTrackSelection.Location = new System.Drawing.Point(144, 34);
            this.pnlTrackSelection.Name = "pnlTrackSelection";
            this.pnlTrackSelection.Size = new System.Drawing.Size(422, 395);
            this.pnlTrackSelection.TabIndex = 9;
            this.pnlTrackSelection.Visible = false;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 380);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(380, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "* Note: The selected tracks will appear if cars were either originating or were s" +
    "et-out on them";
            // 
            // lstTracks
            // 
            this.lstTracks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTracks.Enabled = false;
            this.lstTracks.FormattingEnabled = true;
            this.lstTracks.Location = new System.Drawing.Point(3, 58);
            this.lstTracks.Name = "lstTracks";
            this.lstTracks.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTracks.Size = new System.Drawing.Size(417, 316);
            this.lstTracks.TabIndex = 2;
            // 
            // rdoSpecificTracks
            // 
            this.rdoSpecificTracks.AutoSize = true;
            this.rdoSpecificTracks.Location = new System.Drawing.Point(6, 35);
            this.rdoSpecificTracks.Name = "rdoSpecificTracks";
            this.rdoSpecificTracks.Size = new System.Drawing.Size(99, 17);
            this.rdoSpecificTracks.TabIndex = 1;
            this.rdoSpecificTracks.TabStop = true;
            this.rdoSpecificTracks.Text = "Specific Tracks";
            this.rdoSpecificTracks.UseVisualStyleBackColor = true;
            this.rdoSpecificTracks.CheckedChanged += new System.EventHandler(this.rdoSpecificTracks_CheckedChanged);
            // 
            // rdoAllTracks
            // 
            this.rdoAllTracks.AutoSize = true;
            this.rdoAllTracks.Checked = true;
            this.rdoAllTracks.Location = new System.Drawing.Point(6, 16);
            this.rdoAllTracks.Name = "rdoAllTracks";
            this.rdoAllTracks.Size = new System.Drawing.Size(100, 17);
            this.rdoAllTracks.TabIndex = 1;
            this.rdoAllTracks.TabStop = true;
            this.rdoAllTracks.Text = "All of my Tracks";
            this.rdoAllTracks.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(306, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Which tracks should be shown for Track-to-Track Movements?";
            // 
            // pnlReview
            // 
            this.pnlReview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReview.Controls.Add(this.txtReview);
            this.pnlReview.Controls.Add(this.label13);
            this.pnlReview.Location = new System.Drawing.Point(144, 34);
            this.pnlReview.Name = "pnlReview";
            this.pnlReview.Size = new System.Drawing.Size(422, 395);
            this.pnlReview.TabIndex = 10;
            this.pnlReview.Visible = false;
            this.pnlReview.VisibleChanged += new System.EventHandler(this.pnlReview_VisibleChanged);
            // 
            // txtReview
            // 
            this.txtReview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReview.Location = new System.Drawing.Point(6, 16);
            this.txtReview.Multiline = true;
            this.txtReview.Name = "txtReview";
            this.txtReview.ReadOnly = true;
            this.txtReview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReview.Size = new System.Drawing.Size(413, 376);
            this.txtReview.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(330, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Review your Rail Activity Report configuration and click Run Report:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::FleetTracking.Properties.Resources.moving_64;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // ldrTrack
            // 
            this.ldrTrack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ldrTrack.BackColor = System.Drawing.Color.Transparent;
            this.ldrTrack.Location = new System.Drawing.Point(3, 58);
            this.ldrTrack.Name = "ldrTrack";
            this.ldrTrack.Size = new System.Drawing.Size(416, 316);
            this.ldrTrack.TabIndex = 4;
            // 
            // ldrTrain
            // 
            this.ldrTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ldrTrain.BackColor = System.Drawing.Color.Transparent;
            this.ldrTrain.Location = new System.Drawing.Point(3, 58);
            this.ldrTrain.Name = "ldrTrain";
            this.ldrTrain.Size = new System.Drawing.Size(416, 329);
            this.ldrTrain.TabIndex = 11;
            // 
            // RailActivityWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWelcome);
            this.Controls.Add(this.pnlTrainSelection);
            this.Controls.Add(this.pnlTrackSelection);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.pnlDateSelection);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlReview);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.cmdRun);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstNav);
            this.Name = "RailActivityWizard";
            this.Size = new System.Drawing.Size(566, 465);
            this.Load += new System.EventHandler(this.RailActivityWizard_Load);
            this.pnlWelcome.ResumeLayout(false);
            this.pnlDateSelection.ResumeLayout(false);
            this.pnlDateSelection.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.pnlTrainSelection.ResumeLayout(false);
            this.pnlTrainSelection.PerformLayout();
            this.pnlTrackSelection.ResumeLayout(false);
            this.pnlTrackSelection.PerformLayout();
            this.pnlReview.ResumeLayout(false);
            this.pnlReview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstNav;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Panel pnlWelcome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlDateSelection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkTrackToTrackMovement;
        private System.Windows.Forms.CheckBox chkMovementByTrain;
        private System.Windows.Forms.Panel pnlTrainSelection;
        private System.Windows.Forms.RadioButton rdoAllTrains;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rdoSpecificTrains;
        private System.Windows.Forms.ListBox lstTrains;
        private System.Windows.Forms.Panel pnlTrackSelection;
        private System.Windows.Forms.ListBox lstTracks;
        private System.Windows.Forms.RadioButton rdoSpecificTracks;
        private System.Windows.Forms.RadioButton rdoAllTracks;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlReview;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtReview;
        private System.Windows.Forms.ImageList imlState;
        private Loader ldrTrain;
        private Loader ldrTrack;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
