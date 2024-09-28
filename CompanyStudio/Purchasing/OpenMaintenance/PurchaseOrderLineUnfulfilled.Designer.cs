namespace CompanyStudio.Purchasing.OpenMaintenance
{
    partial class PurchaseOrderLineUnfulfilled
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServiceItem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnfulfilled = new System.Windows.Forms.TextBox();
            this.txtExpectedRailcars = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expected Railcars:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Service/Item:";
            // 
            // txtServiceItem
            // 
            this.txtServiceItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServiceItem.Location = new System.Drawing.Point(6, 42);
            this.txtServiceItem.Multiline = true;
            this.txtServiceItem.Name = "txtServiceItem";
            this.txtServiceItem.ReadOnly = true;
            this.txtServiceItem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtServiceItem.Size = new System.Drawing.Size(530, 47);
            this.txtServiceItem.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Unfulfilled Quantity:";
            // 
            // txtUnfulfilled
            // 
            this.txtUnfulfilled.Location = new System.Drawing.Point(128, 95);
            this.txtUnfulfilled.Name = "txtUnfulfilled";
            this.txtUnfulfilled.ReadOnly = true;
            this.txtUnfulfilled.Size = new System.Drawing.Size(58, 20);
            this.txtUnfulfilled.TabIndex = 5;
            // 
            // txtExpectedRailcars
            // 
            this.txtExpectedRailcars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpectedRailcars.Location = new System.Drawing.Point(105, 3);
            this.txtExpectedRailcars.Name = "txtExpectedRailcars";
            this.txtExpectedRailcars.ReadOnly = true;
            this.txtExpectedRailcars.Size = new System.Drawing.Size(431, 20);
            this.txtExpectedRailcars.TabIndex = 5;
            // 
            // PurchaseOrderLineUnfulfilled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtExpectedRailcars);
            this.Controls.Add(this.txtUnfulfilled);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtServiceItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PurchaseOrderLineUnfulfilled";
            this.Size = new System.Drawing.Size(539, 121);
            this.Load += new System.EventHandler(this.PurchaseOrderLineUnfulfilled_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServiceItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnfulfilled;
        private System.Windows.Forms.TextBox txtExpectedRailcars;
    }
}
