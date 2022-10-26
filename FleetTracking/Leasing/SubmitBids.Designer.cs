namespace FleetTracking.Leasing
{
    partial class SubmitBids
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
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Type: Railcar");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("End Time: 10/28/2022 17:00");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Purpose: Complete PO blah blah blah");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("(1) Iron River Power", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Type: Railcar");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("End Time: 10/28/2022 17:00");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Purpose: Complete PO blah blah blah");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("(3) Iron River Power", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(824, 343);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode9.Name = "Node1";
            treeNode9.Text = "Type: Railcar";
            treeNode10.Name = "Node3";
            treeNode10.Text = "End Time: 10/28/2022 17:00";
            treeNode11.Name = "Node4";
            treeNode11.Text = "Purpose: Complete PO blah blah blah";
            treeNode12.Name = "Node0";
            treeNode12.Text = "(1) Iron River Power";
            treeNode13.Name = "Node6";
            treeNode13.Text = "Type: Railcar";
            treeNode14.Name = "Node7";
            treeNode14.Text = "End Time: 10/28/2022 17:00";
            treeNode15.Name = "Node8";
            treeNode15.Text = "Purpose: Complete PO blah blah blah";
            treeNode16.Name = "Node5";
            treeNode16.Text = "(3) Iron River Power";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode16});
            this.treeView1.Size = new System.Drawing.Size(162, 343);
            this.treeView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SubmitBids
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SubmitBids";
            this.Size = new System.Drawing.Size(824, 343);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
    }
}
