
namespace CompanyStudio.Accounts
{
    partial class frmTransferFunds
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferFunds));
            this.label1 = new System.Windows.Forms.Label();
            this.cboFrom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAvailable = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdTransfer = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtTransfer = new System.Windows.Forms.TextBox();
            this.loader = new CompanyStudio.Loader();
            this.studioFormExtender1 = new CompanyStudio.StudioFormExtender(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Account:";
            // 
            // cboFrom
            // 
            this.cboFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrom.FormattingEnabled = true;
            this.cboFrom.Location = new System.Drawing.Point(113, 12);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(324, 21);
            this.cboFrom.TabIndex = 0;
            this.cboFrom.SelectedIndexChanged += new System.EventHandler(this.cboFrom_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To Account:";
            // 
            // cboTo
            // 
            this.cboTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTo.FormattingEnabled = true;
            this.cboTo.Location = new System.Drawing.Point(113, 39);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(324, 21);
            this.cboTo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Available Balance:";
            // 
            // txtAvailable
            // 
            this.txtAvailable.Location = new System.Drawing.Point(113, 66);
            this.txtAvailable.Name = "txtAvailable";
            this.txtAvailable.ReadOnly = true;
            this.txtAvailable.Size = new System.Drawing.Size(127, 20);
            this.txtAvailable.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Transfer Amount:";
            // 
            // cmdTransfer
            // 
            this.cmdTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTransfer.Location = new System.Drawing.Point(362, 118);
            this.cmdTransfer.Name = "cmdTransfer";
            this.cmdTransfer.Size = new System.Drawing.Size(75, 23);
            this.cmdTransfer.TabIndex = 4;
            this.cmdTransfer.Text = "Transfer";
            this.cmdTransfer.UseVisualStyleBackColor = true;
            this.cmdTransfer.Click += new System.EventHandler(this.cmdTransfer_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(281, 118);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtTransfer
            // 
            this.txtTransfer.Location = new System.Drawing.Point(113, 92);
            this.txtTransfer.Name = "txtTransfer";
            this.txtTransfer.Size = new System.Drawing.Size(127, 20);
            this.txtTransfer.TabIndex = 3;
            this.txtTransfer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransfer_KeyPress);
            this.txtTransfer.Leave += new System.EventHandler(this.txtTransfer_Leave);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(450, 153);
            this.loader.TabIndex = 0;
            this.loader.Visible = false;
            // 
            // frmTransferFunds
            // 
            this.AcceptButton = this.cmdTransfer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(449, 152);
            this.Controls.Add(this.txtTransfer);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdTransfer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAvailable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTransferFunds";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer Funds";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTransferFunds_FormClosed);
            this.Load += new System.EventHandler(this.frmTransferFunds_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StudioFormExtender studioFormExtender1;
        private Loader loader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAvailable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdTransfer;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox txtTransfer;
    }
}