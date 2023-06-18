namespace SystemManagement
{
    partial class frmEditGovernment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditGovernment));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstOfficials = new System.Windows.Forms.ListView();
            this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imlSmall = new System.Windows.Forms.ImageList(this.components);
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdSelectOfficials = new System.Windows.Forms.Button();
            this.cboDomain = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkMintCurrency = new System.Windows.Forms.CheckBox();
            this.chkInterest = new System.Windows.Forms.CheckBox();
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
            this.txtName.Size = new System.Drawing.Size(328, 20);
            this.txtName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Managing Officials:";
            // 
            // lstOfficials
            // 
            this.lstOfficials.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUser});
            this.lstOfficials.FullRowSelect = true;
            this.lstOfficials.HideSelection = false;
            this.lstOfficials.Location = new System.Drawing.Point(15, 101);
            this.lstOfficials.Name = "lstOfficials";
            this.lstOfficials.Size = new System.Drawing.Size(369, 139);
            this.lstOfficials.SmallImageList = this.imlSmall;
            this.lstOfficials.TabIndex = 4;
            this.lstOfficials.UseCompatibleStateImageBehavior = false;
            this.lstOfficials.View = System.Windows.Forms.View.Details;
            // 
            // colUser
            // 
            this.colUser.Text = "User";
            this.colUser.Width = 350;
            // 
            // imlSmall
            // 
            this.imlSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imlSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(208, 275);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(85, 23);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(299, 275);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(85, 23);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdSelectOfficials
            // 
            this.cmdSelectOfficials.Location = new System.Drawing.Point(299, 246);
            this.cmdSelectOfficials.Name = "cmdSelectOfficials";
            this.cmdSelectOfficials.Size = new System.Drawing.Size(85, 23);
            this.cmdSelectOfficials.TabIndex = 5;
            this.cmdSelectOfficials.Text = "Select Officials";
            this.cmdSelectOfficials.UseVisualStyleBackColor = true;
            this.cmdSelectOfficials.Click += new System.EventHandler(this.cmdSelectOfficials_Click);
            // 
            // cboDomain
            // 
            this.cboDomain.FormattingEnabled = true;
            this.cboDomain.Location = new System.Drawing.Point(92, 38);
            this.cboDomain.Name = "cboDomain";
            this.cboDomain.Size = new System.Drawing.Size(292, 21);
            this.cboDomain.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Email Domain:";
            // 
            // chkMintCurrency
            // 
            this.chkMintCurrency.AutoSize = true;
            this.chkMintCurrency.Location = new System.Drawing.Point(75, 65);
            this.chkMintCurrency.Name = "chkMintCurrency";
            this.chkMintCurrency.Size = new System.Drawing.Size(113, 17);
            this.chkMintCurrency.TabIndex = 2;
            this.chkMintCurrency.Text = "Can Mint Currency";
            this.chkMintCurrency.UseVisualStyleBackColor = true;
            // 
            // chkInterest
            // 
            this.chkInterest.AutoSize = true;
            this.chkInterest.Location = new System.Drawing.Point(194, 65);
            this.chkInterest.Name = "chkInterest";
            this.chkInterest.Size = new System.Drawing.Size(131, 17);
            this.chkInterest.TabIndex = 3;
            this.chkInterest.Text = "Can Configure Interest";
            this.chkInterest.UseVisualStyleBackColor = true;
            // 
            // frmEditGovernment
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(400, 309);
            this.Controls.Add(this.chkInterest);
            this.Controls.Add(this.chkMintCurrency);
            this.Controls.Add(this.cboDomain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdSelectOfficials);
            this.Controls.Add(this.lstOfficials);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditGovernment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Government";
            this.Load += new System.EventHandler(this.frmEditGovernment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstOfficials;
        private System.Windows.Forms.ColumnHeader colUser;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdSelectOfficials;
        private System.Windows.Forms.ImageList imlSmall;
        private System.Windows.Forms.ComboBox cboDomain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkMintCurrency;
        private System.Windows.Forms.CheckBox chkInterest;
    }
}