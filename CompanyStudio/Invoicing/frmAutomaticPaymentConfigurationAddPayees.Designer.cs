namespace CompanyStudio.Invoicing
{
    partial class frmAutomaticPaymentConfigurationAddPayees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutomaticPaymentConfigurationAddPayees));
            this.label1 = new System.Windows.Forms.Label();
            this.lstAvailable = new System.Windows.Forms.ListView();
            this.colSourcePayee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCloneable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dgvChosen = new System.Windows.Forms.DataGridView();
            this.colPayee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCloneFrom = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboCloneAllFrom = new System.Windows.Forms.ToolStripComboBox();
            this.cmdApply = new System.Windows.Forms.ToolStripButton();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.studioFormExtender = new CompanyStudio.StudioFormExtender(this.components);
            this.loader = new CompanyStudio.Loader();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChosen)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Payees";
            // 
            // lstAvailable
            // 
            this.lstAvailable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSourcePayee,
            this.colCloneable});
            this.lstAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAvailable.FullRowSelect = true;
            this.lstAvailable.HideSelection = false;
            this.lstAvailable.Location = new System.Drawing.Point(0, 0);
            this.lstAvailable.Name = "lstAvailable";
            this.lstAvailable.Size = new System.Drawing.Size(322, 232);
            this.lstAvailable.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstAvailable.TabIndex = 1;
            this.lstAvailable.UseCompatibleStateImageBehavior = false;
            this.lstAvailable.View = System.Windows.Forms.View.Details;
            // 
            // colSourcePayee
            // 
            this.colSourcePayee.Text = "Payee";
            this.colSourcePayee.Width = 250;
            // 
            // colCloneable
            // 
            this.colCloneable.Text = "Cloneable";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.Image = global::CompanyStudio.Properties.Resources.arrow_left;
            this.button1.Location = new System.Drawing.Point(3, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Remove All";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.Image = global::CompanyStudio.Properties.Resources.arrow_left;
            this.button2.Location = new System.Drawing.Point(3, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remove";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.Location = new System.Drawing.Point(3, 123);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(86, 23);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(3, 152);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Add All";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dgvChosen
            // 
            this.dgvChosen.AllowUserToAddRows = false;
            this.dgvChosen.AllowUserToDeleteRows = false;
            this.dgvChosen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChosen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPayee,
            this.colCloneFrom});
            this.dgvChosen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChosen.Location = new System.Drawing.Point(0, 25);
            this.dgvChosen.Name = "dgvChosen";
            this.dgvChosen.RowHeadersVisible = false;
            this.dgvChosen.Size = new System.Drawing.Size(455, 207);
            this.dgvChosen.TabIndex = 3;
            // 
            // colPayee
            // 
            this.colPayee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPayee.HeaderText = "Payee";
            this.colPayee.Name = "colPayee";
            this.colPayee.ReadOnly = true;
            // 
            // colCloneFrom
            // 
            this.colCloneFrom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCloneFrom.HeaderText = "Clone From";
            this.colCloneFrom.Name = "colCloneFrom";
            this.colCloneFrom.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvChosen);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(95, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 232);
            this.panel1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cboCloneAllFrom,
            this.cmdApply});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(455, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(79, 22);
            this.toolStripLabel1.Text = "Clone All From:";
            // 
            // cboCloneAllFrom
            // 
            this.cboCloneAllFrom.Name = "cboCloneAllFrom";
            this.cboCloneAllFrom.Size = new System.Drawing.Size(121, 25);
            this.cboCloneAllFrom.Sorted = true;
            // 
            // cmdApply
            // 
            this.cmdApply.Image = global::CompanyStudio.Properties.Resources.accept;
            this.cmdApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(54, 22);
            this.cmdApply.Text = "Apply";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(813, 270);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(732, 270);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Cancel";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // loader
            // 
            this.loader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(352, 100);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(196, 101);
            this.loader.TabIndex = 6;
            this.loader.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 32);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstAvailable);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.cmdAdd);
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Size = new System.Drawing.Size(876, 232);
            this.splitContainer1.SplitterDistance = 322;
            this.splitContainer1.TabIndex = 7;
            // 
            // frmAutomaticPaymentConfigurationAddPayees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 300);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.loader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAutomaticPaymentConfigurationAddPayees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Payees";
            this.Load += new System.EventHandler(this.frmAutomaticPaymentConfigurationAddPayees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChosen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstAvailable;
        private System.Windows.Forms.ColumnHeader colSourcePayee;
        private System.Windows.Forms.ColumnHeader colCloneable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dgvChosen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayee;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCloneFrom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cboCloneAllFrom;
        private System.Windows.Forms.ToolStripButton cmdApply;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private StudioFormExtender studioFormExtender;
        private Loader loader;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}