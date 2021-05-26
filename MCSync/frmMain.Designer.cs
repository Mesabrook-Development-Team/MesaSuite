namespace MCSync
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
            this.picMainLogo = new System.Windows.Forms.PictureBox();
            this.btnHelp = new System.Windows.Forms.PictureBox();
            this.btnConf = new System.Windows.Forms.Panel();
            this.btnSync = new System.Windows.Forms.Panel();
            this.lblDocumentation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMainLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // picMainLogo
            // 
            this.picMainLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picMainLogo.BackColor = System.Drawing.Color.Transparent;
            this.picMainLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picMainLogo.BackgroundImage")));
            this.picMainLogo.Location = new System.Drawing.Point(208, 42);
            this.picMainLogo.Name = "picMainLogo";
            this.picMainLogo.Size = new System.Drawing.Size(370, 76);
            this.picMainLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMainLogo.TabIndex = 2;
            this.picMainLogo.TabStop = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.Image = global::MCSync.Properties.Resources.buttonHelp;
            this.btnHelp.Location = new System.Drawing.Point(742, 403);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(33, 40);
            this.btnHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHelp.TabIndex = 6;
            this.btnHelp.TabStop = false;
            this.btnHelp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnHelp_MouseClick);
            this.btnHelp.MouseEnter += new System.EventHandler(this.btnHelp_MouseEnter);
            this.btnHelp.MouseLeave += new System.EventHandler(this.btnHelp_MouseLeave);
            // 
            // btnConf
            // 
            this.btnConf.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConf.BackColor = System.Drawing.Color.Transparent;
            this.btnConf.BackgroundImage = global::MCSync.Properties.Resources.btnOptBase;
            this.btnConf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConf.Location = new System.Drawing.Point(291, 168);
            this.btnConf.Name = "btnConf";
            this.btnConf.Size = new System.Drawing.Size(204, 57);
            this.btnConf.TabIndex = 7;
            this.btnConf.MouseClick += new System.Windows.Forms.MouseEventHandler(this.newBtnConf_MouseClick);
            this.btnConf.MouseEnter += new System.EventHandler(this.newBtnConf_MouseEnter);
            this.btnConf.MouseLeave += new System.EventHandler(this.newBtnConf_MouseLeave);
            // 
            // btnSync
            // 
            this.btnSync.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSync.BackColor = System.Drawing.Color.Transparent;
            this.btnSync.BackgroundImage = global::MCSync.Properties.Resources.btnSyncBase;
            this.btnSync.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSync.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSync.Location = new System.Drawing.Point(291, 246);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(204, 57);
            this.btnSync.TabIndex = 8;
            this.btnSync.MouseClick += new System.Windows.Forms.MouseEventHandler(this.newBtnSync_MouseClick);
            this.btnSync.MouseEnter += new System.EventHandler(this.newBtnSync_MouseEnter);
            this.btnSync.MouseLeave += new System.EventHandler(this.newBtnSync_MouseLeave);
            // 
            // lblDocumentation
            // 
            this.lblDocumentation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocumentation.AutoSize = true;
            this.lblDocumentation.BackColor = System.Drawing.Color.Transparent;
            this.lblDocumentation.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentation.ForeColor = System.Drawing.Color.White;
            this.lblDocumentation.Location = new System.Drawing.Point(691, 414);
            this.lblDocumentation.Name = "lblDocumentation";
            this.lblDocumentation.Size = new System.Drawing.Size(45, 19);
            this.lblDocumentation.TabIndex = 9;
            this.lblDocumentation.Text = "Help";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::MCSync.Properties.Resources.b1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(787, 455);
            this.Controls.Add(this.lblDocumentation);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.btnConf);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.picMainLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Sync";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMainLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHelp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picMainLogo;
        private System.Windows.Forms.PictureBox btnHelp;
        private System.Windows.Forms.Panel btnConf;
        private System.Windows.Forms.Panel btnSync;
        private System.Windows.Forms.Label lblDocumentation;
    }
}

