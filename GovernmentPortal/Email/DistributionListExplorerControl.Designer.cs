
namespace GovernmentPortal.Email
{
    partial class DistributionListExplorerControl
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
            this.lstRecipients = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSpecific = new System.Windows.Forms.TextBox();
            this.rdoSpecific = new System.Windows.Forms.RadioButton();
            this.rdoMembers = new System.Windows.Forms.RadioButton();
            this.rdoPublic = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loader = new GovernmentPortal.Loader();
            this.SuspendLayout();
            // 
            // lstRecipients
            // 
            this.lstRecipients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRecipients.HideSelection = false;
            this.lstRecipients.LabelEdit = true;
            this.lstRecipients.Location = new System.Drawing.Point(3, 91);
            this.lstRecipients.Name = "lstRecipients";
            this.lstRecipients.Size = new System.Drawing.Size(405, 95);
            this.lstRecipients.TabIndex = 20;
            this.lstRecipients.UseCompatibleStateImageBehavior = false;
            this.lstRecipients.View = System.Windows.Forms.View.List;
            this.lstRecipients.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstRecipients_AfterLabelEdit);
            this.lstRecipients.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstRecipients_BeforeLabelEdit);
            this.lstRecipients.Click += new System.EventHandler(this.lstRecipients_Click);
            this.lstRecipients.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstRecipients_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "What email addresses are part of this Distribution List?";
            // 
            // txtSpecific
            // 
            this.txtSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSpecific.Enabled = false;
            this.txtSpecific.Location = new System.Drawing.Point(267, 54);
            this.txtSpecific.Name = "txtSpecific";
            this.txtSpecific.Size = new System.Drawing.Size(141, 20);
            this.txtSpecific.TabIndex = 18;
            this.txtSpecific.TextChanged += new System.EventHandler(this.FieldValueChanged);
            // 
            // rdoSpecific
            // 
            this.rdoSpecific.AutoSize = true;
            this.rdoSpecific.Location = new System.Drawing.Point(168, 55);
            this.rdoSpecific.Name = "rdoSpecific";
            this.rdoSpecific.Size = new System.Drawing.Size(93, 17);
            this.rdoSpecific.TabIndex = 17;
            this.rdoSpecific.TabStop = true;
            this.rdoSpecific.Text = "Specific email:";
            this.rdoSpecific.UseVisualStyleBackColor = true;
            this.rdoSpecific.CheckedChanged += new System.EventHandler(this.Mode_CheckedChanged);
            // 
            // rdoMembers
            // 
            this.rdoMembers.AutoSize = true;
            this.rdoMembers.Location = new System.Drawing.Point(63, 55);
            this.rdoMembers.Name = "rdoMembers";
            this.rdoMembers.Size = new System.Drawing.Size(99, 17);
            this.rdoMembers.TabIndex = 15;
            this.rdoMembers.TabStop = true;
            this.rdoMembers.Text = "Members of List";
            this.rdoMembers.UseVisualStyleBackColor = true;
            this.rdoMembers.CheckedChanged += new System.EventHandler(this.Mode_CheckedChanged);
            // 
            // rdoPublic
            // 
            this.rdoPublic.AutoSize = true;
            this.rdoPublic.Location = new System.Drawing.Point(3, 55);
            this.rdoPublic.Name = "rdoPublic";
            this.rdoPublic.Size = new System.Drawing.Size(54, 17);
            this.rdoPublic.TabIndex = 14;
            this.rdoPublic.TabStop = true;
            this.rdoPublic.Text = "Public";
            this.rdoPublic.UseVisualStyleBackColor = true;
            this.rdoPublic.CheckedChanged += new System.EventHandler(this.Mode_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Who is allowed to send to this Distribution List?";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(3, 16);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(405, 20);
            this.txtAddress.TabIndex = 12;
            this.txtAddress.TextChanged += new System.EventHandler(this.FieldValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "What is the address of the Distribution List?";
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(415, 194);
            this.loader.TabIndex = 21;
            this.loader.Visible = false;
            // 
            // DistributionListExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstRecipients);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSpecific);
            this.Controls.Add(this.rdoSpecific);
            this.Controls.Add(this.rdoMembers);
            this.Controls.Add(this.rdoPublic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loader);
            this.Name = "DistributionListExplorerControl";
            this.Size = new System.Drawing.Size(415, 194);
            this.Load += new System.EventHandler(this.DistributionListExplorerControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstRecipients;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSpecific;
        private System.Windows.Forms.RadioButton rdoSpecific;
        private System.Windows.Forms.RadioButton rdoMembers;
        private System.Windows.Forms.RadioButton rdoPublic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label1;
        private Loader loader;
    }
}
