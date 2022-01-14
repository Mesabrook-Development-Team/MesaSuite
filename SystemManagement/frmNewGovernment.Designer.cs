namespace SystemManagement
{
    partial class frmNewGovernment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewGovernment));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstOfficials = new System.Windows.Forms.ListView();
            this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imlSmall = new System.Windows.Forms.ImageList(this.components);
            this.cmdSelectOfficials = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cboDomain = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkMintCurrency = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "What is the name of the new government?";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(284, 20);
            this.txtName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Who manages officials of this government?";
            // 
            // lstOfficials
            // 
            this.lstOfficials.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUser});
            this.lstOfficials.FullRowSelect = true;
            this.lstOfficials.HideSelection = false;
            this.lstOfficials.Location = new System.Drawing.Point(12, 126);
            this.lstOfficials.Name = "lstOfficials";
            this.lstOfficials.Size = new System.Drawing.Size(284, 112);
            this.lstOfficials.SmallImageList = this.imlSmall;
            this.lstOfficials.TabIndex = 3;
            this.lstOfficials.UseCompatibleStateImageBehavior = false;
            this.lstOfficials.View = System.Windows.Forms.View.Details;
            // 
            // colUser
            // 
            this.colUser.Text = "User";
            this.colUser.Width = 275;
            // 
            // imlSmall
            // 
            this.imlSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imlSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmdSelectOfficials
            // 
            this.cmdSelectOfficials.Location = new System.Drawing.Point(211, 244);
            this.cmdSelectOfficials.Name = "cmdSelectOfficials";
            this.cmdSelectOfficials.Size = new System.Drawing.Size(85, 23);
            this.cmdSelectOfficials.TabIndex = 4;
            this.cmdSelectOfficials.Text = "Select Officials";
            this.cmdSelectOfficials.UseVisualStyleBackColor = true;
            this.cmdSelectOfficials.Click += new System.EventHandler(this.cmdSelectOfficials_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(211, 273);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(85, 23);
            this.cmdSave.TabIndex = 5;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(120, 273);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(85, 23);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cboDomain
            // 
            this.cboDomain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDomain.FormattingEnabled = true;
            this.cboDomain.Location = new System.Drawing.Point(12, 63);
            this.cboDomain.Name = "cboDomain";
            this.cboDomain.Size = new System.Drawing.Size(284, 21);
            this.cboDomain.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "What is the email domain for this government?";
            // 
            // chkMintCurrency
            // 
            this.chkMintCurrency.AutoSize = true;
            this.chkMintCurrency.Location = new System.Drawing.Point(12, 90);
            this.chkMintCurrency.Name = "chkMintCurrency";
            this.chkMintCurrency.Size = new System.Drawing.Size(197, 17);
            this.chkMintCurrency.TabIndex = 2;
            this.chkMintCurrency.Text = "Can this Government mint currency?";
            this.chkMintCurrency.UseVisualStyleBackColor = true;
            // 
            // frmNewGovernment
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(307, 304);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewGovernment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create a New Government";
            this.Load += new System.EventHandler(this.frmNewGovernment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstOfficials;
        private System.Windows.Forms.ImageList imlSmall;
        private System.Windows.Forms.ColumnHeader colUser;
        private System.Windows.Forms.Button cmdSelectOfficials;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ComboBox cboDomain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkMintCurrency;
    }
}