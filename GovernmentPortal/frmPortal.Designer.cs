
namespace GovernmentPortal
{
    partial class frmPortal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPortal));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolOfficials = new System.Windows.Forms.ToolStripButton();
            this.tsbSwitchGovernment = new System.Windows.Forms.ToolStripButton();
            this.toolEmail = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiAliases = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDistributionLists = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAccounts = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiAccountList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAccountCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOfficials,
            this.tsbSwitchGovernment,
            this.toolEmail,
            this.toolAccounts});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(659, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolOfficials
            // 
            this.toolOfficials.Image = global::GovernmentPortal.Properties.Resources.icn_official;
            this.toolOfficials.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOfficials.Name = "toolOfficials";
            this.toolOfficials.Size = new System.Drawing.Size(70, 22);
            this.toolOfficials.Text = "Officials";
            this.toolOfficials.Visible = false;
            this.toolOfficials.Click += new System.EventHandler(this.toolOfficials_Click);
            // 
            // tsbSwitchGovernment
            // 
            this.tsbSwitchGovernment.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbSwitchGovernment.Image = ((System.Drawing.Image)(resources.GetObject("tsbSwitchGovernment.Image")));
            this.tsbSwitchGovernment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSwitchGovernment.Name = "tsbSwitchGovernment";
            this.tsbSwitchGovernment.Size = new System.Drawing.Size(131, 22);
            this.tsbSwitchGovernment.Text = "Switch Government";
            this.tsbSwitchGovernment.Click += new System.EventHandler(this.tsbSwitchGovernment_Click);
            // 
            // toolEmail
            // 
            this.toolEmail.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAliases,
            this.tsmiDistributionLists});
            this.toolEmail.Image = ((System.Drawing.Image)(resources.GetObject("toolEmail.Image")));
            this.toolEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEmail.Name = "toolEmail";
            this.toolEmail.Size = new System.Drawing.Size(65, 22);
            this.toolEmail.Text = "Email";
            this.toolEmail.Visible = false;
            // 
            // tsmiAliases
            // 
            this.tsmiAliases.Name = "tsmiAliases";
            this.tsmiAliases.Size = new System.Drawing.Size(162, 22);
            this.tsmiAliases.Text = "Aliases";
            this.tsmiAliases.Click += new System.EventHandler(this.tsmiAliases_Click);
            // 
            // tsmiDistributionLists
            // 
            this.tsmiDistributionLists.Name = "tsmiDistributionLists";
            this.tsmiDistributionLists.Size = new System.Drawing.Size(162, 22);
            this.tsmiDistributionLists.Text = "Distribution Lists";
            this.tsmiDistributionLists.Click += new System.EventHandler(this.tsmiDistributionLists_Click);
            // 
            // toolAccounts
            // 
            this.toolAccounts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAccountList,
            this.tsmiAccountCategories});
            this.toolAccounts.Image = ((System.Drawing.Image)(resources.GetObject("toolAccounts.Image")));
            this.toolAccounts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAccounts.Name = "toolAccounts";
            this.toolAccounts.Size = new System.Drawing.Size(86, 22);
            this.toolAccounts.Text = "Accounts";
            this.toolAccounts.Visible = false;
            // 
            // tsmiAccountList
            // 
            this.tsmiAccountList.Name = "tsmiAccountList";
            this.tsmiAccountList.Size = new System.Drawing.Size(180, 22);
            this.tsmiAccountList.Text = "List";
            this.tsmiAccountList.Click += new System.EventHandler(this.tsmiAccountList_Click);
            // 
            // tsmiAccountCategories
            // 
            this.tsmiAccountCategories.Name = "tsmiAccountCategories";
            this.tsmiAccountCategories.Size = new System.Drawing.Size(180, 22);
            this.tsmiAccountCategories.Text = "Categories";
            this.tsmiAccountCategories.Click += new System.EventHandler(this.tsmiAccountCategories_Click);
            // 
            // frmPortal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 371);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmPortal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Government Portal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPortal_FormClosing);
            this.Load += new System.EventHandler(this.frmPortal_Load);
            this.Shown += new System.EventHandler(this.frmPortal_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolOfficials;
        private System.Windows.Forms.ToolStripDropDownButton toolEmail;
        private System.Windows.Forms.ToolStripMenuItem tsmiAliases;
        private System.Windows.Forms.ToolStripMenuItem tsmiDistributionLists;
        private System.Windows.Forms.ToolStripButton tsbSwitchGovernment;
        private System.Windows.Forms.ToolStripDropDownButton toolAccounts;
        private System.Windows.Forms.ToolStripMenuItem tsmiAccountList;
        private System.Windows.Forms.ToolStripMenuItem tsmiAccountCategories;
    }
}

