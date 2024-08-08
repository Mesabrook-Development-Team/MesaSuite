namespace MesaSuite.NotificationsAndTasks.NotificationEventWizard
{
    partial class frmNotificationEventWizardShell
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
            this.formTheme1 = new ReaLTaiizor.Forms.FormTheme();
            this.loader = new ReaLTaiizor.Controls.ProgressIndicator();
            this.cmdCancel = new ReaLTaiizor.Controls.ForeverButton();
            this.cmdBack = new ReaLTaiizor.Controls.ForeverButton();
            this.cmdNext = new ReaLTaiizor.Controls.ForeverButton();
            this.cmdRun = new ReaLTaiizor.Controls.ForeverButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lstNav = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.formTheme1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formTheme1
            // 
            this.formTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.formTheme1.Controls.Add(this.loader);
            this.formTheme1.Controls.Add(this.cmdCancel);
            this.formTheme1.Controls.Add(this.cmdBack);
            this.formTheme1.Controls.Add(this.cmdNext);
            this.formTheme1.Controls.Add(this.cmdRun);
            this.formTheme1.Controls.Add(this.pnlContent);
            this.formTheme1.Controls.Add(this.lstNav);
            this.formTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formTheme1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.formTheme1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.formTheme1.Location = new System.Drawing.Point(0, 0);
            this.formTheme1.Name = "formTheme1";
            this.formTheme1.Padding = new System.Windows.Forms.Padding(3, 28, 3, 28);
            this.formTheme1.Sizable = true;
            this.formTheme1.Size = new System.Drawing.Size(614, 450);
            this.formTheme1.SmartBounds = false;
            this.formTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.formTheme1.TabIndex = 0;
            this.formTheme1.Text = "New Notification Wizard";
            // 
            // loader
            // 
            this.loader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(63)))), ((int)(((byte)(74)))));
            this.loader.Location = new System.Drawing.Point(267, 185);
            this.loader.MinimumSize = new System.Drawing.Size(50, 50);
            this.loader.Name = "loader";
            this.loader.P_AnimationColor = System.Drawing.Color.DimGray;
            this.loader.P_AnimationSpeed = 100;
            this.loader.P_BaseColor = System.Drawing.Color.DarkGray;
            this.loader.Size = new System.Drawing.Size(80, 80);
            this.loader.TabIndex = 3;
            this.loader.Text = "progressIndicator1";
            this.loader.Visible = false;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(53)))), ((int)(((byte)(35)))));
            this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmdCancel.Location = new System.Drawing.Point(104, 379);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Rounded = false;
            this.cmdCancel.Size = new System.Drawing.Size(120, 40);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // cmdBack
            // 
            this.cmdBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBack.BackColor = System.Drawing.Color.Transparent;
            this.cmdBack.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cmdBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdBack.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmdBack.Location = new System.Drawing.Point(230, 379);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Rounded = false;
            this.cmdBack.Size = new System.Drawing.Size(120, 40);
            this.cmdBack.TabIndex = 2;
            this.cmdBack.Text = "Back";
            this.cmdBack.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // cmdNext
            // 
            this.cmdNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNext.BackColor = System.Drawing.Color.Transparent;
            this.cmdNext.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cmdNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdNext.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmdNext.Location = new System.Drawing.Point(356, 379);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Rounded = false;
            this.cmdNext.Size = new System.Drawing.Size(120, 40);
            this.cmdNext.TabIndex = 2;
            this.cmdNext.Text = "Next";
            this.cmdNext.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // cmdRun
            // 
            this.cmdRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRun.BackColor = System.Drawing.Color.Transparent;
            this.cmdRun.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cmdRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdRun.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmdRun.Location = new System.Drawing.Point(482, 379);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Rounded = false;
            this.cmdRun.Size = new System.Drawing.Size(120, 40);
            this.cmdRun.TabIndex = 2;
            this.cmdRun.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(63)))), ((int)(((byte)(74)))));
            this.pnlContent.Location = new System.Drawing.Point(156, 25);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(455, 348);
            this.pnlContent.TabIndex = 1;
            // 
            // lstNav
            // 
            this.lstNav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(64)))));
            this.lstNav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstNav.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstNav.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(162)))), ((int)(((byte)(167)))));
            this.lstNav.HideSelection = false;
            this.lstNav.LargeImageList = this.imageList;
            this.lstNav.Location = new System.Drawing.Point(3, 25);
            this.lstNav.Name = "lstNav";
            this.lstNav.Size = new System.Drawing.Size(153, 348);
            this.lstNav.SmallImageList = this.imageList;
            this.lstNav.TabIndex = 0;
            this.lstNav.UseCompatibleStateImageBehavior = false;
            this.lstNav.View = System.Windows.Forms.View.SmallIcon;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmNotificationEventWizardShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 450);
            this.Controls.Add(this.formTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(126, 50);
            this.Name = "frmNotificationEventWizardShell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Notification Wizard";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.formTheme1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.FormTheme formTheme1;
        private System.Windows.Forms.ListView lstNav;
        private System.Windows.Forms.Panel pnlContent;
        private ReaLTaiizor.Controls.ForeverButton cmdRun;
        private ReaLTaiizor.Controls.ForeverButton cmdNext;
        private ReaLTaiizor.Controls.ForeverButton cmdCancel;
        private ReaLTaiizor.Controls.ForeverButton cmdBack;
        private System.Windows.Forms.ImageList imageList;
        private ReaLTaiizor.Controls.ProgressIndicator loader;
    }
}