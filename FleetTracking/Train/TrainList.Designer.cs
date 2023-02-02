namespace FleetTracking.Train
{
    partial class TrainList
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
            this.cmdFirst = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdPrev = new System.Windows.Forms.Button();
            this.cmdLast = new System.Windows.Forms.Button();
            this.dgvTrains = new System.Windows.Forms.DataGridView();
            this.colSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocomotive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAddTrain = new System.Windows.Forms.ToolStripButton();
            this.toolDeleteTrain = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoInProgress = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.chkOperableTrainsOnly = new System.Windows.Forms.CheckBox();
            this.loader = new FleetTracking.Loader();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrains)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmdFirst);
            this.groupBox1.Controls.Add(this.cmdNext);
            this.groupBox1.Controls.Add(this.cmdPrev);
            this.groupBox1.Controls.Add(this.cmdLast);
            this.groupBox1.Controls.Add(this.dgvTrains);
            this.groupBox1.Location = new System.Drawing.Point(0, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 273);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trains";
            // 
            // cmdFirst
            // 
            this.cmdFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdFirst.Image = global::FleetTracking.Properties.Resources.resultset_first;
            this.cmdFirst.Location = new System.Drawing.Point(6, 244);
            this.cmdFirst.Name = "cmdFirst";
            this.cmdFirst.Size = new System.Drawing.Size(28, 23);
            this.cmdFirst.TabIndex = 1;
            this.cmdFirst.UseVisualStyleBackColor = true;
            // 
            // cmdNext
            // 
            this.cmdNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNext.Image = global::FleetTracking.Properties.Resources.resultset_next;
            this.cmdNext.Location = new System.Drawing.Point(542, 244);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(28, 23);
            this.cmdNext.TabIndex = 1;
            this.cmdNext.UseVisualStyleBackColor = true;
            // 
            // cmdPrev
            // 
            this.cmdPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrev.Image = global::FleetTracking.Properties.Resources.resultset_previous;
            this.cmdPrev.Location = new System.Drawing.Point(40, 244);
            this.cmdPrev.Name = "cmdPrev";
            this.cmdPrev.Size = new System.Drawing.Size(28, 23);
            this.cmdPrev.TabIndex = 1;
            this.cmdPrev.UseVisualStyleBackColor = true;
            // 
            // cmdLast
            // 
            this.cmdLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLast.Image = global::FleetTracking.Properties.Resources.resultset_last;
            this.cmdLast.Location = new System.Drawing.Point(576, 244);
            this.cmdLast.Name = "cmdLast";
            this.cmdLast.Size = new System.Drawing.Size(28, 23);
            this.cmdLast.TabIndex = 1;
            this.cmdLast.UseVisualStyleBackColor = true;
            // 
            // dgvTrains
            // 
            this.dgvTrains.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTrains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrains.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSymbol,
            this.colStatus,
            this.colStartTime,
            this.colEndTime,
            this.colLocomotive,
            this.colStockTotal,
            this.colLength});
            this.dgvTrains.Location = new System.Drawing.Point(3, 16);
            this.dgvTrains.Name = "dgvTrains";
            this.dgvTrains.Size = new System.Drawing.Size(604, 222);
            this.dgvTrains.TabIndex = 0;
            this.dgvTrains.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrains_CellDoubleClick);
            this.dgvTrains.SelectionChanged += new System.EventHandler(this.dgvTrains_SelectionChanged);
            // 
            // colSymbol
            // 
            this.colSymbol.HeaderText = "Symbol";
            this.colSymbol.Name = "colSymbol";
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // colStartTime
            // 
            this.colStartTime.HeaderText = "Start Time";
            this.colStartTime.Name = "colStartTime";
            // 
            // colEndTime
            // 
            this.colEndTime.HeaderText = "End Time";
            this.colEndTime.Name = "colEndTime";
            // 
            // colLocomotive
            // 
            this.colLocomotive.HeaderText = "Locomotive";
            this.colLocomotive.Name = "colLocomotive";
            // 
            // colStockTotal
            // 
            this.colStockTotal.HeaderText = "Total Stock";
            this.colStockTotal.Name = "colStockTotal";
            // 
            // colLength
            // 
            this.colLength.HeaderText = "Length";
            this.colLength.Name = "colLength";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddTrain,
            this.toolDeleteTrain});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(610, 38);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAddTrain
            // 
            this.toolAddTrain.Image = global::FleetTracking.Properties.Resources.add;
            this.toolAddTrain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddTrain.Name = "toolAddTrain";
            this.toolAddTrain.Size = new System.Drawing.Size(61, 35);
            this.toolAddTrain.Text = "Add Train";
            this.toolAddTrain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolAddTrain.Click += new System.EventHandler(this.toolAddTrain_Click);
            // 
            // toolDeleteTrain
            // 
            this.toolDeleteTrain.Enabled = false;
            this.toolDeleteTrain.Image = global::FleetTracking.Properties.Resources.delete;
            this.toolDeleteTrain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDeleteTrain.Name = "toolDeleteTrain";
            this.toolDeleteTrain.Size = new System.Drawing.Size(72, 35);
            this.toolDeleteTrain.Text = "Delete Train";
            this.toolDeleteTrain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolDeleteTrain.Click += new System.EventHandler(this.toolDeleteTrain_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filter:";
            // 
            // rdoInProgress
            // 
            this.rdoInProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoInProgress.AutoSize = true;
            this.rdoInProgress.Checked = true;
            this.rdoInProgress.Location = new System.Drawing.Point(48, 317);
            this.rdoInProgress.Name = "rdoInProgress";
            this.rdoInProgress.Size = new System.Drawing.Size(78, 17);
            this.rdoInProgress.TabIndex = 3;
            this.rdoInProgress.TabStop = true;
            this.rdoInProgress.Text = "In Progress";
            this.rdoInProgress.UseVisualStyleBackColor = true;
            this.rdoInProgress.CheckedChanged += new System.EventHandler(this.FilterOption_CheckedChanged);
            // 
            // rdoAll
            // 
            this.rdoAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(132, 317);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 3;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.CheckedChanged += new System.EventHandler(this.FilterOption_CheckedChanged);
            // 
            // chkOperableTrainsOnly
            // 
            this.chkOperableTrainsOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkOperableTrainsOnly.AutoSize = true;
            this.chkOperableTrainsOnly.Checked = true;
            this.chkOperableTrainsOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOperableTrainsOnly.Location = new System.Drawing.Point(174, 318);
            this.chkOperableTrainsOnly.Name = "chkOperableTrainsOnly";
            this.chkOperableTrainsOnly.Size = new System.Drawing.Size(125, 17);
            this.chkOperableTrainsOnly.TabIndex = 4;
            this.chkOperableTrainsOnly.Text = "Operable Trains Only";
            this.chkOperableTrainsOnly.UseVisualStyleBackColor = true;
            this.chkOperableTrainsOnly.CheckedChanged += new System.EventHandler(this.FilterOption_CheckedChanged);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(610, 343);
            this.loader.TabIndex = 5;
            this.loader.Visible = false;
            // 
            // TrainList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkOperableTrainsOnly);
            this.Controls.Add(this.rdoAll);
            this.Controls.Add(this.rdoInProgress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loader);
            this.Name = "TrainList";
            this.Size = new System.Drawing.Size(610, 343);
            this.Load += new System.EventHandler(this.TrainList_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrains)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTrains;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAddTrain;
        private System.Windows.Forms.ToolStripButton toolDeleteTrain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoInProgress;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.CheckBox chkOperableTrainsOnly;
        private Loader loader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocomotive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private DataGridViewStylizer dataGridViewStylizer;
        private System.Windows.Forms.Button cmdLast;
        private System.Windows.Forms.Button cmdFirst;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdPrev;
    }
}
