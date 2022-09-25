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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.label1 = new System.Windows.Forms.Label();
            this.txtModsDirectory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.rbServer = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdBrowseOResources = new MCSync.FancyButton();
            this.cmdBrowseConfig = new MCSync.FancyButton();
            this.cmdBrowseResourcePacks = new MCSync.FancyButton();
            this.cmdBrowseMods = new MCSync.FancyButton();
            this.cmdMinecraftFolder = new MCSync.FancyButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMinecraftFolder = new System.Windows.Forms.TextBox();
            this.overrideFoldersCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOResourcesDirectory = new System.Windows.Forms.TextBox();
            this.txtResourcePacksDirectory = new System.Windows.Forms.TextBox();
            this.txtConfigDirectory = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdResourcePacksWhitelist = new MCSync.FancyButton();
            this.cmdModsWhitelist = new MCSync.FancyButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxBalloonTips = new System.Windows.Forms.CheckBox();
            this.fButtonSave = new MCSync.FancyButton();
            this.fButtonCancel = new MCSync.FancyButton();
            this.fadeTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = ".minecraft Directory:";
            // 
            // txtModsDirectory
            // 
            this.txtModsDirectory.BackColor = System.Drawing.Color.Gray;
            this.txtModsDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModsDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModsDirectory.ForeColor = System.Drawing.Color.White;
            this.txtModsDirectory.Location = new System.Drawing.Point(148, 105);
            this.txtModsDirectory.Name = "txtModsDirectory";
            this.txtModsDirectory.ReadOnly = true;
            this.txtModsDirectory.Size = new System.Drawing.Size(241, 22);
            this.txtModsDirectory.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(105, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mode:";
            // 
            // rbClient
            // 
            this.rbClient.AutoSize = true;
            this.rbClient.BackColor = System.Drawing.Color.Transparent;
            this.rbClient.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbClient.ForeColor = System.Drawing.Color.White;
            this.rbClient.Location = new System.Drawing.Point(148, 208);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(55, 17);
            this.rbClient.TabIndex = 8;
            this.rbClient.TabStop = true;
            this.rbClient.Text = "Player";
            this.rbClient.UseVisualStyleBackColor = false;
            // 
            // rbServer
            // 
            this.rbServer.AutoSize = true;
            this.rbServer.BackColor = System.Drawing.Color.Transparent;
            this.rbServer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbServer.ForeColor = System.Drawing.Color.White;
            this.rbServer.Location = new System.Drawing.Point(207, 208);
            this.rbServer.Name = "rbServer";
            this.rbServer.Size = new System.Drawing.Size(56, 17);
            this.rbServer.TabIndex = 9;
            this.rbServer.TabStop = true;
            this.rbServer.Text = "Server";
            this.rbServer.UseVisualStyleBackColor = false;
            this.rbServer.CheckedChanged += new System.EventHandler(this.rbServer_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmdBrowseOResources);
            this.groupBox1.Controls.Add(this.cmdBrowseConfig);
            this.groupBox1.Controls.Add(this.cmdBrowseResourcePacks);
            this.groupBox1.Controls.Add(this.cmdBrowseMods);
            this.groupBox1.Controls.Add(this.cmdMinecraftFolder);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtMinecraftFolder);
            this.groupBox1.Controls.Add(this.overrideFoldersCheckBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtModsDirectory);
            this.groupBox1.Controls.Add(this.txtOResourcesDirectory);
            this.groupBox1.Controls.Add(this.txtResourcePacksDirectory);
            this.groupBox1.Controls.Add(this.txtConfigDirectory);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rbServer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rbClient);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 251);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Folder Settings";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmdBrowseOResources
            // 
            this.cmdBrowseOResources.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdBrowseOResources.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdBrowseOResources.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cmdBrowseOResources.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.cmdBrowseOResources.BorderRadius = 0;
            this.cmdBrowseOResources.BorderRadius1 = 0;
            this.cmdBrowseOResources.BorderSize = 0;
            this.cmdBrowseOResources.BorderSize1 = 0;
            this.cmdBrowseOResources.FlatAppearance.BorderSize = 0;
            this.cmdBrowseOResources.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBrowseOResources.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrowseOResources.ForeColor = System.Drawing.Color.White;
            this.cmdBrowseOResources.Location = new System.Drawing.Point(396, 179);
            this.cmdBrowseOResources.Name = "cmdBrowseOResources";
            this.cmdBrowseOResources.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseOResources.TabIndex = 19;
            this.cmdBrowseOResources.Text = "Browse";
            this.cmdBrowseOResources.TextColor = System.Drawing.Color.White;
            this.cmdBrowseOResources.UseVisualStyleBackColor = false;
            this.cmdBrowseOResources.Click += new System.EventHandler(this.cmdBrowseOResources_Click);
            // 
            // cmdBrowseConfig
            // 
            this.cmdBrowseConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdBrowseConfig.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdBrowseConfig.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cmdBrowseConfig.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.cmdBrowseConfig.BorderRadius = 0;
            this.cmdBrowseConfig.BorderRadius1 = 0;
            this.cmdBrowseConfig.BorderSize = 0;
            this.cmdBrowseConfig.BorderSize1 = 0;
            this.cmdBrowseConfig.FlatAppearance.BorderSize = 0;
            this.cmdBrowseConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBrowseConfig.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrowseConfig.ForeColor = System.Drawing.Color.White;
            this.cmdBrowseConfig.Location = new System.Drawing.Point(396, 154);
            this.cmdBrowseConfig.Name = "cmdBrowseConfig";
            this.cmdBrowseConfig.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseConfig.TabIndex = 18;
            this.cmdBrowseConfig.Text = "Browse";
            this.cmdBrowseConfig.TextColor = System.Drawing.Color.White;
            this.cmdBrowseConfig.UseVisualStyleBackColor = false;
            this.cmdBrowseConfig.Click += new System.EventHandler(this.cmdBrowseConfig_Click);
            // 
            // cmdBrowseResourcePacks
            // 
            this.cmdBrowseResourcePacks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdBrowseResourcePacks.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdBrowseResourcePacks.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cmdBrowseResourcePacks.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.cmdBrowseResourcePacks.BorderRadius = 0;
            this.cmdBrowseResourcePacks.BorderRadius1 = 0;
            this.cmdBrowseResourcePacks.BorderSize = 0;
            this.cmdBrowseResourcePacks.BorderSize1 = 0;
            this.cmdBrowseResourcePacks.FlatAppearance.BorderSize = 0;
            this.cmdBrowseResourcePacks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBrowseResourcePacks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrowseResourcePacks.ForeColor = System.Drawing.Color.White;
            this.cmdBrowseResourcePacks.Location = new System.Drawing.Point(396, 128);
            this.cmdBrowseResourcePacks.Name = "cmdBrowseResourcePacks";
            this.cmdBrowseResourcePacks.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseResourcePacks.TabIndex = 17;
            this.cmdBrowseResourcePacks.Text = "Browse";
            this.cmdBrowseResourcePacks.TextColor = System.Drawing.Color.White;
            this.cmdBrowseResourcePacks.UseVisualStyleBackColor = false;
            this.cmdBrowseResourcePacks.Click += new System.EventHandler(this.cmdBrowseResourcePacks_Click);
            // 
            // cmdBrowseMods
            // 
            this.cmdBrowseMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdBrowseMods.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdBrowseMods.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cmdBrowseMods.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.cmdBrowseMods.BorderRadius = 0;
            this.cmdBrowseMods.BorderRadius1 = 0;
            this.cmdBrowseMods.BorderSize = 0;
            this.cmdBrowseMods.BorderSize1 = 0;
            this.cmdBrowseMods.FlatAppearance.BorderSize = 0;
            this.cmdBrowseMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBrowseMods.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrowseMods.ForeColor = System.Drawing.Color.White;
            this.cmdBrowseMods.Location = new System.Drawing.Point(396, 102);
            this.cmdBrowseMods.Name = "cmdBrowseMods";
            this.cmdBrowseMods.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseMods.TabIndex = 16;
            this.cmdBrowseMods.Text = "Browse";
            this.cmdBrowseMods.TextColor = System.Drawing.Color.White;
            this.cmdBrowseMods.UseVisualStyleBackColor = false;
            this.cmdBrowseMods.Click += new System.EventHandler(this.cmdBrowseMods_Click);
            // 
            // cmdMinecraftFolder
            // 
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
            this.cmdMinecraftFolder.Location = new System.Drawing.Point(396, 31);
            this.cmdMinecraftFolder.Name = "cmdMinecraftFolder";
            this.cmdMinecraftFolder.Size = new System.Drawing.Size(75, 23);
            this.cmdMinecraftFolder.TabIndex = 15;
            this.cmdMinecraftFolder.Text = "Browse";
            this.cmdMinecraftFolder.TextColor = System.Drawing.Color.White;
            this.cmdMinecraftFolder.UseVisualStyleBackColor = false;
            this.cmdMinecraftFolder.Click += new System.EventHandler(this.cmdMinecraftFolder_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(61, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Mods Directory:";
            // 
            // txtMinecraftFolder
            // 
            this.txtMinecraftFolder.BackColor = System.Drawing.Color.Gray;
            this.txtMinecraftFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinecraftFolder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinecraftFolder.ForeColor = System.Drawing.Color.White;
            this.txtMinecraftFolder.Location = new System.Drawing.Point(151, 34);
            this.txtMinecraftFolder.Name = "txtMinecraftFolder";
            this.txtMinecraftFolder.ReadOnly = true;
            this.txtMinecraftFolder.Size = new System.Drawing.Size(238, 22);
            this.txtMinecraftFolder.TabIndex = 12;
            this.txtMinecraftFolder.TextChanged += new System.EventHandler(this.txtMinecraftFolder_TextChanged);
            // 
            // overrideFoldersCheckBox
            // 
            this.overrideFoldersCheckBox.AutoSize = true;
            this.overrideFoldersCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.overrideFoldersCheckBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overrideFoldersCheckBox.ForeColor = System.Drawing.Color.White;
            this.overrideFoldersCheckBox.Location = new System.Drawing.Point(181, 70);
            this.overrideFoldersCheckBox.Name = "overrideFoldersCheckBox";
            this.overrideFoldersCheckBox.Size = new System.Drawing.Size(118, 17);
            this.overrideFoldersCheckBox.TabIndex = 10;
            this.overrideFoldersCheckBox.Text = "Use Custom Paths";
            this.overrideFoldersCheckBox.UseVisualStyleBackColor = false;
            this.overrideFoldersCheckBox.CheckedChanged += new System.EventHandler(this.overrideFoldersCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Resource Packs Directory:";
            // 
            // txtOResourcesDirectory
            // 
            this.txtOResourcesDirectory.BackColor = System.Drawing.Color.Gray;
            this.txtOResourcesDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOResourcesDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOResourcesDirectory.ForeColor = System.Drawing.Color.White;
            this.txtOResourcesDirectory.Location = new System.Drawing.Point(148, 182);
            this.txtOResourcesDirectory.Name = "txtOResourcesDirectory";
            this.txtOResourcesDirectory.ReadOnly = true;
            this.txtOResourcesDirectory.Size = new System.Drawing.Size(241, 22);
            this.txtOResourcesDirectory.TabIndex = 6;
            // 
            // txtResourcePacksDirectory
            // 
            this.txtResourcePacksDirectory.BackColor = System.Drawing.Color.Gray;
            this.txtResourcePacksDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResourcePacksDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResourcePacksDirectory.ForeColor = System.Drawing.Color.White;
            this.txtResourcePacksDirectory.Location = new System.Drawing.Point(148, 131);
            this.txtResourcePacksDirectory.Name = "txtResourcePacksDirectory";
            this.txtResourcePacksDirectory.ReadOnly = true;
            this.txtResourcePacksDirectory.Size = new System.Drawing.Size(241, 22);
            this.txtResourcePacksDirectory.TabIndex = 2;
            // 
            // txtConfigDirectory
            // 
            this.txtConfigDirectory.BackColor = System.Drawing.Color.Gray;
            this.txtConfigDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfigDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfigDirectory.ForeColor = System.Drawing.Color.White;
            this.txtConfigDirectory.Location = new System.Drawing.Point(148, 157);
            this.txtConfigDirectory.Name = "txtConfigDirectory";
            this.txtConfigDirectory.ReadOnly = true;
            this.txtConfigDirectory.Size = new System.Drawing.Size(241, 22);
            this.txtConfigDirectory.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(28, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "OResources Directory:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(56, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Config Directory:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cmdResourcePacksWhitelist);
            this.groupBox2.Controls.Add(this.cmdModsWhitelist);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 151);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manage Whitelists";
            // 
            // cmdResourcePacksWhitelist
            // 
            this.cmdResourcePacksWhitelist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdResourcePacksWhitelist.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdResourcePacksWhitelist.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cmdResourcePacksWhitelist.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.cmdResourcePacksWhitelist.BorderRadius = 0;
            this.cmdResourcePacksWhitelist.BorderRadius1 = 0;
            this.cmdResourcePacksWhitelist.BorderSize = 0;
            this.cmdResourcePacksWhitelist.BorderSize1 = 0;
            this.cmdResourcePacksWhitelist.FlatAppearance.BorderSize = 0;
            this.cmdResourcePacksWhitelist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdResourcePacksWhitelist.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdResourcePacksWhitelist.ForeColor = System.Drawing.Color.White;
            this.cmdResourcePacksWhitelist.Location = new System.Drawing.Point(243, 91);
            this.cmdResourcePacksWhitelist.Name = "cmdResourcePacksWhitelist";
            this.cmdResourcePacksWhitelist.Size = new System.Drawing.Size(115, 23);
            this.cmdResourcePacksWhitelist.TabIndex = 21;
            this.cmdResourcePacksWhitelist.Text = "Resource Packs";
            this.cmdResourcePacksWhitelist.TextColor = System.Drawing.Color.White;
            this.cmdResourcePacksWhitelist.UseVisualStyleBackColor = false;
            this.cmdResourcePacksWhitelist.Click += new System.EventHandler(this.cmdResourcePacksWhitelist_Click);
            // 
            // cmdModsWhitelist
            // 
            this.cmdModsWhitelist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdModsWhitelist.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdModsWhitelist.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cmdModsWhitelist.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.cmdModsWhitelist.BorderRadius = 0;
            this.cmdModsWhitelist.BorderRadius1 = 0;
            this.cmdModsWhitelist.BorderSize = 0;
            this.cmdModsWhitelist.BorderSize1 = 0;
            this.cmdModsWhitelist.FlatAppearance.BorderSize = 0;
            this.cmdModsWhitelist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdModsWhitelist.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdModsWhitelist.ForeColor = System.Drawing.Color.White;
            this.cmdModsWhitelist.Location = new System.Drawing.Point(122, 91);
            this.cmdModsWhitelist.Name = "cmdModsWhitelist";
            this.cmdModsWhitelist.Size = new System.Drawing.Size(115, 23);
            this.cmdModsWhitelist.TabIndex = 20;
            this.cmdModsWhitelist.Text = "Mods";
            this.cmdModsWhitelist.TextColor = System.Drawing.Color.White;
            this.cmdModsWhitelist.UseVisualStyleBackColor = false;
            this.cmdModsWhitelist.Click += new System.EventHandler(this.cmdModsWhitelist_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(109, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(264, 39);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mods and Resource Packs not whitelisted will be\r\ndeleted when you update. You can" +
    " white list them\r\nbelow.\r\n";
            // 
            // cboxBalloonTips
            // 
            this.cboxBalloonTips.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxBalloonTips.AutoSize = true;
            this.cboxBalloonTips.BackColor = System.Drawing.Color.Transparent;
            this.cboxBalloonTips.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxBalloonTips.ForeColor = System.Drawing.Color.White;
            this.cboxBalloonTips.Location = new System.Drawing.Point(12, 432);
            this.cboxBalloonTips.Name = "cboxBalloonTips";
            this.cboxBalloonTips.Size = new System.Drawing.Size(188, 17);
            this.cboxBalloonTips.TabIndex = 4;
            this.cboxBalloonTips.Text = "Show Balloon Tips during Sync.";
            this.cboxBalloonTips.UseVisualStyleBackColor = false;
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
            this.fButtonSave.Location = new System.Drawing.Point(420, 428);
            this.fButtonSave.Name = "fButtonSave";
            this.fButtonSave.Size = new System.Drawing.Size(75, 23);
            this.fButtonSave.TabIndex = 13;
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
            this.fButtonCancel.Location = new System.Drawing.Point(339, 428);
            this.fButtonCancel.Name = "fButtonCancel";
            this.fButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.fButtonCancel.TabIndex = 14;
            this.fButtonCancel.Text = "Cancel";
            this.fButtonCancel.TextColor = System.Drawing.Color.White;
            this.fButtonCancel.UseVisualStyleBackColor = false;
            this.fButtonCancel.Click += new System.EventHandler(this.fButtonCancel_Click);
            // 
            // fadeTimer
            // 
            this.fadeTimer.Interval = 30;
            this.fadeTimer.Tick += new System.EventHandler(this.fadeTimer_Tick);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::MCSync.Properties.Resources.tile_transparent1;
            this.ClientSize = new System.Drawing.Size(507, 461);
            this.ControlBox = false;
            this.Controls.Add(this.fButtonCancel);
            this.Controls.Add(this.fButtonSave);
            this.Controls.Add(this.cboxBalloonTips);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MCSync Settings";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfig_FormClosing);
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModsDirectory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbClient;
        private System.Windows.Forms.RadioButton rbServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOResourcesDirectory;
        private System.Windows.Forms.TextBox txtResourcePacksDirectory;
        private System.Windows.Forms.TextBox txtConfigDirectory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox overrideFoldersCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMinecraftFolder;
        private System.Windows.Forms.CheckBox cboxBalloonTips;
        private FancyButton fButtonSave;
        private FancyButton fButtonCancel;
        private FancyButton cmdBrowseOResources;
        private FancyButton cmdBrowseConfig;
        private FancyButton cmdBrowseResourcePacks;
        private FancyButton cmdBrowseMods;
        private FancyButton cmdMinecraftFolder;
        private FancyButton cmdResourcePacksWhitelist;
        private FancyButton cmdModsWhitelist;
        private System.Windows.Forms.Timer fadeTimer;
    }
}