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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlMainTimer = new System.Windows.Forms.Timer(this.components);
            this.fButtonSync = new MCSync.FancyButton();
            this.fButtonOptions = new MCSync.FancyButton();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.BackgroundImage = global::MCSync.Properties.Resources.tile_transparent1;
            this.pnlMain.Controls.Add(this.lblVersion);
            this.pnlMain.Controls.Add(this.fButtonSync);
            this.pnlMain.Controls.Add(this.fButtonOptions);
            this.pnlMain.Controls.Add(this.pictureBox1);
            this.pnlMain.ForeColor = System.Drawing.Color.Transparent;
            this.pnlMain.Location = new System.Drawing.Point(251, 90);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(400, 342);
            this.pnlMain.TabIndex = 10;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(160, 297);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(81, 13);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version 0.0.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::MCSync.Properties.Resources.main_logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(88, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.Transparent;
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(902, 522);
            this.pnlForm.TabIndex = 13;
            // 
            // pnlMainTimer
            // 
            this.pnlMainTimer.Tick += new System.EventHandler(this.pnlMainTimer_Tick);
            // 
            // fButtonSync
            // 
            this.fButtonSync.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fButtonSync.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fButtonSync.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.fButtonSync.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.fButtonSync.BorderRadius = 5;
            this.fButtonSync.BorderRadius1 = 5;
            this.fButtonSync.BorderSize = 0;
            this.fButtonSync.BorderSize1 = 0;
            this.fButtonSync.FlatAppearance.BorderSize = 0;
            this.fButtonSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fButtonSync.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fButtonSync.ForeColor = System.Drawing.Color.White;
            this.fButtonSync.Location = new System.Drawing.Point(125, 221);
            this.fButtonSync.Name = "fButtonSync";
            this.fButtonSync.Size = new System.Drawing.Size(150, 40);
            this.fButtonSync.TabIndex = 2;
            this.fButtonSync.Text = "Sync";
            this.fButtonSync.TextColor = System.Drawing.Color.White;
            this.fButtonSync.UseCompatibleTextRendering = true;
            this.fButtonSync.UseVisualStyleBackColor = false;
            this.fButtonSync.Click += new System.EventHandler(this.fButtonSync_Click);
            // 
            // fButtonOptions
            // 
            this.fButtonOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fButtonOptions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fButtonOptions.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.fButtonOptions.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.fButtonOptions.BorderRadius = 5;
            this.fButtonOptions.BorderRadius1 = 5;
            this.fButtonOptions.BorderSize = 0;
            this.fButtonOptions.BorderSize1 = 0;
            this.fButtonOptions.FlatAppearance.BorderSize = 0;
            this.fButtonOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fButtonOptions.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fButtonOptions.ForeColor = System.Drawing.Color.White;
            this.fButtonOptions.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.fButtonOptions.Location = new System.Drawing.Point(125, 158);
            this.fButtonOptions.Name = "fButtonOptions";
            this.fButtonOptions.Size = new System.Drawing.Size(150, 40);
            this.fButtonOptions.TabIndex = 1;
            this.fButtonOptions.Text = "Options";
            this.fButtonOptions.TextColor = System.Drawing.Color.White;
            this.fButtonOptions.UseCompatibleTextRendering = true;
            this.fButtonOptions.UseVisualStyleBackColor = false;
            this.fButtonOptions.Click += new System.EventHandler(this.fancyButton1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::MCSync.Properties.Resources.b1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(902, 522);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlForm);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Sync";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmMain_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private FancyButton fButtonOptions;
        private FancyButton fButtonSync;
        private System.Windows.Forms.Label lblVersion;
        public System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Timer pnlMainTimer;
        public System.Windows.Forms.Panel pnlForm;
    }
}

