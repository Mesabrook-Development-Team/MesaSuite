
namespace CompanyStudio.Accounts
{
    partial class frmCategories
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
            "Click to add..."}, -1, System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategories));
            this.lstCategories = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAccountsCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loader = new CompanyStudio.Loader();
            this.studioFormExtender = new CompanyStudio.StudioFormExtender(this.components);
            this.SuspendLayout();
            // 
            // lstCategories
            // 
            this.lstCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colAccountsCount});
            this.lstCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCategories.FullRowSelect = true;
            this.lstCategories.HideSelection = false;
            this.lstCategories.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lstCategories.LabelEdit = true;
            this.lstCategories.Location = new System.Drawing.Point(0, 0);
            this.lstCategories.MultiSelect = false;
            this.lstCategories.Name = "lstCategories";
            this.lstCategories.Size = new System.Drawing.Size(502, 253);
            this.lstCategories.TabIndex = 0;
            this.lstCategories.UseCompatibleStateImageBehavior = false;
            this.lstCategories.View = System.Windows.Forms.View.Details;
            this.lstCategories.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstCategories_AfterLabelEdit);
            this.lstCategories.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstCategories_KeyUp);
            this.lstCategories.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstCategories_MouseClick);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 200;
            // 
            // colAccountsCount
            // 
            this.colAccountsCount.Text = "Accounts";
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(502, 253);
            this.loader.TabIndex = 1;
            // 
            // frmCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 253);
            this.Controls.Add(this.lstCategories);
            this.Controls.Add(this.loader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCategories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Categories";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCategories_FormClosed);
            this.Load += new System.EventHandler(this.frmCategories_Load);
            this.Shown += new System.EventHandler(this.frmCategories_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstCategories;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colAccountsCount;
        private Loader loader;
        private StudioFormExtender studioFormExtender;
    }
}