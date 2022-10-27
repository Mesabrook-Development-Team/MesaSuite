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
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.Leasing
{
    public partial class SubmitBids : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public SubmitBids()
        {
            InitializeComponent();
        }

        private async void SubmitBids_Load(object sender, EventArgs e)
        {
            tabControl.TabPages.Clear();
            AddLeaseBidTab();

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "LeaseRequest/GetAll";
                List<LeaseRequest> leaseRequests = await get.GetObject<List<LeaseRequest>>() ?? new List<LeaseRequest>();
                foreach (LeaseRequest leaseRequest in leaseRequests.Where(lr => !_application.IsCurrentEntity(lr.CompanyIDRequester, lr.GovernmentIDRequester)))
                {
                    AddLeaseRequestToTree(leaseRequest);
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void AddLeaseRequestToTree(LeaseRequest leaseRequest)
        {
            TreeNode rootNode = new TreeNode($"({leaseRequest.LeaseRequestID}) {leaseRequest.CompanyRequester?.Name}{leaseRequest.GovernmentRequester?.Name}");
            rootNode.Nodes.Add($"Type: {leaseRequest.LeaseType.ToString().ToDisplayName()}");
            rootNode.Nodes.Add($"End Time: {leaseRequest.BidEndTime?.ToString("MM/dd/yyyy HH:mm")}");
            rootNode.Nodes.Add($"Purpose: {(leaseRequest.Purpose.Length > 30 ? leaseRequest.Purpose.Substring(0, 30) : leaseRequest.Purpose)}");
            treLeaseRequests.Nodes.Add(rootNode);
        }

        private void AddLeaseBidTab()
        {
            SubmitBidsDetail detail = new SubmitBidsDetail()
            {
                Application = _application,
                Dock = DockStyle.Fill
            };
            TabPage bidPage = new TabPage("Bid");
            bidPage.Controls.Add(detail);
            tabControl.TabPages.Add(bidPage);
        }
    }
}
