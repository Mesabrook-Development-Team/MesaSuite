namespace FleetTracking.Roster
{
    partial class BrowseRoster
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAssigned = new System.Windows.Forms.TabPage();
            this.tabOwned = new System.Windows.Forms.TabPage();
            this.tabLeased = new System.Windows.Forms.TabPage();
            this.tabLeaseRequests = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(1071, 555);
            this.splitContainer1.SplitterDistance = 285;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabAssigned);
            this.tabControl.Controls.Add(this.tabOwned);
            this.tabControl.Controls.Add(this.tabLeased);
            this.tabControl.Controls.Add(this.tabLeaseRequests);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1071, 285);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabAssigned
            // 
            this.tabAssigned.Location = new System.Drawing.Point(4, 22);
            this.tabAssigned.Name = "tabAssigned";
            this.tabAssigned.Padding = new System.Windows.Forms.Padding(3);
            this.tabAssigned.Size = new System.Drawing.Size(1063, 259);
            this.tabAssigned.TabIndex = 0;
            this.tabAssigned.Text = "Assigned";
            this.tabAssigned.UseVisualStyleBackColor = true;
            // 
            // tabOwned
            // 
            this.tabOwned.Location = new System.Drawing.Point(4, 22);
            this.tabOwned.Name = "tabOwned";
            this.tabOwned.Padding = new System.Windows.Forms.Padding(3);
            this.tabOwned.Size = new System.Drawing.Size(1063, 259);
            this.tabOwned.TabIndex = 1;
            this.tabOwned.Text = "Owned";
            this.tabOwned.UseVisualStyleBackColor = true;
            // 
            // tabLeased
            // 
            this.tabLeased.Location = new System.Drawing.Point(4, 22);
            this.tabLeased.Name = "tabLeased";
            this.tabLeased.Size = new System.Drawing.Size(1063, 259);
            this.tabLeased.TabIndex = 2;
            this.tabLeased.Text = "Leased";
            this.tabLeased.UseVisualStyleBackColor = true;
            // 
            // tabLeaseRequests
            // 
            this.tabLeaseRequests.Location = new System.Drawing.Point(4, 22);
            this.tabLeaseRequests.Name = "tabLeaseRequests";
            this.tabLeaseRequests.Size = new System.Drawing.Size(1063, 259);
            this.tabLeaseRequests.TabIndex = 3;
            this.tabLeaseRequests.Text = "Lease Requests";
            this.tabLeaseRequests.UseVisualStyleBackColor = true;
            // 
            // BrowseRoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "BrowseRoster";
            this.Size = new System.Drawing.Size(1071, 555);
            this.Load += new System.EventHandler(this.BrowseRoster_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAssigned;
        private System.Windows.Forms.TabPage tabOwned;
        private System.Windows.Forms.TabPage tabLeased;
        private System.Windows.Forms.TabPage tabLeaseRequests;
    }
}
