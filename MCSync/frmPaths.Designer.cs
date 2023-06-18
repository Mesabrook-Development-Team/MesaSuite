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
            this.label1 = new System.Windows.Forms.Label();
            this.cmdBrowseOResources = new MCSync.FancyButton();
            this.cmdBrowseConfig = new MCSync.FancyButton();
            this.cmdBrowseResourcePacks = new MCSync.FancyButton();
            this.cmdBrowseMods = new MCSync.FancyButton();
            this.cmdMinecraftFolder = new MCSync.FancyButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMinecraftFolder = new System.Windows.Forms.TextBox();
            this.overrideFoldersCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModsDirectory = new System.Windows.Forms.TextBox();
            this.txtOResourcesDirectory = new System.Windows.Forms.TextBox();
            this.txtResourcePacksDirectory = new System.Windows.Forms.TextBox();
            this.txtConfigDirectory = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbServer = new System.Windows.Forms.RadioButton();
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdBrowseAnimation = new MCSync.FancyButton();
            this.txtAnimationDirectory = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.fButtonCancel = new MCSync.FancyButton();
            this.fButtonSave = new MCSync.FancyButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSignPacksDirectory = new System.Windows.Forms.TextBox();
            this.cmdBrowseSignPacks = new MCSync.FancyButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(198, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configure Minecraft Directories";
            // 
            // cmdBrowseOResources
            // 
            this.cmdBrowseOResources.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.cmdBrowseOResources.Location = new System.Drawing.Point(454, 273);
            this.cmdBrowseOResources.Name = "cmdBrowseOResources";
            this.cmdBrowseOResources.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseOResources.TabIndex = 10;
            this.cmdBrowseOResources.Text = "Browse";
            this.cmdBrowseOResources.TextColor = System.Drawing.Color.White;
            this.cmdBrowseOResources.UseVisualStyleBackColor = false;
            this.cmdBrowseOResources.Click += new System.EventHandler(this.cmdBrowseOResources_Click);
            // 
            // cmdBrowseConfig
            // 
            this.cmdBrowseConfig.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.cmdBrowseConfig.Location = new System.Drawing.Point(454, 247);
            this.cmdBrowseConfig.Name = "cmdBrowseConfig";
            this.cmdBrowseConfig.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseConfig.TabIndex = 8;
            this.cmdBrowseConfig.Text = "Browse";
            this.cmdBrowseConfig.TextColor = System.Drawing.Color.White;
            this.cmdBrowseConfig.UseVisualStyleBackColor = false;
            this.cmdBrowseConfig.Click += new System.EventHandler(this.cmdBrowseConfig_Click);
            // 
            // cmdBrowseResourcePacks
            // 
            this.cmdBrowseResourcePacks.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.cmdBrowseResourcePacks.Location = new System.Drawing.Point(454, 220);
            this.cmdBrowseResourcePacks.Name = "cmdBrowseResourcePacks";
            this.cmdBrowseResourcePacks.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseResourcePacks.TabIndex = 6;
            this.cmdBrowseResourcePacks.Text = "Browse";
            this.cmdBrowseResourcePacks.TextColor = System.Drawing.Color.White;
            this.cmdBrowseResourcePacks.UseVisualStyleBackColor = false;
            this.cmdBrowseResourcePacks.Click += new System.EventHandler(this.cmdBrowseResourcePacks_Click);
            // 
            // cmdBrowseMods
            // 
            this.cmdBrowseMods.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.cmdBrowseMods.Location = new System.Drawing.Point(454, 194);
            this.cmdBrowseMods.Name = "cmdBrowseMods";
            this.cmdBrowseMods.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseMods.TabIndex = 4;
            this.cmdBrowseMods.Text = "Browse";
            this.cmdBrowseMods.TextColor = System.Drawing.Color.White;
            this.cmdBrowseMods.UseVisualStyleBackColor = false;
            this.cmdBrowseMods.Click += new System.EventHandler(this.cmdBrowseMods_Click);
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
            this.cmdMinecraftFolder.Location = new System.Drawing.Point(454, 123);
            this.cmdMinecraftFolder.Name = "cmdMinecraftFolder";
            this.cmdMinecraftFolder.Size = new System.Drawing.Size(75, 23);
            this.cmdMinecraftFolder.TabIndex = 1;
            this.cmdMinecraftFolder.Text = "Browse";
            this.cmdMinecraftFolder.TextColor = System.Drawing.Color.White;
            this.cmdMinecraftFolder.UseVisualStyleBackColor = false;
            this.cmdMinecraftFolder.Click += new System.EventHandler(this.cmdMinecraftFolder_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(119, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Mods Directory:";
            // 
            // txtMinecraftFolder
            // 
            this.txtMinecraftFolder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMinecraftFolder.BackColor = System.Drawing.Color.Gray;
            this.txtMinecraftFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinecraftFolder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinecraftFolder.ForeColor = System.Drawing.Color.White;
            this.txtMinecraftFolder.Location = new System.Drawing.Point(209, 124);
            this.txtMinecraftFolder.Name = "txtMinecraftFolder";
            this.txtMinecraftFolder.ReadOnly = true;
            this.txtMinecraftFolder.Size = new System.Drawing.Size(238, 22);
            this.txtMinecraftFolder.TabIndex = 0;
            this.txtMinecraftFolder.TextChanged += new System.EventHandler(this.txtMinecraftFolder_TextChanged);
            // 
            // overrideFoldersCheckBox
            // 
            this.overrideFoldersCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.overrideFoldersCheckBox.AutoSize = true;
            this.overrideFoldersCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.overrideFoldersCheckBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overrideFoldersCheckBox.ForeColor = System.Drawing.Color.White;
            this.overrideFoldersCheckBox.Location = new System.Drawing.Point(239, 160);
            this.overrideFoldersCheckBox.Name = "overrideFoldersCheckBox";
            this.overrideFoldersCheckBox.Size = new System.Drawing.Size(118, 17);
            this.overrideFoldersCheckBox.TabIndex = 2;
            this.overrideFoldersCheckBox.Text = "Use Custom Paths";
            this.overrideFoldersCheckBox.UseVisualStyleBackColor = false;
            this.overrideFoldersCheckBox.CheckedChanged += new System.EventHandler(this.overrideFoldersCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(99, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = ".minecraft Directory:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(69, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Resource Packs Directory:";
            // 
            // txtModsDirectory
            // 
            this.txtModsDirectory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtModsDirectory.BackColor = System.Drawing.Color.Gray;
            this.txtModsDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModsDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModsDirectory.ForeColor = System.Drawing.Color.White;
            this.txtModsDirectory.Location = new System.Drawing.Point(206, 195);
            this.txtModsDirectory.Name = "txtModsDirectory";
            this.txtModsDirectory.ReadOnly = true;
            this.txtModsDirectory.Size = new System.Drawing.Size(241, 22);
            this.txtModsDirectory.TabIndex = 3;
            // 
            // txtOResourcesDirectory
            // 
            this.txtOResourcesDirectory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtOResourcesDirectory.BackColor = System.Drawing.Color.Gray;
            this.txtOResourcesDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOResourcesDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOResourcesDirectory.ForeColor = System.Drawing.Color.White;
            this.txtOResourcesDirectory.Location = new System.Drawing.Point(206, 274);
            this.txtOResourcesDirectory.Name = "txtOResourcesDirectory";
            this.txtOResourcesDirectory.ReadOnly = true;
            this.txtOResourcesDirectory.Size = new System.Drawing.Size(241, 22);
            this.txtOResourcesDirectory.TabIndex = 9;
            // 
            // txtResourcePacksDirectory
            // 
            this.txtResourcePacksDirectory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtResourcePacksDirectory.BackColor = System.Drawing.Color.Gray;
            this.txtResourcePacksDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResourcePacksDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResourcePacksDirectory.ForeColor = System.Drawing.Color.White;
            this.txtResourcePacksDirectory.Location = new System.Drawing.Point(206, 221);
            this.txtResourcePacksDirectory.Name = "txtResourcePacksDirectory";
            this.txtResourcePacksDirectory.ReadOnly = true;
            this.txtResourcePacksDirectory.Size = new System.Drawing.Size(241, 22);
            this.txtResourcePacksDirectory.TabIndex = 5;
            // 
            // txtConfigDirectory
            // 
            this.txtConfigDirectory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtConfigDirectory.BackColor = System.Drawing.Color.Gray;
            this.txtConfigDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfigDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfigDirectory.ForeColor = System.Drawing.Color.White;
            this.txtConfigDirectory.Location = new System.Drawing.Point(206, 248);
            this.txtConfigDirectory.Name = "txtConfigDirectory";
            this.txtConfigDirectory.ReadOnly = true;
            this.txtConfigDirectory.Size = new System.Drawing.Size(241, 22);
            this.txtConfigDirectory.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(86, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "OResources Directory:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(114, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Config Directory:";
            // 
            // rbServer
            // 
            this.rbServer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbServer.AutoSize = true;
            this.rbServer.BackColor = System.Drawing.Color.Transparent;
            this.rbServer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbServer.ForeColor = System.Drawing.Color.White;
            this.rbServer.Location = new System.Drawing.Point(265, 357);
            this.rbServer.Name = "rbServer";
            this.rbServer.Size = new System.Drawing.Size(56, 17);
            this.rbServer.TabIndex = 16;
            this.rbServer.TabStop = true;
            this.rbServer.Text = "Server";
            this.rbServer.UseVisualStyleBackColor = false;
            // 
            // rbClient
            // 
            this.rbClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbClient.AutoSize = true;
            this.rbClient.BackColor = System.Drawing.Color.Transparent;
            this.rbClient.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbClient.ForeColor = System.Drawing.Color.White;
            this.rbClient.Location = new System.Drawing.Point(206, 357);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(55, 17);
            this.rbClient.TabIndex = 15;
            this.rbClient.TabStop = true;
            this.rbClient.Text = "Player";
            this.rbClient.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(166, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Mode:";
            // 
            // cmdBrowseAnimation
            // 
            this.cmdBrowseAnimation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdBrowseAnimation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdBrowseAnimation.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdBrowseAnimation.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cmdBrowseAnimation.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.cmdBrowseAnimation.BorderRadius = 0;
            this.cmdBrowseAnimation.BorderRadius1 = 0;
            this.cmdBrowseAnimation.BorderSize = 0;
            this.cmdBrowseAnimation.BorderSize1 = 0;
            this.cmdBrowseAnimation.FlatAppearance.BorderSize = 0;
            this.cmdBrowseAnimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBrowseAnimation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrowseAnimation.ForeColor = System.Drawing.Color.White;
            this.cmdBrowseAnimation.Location = new System.Drawing.Point(454, 299);
            this.cmdBrowseAnimation.Name = "cmdBrowseAnimation";
            this.cmdBrowseAnimation.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseAnimation.TabIndex = 12;
            this.cmdBrowseAnimation.Text = "Browse";
            this.cmdBrowseAnimation.TextColor = System.Drawing.Color.White;
            this.cmdBrowseAnimation.UseVisualStyleBackColor = false;
            this.cmdBrowseAnimation.Click += new System.EventHandler(this.cmdBrowseAnimation_Click);
            // 
            // txtAnimationDirectory
            // 
            this.txtAnimationDirectory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAnimationDirectory.BackColor = System.Drawing.Color.Gray;
            this.txtAnimationDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnimationDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnimationDirectory.ForeColor = System.Drawing.Color.White;
            this.txtAnimationDirectory.Location = new System.Drawing.Point(206, 300);
            this.txtAnimationDirectory.Name = "txtAnimationDirectory";
            this.txtAnimationDirectory.ReadOnly = true;
            this.txtAnimationDirectory.Size = new System.Drawing.Size(241, 22);
            this.txtAnimationDirectory.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(26, 304);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Custom Loading Screen Directory:";
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
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(24, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Traffic Control Signpack Directory:";
            // 
            // txtSignPacksDirectory
            // 
            this.txtSignPacksDirectory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSignPacksDirectory.BackColor = System.Drawing.Color.Gray;
            this.txtSignPacksDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSignPacksDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSignPacksDirectory.ForeColor = System.Drawing.Color.White;
            this.txtSignPacksDirectory.Location = new System.Drawing.Point(206, 326);
            this.txtSignPacksDirectory.Name = "txtSignPacksDirectory";
            this.txtSignPacksDirectory.ReadOnly = true;
            this.txtSignPacksDirectory.Size = new System.Drawing.Size(241, 22);
            this.txtSignPacksDirectory.TabIndex = 13;
            // 
            // cmdBrowseSignPacks
            // 
            this.cmdBrowseSignPacks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdBrowseSignPacks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdBrowseSignPacks.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdBrowseSignPacks.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cmdBrowseSignPacks.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.cmdBrowseSignPacks.BorderRadius = 0;
            this.cmdBrowseSignPacks.BorderRadius1 = 0;
            this.cmdBrowseSignPacks.BorderSize = 0;
            this.cmdBrowseSignPacks.BorderSize1 = 0;
            this.cmdBrowseSignPacks.FlatAppearance.BorderSize = 0;
            this.cmdBrowseSignPacks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBrowseSignPacks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrowseSignPacks.ForeColor = System.Drawing.Color.White;
            this.cmdBrowseSignPacks.Location = new System.Drawing.Point(454, 326);
            this.cmdBrowseSignPacks.Name = "cmdBrowseSignPacks";
            this.cmdBrowseSignPacks.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseSignPacks.TabIndex = 14;
            this.cmdBrowseSignPacks.Text = "Browse";
            this.cmdBrowseSignPacks.TextColor = System.Drawing.Color.White;
            this.cmdBrowseSignPacks.UseVisualStyleBackColor = false;
            this.cmdBrowseSignPacks.Click += new System.EventHandler(this.cmdBrowseSignPacks_Click);
            // 
            // frmPaths
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::MCSync.Properties.Resources.tile_transparent1;
            this.ClientSize = new System.Drawing.Size(598, 471);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fButtonCancel);
            this.Controls.Add(this.fButtonSave);
            this.Controls.Add(this.cmdBrowseSignPacks);
            this.Controls.Add(this.txtSignPacksDirectory);
            this.Controls.Add(this.cmdBrowseAnimation);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtAnimationDirectory);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdBrowseOResources);
            this.Controls.Add(this.cmdBrowseConfig);
            this.Controls.Add(this.cmdBrowseResourcePacks);
            this.Controls.Add(this.cmdBrowseMods);
            this.Controls.Add(this.cmdMinecraftFolder);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMinecraftFolder);
            this.Controls.Add(this.overrideFoldersCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtModsDirectory);
            this.Controls.Add(this.txtOResourcesDirectory);
            this.Controls.Add(this.txtResourcePacksDirectory);
            this.Controls.Add(this.txtConfigDirectory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbServer);
            this.Controls.Add(this.rbClient);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FancyButton cmdBrowseOResources;
        private FancyButton cmdBrowseConfig;
        private FancyButton cmdBrowseResourcePacks;
        private FancyButton cmdBrowseMods;
        private FancyButton cmdMinecraftFolder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMinecraftFolder;
        private System.Windows.Forms.CheckBox overrideFoldersCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtModsDirectory;
        private System.Windows.Forms.TextBox txtOResourcesDirectory;
        private System.Windows.Forms.TextBox txtResourcePacksDirectory;
        private System.Windows.Forms.TextBox txtConfigDirectory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbServer;
        private System.Windows.Forms.RadioButton rbClient;
        private System.Windows.Forms.Label label5;
        private FancyButton cmdBrowseAnimation;
        private System.Windows.Forms.TextBox txtAnimationDirectory;
        private System.Windows.Forms.Label label8;
        private FancyButton fButtonCancel;
        private FancyButton fButtonSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSignPacksDirectory;
        private FancyButton cmdBrowseSignPacks;
    }
}