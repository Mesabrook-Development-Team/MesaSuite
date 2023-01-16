using FleetTracking.Interop;
using FleetTracking.Properties;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetTracking
{
    public partial class PrintableReport : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }
        public string ReportResourcePath { get; set; }
        public Dictionary<string, object> DataSources { get; set; }
        public PrintableReport()
        {
            InitializeComponent();
        }


        private void PrintableReport_Load(object sender, EventArgs e)
        {
            reportViewer.Reset();
            reportViewer.LocalReport.ReportEmbeddedResource = ReportResourcePath;
            foreach(KeyValuePair<string, object> dataSource in DataSources)
            {
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource(dataSource.Key, dataSource.Value));
            }
            reportViewer.LocalReport.Refresh();
            reportViewer.RefreshReport();
        }
    }
}
