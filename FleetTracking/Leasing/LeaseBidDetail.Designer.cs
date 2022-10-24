namespace FleetTracking.Leasing
{
    partial class LeaseBidDetail
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
            this.lblRollingStock = new System.Windows.Forms.Label();
            this.txtLeaseAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReceivedTo = new System.Windows.Forms.Label();
            this.cboReceivedTo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRecurringBilling = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRecurringAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTerms = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cboRollingStock = new FleetTracking.ControlSelector();
            this.loader = new FleetTracking.Loader();
            this.SuspendLayout();
            // 
            // lblRollingStock
            // 
            this.lblRollingStock.AutoSize = true;
            this.lblRollingStock.Location = new System.Drawing.Point(3, 9);
            this.lblRollingStock.Name = "lblRollingStock";
            this.lblRollingStock.Size = new System.Drawing.Size(0, 13);
            this.lblRollingStock.TabIndex = 0;
            // 
            // txtLeaseAmount
            // 
            this.txtLeaseAmount.Location = new System.Drawing.Point(104, 33);
            this.txtLeaseAmount.Name = "txtLeaseAmount";
            this.txtLeaseAmount.Size = new System.Drawing.Size(76, 20);
            this.txtLeaseAmount.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lease Amount:";
            // 
            // lblReceivedTo
            // 
            this.lblReceivedTo.AutoSize = true;
            this.lblReceivedTo.Location = new System.Drawing.Point(186, 36);
            this.lblReceivedTo.Name = "lblReceivedTo";
            this.lblReceivedTo.Size = new System.Drawing.Size(72, 13);
            this.lblReceivedTo.TabIndex = 4;
            this.lblReceivedTo.Text = "Received To:";
            this.lblReceivedTo.Visible = false;
            // 
            // cboReceivedTo
            // 
            this.cboReceivedTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReceivedTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboReceivedTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReceivedTo.FormattingEnabled = true;
            this.cboReceivedTo.Location = new System.Drawing.Point(264, 33);
            this.cboReceivedTo.Name = "cboReceivedTo";
            this.cboReceivedTo.Size = new System.Drawing.Size(270, 21);
            this.cboReceivedTo.TabIndex = 2;
            this.cboReceivedTo.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Recurring Billing:";
            // 
            // cboRecurringBilling
            // 
            this.cboRecurringBilling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRecurringBilling.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRecurringBilling.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRecurringBilling.FormattingEnabled = true;
            this.cboRecurringBilling.Location = new System.Drawing.Point(104, 60);
            this.cboRecurringBilling.Name = "cboRecurringBilling";
            this.cboRecurringBilling.Size = new System.Drawing.Size(430, 21);
            this.cboRecurringBilling.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Recurring Amount:";
            // 
            // txtRecurringAmount
            // 
            this.txtRecurringAmount.Location = new System.Drawing.Point(104, 87);
            this.txtRecurringAmount.Name = "txtRecurringAmount";
            this.txtRecurringAmount.Size = new System.Drawing.Size(76, 20);
            this.txtRecurringAmount.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Terms:";
            // 
            // txtTerms
            // 
            this.txtTerms.AcceptsReturn = true;
            this.txtTerms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTerms.Location = new System.Drawing.Point(3, 133);
            this.txtTerms.Multiline = true;
            this.txtTerms.Name = "txtTerms";
            this.txtTerms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTerms.Size = new System.Drawing.Size(531, 122);
            this.txtTerms.TabIndex = 5;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(459, 261);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            // 
            // cmdReset
            // 
            this.cmdReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReset.Location = new System.Drawing.Point(378, 261);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(75, 23);
            this.cmdReset.TabIndex = 7;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            // 
            // cboRollingStock
            // 
            this.cboRollingStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRollingStock.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboRollingStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRollingStock.FormattingEnabled = true;
            this.cboRollingStock.Location = new System.Drawing.Point(104, 6);
            this.cboRollingStock.Name = "cboRollingStock";
            this.cboRollingStock.Size = new System.Drawing.Size(430, 21);
            this.cboRollingStock.TabIndex = 0;
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(537, 291);
            this.loader.TabIndex = 9;
            this.loader.Visible = false;
            // 
            // LeaseBidDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtTerms);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboRecurringBilling);
            this.Controls.Add(this.cboReceivedTo);
            this.Controls.Add(this.lblReceivedTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRecurringAmount);
            this.Controls.Add(this.txtLeaseAmount);
            this.Controls.Add(this.cboRollingStock);
            this.Controls.Add(this.lblRollingStock);
            this.Controls.Add(this.loader);
            this.Name = "LeaseBidDetail";
            this.Size = new System.Drawing.Size(537, 291);
            this.Load += new System.EventHandler(this.LeaseBidDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRollingStock;
        private ControlSelector cboRollingStock;
        private System.Windows.Forms.TextBox txtLeaseAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReceivedTo;
        private System.Windows.Forms.ComboBox cboReceivedTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRecurringBilling;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRecurringAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTerms;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdReset;
        private Loader loader;
    }
}
