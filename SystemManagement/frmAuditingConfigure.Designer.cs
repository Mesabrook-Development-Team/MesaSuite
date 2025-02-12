namespace SystemManagement
{
    partial class frmAuditingConfigure
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuditingConfigure));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiscordIDs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboNamespaces = new System.Windows.Forms.ComboBox();
            this.cmdAddNamespace = new System.Windows.Forms.Button();
            this.dgvBlocks = new System.Windows.Forms.DataGridView();
            this.colBlockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlertPlace = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAlertBreak = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAlertUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblSaved = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrSaveLabelTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlocks)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Discord ID(s) to notify:";
            // 
            // txtDiscordIDs
            // 
            this.txtDiscordIDs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscordIDs.Location = new System.Drawing.Point(129, 12);
            this.txtDiscordIDs.Name = "txtDiscordIDs";
            this.txtDiscordIDs.Size = new System.Drawing.Size(315, 20);
            this.txtDiscordIDs.TabIndex = 0;
            this.txtDiscordIDs.TextChanged += new System.EventHandler(this.txtDiscordIDs_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Blocks to notify on:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Add entire namespace (optional):";
            // 
            // cboNamespaces
            // 
            this.cboNamespaces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNamespaces.FormattingEnabled = true;
            this.cboNamespaces.Location = new System.Drawing.Point(180, 302);
            this.cboNamespaces.Name = "cboNamespaces";
            this.cboNamespaces.Size = new System.Drawing.Size(203, 21);
            this.cboNamespaces.TabIndex = 2;
            // 
            // cmdAddNamespace
            // 
            this.cmdAddNamespace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddNamespace.Location = new System.Drawing.Point(389, 300);
            this.cmdAddNamespace.Name = "cmdAddNamespace";
            this.cmdAddNamespace.Size = new System.Drawing.Size(55, 23);
            this.cmdAddNamespace.TabIndex = 3;
            this.cmdAddNamespace.Text = "Add";
            this.cmdAddNamespace.UseVisualStyleBackColor = true;
            this.cmdAddNamespace.Click += new System.EventHandler(this.cmdAddNamespace_Click);
            // 
            // dgvBlocks
            // 
            this.dgvBlocks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBlocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBlocks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBlockName,
            this.colAlertPlace,
            this.colAlertBreak,
            this.colAlertUse});
            this.dgvBlocks.Location = new System.Drawing.Point(15, 58);
            this.dgvBlocks.Name = "dgvBlocks";
            this.dgvBlocks.Size = new System.Drawing.Size(429, 236);
            this.dgvBlocks.TabIndex = 1;
            this.dgvBlocks.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBlocks_RowValidated);
            this.dgvBlocks.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvBlocks_UserDeletingRow);
            // 
            // colBlockName
            // 
            this.colBlockName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBlockName.HeaderText = "Block Name";
            this.colBlockName.Name = "colBlockName";
            this.colBlockName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colAlertPlace
            // 
            this.colAlertPlace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colAlertPlace.HeaderText = "Alert Place";
            this.colAlertPlace.Name = "colAlertPlace";
            this.colAlertPlace.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAlertPlace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAlertPlace.Width = 83;
            // 
            // colAlertBreak
            // 
            this.colAlertBreak.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colAlertBreak.HeaderText = "Alert Break";
            this.colAlertBreak.Name = "colAlertBreak";
            this.colAlertBreak.Width = 65;
            // 
            // colAlertUse
            // 
            this.colAlertUse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colAlertUse.HeaderText = "Alert Use";
            this.colAlertUse.Name = "colAlertUse";
            this.colAlertUse.Width = 56;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSaved});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(456, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblSaved
            // 
            this.lblSaved.BackColor = System.Drawing.Color.Green;
            this.lblSaved.Name = "lblSaved";
            this.lblSaved.Size = new System.Drawing.Size(41, 17);
            this.lblSaved.Text = "Saved!";
            this.lblSaved.Visible = false;
            // 
            // tmrSaveLabelTimer
            // 
            this.tmrSaveLabelTimer.Interval = 3000;
            this.tmrSaveLabelTimer.Tick += new System.EventHandler(this.tmrSaveLabelTimer_Tick);
            // 
            // frmAuditingConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 361);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvBlocks);
            this.Controls.Add(this.cboNamespaces);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdAddNamespace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDiscordIDs);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAuditingConfigure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configure Audit Alerts";
            this.Load += new System.EventHandler(this.frmAuditingConfigure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlocks)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiscordIDs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboNamespaces;
        private System.Windows.Forms.Button cmdAddNamespace;
        private System.Windows.Forms.DataGridView dgvBlocks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlockName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAlertPlace;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAlertBreak;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAlertUse;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblSaved;
        private System.Windows.Forms.Timer tmrSaveLabelTimer;
    }
}