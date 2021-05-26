namespace ReleaseUtility
{
    partial class frmMain
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
            this.lstSteps = new System.Windows.Forms.TreeView();
            this.ctxSteps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNewStep = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteSteps = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdRun = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDefaults = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdDown = new System.Windows.Forms.Button();
            this.cmdUp = new System.Windows.Forms.Button();
            this.pnlRunning = new System.Windows.Forms.Panel();
            this.lblRunningStatus = new System.Windows.Forms.Label();
            this.prgStatus = new System.Windows.Forms.ProgressBar();
            this.ctxSteps.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlRunning.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSteps
            // 
            this.lstSteps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSteps.ContextMenuStrip = this.ctxSteps;
            this.lstSteps.Location = new System.Drawing.Point(12, 40);
            this.lstSteps.Name = "lstSteps";
            this.lstSteps.Size = new System.Drawing.Size(308, 305);
            this.lstSteps.TabIndex = 0;
            this.lstSteps.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstSteps_AfterSelect);
            // 
            // ctxSteps
            // 
            this.ctxSteps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewStep,
            this.toolStripMenuItem1,
            this.mnuDeleteSteps,
            this.mnuProperties});
            this.ctxSteps.Name = "ctxSteps";
            this.ctxSteps.Size = new System.Drawing.Size(134, 76);
            this.ctxSteps.Opening += new System.ComponentModel.CancelEventHandler(this.ctxSteps_Opening);
            // 
            // mnuNewStep
            // 
            this.mnuNewStep.Name = "mnuNewStep";
            this.mnuNewStep.Size = new System.Drawing.Size(133, 22);
            this.mnuNewStep.Text = "New Step";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(130, 6);
            // 
            // mnuDeleteSteps
            // 
            this.mnuDeleteSteps.Name = "mnuDeleteSteps";
            this.mnuDeleteSteps.Size = new System.Drawing.Size(133, 22);
            this.mnuDeleteSteps.Text = "Delete Step";
            this.mnuDeleteSteps.Click += new System.EventHandler(this.mnuDeleteSteps_Click);
            // 
            // mnuProperties
            // 
            this.mnuProperties.Name = "mnuProperties";
            this.mnuProperties.Size = new System.Drawing.Size(133, 22);
            this.mnuProperties.Text = "Properties";
            this.mnuProperties.Click += new System.EventHandler(this.mnuProperties_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Steps:";
            // 
            // cmdRun
            // 
            this.cmdRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRun.Location = new System.Drawing.Point(245, 351);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(75, 23);
            this.cmdRun.TabIndex = 1;
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = true;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(371, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuSave,
            this.mnuSaveAs,
            this.mnuOpen,
            this.toolStripMenuItem2,
            this.mnuDefaults,
            this.toolStripMenuItem3,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNew.Size = new System.Drawing.Size(146, 22);
            this.mnuNew.Text = "New";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSave.Size = new System.Drawing.Size(146, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.Size = new System.Drawing.Size(146, 22);
            this.mnuSaveAs.Text = "Save As...";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpen.Size = new System.Drawing.Size(146, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(143, 6);
            // 
            // mnuDefaults
            // 
            this.mnuDefaults.Name = "mnuDefaults";
            this.mnuDefaults.Size = new System.Drawing.Size(146, 22);
            this.mnuDefaults.Text = "Set Defaults";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(143, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(146, 22);
            this.mnuExit.Text = "Exit";
            // 
            // cmdDown
            // 
            this.cmdDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdDown.BackgroundImage = global::ReleaseUtility.Properties.Resources.down;
            this.cmdDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdDown.Enabled = false;
            this.cmdDown.Location = new System.Drawing.Point(326, 195);
            this.cmdDown.Name = "cmdDown";
            this.cmdDown.Size = new System.Drawing.Size(32, 32);
            this.cmdDown.TabIndex = 4;
            this.cmdDown.UseVisualStyleBackColor = true;
            this.cmdDown.Click += new System.EventHandler(this.cmdDown_Click);
            // 
            // cmdUp
            // 
            this.cmdUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdUp.BackgroundImage = global::ReleaseUtility.Properties.Resources.up;
            this.cmdUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdUp.Enabled = false;
            this.cmdUp.Location = new System.Drawing.Point(326, 157);
            this.cmdUp.Name = "cmdUp";
            this.cmdUp.Size = new System.Drawing.Size(32, 32);
            this.cmdUp.TabIndex = 4;
            this.cmdUp.UseVisualStyleBackColor = true;
            this.cmdUp.Click += new System.EventHandler(this.cmdUp_Click);
            // 
            // pnlRunning
            // 
            this.pnlRunning.Controls.Add(this.lblRunningStatus);
            this.pnlRunning.Controls.Add(this.prgStatus);
            this.pnlRunning.Location = new System.Drawing.Point(0, 157);
            this.pnlRunning.Name = "pnlRunning";
            this.pnlRunning.Size = new System.Drawing.Size(371, 70);
            this.pnlRunning.TabIndex = 5;
            this.pnlRunning.Visible = false;
            // 
            // lblRunningStatus
            // 
            this.lblRunningStatus.AutoSize = true;
            this.lblRunningStatus.Location = new System.Drawing.Point(12, 50);
            this.lblRunningStatus.Name = "lblRunningStatus";
            this.lblRunningStatus.Size = new System.Drawing.Size(0, 13);
            this.lblRunningStatus.TabIndex = 1;
            // 
            // prgStatus
            // 
            this.prgStatus.Location = new System.Drawing.Point(12, 24);
            this.prgStatus.Name = "prgStatus";
            this.prgStatus.Size = new System.Drawing.Size(347, 23);
            this.prgStatus.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 385);
            this.Controls.Add(this.pnlRunning);
            this.Controls.Add(this.cmdDown);
            this.Controls.Add(this.cmdUp);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cmdRun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstSteps);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "untitled - MesaSuite Release Utility";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ctxSteps.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlRunning.ResumeLayout(false);
            this.pnlRunning.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView lstSteps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip ctxSteps;
        private System.Windows.Forms.ToolStripMenuItem mnuNewStep;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteSteps;
        private System.Windows.Forms.ToolStripMenuItem mnuProperties;
        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuDefaults;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
        private System.Windows.Forms.Button cmdUp;
        private System.Windows.Forms.Button cmdDown;
        private System.Windows.Forms.Panel pnlRunning;
        private System.Windows.Forms.Label lblRunningStatus;
        private System.Windows.Forms.ProgressBar prgStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
    }
}

