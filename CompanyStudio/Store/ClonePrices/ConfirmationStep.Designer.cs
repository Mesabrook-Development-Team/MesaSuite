namespace CompanyStudio.Store.ClonePrices
{
    partial class ConfirmationStep
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
            this.lblBody = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChanges = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBody
            // 
            this.lblBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBody.Location = new System.Drawing.Point(0, 26);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(471, 13);
            this.lblBody.TabIndex = 0;
            this.lblBody.Text = "The following changes will be made:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "You\'re all set!";
            // 
            // txtChanges
            // 
            this.txtChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChanges.Location = new System.Drawing.Point(3, 42);
            this.txtChanges.Multiline = true;
            this.txtChanges.Name = "txtChanges";
            this.txtChanges.ReadOnly = true;
            this.txtChanges.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChanges.Size = new System.Drawing.Size(465, 166);
            this.txtChanges.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(0, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Click the Run button below to commit these changes.";
            // 
            // ConfirmationStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChanges);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBody);
            this.Name = "ConfirmationStep";
            this.Size = new System.Drawing.Size(471, 224);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChanges;
        private System.Windows.Forms.Label label1;
    }
}
