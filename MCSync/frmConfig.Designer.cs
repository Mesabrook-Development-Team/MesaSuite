namespace MCSync
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModsDirectory = new System.Windows.Forms.TextBox();
            this.txtResourcePacksDirectory = new System.Windows.Forms.TextBox();
            this.cmdBrowseMods = new System.Windows.Forms.Button();
            this.cmdBrowseResourcePacks = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.rbServer = new System.Windows.Forms.RadioButton();
            this.cmdBrowseConfig = new System.Windows.Forms.Button();
            this.txtConfigDirectory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdModsWhitelist = new System.Windows.Forms.Button();
            this.cmdResourcePacksWhitelist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mods Directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Resource Packs Directory:";
            // 
            // txtModsDirectory
            // 
            this.txtModsDirectory.Location = new System.Drawing.Point(152, 19);
            this.txtModsDirectory.Name = "txtModsDirectory";
            this.txtModsDirectory.ReadOnly = true;
            this.txtModsDirectory.Size = new System.Drawing.Size(241, 20);
            this.txtModsDirectory.TabIndex = 0;
            // 
            // txtResourcePacksDirectory
            // 
            this.txtResourcePacksDirectory.Location = new System.Drawing.Point(152, 45);
            this.txtResourcePacksDirectory.Name = "txtResourcePacksDirectory";
            this.txtResourcePacksDirectory.ReadOnly = true;
            this.txtResourcePacksDirectory.Size = new System.Drawing.Size(241, 20);
            this.txtResourcePacksDirectory.TabIndex = 2;
            // 
            // cmdBrowseMods
            // 
            this.cmdBrowseMods.Location = new System.Drawing.Point(402, 17);
            this.cmdBrowseMods.Name = "cmdBrowseMods";
            this.cmdBrowseMods.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseMods.TabIndex = 1;
            this.cmdBrowseMods.Text = "Browse...";
            this.cmdBrowseMods.UseVisualStyleBackColor = true;
            this.cmdBrowseMods.Click += new System.EventHandler(this.cmdBrowseMods_Click);
            // 
            // cmdBrowseResourcePacks
            // 
            this.cmdBrowseResourcePacks.Location = new System.Drawing.Point(402, 43);
            this.cmdBrowseResourcePacks.Name = "cmdBrowseResourcePacks";
            this.cmdBrowseResourcePacks.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseResourcePacks.TabIndex = 3;
            this.cmdBrowseResourcePacks.Text = "Browse...";
            this.cmdBrowseResourcePacks.UseVisualStyleBackColor = true;
            this.cmdBrowseResourcePacks.Click += new System.EventHandler(this.cmdBrowseResourcePacks_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(402, 149);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(321, 149);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mode:";
            // 
            // rbClient
            // 
            this.rbClient.AutoSize = true;
            this.rbClient.Location = new System.Drawing.Point(152, 97);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(54, 17);
            this.rbClient.TabIndex = 4;
            this.rbClient.TabStop = true;
            this.rbClient.Text = "Player";
            this.rbClient.UseVisualStyleBackColor = true;
            // 
            // rbServer
            // 
            this.rbServer.AutoSize = true;
            this.rbServer.Location = new System.Drawing.Point(211, 97);
            this.rbServer.Name = "rbServer";
            this.rbServer.Size = new System.Drawing.Size(56, 17);
            this.rbServer.TabIndex = 5;
            this.rbServer.TabStop = true;
            this.rbServer.Text = "Server";
            this.rbServer.UseVisualStyleBackColor = true;
            // 
            // cmdBrowseConfig
            // 
            this.cmdBrowseConfig.Location = new System.Drawing.Point(402, 69);
            this.cmdBrowseConfig.Name = "cmdBrowseConfig";
            this.cmdBrowseConfig.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseConfig.TabIndex = 10;
            this.cmdBrowseConfig.Text = "Browse...";
            this.cmdBrowseConfig.UseVisualStyleBackColor = true;
            this.cmdBrowseConfig.Click += new System.EventHandler(this.cmdBrowseConfig_Click);
            // 
            // txtConfigDirectory
            // 
            this.txtConfigDirectory.Location = new System.Drawing.Point(152, 71);
            this.txtConfigDirectory.Name = "txtConfigDirectory";
            this.txtConfigDirectory.ReadOnly = true;
            this.txtConfigDirectory.Size = new System.Drawing.Size(241, 20);
            this.txtConfigDirectory.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Config Directory:";
            // 
            // cmdModsWhitelist
            // 
            this.cmdModsWhitelist.Location = new System.Drawing.Point(152, 120);
            this.cmdModsWhitelist.Name = "cmdModsWhitelist";
            this.cmdModsWhitelist.Size = new System.Drawing.Size(159, 23);
            this.cmdModsWhitelist.TabIndex = 11;
            this.cmdModsWhitelist.Text = "Mods Whitelist";
            this.cmdModsWhitelist.UseVisualStyleBackColor = true;
            this.cmdModsWhitelist.Click += new System.EventHandler(this.cmdModsWhitelist_Click);
            // 
            // cmdResourcePacksWhitelist
            // 
            this.cmdResourcePacksWhitelist.Location = new System.Drawing.Point(317, 120);
            this.cmdResourcePacksWhitelist.Name = "cmdResourcePacksWhitelist";
            this.cmdResourcePacksWhitelist.Size = new System.Drawing.Size(160, 23);
            this.cmdResourcePacksWhitelist.TabIndex = 11;
            this.cmdResourcePacksWhitelist.Text = "Resource Pack Whitelist";
            this.cmdResourcePacksWhitelist.UseVisualStyleBackColor = true;
            this.cmdResourcePacksWhitelist.Click += new System.EventHandler(this.cmdResourcePacksWhitelist_Click);
            // 
            // frmConfig
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(489, 183);
            this.Controls.Add(this.cmdResourcePacksWhitelist);
            this.Controls.Add(this.cmdModsWhitelist);
            this.Controls.Add(this.cmdBrowseConfig);
            this.Controls.Add(this.txtConfigDirectory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbServer);
            this.Controls.Add(this.rbClient);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdBrowseResourcePacks);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdBrowseMods);
            this.Controls.Add(this.txtResourcePacksDirectory);
            this.Controls.Add(this.txtModsDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration Editor";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModsDirectory;
        private System.Windows.Forms.TextBox txtResourcePacksDirectory;
        private System.Windows.Forms.Button cmdBrowseMods;
        private System.Windows.Forms.Button cmdBrowseResourcePacks;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbClient;
        private System.Windows.Forms.RadioButton rbServer;
        private System.Windows.Forms.Button cmdBrowseConfig;
        private System.Windows.Forms.TextBox txtConfigDirectory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdModsWhitelist;
        private System.Windows.Forms.Button cmdResourcePacksWhitelist;
    }
}