namespace SystemManagement
{
    partial class frmItemImporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemImporter));
            this.label1 = new System.Windows.Forms.Label();
            this.txtImportFolder = new System.Windows.Forms.TextBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.grpPreview = new System.Windows.Forms.GroupBox();
            this.cmdStartImport = new System.Windows.Forms.Button();
            this.cmdCommit = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.openFolder = new WK.Libraries.BetterFolderBrowserNS.BetterFolderBrowser(this.components);
            this.loader = new SystemManagement.Loader();
            this.pnlUpload = new System.Windows.Forms.Panel();
            this.prgItem = new System.Windows.Forms.ProgressBar();
            this.prgNamespace = new System.Windows.Forms.ProgressBar();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblNamespace = new System.Windows.Forms.Label();
            this.grpPreview.SuspendLayout();
            this.pnlUpload.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Import Folder:";
            // 
            // txtImportFolder
            // 
            this.txtImportFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportFolder.Location = new System.Drawing.Point(103, 12);
            this.txtImportFolder.Name = "txtImportFolder";
            this.txtImportFolder.Size = new System.Drawing.Size(640, 20);
            this.txtImportFolder.TabIndex = 0;
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowse.Location = new System.Drawing.Point(749, 10);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowse.TabIndex = 1;
            this.cmdBrowse.Text = "Browse...";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // grpPreview
            // 
            this.grpPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPreview.Controls.Add(this.cmdStartImport);
            this.grpPreview.Location = new System.Drawing.Point(12, 38);
            this.grpPreview.Name = "grpPreview";
            this.grpPreview.Size = new System.Drawing.Size(812, 350);
            this.grpPreview.TabIndex = 2;
            this.grpPreview.TabStop = false;
            this.grpPreview.Text = "New Items to Import";
            // 
            // cmdStartImport
            // 
            this.cmdStartImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStartImport.Location = new System.Drawing.Point(72, 164);
            this.cmdStartImport.Name = "cmdStartImport";
            this.cmdStartImport.Size = new System.Drawing.Size(669, 23);
            this.cmdStartImport.TabIndex = 0;
            this.cmdStartImport.Text = "Start Import";
            this.cmdStartImport.UseVisualStyleBackColor = true;
            this.cmdStartImport.Click += new System.EventHandler(this.cmdStartImport_Click);
            // 
            // cmdCommit
            // 
            this.cmdCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCommit.Enabled = false;
            this.cmdCommit.Location = new System.Drawing.Point(749, 394);
            this.cmdCommit.Name = "cmdCommit";
            this.cmdCommit.Size = new System.Drawing.Size(75, 23);
            this.cmdCommit.TabIndex = 3;
            this.cmdCommit.Text = "Commit";
            this.cmdCommit.UseVisualStyleBackColor = true;
            this.cmdCommit.Click += new System.EventHandler(this.cmdCommit_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(668, 394);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // openFolder
            // 
            this.openFolder.Multiselect = false;
            this.openFolder.RootFolder = "C:\\Users\\CSX8600\\Desktop";
            this.openFolder.Title = "Please select a folder...";
            // 
            // loader
            // 
            this.loader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(320, 161);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(196, 101);
            this.loader.TabIndex = 5;
            this.loader.Visible = false;
            // 
            // pnlUpload
            // 
            this.pnlUpload.Controls.Add(this.prgItem);
            this.pnlUpload.Controls.Add(this.prgNamespace);
            this.pnlUpload.Controls.Add(this.lblItem);
            this.pnlUpload.Controls.Add(this.lblNamespace);
            this.pnlUpload.Location = new System.Drawing.Point(199, 166);
            this.pnlUpload.Name = "pnlUpload";
            this.pnlUpload.Size = new System.Drawing.Size(439, 91);
            this.pnlUpload.TabIndex = 6;
            this.pnlUpload.Visible = false;
            // 
            // prgItem
            // 
            this.prgItem.Location = new System.Drawing.Point(3, 60);
            this.prgItem.Name = "prgItem";
            this.prgItem.Size = new System.Drawing.Size(433, 23);
            this.prgItem.TabIndex = 1;
            // 
            // prgNamespace
            // 
            this.prgNamespace.Location = new System.Drawing.Point(3, 18);
            this.prgNamespace.Name = "prgNamespace";
            this.prgNamespace.Size = new System.Drawing.Size(433, 23);
            this.prgNamespace.TabIndex = 1;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(3, 44);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(30, 13);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "Item:";
            // 
            // lblNamespace
            // 
            this.lblNamespace.AutoSize = true;
            this.lblNamespace.Location = new System.Drawing.Point(3, 2);
            this.lblNamespace.Name = "lblNamespace";
            this.lblNamespace.Size = new System.Drawing.Size(67, 13);
            this.lblNamespace.TabIndex = 0;
            this.lblNamespace.Text = "Namespace:";
            // 
            // frmItemImporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 423);
            this.Controls.Add(this.pnlUpload);
            this.Controls.Add(this.loader);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdCommit);
            this.Controls.Add(this.grpPreview);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.txtImportFolder);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmItemImporter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Importer";
            this.grpPreview.ResumeLayout(false);
            this.pnlUpload.ResumeLayout(false);
            this.pnlUpload.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImportFolder;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.GroupBox grpPreview;
        private System.Windows.Forms.Button cmdStartImport;
        private System.Windows.Forms.Button cmdCommit;
        private System.Windows.Forms.Button cmdCancel;
        private WK.Libraries.BetterFolderBrowserNS.BetterFolderBrowser openFolder;
        private Loader loader;
        private System.Windows.Forms.Panel pnlUpload;
        private System.Windows.Forms.ProgressBar prgItem;
        private System.Windows.Forms.ProgressBar prgNamespace;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblNamespace;
    }
}