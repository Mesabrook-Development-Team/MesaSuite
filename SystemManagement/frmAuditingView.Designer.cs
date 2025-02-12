namespace SystemManagement
{
    partial class frmAuditingView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuditingView));
            this.lstAuditData = new System.Windows.Forms.ListView();
            this.colAuditTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPosition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBlockName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlayer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpMinimum = new System.Windows.Forms.DateTimePicker();
            this.dtpMaximum = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFromX = new System.Windows.Forms.TextBox();
            this.txtFromY = new System.Windows.Forms.TextBox();
            this.txtFromZ = new System.Windows.Forms.TextBox();
            this.txtToX = new System.Windows.Forms.TextBox();
            this.txtToY = new System.Windows.Forms.TextBox();
            this.txtToZ = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBlockNames = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPlayers = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numTake = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numSkip = new System.Windows.Forms.NumericUpDown();
            this.cmdGo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkip)).BeginInit();
            this.SuspendLayout();
            // 
            // lstAuditData
            // 
            this.lstAuditData.AllowColumnReorder = true;
            this.lstAuditData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAuditData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAuditTime,
            this.colPosition,
            this.colBlockName,
            this.colPlayer,
            this.colAction});
            this.lstAuditData.FullRowSelect = true;
            this.lstAuditData.HideSelection = false;
            this.lstAuditData.Location = new System.Drawing.Point(1, 138);
            this.lstAuditData.Name = "lstAuditData";
            this.lstAuditData.Size = new System.Drawing.Size(705, 268);
            this.lstAuditData.TabIndex = 2;
            this.lstAuditData.UseCompatibleStateImageBehavior = false;
            this.lstAuditData.View = System.Windows.Forms.View.Details;
            this.lstAuditData.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstAuditData_ColumnClick);
            // 
            // colAuditTime
            // 
            this.colAuditTime.Text = "Audit Time";
            this.colAuditTime.Width = 150;
            // 
            // colPosition
            // 
            this.colPosition.Text = "Block Pos";
            this.colPosition.Width = 100;
            // 
            // colBlockName
            // 
            this.colBlockName.Text = "Block Name";
            this.colBlockName.Width = 150;
            // 
            // colPlayer
            // 
            this.colPlayer.Text = "Player";
            this.colPlayer.Width = 100;
            // 
            // colAction
            // 
            this.colAction.Text = "Action";
            this.colAction.Width = 100;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.numSkip);
            this.groupBox1.Controls.Add(this.numTake);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtToZ);
            this.groupBox1.Controls.Add(this.txtFromZ);
            this.groupBox1.Controls.Add(this.txtToY);
            this.groupBox1.Controls.Add(this.txtToX);
            this.groupBox1.Controls.Add(this.txtFromY);
            this.groupBox1.Controls.Add(this.txtPlayers);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtBlockNames);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFromX);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpMaximum);
            this.groupBox1.Controls.Add(this.dtpMinimum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Query";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Between Dates:";
            // 
            // dtpMinimum
            // 
            this.dtpMinimum.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.dtpMinimum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMinimum.Location = new System.Drawing.Point(6, 32);
            this.dtpMinimum.Name = "dtpMinimum";
            this.dtpMinimum.Size = new System.Drawing.Size(142, 20);
            this.dtpMinimum.TabIndex = 0;
            this.dtpMinimum.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // dtpMaximum
            // 
            this.dtpMaximum.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.dtpMaximum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMaximum.Location = new System.Drawing.Point(6, 58);
            this.dtpMaximum.Name = "dtpMaximum";
            this.dtpMaximum.Size = new System.Drawing.Size(142, 20);
            this.dtpMaximum.TabIndex = 1;
            this.dtpMaximum.Value = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(154, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Block Region:";
            // 
            // txtFromX
            // 
            this.txtFromX.Location = new System.Drawing.Point(157, 32);
            this.txtFromX.Name = "txtFromX";
            this.txtFromX.Size = new System.Drawing.Size(45, 20);
            this.txtFromX.TabIndex = 2;
            // 
            // txtFromY
            // 
            this.txtFromY.Location = new System.Drawing.Point(208, 32);
            this.txtFromY.Name = "txtFromY";
            this.txtFromY.Size = new System.Drawing.Size(45, 20);
            this.txtFromY.TabIndex = 3;
            // 
            // txtFromZ
            // 
            this.txtFromZ.Location = new System.Drawing.Point(259, 32);
            this.txtFromZ.Name = "txtFromZ";
            this.txtFromZ.Size = new System.Drawing.Size(45, 20);
            this.txtFromZ.TabIndex = 4;
            // 
            // txtToX
            // 
            this.txtToX.Location = new System.Drawing.Point(157, 58);
            this.txtToX.Name = "txtToX";
            this.txtToX.Size = new System.Drawing.Size(45, 20);
            this.txtToX.TabIndex = 5;
            // 
            // txtToY
            // 
            this.txtToY.Location = new System.Drawing.Point(208, 58);
            this.txtToY.Name = "txtToY";
            this.txtToY.Size = new System.Drawing.Size(45, 20);
            this.txtToY.TabIndex = 6;
            // 
            // txtToZ
            // 
            this.txtToZ.Location = new System.Drawing.Point(259, 58);
            this.txtToZ.Name = "txtToZ";
            this.txtToZ.Size = new System.Drawing.Size(45, 20);
            this.txtToZ.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(307, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Block Name(s):";
            // 
            // txtBlockNames
            // 
            this.txtBlockNames.Location = new System.Drawing.Point(310, 32);
            this.txtBlockNames.Name = "txtBlockNames";
            this.txtBlockNames.Size = new System.Drawing.Size(117, 20);
            this.txtBlockNames.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(332, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "% for wildcard";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(430, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Player(s):";
            // 
            // txtPlayers
            // 
            this.txtPlayers.Location = new System.Drawing.Point(433, 32);
            this.txtPlayers.Name = "txtPlayers";
            this.txtPlayers.Size = new System.Drawing.Size(117, 20);
            this.txtPlayers.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(455, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "% for wildcard";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(556, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Take:";
            // 
            // numTake
            // 
            this.numTake.Location = new System.Drawing.Point(602, 33);
            this.numTake.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTake.Name = "numTake";
            this.numTake.Size = new System.Drawing.Size(74, 20);
            this.numTake.TabIndex = 10;
            this.numTake.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(556, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Skip:";
            // 
            // numSkip
            // 
            this.numSkip.Location = new System.Drawing.Point(602, 59);
            this.numSkip.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numSkip.Name = "numSkip";
            this.numSkip.Size = new System.Drawing.Size(74, 20);
            this.numSkip.TabIndex = 11;
            // 
            // cmdGo
            // 
            this.cmdGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGo.Location = new System.Drawing.Point(619, 109);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(75, 23);
            this.cmdGo.TabIndex = 1;
            this.cmdGo.Text = "Go";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // frmAuditingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 407);
            this.Controls.Add(this.cmdGo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstAuditData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAuditingView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Audit Data";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstAuditData;
        private System.Windows.Forms.ColumnHeader colAuditTime;
        private System.Windows.Forms.ColumnHeader colPosition;
        private System.Windows.Forms.ColumnHeader colBlockName;
        private System.Windows.Forms.ColumnHeader colPlayer;
        private System.Windows.Forms.ColumnHeader colAction;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpMinimum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpMaximum;
        private System.Windows.Forms.TextBox txtToZ;
        private System.Windows.Forms.TextBox txtFromZ;
        private System.Windows.Forms.TextBox txtToY;
        private System.Windows.Forms.TextBox txtToX;
        private System.Windows.Forms.TextBox txtFromY;
        private System.Windows.Forms.TextBox txtFromX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBlockNames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPlayers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numSkip;
        private System.Windows.Forms.NumericUpDown numTake;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdGo;
    }
}