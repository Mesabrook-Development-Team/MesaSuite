namespace GovernmentPortal.WireTransfers
{
    partial class frmIssue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIssue));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSend = new System.Windows.Forms.Button();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtToAccount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTransferAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAvailableAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFromAccount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loader = new GovernmentPortal.Loader();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(268, 130);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(2);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 18;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSend
            // 
            this.cmdSend.Location = new System.Drawing.Point(347, 130);
            this.cmdSend.Margin = new System.Windows.Forms.Padding(2);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(75, 23);
            this.cmdSend.TabIndex = 17;
            this.cmdSend.Text = "Send";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(103, 106);
            this.txtMemo.Margin = new System.Windows.Forms.Padding(2);
            this.txtMemo.MaxLength = 100;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(319, 20);
            this.txtMemo.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 109);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Memo:";
            // 
            // txtToAccount
            // 
            this.txtToAccount.Location = new System.Drawing.Point(103, 58);
            this.txtToAccount.Margin = new System.Windows.Forms.Padding(2);
            this.txtToAccount.Name = "txtToAccount";
            this.txtToAccount.Size = new System.Drawing.Size(319, 20);
            this.txtToAccount.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 61);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "To Account:";
            // 
            // txtTransferAmount
            // 
            this.txtTransferAmount.Location = new System.Drawing.Point(103, 82);
            this.txtTransferAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtTransferAmount.Name = "txtTransferAmount";
            this.txtTransferAmount.Size = new System.Drawing.Size(133, 20);
            this.txtTransferAmount.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Transfer Amount:";
            // 
            // txtAvailableAmount
            // 
            this.txtAvailableAmount.Location = new System.Drawing.Point(103, 34);
            this.txtAvailableAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAvailableAmount.Name = "txtAvailableAmount";
            this.txtAvailableAmount.ReadOnly = true;
            this.txtAvailableAmount.Size = new System.Drawing.Size(133, 20);
            this.txtAvailableAmount.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Available Amount:";
            // 
            // cboFromAccount
            // 
            this.cboFromAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFromAccount.FormattingEnabled = true;
            this.cboFromAccount.Location = new System.Drawing.Point(103, 9);
            this.cboFromAccount.Margin = new System.Windows.Forms.Padding(2);
            this.cboFromAccount.Name = "cboFromAccount";
            this.cboFromAccount.Size = new System.Drawing.Size(319, 21);
            this.cboFromAccount.TabIndex = 7;
            this.cboFromAccount.SelectedIndexChanged += new System.EventHandler(this.cboFromAccount_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "From Account:";
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(436, 160);
            this.loader.TabIndex = 19;
            this.loader.Visible = false;
            // 
            // frmIssue
            // 
            this.AcceptButton = this.cmdSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(435, 158);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSend);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtToAccount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTransferAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAvailableAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboFromAccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Wire Transfer";
            this.Load += new System.EventHandler(this.frmIssue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtToAccount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTransferAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAvailableAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFromAccount;
        private System.Windows.Forms.Label label1;
        private Loader loader;
    }
}