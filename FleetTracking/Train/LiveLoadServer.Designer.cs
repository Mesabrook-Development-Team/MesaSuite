namespace FleetTracking.Train
{
    partial class LiveLoadServer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiveLoadServer));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdEndServer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstClients = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tmrServer = new System.Windows.Forms.Timer(this.components);
            this.loader = new FleetTracking.Loader();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::FleetTracking.Properties.Resources.gif_loader;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Live Load in progress...";
            // 
            // lblCode
            // 
            this.lblCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(3, 16);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(370, 61);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "Fetching...";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblCode);
            this.groupBox1.Location = new System.Drawing.Point(3, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 80);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Live Load Code";
            // 
            // cmdEndServer
            // 
            this.cmdEndServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEndServer.Location = new System.Drawing.Point(271, 290);
            this.cmdEndServer.Name = "cmdEndServer";
            this.cmdEndServer.Size = new System.Drawing.Size(108, 23);
            this.cmdEndServer.TabIndex = 4;
            this.cmdEndServer.Text = "End Live Loading";
            this.cmdEndServer.UseVisualStyleBackColor = true;
            this.cmdEndServer.Click += new System.EventHandler(this.cmdEndServer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lstClients);
            this.groupBox2.Location = new System.Drawing.Point(3, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 104);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connected Clients";
            // 
            // lstClients
            // 
            this.lstClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstClients.HideSelection = false;
            this.lstClients.Location = new System.Drawing.Point(3, 16);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(370, 85);
            this.lstClients.SmallImageList = this.imageList;
            this.lstClients.TabIndex = 0;
            this.lstClients.UseCompatibleStateImageBehavior = false;
            this.lstClients.View = System.Windows.Forms.View.SmallIcon;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "user");
            // 
            // tmrServer
            // 
            this.tmrServer.Interval = 5000;
            this.tmrServer.Tick += new System.EventHandler(this.tmrServer_Tick);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(382, 316);
            this.loader.TabIndex = 6;
            this.loader.Visible = false;
            // 
            // LiveLoadServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdEndServer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.loader);
            this.Name = "LiveLoadServer";
            this.Size = new System.Drawing.Size(382, 316);
            this.Load += new System.EventHandler(this.LiveLoadServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdEndServer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstClients;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Timer tmrServer;
        private Loader loader;
    }
}
