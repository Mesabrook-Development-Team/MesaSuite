namespace FleetTracking
{
    partial class PrintableReport
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
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmdNetworkPrint = new System.Windows.Forms.Button();
            this.loader = new FleetTracking.Loader();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(825, 500);
            this.reportViewer.TabIndex = 0;
            // 
            // cmdNetworkPrint
            // 
            this.cmdNetworkPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNetworkPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNetworkPrint.Location = new System.Drawing.Point(736, 3);
            this.cmdNetworkPrint.Name = "cmdNetworkPrint";
            this.cmdNetworkPrint.Size = new System.Drawing.Size(89, 23);
            this.cmdNetworkPrint.TabIndex = 1;
            this.cmdNetworkPrint.Text = "Network Print";
            this.cmdNetworkPrint.UseVisualStyleBackColor = true;
            this.cmdNetworkPrint.Visible = false;
            this.cmdNetworkPrint.Click += new System.EventHandler(this.cmdNetworkPrint_Click);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(825, 500);
            this.loader.TabIndex = 2;
            this.loader.Visible = false;
            // 
            // PrintableReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdNetworkPrint);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.loader);
            this.Name = "PrintableReport";
            this.Size = new System.Drawing.Size(825, 500);
            this.Load += new System.EventHandler(this.PrintableReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Button cmdNetworkPrint;
        private Loader loader;
    }
}
