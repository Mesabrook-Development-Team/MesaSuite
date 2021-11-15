
namespace CompanyStudio.Accounts
{
    partial class frmCloseAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCloseAccount));
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountToClose = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDestAccount = new System.Windows.Forms.ComboBox();
            this.cmdConfirm = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.loader = new CompanyStudio.Loader();
            this.studioFormExtender = new CompanyStudio.StudioFormExtender(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account To Close:";
            // 
            // txtAccountToClose
            // 
            this.txtAccountToClose.Location = new System.Drawing.Point(113, 12);
            this.txtAccountToClose.Name = "txtAccountToClose";
            this.txtAccountToClose.ReadOnly = true;
            this.txtAccountToClose.Size = new System.Drawing.Size(204, 20);
            this.txtAccountToClose.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Balance:";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(113, 38);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(204, 20);
            this.txtBalance.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Where should this Account\'s balance be moved to?";
            // 
            // cboDestAccount
            // 
            this.cboDestAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestAccount.FormattingEnabled = true;
            this.cboDestAccount.Location = new System.Drawing.Point(15, 77);
            this.cboDestAccount.Name = "cboDestAccount";
            this.cboDestAccount.Size = new System.Drawing.Size(302, 21);
            this.cboDestAccount.TabIndex = 2;
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.Location = new System.Drawing.Point(242, 104);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Size = new System.Drawing.Size(75, 23);
            this.cmdConfirm.TabIndex = 3;
            this.cmdConfirm.Text = "Confirm";
            this.cmdConfirm.UseVisualStyleBackColor = true;
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(161, 104);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // loader
            // 
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(338, 138);
            this.loader.TabIndex = 5;
            this.loader.Visible = false;
            // 
            // frmCloseAccount
            // 
            this.AcceptButton = this.cmdConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(340, 137);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.cboDestAccount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAccountToClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCloseAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Close Account";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCloseAccount_FormClosed);
            this.Load += new System.EventHandler(this.frmCloseAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountToClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDestAccount;
        private System.Windows.Forms.Button cmdConfirm;
        private System.Windows.Forms.Button cmdCancel;
        private Loader loader;
        private StudioFormExtender studioFormExtender;
    }
}