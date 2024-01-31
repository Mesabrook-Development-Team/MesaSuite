namespace CompanyStudio.Store
{
    partial class frmPricingAutomation
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPricingAutomation));
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.grpProperties = new System.Windows.Forms.GroupBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkAdd = new System.Windows.Forms.CheckBox();
            this.grpLocations = new System.Windows.Forms.GroupBox();
            this.lstLocations = new System.Windows.Forms.ListBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.studioFormExtender = new CompanyStudio.StudioFormExtender(this.components);
            this.loader = new CompanyStudio.Loader();
            this.grpProperties.SuspendLayout();
            this.grpLocations.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Automation Setup";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(12, 35);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(115, 17);
            this.chkEnabled.TabIndex = 0;
            this.chkEnabled.Text = "Enable Automation";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // grpProperties
            // 
            this.grpProperties.Controls.Add(this.chkDelete);
            this.grpProperties.Controls.Add(this.chkUpdate);
            this.grpProperties.Controls.Add(this.chkAdd);
            this.grpProperties.Enabled = false;
            this.grpProperties.Location = new System.Drawing.Point(12, 58);
            this.grpProperties.Name = "grpProperties";
            this.grpProperties.Size = new System.Drawing.Size(298, 84);
            this.grpProperties.TabIndex = 1;
            this.grpProperties.TabStop = false;
            this.grpProperties.Text = "Automation Properties";
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(6, 65);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(147, 17);
            this.chkDelete.TabIndex = 2;
            this.chkDelete.Text = "Automatically delete items";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Location = new System.Drawing.Point(6, 42);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(151, 17);
            this.chkUpdate.TabIndex = 1;
            this.chkUpdate.Text = "Automatically update items";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkAdd
            // 
            this.chkAdd.AutoSize = true;
            this.chkAdd.Location = new System.Drawing.Point(6, 19);
            this.chkAdd.Name = "chkAdd";
            this.chkAdd.Size = new System.Drawing.Size(159, 17);
            this.chkAdd.TabIndex = 0;
            this.chkAdd.Text = "Automatically add new items";
            this.chkAdd.UseVisualStyleBackColor = true;
            // 
            // grpLocations
            // 
            this.grpLocations.Controls.Add(this.lstLocations);
            this.grpLocations.Enabled = false;
            this.grpLocations.Location = new System.Drawing.Point(12, 148);
            this.grpLocations.Name = "grpLocations";
            this.grpLocations.Size = new System.Drawing.Size(298, 162);
            this.grpLocations.TabIndex = 2;
            this.grpLocations.TabStop = false;
            this.grpLocations.Text = "Locations";
            // 
            // lstLocations
            // 
            this.lstLocations.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstLocations.FormattingEnabled = true;
            this.lstLocations.Location = new System.Drawing.Point(6, 19);
            this.lstLocations.Name = "lstLocations";
            this.lstLocations.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstLocations.Size = new System.Drawing.Size(286, 134);
            this.lstLocations.TabIndex = 0;
            this.lstLocations.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstLocations_DrawItem);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(235, 316);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(154, 316);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
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
            this.loader.Size = new System.Drawing.Size(322, 349);
            this.loader.TabIndex = 5;
            this.loader.Visible = false;
            // 
            // frmPricingAutomation
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(322, 347);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.grpLocations);
            this.Controls.Add(this.grpProperties);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPricingAutomation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Automation";
            this.Load += new System.EventHandler(this.frmPricingAutomation_Load);
            this.grpProperties.ResumeLayout(false);
            this.grpProperties.PerformLayout();
            this.grpLocations.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.GroupBox grpProperties;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkAdd;
        private System.Windows.Forms.GroupBox grpLocations;
        private System.Windows.Forms.ListBox lstLocations;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private StudioFormExtender studioFormExtender;
        private Loader loader;
    }
}