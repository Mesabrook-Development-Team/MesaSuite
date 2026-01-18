using CompanyStudio.Extensions;
using CompanyStudio.Models;
using MesaSuite.Common.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyStudio.Purchasing.DraftEntry
{
    public partial class frmSelectFulfillmentPlan : BaseCompanyStudioContent, ILocationScoped
    {
        public long PurchaseOrderID { get; set; }
        public long PurchaseOrderLineID { get; set; }

        public frmSelectFulfillmentPlan()
        {
            InitializeComponent();
        }

        public Location LocationModel { get; set; }

        private async void frmSelectFulfillmentPlan_Load(object sender, EventArgs e)
        {
            using (CreateLoadVisualHandler())
            {
                GetData get = new GetData(DataAccess.APIs.CompanyStudio, $"FulfillmentPlan/GetByPurchaseOrderID/{PurchaseOrderID}");
                get.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                List<FulfillmentPlan> plans = await get.GetObject<List<FulfillmentPlan>>() ?? new List<FulfillmentPlan>();

                foreach(FulfillmentPlan plan in plans)
                {
                    DataGridViewRow row = dgvFulfillmentPlans.Rows[dgvFulfillmentPlans.Rows.Add()];
                    string railcar = "[None]";
                    if (plan.Railcar?.RailcarID != null)
                    {
                        railcar = plan.Railcar.ReportingID ?? "[None]";
                    }

                    string route = plan.RouteInformation;

                    row.Cells[colRailcar.Name].Value = railcar;
                    row.Cells[colRoute.Name].Value = route;

                    if (plan.FulfillmentPlanPurchaseOrderLines != null && plan.FulfillmentPlanPurchaseOrderLines.Any(fppol => fppol.PurchaseOrderLineID == PurchaseOrderLineID))
                    {
                        row.Cells[colSelect.Name].Value = true;
                    }

                    row.Tag = plan.FulfillmentPlanID.Value;
                }
            }
        }

        private LoadVisualHandler CreateLoadVisualHandler()
        {
            return new LoadVisualHandler(loader, cmdSave, cmdCancel, groupBox1);
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            using (CreateLoadVisualHandler())
            {
                HashSet<long> selectedFulfillmentPlanIDs = new HashSet<long>();
                foreach (DataGridViewRow row in dgvFulfillmentPlans.Rows)
                {
                    bool isSelected = (bool)row.Cells[colSelect.Name].Value;
                    if (isSelected)
                    {
                        long fulfillmentPlanID = (long)row.Tag;
                        selectedFulfillmentPlanIDs.Add(fulfillmentPlanID);
                    }
                }

                GetData get = new GetData(DataAccess.APIs.CompanyStudio, $"FulfillmentPlan/GetByPurchaseOrderID/{PurchaseOrderID}");
                get.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                List<FulfillmentPlan> plansInDatabase = await get.GetObject<List<FulfillmentPlan>>() ?? new List<FulfillmentPlan>();
                HashSet<long> existingPlanIDs = plansInDatabase
                    .Where(fp => fp.FulfillmentPlanPurchaseOrderLines
                        .Any(fppol => fppol.PurchaseOrderLineID == PurchaseOrderLineID))
                    .Select(fp => fp.FulfillmentPlanID.Value).ToHashSet();

                bool anyFailed = false;
                foreach(long addedID in selectedFulfillmentPlanIDs.Except(existingPlanIDs))
                {
                    FulfillmentPlanPurchaseOrderLine newJoin = new FulfillmentPlanPurchaseOrderLine()
                    {
                        FulfillmentPlanID = addedID,
                        PurchaseOrderLineID = PurchaseOrderLineID
                    };

                    PostData post = new PostData(DataAccess.APIs.CompanyStudio, "FulfillmentPlanPurchaseOrderLine/Post", newJoin);
                    post.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                    await post.ExecuteNoResult();

                    anyFailed |= !post.RequestSuccessful;
                }

                foreach(long deletedID in existingPlanIDs.Except(selectedFulfillmentPlanIDs))
                {
                    FulfillmentPlanPurchaseOrderLine existingFPPOL = plansInDatabase
                        .Single(fp => fp.FulfillmentPlanID == deletedID)
                        .FulfillmentPlanPurchaseOrderLines
                        .FirstOrDefault(fppol => fppol.PurchaseOrderLineID == PurchaseOrderLineID);

                    DeleteData delete = new DeleteData(DataAccess.APIs.CompanyStudio, $"FulfillmentPlanPurchaseOrderLine/Delete/{existingFPPOL.FulfillmentPlanPurchaseOrderLineID}");
                    delete.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                    await delete.Execute();

                    anyFailed |= !delete.RequestSuccessful;
                }

                if (anyFailed)
                {
                    MessageBox.Show("Not all updates were committed. Please review your Fulfillment Plans to see what was successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void toolCheckAll_Click(object sender, EventArgs e)
        {
            SetCheckedState(true);
        }

        private void SetCheckedState(bool v)
        {
            foreach(DataGridViewRow row in dgvFulfillmentPlans.Rows)
            {
                row.Cells[colSelect.Name].Value = v;
            }
        }

        private void toolUncheckAll_Click(object sender, EventArgs e)
        {
            SetCheckedState(false);
        }
    }
}
