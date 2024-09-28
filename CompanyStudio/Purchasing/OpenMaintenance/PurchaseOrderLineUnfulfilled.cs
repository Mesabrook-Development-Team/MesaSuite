using CompanyStudio.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CompanyStudio.Purchasing.OpenMaintenance
{
    public partial class PurchaseOrderLineUnfulfilled : UserControl
    {
        public PurchaseOrderLine PurchaseOrderLine { get; set; }
        public PurchaseOrderLineUnfulfilled()
        {
            InitializeComponent();
        }

        private void PurchaseOrderLineUnfulfilled_Load(object sender, EventArgs e)
        {
            txtExpectedRailcars.Text = string.Join(", ", PurchaseOrderLine.FulfillmentPlanPurchaseOrderLines?.Select(fppol => fppol.FulfillmentPlan?.Railcar?.ReportingID) ?? new string[0]);
            txtServiceItem.Text = PurchaseOrderLine.DisplayString;
            txtUnfulfilled.Text = (PurchaseOrderLine.Quantity - (PurchaseOrderLine.Fulfillments?.Sum(f => f.Quantity) ?? 0)).ToString();
        }
    }
}
