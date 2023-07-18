namespace GovernmentPortal.Law
{
    partial class frmLawEditor
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.treLaws = new System.Windows.Forms.TreeView();
            this.ctxLaws = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addLawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLawsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addSectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loaderLaws = new GovernmentPortal.Loader();
            this.pnlSection = new System.Windows.Forms.Panel();
            this.cmdMoveDown = new System.Windows.Forms.Button();
            this.cmdMoveUp = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loaderSection = new GovernmentPortal.Loader();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ctxLaws.SuspendLayout();
            this.pnlSection.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmdMoveDown);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.cmdMoveUp);
            this.splitContainer1.Panel1.Controls.Add(this.treLaws);
            this.splitContainer1.Panel1.Controls.Add(this.loaderLaws);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlSection);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Laws";
            // 
            // treLaws
            // 
            this.treLaws.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treLaws.ContextMenuStrip = this.ctxLaws;
            this.treLaws.LabelEdit = true;
            this.treLaws.Location = new System.Drawing.Point(0, 22);
            this.treLaws.Name = "treLaws";
            this.treLaws.Size = new System.Drawing.Size(163, 425);
            this.treLaws.TabIndex = 0;
            this.treLaws.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treLaws_BeforeLabelEdit);
            this.treLaws.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treLaws_AfterLabelEdit);
            this.treLaws.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treLaws_AfterSelect);
            // 
            // ctxLaws
            // 
            this.ctxLaws.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLawToolStripMenuItem,
            this.deleteLawsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addSectionToolStripMenuItem,
            this.deleteSectionsToolStripMenuItem});
            this.ctxLaws.Name = "ctxLaws";
            this.ctxLaws.Size = new System.Drawing.Size(150, 98);
            this.ctxLaws.Opening += new System.ComponentModel.CancelEventHandler(this.ctxLaws_Opening);
            // 
            // addLawToolStripMenuItem
            // 
            this.addLawToolStripMenuItem.Name = "addLawToolStripMenuItem";
            this.addLawToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addLawToolStripMenuItem.Text = "Add Law";
            this.addLawToolStripMenuItem.Click += new System.EventHandler(this.addLawToolStripMenuItem_Click);
            // 
            // deleteLawsToolStripMenuItem
            // 
            this.deleteLawsToolStripMenuItem.Name = "deleteLawsToolStripMenuItem";
            this.deleteLawsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.deleteLawsToolStripMenuItem.Text = "Delete Law";
            this.deleteLawsToolStripMenuItem.Click += new System.EventHandler(this.deleteLawsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 6);
            // 
            // addSectionToolStripMenuItem
            // 
            this.addSectionToolStripMenuItem.Name = "addSectionToolStripMenuItem";
            this.addSectionToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addSectionToolStripMenuItem.Text = "Add Section";
            this.addSectionToolStripMenuItem.Click += new System.EventHandler(this.addSectionToolStripMenuItem_Click);
            // 
            // deleteSectionsToolStripMenuItem
            // 
            this.deleteSectionsToolStripMenuItem.Name = "deleteSectionsToolStripMenuItem";
            this.deleteSectionsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.deleteSectionsToolStripMenuItem.Text = "Delete Section";
            this.deleteSectionsToolStripMenuItem.Click += new System.EventHandler(this.deleteSectionsToolStripMenuItem_Click);
            // 
            // loaderLaws
            // 
            this.loaderLaws.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loaderLaws.BackColor = System.Drawing.Color.Transparent;
            this.loaderLaws.Location = new System.Drawing.Point(0, 0);
            this.loaderLaws.Name = "loaderLaws";
            this.loaderLaws.Size = new System.Drawing.Size(193, 450);
            this.loaderLaws.TabIndex = 2;
            this.loaderLaws.Visible = false;
            // 
            // pnlSection
            // 
            this.pnlSection.Controls.Add(this.cmdReset);
            this.pnlSection.Controls.Add(this.cmdSave);
            this.pnlSection.Controls.Add(this.txtDetails);
            this.pnlSection.Controls.Add(this.label4);
            this.pnlSection.Controls.Add(this.txtTitle);
            this.pnlSection.Controls.Add(this.label3);
            this.pnlSection.Controls.Add(this.label2);
            this.pnlSection.Controls.Add(this.loaderSection);
            this.pnlSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSection.Location = new System.Drawing.Point(0, 0);
            this.pnlSection.Name = "pnlSection";
            this.pnlSection.Size = new System.Drawing.Size(601, 450);
            this.pnlSection.TabIndex = 0;
            this.pnlSection.Visible = false;
            // 
            // cmdMoveDown
            // 
            this.cmdMoveDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdMoveDown.Image = global::GovernmentPortal.Properties.Resources.arrow_down;
            this.cmdMoveDown.Location = new System.Drawing.Point(169, 228);
            this.cmdMoveDown.Name = "cmdMoveDown";
            this.cmdMoveDown.Size = new System.Drawing.Size(23, 23);
            this.cmdMoveDown.TabIndex = 6;
            this.cmdMoveDown.UseVisualStyleBackColor = true;
            this.cmdMoveDown.Click += new System.EventHandler(this.cmdMoveDown_Click);
            // 
            // cmdMoveUp
            // 
            this.cmdMoveUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdMoveUp.Image = global::GovernmentPortal.Properties.Resources.arrow_up;
            this.cmdMoveUp.Location = new System.Drawing.Point(169, 199);
            this.cmdMoveUp.Name = "cmdMoveUp";
            this.cmdMoveUp.Size = new System.Drawing.Size(23, 23);
            this.cmdMoveUp.TabIndex = 6;
            this.cmdMoveUp.UseVisualStyleBackColor = true;
            this.cmdMoveUp.Click += new System.EventHandler(this.cmdMoveUp_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReset.Location = new System.Drawing.Point(433, 415);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(75, 23);
            this.cmdReset.TabIndex = 4;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(514, 415);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // txtDetails
            // 
            this.txtDetails.AcceptsReturn = true;
            this.txtDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetails.Location = new System.Drawing.Point(3, 67);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size(586, 342);
            this.txtDetails.TabIndex = 3;
            this.txtDetails.TextChanged += new System.EventHandler(this.SectionDataChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Details:";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(29, 22);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(560, 20);
            this.txtTitle.TabIndex = 3;
            this.txtTitle.TextChanged += new System.EventHandler(this.SectionDataChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Section";
            // 
            // loaderSection
            // 
            this.loaderSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loaderSection.BackColor = System.Drawing.Color.Transparent;
            this.loaderSection.Location = new System.Drawing.Point(0, 0);
            this.loaderSection.Name = "loaderSection";
            this.loaderSection.Size = new System.Drawing.Size(601, 450);
            this.loaderSection.TabIndex = 5;
            this.loaderSection.Visible = false;
            // 
            // frmLawEditor
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdReset;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmLawEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laws";
            this.Load += new System.EventHandler(this.frmLawEditor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ctxLaws.ResumeLayout(false);
            this.pnlSection.ResumeLayout(false);
            this.pnlSection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treLaws;
        private System.Windows.Forms.ContextMenuStrip ctxLaws;
        private System.Windows.Forms.ToolStripMenuItem addLawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLawsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addSectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSectionsToolStripMenuItem;
        private System.Windows.Forms.Panel pnlSection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label label4;
        private Loader loaderLaws;
        private Loader loaderSection;
        private System.Windows.Forms.Button cmdMoveDown;
        private System.Windows.Forms.Button cmdMoveUp;
    }
}