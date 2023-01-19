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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pboxImage = new System.Windows.Forms.PictureBox();
            this.cmdUpdateImage = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboModel = new FleetTracking.ControlSelector();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReportingMark = new System.Windows.Forms.TextBox();
            this.cboPossessor = new System.Windows.Forms.ComboBox();
            this.cboOwner = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReportingNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLessee = new System.Windows.Forms.TextBox();
            this.txtCurrentLocation = new System.Windows.Forms.TextBox();
            this.loader = new FleetTracking.Loader();
            this.cboCurrentLocation = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.tabGeneral.Controls.Add(this.splitContainer1);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(844, 299);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pboxImage);
            this.splitContainer1.Panel1.Controls.Add(this.cmdUpdateImage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cmdReset);
            this.splitContainer1.Panel2.Controls.Add(this.cmdSave);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.cboModel);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtReportingMark);
            this.splitContainer1.Panel2.Controls.Add(this.cboPossessor);
            this.splitContainer1.Panel2.Controls.Add(this.cboOwner);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.txtReportingNumber);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txtLessee);
            this.splitContainer1.Panel2.Controls.Add(this.txtCurrentLocation);
            this.splitContainer1.Panel2.Controls.Add(this.cboCurrentLocation);
            this.splitContainer1.Size = new System.Drawing.Size(838, 293);
            this.splitContainer1.SplitterDistance = 325;
            this.splitContainer1.TabIndex = 0;
            // 
            // pboxImage
            // 
            this.pboxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxImage.Location = new System.Drawing.Point(-1, 0);
            this.pboxImage.Name = "pboxImage";
            this.pboxImage.Size = new System.Drawing.Size(325, 261);
            this.pboxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxImage.TabIndex = 0;
            this.pboxImage.TabStop = false;
            // 
            // cmdUpdateImage
            // 
            this.cmdUpdateImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpdateImage.Location = new System.Drawing.Point(-1, 267);
            this.cmdUpdateImage.Name = "cmdUpdateImage";
            this.cmdUpdateImage.Size = new System.Drawing.Size(325, 23);
            this.cmdUpdateImage.TabIndex = 0;
            this.cmdUpdateImage.Text = "Update Image";
            this.cmdUpdateImage.UseVisualStyleBackColor = true;
            this.cmdUpdateImage.Click += new System.EventHandler(this.cmdUpdateImage_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReset.Location = new System.Drawing.Point(350, 267);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(75, 23);
            this.cmdReset.TabIndex = 8;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(431, 267);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Model:";
            // 
            // cboModel
            // 
            this.cboModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboModel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.Location = new System.Drawing.Point(96, 3);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(410, 21);
            this.cboModel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reporting Mark:";
            // 
            // txtReportingMark
            // 
            this.txtReportingMark.Location = new System.Drawing.Point(96, 30);
            this.txtReportingMark.Name = "txtReportingMark";
            this.txtReportingMark.Size = new System.Drawing.Size(57, 20);
            this.txtReportingMark.TabIndex = 1;
            // 
            // cboPossessor
            // 
            this.cboPossessor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPossessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPossessor.FormattingEnabled = true;
            this.cboPossessor.Location = new System.Drawing.Point(96, 83);
            this.cboPossessor.Name = "cboPossessor";
            this.cboPossessor.Size = new System.Drawing.Size(410, 21);
            this.cboPossessor.Sorted = true;
            this.cboPossessor.TabIndex = 4;
            // 
            // cboOwner
            // 
            this.cboOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOwner.FormattingEnabled = true;
            this.cboOwner.Location = new System.Drawing.Point(96, 56);
            this.cboOwner.Name = "cboOwner";
            this.cboOwner.Size = new System.Drawing.Size(410, 21);
            this.cboOwner.Sorted = true;
            this.cboOwner.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Possessor:";
            // 
            // txtReportingNumber
            // 
            this.txtReportingNumber.Location = new System.Drawing.Point(159, 30);
            this.txtReportingNumber.Name = "txtReportingNumber";
            this.txtReportingNumber.Size = new System.Drawing.Size(57, 20);
            this.txtReportingNumber.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Owner:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Lessee:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current Location:";
            // 
            // txtLessee
            // 
            this.txtLessee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLessee.Location = new System.Drawing.Point(96, 110);
            this.txtLessee.Name = "txtLessee";
            this.txtLessee.ReadOnly = true;
            this.txtLessee.Size = new System.Drawing.Size(410, 20);
            this.txtLessee.TabIndex = 5;
            // 
            // txtCurrentLocation
            // 
            this.txtCurrentLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentLocation.Location = new System.Drawing.Point(96, 136);
            this.txtCurrentLocation.Name = "txtCurrentLocation";
            this.txtCurrentLocation.ReadOnly = true;
            this.txtCurrentLocation.Size = new System.Drawing.Size(410, 20);
            this.txtCurrentLocation.TabIndex = 6;
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
            this.loader.Size = new System.Drawing.Size(852, 325);
            this.loader.TabIndex = 1;
            this.loader.Visible = false;
            // 
            // cboCurrentLocation
            // 
            this.cboCurrentLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCurrentLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrentLocation.FormattingEnabled = true;
            this.cboCurrentLocation.Location = new System.Drawing.Point(96, 136);
            this.cboCurrentLocation.Name = "cboCurrentLocation";
            this.cboCurrentLocation.Size = new System.Drawing.Size(410, 21);
            this.cboCurrentLocation.Sorted = true;
            this.cboCurrentLocation.TabIndex = 6;
            this.cboCurrentLocation.Visible = false;
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.ComboBox cboPossessor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLessee;
        private System.Windows.Forms.ComboBox cboCurrentLocation;
    }
}
