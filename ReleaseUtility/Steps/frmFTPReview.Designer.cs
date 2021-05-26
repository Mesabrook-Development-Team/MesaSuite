namespace ReleaseUtility.Steps
{
    partial class frmFTPReview
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
            this.chkFiles = new System.Windows.Forms.CheckedListBox();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkFiles
            // 
            this.chkFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFiles.FormattingEnabled = true;
            this.chkFiles.HorizontalScrollbar = true;
            this.chkFiles.Location = new System.Drawing.Point(0, 0);
            this.chkFiles.Name = "chkFiles";
            this.chkFiles.Size = new System.Drawing.Size(431, 289);
            this.chkFiles.TabIndex = 0;
            // 
            // cmdSelect
            // 
            this.cmdSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelect.Location = new System.Drawing.Point(344, 295);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(75, 23);
            this.cmdSelect.TabIndex = 1;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(263, 295);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmFTPReview
            // 
            this.AcceptButton = this.cmdSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(431, 326);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.chkFiles);
            this.Name = "frmFTPReview";
            this.Text = "Review FTP Upload";
            this.Load += new System.EventHandler(this.frmFTPReview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkFiles;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.Button cmdCancel;
    }
}