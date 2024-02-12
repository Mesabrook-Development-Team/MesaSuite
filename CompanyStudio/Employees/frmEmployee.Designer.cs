namespace CompanyStudio.Employees
{
    partial class frmEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployee));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkManageEmails = new System.Windows.Forms.CheckBox();
            this.chkManageEmployees = new System.Windows.Forms.CheckBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cboEmployees = new System.Windows.Forms.ComboBox();
            this.loader = new CompanyStudio.Loader();
            this.chkManageAccounts = new System.Windows.Forms.CheckBox();
            this.chkManageLocations = new System.Windows.Forms.CheckBox();
            this.chkIssueWireTransfers = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkFleetLoadUnload = new System.Windows.Forms.CheckBox();
            this.chkFleetTrainCrew = new System.Windows.Forms.CheckBox();
            this.chkFleetYardmaster = new System.Windows.Forms.CheckBox();
            this.chkFleetLeasing = new System.Windows.Forms.CheckBox();
            this.chkFleetSetup = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "What is this Employee allowed to do?";
            // 
            // chkManageEmails
            // 
            this.chkManageEmails.AutoSize = true;
            this.chkManageEmails.Location = new System.Drawing.Point(6, 19);
            this.chkManageEmails.Name = "chkManageEmails";
            this.chkManageEmails.Size = new System.Drawing.Size(98, 17);
            this.chkManageEmails.TabIndex = 0;
            this.chkManageEmails.Text = "Manage Emails";
            this.chkManageEmails.UseVisualStyleBackColor = true;
            this.chkManageEmails.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkManageEmployees
            // 
            this.chkManageEmployees.AutoSize = true;
            this.chkManageEmployees.Location = new System.Drawing.Point(6, 42);
            this.chkManageEmployees.Name = "chkManageEmployees";
            this.chkManageEmployees.Size = new System.Drawing.Size(119, 17);
            this.chkManageEmployees.TabIndex = 1;
            this.chkManageEmployees.Text = "Manage Employees";
            this.chkManageEmployees.UseVisualStyleBackColor = true;
            this.chkManageEmployees.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(344, 197);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(263, 197);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cboEmployees
            // 
            this.cboEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEmployees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployees.FormattingEnabled = true;
            this.cboEmployees.Location = new System.Drawing.Point(53, 12);
            this.cboEmployees.Name = "cboEmployees";
            this.cboEmployees.Size = new System.Drawing.Size(366, 21);
            this.cboEmployees.TabIndex = 0;
            this.cboEmployees.SelectedIndexChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // loader
            // 
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(431, 233);
            this.loader.TabIndex = 5;
            this.loader.Visible = false;
            // 
            // chkManageAccounts
            // 
            this.chkManageAccounts.AutoSize = true;
            this.chkManageAccounts.Location = new System.Drawing.Point(6, 65);
            this.chkManageAccounts.Name = "chkManageAccounts";
            this.chkManageAccounts.Size = new System.Drawing.Size(113, 17);
            this.chkManageAccounts.TabIndex = 2;
            this.chkManageAccounts.Text = "Manage Accounts";
            this.chkManageAccounts.UseVisualStyleBackColor = true;
            this.chkManageAccounts.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkManageLocations
            // 
            this.chkManageLocations.AutoSize = true;
            this.chkManageLocations.Location = new System.Drawing.Point(6, 88);
            this.chkManageLocations.Name = "chkManageLocations";
            this.chkManageLocations.Size = new System.Drawing.Size(114, 17);
            this.chkManageLocations.TabIndex = 3;
            this.chkManageLocations.Text = "Manage Locations";
            this.chkManageLocations.UseVisualStyleBackColor = true;
            this.chkManageLocations.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkIssueWireTransfers
            // 
            this.chkIssueWireTransfers.AutoSize = true;
            this.chkIssueWireTransfers.Location = new System.Drawing.Point(6, 111);
            this.chkIssueWireTransfers.Name = "chkIssueWireTransfers";
            this.chkIssueWireTransfers.Size = new System.Drawing.Size(123, 17);
            this.chkIssueWireTransfers.TabIndex = 4;
            this.chkIssueWireTransfers.Text = "Issue Wire Transfers";
            this.chkIssueWireTransfers.UseVisualStyleBackColor = true;
            this.chkIssueWireTransfers.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkManageEmails);
            this.groupBox1.Controls.Add(this.chkIssueWireTransfers);
            this.groupBox1.Controls.Add(this.chkManageEmployees);
            this.groupBox1.Controls.Add(this.chkManageLocations);
            this.groupBox1.Controls.Add(this.chkManageAccounts);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 135);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkFleetLoadUnload);
            this.groupBox2.Controls.Add(this.chkFleetTrainCrew);
            this.groupBox2.Controls.Add(this.chkFleetYardmaster);
            this.groupBox2.Controls.Add(this.chkFleetLeasing);
            this.groupBox2.Controls.Add(this.chkFleetSetup);
            this.groupBox2.Location = new System.Drawing.Point(218, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 135);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fleet Tracking";
            // 
            // chkFleetLoadUnload
            // 
            this.chkFleetLoadUnload.AutoSize = true;
            this.chkFleetLoadUnload.Location = new System.Drawing.Point(6, 111);
            this.chkFleetLoadUnload.Name = "chkFleetLoadUnload";
            this.chkFleetLoadUnload.Size = new System.Drawing.Size(125, 17);
            this.chkFleetLoadUnload.TabIndex = 4;
            this.chkFleetLoadUnload.Text = "Railcar Load/Unload";
            this.chkFleetLoadUnload.UseVisualStyleBackColor = true;
            this.chkFleetLoadUnload.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkFleetTrainCrew
            // 
            this.chkFleetTrainCrew.AutoSize = true;
            this.chkFleetTrainCrew.Location = new System.Drawing.Point(6, 88);
            this.chkFleetTrainCrew.Name = "chkFleetTrainCrew";
            this.chkFleetTrainCrew.Size = new System.Drawing.Size(131, 17);
            this.chkFleetTrainCrew.TabIndex = 3;
            this.chkFleetTrainCrew.Text = "Train Crew Operations";
            this.chkFleetTrainCrew.UseVisualStyleBackColor = true;
            this.chkFleetTrainCrew.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkFleetYardmaster
            // 
            this.chkFleetYardmaster.AutoSize = true;
            this.chkFleetYardmaster.Location = new System.Drawing.Point(6, 65);
            this.chkFleetYardmaster.Name = "chkFleetYardmaster";
            this.chkFleetYardmaster.Size = new System.Drawing.Size(133, 17);
            this.chkFleetYardmaster.TabIndex = 2;
            this.chkFleetYardmaster.Text = "Yardmaster Operations";
            this.chkFleetYardmaster.UseVisualStyleBackColor = true;
            this.chkFleetYardmaster.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkFleetLeasing
            // 
            this.chkFleetLeasing.AutoSize = true;
            this.chkFleetLeasing.Location = new System.Drawing.Point(6, 42);
            this.chkFleetLeasing.Name = "chkFleetLeasing";
            this.chkFleetLeasing.Size = new System.Drawing.Size(120, 17);
            this.chkFleetLeasing.TabIndex = 1;
            this.chkFleetLeasing.Text = "Lease Management";
            this.chkFleetLeasing.UseVisualStyleBackColor = true;
            this.chkFleetLeasing.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkFleetSetup
            // 
            this.chkFleetSetup.AutoSize = true;
            this.chkFleetSetup.Location = new System.Drawing.Point(6, 19);
            this.chkFleetSetup.Name = "chkFleetSetup";
            this.chkFleetSetup.Size = new System.Drawing.Size(91, 17);
            this.chkFleetSetup.TabIndex = 0;
            this.chkFleetSetup.Text = "System Setup";
            this.chkFleetSetup.UseVisualStyleBackColor = true;
            this.chkFleetSetup.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // frmEmployee
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(431, 233);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboEmployees);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEmployee_FormClosed);
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            this.Shown += new System.EventHandler(this.frmEmployee_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkManageEmails;
        private System.Windows.Forms.CheckBox chkManageEmployees;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ComboBox cboEmployees;
        private Loader loader;
        private System.Windows.Forms.CheckBox chkManageAccounts;
        private System.Windows.Forms.CheckBox chkManageLocations;
        private System.Windows.Forms.CheckBox chkIssueWireTransfers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkFleetYardmaster;
        private System.Windows.Forms.CheckBox chkFleetLeasing;
        private System.Windows.Forms.CheckBox chkFleetSetup;
        private System.Windows.Forms.CheckBox chkFleetLoadUnload;
        private System.Windows.Forms.CheckBox chkFleetTrainCrew;
    }
}