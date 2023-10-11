namespace CompanyStudio.Store
{
    partial class frmStoreSales
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Welcome"}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Select Registers");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Select Items");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Time Ranges");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Review");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStoreSales));
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstNav = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdRun = new System.Windows.Forms.Button();
            this.pnlWelcome = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSelectRegisters = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.chkRegisters = new System.Windows.Forms.CheckedListBox();
            this.pnlSelectItems = new System.Windows.Forms.Panel();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.cmdAddItem = new System.Windows.Forms.Button();
            this.itmSelector = new CompanyStudio.ItemSelectorInput();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlTimeRange = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.pnlReview = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReview = new System.Windows.Forms.TextBox();
            this.colItemImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlWelcome.SuspendLayout();
            this.pnlSelectRegisters.SuspendLayout();
            this.pnlSelectItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlTimeRange.SuspendLayout();
            this.pnlReview.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(1, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(561, 2);
            this.label3.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::CompanyStudio.Properties.Resources.coins;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(518, 33);
            this.label2.TabIndex = 13;
            this.label2.Text = "Store Sales Report Wizard";
            // 
            // lstNav
            // 
            this.lstNav.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lstNav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstNav.AutoArrange = false;
            this.lstNav.HideSelection = false;
            this.lstNav.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lstNav.Location = new System.Drawing.Point(0, 33);
            this.lstNav.Name = "lstNav";
            this.lstNav.Size = new System.Drawing.Size(144, 337);
            this.lstNav.SmallImageList = this.imageList;
            this.lstNav.TabIndex = 12;
            this.lstNav.UseCompatibleStateImageBehavior = false;
            this.lstNav.View = System.Windows.Forms.View.SmallIcon;
            this.lstNav.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstNav_ItemSelectionChanged);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(208, 376);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 15;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBack.Location = new System.Drawing.Point(295, 376);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(75, 23);
            this.cmdBack.TabIndex = 16;
            this.cmdBack.Text = "< Back";
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNext.Location = new System.Drawing.Point(376, 376);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(75, 23);
            this.cmdNext.TabIndex = 17;
            this.cmdNext.Text = "Next >";
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdRun
            // 
            this.cmdRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRun.Location = new System.Drawing.Point(463, 376);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(75, 23);
            this.cmdRun.TabIndex = 18;
            this.cmdRun.Text = "Run Report";
            this.cmdRun.UseVisualStyleBackColor = true;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // pnlWelcome
            // 
            this.pnlWelcome.Controls.Add(this.label1);
            this.pnlWelcome.Location = new System.Drawing.Point(144, 34);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Size = new System.Drawing.Size(407, 333);
            this.pnlWelcome.TabIndex = 19;
            this.pnlWelcome.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 333);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // pnlSelectRegisters
            // 
            this.pnlSelectRegisters.Controls.Add(this.label4);
            this.pnlSelectRegisters.Controls.Add(this.chkRegisters);
            this.pnlSelectRegisters.Location = new System.Drawing.Point(144, 34);
            this.pnlSelectRegisters.Name = "pnlSelectRegisters";
            this.pnlSelectRegisters.Size = new System.Drawing.Size(407, 333);
            this.pnlSelectRegisters.TabIndex = 20;
            this.pnlSelectRegisters.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Which registers should be included?";
            // 
            // chkRegisters
            // 
            this.chkRegisters.FormattingEnabled = true;
            this.chkRegisters.Location = new System.Drawing.Point(6, 21);
            this.chkRegisters.Name = "chkRegisters";
            this.chkRegisters.Size = new System.Drawing.Size(388, 304);
            this.chkRegisters.TabIndex = 0;
            // 
            // pnlSelectItems
            // 
            this.pnlSelectItems.Controls.Add(this.chkShowAll);
            this.pnlSelectItems.Controls.Add(this.cmdAddItem);
            this.pnlSelectItems.Controls.Add(this.itmSelector);
            this.pnlSelectItems.Controls.Add(this.label5);
            this.pnlSelectItems.Controls.Add(this.dgvItems);
            this.pnlSelectItems.Location = new System.Drawing.Point(144, 34);
            this.pnlSelectItems.Name = "pnlSelectItems";
            this.pnlSelectItems.Size = new System.Drawing.Size(407, 333);
            this.pnlSelectItems.TabIndex = 21;
            this.pnlSelectItems.Visible = false;
            // 
            // chkShowAll
            // 
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.Location = new System.Drawing.Point(3, 3);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(95, 17);
            this.chkShowAll.TabIndex = 4;
            this.chkShowAll.Text = "Show All Items";
            this.chkShowAll.UseVisualStyleBackColor = true;
            this.chkShowAll.CheckedChanged += new System.EventHandler(this.chkShowAll_CheckedChanged);
            // 
            // cmdAddItem
            // 
            this.cmdAddItem.Location = new System.Drawing.Point(348, 18);
            this.cmdAddItem.Name = "cmdAddItem";
            this.cmdAddItem.Size = new System.Drawing.Size(57, 23);
            this.cmdAddItem.TabIndex = 3;
            this.cmdAddItem.Text = "Add";
            this.cmdAddItem.UseVisualStyleBackColor = true;
            this.cmdAddItem.Click += new System.EventHandler(this.cmdAddItem_Click);
            // 
            // itmSelector
            // 
            this.itmSelector.Location = new System.Drawing.Point(62, 20);
            this.itmSelector.Name = "itmSelector";
            this.itmSelector.SelectedID = null;
            this.itmSelector.Size = new System.Drawing.Size(280, 20);
            this.itmSelector.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(1, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Add Item:";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemImage,
            this.colItem,
            this.colRemove});
            this.dgvItems.Location = new System.Drawing.Point(3, 47);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(401, 278);
            this.dgvItems.TabIndex = 1;
            this.dgvItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellContentClick);
            this.dgvItems.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvItems_CellPainting);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(2, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Enter the date/time range of sales to show:";
            // 
            // pnlTimeRange
            // 
            this.pnlTimeRange.Controls.Add(this.label8);
            this.pnlTimeRange.Controls.Add(this.label7);
            this.pnlTimeRange.Controls.Add(this.dtpEnd);
            this.pnlTimeRange.Controls.Add(this.dtpStart);
            this.pnlTimeRange.Controls.Add(this.label6);
            this.pnlTimeRange.Location = new System.Drawing.Point(144, 34);
            this.pnlTimeRange.Name = "pnlTimeRange";
            this.pnlTimeRange.Size = new System.Drawing.Size(407, 333);
            this.pnlTimeRange.TabIndex = 22;
            this.pnlTimeRange.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Range End:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Range Start:";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "";
            this.dtpEnd.Location = new System.Drawing.Point(79, 47);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(315, 20);
            this.dtpEnd.TabIndex = 5;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "";
            this.dtpStart.Location = new System.Drawing.Point(79, 21);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(315, 20);
            this.dtpStart.TabIndex = 5;
            // 
            // pnlReview
            // 
            this.pnlReview.Controls.Add(this.label9);
            this.pnlReview.Controls.Add(this.txtReview);
            this.pnlReview.Location = new System.Drawing.Point(144, 34);
            this.pnlReview.Name = "pnlReview";
            this.pnlReview.Size = new System.Drawing.Size(407, 333);
            this.pnlReview.TabIndex = 23;
            this.pnlReview.Visible = false;
            this.pnlReview.VisibleChanged += new System.EventHandler(this.pnlReview_VisibleChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Review the report parameters:";
            // 
            // txtReview
            // 
            this.txtReview.Location = new System.Drawing.Point(6, 21);
            this.txtReview.Multiline = true;
            this.txtReview.Name = "txtReview";
            this.txtReview.ReadOnly = true;
            this.txtReview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReview.Size = new System.Drawing.Size(388, 304);
            this.txtReview.TabIndex = 0;
            // 
            // colItemImage
            // 
            this.colItemImage.HeaderText = "Image";
            this.colItemImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colItemImage.Name = "colItemImage";
            this.colItemImage.ReadOnly = true;
            this.colItemImage.Width = 40;
            // 
            // colItem
            // 
            this.colItem.HeaderText = "Item";
            this.colItem.Name = "colItem";
            this.colItem.ReadOnly = true;
            this.colItem.Width = 250;
            // 
            // colRemove
            // 
            this.colRemove.HeaderText = "Remove";
            this.colRemove.Name = "colRemove";
            this.colRemove.ReadOnly = true;
            this.colRemove.Width = 60;
            // 
            // frmStoreSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 411);
            this.Controls.Add(this.pnlSelectItems);
            this.Controls.Add(this.pnlTimeRange);
            this.Controls.Add(this.pnlReview);
            this.Controls.Add(this.pnlSelectRegisters);
            this.Controls.Add(this.pnlWelcome);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.cmdRun);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstNav);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStoreSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Store Sales Parameters";
            this.Load += new System.EventHandler(this.frmStoreSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlWelcome.ResumeLayout(false);
            this.pnlSelectRegisters.ResumeLayout(false);
            this.pnlSelectItems.ResumeLayout(false);
            this.pnlSelectItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlTimeRange.ResumeLayout(false);
            this.pnlTimeRange.PerformLayout();
            this.pnlReview.ResumeLayout(false);
            this.pnlReview.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstNav;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.Panel pnlWelcome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSelectRegisters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox chkRegisters;
        private System.Windows.Forms.Panel pnlSelectItems;
        private ItemSelectorInput itmSelector;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button cmdAddItem;
        private System.Windows.Forms.Panel pnlTimeRange;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Panel pnlReview;
        private System.Windows.Forms.TextBox txtReview;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.CheckBox chkShowAll;
        private System.Windows.Forms.DataGridViewImageColumn colItemImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewButtonColumn colRemove;
    }
}