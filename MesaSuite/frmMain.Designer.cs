namespace MesaSuite
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pboxMCSync = new System.Windows.Forms.PictureBox();
            this.pboxMCSyncLogo = new System.Windows.Forms.PictureBox();
            this.pnlMCSync = new System.Windows.Forms.Panel();
            this.pnlUserBtn = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblLogInStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.flow = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSystemManagement = new System.Windows.Forms.Panel();
            this.pboxSystemManagement = new System.Windows.Forms.PictureBox();
            this.pboxSystem = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMCSync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMCSyncLogo)).BeginInit();
            this.pnlMCSync.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.flow.SuspendLayout();
            this.pnlSystemManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSystemManagement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSystem)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxMCSync
            // 
            this.pboxMCSync.BackColor = System.Drawing.Color.Transparent;
            this.pboxMCSync.BackgroundImage = global::MesaSuite.Properties.Resources.btnMCSync;
            this.pboxMCSync.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pboxMCSync.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pboxMCSync.Location = new System.Drawing.Point(24, 19);
            this.pboxMCSync.Name = "pboxMCSync";
            this.pboxMCSync.Size = new System.Drawing.Size(92, 97);
            this.pboxMCSync.TabIndex = 1;
            this.pboxMCSync.TabStop = false;
            this.pboxMCSync.Click += new System.EventHandler(this.pboxMCSync_Click);
            this.pboxMCSync.MouseEnter += new System.EventHandler(this.pboxMCSync_MouseEnter);
            this.pboxMCSync.MouseLeave += new System.EventHandler(this.pboxMCSync_MouseLeave);
            this.pboxMCSync.MouseHover += new System.EventHandler(this.pboxMCSync_MouseHover);
            // 
            // pboxMCSyncLogo
            // 
            this.pboxMCSyncLogo.BackColor = System.Drawing.Color.Transparent;
            this.pboxMCSyncLogo.BackgroundImage = global::MesaSuite.Properties.Resources.logo_MCSync;
            this.pboxMCSyncLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pboxMCSyncLogo.Location = new System.Drawing.Point(6, 118);
            this.pboxMCSyncLogo.Name = "pboxMCSyncLogo";
            this.pboxMCSyncLogo.Size = new System.Drawing.Size(115, 25);
            this.pboxMCSyncLogo.TabIndex = 2;
            this.pboxMCSyncLogo.TabStop = false;
            // 
            // pnlMCSync
            // 
            this.pnlMCSync.BackColor = System.Drawing.Color.Transparent;
            this.pnlMCSync.Controls.Add(this.pboxMCSync);
            this.pnlMCSync.Controls.Add(this.pboxMCSyncLogo);
            this.pnlMCSync.Location = new System.Drawing.Point(3, 3);
            this.pnlMCSync.Name = "pnlMCSync";
            this.pnlMCSync.Size = new System.Drawing.Size(132, 155);
            this.pnlMCSync.TabIndex = 3;
            this.pnlMCSync.Visible = false;
            // 
            // pnlUserBtn
            // 
            this.pnlUserBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUserBtn.BackgroundImage = global::MesaSuite.Properties.Resources.btnLoginBase;
            this.pnlUserBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlUserBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlUserBtn.Location = new System.Drawing.Point(731, 479);
            this.pnlUserBtn.Name = "pnlUserBtn";
            this.pnlUserBtn.Size = new System.Drawing.Size(136, 40);
            this.pnlUserBtn.TabIndex = 4;
            this.pnlUserBtn.Click += new System.EventHandler(this.pnlUserBtn_Click);
            this.pnlUserBtn.MouseEnter += new System.EventHandler(this.pnlUserBtn_MouseEnter);
            this.pnlUserBtn.MouseLeave += new System.EventHandler(this.pnlUserBtn_MouseLeave);
            this.pnlUserBtn.MouseHover += new System.EventHandler(this.pnlUserBtn_MouseHover);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(28, 506);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "Version";
            // 
            // lblLogInStatus
            // 
            this.lblLogInStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblLogInStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.lblLogInStatus.ForeColor = System.Drawing.Color.White;
            this.lblLogInStatus.Name = "lblLogInStatus";
            this.lblLogInStatus.Size = new System.Drawing.Size(87, 19);
            this.lblLogInStatus.Text = "Not Logged In";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLogInStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 537);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(879, 24);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // flow
            // 
            this.flow.AutoScroll = true;
            this.flow.BackColor = System.Drawing.Color.Transparent;
            this.flow.Controls.Add(this.pnlMCSync);
            this.flow.Controls.Add(this.pnlSystemManagement);
            this.flow.Location = new System.Drawing.Point(31, 44);
            this.flow.Name = "flow";
            this.flow.Size = new System.Drawing.Size(836, 429);
            this.flow.TabIndex = 6;
            // 
            // pnlSystemManagement
            // 
            this.pnlSystemManagement.BackColor = System.Drawing.Color.Transparent;
            this.pnlSystemManagement.Controls.Add(this.pboxSystemManagement);
            this.pnlSystemManagement.Controls.Add(this.pboxSystem);
            this.pnlSystemManagement.Location = new System.Drawing.Point(141, 3);
            this.pnlSystemManagement.Name = "pnlSystemManagement";
            this.pnlSystemManagement.Size = new System.Drawing.Size(132, 155);
            this.pnlSystemManagement.TabIndex = 4;
            // 
            // pboxSystemManagement
            // 
            this.pboxSystemManagement.BackColor = System.Drawing.Color.Transparent;
            this.pboxSystemManagement.BackgroundImage = global::MesaSuite.Properties.Resources.icn_system;
            this.pboxSystemManagement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pboxSystemManagement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pboxSystemManagement.Location = new System.Drawing.Point(21, 19);
            this.pboxSystemManagement.Name = "pboxSystemManagement";
            this.pboxSystemManagement.Size = new System.Drawing.Size(92, 97);
            this.pboxSystemManagement.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxSystemManagement.TabIndex = 1;
            this.pboxSystemManagement.TabStop = false;
            this.pboxSystemManagement.Click += new System.EventHandler(this.pboxUserManagement_Click);
            this.pboxSystemManagement.MouseEnter += new System.EventHandler(this.pboxUserManagement_MouseEnter);
            this.pboxSystemManagement.MouseLeave += new System.EventHandler(this.pboxUserManagement_MouseLeave);
            this.pboxSystemManagement.MouseHover += new System.EventHandler(this.pboxUserManagement_MouseHover);
            // 
            // pboxSystem
            // 
            this.pboxSystem.BackColor = System.Drawing.Color.Transparent;
            this.pboxSystem.BackgroundImage = global::MesaSuite.Properties.Resources.lbl_system;
            this.pboxSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pboxSystem.Location = new System.Drawing.Point(18, 118);
            this.pboxSystem.Name = "pboxSystem";
            this.pboxSystem.Size = new System.Drawing.Size(98, 25);
            this.pboxSystem.TabIndex = 2;
            this.pboxSystem.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MesaSuite.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(879, 561);
            this.Controls.Add(this.flow);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.pnlUserBtn);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxMCSync)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMCSyncLogo)).EndInit();
            this.pnlMCSync.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flow.ResumeLayout(false);
            this.pnlSystemManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxSystemManagement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSystem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pboxMCSync;
        private System.Windows.Forms.PictureBox pboxMCSyncLogo;
        private System.Windows.Forms.Panel pnlMCSync;
        private System.Windows.Forms.Panel pnlUserBtn;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ToolStripStatusLabel lblLogInStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.FlowLayoutPanel flow;
        private System.Windows.Forms.Panel pnlSystemManagement;
        private System.Windows.Forms.PictureBox pboxSystemManagement;
        private System.Windows.Forms.PictureBox pboxSystem;
    }
}