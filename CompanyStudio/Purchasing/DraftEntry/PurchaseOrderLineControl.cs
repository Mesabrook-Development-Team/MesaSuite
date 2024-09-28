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

namespace CompanyStudio.Purchasing.DraftEntry
{
    [ToolboxItem(false)]
    public partial class PurchaseOrderLineControl : UserControl
    {
        public event EventHandler DeleteClicked;
        public PurchaseOrderLine PurchaseOrderLine { get; set; }
        public long? PurchaseOrderID { get; set; }
        public long? CompanyID { get; set; }
        public long? LocationID { get; set; }

        public PurchaseOrderLineControl()
        {
            InitializeComponent();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        private void PurchaseOrderLineControl_Load(object sender, EventArgs e)
        {
            rdoItem.Checked = (!PurchaseOrderLine?.IsService) ?? false;
            rdoService.Checked = PurchaseOrderLine?.IsService ?? false;
            txtServiceDescription.Text = PurchaseOrderLine?.ServiceDescription;
            cboItem.SelectedID = PurchaseOrderLine?.ItemID;
            txtItemDescription.Text = PurchaseOrderLine?.ItemDescription;
            txtQuantity.Text = PurchaseOrderLine?.Quantity.ToString();
            txtUnitCost.Text = PurchaseOrderLine?.UnitCost.ToString();
            txtLineCost.Text = (PurchaseOrderLine?.Quantity * PurchaseOrderLine?.UnitCost)?.ToString();
            lblFulfillmentPlanWarning.Visible = !PurchaseOrderLine?.FulfillmentPlanPurchaseOrderLines?.Any() ?? true;
        }

        public async Task<string> PerformSave()
        {
            if (!decimal.TryParse(txtQuantity.Text, out decimal quantity))
            {
                return "Quantity must be a number";
            }

            if (!decimal.TryParse(txtUnitCost.Text, out decimal unitCost))
            {
                return "Unit Cost must be a number";
            }

            PurchaseOrderLine lineToSave = new PurchaseOrderLine()
            {
                PurchaseOrderLineID = PurchaseOrderLine?.PurchaseOrderLineID,
                PurchaseOrderID = PurchaseOrderID,
                IsService = rdoService.Checked,
                ServiceDescription = rdoService.Checked ? txtServiceDescription.Text : null,
                ItemID = rdoItem.Checked ? cboItem.SelectedID : null,
                ItemDescription = rdoItem.Checked ? txtItemDescription.Text : null,
                Quantity = quantity,
                UnitCost = unitCost
            };

            if (lineToSave.PurchaseOrderLineID == null)
            {
                PostData post = new PostData(DataAccess.APIs.CompanyStudio, "PurchaseOrderLine/Post", lineToSave);
                post.SuppressErrors = true;
                post.AddLocationHeader(CompanyID, LocationID);
                lineToSave = await post.Execute<PurchaseOrderLine>();
                if (post.RequestSuccessful)
                {
                    PurchaseOrderLine = lineToSave;
                }
                else
                {
                    return post.LastError;
                }
            }
            else
            {
                PutData put = new PutData(DataAccess.APIs.CompanyStudio, "PurchaseOrderLine/Put", lineToSave);
                put.SuppressErrors = true;
                put.AddLocationHeader(CompanyID, LocationID);
                lineToSave = await put.Execute<PurchaseOrderLine>();
                if (put.RequestSuccessful)
                {
                    PurchaseOrderLine = lineToSave;
                }
                else
                {
                    return put.LastError;
                }
            }

            return null;
        }

        public List<string> ValidatePresence()
        {
            List<string> errors = new List<string>();
            if (!rdoItem.Checked && !rdoService.Checked)
            {
                errors.Add("Line Type is a required field");
            }

            if (rdoItem.Checked)
            {
                if (cboItem.SelectedID == null && string.IsNullOrEmpty(txtItemDescription.Text))
                {
                    errors.Add("Either Item or Item Description is a required field when Line Type is Item");
                }
            }
            else if (rdoService.Checked && string.IsNullOrEmpty(txtServiceDescription.Text))
            {
                errors.Add("Service Description is a required field when Line Type is Service");
            }

            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                errors.Add("Quantity is a required field");
            }
            if (!decimal.TryParse(txtQuantity.Text, out _))
            {
                errors.Add("Quantity must be a number");
            }

            if (string.IsNullOrEmpty(txtUnitCost.Text))
            {
                errors.Add("Unit Cost is a required field");
            }
            if (!decimal.TryParse(txtUnitCost.Text, out _))
            {
                errors.Add("Unit Cost must be a number");
            }

            return errors;
        }

        private void LineTypeCheckedChange(object sender, EventArgs e)
        {
            pnlItem.Visible = rdoItem.Checked;
            pnlService.Visible = rdoService.Checked;
        }

        public void SetHasFulfillmentPlan(bool hasFulfillmentPlan)
        {
            lblFulfillmentPlanWarning.Visible = !hasFulfillmentPlan;
        }
    }
}
