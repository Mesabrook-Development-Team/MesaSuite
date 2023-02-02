namespace FleetTracking.Roster
{
    partial class MassAddStockInput
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colReportingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReportingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOwner = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colReleasedTo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolCheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolUncheckAll = new System.Windows.Forms.ToolStripButton();
            this.chkLocation = new System.Windows.Forms.CheckBox();
            this.chkReleasedTo = new System.Windows.Forms.CheckBox();
            this.chkOwner = new System.Windows.Forms.CheckBox();
            this.cmdApplyFields = new System.Windows.Forms.Button();
            this.cboReleasedTo = new System.Windows.Forms.ComboBox();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.cboOwner = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoRailcarModel = new System.Windows.Forms.RadioButton();
            this.rdoLocomotiveModel = new System.Windows.Forms.RadioButton();
            this.cboLocomotiveModel = new FleetTracking.ControlSelector();
            this.cboRailcarModel = new FleetTracking.ControlSelector();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 56);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvStock);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chkLocation);
            this.splitContainer1.Panel2.Controls.Add(this.chkReleasedTo);
            this.splitContainer1.Panel2.Controls.Add(this.chkOwner);
            this.splitContainer1.Panel2.Controls.Add(this.cmdApplyFields);
            this.splitContainer1.Panel2.Controls.Add(this.cboReleasedTo);
            this.splitContainer1.Panel2.Controls.Add(this.cboLocation);
            this.splitContainer1.Panel2.Controls.Add(this.cboOwner);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(617, 389);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 4;
            // 
            // dgvStock
            // 
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colReportingMark,
            this.colReportingNumber,
            this.colOwner,
            this.colReleasedTo,
            this.colLocation});
            this.dgvStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStock.Location = new System.Drawing.Point(0, 25);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.Size = new System.Drawing.Size(617, 236);
            this.dgvStock.TabIndex = 1;
            this.dgvStock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellClick);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 30;
            // 
            // colReportingMark
            // 
            this.colReportingMark.HeaderText = "Reporting Mark";
            this.colReportingMark.Name = "colReportingMark";
            // 
            // colReportingNumber
            // 
            this.colReportingNumber.HeaderText = "Reporting Number";
            this.colReportingNumber.Name = "colReportingNumber";
            this.colReportingNumber.Width = 150;
            // 
            // colOwner
            // 
            this.colOwner.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colOwner.HeaderText = "Owner";
            this.colOwner.Name = "colOwner";
            this.colOwner.Width = 150;
            // 
            // colReleasedTo
            // 
            this.colReleasedTo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colReleasedTo.HeaderText = "Released To";
            this.colReleasedTo.Name = "colReleasedTo";
            this.colReleasedTo.Width = 150;
            // 
            // colLocation
            // 
            this.colLocation.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colLocation.HeaderText = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.Width = 150;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCheckAll,
            this.toolUncheckAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(617, 25);
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
            // chkLocation
            // 
            this.chkLocation.AutoSize = true;
            this.chkLocation.Location = new System.Drawing.Point(3, 72);
            this.chkLocation.Name = "chkLocation";
            this.chkLocation.Size = new System.Drawing.Size(70, 17);
            this.chkLocation.TabIndex = 4;
            this.chkLocation.Text = "Location:";
            this.chkLocation.UseVisualStyleBackColor = true;
            this.chkLocation.CheckedChanged += new System.EventHandler(this.chkLocation_CheckedChanged);
            // 
            // chkReleasedTo
            // 
            this.chkReleasedTo.AutoSize = true;
            this.chkReleasedTo.Location = new System.Drawing.Point(3, 45);
            this.chkReleasedTo.Name = "chkReleasedTo";
            this.chkReleasedTo.Size = new System.Drawing.Size(90, 17);
            this.chkReleasedTo.TabIndex = 2;
            this.chkReleasedTo.Text = "Released To:";
            this.chkReleasedTo.UseVisualStyleBackColor = true;
            this.chkReleasedTo.CheckedChanged += new System.EventHandler(this.chkReleasedTo_CheckedChanged);
            // 
            // chkOwner
            // 
            this.chkOwner.AutoSize = true;
            this.chkOwner.Location = new System.Drawing.Point(3, 18);
            this.chkOwner.Name = "chkOwner";
            this.chkOwner.Size = new System.Drawing.Size(60, 17);
            this.chkOwner.TabIndex = 0;
            this.chkOwner.Text = "Owner:";
            this.chkOwner.UseVisualStyleBackColor = true;
            this.chkOwner.CheckedChanged += new System.EventHandler(this.chkOwner_CheckedChanged);
            // 
            // cmdApplyFields
            // 
            this.cmdApplyFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdApplyFields.Location = new System.Drawing.Point(539, 97);
            this.cmdApplyFields.Name = "cmdApplyFields";
            this.cmdApplyFields.Size = new System.Drawing.Size(75, 23);
            this.cmdApplyFields.TabIndex = 6;
            this.cmdApplyFields.Text = "Apply Fields";
            this.cmdApplyFields.UseVisualStyleBackColor = true;
            this.cmdApplyFields.Click += new System.EventHandler(this.cmdApplyFields_Click);
            // 
            // cboReleasedTo
            // 
            this.cboReleasedTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReleasedTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboReleasedTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReleasedTo.Enabled = false;
            this.cboReleasedTo.FormattingEnabled = true;
            this.cboReleasedTo.Location = new System.Drawing.Point(99, 43);
            this.cboReleasedTo.Name = "cboReleasedTo";
            this.cboReleasedTo.Size = new System.Drawing.Size(515, 21);
            this.cboReleasedTo.TabIndex = 3;
            // 
            // cboLocation
            // 
            this.cboLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboLocation.Enabled = false;
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(99, 70);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(515, 21);
            this.cboLocation.TabIndex = 5;
            // 
            // cboOwner
            // 
            this.cboOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOwner.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboOwner.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboOwner.Enabled = false;
            this.cboOwner.FormattingEnabled = true;
            this.cboOwner.Location = new System.Drawing.Point(99, 16);
            this.cboOwner.Name = "cboOwner";
            this.cboOwner.Size = new System.Drawing.Size(515, 21);
            this.cboOwner.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mass Update Field Options";
            // 
            // rdoRailcarModel
            // 
            this.rdoRailcarModel.AutoSize = true;
            this.rdoRailcarModel.Location = new System.Drawing.Point(3, 3);
            this.rdoRailcarModel.Name = "rdoRailcarModel";
            this.rdoRailcarModel.Size = new System.Drawing.Size(90, 17);
            this.rdoRailcarModel.TabIndex = 0;
            this.rdoRailcarModel.TabStop = true;
            this.rdoRailcarModel.Text = "Railcar Model";
            this.rdoRailcarModel.UseVisualStyleBackColor = true;
            this.rdoRailcarModel.CheckedChanged += new System.EventHandler(this.rdoRailcarModel_CheckedChanged);
            // 
            // rdoLocomotiveModel
            // 
            this.rdoLocomotiveModel.AutoSize = true;
            this.rdoLocomotiveModel.Location = new System.Drawing.Point(3, 30);
            this.rdoLocomotiveModel.Name = "rdoLocomotiveModel";
            this.rdoLocomotiveModel.Size = new System.Drawing.Size(112, 17);
            this.rdoLocomotiveModel.TabIndex = 2;
            this.rdoLocomotiveModel.TabStop = true;
            this.rdoLocomotiveModel.Text = "Locomotive Model";
            this.rdoLocomotiveModel.UseVisualStyleBackColor = true;
            this.rdoLocomotiveModel.CheckedChanged += new System.EventHandler(this.rdoLocomotiveModel_CheckedChanged);
            // 
            // cboLocomotiveModel
            // 
            this.cboLocomotiveModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocomotiveModel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboLocomotiveModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocomotiveModel.Enabled = false;
            this.cboLocomotiveModel.FormattingEnabled = true;
            this.cboLocomotiveModel.Location = new System.Drawing.Point(121, 29);
            this.cboLocomotiveModel.Name = "cboLocomotiveModel";
            this.cboLocomotiveModel.Size = new System.Drawing.Size(493, 21);
            this.cboLocomotiveModel.TabIndex = 3;
            this.cboLocomotiveModel.SelectedIndexChanged += new System.EventHandler(this.cboLocomotiveModel_SelectedIndexChanged);
            // 
            // cboRailcarModel
            // 
            this.cboRailcarModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRailcarModel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboRailcarModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRailcarModel.Enabled = false;
            this.cboRailcarModel.FormattingEnabled = true;
            this.cboRailcarModel.Location = new System.Drawing.Point(121, 2);
            this.cboRailcarModel.Name = "cboRailcarModel";
            this.cboRailcarModel.Size = new System.Drawing.Size(493, 21);
            this.cboRailcarModel.TabIndex = 1;
            this.cboRailcarModel.SelectedIndexChanged += new System.EventHandler(this.cboRailcarModel_SelectedIndexChanged);
            // 
            // MassAddStockInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboRailcarModel);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cboLocomotiveModel);
            this.Controls.Add(this.rdoRailcarModel);
            this.Controls.Add(this.rdoLocomotiveModel);
            this.Name = "MassAddStockInput";
            this.Size = new System.Drawing.Size(617, 445);
            this.Load += new System.EventHandler(this.MassAddStockInput_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoLocomotiveModel;
        private System.Windows.Forms.RadioButton rdoRailcarModel;
        private ControlSelector cboRailcarModel;
        private ControlSelector cboLocomotiveModel;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.ComboBox cboOwner;
        private System.Windows.Forms.Button cmdApplyFields;
        private DataGridViewStylizer dataGridViewStylizer;
        private System.Windows.Forms.ComboBox cboReleasedTo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportingNumber;
        private System.Windows.Forms.DataGridViewComboBoxColumn colOwner;
        private System.Windows.Forms.DataGridViewComboBoxColumn colReleasedTo;
        private System.Windows.Forms.DataGridViewComboBoxColumn colLocation;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolCheckAll;
        private System.Windows.Forms.ToolStripButton toolUncheckAll;
        private System.Windows.Forms.CheckBox chkLocation;
        private System.Windows.Forms.CheckBox chkReleasedTo;
        private System.Windows.Forms.CheckBox chkOwner;
    }
}
