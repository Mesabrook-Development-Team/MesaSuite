using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
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
    public partial class LeaseBidDetail : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }
        public long? LeaseRequestID { get; set; }
        public long? LeaseBidID { get; set; }

        public LeaseBidDetail()
        {
            InitializeComponent();
        }

        private async void LeaseBidDetail_Load(object sender, EventArgs e)
        {
            if (LeaseRequestID == null && LeaseBidID == null)
            {
                this.ShowError("Not enough data was supplied to open this pane.");
                ParentForm.Close();
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"LeaseRequest/Get/{LeaseRequestID}";
                LeaseRequest leaseRequest = await get.GetObject<LeaseRequest>();
                if (leaseRequest == null)
                {
                    ParentForm.Close();
                    return;
                }

                if (leaseRequest.LeaseType == LeaseRequest.LeaseTypes.Locomotive)
                {
                    get.Resource = "Locomotive/GetAll";
                    List<Locomotive> locomotives = await get.GetObject<List<Locomotive>>() ?? new List<Locomotive>();
                    locomotives = locomotives.Where(l => _application.IsCurrentEntity(l.CompanyIDOwner, l.GovernmentIDOwner) && l.CompanyLeasedTo?.CompanyID == null && l.GovernmentLeasedTo?.GovernmentID == null).ToList();

                }
            }
            finally
            {
                loader.Visible = false;
            }
        }
    }
}
