using CompanyStudio.Extensions;
using CompanyStudio.Models;
using MesaSuite.Common.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyStudio.Purchasing.OpenMaintenance
{
    public partial class frmOpenViewerSubmitter : BaseCompanyStudioContent, ILocationScoped
    {
        public long? PurchaseOrderID { get; set; }
        public Location LocationModel { get; set; }

        public frmOpenViewerSubmitter()
        {
            InitializeComponent();
        }

        private async void frmOpenViewerSubmitter_Load(object sender, EventArgs e)
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                GetData get = new GetData(DataAccess.APIs.CompanyStudio, "PurchaseOrder/Get/" + PurchaseOrderID);
                get.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                PurchaseOrder purchaseOrder = await get.GetObject<PurchaseOrder>() ?? new PurchaseOrder();
                txtFrom.Text = purchaseOrder.DestinationString;
                txtDescription.Text = purchaseOrder.Description;
                txtDate.Text = purchaseOrder.PurchaseOrderDate?.ToString("MM/dd/yyyy");

                foreach(PurchaseOrderLine purchaseOrderLine in purchaseOrder.PurchaseOrderLines ?? new List<PurchaseOrderLine>())
                {
                    AddPurchaseOrderLine(purchaseOrderLine);
                }

                get = new GetData(DataAccess.APIs.CompanyStudio, "FulfillmentPlan/GetByPurchaseOrderID/" + PurchaseOrderID);
                get.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                List<FulfillmentPlan> fulfillmentPlans = await get.GetObject<List<FulfillmentPlan>>() ?? new List<FulfillmentPlan>();
                foreach(FulfillmentPlan fulfillmentPlan in fulfillmentPlans)
                {
                    int rowIndex = dgvFulfillmentPlans.Rows.Add();
                    DataGridViewRow row = dgvFulfillmentPlans.Rows[rowIndex];
                    row.Cells[colFPRailcar.Name].Value = fulfillmentPlan.Railcar?.ReportingID;
                    row.Cells[colFPPOLines.Name].Value = (fulfillmentPlan.FulfillmentPlanPurchaseOrderLines?.Count ?? 0) + " Purchase Order Line(s)";
                    string route = "";
                    FulfillmentPlanRoute firstRoute = fulfillmentPlan.FulfillmentPlanRoutes.FirstOrDefault();
                    if (firstRoute != null)
                    {
                        if (firstRoute.CompanyIDFrom != null)
                        {
                            route = firstRoute.CompanyFrom?.Name + " -> ";
                        }
                        else if (firstRoute.GovernmentIDFrom != null)
                        {
                            route = firstRoute.GovernmentFrom?.Name + " -> ";
                        }
                    }
                    route += string.Join(" -> ", fulfillmentPlan.FulfillmentPlanRoutes.Select(fpr => fpr.CompanyIDTo != null ? fpr.CompanyTo?.Name : fpr.GovernmentTo?.Name));
                    row.Cells[colFPRoute.Name].Value = route;
                    row.Tag = fulfillmentPlan;
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void AddPurchaseOrderLine(PurchaseOrderLine purchaseOrderLine)
        {
            PurchaseOrderLineReadOnly purchaseOrderLineReadOnly = new PurchaseOrderLineReadOnly()
            {
                PurchaseOrderLine = purchaseOrderLine,
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right
            };
            int top = 0;
            if (pnlPOLines.Controls.OfType<PurchaseOrderLineReadOnly>().Any())
            {
                top = pnlPOLines.Controls.OfType<PurchaseOrderLineReadOnly>().Max(c => c.Bottom);
            }
            purchaseOrderLineReadOnly.Top = top;
            purchaseOrderLineReadOnly.OnFulfillmentPlanLinkClicked += PurchaseOrderLineReadOnly_OnFulfillmentPlanLinkClicked;
            pnlPOLines.Controls.Add(purchaseOrderLineReadOnly);
            purchaseOrderLineReadOnly.Width = pnlPOLines.Width;
        }

        private void PurchaseOrderLineReadOnly_OnFulfillmentPlanLinkClicked(object sender, EventArgs e)
        {
            PurchaseOrderLineReadOnly purchaseOrderLineReadOnly = sender as PurchaseOrderLineReadOnly;
            if (purchaseOrderLineReadOnly == null)
            {
                return;
            }

            PurchaseOrderLine purchaseOrderLine = purchaseOrderLineReadOnly.PurchaseOrderLine;
            DataGridViewRow selectedRow = dgvFulfillmentPlans
                                            .Rows
                                            .OfType<DataGridViewRow>()
                                            .Where(row => 
                                                row.Tag is FulfillmentPlan fp &&
                                                fp != null && 
                                                fp.FulfillmentPlanPurchaseOrderLines
                                                    .Any(fppol => 
                                                        fppol.PurchaseOrderLineID == purchaseOrderLine.PurchaseOrderLineID))
                                            .FirstOrDefault();

            if (selectedRow == null)
            {
                return;
            }

            tabControl1.SelectedTab = tabFulfillmentPlans;
            foreach(DataGridViewRow row in dgvFulfillmentPlans.Rows)
            {
                row.Selected = false;
            }

            selectedRow.Selected = true;
        }

        private void dgvFulfillmentPlans_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvFulfillmentPlans.SelectedRows.OfType<DataGridViewRow>().FirstOrDefault();
            if (row == null)
            {
                return;
            }

            FulfillmentPlan fulfillmentPlan = row.Tag as FulfillmentPlan;
            if (fulfillmentPlan == null)
            {
                return;
            }

            lnkFPRailcar.Text = fulfillmentPlan.Railcar?.ReportingID;
            lnkFPRailcar.Tag = fulfillmentPlan.Railcar;
            StringBuilder purchaseOrderLines = new StringBuilder();
            foreach(PurchaseOrderLine purchaseOrderLine in fulfillmentPlan.FulfillmentPlanPurchaseOrderLines.Select(fppol => fppol.PurchaseOrderLine))
            {
                if (purchaseOrderLines.Length > 0)
                {
                    purchaseOrderLines.Append(", ");
                }

                purchaseOrderLines.Append($"{purchaseOrderLine.Quantity}x ");
                if (purchaseOrderLine.IsService)
                {
                    purchaseOrderLines.Append(purchaseOrderLine.ServiceDescription);
                }
                else
                {
                    if (purchaseOrderLine.ItemID != null)
                    {
                        purchaseOrderLines.Append(purchaseOrderLine.Item.Name);
                        if (!string.IsNullOrEmpty(purchaseOrderLine.ItemDescription))
                        {
                            purchaseOrderLines.Append(" - ");
                        }
                    }

                    if (!string.IsNullOrEmpty(purchaseOrderLine.ItemDescription))
                    {
                        purchaseOrderLines.Append(purchaseOrderLine.ItemDescription);
                    }
                }
            }

            txtFPPurchaseOrderLines.Text = purchaseOrderLines.ToString();
            txtFPPickupTrack.Text = fulfillmentPlan.TrackLoading?.Name;
            txtFPStrategicAfterPickup.Text = fulfillmentPlan.TrackStrategicAfterLoad?.Name;
            txtFPDropOffTrack.Text = fulfillmentPlan.TrackDestination?.Name;
            txtFPStrategicAfterDropOff.Text = fulfillmentPlan.TrackStrategicAfterDestination?.Name;
            txtFPDestinationAfterFulfillment.Text = fulfillmentPlan.TrackPostFulfillment?.Name;
            txtFPRailcarRouting.Text = row.Cells[colFPRoute.Name].Value as string;
        }
    }
}
