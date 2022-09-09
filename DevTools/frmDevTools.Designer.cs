namespace DevTools
{
    partial class frmDevTools
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtSQLProviderLocation = new System.Windows.Forms.TextBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMailConnectionString = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContainer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdMigrations = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdLoaders = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdDeploy = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmdBackEndAuth = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.rdoSysLive = new System.Windows.Forms.RadioButton();
            this.rdoSysLocal = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoSyncLive = new System.Windows.Forms.RadioButton();
            this.rdoSyncLocal = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdoCompanyLive = new System.Windows.Forms.RadioButton();
            this.rdoCompanyLocal = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdoAuthLive = new System.Windows.Forms.RadioButton();
            this.rdoAuthLocal = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rdoVersionLive = new System.Windows.Forms.RadioButton();
            this.rdoVersionLocal = new System.Windows.Forms.RadioButton();
            this.label20 = new System.Windows.Forms.Label();
            this.rdoLDAP = new System.Windows.Forms.RadioButton();
            this.rdoBackend = new System.Windows.Forms.RadioButton();
            this.label21 = new System.Windows.Forms.Label();
            this.numAPIPort = new System.Windows.Forms.NumericUpDown();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rdoGovLive = new System.Windows.Forms.RadioButton();
            this.rdoGovLocal = new System.Windows.Forms.RadioButton();
            this.label26 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.numAuthPort = new System.Windows.Forms.NumericUpDown();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rdoFleetLive = new System.Windows.Forms.RadioButton();
            this.rdoFleetLocal = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAPIPort)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAuthPort)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Confirm Configuration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SQL Provider Location:";
            // 
            // txtSQLProviderLocation
            // 
            this.txtSQLProviderLocation.Location = new System.Drawing.Point(171, 28);
            this.txtSQLProviderLocation.Name = "txtSQLProviderLocation";
            this.txtSQLProviderLocation.Size = new System.Drawing.Size(245, 20);
            this.txtSQLProviderLocation.TabIndex = 0;
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(422, 26);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowse.TabIndex = 1;
            this.cmdBrowse.Text = "Browse...";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Connection String:";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(171, 54);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(245, 20);
            this.txtConnectionString.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "hMailServer Connection String:";
            // 
            // txtMailConnectionString
            // 
            this.txtMailConnectionString.Location = new System.Drawing.Point(171, 80);
            this.txtMailConnectionString.Name = "txtMailConnectionString";
            this.txtMailConnectionString.Size = new System.Drawing.Size(245, 20);
            this.txtMailConnectionString.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "LDAP Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(171, 129);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(245, 20);
            this.txtAddress.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "LDAP Container:";
            // 
            // txtContainer
            // 
            this.txtContainer.Location = new System.Drawing.Point(171, 155);
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Size = new System.Drawing.Size(245, 20);
            this.txtContainer.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "LDAP Group Name:";
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(171, 181);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(245, 20);
            this.txtGroup.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(102, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "LDAP User:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(171, 207);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(245, 20);
            this.txtUser.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(78, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "LDAP Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(171, 233);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(245, 20);
            this.txtPassword.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(178, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 9);
            this.label10.TabIndex = 4;
            this.label10.Text = "* based on API-System";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 351);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(198, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "2. Run Database Migrations";
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(650, 296);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 20;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdMigrations
            // 
            this.cmdMigrations.Location = new System.Drawing.Point(15, 370);
            this.cmdMigrations.Name = "cmdMigrations";
            this.cmdMigrations.Size = new System.Drawing.Size(710, 23);
            this.cmdMigrations.TabIndex = 22;
            this.cmdMigrations.Text = "Run";
            this.cmdMigrations.UseVisualStyleBackColor = true;
            this.cmdMigrations.Click += new System.EventHandler(this.cmdMigrations_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 396);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "3. Run Loaders";
            // 
            // cmdLoaders
            // 
            this.cmdLoaders.Location = new System.Drawing.Point(15, 415);
            this.cmdLoaders.Name = "cmdLoaders";
            this.cmdLoaders.Size = new System.Drawing.Size(710, 23);
            this.cmdLoaders.TabIndex = 23;
            this.cmdLoaders.Text = "Run";
            this.cmdLoaders.UseVisualStyleBackColor = true;
            this.cmdLoaders.Click += new System.EventHandler(this.cmdLoaders_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 306);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(141, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "1.5 Deploy Schema";
            // 
            // cmdDeploy
            // 
            this.cmdDeploy.Location = new System.Drawing.Point(15, 325);
            this.cmdDeploy.Name = "cmdDeploy";
            this.cmdDeploy.Size = new System.Drawing.Size(710, 23);
            this.cmdDeploy.TabIndex = 21;
            this.cmdDeploy.Text = "Run";
            this.cmdDeploy.UseVisualStyleBackColor = true;
            this.cmdDeploy.Click += new System.EventHandler(this.cmdDeploy_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(153, 310);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 9);
            this.label14.TabIndex = 4;
            this.label14.Text = "* fresh database only";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 441);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Other Tools";
            // 
            // cmdBackEndAuth
            // 
            this.cmdBackEndAuth.Location = new System.Drawing.Point(15, 460);
            this.cmdBackEndAuth.Name = "cmdBackEndAuth";
            this.cmdBackEndAuth.Size = new System.Drawing.Size(81, 61);
            this.cmdBackEndAuth.TabIndex = 24;
            this.cmdBackEndAuth.Text = "Start Development Backend Auth";
            this.cmdBackEndAuth.UseVisualStyleBackColor = true;
            this.cmdBackEndAuth.Click += new System.EventHandler(this.cmdBackEndAuth_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(499, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "System Management:";
            // 
            // rdoSysLive
            // 
            this.rdoSysLive.AutoSize = true;
            this.rdoSysLive.Location = new System.Drawing.Point(0, 0);
            this.rdoSysLive.Name = "rdoSysLive";
            this.rdoSysLive.Size = new System.Drawing.Size(45, 17);
            this.rdoSysLive.TabIndex = 0;
            this.rdoSysLive.TabStop = true;
            this.rdoSysLive.Text = "Live";
            this.rdoSysLive.UseVisualStyleBackColor = true;
            // 
            // rdoSysLocal
            // 
            this.rdoSysLocal.AutoSize = true;
            this.rdoSysLocal.Location = new System.Drawing.Point(45, 0);
            this.rdoSysLocal.Name = "rdoSysLocal";
            this.rdoSysLocal.Size = new System.Drawing.Size(51, 17);
            this.rdoSysLocal.TabIndex = 1;
            this.rdoSysLocal.TabStop = true;
            this.rdoSysLocal.Text = "Local";
            this.rdoSysLocal.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(558, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "MCSync:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(521, 102);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Company Studio:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(530, 171);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(78, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Authentication:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoSysLive);
            this.panel1.Controls.Add(this.rdoSysLocal);
            this.panel1.Location = new System.Drawing.Point(614, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(91, 17);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoSyncLive);
            this.panel2.Controls.Add(this.rdoSyncLocal);
            this.panel2.Location = new System.Drawing.Point(614, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(91, 17);
            this.panel2.TabIndex = 14;
            // 
            // rdoSyncLive
            // 
            this.rdoSyncLive.AutoSize = true;
            this.rdoSyncLive.Location = new System.Drawing.Point(0, 0);
            this.rdoSyncLive.Name = "rdoSyncLive";
            this.rdoSyncLive.Size = new System.Drawing.Size(45, 17);
            this.rdoSyncLive.TabIndex = 0;
            this.rdoSyncLive.TabStop = true;
            this.rdoSyncLive.Text = "Live";
            this.rdoSyncLive.UseVisualStyleBackColor = true;
            // 
            // rdoSyncLocal
            // 
            this.rdoSyncLocal.AutoSize = true;
            this.rdoSyncLocal.Location = new System.Drawing.Point(45, 0);
            this.rdoSyncLocal.Name = "rdoSyncLocal";
            this.rdoSyncLocal.Size = new System.Drawing.Size(51, 17);
            this.rdoSyncLocal.TabIndex = 1;
            this.rdoSyncLocal.TabStop = true;
            this.rdoSyncLocal.Text = "Local";
            this.rdoSyncLocal.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdoCompanyLive);
            this.panel3.Controls.Add(this.rdoCompanyLocal);
            this.panel3.Location = new System.Drawing.Point(614, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(91, 17);
            this.panel3.TabIndex = 16;
            // 
            // rdoCompanyLive
            // 
            this.rdoCompanyLive.AutoSize = true;
            this.rdoCompanyLive.Location = new System.Drawing.Point(0, 0);
            this.rdoCompanyLive.Name = "rdoCompanyLive";
            this.rdoCompanyLive.Size = new System.Drawing.Size(45, 17);
            this.rdoCompanyLive.TabIndex = 0;
            this.rdoCompanyLive.TabStop = true;
            this.rdoCompanyLive.Text = "Live";
            this.rdoCompanyLive.UseVisualStyleBackColor = true;
            // 
            // rdoCompanyLocal
            // 
            this.rdoCompanyLocal.AutoSize = true;
            this.rdoCompanyLocal.Location = new System.Drawing.Point(45, 0);
            this.rdoCompanyLocal.Name = "rdoCompanyLocal";
            this.rdoCompanyLocal.Size = new System.Drawing.Size(51, 17);
            this.rdoCompanyLocal.TabIndex = 1;
            this.rdoCompanyLocal.TabStop = true;
            this.rdoCompanyLocal.Text = "Local";
            this.rdoCompanyLocal.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdoAuthLive);
            this.panel4.Controls.Add(this.rdoAuthLocal);
            this.panel4.Location = new System.Drawing.Point(614, 169);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(91, 17);
            this.panel4.TabIndex = 19;
            // 
            // rdoAuthLive
            // 
            this.rdoAuthLive.AutoSize = true;
            this.rdoAuthLive.Location = new System.Drawing.Point(0, 0);
            this.rdoAuthLive.Name = "rdoAuthLive";
            this.rdoAuthLive.Size = new System.Drawing.Size(45, 17);
            this.rdoAuthLive.TabIndex = 0;
            this.rdoAuthLive.TabStop = true;
            this.rdoAuthLive.Text = "Live";
            this.rdoAuthLive.UseVisualStyleBackColor = true;
            // 
            // rdoAuthLocal
            // 
            this.rdoAuthLocal.AutoSize = true;
            this.rdoAuthLocal.Location = new System.Drawing.Point(45, 0);
            this.rdoAuthLocal.Name = "rdoAuthLocal";
            this.rdoAuthLocal.Size = new System.Drawing.Size(51, 17);
            this.rdoAuthLocal.TabIndex = 1;
            this.rdoAuthLocal.TabStop = true;
            this.rdoAuthLocal.Text = "Local";
            this.rdoAuthLocal.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rdoVersionLive);
            this.panel5.Controls.Add(this.rdoVersionLocal);
            this.panel5.Location = new System.Drawing.Point(614, 77);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(91, 17);
            this.panel5.TabIndex = 15;
            // 
            // rdoVersionLive
            // 
            this.rdoVersionLive.AutoSize = true;
            this.rdoVersionLive.Location = new System.Drawing.Point(0, 0);
            this.rdoVersionLive.Name = "rdoVersionLive";
            this.rdoVersionLive.Size = new System.Drawing.Size(45, 17);
            this.rdoVersionLive.TabIndex = 0;
            this.rdoVersionLive.TabStop = true;
            this.rdoVersionLive.Text = "Live";
            this.rdoVersionLive.UseVisualStyleBackColor = true;
            // 
            // rdoVersionLocal
            // 
            this.rdoVersionLocal.AutoSize = true;
            this.rdoVersionLocal.Location = new System.Drawing.Point(45, 0);
            this.rdoVersionLocal.Name = "rdoVersionLocal";
            this.rdoVersionLocal.Size = new System.Drawing.Size(51, 17);
            this.rdoVersionLocal.TabIndex = 1;
            this.rdoVersionLocal.TabStop = true;
            this.rdoVersionLocal.Text = "Local";
            this.rdoVersionLocal.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(563, 79);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(45, 13);
            this.label20.TabIndex = 17;
            this.label20.Text = "Version:";
            // 
            // rdoLDAP
            // 
            this.rdoLDAP.AutoSize = true;
            this.rdoLDAP.Location = new System.Drawing.Point(171, 106);
            this.rdoLDAP.Name = "rdoLDAP";
            this.rdoLDAP.Size = new System.Drawing.Size(75, 17);
            this.rdoLDAP.TabIndex = 4;
            this.rdoLDAP.TabStop = true;
            this.rdoLDAP.Text = "Use LDAP";
            this.rdoLDAP.UseVisualStyleBackColor = true;
            this.rdoLDAP.CheckedChanged += new System.EventHandler(this.rdoLDAP_CheckedChanged);
            // 
            // rdoBackend
            // 
            this.rdoBackend.AutoSize = true;
            this.rdoBackend.Location = new System.Drawing.Point(252, 106);
            this.rdoBackend.Name = "rdoBackend";
            this.rdoBackend.Size = new System.Drawing.Size(138, 17);
            this.rdoBackend.TabIndex = 5;
            this.rdoBackend.TabStop = true;
            this.rdoBackend.Text = "Use Dev Backend Auth";
            this.rdoBackend.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(116, 261);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 13);
            this.label21.TabIndex = 1;
            this.label21.Text = "API Port:";
            // 
            // numAPIPort
            // 
            this.numAPIPort.Location = new System.Drawing.Point(171, 259);
            this.numAPIPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numAPIPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numAPIPort.Name = "numAPIPort";
            this.numAPIPort.Size = new System.Drawing.Size(245, 20);
            this.numAPIPort.TabIndex = 11;
            this.numAPIPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.rdoGovLive);
            this.panel6.Controls.Add(this.rdoGovLocal);
            this.panel6.Location = new System.Drawing.Point(614, 123);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(91, 17);
            this.panel6.TabIndex = 17;
            // 
            // rdoGovLive
            // 
            this.rdoGovLive.AutoSize = true;
            this.rdoGovLive.Location = new System.Drawing.Point(0, 0);
            this.rdoGovLive.Name = "rdoGovLive";
            this.rdoGovLive.Size = new System.Drawing.Size(45, 17);
            this.rdoGovLive.TabIndex = 0;
            this.rdoGovLive.TabStop = true;
            this.rdoGovLive.Text = "Live";
            this.rdoGovLive.UseVisualStyleBackColor = true;
            // 
            // rdoGovLocal
            // 
            this.rdoGovLocal.AutoSize = true;
            this.rdoGovLocal.Location = new System.Drawing.Point(45, 0);
            this.rdoGovLocal.Name = "rdoGovLocal";
            this.rdoGovLocal.Size = new System.Drawing.Size(51, 17);
            this.rdoGovLocal.TabIndex = 1;
            this.rdoGovLocal.TabStop = true;
            this.rdoGovLocal.Text = "Local";
            this.rdoGovLocal.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(510, 125);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(98, 13);
            this.label26.TabIndex = 1;
            this.label26.Text = "Government Portal:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(103, 287);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(62, 13);
            this.label22.TabIndex = 1;
            this.label22.Text = "OAuth Port:";
            // 
            // numAuthPort
            // 
            this.numAuthPort.Location = new System.Drawing.Point(171, 285);
            this.numAuthPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numAuthPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numAuthPort.Name = "numAuthPort";
            this.numAuthPort.Size = new System.Drawing.Size(245, 20);
            this.numAuthPort.TabIndex = 12;
            this.numAuthPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.rdoFleetLive);
            this.panel7.Controls.Add(this.rdoFleetLocal);
            this.panel7.Location = new System.Drawing.Point(614, 146);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(91, 17);
            this.panel7.TabIndex = 18;
            // 
            // rdoFleetLive
            // 
            this.rdoFleetLive.AutoSize = true;
            this.rdoFleetLive.Location = new System.Drawing.Point(0, 0);
            this.rdoFleetLive.Name = "rdoFleetLive";
            this.rdoFleetLive.Size = new System.Drawing.Size(45, 17);
            this.rdoFleetLive.TabIndex = 0;
            this.rdoFleetLive.TabStop = true;
            this.rdoFleetLive.Text = "Live";
            this.rdoFleetLive.UseVisualStyleBackColor = true;
            // 
            // rdoFleetLocal
            // 
            this.rdoFleetLocal.AutoSize = true;
            this.rdoFleetLocal.Location = new System.Drawing.Point(45, 0);
            this.rdoFleetLocal.Name = "rdoFleetLocal";
            this.rdoFleetLocal.Size = new System.Drawing.Size(51, 17);
            this.rdoFleetLocal.TabIndex = 1;
            this.rdoFleetLocal.TabStop = true;
            this.rdoFleetLocal.Text = "Local";
            this.rdoFleetLocal.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(530, 150);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(78, 13);
            this.label23.TabIndex = 1;
            this.label23.Text = "Fleet Tracking:";
            // 
            // frmDevTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 530);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.numAuthPort);
            this.Controls.Add(this.numAPIPort);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.rdoBackend);
            this.Controls.Add(this.rdoLDAP);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdBackEndAuth);
            this.Controls.Add(this.cmdLoaders);
            this.Controls.Add(this.cmdDeploy);
            this.Controls.Add(this.cmdMigrations);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtContainer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMailConnectionString);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtSQLProviderLocation);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Name = "frmDevTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MesaSuite Development Tools";
            this.Load += new System.EventHandler(this.frmDevTools_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAPIPort)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAuthPort)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSQLProviderLocation;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMailConnectionString;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtContainer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdMigrations;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdLoaders;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button cmdDeploy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button cmdBackEndAuth;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton rdoSysLive;
        private System.Windows.Forms.RadioButton rdoSysLocal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdoSyncLive;
        private System.Windows.Forms.RadioButton rdoSyncLocal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdoCompanyLive;
        private System.Windows.Forms.RadioButton rdoCompanyLocal;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdoAuthLive;
        private System.Windows.Forms.RadioButton rdoAuthLocal;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rdoVersionLive;
        private System.Windows.Forms.RadioButton rdoVersionLocal;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.RadioButton rdoLDAP;
        private System.Windows.Forms.RadioButton rdoBackend;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown numAPIPort;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton rdoGovLive;
        private System.Windows.Forms.RadioButton rdoGovLocal;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown numAuthPort;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.RadioButton rdoFleetLive;
        private System.Windows.Forms.RadioButton rdoFleetLocal;
        private System.Windows.Forms.Label label23;
    }
}

