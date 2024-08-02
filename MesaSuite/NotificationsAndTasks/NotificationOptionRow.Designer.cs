namespace MesaSuite.NotificationsAndTasks
{
    partial class NotificationOptionRow
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
            this.tglEnabled = new ReaLTaiizor.Controls.ForeverToggle();
            this.lblText = new System.Windows.Forms.Label();
            this.cmdCustomize = new ReaLTaiizor.Controls.LostButton();
            this.separator1 = new ReaLTaiizor.Controls.Separator();
            this.lblEntityLabel = new ReaLTaiizor.Controls.ForeverLabel();
            this.pnlCollapseButton = new System.Windows.Forms.Panel();
            this.materialCheckBox1 = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.materialCheckBox2 = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.materialCheckBox3 = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.chkEntities = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // tglEnabled
            // 
            this.tglEnabled.BackColor = System.Drawing.Color.Transparent;
            this.tglEnabled.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.tglEnabled.BaseColorRed = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(85)))), ((int)(((byte)(96)))));
            this.tglEnabled.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(85)))), ((int)(((byte)(86)))));
            this.tglEnabled.Checked = false;
            this.tglEnabled.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tglEnabled.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tglEnabled.Location = new System.Drawing.Point(0, 0);
            this.tglEnabled.Name = "tglEnabled";
            this.tglEnabled.Options = ReaLTaiizor.Controls.ForeverToggle._Options.Style1;
            this.tglEnabled.Size = new System.Drawing.Size(76, 33);
            this.tglEnabled.TabIndex = 0;
            this.tglEnabled.Text = "foreverToggle1";
            this.tglEnabled.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.tglEnabled.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.tglEnabled.CheckedChanged += new ReaLTaiizor.Controls.ForeverToggle.CheckedChangedEventHandler(this.tglEnabled_CheckedChanged);
            this.tglEnabled.ClientSizeChanged += new System.EventHandler(this.foreverToggle1_ClientSizeChanged);
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Location = new System.Drawing.Point(85, 0);
            this.lblText.Margin = new System.Windows.Forms.Padding(3);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(404, 33);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "Notification Label Text";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdCustomize
            // 
            this.cmdCustomize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCustomize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmdCustomize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCustomize.Enabled = false;
            this.cmdCustomize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmdCustomize.ForeColor = System.Drawing.Color.White;
            this.cmdCustomize.HoverColor = System.Drawing.Color.DodgerBlue;
            this.cmdCustomize.Image = null;
            this.cmdCustomize.Location = new System.Drawing.Point(491, 6);
            this.cmdCustomize.Name = "cmdCustomize";
            this.cmdCustomize.Size = new System.Drawing.Size(80, 22);
            this.cmdCustomize.TabIndex = 3;
            this.cmdCustomize.Text = "Customize";
            this.cmdCustomize.Click += new System.EventHandler(this.cmdCustomize_Click);
            // 
            // separator1
            // 
            this.separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator1.Cursor = System.Windows.Forms.Cursors.No;
            this.separator1.LineColor = System.Drawing.Color.Gray;
            this.separator1.Location = new System.Drawing.Point(0, 38);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(551, 11);
            this.separator1.TabIndex = 4;
            this.separator1.Text = "separator1";
            this.separator1.Click += new System.EventHandler(this.separator1_Click);
            // 
            // lblEntityLabel
            // 
            this.lblEntityLabel.AutoSize = true;
            this.lblEntityLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblEntityLabel.Cursor = System.Windows.Forms.Cursors.No;
            this.lblEntityLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEntityLabel.ForeColor = System.Drawing.Color.LightGray;
            this.lblEntityLabel.Location = new System.Drawing.Point(0, 36);
            this.lblEntityLabel.Name = "lblEntityLabel";
            this.lblEntityLabel.Size = new System.Drawing.Size(113, 13);
            this.lblEntityLabel.TabIndex = 5;
            this.lblEntityLabel.Text = "Used in 0 Location(s)";
            this.lblEntityLabel.Click += new System.EventHandler(this.lblEntityLabel_Click);
            // 
            // pnlCollapseButton
            // 
            this.pnlCollapseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCollapseButton.BackgroundImage = global::MesaSuite.Properties.Resources.delete;
            this.pnlCollapseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlCollapseButton.Cursor = System.Windows.Forms.Cursors.No;
            this.pnlCollapseButton.Location = new System.Drawing.Point(552, 36);
            this.pnlCollapseButton.Name = "pnlCollapseButton";
            this.pnlCollapseButton.Size = new System.Drawing.Size(16, 16);
            this.pnlCollapseButton.TabIndex = 6;
            this.pnlCollapseButton.Click += new System.EventHandler(this.pnlCollapseButton_Click);
            // 
            // materialCheckBox1
            // 
            this.materialCheckBox1.Checked = true;
            this.materialCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.materialCheckBox1.Depth = 0;
            this.materialCheckBox1.Location = new System.Drawing.Point(0, 0);
            this.materialCheckBox1.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialCheckBox1.Name = "materialCheckBox1";
            this.materialCheckBox1.ReadOnly = false;
            this.materialCheckBox1.Ripple = true;
            this.materialCheckBox1.Size = new System.Drawing.Size(104, 37);
            this.materialCheckBox1.TabIndex = 0;
            this.materialCheckBox1.Text = "Test 1";
            this.materialCheckBox1.UseAccentColor = false;
            this.materialCheckBox1.UseVisualStyleBackColor = true;
            // 
            // materialCheckBox2
            // 
            this.materialCheckBox2.Depth = 0;
            this.materialCheckBox2.Location = new System.Drawing.Point(0, 0);
            this.materialCheckBox2.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialCheckBox2.Name = "materialCheckBox2";
            this.materialCheckBox2.ReadOnly = false;
            this.materialCheckBox2.Ripple = true;
            this.materialCheckBox2.Size = new System.Drawing.Size(104, 37);
            this.materialCheckBox2.TabIndex = 0;
            this.materialCheckBox2.Text = "Test 2";
            this.materialCheckBox2.UseAccentColor = false;
            this.materialCheckBox2.UseVisualStyleBackColor = true;
            // 
            // materialCheckBox3
            // 
            this.materialCheckBox3.Depth = 0;
            this.materialCheckBox3.Location = new System.Drawing.Point(0, 0);
            this.materialCheckBox3.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox3.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialCheckBox3.Name = "materialCheckBox3";
            this.materialCheckBox3.ReadOnly = false;
            this.materialCheckBox3.Ripple = true;
            this.materialCheckBox3.Size = new System.Drawing.Size(104, 37);
            this.materialCheckBox3.TabIndex = 0;
            this.materialCheckBox3.Text = "Test 3";
            this.materialCheckBox3.UseAccentColor = false;
            this.materialCheckBox3.UseVisualStyleBackColor = true;
            // 
            // chkEntities
            // 
            this.chkEntities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEntities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkEntities.CheckOnClick = true;
            this.chkEntities.ColumnWidth = 100;
            this.chkEntities.ForeColor = System.Drawing.Color.White;
            this.chkEntities.FormattingEnabled = true;
            this.chkEntities.Location = new System.Drawing.Point(3, 58);
            this.chkEntities.Name = "chkEntities";
            this.chkEntities.Size = new System.Drawing.Size(572, 4);
            this.chkEntities.TabIndex = 0;
            this.chkEntities.Visible = false;
            this.chkEntities.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkEntities_ItemCheck);
            // 
            // NotificationOptionRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.pnlCollapseButton);
            this.Controls.Add(this.chkEntities);
            this.Controls.Add(this.lblEntityLabel);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.cmdCustomize);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.tglEnabled);
            this.Name = "NotificationOptionRow";
            this.Size = new System.Drawing.Size(578, 57);
            this.Load += new System.EventHandler(this.NotificationOptionRow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.ForeverToggle tglEnabled;
        private System.Windows.Forms.Label lblText;
        private ReaLTaiizor.Controls.LostButton cmdCustomize;
        private ReaLTaiizor.Controls.Separator separator1;
        private ReaLTaiizor.Controls.ForeverLabel lblEntityLabel;
        private System.Windows.Forms.Panel pnlCollapseButton;
        private ReaLTaiizor.Controls.MaterialCheckBox materialCheckBox1;
        private ReaLTaiizor.Controls.MaterialCheckBox materialCheckBox2;
        private ReaLTaiizor.Controls.MaterialCheckBox materialCheckBox3;
        private System.Windows.Forms.CheckedListBox chkEntities;
    }
}
