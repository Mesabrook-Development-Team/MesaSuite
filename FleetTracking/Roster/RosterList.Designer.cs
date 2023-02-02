namespace FleetTracking.Roster
{
    partial class RosterList
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
            this.panelList = new System.Windows.Forms.Panel();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoLocomotives = new System.Windows.Forms.RadioButton();
            this.rdoRailcars = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // panelList
            // 
            this.panelList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelList.Location = new System.Drawing.Point(0, 0);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(733, 293);
            this.panelList.TabIndex = 0;
            // 
            // rdoAll
            // 
            this.rdoAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.Location = new System.Drawing.Point(3, 299);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 0;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.CheckedChanged += new System.EventHandler(this.FilterCheckedChanged);
            // 
            // rdoLocomotives
            // 
            this.rdoLocomotives.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoLocomotives.AutoSize = true;
            this.rdoLocomotives.Location = new System.Drawing.Point(45, 299);
            this.rdoLocomotives.Name = "rdoLocomotives";
            this.rdoLocomotives.Size = new System.Drawing.Size(85, 17);
            this.rdoLocomotives.TabIndex = 0;
            this.rdoLocomotives.Text = "Locomotives";
            this.rdoLocomotives.UseVisualStyleBackColor = true;
            this.rdoLocomotives.CheckedChanged += new System.EventHandler(this.FilterCheckedChanged);
            // 
            // rdoRailcars
            // 
            this.rdoRailcars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoRailcars.AutoSize = true;
            this.rdoRailcars.Location = new System.Drawing.Point(136, 299);
            this.rdoRailcars.Name = "rdoRailcars";
            this.rdoRailcars.Size = new System.Drawing.Size(63, 17);
            this.rdoRailcars.TabIndex = 0;
            this.rdoRailcars.Text = "Railcars";
            this.rdoRailcars.UseVisualStyleBackColor = true;
            this.rdoRailcars.CheckedChanged += new System.EventHandler(this.FilterCheckedChanged);
            // 
            // RosterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdoRailcars);
            this.Controls.Add(this.rdoLocomotives);
            this.Controls.Add(this.rdoAll);
            this.Controls.Add(this.panelList);
            this.Name = "RosterList";
            this.Size = new System.Drawing.Size(736, 319);
            this.Load += new System.EventHandler(this.RosterList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoLocomotives;
        private System.Windows.Forms.RadioButton rdoRailcars;
    }
}
