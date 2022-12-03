namespace FleetTracking.Train
{
    partial class InProgressTrainDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InProgressTrainDisplay));
            this.label1 = new System.Windows.Forms.Label();
            this.lnkSymbol = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblOnDutySince = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtInstructions = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalLength = new System.Windows.Forms.Label();
            this.lblStockTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabConsist = new System.Windows.Forms.TabPage();
            this.dgvConsist = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tabDutyTrans = new System.Windows.Forms.TabPage();
            this.dgvDutyTrans = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tabLocoFuel = new System.Windows.Forms.TabPage();
            this.dgvLocoFuel = new System.Windows.Forms.DataGridView();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.tabHandledCars = new System.Windows.Forms.TabPage();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            this.colOperator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConsistImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConsistType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFuelImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colFuelReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartingFuel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndingFuel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.colHandledImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colHandledReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPickedUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSetOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPartialTrip = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.loaderTrainInfo = new FleetTracking.Loader();
            this.loaderConsist = new FleetTracking.Loader();
            this.loaderDutyTrans = new FleetTracking.Loader();
            this.loaderLocoFuel = new FleetTracking.Loader();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabConsist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsist)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tabDutyTrans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDutyTrans)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabLocoFuel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocoFuel)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.tabHandledCars.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Symbol:";
            // 
            // lnkSymbol
            // 
            this.lnkSymbol.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lnkSymbol.AutoSize = true;
            this.lnkSymbol.Location = new System.Drawing.Point(60, 16);
            this.lnkSymbol.Name = "lnkSymbol";
            this.lnkSymbol.Size = new System.Drawing.Size(58, 13);
            this.lnkSymbol.TabIndex = 1;
            this.lnkSymbol.TabStop = true;
            this.lnkSymbol.Text = "IRW Q100";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Train Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BackColor = System.Drawing.Color.Yellow;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(89, 34);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(169, 23);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Not Started";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "On Duty Since:";
            // 
            // lblOnDutySince
            // 
            this.lblOnDutySince.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOnDutySince.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnDutySince.Location = new System.Drawing.Point(93, 57);
            this.lblOnDutySince.Name = "lblOnDutySince";
            this.lblOnDutySince.Size = new System.Drawing.Size(165, 23);
            this.lblOnDutySince.TabIndex = 3;
            this.lblOnDutySince.Text = "--/--/---- --:--";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.splitContainer1);
            this.groupBox3.Controls.Add(this.loaderTrainInfo);
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(544, 115);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Train Information";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lnkSymbol);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lblOnDutySince);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtInstructions);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Size = new System.Drawing.Size(538, 96);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtInstructions
            // 
            this.txtInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInstructions.Location = new System.Drawing.Point(3, 16);
            this.txtInstructions.Multiline = true;
            this.txtInstructions.Name = "txtInstructions";
            this.txtInstructions.ReadOnly = true;
            this.txtInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInstructions.Size = new System.Drawing.Size(267, 77);
            this.txtInstructions.TabIndex = 1;
            this.txtInstructions.Text = "Spring Valley can be skipped - no pickups/setouts required.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Train Instructions:";
            // 
            // lblTotalLength
            // 
            this.lblTotalLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalLength.Location = new System.Drawing.Point(447, 341);
            this.lblTotalLength.Name = "lblTotalLength";
            this.lblTotalLength.Size = new System.Drawing.Size(65, 13);
            this.lblTotalLength.TabIndex = 0;
            this.lblTotalLength.Text = "Stock Total:";
            // 
            // lblStockTotal
            // 
            this.lblStockTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStockTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStockTotal.Location = new System.Drawing.Point(83, 341);
            this.lblStockTotal.Name = "lblStockTotal";
            this.lblStockTotal.Size = new System.Drawing.Size(62, 13);
            this.lblStockTotal.TabIndex = 0;
            this.lblStockTotal.Text = "Stock Total:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(358, 341);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Total Length:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Stock Total:";
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabConsist);
            this.tabControl.Controls.Add(this.tabDutyTrans);
            this.tabControl.Controls.Add(this.tabLocoFuel);
            this.tabControl.Controls.Add(this.tabHandledCars);
            this.tabControl.Location = new System.Drawing.Point(0, 121);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(545, 365);
            this.tabControl.TabIndex = 6;
            // 
            // tabConsist
            // 
            this.tabConsist.Controls.Add(this.lblTotalLength);
            this.tabConsist.Controls.Add(this.label8);
            this.tabConsist.Controls.Add(this.dgvConsist);
            this.tabConsist.Controls.Add(this.lblStockTotal);
            this.tabConsist.Controls.Add(this.toolStrip2);
            this.tabConsist.Controls.Add(this.label6);
            this.tabConsist.Controls.Add(this.loaderConsist);
            this.tabConsist.Location = new System.Drawing.Point(23, 4);
            this.tabConsist.Name = "tabConsist";
            this.tabConsist.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsist.Size = new System.Drawing.Size(518, 357);
            this.tabConsist.TabIndex = 0;
            this.tabConsist.Text = "Consist";
            this.tabConsist.UseVisualStyleBackColor = true;
            // 
            // dgvConsist
            // 
            this.dgvConsist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConsist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConsistImage,
            this.colReportingMark,
            this.colPosition,
            this.colConsistType});
            this.dgvConsist.Location = new System.Drawing.Point(3, 28);
            this.dgvConsist.Name = "dgvConsist";
            this.dgvConsist.Size = new System.Drawing.Size(512, 310);
            this.dgvConsist.TabIndex = 2;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(512, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(65, 22);
            this.toolStripButton2.Text = "Modify";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(77, 22);
            this.toolStripButton3.Text = "Live Load";
            // 
            // tabDutyTrans
            // 
            this.tabDutyTrans.Controls.Add(this.dgvDutyTrans);
            this.tabDutyTrans.Controls.Add(this.toolStrip1);
            this.tabDutyTrans.Controls.Add(this.loaderDutyTrans);
            this.tabDutyTrans.Location = new System.Drawing.Point(23, 4);
            this.tabDutyTrans.Name = "tabDutyTrans";
            this.tabDutyTrans.Padding = new System.Windows.Forms.Padding(3);
            this.tabDutyTrans.Size = new System.Drawing.Size(518, 357);
            this.tabDutyTrans.TabIndex = 1;
            this.tabDutyTrans.Text = "Duty Trans";
            this.tabDutyTrans.UseVisualStyleBackColor = true;
            // 
            // dgvDutyTrans
            // 
            this.dgvDutyTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDutyTrans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOperator,
            this.colTimeStart,
            this.colTimeEnd});
            this.dgvDutyTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDutyTrans.Location = new System.Drawing.Point(3, 28);
            this.dgvDutyTrans.Name = "dgvDutyTrans";
            this.dgvDutyTrans.RowHeadersVisible = false;
            this.dgvDutyTrans.Size = new System.Drawing.Size(512, 326);
            this.dgvDutyTrans.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(512, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(111, 22);
            this.toolStripButton1.Text = "Go On/Off Duty";
            // 
            // tabLocoFuel
            // 
            this.tabLocoFuel.Controls.Add(this.dgvLocoFuel);
            this.tabLocoFuel.Controls.Add(this.toolStrip3);
            this.tabLocoFuel.Controls.Add(this.loaderLocoFuel);
            this.tabLocoFuel.Location = new System.Drawing.Point(23, 4);
            this.tabLocoFuel.Name = "tabLocoFuel";
            this.tabLocoFuel.Size = new System.Drawing.Size(518, 357);
            this.tabLocoFuel.TabIndex = 2;
            this.tabLocoFuel.Text = "Loco Fuel";
            this.tabLocoFuel.UseVisualStyleBackColor = true;
            // 
            // dgvLocoFuel
            // 
            this.dgvLocoFuel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocoFuel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFuelImage,
            this.colFuelReportingMark,
            this.colStartingFuel,
            this.colEndingFuel});
            this.dgvLocoFuel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLocoFuel.Location = new System.Drawing.Point(0, 25);
            this.dgvLocoFuel.Name = "dgvLocoFuel";
            this.dgvLocoFuel.RowHeadersVisible = false;
            this.dgvLocoFuel.Size = new System.Drawing.Size(518, 332);
            this.dgvLocoFuel.TabIndex = 2;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(518, 25);
            this.toolStrip3.TabIndex = 1;
            this.toolStrip3.Text = "toolStrip1";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(115, 22);
            this.toolStripButton4.Text = "Add Locomotive";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(70, 22);
            this.toolStripButton5.Text = "Set Start";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(66, 22);
            this.toolStripButton6.Text = "Set End";
            // 
            // tabHandledCars
            // 
            this.tabHandledCars.Controls.Add(this.dataGridView1);
            this.tabHandledCars.Controls.Add(this.toolStrip4);
            this.tabHandledCars.Location = new System.Drawing.Point(23, 4);
            this.tabHandledCars.Name = "tabHandledCars";
            this.tabHandledCars.Size = new System.Drawing.Size(518, 357);
            this.tabHandledCars.TabIndex = 3;
            this.tabHandledCars.Text = "Handled Cars";
            this.tabHandledCars.UseVisualStyleBackColor = true;
            // 
            // colOperator
            // 
            this.colOperator.HeaderText = "Operator";
            this.colOperator.Name = "colOperator";
            // 
            // colTimeStart
            // 
            this.colTimeStart.HeaderText = "Start Time";
            this.colTimeStart.Name = "colTimeStart";
            // 
            // colTimeEnd
            // 
            this.colTimeEnd.HeaderText = "End Time";
            this.colTimeEnd.Name = "colTimeEnd";
            // 
            // colConsistImage
            // 
            this.colConsistImage.HeaderText = "Image";
            this.colConsistImage.Name = "colConsistImage";
            // 
            // colReportingMark
            // 
            this.colReportingMark.HeaderText = "Reporting Mark";
            this.colReportingMark.Name = "colReportingMark";
            this.colReportingMark.Width = 120;
            // 
            // colPosition
            // 
            this.colPosition.HeaderText = "Pos";
            this.colPosition.Name = "colPosition";
            this.colPosition.Width = 40;
            // 
            // colConsistType
            // 
            this.colConsistType.HeaderText = "Type";
            this.colConsistType.Name = "colConsistType";
            // 
            // colFuelImage
            // 
            this.colFuelImage.HeaderText = "Image";
            this.colFuelImage.Name = "colFuelImage";
            // 
            // colFuelReportingMark
            // 
            this.colFuelReportingMark.HeaderText = "Reporting Mark";
            this.colFuelReportingMark.Name = "colFuelReportingMark";
            this.colFuelReportingMark.Width = 120;
            // 
            // colStartingFuel
            // 
            this.colStartingFuel.HeaderText = "Start Amount";
            this.colStartingFuel.Name = "colStartingFuel";
            // 
            // colEndingFuel
            // 
            this.colEndingFuel.HeaderText = "End Amount";
            this.colEndingFuel.Name = "colEndingFuel";
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton7});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(518, 25);
            this.toolStrip4.TabIndex = 0;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHandledImage,
            this.colHandledReportingMark,
            this.colPickedUp,
            this.colSetOut,
            this.colPartialTrip});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(518, 332);
            this.dataGridView1.TabIndex = 1;
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(120, 22);
            this.toolStripButton7.Text = "Toggle Partial Trip";
            // 
            // colHandledImage
            // 
            this.colHandledImage.HeaderText = "Image";
            this.colHandledImage.Name = "colHandledImage";
            // 
            // colHandledReportingMark
            // 
            this.colHandledReportingMark.HeaderText = "Reporting Mark";
            this.colHandledReportingMark.Name = "colHandledReportingMark";
            this.colHandledReportingMark.Width = 120;
            // 
            // colPickedUp
            // 
            this.colPickedUp.HeaderText = "Picked Up From";
            this.colPickedUp.Name = "colPickedUp";
            this.colPickedUp.Width = 120;
            // 
            // colSetOut
            // 
            this.colSetOut.HeaderText = "Set Out To";
            this.colSetOut.Name = "colSetOut";
            this.colSetOut.Width = 120;
            // 
            // colPartialTrip
            // 
            this.colPartialTrip.HeaderText = "Partial Trip";
            this.colPartialTrip.Name = "colPartialTrip";
            // 
            // loaderTrainInfo
            // 
            this.loaderTrainInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loaderTrainInfo.BackColor = System.Drawing.Color.Transparent;
            this.loaderTrainInfo.Location = new System.Drawing.Point(3, 16);
            this.loaderTrainInfo.Name = "loaderTrainInfo";
            this.loaderTrainInfo.Size = new System.Drawing.Size(538, 99);
            this.loaderTrainInfo.TabIndex = 1;
            this.loaderTrainInfo.Visible = false;
            // 
            // loaderConsist
            // 
            this.loaderConsist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loaderConsist.BackColor = System.Drawing.Color.Transparent;
            this.loaderConsist.Location = new System.Drawing.Point(0, 0);
            this.loaderConsist.Name = "loaderConsist";
            this.loaderConsist.Size = new System.Drawing.Size(518, 357);
            this.loaderConsist.TabIndex = 3;
            this.loaderConsist.Visible = false;
            // 
            // loaderDutyTrans
            // 
            this.loaderDutyTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loaderDutyTrans.BackColor = System.Drawing.Color.Transparent;
            this.loaderDutyTrans.Location = new System.Drawing.Point(0, 0);
            this.loaderDutyTrans.Name = "loaderDutyTrans";
            this.loaderDutyTrans.Size = new System.Drawing.Size(518, 358);
            this.loaderDutyTrans.TabIndex = 3;
            this.loaderDutyTrans.Visible = false;
            // 
            // loaderLocoFuel
            // 
            this.loaderLocoFuel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loaderLocoFuel.BackColor = System.Drawing.Color.Transparent;
            this.loaderLocoFuel.Location = new System.Drawing.Point(0, 0);
            this.loaderLocoFuel.Name = "loaderLocoFuel";
            this.loaderLocoFuel.Size = new System.Drawing.Size(518, 358);
            this.loaderLocoFuel.TabIndex = 3;
            this.loaderLocoFuel.Visible = false;
            // 
            // InProgressTrainDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.groupBox3);
            this.Name = "InProgressTrainDisplay";
            this.Size = new System.Drawing.Size(548, 486);
            this.Load += new System.EventHandler(this.InProgressTrainDisplay_Load);
            this.groupBox3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabConsist.ResumeLayout(false);
            this.tabConsist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsist)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabDutyTrans.ResumeLayout(false);
            this.tabDutyTrans.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDutyTrans)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabLocoFuel.ResumeLayout(false);
            this.tabLocoFuel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocoFuel)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabHandledCars.ResumeLayout(false);
            this.tabHandledCars.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkSymbol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblOnDutySince;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblTotalLength;
        private System.Windows.Forms.Label lblStockTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabConsist;
        private System.Windows.Forms.TabPage tabDutyTrans;
        private System.Windows.Forms.TextBox txtInstructions;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvConsist;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabPage tabLocoFuel;
        private System.Windows.Forms.DataGridView dgvLocoFuel;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.TabPage tabHandledCars;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private DataGridViewStylizer dataGridViewStylizer;
        private System.Windows.Forms.DataGridView dgvDutyTrans;
        private System.Windows.Forms.DataGridViewImageColumn colConsistImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConsistType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeEnd;
        private System.Windows.Forms.DataGridViewImageColumn colFuelImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFuelReportingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartingFuel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndingFuel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn colHandledImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHandledReportingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPickedUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSetOut;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPartialTrip;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private Loader loaderTrainInfo;
        private Loader loaderConsist;
        private Loader loaderDutyTrans;
        private Loader loaderLocoFuel;
    }
}
