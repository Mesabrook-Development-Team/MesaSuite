namespace MesaSuite.NotificationsAndTasks
{
    partial class frmNotificationCenter
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
            this.tabTaskCenterNav = new ReaLTaiizor.Controls.AirTabPage();
            this.tpgNotifications = new System.Windows.Forms.TabPage();
            this.tpgTasks = new System.Windows.Forms.TabPage();
            this.tpgOptions = new System.Windows.Forms.TabPage();
            this.optionsLoader = new ReaLTaiizor.Controls.ProgressIndicator();
            this.tabScopes = new ReaLTaiizor.Controls.ForeverTabPage();
            this.tbtnGeneral = new System.Windows.Forms.TabPage();
            this.tabGeneral = new ReaLTaiizor.Controls.AirTabPage();
            this.tbtnCompany = new System.Windows.Forms.TabPage();
            this.tabCompany = new ReaLTaiizor.Controls.AirTabPage();
            this.tbtnGovernment = new System.Windows.Forms.TabPage();
            this.tabGovernment = new ReaLTaiizor.Controls.AirTabPage();
            this.tbtnFleet = new System.Windows.Forms.TabPage();
            this.tabFleetTracking = new ReaLTaiizor.Controls.AirTabPage();
            this.tpgWizard = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdAddCustomNotification = new ReaLTaiizor.Controls.LostButton();
            this.customNotificationsLoader = new ReaLTaiizor.Controls.ProgressIndicator();
            this.pnlCustomNotifications = new System.Windows.Forms.Panel();
            this.lblNoCustomNotifications2 = new ReaLTaiizor.Controls.SmallLabel();
            this.lblNoCustomNotifications = new ReaLTaiizor.Controls.BigLabel();
            this.tabTaskCenterNav.SuspendLayout();
            this.tpgOptions.SuspendLayout();
            this.tabScopes.SuspendLayout();
            this.tbtnGeneral.SuspendLayout();
            this.tbtnCompany.SuspendLayout();
            this.tbtnGovernment.SuspendLayout();
            this.tbtnFleet.SuspendLayout();
            this.tpgWizard.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlCustomNotifications.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTaskCenterNav
            // 
            this.tabTaskCenterNav.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabTaskCenterNav.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabTaskCenterNav.Controls.Add(this.tpgNotifications);
            this.tabTaskCenterNav.Controls.Add(this.tpgTasks);
            this.tabTaskCenterNav.Controls.Add(this.tpgOptions);
            this.tabTaskCenterNav.Controls.Add(this.tpgWizard);
            this.tabTaskCenterNav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabTaskCenterNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTaskCenterNav.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTaskCenterNav.ItemSize = new System.Drawing.Size(35, 115);
            this.tabTaskCenterNav.Location = new System.Drawing.Point(0, 0);
            this.tabTaskCenterNav.Multiline = true;
            this.tabTaskCenterNav.Name = "tabTaskCenterNav";
            this.tabTaskCenterNav.NormalTextColor = System.Drawing.Color.DimGray;
            this.tabTaskCenterNav.SelectedIndex = 0;
            this.tabTaskCenterNav.SelectedTabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabTaskCenterNav.SelectedTextColor = System.Drawing.Color.Gainsboro;
            this.tabTaskCenterNav.ShowOuterBorders = false;
            this.tabTaskCenterNav.Size = new System.Drawing.Size(774, 383);
            this.tabTaskCenterNav.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabTaskCenterNav.SquareColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(87)))), ((int)(((byte)(100)))));
            this.tabTaskCenterNav.TabCursor = System.Windows.Forms.Cursors.Hand;
            this.tabTaskCenterNav.TabIndex = 0;
            // 
            // tpgNotifications
            // 
            this.tpgNotifications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tpgNotifications.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpgNotifications.Location = new System.Drawing.Point(119, 4);
            this.tpgNotifications.Name = "tpgNotifications";
            this.tpgNotifications.Padding = new System.Windows.Forms.Padding(3);
            this.tpgNotifications.Size = new System.Drawing.Size(651, 375);
            this.tpgNotifications.TabIndex = 0;
            this.tpgNotifications.Text = "Notifications";
            // 
            // tpgTasks
            // 
            this.tpgTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tpgTasks.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpgTasks.Location = new System.Drawing.Point(119, 4);
            this.tpgTasks.Name = "tpgTasks";
            this.tpgTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tpgTasks.Size = new System.Drawing.Size(651, 375);
            this.tpgTasks.TabIndex = 1;
            this.tpgTasks.Text = "Tasks";
            // 
            // tpgOptions
            // 
            this.tpgOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tpgOptions.Controls.Add(this.optionsLoader);
            this.tpgOptions.Controls.Add(this.tabScopes);
            this.tpgOptions.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpgOptions.Location = new System.Drawing.Point(119, 4);
            this.tpgOptions.Name = "tpgOptions";
            this.tpgOptions.Size = new System.Drawing.Size(651, 375);
            this.tpgOptions.TabIndex = 2;
            this.tpgOptions.Text = "Options";
            // 
            // optionsLoader
            // 
            this.optionsLoader.Location = new System.Drawing.Point(285, 147);
            this.optionsLoader.MinimumSize = new System.Drawing.Size(50, 50);
            this.optionsLoader.Name = "optionsLoader";
            this.optionsLoader.P_AnimationColor = System.Drawing.Color.DimGray;
            this.optionsLoader.P_AnimationSpeed = 100;
            this.optionsLoader.P_BaseColor = System.Drawing.Color.DarkGray;
            this.optionsLoader.Size = new System.Drawing.Size(80, 80);
            this.optionsLoader.TabIndex = 1;
            this.optionsLoader.Text = "progressIndicator1";
            // 
            // tabScopes
            // 
            this.tabScopes.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.tabScopes.ActiveFontColor = System.Drawing.Color.White;
            this.tabScopes.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.tabScopes.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabScopes.Controls.Add(this.tbtnGeneral);
            this.tabScopes.Controls.Add(this.tbtnCompany);
            this.tabScopes.Controls.Add(this.tbtnGovernment);
            this.tabScopes.Controls.Add(this.tbtnFleet);
            this.tabScopes.DeactiveFontColor = System.Drawing.Color.White;
            this.tabScopes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabScopes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabScopes.ItemSize = new System.Drawing.Size(120, 40);
            this.tabScopes.Location = new System.Drawing.Point(0, 0);
            this.tabScopes.Name = "tabScopes";
            this.tabScopes.SelectedIndex = 0;
            this.tabScopes.Size = new System.Drawing.Size(651, 375);
            this.tabScopes.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabScopes.TabIndex = 0;
            // 
            // tbtnGeneral
            // 
            this.tbtnGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tbtnGeneral.Controls.Add(this.tabGeneral);
            this.tbtnGeneral.Location = new System.Drawing.Point(4, 44);
            this.tbtnGeneral.Name = "tbtnGeneral";
            this.tbtnGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbtnGeneral.Size = new System.Drawing.Size(643, 327);
            this.tbtnGeneral.TabIndex = 3;
            this.tbtnGeneral.Text = "General Notifications";
            // 
            // tabGeneral
            // 
            this.tabGeneral.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabGeneral.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabGeneral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGeneral.ItemSize = new System.Drawing.Size(30, 115);
            this.tabGeneral.Location = new System.Drawing.Point(3, 3);
            this.tabGeneral.Multiline = true;
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.NormalTextColor = System.Drawing.Color.DimGray;
            this.tabGeneral.SelectedIndex = 0;
            this.tabGeneral.SelectedTabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabGeneral.SelectedTextColor = System.Drawing.Color.White;
            this.tabGeneral.ShowOuterBorders = false;
            this.tabGeneral.Size = new System.Drawing.Size(637, 321);
            this.tabGeneral.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabGeneral.SquareColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(87)))), ((int)(((byte)(100)))));
            this.tabGeneral.TabCursor = System.Windows.Forms.Cursors.Hand;
            this.tabGeneral.TabIndex = 0;
            // 
            // tbtnCompany
            // 
            this.tbtnCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tbtnCompany.Controls.Add(this.tabCompany);
            this.tbtnCompany.Location = new System.Drawing.Point(4, 44);
            this.tbtnCompany.Name = "tbtnCompany";
            this.tbtnCompany.Padding = new System.Windows.Forms.Padding(3);
            this.tbtnCompany.Size = new System.Drawing.Size(643, 327);
            this.tbtnCompany.TabIndex = 0;
            this.tbtnCompany.Text = "Company Notifications";
            // 
            // tabCompany
            // 
            this.tabCompany.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabCompany.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCompany.ItemSize = new System.Drawing.Size(30, 115);
            this.tabCompany.Location = new System.Drawing.Point(3, 3);
            this.tabCompany.Multiline = true;
            this.tabCompany.Name = "tabCompany";
            this.tabCompany.NormalTextColor = System.Drawing.Color.DimGray;
            this.tabCompany.SelectedIndex = 0;
            this.tabCompany.SelectedTabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabCompany.SelectedTextColor = System.Drawing.Color.White;
            this.tabCompany.ShowOuterBorders = false;
            this.tabCompany.Size = new System.Drawing.Size(637, 321);
            this.tabCompany.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabCompany.SquareColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(87)))), ((int)(((byte)(100)))));
            this.tabCompany.TabCursor = System.Windows.Forms.Cursors.Hand;
            this.tabCompany.TabIndex = 1;
            // 
            // tbtnGovernment
            // 
            this.tbtnGovernment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tbtnGovernment.Controls.Add(this.tabGovernment);
            this.tbtnGovernment.Location = new System.Drawing.Point(4, 44);
            this.tbtnGovernment.Name = "tbtnGovernment";
            this.tbtnGovernment.Padding = new System.Windows.Forms.Padding(3);
            this.tbtnGovernment.Size = new System.Drawing.Size(643, 327);
            this.tbtnGovernment.TabIndex = 1;
            this.tbtnGovernment.Text = "Government Notifications";
            // 
            // tabGovernment
            // 
            this.tabGovernment.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabGovernment.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabGovernment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabGovernment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGovernment.ItemSize = new System.Drawing.Size(30, 115);
            this.tabGovernment.Location = new System.Drawing.Point(3, 3);
            this.tabGovernment.Multiline = true;
            this.tabGovernment.Name = "tabGovernment";
            this.tabGovernment.NormalTextColor = System.Drawing.Color.DimGray;
            this.tabGovernment.SelectedIndex = 0;
            this.tabGovernment.SelectedTabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabGovernment.SelectedTextColor = System.Drawing.Color.White;
            this.tabGovernment.ShowOuterBorders = false;
            this.tabGovernment.Size = new System.Drawing.Size(637, 321);
            this.tabGovernment.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabGovernment.SquareColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(87)))), ((int)(((byte)(100)))));
            this.tabGovernment.TabCursor = System.Windows.Forms.Cursors.Hand;
            this.tabGovernment.TabIndex = 1;
            // 
            // tbtnFleet
            // 
            this.tbtnFleet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tbtnFleet.Controls.Add(this.tabFleetTracking);
            this.tbtnFleet.Location = new System.Drawing.Point(4, 44);
            this.tbtnFleet.Name = "tbtnFleet";
            this.tbtnFleet.Padding = new System.Windows.Forms.Padding(3);
            this.tbtnFleet.Size = new System.Drawing.Size(643, 327);
            this.tbtnFleet.TabIndex = 2;
            this.tbtnFleet.Text = "Fleet Tracking Notifications";
            // 
            // tabFleetTracking
            // 
            this.tabFleetTracking.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabFleetTracking.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabFleetTracking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabFleetTracking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFleetTracking.ItemSize = new System.Drawing.Size(30, 115);
            this.tabFleetTracking.Location = new System.Drawing.Point(3, 3);
            this.tabFleetTracking.Multiline = true;
            this.tabFleetTracking.Name = "tabFleetTracking";
            this.tabFleetTracking.NormalTextColor = System.Drawing.Color.DimGray;
            this.tabFleetTracking.SelectedIndex = 0;
            this.tabFleetTracking.SelectedTabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabFleetTracking.SelectedTextColor = System.Drawing.Color.White;
            this.tabFleetTracking.ShowOuterBorders = false;
            this.tabFleetTracking.Size = new System.Drawing.Size(637, 321);
            this.tabFleetTracking.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabFleetTracking.SquareColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(87)))), ((int)(((byte)(100)))));
            this.tabFleetTracking.TabCursor = System.Windows.Forms.Cursors.Hand;
            this.tabFleetTracking.TabIndex = 1;
            // 
            // tpgWizard
            // 
            this.tpgWizard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tpgWizard.Controls.Add(this.panel1);
            this.tpgWizard.Controls.Add(this.customNotificationsLoader);
            this.tpgWizard.Controls.Add(this.pnlCustomNotifications);
            this.tpgWizard.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpgWizard.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpgWizard.Location = new System.Drawing.Point(119, 4);
            this.tpgWizard.Name = "tpgWizard";
            this.tpgWizard.Size = new System.Drawing.Size(651, 375);
            this.tpgWizard.TabIndex = 3;
            this.tpgWizard.Text = "Custom Notifications";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cmdAddCustomNotification);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 30);
            this.panel1.TabIndex = 4;
            // 
            // cmdAddCustomNotification
            // 
            this.cmdAddCustomNotification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddCustomNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmdAddCustomNotification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdAddCustomNotification.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmdAddCustomNotification.ForeColor = System.Drawing.Color.White;
            this.cmdAddCustomNotification.HoverColor = System.Drawing.Color.DodgerBlue;
            this.cmdAddCustomNotification.Image = null;
            this.cmdAddCustomNotification.Location = new System.Drawing.Point(544, 0);
            this.cmdAddCustomNotification.Name = "cmdAddCustomNotification";
            this.cmdAddCustomNotification.Size = new System.Drawing.Size(107, 30);
            this.cmdAddCustomNotification.TabIndex = 0;
            this.cmdAddCustomNotification.Text = "Add Notification";
            this.cmdAddCustomNotification.Click += new System.EventHandler(this.cmdAddCustomNotification_Click);
            // 
            // customNotificationsLoader
            // 
            this.customNotificationsLoader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customNotificationsLoader.Location = new System.Drawing.Point(285, 147);
            this.customNotificationsLoader.MinimumSize = new System.Drawing.Size(50, 50);
            this.customNotificationsLoader.Name = "customNotificationsLoader";
            this.customNotificationsLoader.P_AnimationColor = System.Drawing.Color.DimGray;
            this.customNotificationsLoader.P_AnimationSpeed = 100;
            this.customNotificationsLoader.P_BaseColor = System.Drawing.Color.DarkGray;
            this.customNotificationsLoader.Size = new System.Drawing.Size(80, 80);
            this.customNotificationsLoader.TabIndex = 2;
            this.customNotificationsLoader.Text = "progressIndicator1";
            this.customNotificationsLoader.Visible = false;
            // 
            // pnlCustomNotifications
            // 
            this.pnlCustomNotifications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCustomNotifications.AutoScroll = true;
            this.pnlCustomNotifications.Controls.Add(this.lblNoCustomNotifications2);
            this.pnlCustomNotifications.Controls.Add(this.lblNoCustomNotifications);
            this.pnlCustomNotifications.Location = new System.Drawing.Point(0, 36);
            this.pnlCustomNotifications.Name = "pnlCustomNotifications";
            this.pnlCustomNotifications.Size = new System.Drawing.Size(651, 339);
            this.pnlCustomNotifications.TabIndex = 3;
            // 
            // lblNoCustomNotifications2
            // 
            this.lblNoCustomNotifications2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoCustomNotifications2.AutoSize = true;
            this.lblNoCustomNotifications2.BackColor = System.Drawing.Color.Transparent;
            this.lblNoCustomNotifications2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoCustomNotifications2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.lblNoCustomNotifications2.Location = new System.Drawing.Point(229, 158);
            this.lblNoCustomNotifications2.Name = "lblNoCustomNotifications2";
            this.lblNoCustomNotifications2.Size = new System.Drawing.Size(179, 13);
            this.lblNoCustomNotifications2.TabIndex = 1;
            this.lblNoCustomNotifications2.Text = "Click Add Notification to get started";
            this.lblNoCustomNotifications2.Visible = false;
            // 
            // lblNoCustomNotifications
            // 
            this.lblNoCustomNotifications.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoCustomNotifications.AutoSize = true;
            this.lblNoCustomNotifications.BackColor = System.Drawing.Color.Transparent;
            this.lblNoCustomNotifications.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.lblNoCustomNotifications.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblNoCustomNotifications.Location = new System.Drawing.Point(18, 95);
            this.lblNoCustomNotifications.Name = "lblNoCustomNotifications";
            this.lblNoCustomNotifications.Size = new System.Drawing.Size(615, 46);
            this.lblNoCustomNotifications.TabIndex = 0;
            this.lblNoCustomNotifications.Text = "You don\'t have any custom notifications";
            this.lblNoCustomNotifications.Visible = false;
            // 
            // frmNotificationCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 383);
            this.Controls.Add(this.tabTaskCenterNav);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmNotificationCenter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notifications and Tasks Center";
            this.Load += new System.EventHandler(this.frmNotificationCenter_Load);
            this.tabTaskCenterNav.ResumeLayout(false);
            this.tpgOptions.ResumeLayout(false);
            this.tabScopes.ResumeLayout(false);
            this.tbtnGeneral.ResumeLayout(false);
            this.tbtnCompany.ResumeLayout(false);
            this.tbtnGovernment.ResumeLayout(false);
            this.tbtnFleet.ResumeLayout(false);
            this.tpgWizard.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlCustomNotifications.ResumeLayout(false);
            this.pnlCustomNotifications.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.AirTabPage tabTaskCenterNav;
        private System.Windows.Forms.TabPage tpgNotifications;
        private System.Windows.Forms.TabPage tpgTasks;
        private System.Windows.Forms.TabPage tpgOptions;
        private System.Windows.Forms.TabPage tpgWizard;
        private ReaLTaiizor.Controls.ForeverTabPage tabScopes;
        private System.Windows.Forms.TabPage tbtnCompany;
        private System.Windows.Forms.TabPage tbtnGovernment;
        private System.Windows.Forms.TabPage tbtnFleet;
        private System.Windows.Forms.TabPage tbtnGeneral;
        private ReaLTaiizor.Controls.AirTabPage tabGeneral;
        private ReaLTaiizor.Controls.AirTabPage tabCompany;
        private ReaLTaiizor.Controls.AirTabPage tabGovernment;
        private ReaLTaiizor.Controls.AirTabPage tabFleetTracking;
        private ReaLTaiizor.Controls.ProgressIndicator optionsLoader;
        private ReaLTaiizor.Controls.ProgressIndicator customNotificationsLoader;
        private System.Windows.Forms.Panel pnlCustomNotifications;
        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.LostButton cmdAddCustomNotification;
        private ReaLTaiizor.Controls.SmallLabel lblNoCustomNotifications2;
        private ReaLTaiizor.Controls.BigLabel lblNoCustomNotifications;
    }
}