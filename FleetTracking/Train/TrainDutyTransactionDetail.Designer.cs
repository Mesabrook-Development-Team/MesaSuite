namespace FleetTracking.Train
{
    partial class TrainDutyTransactionDetail
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
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpOnDuty = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpOffDuty = new System.Windows.Forms.DateTimePicker();
            this.chkOffDuty = new System.Windows.Forms.CheckBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.loader = new FleetTracking.Loader();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Operator:";
            // 
            // cboOperator
            // 
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Location = new System.Drawing.Point(84, 3);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(375, 21);
            this.cboOperator.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time On Duty:";
            // 
            // dtpOnDuty
            // 
            this.dtpOnDuty.CustomFormat = "dddd MM/dd/yyyy HH:mm";
            this.dtpOnDuty.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOnDuty.Location = new System.Drawing.Point(84, 30);
            this.dtpOnDuty.Name = "dtpOnDuty";
            this.dtpOnDuty.Size = new System.Drawing.Size(375, 20);
            this.dtpOnDuty.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time Off Duty:";
            // 
            // dtpOffDuty
            // 
            this.dtpOffDuty.CustomFormat = "dddd MM/dd/yyyy HH:mm";
            this.dtpOffDuty.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOffDuty.Location = new System.Drawing.Point(84, 78);
            this.dtpOffDuty.Name = "dtpOffDuty";
            this.dtpOffDuty.Size = new System.Drawing.Size(375, 20);
            this.dtpOffDuty.TabIndex = 3;
            // 
            // chkOffDuty
            // 
            this.chkOffDuty.AutoSize = true;
            this.chkOffDuty.Location = new System.Drawing.Point(6, 56);
            this.chkOffDuty.Name = "chkOffDuty";
            this.chkOffDuty.Size = new System.Drawing.Size(65, 17);
            this.chkOffDuty.TabIndex = 2;
            this.chkOffDuty.Text = "Off Duty";
            this.chkOffDuty.UseVisualStyleBackColor = true;
            this.chkOffDuty.CheckedChanged += new System.EventHandler(this.chkOffDuty_CheckedChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(384, 104);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(303, 104);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 5;
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
            this.loader.Size = new System.Drawing.Size(462, 135);
            this.loader.TabIndex = 6;
            this.loader.Visible = false;
            // 
            // TrainDutyTransactionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.chkOffDuty);
            this.Controls.Add(this.dtpOffDuty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpOnDuty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboOperator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loader);
            this.Name = "TrainDutyTransactionDetail";
            this.Size = new System.Drawing.Size(462, 135);
            this.Load += new System.EventHandler(this.TrainDutyTransaction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboOperator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpOnDuty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpOffDuty;
        private System.Windows.Forms.CheckBox chkOffDuty;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private Loader loader;
    }
}
