namespace MesaSuite.NotificationsAndTasks.NotificationEventWizard
{
    partial class CollectingInfoStep
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectingInfoStep));
            this.label4 = new System.Windows.Forms.Label();
            this.cboScopes = new ReaLTaiizor.Controls.ForeverComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new ReaLTaiizor.Controls.ForeverTextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-2, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 91);
            this.label4.TabIndex = 12;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // cboScopes
            // 
            this.cboScopes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboScopes.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
            this.cboScopes.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.cboScopes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboScopes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboScopes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScopes.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cboScopes.ForeColor = System.Drawing.Color.White;
            this.cboScopes.FormattingEnabled = true;
            this.cboScopes.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cboScopes.HoverFontColor = System.Drawing.Color.White;
            this.cboScopes.ItemHeight = 18;
            this.cboScopes.Items.AddRange(new object[] {
            "Company",
            "Fleet",
            "Global",
            "Government",
            "Location"});
            this.cboScopes.Location = new System.Drawing.Point(3, 80);
            this.cboScopes.Name = "cboScopes";
            this.cboScopes.Size = new System.Drawing.Size(374, 24);
            this.cboScopes.Sorted = true;
            this.cboScopes.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "What Scope will it be?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "What will your Notification be called?";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.txtName.FocusOnHover = false;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtName.Location = new System.Drawing.Point(3, 16);
            this.txtName.MaxLength = 32767;
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = false;
            this.txtName.Size = new System.Drawing.Size(374, 29);
            this.txtName.TabIndex = 9;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtName.UseSystemPasswordChar = false;
            // 
            // CollectingInfoStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboScopes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Name = "CollectingInfoStep";
            this.Size = new System.Drawing.Size(388, 231);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private ReaLTaiizor.Controls.ForeverComboBox cboScopes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.ForeverTextBox txtName;
    }
}
