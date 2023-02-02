namespace FleetTracking.Leasing
{
    partial class Overview
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chrtRailcarsAvailable = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chrtLocomotivesAvailable = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.loader = new FleetTracking.Loader();
            this.chrtLeaseRequests = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtRailcarsAvailable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtLocomotivesAvailable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtLeaseRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.chrtRailcarsAvailable);
            this.flowLayoutPanel1.Controls.Add(this.chrtLocomotivesAvailable);
            this.flowLayoutPanel1.Controls.Add(this.chrtLeaseRequests);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(721, 369);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // chrtRailcarsAvailable
            // 
            this.chrtRailcarsAvailable.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chrtRailcarsAvailable.ChartAreas.Add(chartArea1);
            this.chrtRailcarsAvailable.Location = new System.Drawing.Point(3, 3);
            this.chrtRailcarsAvailable.Name = "chrtRailcarsAvailable";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.IsValueShownAsLabel = true;
            series1.Name = "Series1";
            this.chrtRailcarsAvailable.Series.Add(series1);
            this.chrtRailcarsAvailable.Size = new System.Drawing.Size(186, 192);
            this.chrtRailcarsAvailable.TabIndex = 0;
            this.chrtRailcarsAvailable.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Railcars Available";
            title1.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Emboss;
            this.chrtRailcarsAvailable.Titles.Add(title1);
            // 
            // chrtLocomotivesAvailable
            // 
            this.chrtLocomotivesAvailable.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chrtLocomotivesAvailable.ChartAreas.Add(chartArea2);
            this.chrtLocomotivesAvailable.Location = new System.Drawing.Point(195, 3);
            this.chrtLocomotivesAvailable.Name = "chrtLocomotivesAvailable";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.IsValueShownAsLabel = true;
            series2.Name = "Series1";
            this.chrtLocomotivesAvailable.Series.Add(series2);
            this.chrtLocomotivesAvailable.Size = new System.Drawing.Size(186, 192);
            this.chrtLocomotivesAvailable.TabIndex = 0;
            this.chrtLocomotivesAvailable.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Locomotives Available";
            title2.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Emboss;
            this.chrtLocomotivesAvailable.Titles.Add(title2);
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(721, 369);
            this.loader.TabIndex = 1;
            this.loader.Visible = false;
            // 
            // chrtLeaseRequests
            // 
            this.chrtLeaseRequests.BackColor = System.Drawing.Color.Transparent;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.chrtLeaseRequests.ChartAreas.Add(chartArea3);
            this.chrtLeaseRequests.Location = new System.Drawing.Point(387, 3);
            this.chrtLeaseRequests.Name = "chrtLeaseRequests";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.IsValueShownAsLabel = true;
            series3.Name = "Series1";
            this.chrtLeaseRequests.Series.Add(series3);
            this.chrtLeaseRequests.Size = new System.Drawing.Size(186, 192);
            this.chrtLeaseRequests.TabIndex = 0;
            this.chrtLeaseRequests.Text = "chart1";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Title1";
            title3.Text = "Lease Requests";
            title3.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Emboss;
            this.chrtLeaseRequests.Titles.Add(title3);
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.loader);
            this.Name = "Overview";
            this.Size = new System.Drawing.Size(721, 369);
            this.Load += new System.EventHandler(this.Overview_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chrtRailcarsAvailable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtLocomotivesAvailable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtLeaseRequests)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtRailcarsAvailable;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtLocomotivesAvailable;
        private Loader loader;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtLeaseRequests;
    }
}
