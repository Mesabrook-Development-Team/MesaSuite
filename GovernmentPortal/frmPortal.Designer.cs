﻿
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
            this.tsbMintCurrency = new System.Windows.Forms.ToolStripButton();
            this.tsmiTaxes = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiSalesTax = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEmploymentTax = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInvoices = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuInvoiceReceivable = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInvoicePayable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInvoicesInvoiceConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOfficials,
            this.tsbSwitchGovernment,
            this.toolEmail,
            this.toolAccounts,
            this.tsbMintCurrency,
            this.tsmiTaxes,
            this.mnuInvoices});
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
            this.tsbSwitchGovernment.Image = global::GovernmentPortal.Properties.Resources.government;
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
            this.toolEmail.Image = global::GovernmentPortal.Properties.Resources.mail_explorer;
            this.toolEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEmail.Name = "toolEmail";
            this.toolEmail.Size = new System.Drawing.Size(65, 22);
            this.toolEmail.Text = "Email";
            this.toolEmail.Visible = false;
            // 
            // tsmiAliases
            // 
            this.tsmiAliases.Image = global::GovernmentPortal.Properties.Resources.icn_alias;
            this.tsmiAliases.Name = "tsmiAliases";
            this.tsmiAliases.Size = new System.Drawing.Size(162, 22);
            this.tsmiAliases.Text = "Aliases";
            this.tsmiAliases.Click += new System.EventHandler(this.tsmiAliases_Click);
            // 
            // tsmiDistributionLists
            // 
            this.tsmiDistributionLists.Image = global::GovernmentPortal.Properties.Resources.icn_list;
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
            this.toolAccounts.Image = global::GovernmentPortal.Properties.Resources.icn_group;
            this.toolAccounts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAccounts.Name = "toolAccounts";
            this.toolAccounts.Size = new System.Drawing.Size(86, 22);
            this.toolAccounts.Text = "Accounts";
            this.toolAccounts.Visible = false;
            // 
            // tsmiAccountList
            // 
            this.tsmiAccountList.Image = global::GovernmentPortal.Properties.Resources.icn_list;
            this.tsmiAccountList.Name = "tsmiAccountList";
            this.tsmiAccountList.Size = new System.Drawing.Size(130, 22);
            this.tsmiAccountList.Text = "List";
            this.tsmiAccountList.Click += new System.EventHandler(this.tsmiAccountList_Click);
            // 
            // tsmiAccountCategories
            // 
            this.tsmiAccountCategories.Image = global::GovernmentPortal.Properties.Resources.icn_view;
            this.tsmiAccountCategories.Name = "tsmiAccountCategories";
            this.tsmiAccountCategories.Size = new System.Drawing.Size(130, 22);
            this.tsmiAccountCategories.Text = "Categories";
            this.tsmiAccountCategories.Click += new System.EventHandler(this.tsmiAccountCategories_Click);
            // 
            // tsbMintCurrency
            // 
            this.tsbMintCurrency.Image = global::GovernmentPortal.Properties.Resources.icn_coins;
            this.tsbMintCurrency.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMintCurrency.Name = "tsbMintCurrency";
            this.tsbMintCurrency.Size = new System.Drawing.Size(103, 22);
            this.tsbMintCurrency.Text = "Mint Currency";
            this.tsbMintCurrency.Visible = false;
            this.tsbMintCurrency.Click += new System.EventHandler(this.tsbMintCurrency_Click);
            // 
            // tsmiTaxes
            // 
            this.tsmiTaxes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSalesTax,
            this.tsmiEmploymentTax});
            this.tsmiTaxes.Image = global::GovernmentPortal.Properties.Resources.icn_dollar_in;
            this.tsmiTaxes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiTaxes.Name = "tsmiTaxes";
            this.tsmiTaxes.Size = new System.Drawing.Size(64, 22);
            this.tsmiTaxes.Text = "Taxes";
            this.tsmiTaxes.Visible = false;
            // 
            // tsmiSalesTax
            // 
            this.tsmiSalesTax.Image = global::GovernmentPortal.Properties.Resources.icn_dollar;
            this.tsmiSalesTax.Name = "tsmiSalesTax";
            this.tsmiSalesTax.Size = new System.Drawing.Size(180, 22);
            this.tsmiSalesTax.Text = "Sales Tax";
            this.tsmiSalesTax.Click += new System.EventHandler(this.tsmiSalesTax_Click);
            // 
            // tsmiEmploymentTax
            // 
            this.tsmiEmploymentTax.Image = global::GovernmentPortal.Properties.Resources.icn_group;
            this.tsmiEmploymentTax.Name = "tsmiEmploymentTax";
            this.tsmiEmploymentTax.Size = new System.Drawing.Size(180, 22);
            this.tsmiEmploymentTax.Text = "Employment Tax";
            this.tsmiEmploymentTax.Visible = false;
            // 
            // mnuInvoices
            // 
            this.mnuInvoices.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInvoiceReceivable,
            this.mnuInvoicePayable,
            this.toolStripMenuItem1,
            this.mnuInvoicesInvoiceConfiguration});
            this.mnuInvoices.Image = global::GovernmentPortal.Properties.Resources.icn_bill;
            this.mnuInvoices.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuInvoices.Name = "mnuInvoices";
            this.mnuInvoices.Size = new System.Drawing.Size(79, 22);
            this.mnuInvoices.Text = "Invoices";
            this.mnuInvoices.Visible = false;
            // 
            // mnuInvoiceReceivable
            // 
            this.mnuInvoiceReceivable.Image = global::GovernmentPortal.Properties.Resources.icn_dollar_in;
            this.mnuInvoiceReceivable.Name = "mnuInvoiceReceivable";
            this.mnuInvoiceReceivable.Size = new System.Drawing.Size(189, 22);
            this.mnuInvoiceReceivable.Text = "Receivable";
            this.mnuInvoiceReceivable.Click += new System.EventHandler(this.mnuInvoiceReceivable_Click);
            // 
            // mnuInvoicePayable
            // 
            this.mnuInvoicePayable.Image = global::GovernmentPortal.Properties.Resources.icn_dollar_out;
            this.mnuInvoicePayable.Name = "mnuInvoicePayable";
            this.mnuInvoicePayable.Size = new System.Drawing.Size(189, 22);
            this.mnuInvoicePayable.Text = "Payable";
            this.mnuInvoicePayable.Click += new System.EventHandler(this.mnuInvoicePayable_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(186, 6);
            // 
            // mnuInvoicesInvoiceConfiguration
            // 
            this.mnuInvoicesInvoiceConfiguration.Image = global::GovernmentPortal.Properties.Resources.icn_view;
            this.mnuInvoicesInvoiceConfiguration.Name = "mnuInvoicesInvoiceConfiguration";
            this.mnuInvoicesInvoiceConfiguration.Size = new System.Drawing.Size(189, 22);
            this.mnuInvoicesInvoiceConfiguration.Text = "Invoice Configuration";
            this.mnuInvoicesInvoiceConfiguration.Click += new System.EventHandler(this.mnuInvoicesInvoiceConfiguration_Click);
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
        private System.Windows.Forms.ToolStripButton tsbMintCurrency;
        private System.Windows.Forms.ToolStripDropDownButton tsmiTaxes;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalesTax;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmploymentTax;
        private System.Windows.Forms.ToolStripDropDownButton mnuInvoices;
        private System.Windows.Forms.ToolStripMenuItem mnuInvoiceReceivable;
        private System.Windows.Forms.ToolStripMenuItem mnuInvoicePayable;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuInvoicesInvoiceConfiguration;
    }
}

