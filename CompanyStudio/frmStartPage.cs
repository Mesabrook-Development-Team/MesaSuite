using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyStudio.Extensions;
using CompanyStudio.Models;
using MesaSuite.Common.Collections;
using MesaSuite.Common.Data;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio
{
    public partial class frmStartPage : DockContent
    {
        public frmStudio Studio { get; set; }
        private List<ToDoItem> toDoItems = new List<ToDoItem>();

        public frmStartPage()
        {
            InitializeComponent();
        }

        private async void frmStartPage_Load(object sender, EventArgs e)
        {
            loader.BringToFront();
            loader.Visible = true;

            GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Employee/GetToDoItems");
            toDoItems = await get.GetObject<List<ToDoItem>>() ?? new List<ToDoItem>();
            toDoItems.ForEach(tdi => tdi.CompanyName = Studio.Companies.FirstOrDefault(c => c.CompanyID == tdi.CompanyID)?.Name);
            toDoItems.Sort(new ToDoItem.ToDoItemComparer());
            foreach (ToDoItem item in toDoItems)
            {
                TabPage companyPage = tbpToDoList.TabPages.OfType<TabPage>().FirstOrDefault(tp => tp.Tag is Company company && company.CompanyID == item.CompanyID);
                if (companyPage == null)
                {
                    Company company = Studio.Companies.FirstOrDefault(c => c.CompanyID == item.CompanyID);
                    if (company == null)
                    {
                        continue;
                    }

                    companyPage = new TabPage();
                    companyPage.Tag = company;
                    companyPage.Text = company.Name;

                    int insertIndex = 1;
                    TabPage desiredIndex = tbpToDoList.TabPages.OfType<TabPage>().OrderBy(tp => tp.Text).FirstOrDefault(tb => tb.Text.CompareTo(companyPage.Text) >= 1);
                    if (desiredIndex != null)
                    {
                        insertIndex = tbpToDoList.TabPages.IndexOf(desiredIndex);
                    }

                    tbpToDoList.TabPages.Insert(insertIndex, companyPage);
                }

                lblAllCaughtUp.Visible = false;
                // Insert into All Businesses tab
                ReaLTaiizor.Controls.HopeNotify.AlertType type = default;
                switch(item.Type)
                {
                    case ToDoItem.Types.PayablePastDueInvoice:
                    case ToDoItem.Types.ReceivablePastDueInvoice:
                        type = ReaLTaiizor.Controls.HopeNotify.AlertType.Error;
                        break;
                    case ToDoItem.Types.PayableInvoiceWaiting:
                    case ToDoItem.Types.ReceivableInvoiceWaiting:
                    case ToDoItem.Types.RegisterOffline:
                    case ToDoItem.Types.PurchaseOrderWaitingApproval:
                    case ToDoItem.Types.QuotationRequestWaiting:
                        type = ReaLTaiizor.Controls.HopeNotify.AlertType.Warning;
                        break;
                    case ToDoItem.Types.RailcarAwaitingAction:
                    case ToDoItem.Types.OpenPurchaseOrders:
                        type = ReaLTaiizor.Controls.HopeNotify.AlertType.Info;
                        break;
                }

                ReaLTaiizor.Controls.HopeNotify mainTabControl = new ReaLTaiizor.Controls.HopeNotify()
                {
                    Text = $"{(companyPage.Tag as Company).Name}: {item.Message}",
                    Tag = item,
                    Close = false,
                    Width = tabAll.Width,
                    Type = type,
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right
                };
                mainTabControl.Click += NotificationClick;

                int top = 0;
                if (tabAll.Controls.OfType<ReaLTaiizor.Controls.HopeNotify>().Any())
                {
                    top = tabAll.Controls.OfType<ReaLTaiizor.Controls.HopeNotify>().Max(n => n.Bottom) + 6;
                }
                mainTabControl.Top = top;
                tabAll.Controls.Add(mainTabControl);

                // Insert onto company specific tab
                ReaLTaiizor.Controls.HopeNotify companyTabControl = new ReaLTaiizor.Controls.HopeNotify()
                {
                    Text = item.Message,
                    Tag = item,
                    Close = false,
                    Width = companyPage.Width,
                    Type = type,
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right
                };
                companyTabControl.Click += NotificationClick;
                top = 0;
                if (companyPage.Controls.OfType<ReaLTaiizor.Controls.HopeNotify>().Any())
                {
                    top = companyPage.Controls.OfType<ReaLTaiizor.Controls.HopeNotify>().Max(n => n.Bottom) + 6;
                }
                companyTabControl.Top = top;
                companyPage.Controls.Add(companyTabControl);
            }

            loader.Visible = false;
        }

        private async void NotificationClick(object sender, EventArgs e)
        {
            if (!(sender is ReaLTaiizor.Controls.HopeNotify notify) || !(notify.Tag is ToDoItem toDoItem))
            {
                return;
            }

            GetData get = new GetData(DataAccess.APIs.CompanyStudio, null);
            get.AddLocationHeader(toDoItem.CompanyID, toDoItem.LocationID);

            Company company = Studio.Companies.FirstOrDefault(c => c.CompanyID == toDoItem.CompanyID);
            Location location = company.Locations.FirstOrDefault(l => l.LocationID == toDoItem.LocationID);

            switch (toDoItem.Type)
            {
                case ToDoItem.Types.PayableInvoiceWaiting:
                case ToDoItem.Types.PayablePastDueInvoice:
                    get.Resource = "Invoice/Get/" + toDoItem.SourceID;
                    Invoice payableInvoice = await get.GetObject<Invoice>();

                    if (payableInvoice == null)
                    {
                        return;
                    }

                    Invoicing.frmPayableInvoice payableInvoiceForm = new Invoicing.frmPayableInvoice()
                    {
                        Invoice = payableInvoice
                    };
                    Studio.DecorateStudioContent(payableInvoiceForm);
                    payableInvoiceForm.Company = company;
                    payableInvoiceForm.LocationModel = location;
                    payableInvoiceForm.Show(Studio.dockPanel, DockState.Document);
                    break;
                case ToDoItem.Types.ReceivableInvoiceWaiting:
                case ToDoItem.Types.ReceivablePastDueInvoice:
                    get.Resource = "Invoice/Get/" + toDoItem.SourceID;
                    Invoice receivableInvoice = await get.GetObject<Invoice>();

                    if (receivableInvoice == null)
                    {
                        return;
                    }

                    Invoicing.frmReceivableInvoice receivableInvoiceForm = new Invoicing.frmReceivableInvoice()
                    {
                        Company = company
                    };
                    Studio.DecorateStudioContent(receivableInvoiceForm);
                    receivableInvoiceForm.Company = company;
                    receivableInvoiceForm.LocationModel = location;
                    receivableInvoiceForm.Show(Studio.dockPanel, DockState.Document);
                    break;
                case ToDoItem.Types.QuotationRequestWaiting:
                    Purchasing.Quotes.frmQuoteRequest quoteRequest = new Purchasing.Quotes.frmQuoteRequest()
                    {
                        Company = company
                    };
                    Studio.DecorateStudioContent(quoteRequest);
                    quoteRequest.Company = company;
                    quoteRequest.LocationModel = location;
                    quoteRequest.Show(Studio.dockPanel, DockState.Document);
                    break;
                case ToDoItem.Types.PurchaseOrderWaitingApproval:
                    get.Resource = "PurchaseOrder/Get/" + toDoItem.SourceID;
                    PurchaseOrder purchaseOrder = await get.GetObject<PurchaseOrder>();

                    if (purchaseOrder == null) { return; }

                    Purchasing.ApprovalViewer.frmApprovalViewerApprover approvalViewer = new Purchasing.ApprovalViewer.frmApprovalViewerApprover()
                    {
                        PurchaseOrderApprovalID = purchaseOrder.PurchaseOrderApprovals.FirstOrDefault(poa => poa.CompanyIDApprover == company.CompanyID)?.PurchaseOrderApprovalID,
                        PurchaseOrderID = toDoItem.SourceID
                    };
                    Studio.DecorateStudioContent(approvalViewer);
                    approvalViewer.Company = company;
                    approvalViewer.LocationModel = location;
                    approvalViewer.Show(Studio.dockPanel, DockState.Document);
                    break;
                case ToDoItem.Types.RailcarAwaitingAction:
                    Purchasing.ShippingReceiving.frmShippingReceiving shippingReceiving = new Purchasing.ShippingReceiving.frmShippingReceiving();
                    Studio.DecorateStudioContent(shippingReceiving);
                    shippingReceiving.Company = company;
                    shippingReceiving.LocationModel = location;
                    shippingReceiving.Show(Studio.dockPanel, DockState.Document);
                    break;
                case ToDoItem.Types.RegisterOffline:
                    Store.frmRegister register = new Store.frmRegister()
                    {
                        Company = company,
                        RegisterID = toDoItem.SourceID
                    };
                    Studio.DecorateStudioContent(register);
                    register.Company = company;
                    register.LocationModel = location;
                    register.Show(Studio.dockPanel, DockState.Document);
                    break;
                case ToDoItem.Types.OpenPurchaseOrders:
                    Purchasing.frmPurchaseOrderExplorer purchaseOrderExplorer = new Purchasing.frmPurchaseOrderExplorer();
                    Studio.DecorateStudioContent(purchaseOrderExplorer);
                    purchaseOrderExplorer.Company = company;
                    purchaseOrderExplorer.LocationModel = location;
                    purchaseOrderExplorer.Show(Studio.dockPanel, DockState.DockRight);
                    break;
            }
        }

        private class ToDoItem
        {
            public enum Types
            {
                PayableInvoiceWaiting = 0,
                ReceivableInvoiceWaiting,
                PayablePastDueInvoice,
                ReceivablePastDueInvoice,
                PurchaseOrderWaitingApproval,
                QuotationRequestWaiting,
                RailcarAwaitingAction,
                RegisterOffline,
                OpenPurchaseOrders
            }

            public Types Type { get; set; }
            public string Message { get; set; }
            public long? CompanyID { get; set; }
            public long? LocationID { get; set; }
            public long? SourceID { get; set; }

            public string CompanyName { get; set; }

            public class ToDoItemComparer : Comparer<ToDoItem>
            {
                private static readonly Dictionary<Types, int> _typePriorities = new Dictionary<Types, int>()
                {
                    { Types.PayablePastDueInvoice, 0 },
                    { Types.ReceivablePastDueInvoice, 0 },
                    { Types.PayableInvoiceWaiting, 1 },
                    { Types.ReceivableInvoiceWaiting, 1 },
                    { Types.RegisterOffline, 1 },
                    { Types.PurchaseOrderWaitingApproval, 1 },
                    { Types.QuotationRequestWaiting, 1 },
                    { Types.RailcarAwaitingAction, 2 },
                    { Types.OpenPurchaseOrders, 2 }
                };

                public override int Compare(ToDoItem x, ToDoItem y)
                {
                    int typePriorityX = _typePriorities[x.Type];
                    int typePriorityY = _typePriorities[y.Type];
                    int result = typePriorityX.CompareTo(typePriorityY);
                    if (result == 0)
                    {
                        result = x.CompanyName.CompareTo(y.CompanyName);
                    }

                    if (result == 0)
                    {
                        result = x.Message.CompareTo(y.Message);
                    }

                    return result;
                }
            }
        }
    }
}
