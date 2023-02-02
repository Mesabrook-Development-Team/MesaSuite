namespace SystemManagement
{
    partial class frmEditUser
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Programs", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditUser));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstPrograms = new System.Windows.Forms.ListView();
            this.imlLarge = new System.Windows.Forms.ImageList(this.components);
            this.imlSmall = new System.Windows.Forms.ImageList(this.components);
            this.cmdSelectPrograms = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lstSecurityGroups = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.cmdSelectSecurityGroups = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(73, 15);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(221, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(73, 38);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(221, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Programs:";
            // 
            // lstPrograms
            // 
            listViewGroup1.Header = "Programs";
            listViewGroup1.Name = "grpPrograms";
            this.lstPrograms.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lstPrograms.HideSelection = false;
            this.lstPrograms.LargeImageList = this.imlLarge;
            this.lstPrograms.Location = new System.Drawing.Point(12, 77);
            this.lstPrograms.Name = "lstPrograms";
            this.lstPrograms.Size = new System.Drawing.Size(282, 145);
            this.lstPrograms.SmallImageList = this.imlSmall;
            this.lstPrograms.TabIndex = 4;
            this.lstPrograms.UseCompatibleStateImageBehavior = false;
            this.lstPrograms.View = System.Windows.Forms.View.List;
            this.lstPrograms.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstPrograms_KeyDown);
            // 
            // imlLarge
            // 
            this.imlLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlLarge.ImageSize = new System.Drawing.Size(16, 16);
            this.imlLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imlSmall
            // 
            this.imlSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imlSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmdSelectPrograms
            // 
            this.cmdSelectPrograms.Location = new System.Drawing.Point(219, 228);
            this.cmdSelectPrograms.Name = "cmdSelectPrograms";
            this.cmdSelectPrograms.Size = new System.Drawing.Size(75, 23);
            this.cmdSelectPrograms.TabIndex = 5;
            this.cmdSelectPrograms.Text = "Select";
            this.cmdSelectPrograms.UseVisualStyleBackColor = true;
            this.cmdSelectPrograms.Click += new System.EventHandler(this.cmdSelectPerms_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(510, 257);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 8;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(429, 257);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Security Groups:";
            // 
            // lstSecurityGroups
            // 
            this.lstSecurityGroups.HideSelection = false;
            this.lstSecurityGroups.LargeImageList = this.imlLarge;
            this.lstSecurityGroups.Location = new System.Drawing.Point(303, 77);
            this.lstSecurityGroups.Name = "lstSecurityGroups";
            this.lstSecurityGroups.Size = new System.Drawing.Size(282, 145);
            this.lstSecurityGroups.SmallImageList = this.imlSmall;
            this.lstSecurityGroups.TabIndex = 6;
            this.lstSecurityGroups.UseCompatibleStateImageBehavior = false;
            this.lstSecurityGroups.View = System.Windows.Forms.View.List;
            this.lstSecurityGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSecurityGroups_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(364, 15);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(221, 20);
            this.txtFirstName.TabIndex = 2;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Last Name:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(364, 41);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(221, 20);
            this.txtLastName.TabIndex = 3;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // cmdSelectSecurityGroups
            // 
            this.cmdSelectSecurityGroups.Location = new System.Drawing.Point(510, 228);
            this.cmdSelectSecurityGroups.Name = "cmdSelectSecurityGroups";
            this.cmdSelectSecurityGroups.Size = new System.Drawing.Size(75, 23);
            this.cmdSelectSecurityGroups.TabIndex = 7;
            this.cmdSelectSecurityGroups.Text = "Select";
            this.cmdSelectSecurityGroups.UseVisualStyleBackColor = true;
            this.cmdSelectSecurityGroups.Click += new System.EventHandler(this.cmdSelectSecurityGroups_Click);
            // 
            // frmEditUser
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(593, 291);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdSelectSecurityGroups);
            this.Controls.Add(this.cmdSelectPrograms);
            this.Controls.Add(this.lstSecurityGroups);
            this.Controls.Add(this.lstPrograms);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit User";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lstPrograms;
        private System.Windows.Forms.Button cmdSelectPrograms;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ImageList imlSmall;
        private System.Windows.Forms.ImageList imlLarge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstSecurityGroups;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Button cmdSelectSecurityGroups;
    }
}