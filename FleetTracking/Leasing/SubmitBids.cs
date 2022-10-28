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

        private LeaseRequest SelectedTreeNodeLeaseRequest
        {
            get
            {
                TreeNode leaseRequestNode = treLeaseRequests.SelectedNode;
                if (leaseRequestNode == null)
                {
                    return null;
                }

                while(leaseRequestNode.Parent != null)
                {
                    leaseRequestNode = leaseRequestNode.Parent;
                }

                return leaseRequestNode.Tag as LeaseRequest;
            }
        }

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
                get.Resource = "LeaseBid/GetAll";
                List<LeaseBid> leaseBids = await get.GetObject<List<LeaseBid>>() ?? new List<LeaseBid>();

                get.Resource = "LeaseRequest/GetAll";
                List<LeaseRequest> leaseRequests = await get.GetObject<List<LeaseRequest>>() ?? new List<LeaseRequest>();
                foreach (LeaseRequest leaseRequest in leaseRequests.Where(lr => !_application.IsCurrentEntity(lr.CompanyIDRequester, lr.GovernmentIDRequester) && !leaseBids.Any(lb => lb.LeaseRequestID == lr.LeaseRequestID)))
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
            rootNode.Tag = leaseRequest;
            treLeaseRequests.Nodes.Add(rootNode);
        }

        private void AddLeaseBidTab()
        {
            SubmitBidsDetail detail = new SubmitBidsDetail()
            {
                Application = _application,
                Dock = DockStyle.Fill
            };
            detail.GetSelectedLocomotivesCallback = GetSelectedLocomotives;
            detail.GetSelectedRailcarsCallback = GetSelectedRailcars;
            TabPage bidPage = new TabPage("Bid");
            bidPage.Controls.Add(detail);
            tabControl.TabPages.Add(bidPage);
        }

        private void RemoveSelectedNode()
        {
            TreeNode nodeToRemove = treLeaseRequests.SelectedNode;
            if (nodeToRemove == null)
            {
                return;
            }

            while(nodeToRemove.Parent != null)
            {
                nodeToRemove = nodeToRemove.Parent;
            }

            treLeaseRequests.Nodes.Remove(nodeToRemove);
        }

        private void cmdAddLeaseRequest_Click(object sender, EventArgs e)
        {
            if (SelectedTreeNodeLeaseRequest == null || tabControl.SelectedTab == null)
            {
                return;
            }

            int currentIndex = treLeaseRequests.SelectedNode.Index;
            SubmitBidsDetail submitBidsDetail = tabControl.SelectedTab.Controls.OfType<SubmitBidsDetail>().First();
            submitBidsDetail.AddLeaseRequest(SelectedTreeNodeLeaseRequest);
            RemoveSelectedNode();

            if (treLeaseRequests.Nodes.Count > 0)
            {
                if (treLeaseRequests.Nodes.Count == currentIndex)
                {
                    treLeaseRequests.SelectedNode = treLeaseRequests.Nodes[treLeaseRequests.Nodes.Count - 1];
                }
                else
                {
                    treLeaseRequests.SelectedNode = treLeaseRequests.Nodes[currentIndex];
                }
            }

            treLeaseRequests.Focus();
        }

        private void cmdRemoveLeaseRequest_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == null)
            {
                return;
            }

            SubmitBidsDetail submitBidsDetail = tabControl.SelectedTab.Controls.OfType<SubmitBidsDetail>().First();
            foreach(LeaseRequest leaseRequest in submitBidsDetail.SelectedLeaseRequests)
            {
                AddLeaseRequestToTree(leaseRequest);
            }

            submitBidsDetail.RemoveSelectedRequests();
        }

        private List<long> GetSelectedLocomotives()
        {
            List<long> locoSelections = new List<long>();
            foreach(TabPage tab in tabControl.TabPages)
            {
                SubmitBidsDetail submitBidsDetailCtrl = tab.Controls.OfType<SubmitBidsDetail>().FirstOrDefault();
                if (submitBidsDetailCtrl == null)
                {
                    continue;
                }

                locoSelections.AddRange(submitBidsDetailCtrl.GetSelectedLocomotiveIDs());
            }

            return locoSelections;
        }

        private List<long> GetSelectedRailcars()
        {
            List<long> railcarSelections = new List<long>();
            foreach (TabPage tab in tabControl.TabPages)
            {
                SubmitBidsDetail submitBidsDetailCtrl = tab.Controls.OfType<SubmitBidsDetail>().FirstOrDefault();
                if (submitBidsDetailCtrl == null)
                {
                    continue;
                }

                railcarSelections.AddRange(submitBidsDetailCtrl.GetSelectedRailcarIDs());
            }

            return railcarSelections;
        }
    }
}
