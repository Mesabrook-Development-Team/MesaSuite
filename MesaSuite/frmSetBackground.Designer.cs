
namespace MesaSuite
{
    partial class frmSetBackground
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
            this.pboxCurrentWallpaper = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBZoom = new System.Windows.Forms.RadioButton();
            this.rBCenter = new System.Windows.Forms.RadioButton();
            this.rBStretch = new System.Windows.Forms.RadioButton();
            this.rBTile = new System.Windows.Forms.RadioButton();
            this.rBNone = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtWallpaperPath = new System.Windows.Forms.TextBox();
            this.ofdWallpaper = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCurrentWallpaper)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pboxCurrentWallpaper
            // 
            this.pboxCurrentWallpaper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboxCurrentWallpaper.Location = new System.Drawing.Point(12, 29);
            this.pboxCurrentWallpaper.Name = "pboxCurrentWallpaper";
            this.pboxCurrentWallpaper.Size = new System.Drawing.Size(266, 167);
            this.pboxCurrentWallpaper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxCurrentWallpaper.TabIndex = 0;
            this.pboxCurrentWallpaper.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Wallpaper";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(475, 202);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 202);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(92, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset to Default";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBZoom);
            this.groupBox1.Controls.Add(this.rBCenter);
            this.groupBox1.Controls.Add(this.rBStretch);
            this.groupBox1.Controls.Add(this.rBTile);
            this.groupBox1.Controls.Add(this.rBNone);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtWallpaperPath);
            this.groupBox1.Location = new System.Drawing.Point(284, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 167);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Wallpaper";
            // 
            // rBZoom
            // 
            this.rBZoom.AutoSize = true;
            this.rBZoom.Location = new System.Drawing.Point(106, 120);
            this.rBZoom.Name = "rBZoom";
            this.rBZoom.Size = new System.Drawing.Size(52, 17);
            this.rBZoom.TabIndex = 8;
            this.rBZoom.TabStop = true;
            this.rBZoom.Text = "Zoom";
            this.rBZoom.UseVisualStyleBackColor = true;
            this.rBZoom.CheckedChanged += new System.EventHandler(this.rBZoom_CheckedChanged);
            // 
            // rBCenter
            // 
            this.rBCenter.AutoSize = true;
            this.rBCenter.Location = new System.Drawing.Point(15, 120);
            this.rBCenter.Name = "rBCenter";
            this.rBCenter.Size = new System.Drawing.Size(56, 17);
            this.rBCenter.TabIndex = 7;
            this.rBCenter.TabStop = true;
            this.rBCenter.Text = "Center";
            this.rBCenter.UseVisualStyleBackColor = true;
            this.rBCenter.CheckedChanged += new System.EventHandler(this.rBCenter_CheckedChanged);
            // 
            // rBStretch
            // 
            this.rBStretch.AutoSize = true;
            this.rBStretch.Location = new System.Drawing.Point(197, 94);
            this.rBStretch.Name = "rBStretch";
            this.rBStretch.Size = new System.Drawing.Size(59, 17);
            this.rBStretch.TabIndex = 6;
            this.rBStretch.TabStop = true;
            this.rBStretch.Text = "Stretch";
            this.rBStretch.UseVisualStyleBackColor = true;
            this.rBStretch.CheckedChanged += new System.EventHandler(this.rBStretch_CheckedChanged);
            // 
            // rBTile
            // 
            this.rBTile.AutoSize = true;
            this.rBTile.Location = new System.Drawing.Point(106, 94);
            this.rBTile.Name = "rBTile";
            this.rBTile.Size = new System.Drawing.Size(42, 17);
            this.rBTile.TabIndex = 5;
            this.rBTile.TabStop = true;
            this.rBTile.Text = "Tile";
            this.rBTile.UseVisualStyleBackColor = true;
            this.rBTile.CheckedChanged += new System.EventHandler(this.rBTile_CheckedChanged);
            // 
            // rBNone
            // 
            this.rBNone.AutoSize = true;
            this.rBNone.Location = new System.Drawing.Point(15, 94);
            this.rBNone.Name = "rBNone";
            this.rBNone.Size = new System.Drawing.Size(51, 17);
            this.rBNone.TabIndex = 4;
            this.rBNone.TabStop = true;
            this.rBNone.Text = "None";
            this.rBNone.UseVisualStyleBackColor = true;
            this.rBNone.CheckedChanged += new System.EventHandler(this.rBNone_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Image Layout";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(205, 37);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(51, 20);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtWallpaperPath
            // 
            this.txtWallpaperPath.Location = new System.Drawing.Point(15, 37);
            this.txtWallpaperPath.Name = "txtWallpaperPath";
            this.txtWallpaperPath.ReadOnly = true;
            this.txtWallpaperPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWallpaperPath.Size = new System.Drawing.Size(184, 20);
            this.txtWallpaperPath.TabIndex = 0;
            // 
            // ofdWallpaper
            // 
            this.ofdWallpaper.FileName = "Choose a Wallpaper";
            this.ofdWallpaper.Filter = "Image Files|*.jpg;*.png;*.bmp";
            // 
            // frmSetBackground
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 237);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pboxCurrentWallpaper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetBackground";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Dashboard Wallpaper";
            this.Load += new System.EventHandler(this.frmSetBackground_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxCurrentWallpaper)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxCurrentWallpaper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtWallpaperPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rBStretch;
        private System.Windows.Forms.RadioButton rBTile;
        private System.Windows.Forms.RadioButton rBNone;
        private System.Windows.Forms.RadioButton rBZoom;
        private System.Windows.Forms.RadioButton rBCenter;
        private System.Windows.Forms.OpenFileDialog ofdWallpaper;
    }
}