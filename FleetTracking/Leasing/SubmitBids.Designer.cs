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
            this.cmdAddLeaseRequest = new System.Windows.Forms.Button();
            this.cmdRemoveLeaseRequest = new System.Windows.Forms.Button();
            this.loader = new FleetTracking.Loader();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.splitContainer1.Panel2.Controls.Add(this.cmdAddLeaseRequest);
            this.splitContainer1.Panel2.Controls.Add(this.cmdRemoveLeaseRequest);
            this.splitContainer1.Size = new System.Drawing.Size(824, 343);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
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
            this.treLeaseRequests.Size = new System.Drawing.Size(162, 327);
            this.treLeaseRequests.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
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
            this.tabControl.Size = new System.Drawing.Size(605, 324);
            this.tabControl.TabIndex = 1;
            // 
            // cmdAddLeaseRequest
            // 
            this.cmdAddLeaseRequest.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdAddLeaseRequest.Location = new System.Drawing.Point(2, 174);
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
            this.cmdRemoveLeaseRequest.Location = new System.Drawing.Point(3, 134);
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
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(824, 343);
            this.loader.TabIndex = 1;
            this.loader.Visible = false;
            // 
            // SubmitBids
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}
