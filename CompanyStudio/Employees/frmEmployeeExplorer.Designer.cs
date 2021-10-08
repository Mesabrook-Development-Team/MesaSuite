namespace CompanyStudio.Employees
{
    partial class frmEmployeeExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeExplorer));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.mnuAddEmployee = new System.Windows.Forms.ToolStripButton();
            this.mnuRemoveEmployee = new System.Windows.Forms.ToolStripButton();
            this.treEmployees = new System.Windows.Forms.TreeView();
            this.loader = new CompanyStudio.Loader();
            this.toolStripExtender = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.ctxPermission = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuTogglePermission = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxEmployee = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxDeleteEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxAddEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.ctxPermission.SuspendLayout();
            this.ctxEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddEmployee,
            this.mnuRemoveEmployee});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(366, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // mnuAddEmployee
            // 
            this.mnuAddEmployee.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddEmployee.Image")));
            this.mnuAddEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAddEmployee.Name = "mnuAddEmployee";
            this.mnuAddEmployee.Size = new System.Drawing.Size(104, 22);
            this.mnuAddEmployee.Text = "Add Employee";
            this.mnuAddEmployee.Click += new System.EventHandler(this.mnuAddEmployee_Click);
            // 
            // mnuRemoveEmployee
            // 
            this.mnuRemoveEmployee.Enabled = false;
            this.mnuRemoveEmployee.Image = ((System.Drawing.Image)(resources.GetObject("mnuRemoveEmployee.Image")));
            this.mnuRemoveEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRemoveEmployee.Name = "mnuRemoveEmployee";
            this.mnuRemoveEmployee.Size = new System.Drawing.Size(125, 22);
            this.mnuRemoveEmployee.Text = "Remove Employee";
            this.mnuRemoveEmployee.Click += new System.EventHandler(this.mnuRemoveEmployee_Click);
            // 
            // treEmployees
            // 
            this.treEmployees.ContextMenuStrip = this.ctxEmployee;
            this.treEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treEmployees.Location = new System.Drawing.Point(0, 25);
            this.treEmployees.Name = "treEmployees";
            this.treEmployees.Size = new System.Drawing.Size(366, 348);
            this.treEmployees.TabIndex = 1;
            this.treEmployees.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treEmployees_AfterSelect);
            this.treEmployees.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treEmployees_NodeMouseDoubleClick);
            // 
            // loader
            // 
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(366, 373);
            this.loader.TabIndex = 2;
            // 
            // toolStripExtender
            // 
            this.toolStripExtender.DefaultRenderer = null;
            // 
            // ctxPermission
            // 
            this.ctxPermission.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTogglePermission});
            this.ctxPermission.Name = "ctxPermission";
            this.ctxPermission.Size = new System.Drawing.Size(110, 26);
            // 
            // mnuTogglePermission
            // 
            this.mnuTogglePermission.Name = "mnuTogglePermission";
            this.mnuTogglePermission.Size = new System.Drawing.Size(109, 22);
            this.mnuTogglePermission.Text = "Toggle";
            this.mnuTogglePermission.Click += new System.EventHandler(this.mnuTogglePermission_Click);
            // 
            // ctxEmployee
            // 
            this.ctxEmployee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxAddEmployee,
            this.ctxDeleteEmployee});
            this.ctxEmployee.Name = "ctxEmployee";
            this.ctxEmployee.Size = new System.Drawing.Size(181, 70);
            this.ctxEmployee.Text = "Delete";
            this.ctxEmployee.Opening += new System.ComponentModel.CancelEventHandler(this.ctxEmployee_Opening);
            // 
            // ctxDeleteEmployee
            // 
            this.ctxDeleteEmployee.Name = "ctxDeleteEmployee";
            this.ctxDeleteEmployee.Size = new System.Drawing.Size(180, 22);
            this.ctxDeleteEmployee.Text = "Remove Employee";
            this.ctxDeleteEmployee.Click += new System.EventHandler(this.ctxDeleteEmployee_Click);
            // 
            // ctxAddEmployee
            // 
            this.ctxAddEmployee.Name = "ctxAddEmployee";
            this.ctxAddEmployee.Size = new System.Drawing.Size(180, 22);
            this.ctxAddEmployee.Text = "Add Employee";
            this.ctxAddEmployee.Click += new System.EventHandler(this.ctxAddEmployee_Click);
            // 
            // frmEmployeeExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 373);
            this.Controls.Add(this.treEmployees);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.loader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmployeeExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Explorer";
            this.Load += new System.EventHandler(this.frmEmployeeExplorer_Load);
            this.Shown += new System.EventHandler(this.frmEmployeeExplorer_Shown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ctxPermission.ResumeLayout(false);
            this.ctxEmployee.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton mnuAddEmployee;
        private System.Windows.Forms.ToolStripButton mnuRemoveEmployee;
        private System.Windows.Forms.TreeView treEmployees;
        private Loader loader;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender toolStripExtender;
        private System.Windows.Forms.ContextMenuStrip ctxPermission;
        private System.Windows.Forms.ToolStripMenuItem mnuTogglePermission;
        private System.Windows.Forms.ContextMenuStrip ctxEmployee;
        private System.Windows.Forms.ToolStripMenuItem ctxAddEmployee;
        private System.Windows.Forms.ToolStripMenuItem ctxDeleteEmployee;
    }
}