namespace MesaSuite.NotificationsAndTasks
{
    partial class CustomNotificationRow
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
            this.lblName = new ReaLTaiizor.Controls.BigLabel();
            this.lblInfo = new ReaLTaiizor.Controls.SmallLabel();
            this.lostButton1 = new ReaLTaiizor.Controls.LostButton();
            this.lostButton2 = new ReaLTaiizor.Controls.LostButton();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(665, 49);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Notification Nameqg";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblInfo.Location = new System.Drawing.Point(0, 45);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(668, 41);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Category: Test\r\nScope: Company\r\nPublished: Yes";
            // 
            // lostButton1
            // 
            this.lostButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lostButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lostButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lostButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lostButton1.ForeColor = System.Drawing.Color.White;
            this.lostButton1.HoverColor = System.Drawing.Color.DodgerBlue;
            this.lostButton1.Image = null;
            this.lostButton1.Location = new System.Drawing.Point(586, 89);
            this.lostButton1.Name = "lostButton1";
            this.lostButton1.Size = new System.Drawing.Size(79, 24);
            this.lostButton1.TabIndex = 2;
            this.lostButton1.Text = "Settings";
            // 
            // lostButton2
            // 
            this.lostButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lostButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lostButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lostButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lostButton2.ForeColor = System.Drawing.Color.White;
            this.lostButton2.HoverColor = System.Drawing.Color.DodgerBlue;
            this.lostButton2.Image = null;
            this.lostButton2.Location = new System.Drawing.Point(501, 89);
            this.lostButton2.Name = "lostButton2";
            this.lostButton2.Size = new System.Drawing.Size(79, 24);
            this.lostButton2.TabIndex = 2;
            this.lostButton2.Text = "Delete";
            // 
            // CustomNotificationRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.lostButton2);
            this.Controls.Add(this.lostButton1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblName);
            this.Name = "CustomNotificationRow";
            this.Size = new System.Drawing.Size(668, 121);
            this.Load += new System.EventHandler(this.CustomNotificationRow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.BigLabel lblName;
        private ReaLTaiizor.Controls.SmallLabel lblInfo;
        private ReaLTaiizor.Controls.LostButton lostButton1;
        private ReaLTaiizor.Controls.LostButton lostButton2;
    }
}
