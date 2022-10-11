namespace FleetTracking.Leasing
{
    partial class LeaseManagement
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
            this.lblContracts = new System.Windows.Forms.Label();
            this.lblOverview = new System.Windows.Forms.Label();
            this.lblRequests = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblContracts);
            this.splitContainer1.Panel1.Controls.Add(this.lblOverview);
            this.splitContainer1.Panel1.Controls.Add(this.lblRequests);
            this.splitContainer1.Size = new System.Drawing.Size(938, 393);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 4;
            // 
            // lblContracts
            // 
            this.lblContracts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContracts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblContracts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContracts.Location = new System.Drawing.Point(0, 86);
            this.lblContracts.Name = "lblContracts";
            this.lblContracts.Size = new System.Drawing.Size(186, 43);
            this.lblContracts.TabIndex = 0;
            this.lblContracts.Text = "Lease Contracts";
            this.lblContracts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblContracts.Click += new System.EventHandler(this.lblTab_Click);
            this.lblContracts.MouseEnter += new System.EventHandler(this.lblTab_MouseEnter);
            this.lblContracts.MouseLeave += new System.EventHandler(this.lblTab_MouseLeave);
            // 
            // lblOverview
            // 
            this.lblOverview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOverview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverview.Location = new System.Drawing.Point(0, 0);
            this.lblOverview.Name = "lblOverview";
            this.lblOverview.Size = new System.Drawing.Size(186, 43);
            this.lblOverview.TabIndex = 0;
            this.lblOverview.Text = "Overview";
            this.lblOverview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOverview.Click += new System.EventHandler(this.lblTab_Click);
            this.lblOverview.MouseEnter += new System.EventHandler(this.lblTab_MouseEnter);
            this.lblOverview.MouseLeave += new System.EventHandler(this.lblTab_MouseLeave);
            // 
            // lblRequests
            // 
            this.lblRequests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRequests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequests.Location = new System.Drawing.Point(0, 43);
            this.lblRequests.Name = "lblRequests";
            this.lblRequests.Size = new System.Drawing.Size(186, 43);
            this.lblRequests.TabIndex = 0;
            this.lblRequests.Text = "Lease Requests";
            this.lblRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRequests.Click += new System.EventHandler(this.lblTab_Click);
            this.lblRequests.MouseEnter += new System.EventHandler(this.lblTab_MouseEnter);
            this.lblRequests.MouseLeave += new System.EventHandler(this.lblTab_MouseLeave);
            // 
            // LeaseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "LeaseManagement";
            this.Size = new System.Drawing.Size(938, 393);
            this.Load += new System.EventHandler(this.LeaseManagement_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblRequests;
        private System.Windows.Forms.Label lblContracts;
        private System.Windows.Forms.Label lblOverview;
    }
}
