using FleetTracking.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetTracking.Leasing
{
    public partial class LeaseRequestDetail : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public long? LeaseRequestID { get; set; }

        public LeaseRequestDetail()
        {
            InitializeComponent();
        }

        private void LeaseRequestDetail_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async Task LoadData()
        {

        }
    }
}
