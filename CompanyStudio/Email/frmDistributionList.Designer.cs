
namespace CompanyStudio.Email
{
    partial class frmDistributionList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDistributionList));
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoPublic = new System.Windows.Forms.RadioButton();
            this.rdoMembers = new System.Windows.Forms.RadioButton();
            this.rdoSpecific = new System.Windows.Forms.RadioButton();
            this.txtSpecific = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.loader = new CompanyStudio.Loader();
            this.lstRecipients = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "What is the address of the Distribution List?";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(12, 25);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(405, 20);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.TextChanged += new System.EventHandler(this.SetIsDirty);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Who is allowed to send to this Distribution List?";
            // 
            // rdoPublic
            // 
            this.rdoPublic.AutoSize = true;
            this.rdoPublic.Location = new System.Drawing.Point(12, 64);
            this.rdoPublic.Name = "rdoPublic";
            this.rdoPublic.Size = new System.Drawing.Size(54, 17);
            this.rdoPublic.TabIndex = 1;
            this.rdoPublic.TabStop = true;
            this.rdoPublic.Text = "Public";
            this.rdoPublic.UseVisualStyleBackColor = true;
            this.rdoPublic.CheckedChanged += new System.EventHandler(this.SetIsDirty);
            // 
            // rdoMembers
            // 
            this.rdoMembers.AutoSize = true;
            this.rdoMembers.Location = new System.Drawing.Point(72, 64);
            this.rdoMembers.Name = "rdoMembers";
            this.rdoMembers.Size = new System.Drawing.Size(99, 17);
            this.rdoMembers.TabIndex = 2;
            this.rdoMembers.TabStop = true;
            this.rdoMembers.Text = "Members of List";
            this.rdoMembers.UseVisualStyleBackColor = true;
            this.rdoMembers.CheckedChanged += new System.EventHandler(this.SetIsDirty);
            // 
            // rdoSpecific
            // 
            this.rdoSpecific.AutoSize = true;
            this.rdoSpecific.Location = new System.Drawing.Point(177, 64);
            this.rdoSpecific.Name = "rdoSpecific";
            this.rdoSpecific.Size = new System.Drawing.Size(93, 17);
            this.rdoSpecific.TabIndex = 3;
            this.rdoSpecific.TabStop = true;
            this.rdoSpecific.Text = "Specific email:";
            this.rdoSpecific.UseVisualStyleBackColor = true;
            this.rdoSpecific.CheckedChanged += new System.EventHandler(this.rdoSpecific_CheckedChanged);
            // 
            // txtSpecific
            // 
            this.txtSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSpecific.Enabled = false;
            this.txtSpecific.Location = new System.Drawing.Point(276, 63);
            this.txtSpecific.Name = "txtSpecific";
            this.txtSpecific.Size = new System.Drawing.Size(141, 20);
            this.txtSpecific.TabIndex = 4;
            this.txtSpecific.TextChanged += new System.EventHandler(this.SetIsDirty);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "What email addresses are part of this Distribution List?";
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(342, 201);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 8;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(261, 201);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 9;
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
            this.loader.Size = new System.Drawing.Size(428, 234);
            this.loader.TabIndex = 10;
            this.loader.Visible = false;
            // 
            // lstRecipients
            // 
            this.lstRecipients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRecipients.HideSelection = false;
            this.lstRecipients.LabelEdit = true;
            this.lstRecipients.Location = new System.Drawing.Point(12, 100);
            this.lstRecipients.Name = "lstRecipients";
            this.lstRecipients.Size = new System.Drawing.Size(405, 95);
            this.lstRecipients.TabIndex = 11;
            this.lstRecipients.UseCompatibleStateImageBehavior = false;
            this.lstRecipients.View = System.Windows.Forms.View.List;
            this.lstRecipients.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstRecipients_AfterLabelEdit);
            this.lstRecipients.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstRecipients_BeforeLabelEdit);
            this.lstRecipients.Click += new System.EventHandler(this.lstRecipients_Click);
            this.lstRecipients.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstRecipients_KeyDown);
            // 
            // frmDistributionList
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(429, 233);
            this.Controls.Add(this.lstRecipients);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSpecific);
            this.Controls.Add(this.rdoSpecific);
            this.Controls.Add(this.rdoMembers);
            this.Controls.Add(this.rdoPublic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loader);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDistributionList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Distribution List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDistributionList_FormClosed);
            this.Load += new System.EventHandler(this.frmDistributionList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoPublic;
        private System.Windows.Forms.RadioButton rdoMembers;
        private System.Windows.Forms.RadioButton rdoSpecific;
        private System.Windows.Forms.TextBox txtSpecific;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private Loader loader;
        private System.Windows.Forms.ListView lstRecipients;
    }
}