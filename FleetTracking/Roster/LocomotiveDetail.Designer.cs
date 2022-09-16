namespace FleetTracking.Roster
{
    partial class LocomotiveDetail
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.cboModel = new FleetTracking.ControlSelector();
            this.label4 = new System.Windows.Forms.Label();
            this.cboOwner = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrentLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReportingNumber = new System.Windows.Forms.TextBox();
            this.txtReportingMark = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdUpdateImage = new System.Windows.Forms.Button();
            this.pboxImage = new System.Windows.Forms.PictureBox();
            this.loader = new FleetTracking.Loader();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(852, 325);
            this.tabControl1.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.cboModel);
            this.tabGeneral.Controls.Add(this.label4);
            this.tabGeneral.Controls.Add(this.cboOwner);
            this.tabGeneral.Controls.Add(this.label3);
            this.tabGeneral.Controls.Add(this.txtCurrentLocation);
            this.tabGeneral.Controls.Add(this.label2);
            this.tabGeneral.Controls.Add(this.txtReportingNumber);
            this.tabGeneral.Controls.Add(this.txtReportingMark);
            this.tabGeneral.Controls.Add(this.label1);
            this.tabGeneral.Controls.Add(this.cmdUpdateImage);
            this.tabGeneral.Controls.Add(this.pboxImage);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(844, 299);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // cboModel
            // 
            this.cboModel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.Location = new System.Drawing.Point(428, 6);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(410, 21);
            this.cboModel.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Model:";
            // 
            // cboOwner
            // 
            this.cboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOwner.FormattingEnabled = true;
            this.cboOwner.Location = new System.Drawing.Point(428, 59);
            this.cboOwner.Name = "cboOwner";
            this.cboOwner.Size = new System.Drawing.Size(410, 21);
            this.cboOwner.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Owner:";
            // 
            // txtCurrentLocation
            // 
            this.txtCurrentLocation.Location = new System.Drawing.Point(428, 86);
            this.txtCurrentLocation.Name = "txtCurrentLocation";
            this.txtCurrentLocation.ReadOnly = true;
            this.txtCurrentLocation.Size = new System.Drawing.Size(410, 20);
            this.txtCurrentLocation.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current Location:";
            // 
            // txtReportingNumber
            // 
            this.txtReportingNumber.Location = new System.Drawing.Point(492, 33);
            this.txtReportingNumber.Name = "txtReportingNumber";
            this.txtReportingNumber.Size = new System.Drawing.Size(57, 20);
            this.txtReportingNumber.TabIndex = 2;
            // 
            // txtReportingMark
            // 
            this.txtReportingMark.Location = new System.Drawing.Point(429, 33);
            this.txtReportingMark.Name = "txtReportingMark";
            this.txtReportingMark.Size = new System.Drawing.Size(57, 20);
            this.txtReportingMark.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reporting Mark:";
            // 
            // cmdUpdateImage
            // 
            this.cmdUpdateImage.Location = new System.Drawing.Point(3, 270);
            this.cmdUpdateImage.Name = "cmdUpdateImage";
            this.cmdUpdateImage.Size = new System.Drawing.Size(325, 23);
            this.cmdUpdateImage.TabIndex = 5;
            this.cmdUpdateImage.Text = "Update Image";
            this.cmdUpdateImage.UseVisualStyleBackColor = true;
            // 
            // pboxImage
            // 
            this.pboxImage.Location = new System.Drawing.Point(3, 3);
            this.pboxImage.Name = "pboxImage";
            this.pboxImage.Size = new System.Drawing.Size(325, 261);
            this.pboxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxImage.TabIndex = 0;
            this.pboxImage.TabStop = false;
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(852, 325);
            this.loader.TabIndex = 1;
            this.loader.Visible = false;
            // 
            // LocomotiveDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.loader);
            this.Name = "LocomotiveDetail";
            this.Size = new System.Drawing.Size(852, 325);
            this.Load += new System.EventHandler(this.LocomotiveDetail_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.PictureBox pboxImage;
        private System.Windows.Forms.TextBox txtReportingNumber;
        private System.Windows.Forms.TextBox txtReportingMark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdUpdateImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrentLocation;
        private System.Windows.Forms.ComboBox cboOwner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ControlSelector cboModel;
        private Loader loader;
    }
}
