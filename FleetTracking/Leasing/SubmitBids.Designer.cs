namespace FleetTracking.Leasing
{
    partial class SubmitBids
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.treLeaseRequests = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.cmdDeleteTab = new System.Windows.Forms.Button();
            this.cmdAddTab = new System.Windows.Forms.Button();
            this.cmdAddLeaseRequest = new System.Windows.Forms.Button();
            this.cmdRemoveLeaseRequest = new System.Windows.Forms.Button();
            this.loader = new FleetTracking.Loader();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.treLeaseRequests);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            this.splitContainer1.Panel2.Controls.Add(this.cmdDeleteTab);
            this.splitContainer1.Panel2.Controls.Add(this.cmdAddTab);
            this.splitContainer1.Panel2.Controls.Add(this.cmdAddLeaseRequest);
            this.splitContainer1.Panel2.Controls.Add(this.cmdRemoveLeaseRequest);
            this.splitContainer1.Size = new System.Drawing.Size(824, 311);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available Requests:";
            // 
            // treLeaseRequests
            // 
            this.treLeaseRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treLeaseRequests.Location = new System.Drawing.Point(0, 16);
            this.treLeaseRequests.Name = "treLeaseRequests";
            this.treLeaseRequests.Size = new System.Drawing.Size(162, 295);
            this.treLeaseRequests.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Your Bids:";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(50, 16);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(605, 292);
            this.tabControl.TabIndex = 1;
            // 
            // cmdDeleteTab
            // 
            this.cmdDeleteTab.Location = new System.Drawing.Point(3, 56);
            this.cmdDeleteTab.Name = "cmdDeleteTab";
            this.cmdDeleteTab.Size = new System.Drawing.Size(41, 34);
            this.cmdDeleteTab.TabIndex = 0;
            this.cmdDeleteTab.Text = "-\r\nTab";
            this.cmdDeleteTab.UseVisualStyleBackColor = true;
            this.cmdDeleteTab.Click += new System.EventHandler(this.cmdDeleteTab_Click);
            // 
            // cmdAddTab
            // 
            this.cmdAddTab.Location = new System.Drawing.Point(3, 16);
            this.cmdAddTab.Name = "cmdAddTab";
            this.cmdAddTab.Size = new System.Drawing.Size(41, 34);
            this.cmdAddTab.TabIndex = 0;
            this.cmdAddTab.Text = "+\r\nTab";
            this.cmdAddTab.UseVisualStyleBackColor = true;
            this.cmdAddTab.Click += new System.EventHandler(this.cmdAddTab_Click);
            // 
            // cmdAddLeaseRequest
            // 
            this.cmdAddLeaseRequest.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdAddLeaseRequest.Location = new System.Drawing.Point(2, 158);
            this.cmdAddLeaseRequest.Name = "cmdAddLeaseRequest";
            this.cmdAddLeaseRequest.Size = new System.Drawing.Size(41, 34);
            this.cmdAddLeaseRequest.TabIndex = 0;
            this.cmdAddLeaseRequest.Text = ">";
            this.cmdAddLeaseRequest.UseVisualStyleBackColor = true;
            this.cmdAddLeaseRequest.Click += new System.EventHandler(this.cmdAddLeaseRequest_Click);
            // 
            // cmdRemoveLeaseRequest
            // 
            this.cmdRemoveLeaseRequest.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdRemoveLeaseRequest.Location = new System.Drawing.Point(3, 118);
            this.cmdRemoveLeaseRequest.Name = "cmdRemoveLeaseRequest";
            this.cmdRemoveLeaseRequest.Size = new System.Drawing.Size(41, 34);
            this.cmdRemoveLeaseRequest.TabIndex = 0;
            this.cmdRemoveLeaseRequest.Text = "<";
            this.cmdRemoveLeaseRequest.UseVisualStyleBackColor = true;
            this.cmdRemoveLeaseRequest.Click += new System.EventHandler(this.cmdRemoveLeaseRequest_Click);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(-3, -3);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(824, 343);
            this.loader.TabIndex = 1;
            this.loader.Visible = false;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(746, 317);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(665, 317);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // SubmitBids
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.loader);
            this.Name = "SubmitBids";
            this.Size = new System.Drawing.Size(824, 343);
            this.Load += new System.EventHandler(this.SubmitBids_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treLeaseRequests;
        private System.Windows.Forms.Button cmdRemoveLeaseRequest;
        private System.Windows.Forms.Button cmdAddLeaseRequest;
        private System.Windows.Forms.TabControl tabControl;
        private Loader loader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdDeleteTab;
        private System.Windows.Forms.Button cmdAddTab;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
    }
}
