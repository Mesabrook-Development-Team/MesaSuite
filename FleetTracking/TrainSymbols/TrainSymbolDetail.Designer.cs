namespace FleetTracking.TrainSymbols
{
    partial class TrainSymbolDetail
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvRates = new System.Windows.Forms.DataGridView();
            this.colEffective = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPartial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAddRate = new System.Windows.Forms.ToolStripButton();
            this.toolDeleteRate = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvTrains = new System.Windows.Forms.DataGridView();
            this.colStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFuelUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeTaken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.loaderTrains = new FleetTracking.Loader();
            this.loader = new FleetTracking.Loader();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblAverageFuel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAverageDuty = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvFuelByModel = new System.Windows.Forms.DataGridView();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvgFuel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaderStats = new FleetTracking.Loader();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrains)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuelByModel)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmdReset);
            this.groupBox1.Controls.Add(this.cmdSave);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Symbol Details";
            // 
            // cmdReset
            // 
            this.cmdReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReset.Location = new System.Drawing.Point(559, 136);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(75, 23);
            this.cmdReset.TabIndex = 3;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(640, 136);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(9, 64);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(706, 66);
            this.txtDescription.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(47, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(668, 20);
            this.txtName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 171);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(721, 225);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvRates);
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(713, 199);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Rates";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvRates
            // 
            this.dgvRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEffective,
            this.colCar,
            this.colPartial});
            this.dgvRates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRates.Location = new System.Drawing.Point(3, 41);
            this.dgvRates.Name = "dgvRates";
            this.dgvRates.Size = new System.Drawing.Size(707, 155);
            this.dgvRates.TabIndex = 1;
            this.dgvRates.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRates_CellDoubleClick);
            // 
            // colEffective
            // 
            this.colEffective.HeaderText = "Effective";
            this.colEffective.Name = "colEffective";
            this.colEffective.Width = 150;
            // 
            // colCar
            // 
            this.colCar.HeaderText = "Rate Per Car";
            this.colCar.Name = "colCar";
            // 
            // colPartial
            // 
            this.colPartial.HeaderText = "Rate Per Partial Trip";
            this.colPartial.Name = "colPartial";
            this.colPartial.Width = 150;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddRate,
            this.toolDeleteRate});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(707, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAddRate
            // 
            this.toolAddRate.Image = global::FleetTracking.Properties.Resources.add;
            this.toolAddRate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddRate.Name = "toolAddRate";
            this.toolAddRate.Size = new System.Drawing.Size(59, 35);
            this.toolAddRate.Text = "Add Rate";
            this.toolAddRate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolAddRate.Click += new System.EventHandler(this.toolAddRate_Click);
            // 
            // toolDeleteRate
            // 
            this.toolDeleteRate.Enabled = false;
            this.toolDeleteRate.Image = global::FleetTracking.Properties.Resources.delete;
            this.toolDeleteRate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDeleteRate.Name = "toolDeleteRate";
            this.toolDeleteRate.Size = new System.Drawing.Size(70, 35);
            this.toolDeleteRate.Text = "Delete Rate";
            this.toolDeleteRate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvTrains);
            this.tabPage2.Controls.Add(this.loaderTrains);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(713, 199);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Trains";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvTrains
            // 
            this.dgvTrains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrains.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStart,
            this.colEndTime,
            this.colFuelUsage,
            this.colTimeTaken});
            this.dgvTrains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrains.Location = new System.Drawing.Point(3, 3);
            this.dgvTrains.Name = "dgvTrains";
            this.dgvTrains.Size = new System.Drawing.Size(707, 193);
            this.dgvTrains.TabIndex = 0;
            this.dgvTrains.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrains_CellDoubleClick);
            // 
            // colStart
            // 
            this.colStart.HeaderText = "Start Time";
            this.colStart.Name = "colStart";
            // 
            // colEndTime
            // 
            this.colEndTime.HeaderText = "End Time";
            this.colEndTime.Name = "colEndTime";
            // 
            // colFuelUsage
            // 
            this.colFuelUsage.HeaderText = "Fuel Usage";
            this.colFuelUsage.Name = "colFuelUsage";
            // 
            // colTimeTaken
            // 
            this.colTimeTaken.HeaderText = "Total On Duty Time";
            this.colTimeTaken.Name = "colTimeTaken";
            this.colTimeTaken.Width = 125;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.lblAverageDuty);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.lblAverageFuel);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.loaderStats);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(713, 199);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Statistics";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // loaderTrains
            // 
            this.loaderTrains.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loaderTrains.BackColor = System.Drawing.Color.Transparent;
            this.loaderTrains.Location = new System.Drawing.Point(0, 0);
            this.loaderTrains.Name = "loaderTrains";
            this.loaderTrains.Size = new System.Drawing.Size(711, 200);
            this.loaderTrains.TabIndex = 1;
            this.loaderTrains.Visible = false;
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(721, 396);
            this.loader.TabIndex = 2;
            this.loader.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Average Fuel Usage:";
            // 
            // lblAverageFuel
            // 
            this.lblAverageFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAverageFuel.Location = new System.Drawing.Point(126, 3);
            this.lblAverageFuel.Name = "lblAverageFuel";
            this.lblAverageFuel.Size = new System.Drawing.Size(149, 20);
            this.lblAverageFuel.TabIndex = 1;
            this.lblAverageFuel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Average On Duty Time:";
            // 
            // lblAverageDuty
            // 
            this.lblAverageDuty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAverageDuty.Location = new System.Drawing.Point(126, 29);
            this.lblAverageDuty.Name = "lblAverageDuty";
            this.lblAverageDuty.Size = new System.Drawing.Size(149, 20);
            this.lblAverageDuty.TabIndex = 1;
            this.lblAverageDuty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dgvFuelByModel);
            this.groupBox2.Location = new System.Drawing.Point(6, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 141);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Avg Fuel/Loco Model";
            // 
            // dgvFuelByModel
            // 
            this.dgvFuelByModel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFuelByModel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colModel,
            this.colAvgFuel});
            this.dgvFuelByModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFuelByModel.Location = new System.Drawing.Point(3, 16);
            this.dgvFuelByModel.Name = "dgvFuelByModel";
            this.dgvFuelByModel.Size = new System.Drawing.Size(263, 122);
            this.dgvFuelByModel.TabIndex = 0;
            // 
            // colModel
            // 
            this.colModel.HeaderText = "Model";
            this.colModel.Name = "colModel";
            // 
            // colAvgFuel
            // 
            this.colAvgFuel.HeaderText = "Avg Fuel";
            this.colAvgFuel.Name = "colAvgFuel";
            // 
            // loaderStats
            // 
            this.loaderStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loaderStats.BackColor = System.Drawing.Color.Transparent;
            this.loaderStats.Location = new System.Drawing.Point(0, 0);
            this.loaderStats.Name = "loaderStats";
            this.loaderStats.Size = new System.Drawing.Size(713, 199);
            this.loaderStats.TabIndex = 3;
            this.loaderStats.Visible = false;
            // 
            // TrainSymbolDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loader);
            this.Name = "TrainSymbolDetail";
            this.Size = new System.Drawing.Size(721, 396);
            this.Load += new System.EventHandler(this.TrainSymbolDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrains)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuelByModel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvRates;
        private System.Windows.Forms.DataGridView dgvTrains;
        private DataGridViewStylizer dataGridViewStylizer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEffective;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartial;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAddRate;
        private System.Windows.Forms.ToolStripButton toolDeleteRate;
        private Loader loader;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFuelUsage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeTaken;
        private Loader loaderTrains;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAverageDuty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAverageFuel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvFuelByModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvgFuel;
        private Loader loaderStats;
    }
}
