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
using MesaSuite.Common.Data;

namespace FleetTracking.CarLoading
{
    public partial class LiveLoadClient : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public string LiveLoadCode { get; set; }

        public LiveLoadClient()
        {
            InitializeComponent();
        }

        private void LiveLoadClient_Load(object sender, EventArgs e)
        {
            
        }
    }
}
