namespace SystemManagement
{
    partial class frmEditOfficial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditOfficial));
            this.label1 = new System.Windows.Forms.Label();
            this.txtOfficial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGovernment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkManageEmails = new System.Windows.Forms.CheckBox();
            this.chkManageOfficials = new System.Windows.Forms.CheckBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Official:";
            // 
            // txtOfficial
            // 
            this.txtOfficial.Location = new System.Drawing.Point(86, 38);
            this.txtOfficial.Name = "txtOfficial";
            this.txtOfficial.ReadOnly = true;
            this.txtOfficial.Size = new System.Drawing.Size(212, 20);
            this.txtOfficial.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Government:";
            // 
            // txtGovernment
            // 
            this.txtGovernment.Location = new System.Drawing.Point(86, 12);
            this.txtGovernment.Name = "txtGovernment";
            this.txtGovernment.ReadOnly = true;
            this.txtGovernment.Size = new System.Drawing.Size(212, 20);
            this.txtGovernment.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "What is this official allowed to do?";
            // 
            // chkManageEmails
            // 
            this.chkManageEmails.AutoSize = true;
            this.chkManageEmails.Location = new System.Drawing.Point(12, 77);
            this.chkManageEmails.Name = "chkManageEmails";
            this.chkManageEmails.Size = new System.Drawing.Size(98, 17);
            this.chkManageEmails.TabIndex = 2;
            this.chkManageEmails.Text = "Manage Emails";
            this.chkManageEmails.UseVisualStyleBackColor = true;
            // 
            // chkManageOfficials
            // 
            this.chkManageOfficials.AutoSize = true;
            this.chkManageOfficials.Location = new System.Drawing.Point(12, 100);
            this.chkManageOfficials.Name = "chkManageOfficials";
            this.chkManageOfficials.Size = new System.Drawing.Size(105, 17);
            this.chkManageOfficials.TabIndex = 3;
            this.chkManageOfficials.Text = "Manage Officials";
            this.chkManageOfficials.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(223, 123);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(142, 123);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmEditOfficial
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(310, 156);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.chkManageOfficials);
            this.Controls.Add(this.chkManageEmails);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGovernment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOfficial);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditOfficial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Official";
            this.Load += new System.EventHandler(this.frmEditOfficial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOfficial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGovernment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkManageEmails;
        private System.Windows.Forms.CheckBox chkManageOfficials;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
    }
}