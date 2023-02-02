
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
            this.txtResourcePacks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.txtItems.Location = new System.Drawing.Point(32, 143);
            this.txtItems.Multiline = true;
            this.txtItems.Name = "txtItems";
            this.txtItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtItems.Size = new System.Drawing.Size(297, 257);
            this.txtItems.TabIndex = 0;
            // 
            // lblIntro
            // 
            this.lblIntro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIntro.AutoSize = true;
            this.lblIntro.BackColor = System.Drawing.Color.Transparent;
            this.lblIntro.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntro.ForeColor = System.Drawing.Color.White;
            this.lblIntro.Location = new System.Drawing.Point(29, 124);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(87, 13);
            this.lblIntro.TabIndex = 3;
            this.lblIntro.Text = "Mods Whitelist:";
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
            this.fButtonSave.Location = new System.Drawing.Point(335, 429);
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
            this.fButtonCancel.Location = new System.Drawing.Point(254, 429);
            this.fButtonCancel.Name = "fButtonCancel";
            this.fButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.fButtonCancel.TabIndex = 15;
            this.fButtonCancel.Text = "Cancel";
            this.fButtonCancel.TextColor = System.Drawing.Color.White;
            this.fButtonCancel.UseVisualStyleBackColor = false;
            this.fButtonCancel.Click += new System.EventHandler(this.fButtonCancel_Click);
            // 
            // txtResourcePacks
            // 
            this.txtResourcePacks.AcceptsReturn = true;
            this.txtResourcePacks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtResourcePacks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtResourcePacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResourcePacks.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResourcePacks.ForeColor = System.Drawing.Color.White;
            this.txtResourcePacks.Location = new System.Drawing.Point(335, 143);
            this.txtResourcePacks.Multiline = true;
            this.txtResourcePacks.Name = "txtResourcePacks";
            this.txtResourcePacks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResourcePacks.Size = new System.Drawing.Size(297, 257);
            this.txtResourcePacks.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(332, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Resource Pack Whitelist:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(172, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(321, 34);
            this.label9.TabIndex = 47;
            this.label9.Text = "Specify which mods or resource packs you don\'t want\r\nMCSync to delete during Sync" +
    "ing.";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(265, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 17);
            this.label2.TabIndex = 46;
            this.label2.Text = "Configure Whitelists\r\n";
            // 
            // frmWhitelist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::MCSync.Properties.Resources.tile_transparent1;
            this.ClientSize = new System.Drawing.Size(665, 478);
            this.ControlBox = false;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResourcePacks);
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmWhitelist_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItems;
        public System.Windows.Forms.Label lblIntro;
        private FancyButton fButtonSave;
        private FancyButton fButtonCancel;
        private System.Windows.Forms.TextBox txtResourcePacks;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
    }
}