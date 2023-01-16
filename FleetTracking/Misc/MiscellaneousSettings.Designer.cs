﻿namespace FleetTracking.Misc
{
    partial class MiscellaneousSettings
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdEditLocomotivesReleased = new System.Windows.Forms.Button();
            this.chkLocomotivesReleased = new System.Windows.Forms.CheckBox();
            this.cmdEditCarsReleased = new System.Windows.Forms.Button();
            this.chkCarsReleased = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpLocation = new System.Windows.Forms.GroupBox();
            this.cboLocationPayor = new System.Windows.Forms.ComboBox();
            this.cboLocationPayee = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flow = new System.Windows.Forms.FlowLayoutPanel();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.loader = new FleetTracking.Loader();
            this.chkNewLeaseRequests = new System.Windows.Forms.CheckBox();
            this.cmdNewLeaseRequests = new System.Windows.Forms.Button();
            this.chkLeaseBidsReceived = new System.Windows.Forms.CheckBox();
            this.cmdLeaseBidsReceived = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.grpLocation.SuspendLayout();
            this.flow.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdEditLocomotivesReleased);
            this.groupBox2.Controls.Add(this.chkLocomotivesReleased);
            this.groupBox2.Controls.Add(this.cmdLeaseBidsReceived);
            this.groupBox2.Controls.Add(this.cmdNewLeaseRequests);
            this.groupBox2.Controls.Add(this.cmdEditCarsReleased);
            this.groupBox2.Controls.Add(this.chkLeaseBidsReceived);
            this.groupBox2.Controls.Add(this.chkNewLeaseRequests);
            this.groupBox2.Controls.Add(this.chkCarsReleased);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(3, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(621, 93);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Email";
            // 
            // cmdEditLocomotivesReleased
            // 
            this.cmdEditLocomotivesReleased.Enabled = false;
            this.cmdEditLocomotivesReleased.Location = new System.Drawing.Point(238, 61);
            this.cmdEditLocomotivesReleased.Name = "cmdEditLocomotivesReleased";
            this.cmdEditLocomotivesReleased.Size = new System.Drawing.Size(75, 23);
            this.cmdEditLocomotivesReleased.TabIndex = 2;
            this.cmdEditLocomotivesReleased.Text = "Edit Email";
            this.cmdEditLocomotivesReleased.UseVisualStyleBackColor = true;
            this.cmdEditLocomotivesReleased.Click += new System.EventHandler(this.cmdEditLocomotivesReleased_Click);
            // 
            // chkLocomotivesReleased
            // 
            this.chkLocomotivesReleased.AutoSize = true;
            this.chkLocomotivesReleased.Location = new System.Drawing.Point(64, 65);
            this.chkLocomotivesReleased.Name = "chkLocomotivesReleased";
            this.chkLocomotivesReleased.Size = new System.Drawing.Size(168, 17);
            this.chkLocomotivesReleased.TabIndex = 1;
            this.chkLocomotivesReleased.Text = "Locomotives Released To Me";
            this.chkLocomotivesReleased.UseVisualStyleBackColor = true;
            this.chkLocomotivesReleased.CheckedChanged += new System.EventHandler(this.chkLocomotivesReleased_CheckedChanged);
            // 
            // cmdEditCarsReleased
            // 
            this.cmdEditCarsReleased.Enabled = false;
            this.cmdEditCarsReleased.Location = new System.Drawing.Point(238, 32);
            this.cmdEditCarsReleased.Name = "cmdEditCarsReleased";
            this.cmdEditCarsReleased.Size = new System.Drawing.Size(75, 23);
            this.cmdEditCarsReleased.TabIndex = 2;
            this.cmdEditCarsReleased.Text = "Edit Email";
            this.cmdEditCarsReleased.UseVisualStyleBackColor = true;
            this.cmdEditCarsReleased.Click += new System.EventHandler(this.cmdEditCarsReleased_Click);
            // 
            // chkCarsReleased
            // 
            this.chkCarsReleased.AutoSize = true;
            this.chkCarsReleased.Location = new System.Drawing.Point(64, 36);
            this.chkCarsReleased.Name = "chkCarsReleased";
            this.chkCarsReleased.Size = new System.Drawing.Size(129, 17);
            this.chkCarsReleased.TabIndex = 1;
            this.chkCarsReleased.Text = "Cars Released To Me";
            this.chkCarsReleased.UseVisualStyleBackColor = true;
            this.chkCarsReleased.CheckedChanged += new System.EventHandler(this.chkCarsReleased_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "I would like to receive emails about...";
            // 
            // grpLocation
            // 
            this.grpLocation.Controls.Add(this.cboLocationPayor);
            this.grpLocation.Controls.Add(this.cboLocationPayee);
            this.grpLocation.Controls.Add(this.label3);
            this.grpLocation.Controls.Add(this.label1);
            this.grpLocation.Location = new System.Drawing.Point(3, 3);
            this.grpLocation.Name = "grpLocation";
            this.grpLocation.Size = new System.Drawing.Size(621, 100);
            this.grpLocation.TabIndex = 0;
            this.grpLocation.TabStop = false;
            this.grpLocation.Text = "Invoicing Setup";
            // 
            // cboLocationPayor
            // 
            this.cboLocationPayor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocationPayor.FormattingEnabled = true;
            this.cboLocationPayor.Location = new System.Drawing.Point(6, 72);
            this.cboLocationPayor.Name = "cboLocationPayor";
            this.cboLocationPayor.Size = new System.Drawing.Size(609, 21);
            this.cboLocationPayor.TabIndex = 1;
            // 
            // cboLocationPayee
            // 
            this.cboLocationPayee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocationPayee.FormattingEnabled = true;
            this.cboLocationPayee.Location = new System.Drawing.Point(6, 32);
            this.cboLocationPayee.Name = "cboLocationPayee";
            this.cboLocationPayee.Size = new System.Drawing.Size(609, 21);
            this.cboLocationPayee.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "What location shall be charged for track/train fees?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "What location shall receive payments for track/train fees?";
            // 
            // flow
            // 
            this.flow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flow.AutoScroll = true;
            this.flow.Controls.Add(this.grpLocation);
            this.flow.Controls.Add(this.groupBox2);
            this.flow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flow.Location = new System.Drawing.Point(0, 0);
            this.flow.Name = "flow";
            this.flow.Size = new System.Drawing.Size(627, 294);
            this.flow.TabIndex = 0;
            this.flow.Resize += new System.EventHandler(this.flow_Resize);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(549, 300);
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
            this.cmdCancel.Location = new System.Drawing.Point(468, 300);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(627, 326);
            this.loader.TabIndex = 1;
            this.loader.Visible = false;
            // 
            // chkNewLeaseRequests
            // 
            this.chkNewLeaseRequests.AutoSize = true;
            this.chkNewLeaseRequests.Location = new System.Drawing.Point(319, 36);
            this.chkNewLeaseRequests.Name = "chkNewLeaseRequests";
            this.chkNewLeaseRequests.Size = new System.Drawing.Size(128, 17);
            this.chkNewLeaseRequests.TabIndex = 1;
            this.chkNewLeaseRequests.Text = "New Lease Requests";
            this.chkNewLeaseRequests.UseVisualStyleBackColor = true;
            this.chkNewLeaseRequests.CheckedChanged += new System.EventHandler(this.chkNewLeaseRequests_CheckedChanged);
            // 
            // cmdNewLeaseRequests
            // 
            this.cmdNewLeaseRequests.Enabled = false;
            this.cmdNewLeaseRequests.Location = new System.Drawing.Point(482, 32);
            this.cmdNewLeaseRequests.Name = "cmdNewLeaseRequests";
            this.cmdNewLeaseRequests.Size = new System.Drawing.Size(75, 23);
            this.cmdNewLeaseRequests.TabIndex = 2;
            this.cmdNewLeaseRequests.Text = "Edit Email";
            this.cmdNewLeaseRequests.UseVisualStyleBackColor = true;
            this.cmdNewLeaseRequests.Click += new System.EventHandler(this.cmdNewLeaseRequests_Click);
            // 
            // chkLeaseBidsReceived
            // 
            this.chkLeaseBidsReceived.AutoSize = true;
            this.chkLeaseBidsReceived.Location = new System.Drawing.Point(319, 65);
            this.chkLeaseBidsReceived.Name = "chkLeaseBidsReceived";
            this.chkLeaseBidsReceived.Size = new System.Drawing.Size(157, 17);
            this.chkLeaseBidsReceived.TabIndex = 1;
            this.chkLeaseBidsReceived.Text = "Bids on my Lease Requests";
            this.chkLeaseBidsReceived.UseVisualStyleBackColor = true;
            this.chkLeaseBidsReceived.CheckedChanged += new System.EventHandler(this.chkLeaseBidsReceived_CheckedChanged);
            // 
            // cmdLeaseBidsReceived
            // 
            this.cmdLeaseBidsReceived.Enabled = false;
            this.cmdLeaseBidsReceived.Location = new System.Drawing.Point(482, 61);
            this.cmdLeaseBidsReceived.Name = "cmdLeaseBidsReceived";
            this.cmdLeaseBidsReceived.Size = new System.Drawing.Size(75, 23);
            this.cmdLeaseBidsReceived.TabIndex = 2;
            this.cmdLeaseBidsReceived.Text = "Edit Email";
            this.cmdLeaseBidsReceived.UseVisualStyleBackColor = true;
            this.cmdLeaseBidsReceived.Click += new System.EventHandler(this.cmdLeaseBidsReceived_Click);
            // 
            // MiscellaneousSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.flow);
            this.Controls.Add(this.loader);
            this.Name = "MiscellaneousSettings";
            this.Size = new System.Drawing.Size(627, 326);
            this.Load += new System.EventHandler(this.MiscellaneousSettings_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpLocation.ResumeLayout(false);
            this.grpLocation.PerformLayout();
            this.flow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Loader loader;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpLocation;
        private System.Windows.Forms.ComboBox cboLocationPayee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flow;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ComboBox cboLocationPayor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdEditCarsReleased;
        private System.Windows.Forms.CheckBox chkCarsReleased;
        private System.Windows.Forms.Button cmdEditLocomotivesReleased;
        private System.Windows.Forms.CheckBox chkLocomotivesReleased;
        private System.Windows.Forms.Button cmdLeaseBidsReceived;
        private System.Windows.Forms.Button cmdNewLeaseRequests;
        private System.Windows.Forms.CheckBox chkLeaseBidsReceived;
        private System.Windows.Forms.CheckBox chkNewLeaseRequests;
    }
}
