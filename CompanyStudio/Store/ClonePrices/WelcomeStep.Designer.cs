namespace CompanyStudio.Store.ClonePrices
{
    partial class WelcomeStep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeStep));
            this.label1 = new System.Windows.Forms.Label();
            this.chkDefaultAdd = new System.Windows.Forms.CheckBox();
            this.chkDefaultUpdate = new System.Windows.Forms.CheckBox();
            this.chkDefaultDelete = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(439, 178);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // chkDefaultAdd
            // 
            this.chkDefaultAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDefaultAdd.AutoSize = true;
            this.chkDefaultAdd.Checked = true;
            this.chkDefaultAdd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefaultAdd.Location = new System.Drawing.Point(3, 194);
            this.chkDefaultAdd.Name = "chkDefaultAdd";
            this.chkDefaultAdd.Size = new System.Drawing.Size(266, 17);
            this.chkDefaultAdd.TabIndex = 1;
            this.chkDefaultAdd.Text = "Assume adding all items from origin to destination(s)";
            this.chkDefaultAdd.UseVisualStyleBackColor = true;
            // 
            // chkDefaultUpdate
            // 
            this.chkDefaultUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDefaultUpdate.AutoSize = true;
            this.chkDefaultUpdate.Checked = true;
            this.chkDefaultUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefaultUpdate.Location = new System.Drawing.Point(3, 217);
            this.chkDefaultUpdate.Name = "chkDefaultUpdate";
            this.chkDefaultUpdate.Size = new System.Drawing.Size(275, 17);
            this.chkDefaultUpdate.TabIndex = 1;
            this.chkDefaultUpdate.Text = "Assume updating all items from origin to destination(s)";
            this.chkDefaultUpdate.UseVisualStyleBackColor = true;
            // 
            // chkDefaultDelete
            // 
            this.chkDefaultDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDefaultDelete.AutoSize = true;
            this.chkDefaultDelete.Location = new System.Drawing.Point(3, 240);
            this.chkDefaultDelete.Name = "chkDefaultDelete";
            this.chkDefaultDelete.Size = new System.Drawing.Size(271, 17);
            this.chkDefaultDelete.TabIndex = 1;
            this.chkDefaultDelete.Text = "Assume deleting all items from origin to destination(s)";
            this.chkDefaultDelete.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To help make data entry easier for you, ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(226, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "please select some default options below:";
            // 
            // WelcomeStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkDefaultDelete);
            this.Controls.Add(this.chkDefaultUpdate);
            this.Controls.Add(this.chkDefaultAdd);
            this.Controls.Add(this.label1);
            this.Name = "WelcomeStep";
            this.Size = new System.Drawing.Size(439, 260);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDefaultAdd;
        private System.Windows.Forms.CheckBox chkDefaultUpdate;
        private System.Windows.Forms.CheckBox chkDefaultDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
