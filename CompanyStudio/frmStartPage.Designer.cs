namespace CompanyStudio
{
    partial class frmStartPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStartPage));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.airForm1 = new ReaLTaiizor.Forms.AirForm();
            this.airCheckBox1 = new ReaLTaiizor.Controls.AirCheckBox();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.smallLabel1 = new ReaLTaiizor.Controls.SmallLabel();
            this.headerLabel1 = new ReaLTaiizor.Controls.HeaderLabel();
            this.tbpToDoList = new ReaLTaiizor.Controls.AirTabPage();
            this.tabAll = new System.Windows.Forms.TabPage();
            this.lblAllCaughtUp = new ReaLTaiizor.Controls.MaterialLabel();
            this.loader = new CompanyStudio.Loader();
            this.airForm1.SuspendLayout();
            this.tbpToDoList.SuspendLayout();
            this.tabAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(200, 100);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            // 
            // airForm1
            // 
            this.airForm1.BackColor = System.Drawing.Color.White;
            this.airForm1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.airForm1.Controls.Add(this.airCheckBox1);
            this.airForm1.Controls.Add(this.bigLabel1);
            this.airForm1.Controls.Add(this.smallLabel1);
            this.airForm1.Controls.Add(this.headerLabel1);
            this.airForm1.Controls.Add(this.tbpToDoList);
            this.airForm1.Customization = "AAAA/1paWv9ycnL/";
            this.airForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.airForm1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.airForm1.Image = null;
            this.airForm1.Location = new System.Drawing.Point(0, 0);
            this.airForm1.MinimumSize = new System.Drawing.Size(112, 35);
            this.airForm1.Movable = true;
            this.airForm1.Name = "airForm1";
            this.airForm1.NoRounding = true;
            this.airForm1.Sizable = true;
            this.airForm1.Size = new System.Drawing.Size(800, 416);
            this.airForm1.SmartBounds = true;
            this.airForm1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.airForm1.TabIndex = 0;
            this.airForm1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.airForm1.Transparent = false;
            // 
            // airCheckBox1
            // 
            this.airCheckBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.airCheckBox1.Checked = true;
            this.airCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.airCheckBox1.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8=";
            this.airCheckBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.airCheckBox1.Image = null;
            this.airCheckBox1.Location = new System.Drawing.Point(3, 396);
            this.airCheckBox1.Name = "airCheckBox1";
            this.airCheckBox1.NoRounding = false;
            this.airCheckBox1.Size = new System.Drawing.Size(326, 17);
            this.airCheckBox1.TabIndex = 3;
            this.airCheckBox1.Text = "Always show this Start Page when Company Studio starts";
            this.airCheckBox1.Transparent = false;
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel1.Location = new System.Drawing.Point(3, -5);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(467, 46);
            this.bigLabel1.TabIndex = 2;
            this.bigLabel1.Text = "Welcome to Company Studio!";
            // 
            // smallLabel1
            // 
            this.smallLabel1.BackColor = System.Drawing.Color.Transparent;
            this.smallLabel1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.smallLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.smallLabel1.Location = new System.Drawing.Point(3, 41);
            this.smallLabel1.Name = "smallLabel1";
            this.smallLabel1.Size = new System.Drawing.Size(785, 29);
            this.smallLabel1.TabIndex = 1;
            this.smallLabel1.Text = resources.GetString("smallLabel1.Text");
            // 
            // headerLabel1
            // 
            this.headerLabel1.AutoSize = true;
            this.headerLabel1.BackColor = System.Drawing.Color.Transparent;
            this.headerLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.headerLabel1.ForeColor = System.Drawing.Color.DimGray;
            this.headerLabel1.Location = new System.Drawing.Point(3, 70);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Size = new System.Drawing.Size(133, 18);
            this.headerLabel1.TabIndex = 0;
            this.headerLabel1.Text = "Your To-Do List:";
            // 
            // tbpToDoList
            // 
            this.tbpToDoList.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tbpToDoList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbpToDoList.BaseColor = System.Drawing.Color.White;
            this.tbpToDoList.Controls.Add(this.tabAll);
            this.tbpToDoList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbpToDoList.ItemSize = new System.Drawing.Size(30, 115);
            this.tbpToDoList.Location = new System.Drawing.Point(3, 91);
            this.tbpToDoList.Multiline = true;
            this.tbpToDoList.Name = "tbpToDoList";
            this.tbpToDoList.NormalTextColor = System.Drawing.Color.DimGray;
            this.tbpToDoList.SelectedIndex = 0;
            this.tbpToDoList.SelectedTabBackColor = System.Drawing.Color.White;
            this.tbpToDoList.SelectedTextColor = System.Drawing.Color.Black;
            this.tbpToDoList.ShowOuterBorders = true;
            this.tbpToDoList.Size = new System.Drawing.Size(794, 299);
            this.tbpToDoList.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbpToDoList.SquareColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(87)))), ((int)(((byte)(100)))));
            this.tbpToDoList.TabCursor = System.Windows.Forms.Cursors.Hand;
            this.tbpToDoList.TabIndex = 0;
            // 
            // tabAll
            // 
            this.tabAll.BackColor = System.Drawing.Color.White;
            this.tabAll.Controls.Add(this.lblAllCaughtUp);
            this.tabAll.Controls.Add(this.loader);
            this.tabAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabAll.Location = new System.Drawing.Point(119, 4);
            this.tabAll.Name = "tabAll";
            this.tabAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabAll.Size = new System.Drawing.Size(671, 291);
            this.tabAll.TabIndex = 0;
            this.tabAll.Text = "All Businesses";
            // 
            // lblAllCaughtUp
            // 
            this.lblAllCaughtUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAllCaughtUp.AutoSize = true;
            this.lblAllCaughtUp.Depth = 0;
            this.lblAllCaughtUp.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAllCaughtUp.Image = global::CompanyStudio.Properties.Resources.emoticon_happy;
            this.lblAllCaughtUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAllCaughtUp.Location = new System.Drawing.Point(263, 136);
            this.lblAllCaughtUp.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.lblAllCaughtUp.Name = "lblAllCaughtUp";
            this.lblAllCaughtUp.Size = new System.Drawing.Size(145, 19);
            this.lblAllCaughtUp.TabIndex = 0;
            this.lblAllCaughtUp.Text = "You\'re all caught up!";
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(671, 291);
            this.loader.TabIndex = 1;
            // 
            // frmStartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 416);
            this.CloseButtonVisible = false;
            this.Controls.Add(this.airForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(112, 35);
            this.Name = "frmStartPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.frmStartPage_Load);
            this.airForm1.ResumeLayout(false);
            this.airForm1.PerformLayout();
            this.tbpToDoList.ResumeLayout(false);
            this.tabAll.ResumeLayout(false);
            this.tabAll.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private ReaLTaiizor.Forms.AirForm airForm1;
        private ReaLTaiizor.Controls.AirTabPage tbpToDoList;
        private System.Windows.Forms.TabPage tabAll;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel1;
        private ReaLTaiizor.Controls.SmallLabel smallLabel1;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.AirCheckBox airCheckBox1;
        private ReaLTaiizor.Controls.MaterialLabel lblAllCaughtUp;
        private Loader loader;
    }
}