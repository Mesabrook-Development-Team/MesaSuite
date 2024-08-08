namespace MesaSuite.Common.Wizard
{
    partial class frmWizardShell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWizardShell));
            this.cmdRun = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lstNav = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.loader = new CompanyStudio.Loader();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdRun
            // 
            this.cmdRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRun.Location = new System.Drawing.Point(463, 376);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(75, 23);
            this.cmdRun.TabIndex = 31;
            this.cmdRun.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(33, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(518, 33);
            this.lblTitle.TabIndex = 26;
            // 
            // lstNav
            // 
            this.lstNav.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lstNav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstNav.AutoArrange = false;
            this.lstNav.HideSelection = false;
            this.lstNav.Location = new System.Drawing.Point(0, 33);
            this.lstNav.Name = "lstNav";
            this.lstNav.Size = new System.Drawing.Size(144, 337);
            this.lstNav.SmallImageList = this.imageList;
            this.lstNav.TabIndex = 25;
            this.lstNav.UseCompatibleStateImageBehavior = false;
            this.lstNav.View = System.Windows.Forms.View.SmallIcon;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(208, 376);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 28;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdBack
            // 
            this.cmdBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBack.Location = new System.Drawing.Point(295, 376);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(75, 23);
            this.cmdBack.TabIndex = 29;
            this.cmdBack.Text = "< Back";
            this.cmdBack.UseVisualStyleBackColor = true;
            // 
            // cmdNext
            // 
            this.cmdNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNext.Location = new System.Drawing.Point(376, 376);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(75, 23);
            this.cmdNext.TabIndex = 30;
            this.cmdNext.Text = "Next >";
            this.cmdNext.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(1, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(561, 2);
            this.label3.TabIndex = 24;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.White;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(36, 33);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 27;
            this.picLogo.TabStop = false;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Location = new System.Drawing.Point(144, 34);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(407, 336);
            this.pnlContent.TabIndex = 32;
            // 
            // loader
            // 
            this.loader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(177, 155);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(196, 101);
            this.loader.TabIndex = 33;
            this.loader.Visible = false;
            // 
            // frmWizardShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 411);
            this.Controls.Add(this.loader);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.cmdRun);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lstNav);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWizardShell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button cmdRun;
        internal System.Windows.Forms.PictureBox picLogo;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.ListView lstNav;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdBack;
        internal System.Windows.Forms.Button cmdNext;
        internal System.Windows.Forms.Panel pnlContent;
        private CompanyStudio.Loader loader;
    }
}