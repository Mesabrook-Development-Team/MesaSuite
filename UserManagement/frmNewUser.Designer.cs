namespace UserManagement
{
    partial class frmNewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewUser));
            this.label1 = new System.Windows.Forms.Label();
            this.cboUsers = new System.Windows.Forms.ComboBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstPermissions = new System.Windows.Forms.ListView();
            this.imlList = new System.Windows.Forms.ImageList(this.components);
            this.lstSecurityGroups = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdSelectP = new System.Windows.Forms.Button();
            this.cmdSelectSG = new System.Windows.Forms.Button();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select AD User:";
            // 
            // cboUsers
            // 
            this.cboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsers.FormattingEnabled = true;
            this.cboUsers.Location = new System.Drawing.Point(95, 13);
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Size = new System.Drawing.Size(323, 21);
            this.cboUsers.TabIndex = 0;
            this.cboUsers.SelectedIndexChanged += new System.EventHandler(this.cboUsers_SelectedIndexChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(355, 410);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(274, 410);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboUsers);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Existing AD User";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstPermissions);
            this.groupBox2.Controls.Add(this.lstSecurityGroups);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmdSelectP);
            this.groupBox2.Controls.Add(this.cmdSelectSG);
            this.groupBox2.Controls.Add(this.txtLastName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtFirstName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 342);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New AD User";
            // 
            // lstPermissions
            // 
            this.lstPermissions.HideSelection = false;
            this.lstPermissions.Location = new System.Drawing.Point(73, 232);
            this.lstPermissions.Name = "lstPermissions";
            this.lstPermissions.Size = new System.Drawing.Size(345, 74);
            this.lstPermissions.SmallImageList = this.imlList;
            this.lstPermissions.TabIndex = 6;
            this.lstPermissions.UseCompatibleStateImageBehavior = false;
            this.lstPermissions.View = System.Windows.Forms.View.List;
            // 
            // imlList
            // 
            this.imlList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlList.ImageSize = new System.Drawing.Size(16, 16);
            this.imlList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lstSecurityGroups
            // 
            this.lstSecurityGroups.HideSelection = false;
            this.lstSecurityGroups.Location = new System.Drawing.Point(73, 123);
            this.lstSecurityGroups.Name = "lstSecurityGroups";
            this.lstSecurityGroups.Size = new System.Drawing.Size(345, 74);
            this.lstSecurityGroups.SmallImageList = this.imlList;
            this.lstSecurityGroups.TabIndex = 4;
            this.lstSecurityGroups.UseCompatibleStateImageBehavior = false;
            this.lstSecurityGroups.View = System.Windows.Forms.View.List;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Permissions:";
            // 
            // cmdSelectP
            // 
            this.cmdSelectP.Location = new System.Drawing.Point(343, 312);
            this.cmdSelectP.Name = "cmdSelectP";
            this.cmdSelectP.Size = new System.Drawing.Size(75, 23);
            this.cmdSelectP.TabIndex = 7;
            this.cmdSelectP.Text = "Select";
            this.cmdSelectP.UseVisualStyleBackColor = true;
            this.cmdSelectP.Click += new System.EventHandler(this.cmdSelectP_Click);
            // 
            // cmdSelectSG
            // 
            this.cmdSelectSG.Location = new System.Drawing.Point(343, 203);
            this.cmdSelectSG.Name = "cmdSelectSG";
            this.cmdSelectSG.Size = new System.Drawing.Size(75, 23);
            this.cmdSelectSG.TabIndex = 5;
            this.cmdSelectSG.Text = "Select";
            this.cmdSelectSG.UseVisualStyleBackColor = true;
            this.cmdSelectSG.Click += new System.EventHandler(this.cmdSelectSG_Click);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(73, 97);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(345, 20);
            this.txtLastName.TabIndex = 3;
            this.txtLastName.TextChanged += new System.EventHandler(this.DetectExistingOrNew);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "Security Groups:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(73, 71);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(345, 20);
            this.txtFirstName.TabIndex = 2;
            this.txtFirstName.TextChanged += new System.EventHandler(this.DetectExistingOrNew);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "First Name:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(73, 45);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(345, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Email:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(73, 19);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(345, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            // 
            // frmNewUser
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(444, 440);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmNewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New User";
            this.Load += new System.EventHandler(this.frmNewUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboUsers;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ListView lstPermissions;
        private System.Windows.Forms.ListView lstSecurityGroups;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdSelectP;
        private System.Windows.Forms.Button cmdSelectSG;
        private System.Windows.Forms.ImageList imlList;
    }
}