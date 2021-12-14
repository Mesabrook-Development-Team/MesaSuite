
namespace GovernmentPortal
{
    partial class frmSelectGovernment
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboGovernments = new System.Windows.Forms.ComboBox();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.loader = new GovernmentPortal.Loader();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a government to access:";
            // 
            // cboGovernments
            // 
            this.cboGovernments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGovernments.FormattingEnabled = true;
            this.cboGovernments.Location = new System.Drawing.Point(12, 46);
            this.cboGovernments.Name = "cboGovernments";
            this.cboGovernments.Size = new System.Drawing.Size(361, 21);
            this.cboGovernments.TabIndex = 0;
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(298, 73);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(75, 23);
            this.cmdConnect.TabIndex = 1;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(217, 73);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 23);
            this.cmdExit.TabIndex = 2;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(385, 126);
            this.loader.TabIndex = 3;
            // 
            // frmSelectGovernment
            // 
            this.AcceptButton = this.cmdConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(385, 126);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdConnect);
            this.Controls.Add(this.cboGovernments);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loader);
            this.Name = "frmSelectGovernment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Government Selection";
            this.Load += new System.EventHandler(this.frmSelectGovernment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboGovernments;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.Button cmdExit;
        private Loader loader;
    }
}