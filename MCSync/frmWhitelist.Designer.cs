
namespace MCSync
{
    partial class frmWhitelist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWhitelist));
            this.txtItems = new System.Windows.Forms.TextBox();
            this.lblIntro = new System.Windows.Forms.Label();
            this.fButtonSave = new MCSync.FancyButton();
            this.fButtonCancel = new MCSync.FancyButton();
            this.SuspendLayout();
            // 
            // txtItems
            // 
            this.txtItems.AcceptsReturn = true;
            this.txtItems.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItems.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItems.ForeColor = System.Drawing.Color.White;
            this.txtItems.Location = new System.Drawing.Point(12, 36);
            this.txtItems.Multiline = true;
            this.txtItems.Name = "txtItems";
            this.txtItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtItems.Size = new System.Drawing.Size(574, 280);
            this.txtItems.TabIndex = 0;
            // 
            // lblIntro
            // 
            this.lblIntro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIntro.AutoSize = true;
            this.lblIntro.BackColor = System.Drawing.Color.Transparent;
            this.lblIntro.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntro.ForeColor = System.Drawing.Color.White;
            this.lblIntro.Location = new System.Drawing.Point(12, 12);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(36, 13);
            this.lblIntro.TabIndex = 3;
            this.lblIntro.Text = "label1";
            // 
            // fButtonSave
            // 
            this.fButtonSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fButtonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fButtonSave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fButtonSave.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.fButtonSave.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.fButtonSave.BorderRadius = 0;
            this.fButtonSave.BorderRadius1 = 0;
            this.fButtonSave.BorderSize = 0;
            this.fButtonSave.BorderSize1 = 0;
            this.fButtonSave.FlatAppearance.BorderSize = 0;
            this.fButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fButtonSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fButtonSave.ForeColor = System.Drawing.Color.White;
            this.fButtonSave.Location = new System.Drawing.Point(511, 330);
            this.fButtonSave.Name = "fButtonSave";
            this.fButtonSave.Size = new System.Drawing.Size(75, 23);
            this.fButtonSave.TabIndex = 14;
            this.fButtonSave.Text = "Save";
            this.fButtonSave.TextColor = System.Drawing.Color.White;
            this.fButtonSave.UseVisualStyleBackColor = false;
            this.fButtonSave.Click += new System.EventHandler(this.fButtonSave_Click);
            // 
            // fButtonCancel
            // 
            this.fButtonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fButtonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fButtonCancel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fButtonCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.fButtonCancel.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.fButtonCancel.BorderRadius = 0;
            this.fButtonCancel.BorderRadius1 = 0;
            this.fButtonCancel.BorderSize = 0;
            this.fButtonCancel.BorderSize1 = 0;
            this.fButtonCancel.FlatAppearance.BorderSize = 0;
            this.fButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fButtonCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fButtonCancel.ForeColor = System.Drawing.Color.White;
            this.fButtonCancel.Location = new System.Drawing.Point(430, 330);
            this.fButtonCancel.Name = "fButtonCancel";
            this.fButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.fButtonCancel.TabIndex = 15;
            this.fButtonCancel.Text = "Cancel";
            this.fButtonCancel.TextColor = System.Drawing.Color.White;
            this.fButtonCancel.UseVisualStyleBackColor = false;
            this.fButtonCancel.Click += new System.EventHandler(this.fButtonCancel_Click);
            // 
            // frmWhitelist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::MCSync.Properties.Resources.tile_transparent1;
            this.ClientSize = new System.Drawing.Size(598, 365);
            this.Controls.Add(this.fButtonCancel);
            this.Controls.Add(this.fButtonSave);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.txtItems);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWhitelist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmWhitelist_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItems;
        public System.Windows.Forms.Label lblIntro;
        private FancyButton fButtonSave;
        private FancyButton fButtonCancel;
    }
}