namespace UserManagement
{
    partial class frmViewPermission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewPermission));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstUsers = new System.Windows.Forms.ListView();
            this.imlLarge = new System.Windows.Forms.ImageList(this.components);
            this.imlSmall = new System.Windows.Forms.ImageList(this.components);
            this.cmdSelect = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(56, 12);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(266, 20);
            this.txtName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Users:";
            // 
            // lstUsers
            // 
            this.lstUsers.HideSelection = false;
            this.lstUsers.LargeImageList = this.imlLarge;
            this.lstUsers.Location = new System.Drawing.Point(12, 79);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(310, 142);
            this.lstUsers.SmallImageList = this.imlSmall;
            this.lstUsers.TabIndex = 2;
            this.lstUsers.UseCompatibleStateImageBehavior = false;
            this.lstUsers.View = System.Windows.Forms.View.List;
            this.lstUsers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstUsers_KeyDown);
            // 
            // imlLarge
            // 
            this.imlLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLarge.ImageStream")));
            this.imlLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imlLarge.Images.SetKeyName(0, "user_large");
            // 
            // imlSmall
            // 
            this.imlSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmall.ImageStream")));
            this.imlSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSmall.Images.SetKeyName(0, "user");
            // 
            // cmdSelect
            // 
            this.cmdSelect.Location = new System.Drawing.Point(247, 227);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(75, 23);
            this.cmdSelect.TabIndex = 3;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Location = new System.Drawing.Point(247, 256);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Key:";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(56, 38);
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(266, 20);
            this.txtKey.TabIndex = 1;
            // 
            // frmViewPermission
            // 
            this.AcceptButton = this.cmdClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(337, 289);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmViewPermission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permission";
            this.Load += new System.EventHandler(this.frmViewPermission_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstUsers;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.ImageList imlSmall;
        private System.Windows.Forms.ImageList imlLarge;
    }
}