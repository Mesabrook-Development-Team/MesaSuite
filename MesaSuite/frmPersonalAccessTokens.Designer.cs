namespace MesaSuite
{
    partial class frmPersonalAccessTokens
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonalAccessTokens));
            this.dgvPATs = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpiration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuAddPAT = new System.Windows.Forms.ToolStripButton();
            this.mnuDeletePAT = new System.Windows.Forms.ToolStripButton();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpExpiration = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.chkInactivity = new System.Windows.Forms.CheckBox();
            this.chkNetworkPrinting = new System.Windows.Forms.CheckBox();
            this.chkNeverExpires = new System.Windows.Forms.CheckBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPATs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPATs
            // 
            this.dgvPATs.AllowUserToAddRows = false;
            this.dgvPATs.AllowUserToDeleteRows = false;
            this.dgvPATs.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.dgvPATs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(28)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(28)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPATs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPATs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPATs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colExpiration});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPATs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPATs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPATs.EnableHeadersVisualStyles = false;
            this.dgvPATs.Location = new System.Drawing.Point(0, 0);
            this.dgvPATs.MultiSelect = false;
            this.dgvPATs.Name = "dgvPATs";
            this.dgvPATs.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPATs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPATs.RowHeadersVisible = false;
            this.dgvPATs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPATs.Size = new System.Drawing.Size(204, 322);
            this.dgvPATs.TabIndex = 0;
            this.dgvPATs.SelectionChanged += new System.EventHandler(this.dgvPATs_SelectionChanged);
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colExpiration
            // 
            this.colExpiration.HeaderText = "Expires At";
            this.colExpiration.Name = "colExpiration";
            this.colExpiration.ReadOnly = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvPATs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlDetail);
            this.splitContainer1.Size = new System.Drawing.Size(588, 322);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddPAT,
            this.mnuDeletePAT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(588, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuAddPAT
            // 
            this.mnuAddPAT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.mnuAddPAT.Image = global::MesaSuite.Properties.Resources.key_add;
            this.mnuAddPAT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAddPAT.Name = "mnuAddPAT";
            this.mnuAddPAT.Size = new System.Drawing.Size(71, 22);
            this.mnuAddPAT.Text = "Add PAT";
            this.mnuAddPAT.Click += new System.EventHandler(this.mnuAddPAT_Click);
            // 
            // mnuDeletePAT
            // 
            this.mnuDeletePAT.Enabled = false;
            this.mnuDeletePAT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.mnuDeletePAT.Image = global::MesaSuite.Properties.Resources.key_delete;
            this.mnuDeletePAT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDeletePAT.Name = "mnuDeletePAT";
            this.mnuDeletePAT.Size = new System.Drawing.Size(82, 22);
            this.mnuDeletePAT.Text = "Delete PAT";
            this.mnuDeletePAT.Click += new System.EventHandler(this.mnuDeletePAT_Click);
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.cmdReset);
            this.pnlDetail.Controls.Add(this.cmdSave);
            this.pnlDetail.Controls.Add(this.label3);
            this.pnlDetail.Controls.Add(this.chkNeverExpires);
            this.pnlDetail.Controls.Add(this.flowLayoutPanel1);
            this.pnlDetail.Controls.Add(this.dtpExpiration);
            this.pnlDetail.Controls.Add(this.label2);
            this.pnlDetail.Controls.Add(this.txtName);
            this.pnlDetail.Controls.Add(this.label1);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetail.Location = new System.Drawing.Point(0, 0);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(380, 322);
            this.pnlDetail.TabIndex = 0;
            this.pnlDetail.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.txtName.Location = new System.Drawing.Point(53, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(324, 20);
            this.txtName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Expires:";
            // 
            // dtpExpiration
            // 
            this.dtpExpiration.CustomFormat = "dddd MMM dd\',\' yyyy \'@\' HH:mm";
            this.dtpExpiration.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpiration.Location = new System.Drawing.Point(53, 29);
            this.dtpExpiration.Name = "dtpExpiration";
            this.dtpExpiration.Size = new System.Drawing.Size(324, 20);
            this.dtpExpiration.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.chkInactivity);
            this.flowLayoutPanel1.Controls.Add(this.chkNetworkPrinting);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 91);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(371, 199);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "What permissions do you want to grant with this token?";
            // 
            // chkInactivity
            // 
            this.chkInactivity.AutoSize = true;
            this.chkInactivity.Location = new System.Drawing.Point(3, 3);
            this.chkInactivity.Name = "chkInactivity";
            this.chkInactivity.Size = new System.Drawing.Size(137, 17);
            this.chkInactivity.TabIndex = 0;
            this.chkInactivity.Text = "Reset Inactivity Periods";
            this.chkInactivity.UseVisualStyleBackColor = true;
            // 
            // chkNetworkPrinting
            // 
            this.chkNetworkPrinting.AutoSize = true;
            this.chkNetworkPrinting.Location = new System.Drawing.Point(3, 26);
            this.chkNetworkPrinting.Name = "chkNetworkPrinting";
            this.chkNetworkPrinting.Size = new System.Drawing.Size(143, 17);
            this.chkNetworkPrinting.TabIndex = 1;
            this.chkNetworkPrinting.Text = "Perform Network Printing";
            this.chkNetworkPrinting.UseVisualStyleBackColor = true;
            // 
            // chkNeverExpires
            // 
            this.chkNeverExpires.AutoSize = true;
            this.chkNeverExpires.Location = new System.Drawing.Point(53, 55);
            this.chkNeverExpires.Name = "chkNeverExpires";
            this.chkNeverExpires.Size = new System.Drawing.Size(92, 17);
            this.chkNeverExpires.TabIndex = 2;
            this.chkNeverExpires.Text = "Never Expires";
            this.chkNeverExpires.UseVisualStyleBackColor = true;
            this.chkNeverExpires.CheckedChanged += new System.EventHandler(this.chkNeverExpires_CheckedChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(302, 296);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReset.Location = new System.Drawing.Point(221, 296);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(75, 23);
            this.cmdReset.TabIndex = 4;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = false;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // frmPersonalAccessTokens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(588, 347);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPersonalAccessTokens";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personal Access Tokens";
            this.Load += new System.EventHandler(this.frmPersonalAccessTokens_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPATs)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPATs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpiration;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuAddPAT;
        private System.Windows.Forms.ToolStripButton mnuDeletePAT;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpExpiration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkInactivity;
        private System.Windows.Forms.CheckBox chkNetworkPrinting;
        private System.Windows.Forms.CheckBox chkNeverExpires;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdReset;
    }
}