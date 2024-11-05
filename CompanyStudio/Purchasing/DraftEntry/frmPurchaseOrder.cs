using CompanyStudio.Extensions;
using CompanyStudio.Models;
using CompanyStudio.Purchasing.ApprovalViewer;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyStudio.Purchasing.DraftEntry
{
    public partial class frmPurchaseOrder : BaseCompanyStudioContent, ILocationScoped, ISaveable
    {
        public frmPurchaseOrder()
        {
            InitializeComponent();
        }

        public long? PurchaseOrderID { get; set; }
        private PurchaseOrder.Statuses _currentStatus = PurchaseOrder.Statuses.Draft;
        public Location LocationModel { get; set; }
        private List<long?> _deletedLineIDs = new List<long?>();
        private List<PurchaseOrderLine> _linesAtLoad = new List<PurchaseOrderLine>();

        public event EventHandler OnSave;

        private async void frmPurchaseOrder_Load(object sender, EventArgs e)
        {
            try
            {
                toolStripMain.Enabled = false;
                loader.BringToFront();
                loader.Visible = true;

                Studio.dockPanel.Contents.OfType<frmPurchaseOrderExplorer>().Where(poe => poe.LocationModel.LocationID == LocationModel.LocationID).FirstOrDefault()?.RegisterPurchaseOrderForm(this, () => PurchaseOrderID);

                GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Company/GetAll");
                List<Company> companies = await get.GetObject<List<Company>>() ?? new List<Company>();
                foreach(Company company in companies.OrderBy(c => c.Name))
                {
                    foreach(Location location in company.Locations.OrderBy(l => l.Name))
                    {
                        cboLocation.Items.Add(new DropDownItem<Location>(location, $"{company.Name} ({location.Name})"));
                    }
                }

                get = new GetData(DataAccess.APIs.CompanyStudio, "Government/GetAll");
                get.AddCompanyHeader(Company.CompanyID);
                List<Government> governments = await get.GetObject<List<Government>>() ?? new List<Government>();
                foreach(Government government in governments.OrderBy(g => g.Name))
                {
                    cboGovernment.Items.Add(new DropDownItem<Government>(government, government.Name));
                }

                if (PurchaseOrderID != null)
                {
                    get = new GetData(DataAccess.APIs.CompanyStudio, "PurchaseOrder/Get/" + PurchaseOrderID);
                    get.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                    PurchaseOrder purchaseOrder = await get.GetObject<PurchaseOrder>();

                    rdoLocation.Checked = purchaseOrder?.LocationIDDestination != null;
                    cboLocation.SelectedItem = cboLocation.Items.OfType<DropDownItem<Location>>().FirstOrDefault(item => item.Object.LocationID == purchaseOrder?.LocationIDDestination);
                    rdoGovernment.Checked = purchaseOrder?.GovernmentIDDestination != null;
                    cboGovernment.SelectedItem = cboGovernment.Items.OfType<DropDownItem<Government>>().FirstOrDefault(item => item.Object.GovernmentID == purchaseOrder?.GovernmentIDDestination);
                    txtOrderDate.Text = purchaseOrder?.PurchaseOrderDate?.ToString("MM/dd/yyyy");
                    txtDescription.Text = purchaseOrder?.Description;
                    _currentStatus = purchaseOrder?.Status ?? PurchaseOrder.Statuses.Draft;
                    lblStatus.Text = _currentStatus.ToString().ToDisplayName();
                    lblSaveToAddPlans.Visible = false;
                    toolAddPlan.Visible = true;
                    toolDeletePlan.Visible = true;

                    switch(_currentStatus)
                    {
                        case PurchaseOrder.Statuses.Draft:
                            cmdSubmit.Visible = _currentStatus == PurchaseOrder.Statuses.Draft;
                            break;
                        case PurchaseOrder.Statuses.InProgress:
                        case PurchaseOrder.Statuses.Completed:
                            cboGovernment.Enabled = false;
                            cboLocation.Enabled = false;
                            txtDescription.Enabled = false;
                            cmdSave.Enabled = false;
                            toolLoadTemplate.Enabled = false;
                            toolAddNewLine.Enabled = false;
                            break;
                    }

                    if (purchaseOrder?.PurchaseOrderLines != null)
                    {
                        foreach(PurchaseOrderLine purchaseOrderLine in purchaseOrder.PurchaseOrderLines)
                        {
                            AddPurchaseOrderLineControl(purchaseOrderLine, purchaseOrder.Status == PurchaseOrder.Statuses.InProgress || purchaseOrder.Status == PurchaseOrder.Statuses.Completed);
                        }

                        _linesAtLoad = purchaseOrder.PurchaseOrderLines;
                    }

                    await RefreshFulfillmentPlans();
                }
                else
                {
                    _currentStatus = PurchaseOrder.Statuses.Draft;
                    lblStatus.Text = PurchaseOrder.Statuses.Draft.ToString().ToLowerInvariant();
                    cmdSubmit.Visible = true;
                }
            }
            finally
            {
                toolStripMain.Enabled = true;
                loader.Visible = false;
            }
        }

        private void toolAddNewLine_Click(object sender, EventArgs e)
        {
            AddPurchaseOrderLineControl();
        }

        private void AddPurchaseOrderLineControl(PurchaseOrderLine purchaseOrderLine = null, bool disabled = false)
        {
            lblLinePlaceholder.Visible = false;

            int lowestHeight = 0;

            if (pnlPurchaseOrderLines.Controls.OfType<PurchaseOrderLineControl>().Any())
            {
                lowestHeight = pnlPurchaseOrderLines.Controls.OfType<PurchaseOrderLineControl>().Max(ctrl => ctrl.Bottom);
            }

            PurchaseOrderLineControl purchaseOrderLineControl = new PurchaseOrderLineControl();
            purchaseOrderLineControl.CompanyID = Company.CompanyID;
            purchaseOrderLineControl.LocationIDOrigin = LocationModel.LocationID;
            purchaseOrderLineControl.LocationIDDestination = rdoLocation.Checked ? (cboLocation.SelectedItem as DropDownItem<Location>)?.Object.LocationID : null;
            purchaseOrderLineControl.PurchaseOrderLine = purchaseOrderLine;
            purchaseOrderLineControl.PurchaseOrderID = PurchaseOrderID;
            purchaseOrderLineControl.Location = new Point(3, lowestHeight + 3);
            purchaseOrderLineControl.Width = pnlPurchaseOrderLines.Width - 6;
            purchaseOrderLineControl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            purchaseOrderLineControl.BorderStyle = BorderStyle.FixedSingle;
            purchaseOrderLineControl.Enabled = !disabled;
            purchaseOrderLineControl.DeleteClicked += (_, __) =>
            {
                if (purchaseOrderLineControl.PurchaseOrderLine != null)
                {
                    _deletedLineIDs.Add(purchaseOrderLineControl.PurchaseOrderLine.PurchaseOrderLineID);
                }

                int currentBottom = purchaseOrderLineControl.Top - 3;
                pnlPurchaseOrderLines.Controls.Remove(purchaseOrderLineControl);
                foreach (PurchaseOrderLineControl ctrl in pnlPurchaseOrderLines.Controls.OfType<PurchaseOrderLineControl>().Where(ctrl => ctrl.Top > currentBottom).OrderBy(ctrl => ctrl.Top))
                {
                    ctrl.Top = currentBottom + 3;
                    currentBottom = ctrl.Bottom;
                }

                if (!pnlPurchaseOrderLines.Controls.OfType<PurchaseOrderLineControl>().Any())
                {
                    lblLinePlaceholder.Visible = true;
                }
            };
            pnlPurchaseOrderLines.Controls.Add(purchaseOrderLineControl);
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            await Save();
        }

        private void OrderFromCheckedChanged(object sender, EventArgs e)
        {
            cboLocation.Enabled = rdoLocation.Checked;
            cboGovernment.Enabled = rdoGovernment.Checked;

            foreach(PurchaseOrderLineControl ctrl in pnlPurchaseOrderLines.Controls.OfType<PurchaseOrderLineControl>())
            {
                ctrl.LocationIDDestination = cboLocation.Enabled ? (cboLocation.SelectedItem as DropDownItem<Location>)?.Object.LocationID : null;
            }
        }

        private async void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (!await InternalSave())
            {
                return;
            }

            try
            {
                toolStripMain.Enabled = false;
                loader.BringToFront();
                loader.Visible = true;

                PostData post = new PostData(DataAccess.APIs.CompanyStudio, "PurchaseOrder/Submit/" + PurchaseOrderID, new object());
                post.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                PurchaseOrder purchaseOrder = await post.Execute<PurchaseOrder>();
                if (post.RequestSuccessful)
                {
                    StringBuilder linesWithDiscrepantPrices = new StringBuilder();
                    foreach(PurchaseOrderLine line in purchaseOrder.PurchaseOrderLines ?? new List<PurchaseOrderLine>())
                    {
                        PurchaseOrderLineControl polc = pnlPurchaseOrderLines.Controls.OfType<PurchaseOrderLineControl>().FirstOrDefault(ctrl => ctrl.PurchaseOrderLine?.PurchaseOrderLineID == line.PurchaseOrderLineID);
                        if (line.UnitCost != polc.GetCurrentUnitCost())
                        {
                            linesWithDiscrepantPrices.AppendLine($"* {line.Quantity}x {line.Item?.Name} (was {polc.GetCurrentUnitCost().Value.ToString("N2")} each, now {line.UnitCost.Value.ToString("N2")} each)");
                        }
                    }

                    if (linesWithDiscrepantPrices.Length > 0)
                    {
                        this.ShowWarning("The following prices were updated following submission:\r\n\r\n" + linesWithDiscrepantPrices.ToString());
                    }

                    // Open up approval form
                    frmApprovalViewerSubmitter approvalViewer = new frmApprovalViewerSubmitter()
                    {
                        PurchaseOrderID = PurchaseOrderID
                    };
                    Studio.DecorateStudioContent(approvalViewer);
                    approvalViewer.Company = Company;
                    approvalViewer.LocationModel = LocationModel;
                    approvalViewer.Show(Studio.dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                    Close();
                }

            }
            finally
            {
                loader.Visible = false;
                toolStripMain.Enabled = true;
            }
        }

        public async Task Save()
        {
            await InternalSave();
        }

        public async Task<bool> InternalSave()
        {
            if (!this.AreFieldsPresent(new List<(string, Control)>()
            {
                ("Description", txtDescription)
            }))
            {
                return false;
            }

            if (rdoLocation.Checked && cboLocation.SelectedItem == null)
            {
                this.ShowError("Location is a required field");
            }
            if (rdoGovernment.Checked && cboGovernment.SelectedItem == null)
            {
                this.ShowError("Government is a required field");
            }

            PurchaseOrderLineControl[] purchaseOrderLines = pnlPurchaseOrderLines.Controls.OfType<PurchaseOrderLineControl>().ToArray();
            StringBuilder lineErrors = new StringBuilder();
            for (int i = 0; i < purchaseOrderLines.Length; i++)
            {
                foreach (string error in purchaseOrderLines[i].ValidatePresence())
                {
                    lineErrors.AppendLine($"Purchase Order Line {i + 1}: {error}");
                }
            }

            if (lineErrors.Length > 0)
            {
                this.ShowError("The following errors occurred with Purchase Order Lines:\r\n" + lineErrors.ToString());
                return false;
            }

            try
            {
                toolStripMain.Enabled = false;

                loader.BringToFront();
                loader.Visible = true;

                PurchaseOrder purchaseOrderToSave = new PurchaseOrder()
                {
                    PurchaseOrderID = PurchaseOrderID,
                    LocationIDOrigin = LocationModel.LocationID,
                    LocationIDDestination = rdoLocation.Checked ? ((DropDownItem<Location>)cboLocation.SelectedItem).Object.LocationID : null,
                    GovernmentIDDestination = rdoGovernment.Checked ? ((DropDownItem<Government>)cboGovernment.SelectedItem).Object.GovernmentID : null,
                    Description = txtDescription.Text
                };

                if (PurchaseOrderID == null)
                {
                    PostData post = new PostData(DataAccess.APIs.CompanyStudio, "PurchaseOrder/Post", purchaseOrderToSave);
                    post.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                    purchaseOrderToSave = await post.Execute<PurchaseOrder>();
                    if (post.RequestSuccessful)
                    {
                        PurchaseOrderID = purchaseOrderToSave.PurchaseOrderID;
                        foreach (PurchaseOrderLineControl line in purchaseOrderLines)
                        {
                            line.PurchaseOrderID = PurchaseOrderID;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    PutData put = new PutData(DataAccess.APIs.CompanyStudio, "PurchaseOrder/Put", purchaseOrderToSave);
                    put.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                    await put.ExecuteNoResult();
                    if (!put.RequestSuccessful)
                    {
                        return false;
                    }
                }

                lblSaveToAddPlans.Visible = false;
                toolAddPlan.Visible = true;
                toolDeletePlan.Visible = true;

                lineErrors = new StringBuilder();
                for (int i = 0; i < purchaseOrderLines.Length; i++)
                {
                    PurchaseOrderLineControl line = purchaseOrderLines[i];
                    string lineError;
                    if (!string.IsNullOrEmpty(lineError = await line.PerformSave()))
                    {
                        lineErrors.AppendLine($"Purchase Order Line {i + 1}: {lineError}");
                    }
                }

                foreach (long? deletedLineID in _deletedLineIDs)
                {
                    DeleteData delete = new DeleteData(DataAccess.APIs.CompanyStudio, "PurchaseOrderLine/Delete/" + deletedLineID);
                    delete.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                    delete.SuppressErrors = true;
                    await delete.Execute();
                    if (!delete.RequestSuccessful)
                    {
                        lineErrors.AppendLine("Deleted Purchase Order Line: " + delete.LastError);
                    }
                }

                _deletedLineIDs.Clear();

                if (lineErrors.Length > 0)
                {
                    this.ShowError("These Purchase Order Lines encountered errors and were not saved::\r\n" + lineErrors.ToString() +
                        "\r\n\r\nCorrect these errors and try saving again.");
                    return false;
                }

                GetData get = new GetData(DataAccess.APIs.CompanyStudio, "PurchaseOrderLine/GetByPurchaseOrderID/" + PurchaseOrderID);
                get.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                _linesAtLoad = await get.GetObject<List<PurchaseOrderLine>>() ?? new List<PurchaseOrderLine>();

                OnSave?.Invoke(this, EventArgs.Empty);

                await RefreshFulfillmentPlans();

                return true;
            }
            finally
            {
                toolStripMain.Enabled = true;
                loader.Visible = false;
            }
        }

        bool isLoadingFulfillmentPlans = false;
        private async Task RefreshFulfillmentPlans()
        {
            long? previouslySelectedPlanID = null;
            if (dgvFulfillmentPlans.SelectedRows.Count > 0)
            {
                previouslySelectedPlanID = dgvFulfillmentPlans.SelectedRows[0].Tag as long?;
            }

            dgvFulfillmentPlans.Rows.Clear();

            GetData get = new GetData(DataAccess.APIs.CompanyStudio, "FulfillmentPlan/GetByPurchaseOrderID/" + PurchaseOrderID);
            get.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
            List<FulfillmentPlan> plans = await get.GetObject<List<FulfillmentPlan>>() ?? new List<FulfillmentPlan>();

            HashSet<long?> _purchaseOrderLineIDsOnFulfillmentPlans = new HashSet<long?>();
            try
            {
                isLoadingFulfillmentPlans = true;
                foreach (FulfillmentPlan plan in plans)
                {
                    int rowIndex = dgvFulfillmentPlans.Rows.Add();
                    DataGridViewRow row = dgvFulfillmentPlans.Rows[rowIndex];
                    row.Cells[colRailcar.Name].Value = plan.RailcarID != null ?
                                                        plan.Railcar?.ReportingMark + plan.Railcar?.ReportingNumber :
                                                        plan.LeaseRequestID != null ?
                                                            $"Lease Request ID: {plan.LeaseRequestID} (Bids: {plan.LeaseRequest?.LeaseBids?.Count() ?? 0})" :
                                                            "None";
                    row.Cells[colFPPOLines.Name].Value = (plan.FulfillmentPlanPurchaseOrderLines?.Count ?? 0) + " Lines";
                    StringBuilder routeStringBuilder = new StringBuilder();
                    if (!plan.FulfillmentPlanRoutes.Any())
                    {
                        routeStringBuilder.Append("None");
                    }
                    else
                    {
                        FulfillmentPlanRoute firstRoute = plan.FulfillmentPlanRoutes.FirstOrDefault();
                        routeStringBuilder.Append(firstRoute.CompanyFrom?.Name ?? firstRoute.GovernmentFrom?.Name);

                        foreach (FulfillmentPlanRoute route in plan.FulfillmentPlanRoutes)
                        {
                            routeStringBuilder.Append($" -> {route.CompanyTo?.Name ?? route.GovernmentTo?.Name}");
                        }
                    }
                    row.Cells[colRoute.Name].Value = routeStringBuilder.ToString();

                    row.Tag = plan.FulfillmentPlanID;

                    _purchaseOrderLineIDsOnFulfillmentPlans.AddRange(plan.FulfillmentPlanPurchaseOrderLines.Select(fppol => fppol.PurchaseOrderLineID));
                }
            }
            finally
            {
                isLoadingFulfillmentPlans = false;
            }

            if (previouslySelectedPlanID != null)
            {
                foreach(DataGridViewRow row in dgvFulfillmentPlans.Rows)
                {
                    row.Selected = row.Tag as long? == previouslySelectedPlanID;
                }
            }

            if (dgvFulfillmentPlans.SelectedRows.Count > 0)
            {
                dgvFulfillmentPlans_SelectionChanged(this, EventArgs.Empty);
            }

            foreach (PurchaseOrderLineControl line in pnlPurchaseOrderLines.Controls.OfType<PurchaseOrderLineControl>())
            {
                line.SetHasFulfillmentPlan(_purchaseOrderLineIDsOnFulfillmentPlans.Contains(line.PurchaseOrderLine?.PurchaseOrderLineID));
            }
        }

        private void toolAddPlan_Click(object sender, EventArgs e)
        {
            AddFulfillmentPlanControl();
        }

        private void AddFulfillmentPlanControl(long? fulfillmentPlanID = null)
        {
            grpFulfillmentPlanInformation.Controls.OfType<FulfillmentPlanControl>().ToList().ForEach(fpc => grpFulfillmentPlanInformation.Controls.Remove(fpc));
            lblPlanPlaceholder.Visible = false;

            FulfillmentPlanControl control = new FulfillmentPlanControl()
            {
                FulfillmentPlanID = fulfillmentPlanID,
                CompanyID = Company.CompanyID,
                LocationID = LocationModel.LocationID,
                Dock = DockStyle.Fill,
                StartIDGovernment = (cboGovernment.SelectedItem as DropDownItem<Government>)?.Object.GovernmentID,
                StartIDCompany = (cboLocation.SelectedItem as DropDownItem<Location>)?.Object.CompanyID,
                StartIDLocation = (cboLocation.SelectedItem as DropDownItem<Location>)?.Object.LocationID,
                StartName = rdoLocation.Checked ? (cboLocation.SelectedItem as DropDownItem<Location>)?.Text : rdoGovernment.Checked ? (cboGovernment.SelectedItem as DropDownItem<Government>)?.Text : null,
                EndIDLocation = LocationModel.LocationID,
                EndName = $"{Company.Name} ({LocationModel.Name})",
                Studio = Studio
            };
            control.OnSave += FulfillmentPlanControl_OnSave;
            grpFulfillmentPlanInformation.Controls.Add(control);

            control.SetPurchaseOrderLines(_linesAtLoad);
        }

        private async void FulfillmentPlanControl_OnSave(object sender, EventArgs e)
        {
            await RefreshFulfillmentPlans();
        }

        private void dgvFulfillmentPlans_SelectionChanged(object sender, EventArgs e)
        {
            if (isLoadingFulfillmentPlans)
            {
                return;
            }

            DataGridViewRow row = dgvFulfillmentPlans.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (row != null)
            {
                AddFulfillmentPlanControl(row.Tag as long?);
            }
        }

        private void cboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(PurchaseOrderLineControl ctrl in pnlPurchaseOrderLines.Controls.OfType<PurchaseOrderLineControl>())
            {
                ctrl.LocationIDDestination = (cboLocation.SelectedItem as DropDownItem<Location>)?.Object.LocationID;
            }
        }
    }
}
