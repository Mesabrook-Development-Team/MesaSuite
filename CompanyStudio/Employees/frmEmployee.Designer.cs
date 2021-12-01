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
            this.chkManageEmails.Location = new System.Drawing.Point(18, 51);
            this.chkManageEmails.Name = "chkManageEmails";
            this.chkManageEmails.Size = new System.Drawing.Size(98, 17);
            this.chkManageEmails.TabIndex = 1;
            this.chkManageEmails.Text = "Manage Emails";
            this.chkManageEmails.UseVisualStyleBackColor = true;
            this.chkManageEmails.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkManageEmployees
            // 
            this.chkManageEmployees.AutoSize = true;
            this.chkManageEmployees.Location = new System.Drawing.Point(18, 74);
            this.chkManageEmployees.Name = "chkManageEmployees";
            this.chkManageEmployees.Size = new System.Drawing.Size(119, 17);
            this.chkManageEmployees.TabIndex = 2;
            this.chkManageEmployees.Text = "Manage Employees";
            this.chkManageEmployees.UseVisualStyleBackColor = true;
            this.chkManageEmployees.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(317, 117);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(236, 117);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 5;
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
            this.cboEmployees.Size = new System.Drawing.Size(339, 21);
            this.cboEmployees.TabIndex = 0;
            this.cboEmployees.SelectedIndexChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // loader
            // 
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(404, 153);
            this.loader.TabIndex = 5;
            this.loader.Visible = false;
            // 
            // chkManageAccounts
            // 
            this.chkManageAccounts.AutoSize = true;
            this.chkManageAccounts.Location = new System.Drawing.Point(18, 97);
            this.chkManageAccounts.Name = "chkManageAccounts";
            this.chkManageAccounts.Size = new System.Drawing.Size(113, 17);
            this.chkManageAccounts.TabIndex = 3;
            this.chkManageAccounts.Text = "Manage Accounts";
            this.chkManageAccounts.UseVisualStyleBackColor = true;
            this.chkManageAccounts.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // frmEmployee
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(404, 153);
            this.Controls.Add(this.cboEmployees);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.chkManageAccounts);
            this.Controls.Add(this.chkManageEmployees);
            this.Controls.Add(this.chkManageEmails);
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
    }
}