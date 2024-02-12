namespace MCSync
{
    partial class frmPaths
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaths));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMinecraftFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.fButtonExplorer = new MCSync.FancyButton();
            this.fButtonCancel = new MCSync.FancyButton();
            this.fButtonSave = new MCSync.FancyButton();
            this.cmdMinecraftFolder = new MCSync.FancyButton();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(202, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configure Minecraft Directory";
            // 
            // txtMinecraftFolder
            // 
            this.txtMinecraftFolder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMinecraftFolder.BackColor = System.Drawing.Color.Gray;
            this.txtMinecraftFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinecraftFolder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinecraftFolder.ForeColor = System.Drawing.Color.White;
            this.txtMinecraftFolder.Location = new System.Drawing.Point(102, 121);
            this.txtMinecraftFolder.Name = "txtMinecraftFolder";
            this.txtMinecraftFolder.ReadOnly = true;
            this.txtMinecraftFolder.Size = new System.Drawing.Size(313, 22);
            this.txtMinecraftFolder.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(102, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = ".minecraft Directory:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(147, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(304, 34);
            this.label9.TabIndex = 44;
            this.label9.Text = "Tell MCSync where you want the modpack\'s files to\r\nbe downloaded.";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackgroundImage = global::MCSync.Properties.Resources.tile_transparent1;
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(102, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 237);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Helpful Info";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(388, 216);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DimGray;
            this.tabPage1.BackgroundImage = global::MCSync.Properties.Resources.tile_transparent1;
            this.tabPage1.Controls.Add(this.fButtonExplorer);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(380, 190);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vanilla Launcher";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(6, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 52);
            this.label3.TabIndex = 0;
            this.label3.Text = "The .minecraft folder can be found in the following\r\ndirectory\r\n\r\n%appdata%/.mine" +
    "craft";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DimGray;
            this.tabPage2.BackgroundImage = global::MCSync.Properties.Resources.tile_transparent1;
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(380, 190);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MultiMC + Forks";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(6, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(347, 104);
            this.label4.TabIndex = 1;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // fButtonExplorer
            // 
            this.fButtonExplorer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fButtonExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fButtonExplorer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fButtonExplorer.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.fButtonExplorer.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.fButtonExplorer.BorderRadius = 0;
            this.fButtonExplorer.BorderRadius1 = 0;
            this.fButtonExplorer.BorderSize = 0;
            this.fButtonExplorer.BorderSize1 = 0;
            this.fButtonExplorer.FlatAppearance.BorderSize = 0;
            this.fButtonExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fButtonExplorer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fButtonExplorer.ForeColor = System.Drawing.Color.White;
            this.fButtonExplorer.Location = new System.Drawing.Point(250, 146);
            this.fButtonExplorer.Name = "fButtonExplorer";
            this.fButtonExplorer.Size = new System.Drawing.Size(111, 23);
            this.fButtonExplorer.TabIndex = 2;
            this.fButtonExplorer.Text = "Open Explorer";
            this.fButtonExplorer.TextColor = System.Drawing.Color.White;
            this.fButtonExplorer.UseVisualStyleBackColor = false;
            this.fButtonExplorer.Click += new System.EventHandler(this.fButtonExplorer_Click);
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
            this.fButtonCancel.Location = new System.Drawing.Point(221, 421);
            this.fButtonCancel.Name = "fButtonCancel";
            this.fButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.fButtonCancel.TabIndex = 18;
            this.fButtonCancel.Text = "Cancel";
            this.fButtonCancel.TextColor = System.Drawing.Color.White;
            this.fButtonCancel.UseVisualStyleBackColor = false;
            this.fButtonCancel.Click += new System.EventHandler(this.fButtonCancel_Click);
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
            this.fButtonSave.Location = new System.Drawing.Point(302, 421);
            this.fButtonSave.Name = "fButtonSave";
            this.fButtonSave.Size = new System.Drawing.Size(75, 23);
            this.fButtonSave.TabIndex = 17;
            this.fButtonSave.Text = "Save";
            this.fButtonSave.TextColor = System.Drawing.Color.White;
            this.fButtonSave.UseVisualStyleBackColor = false;
            this.fButtonSave.Click += new System.EventHandler(this.fButtonSave_Click);
            // 
            // cmdMinecraftFolder
            // 
            this.cmdMinecraftFolder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdMinecraftFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdMinecraftFolder.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdMinecraftFolder.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cmdMinecraftFolder.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.cmdMinecraftFolder.BorderRadius = 0;
            this.cmdMinecraftFolder.BorderRadius1 = 0;
            this.cmdMinecraftFolder.BorderSize = 0;
            this.cmdMinecraftFolder.BorderSize1 = 0;
            this.cmdMinecraftFolder.FlatAppearance.BorderSize = 0;
            this.cmdMinecraftFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMinecraftFolder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMinecraftFolder.ForeColor = System.Drawing.Color.White;
            this.cmdMinecraftFolder.Location = new System.Drawing.Point(421, 121);
            this.cmdMinecraftFolder.Name = "cmdMinecraftFolder";
            this.cmdMinecraftFolder.Size = new System.Drawing.Size(75, 23);
            this.cmdMinecraftFolder.TabIndex = 1;
            this.cmdMinecraftFolder.Text = "Browse";
            this.cmdMinecraftFolder.TextColor = System.Drawing.Color.White;
            this.cmdMinecraftFolder.UseVisualStyleBackColor = false;
            this.cmdMinecraftFolder.Click += new System.EventHandler(this.cmdMinecraftFolder_Click);
            // 
            // frmPaths
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::MCSync.Properties.Resources.tile_transparent1;
            this.ClientSize = new System.Drawing.Size(598, 471);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fButtonCancel);
            this.Controls.Add(this.fButtonSave);
            this.Controls.Add(this.cmdMinecraftFolder);
            this.Controls.Add(this.txtMinecraftFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPaths";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPaths";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPaths_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FancyButton cmdMinecraftFolder;
        private System.Windows.Forms.TextBox txtMinecraftFolder;
        private System.Windows.Forms.Label label2;
        private FancyButton fButtonCancel;
        private FancyButton fButtonSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private FancyButton fButtonExplorer;
    }
}