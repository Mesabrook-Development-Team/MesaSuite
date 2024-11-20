using CompanyStudio.Extensions;
using CompanyStudio.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CompanyStudio.Purchasing
{
    public partial class frmPurchaseOrderExplorer : BaseCompanyStudioContent, ILocationScoped
    {
        private const string INCOMING_NODE_COMPANY_FORMAT = "From {0} ({1}) - PO {2} - Ordered on {3}";
        private const string INCOMING_NODE_GOV_FORMAT = "From {0} - PO {1} - Ordered on {2}";
        private const string OUTGOING_NODE_COMPANY_FORMAT = "To {0} ({1}) - PO {2} - Ordered on {3}";
        private const string OUTGOING_NODE_GOV_FORMAT = "To {0} - PO {1} - Ordered on {2}";

        private event EventHandler<long?> OnInternalDelete;

        public frmPurchaseOrderExplorer()
        {
            InitializeComponent();
        }

        public Location LocationModel { get; set; }

        private async void frmPurchaseOrderExplorer_Load(object sender, EventArgs e)
        {
            await ReloadTree();
        }

        private async Task ReloadTree(long? selectedPurchaseOrderID = null)
        {
            try
            {
                trePurchaseOrders.Enabled = false;
                toolStrip1.Enabled = false;
                loader.BringToFront();
                loader.Visible = true;

                trePurchaseOrders.Nodes.Clear();

                TreeNode selectedNode = null;
                GetData get = new GetData(DataAccess.APIs.CompanyStudio, "PurchaseOrder/GetAllRelatedToLocation");
                get.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                List<PurchaseOrder> purchaseOrders = await get.GetObject<List<PurchaseOrder>>() ?? new List<PurchaseOrder>();

                Dictionary<PurchaseOrder.Statuses, TreeNode> receivedNodes = new Dictionary<PurchaseOrder.Statuses, TreeNode>();
                Dictionary<PurchaseOrder.Statuses, TreeNode> issuedNodes = new Dictionary<PurchaseOrder.Statuses, TreeNode>();

                foreach (PurchaseOrder.Statuses status in Enum.GetValues(typeof(PurchaseOrder.Statuses)))
                {
                    if (PurchaseOrder.RECEIVED_STATUSES.Contains(status))
                    {
                        receivedNodes.Add(status, new TreeNode(status.ToString().ToDisplayName(), imageList.Images.IndexOfKey(status.ToString().ToLowerInvariant()), imageList.Images.IndexOfKey(status.ToString().ToLowerInvariant())));
                    }

                    issuedNodes.Add(status, new TreeNode(status.ToString().ToDisplayName(), imageList.Images.IndexOfKey(status.ToString().ToLowerInvariant()), imageList.Images.IndexOfKey(status.ToString().ToLowerInvariant())));
                }

                int receivedCount = 0;
                foreach (PurchaseOrder purchaseOrder in purchaseOrders.Where(po => po.LocationIDDestination == LocationModel.LocationID || (po.PurchaseOrderApprovals?.Any(poa => poa.CompanyIDApprover == Company.CompanyID) ?? false)))
                {
                    TreeNode parentNode = receivedNodes.FirstOrDefault(kvp => kvp.Key == purchaseOrder.Status).Value;
                    if (parentNode == null)
                    {
                        continue;
                    }

                    TreeNode purchaseOrderNode = new TreeNode(purchaseOrder.LocationIDOrigin != null ?
                        string.Format(INCOMING_NODE_COMPANY_FORMAT, purchaseOrder.LocationOrigin?.Company?.Name, purchaseOrder.LocationOrigin?.Name, purchaseOrder.PurchaseOrderID, purchaseOrder.PurchaseOrderDate?.ToString("MM/dd/yyyy") ?? "[Unknown]") :
                        string.Format(INCOMING_NODE_GOV_FORMAT, purchaseOrder.GovernmentOrigin?.Name, purchaseOrder.PurchaseOrderID, purchaseOrder.PurchaseOrderDate?.ToString("MM/dd/yyyy") ?? "[Unknown]"),
                        imageList.Images.IndexOfKey(purchaseOrder.Status.ToString().ToLowerInvariant()), imageList.Images.IndexOfKey(purchaseOrder.Status.ToString().ToLowerInvariant()));
                    purchaseOrderNode.Tag = purchaseOrder;
                    parentNode.Nodes.Add(purchaseOrderNode);
                    receivedCount++;

                    if (purchaseOrder.PurchaseOrderID == selectedPurchaseOrderID)
                    {
                        selectedNode = purchaseOrderNode;
                    }
                }

                int issuedNonCompleteCount = 0;
                int issuedTotalCount = 0;
                foreach (PurchaseOrder purchaseOrder in purchaseOrders.Where(po => po.LocationIDOrigin == LocationModel.LocationID))
                {
                    TreeNode parentNode = issuedNodes.FirstOrDefault(kvp => kvp.Key == purchaseOrder.Status).Value;
                    TreeNode purchaseOrderNode = new TreeNode(purchaseOrder.LocationIDDestination != null ?
                        string.Format(OUTGOING_NODE_COMPANY_FORMAT, purchaseOrder.LocationDestination?.Company?.Name, purchaseOrder.LocationDestination?.Name, purchaseOrder.PurchaseOrderID, purchaseOrder.PurchaseOrderDate?.ToString("MM/dd/yyyy") ?? "[Unknown]") :
                        string.Format(OUTGOING_NODE_GOV_FORMAT, purchaseOrder.GovernmentDestination?.Name, purchaseOrder.PurchaseOrderID, purchaseOrder.PurchaseOrderDate?.ToString("MM/dd/yyyy") ?? "[Unknown]"),
                        imageList.Images.IndexOfKey(purchaseOrder.Status.ToString().ToLowerInvariant()), imageList.Images.IndexOfKey(purchaseOrder.Status.ToString().ToLowerInvariant()));
                    purchaseOrderNode.Tag = purchaseOrder;
                    parentNode.Nodes.Add(purchaseOrderNode);

                    if (purchaseOrder.PurchaseOrderID == selectedPurchaseOrderID)
                    {
                        selectedNode = purchaseOrderNode;
                    }

                    issuedTotalCount++;
                    if (purchaseOrder.Status != PurchaseOrder.Statuses.Completed)
                    {
                        issuedNonCompleteCount++;
                    }
                }

                TreeNode receivedNode = new TreeNode("Received", imageList.Images.IndexOfKey("received"), imageList.Images.IndexOfKey("received"));
                foreach (TreeNode parentNode in receivedNodes.Values)
                {
                    parentNode.Text += " (" + parentNode.Nodes.Count + ")";
                    receivedNode.Nodes.Add(parentNode);
                }
                receivedNode.Text += " (" + receivedCount + ")";
                trePurchaseOrders.Nodes.Add(receivedNode);

                TreeNode issuedNode = new TreeNode("Outgoing", imageList.Images.IndexOfKey("sent"), imageList.Images.IndexOfKey("sent"));
                foreach (TreeNode parentNode in issuedNodes.Values)
                {
                    parentNode.Text += " (" + parentNode.Nodes.Count + ")";
                    issuedNode.Nodes.Add(parentNode);
                }
                issuedNode.Text += " (" + issuedNonCompleteCount + "/" + issuedTotalCount + ")";
                trePurchaseOrders.Nodes.Add(issuedNode);

                trePurchaseOrders.ExpandAll();
                receivedNodes[PurchaseOrder.Statuses.Completed].Collapse();
                issuedNodes[PurchaseOrder.Statuses.Completed].Collapse();

                if (selectedNode != null)
                {
                    trePurchaseOrders.SelectedNode = selectedNode;
                }
            }
            finally
            {
                loader.Visible = false;
                trePurchaseOrders.Enabled = true;
                toolStrip1.Enabled = true;
            }
        }

        private void toolAddPurchaseOrder_Click(object sender, EventArgs e)
        {
            OpenPurchaseOrder();
        }

        private void OpenPurchaseOrder(PurchaseOrder purchaseOrder = null)
        {
            PurchaseOrder.Statuses status = purchaseOrder?.Status ?? PurchaseOrder.Statuses.Draft;

            switch (status)
            {
                case PurchaseOrder.Statuses.Draft:
                    DraftEntry.frmPurchaseOrder draftEntry = new DraftEntry.frmPurchaseOrder();
                    Studio.DecorateStudioContent(draftEntry);
                    draftEntry.Company = Company;
                    draftEntry.LocationModel = LocationModel;
                    draftEntry.PurchaseOrderID = purchaseOrder?.PurchaseOrderID;
                    draftEntry.Show(Studio.dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                    break;
                case PurchaseOrder.Statuses.Pending:
                    if (purchaseOrder.LocationIDOrigin == LocationModel.LocationID)
                    {
                        ApprovalViewer.frmApprovalViewerSubmitter approvalViewerSubmitter = new ApprovalViewer.frmApprovalViewerSubmitter()
                        {
                            PurchaseOrderID = purchaseOrder.PurchaseOrderID
                        };
                        Studio.DecorateStudioContent(approvalViewerSubmitter);
                        approvalViewerSubmitter.Company = Company;
                        approvalViewerSubmitter.LocationModel = LocationModel;
                        approvalViewerSubmitter.Show(Studio.dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                    }
                    else if (purchaseOrder.LocationIDDestination == LocationModel.LocationID || purchaseOrder.PurchaseOrderApprovals.Any(poa => poa.CompanyIDApprover == Company.CompanyID))
                    {
                        ApprovalViewer.frmApprovalViewerApprover approvalViewerApprover = new ApprovalViewer.frmApprovalViewerApprover()
                        {
                            PurchaseOrderID = purchaseOrder.PurchaseOrderID
                        };
                        Studio.DecorateStudioContent(approvalViewerApprover);
                        approvalViewerApprover.Company = Company;
                        approvalViewerApprover.LocationModel = LocationModel;
                        approvalViewerApprover.Show(Studio.dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                    }
                    break;
                case PurchaseOrder.Statuses.Accepted:
                case PurchaseOrder.Statuses.InProgress:
                    if (purchaseOrder.LocationIDOrigin == LocationModel.LocationID)
                    {
                        OpenMaintenance.frmOpenViewerSubmitter openMaintenanceSubmitter = new OpenMaintenance.frmOpenViewerSubmitter()
                        {
                            PurchaseOrderID = purchaseOrder.PurchaseOrderID
                        };
                        Studio.DecorateStudioContent(openMaintenanceSubmitter);
                        openMaintenanceSubmitter.Company = Company;
                        openMaintenanceSubmitter.LocationModel = LocationModel;
                        openMaintenanceSubmitter.Show(Studio.dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                    }
                    else if (purchaseOrder.LocationIDDestination == LocationModel.LocationID)
                    {
                        OpenMaintenance.frmOpenPurchaseOrderReceiver openMaintenanceReceiver = new OpenMaintenance.frmOpenPurchaseOrderReceiver()
                        {
                            PurchaseOrderID = purchaseOrder.PurchaseOrderID
                        };
                        Studio.DecorateStudioContent(openMaintenanceReceiver);
                        openMaintenanceReceiver.Company = Company;
                        openMaintenanceReceiver.LocationModel = LocationModel;
                        openMaintenanceReceiver.Show(Studio.dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                    }
                    break;
            }
        }

        private async void PurchaseOrder_OnSave(object sender, long? purchaseOrderID)
        {
            try
            {
                await ReloadTree(purchaseOrderID);
            }
            catch { }
        }

        public void RegisterPurchaseOrderForm<T>(T form, Func<long?> purchaseOrderIDCallback) where T : BaseCompanyStudioContent, ISaveable
        {
            async void OnFormClosed(object sender, FormClosedEventArgs e)
            {
                await ReloadTree(purchaseOrderIDCallback?.Invoke());
            };

            form.OnSave += async (_, __) => await ReloadTree(purchaseOrderIDCallback?.Invoke());
            form.FormClosed += OnFormClosed;

            OnInternalDelete += (_, deletedPOID) =>
            {
                if (form.IsHandleCreated && deletedPOID == purchaseOrderIDCallback?.Invoke())
                {
                    form.FormClosed -= OnFormClosed;
                    form.Close();
                }
            };
        }

        private void trePurchaseOrders_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is PurchaseOrder purchaseOrder)
            {
                OpenPurchaseOrder(purchaseOrder);
            }
        }

        private void trePurchaseOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (trePurchaseOrders.SelectedNode == null || !(trePurchaseOrders.SelectedNode.Tag is PurchaseOrder purchaseOrder))
            {
                return;
            }

            switch(e.KeyCode)
            {
                case Keys.Delete:
                    toolDelete.PerformClick();
                    break;
            }
        }

        private void trePurchaseOrders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trePurchaseOrders.SelectedNode == null || !(trePurchaseOrders.SelectedNode.Tag is PurchaseOrder purchaseOrder))
            {
                toolDelete.Enabled = false;
                return;
            }

            toolDelete.Enabled = purchaseOrder.LocationIDOrigin == LocationModel.LocationID && purchaseOrder.Status == PurchaseOrder.Statuses.Draft;
        }

        private async void toolDelete_Click(object sender, EventArgs e)
        {
            if (trePurchaseOrders.SelectedNode == null || !(trePurchaseOrders.SelectedNode.Tag is PurchaseOrder purchaseOrder))
            {
                return;
            }

            if (purchaseOrder.LocationIDOrigin == LocationModel.LocationID && purchaseOrder.Status == PurchaseOrder.Statuses.Draft && this.Confirm($"Are you sure you want to delete Purchase Order {purchaseOrder.PurchaseOrderID}"))
            {
                DeleteData delete = new DeleteData(DataAccess.APIs.CompanyStudio, "PurchaseOrder/Delete/" + purchaseOrder.PurchaseOrderID);
                delete.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                await delete.Execute();

                OnInternalDelete?.Invoke(this, purchaseOrder.PurchaseOrderID);

                await ReloadTree();
            }
        }

        private async void toolNewFromTemplate_Click(object sender, EventArgs e)
        {
            Templates.frmTemplateDialog openDialog = new Templates.frmTemplateDialog()
            {
                CompanyID = Company.CompanyID,
                LocationID = LocationModel.LocationID,
                Theme = Theme,
                DialogMode = Templates.frmTemplateDialog.DialogModes.Open
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                PostData post = new PostData(DataAccess.APIs.CompanyStudio, "PurchaseOrder/CloneFromTemplate", new { openDialog.SelectedTemplate.PurchaseOrderTemplateID });
                post.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                PurchaseOrder newPO = await post.Execute<PurchaseOrder>();
                if (post.RequestSuccessful)
                {
                    await ReloadTree(newPO.PurchaseOrderID);
                    OpenPurchaseOrder(newPO);
                }
            }
        }
    }
}
