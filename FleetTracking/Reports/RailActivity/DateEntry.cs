using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Interop;

namespace FleetTracking.Reports.RailActivity
{
    public partial class DateEntry : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public DateEntry()
        {
            InitializeComponent();
        }

        private void cmdRun_Click(object sender, EventArgs e)
        {
            PrintableReport printableReport = new PrintableReport()
            {
                Application = _application,
                ReportContext = new RailActivityReportContext(dtpStart.Value, dtpEnd.Value) { Application = _application },
            };
            _application.OpenForm(printableReport);
            ParentForm.Close();
            Dispose();
        }

        private void DateEntry_Load(object sender, EventArgs e)
        {
            ParentForm.Text = "Rail Activity Date Parameters";
        }
    }
}
