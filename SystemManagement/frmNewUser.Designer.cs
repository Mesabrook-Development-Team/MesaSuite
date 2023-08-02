namespace SystemManagement
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
            this.lstPrograms = new System.Windows.Forms.ListView();
            this.imlList = new System.Windows.Forms.ImageList(this.components);
            this.lstSecurityGroups = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdSelectPrograms = new System.Windows.Forms.Button();
            this.cmdSelectSG = new System.Windows.Forms.Button();
            this.txtDiscordID = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkStoreRegister = new System.Windows.Forms.CheckBox();
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
            this.cmdSave.Location = new System.Drawing.Point(355, 455);
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
            this.cmdCancel.Location = new System.Drawing.Point(274, 455);
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
            this.groupBox2.Controls.Add(this.lstPrograms);
            this.groupBox2.Controls.Add(this.lstSecurityGroups);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmdSelectPrograms);
            this.groupBox2.Controls.Add(this.cmdSelectSG);
            this.groupBox2.Controls.Add(this.txtDiscordID);
            this.groupBox2.Controls.Add(this.txtLastName);
            this.groupBox2.Controls.Add(this.label8);
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
            this.groupBox2.Size = new System.Drawing.Size(424, 368);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New AD User";
            // 
            // lstPrograms
            // 
            this.lstPrograms.HideSelection = false;
            this.lstPrograms.Location = new System.Drawing.Point(73, 258);
            this.lstPrograms.Name = "lstPrograms";
            this.lstPrograms.Size = new System.Drawing.Size(345, 74);
            this.lstPrograms.SmallImageList = this.imlList;
            this.lstPrograms.TabIndex = 7;
            this.lstPrograms.UseCompatibleStateImageBehavior = false;
            this.lstPrograms.View = System.Windows.Forms.View.List;
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
            this.lstSecurityGroups.Location = new System.Drawing.Point(73, 149);
            this.lstSecurityGroups.Name = "lstSecurityGroups";
            this.lstSecurityGroups.Size = new System.Drawing.Size(345, 74);
            this.lstSecurityGroups.SmallImageList = this.imlList;
            this.lstSecurityGroups.TabIndex = 5;
            this.lstSecurityGroups.UseCompatibleStateImageBehavior = false;
            this.lstSecurityGroups.View = System.Windows.Forms.View.List;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Programs:";
            // 
            // cmdSelectPrograms
            // 
            this.cmdSelectPrograms.Location = new System.Drawing.Point(343, 338);
            this.cmdSelectPrograms.Name = "cmdSelectPrograms";
            this.cmdSelectPrograms.Size = new System.Drawing.Size(75, 23);
            this.cmdSelectPrograms.TabIndex = 8;
            this.cmdSelectPrograms.Text = "Select";
            this.cmdSelectPrograms.UseVisualStyleBackColor = true;
            this.cmdSelectPrograms.Click += new System.EventHandler(this.cmdSelectPrograms_Click);
            // 
            // cmdSelectSG
            // 
            this.cmdSelectSG.Location = new System.Drawing.Point(343, 229);
            this.cmdSelectSG.Name = "cmdSelectSG";
            this.cmdSelectSG.Size = new System.Drawing.Size(75, 23);
            this.cmdSelectSG.TabIndex = 6;
            this.cmdSelectSG.Text = "Select";
            this.cmdSelectSG.UseVisualStyleBackColor = true;
            this.cmdSelectSG.Click += new System.EventHandler(this.cmdSelectSG_Click);
            // 
            // txtDiscordID
            // 
            this.txtDiscordID.Location = new System.Drawing.Point(73, 123);
            this.txtDiscordID.Name = "txtDiscordID";
            this.txtDiscordID.Size = new System.Drawing.Size(345, 20);
            this.txtDiscordID.TabIndex = 4;
            this.txtDiscordID.TextChanged += new System.EventHandler(this.DetectExistingOrNew);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(73, 97);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(345, 20);
            this.txtLastName.TabIndex = 3;
            this.txtLastName.TextChanged += new System.EventHandler(this.DetectExistingOrNew);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Discord ID:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 149);
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
            // chkStoreRegister
            // 
            this.chkStoreRegister.AutoSize = true;
            this.chkStoreRegister.Location = new System.Drawing.Point(178, 436);
            this.chkStoreRegister.Name = "chkStoreRegister";
            this.chkStoreRegister.Size = new System.Drawing.Size(99, 17);
            this.chkStoreRegister.TabIndex = 4;
            this.chkStoreRegister.Text = "Is Immersibrook";
            this.chkStoreRegister.UseVisualStyleBackColor = true;
            // 
            // frmNewUser
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(444, 487);
            this.Controls.Add(this.chkStoreRegister);
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
            this.Text = "Create a New User";
            this.Load += new System.EventHandler(this.frmNewUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ListView lstPrograms;
        private System.Windows.Forms.ListView lstSecurityGroups;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdSelectPrograms;
        private System.Windows.Forms.Button cmdSelectSG;
        private System.Windows.Forms.ImageList imlList;
        private System.Windows.Forms.TextBox txtDiscordID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkStoreRegister;
    }
}