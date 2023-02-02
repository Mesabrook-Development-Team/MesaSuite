using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.company;
using WebModels.invoicing;
using WebModels.mesasys;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [LocationAccess(RequiredPermissions = new[] { nameof(LocationEmployee.ManageInvoices) })]
    public class InvoiceLineController : DataObjectController<InvoiceLine>
    {
        private long LocationID => long.Parse(Request.Headers.GetValues("LocationID").First());

        public override IEnumerable<string> DefaultRetrievedFields => new[]
        {
            nameof(InvoiceLine.InvoiceLineID),
            nameof(InvoiceLine.InvoiceID),
            nameof(InvoiceLine.Description),
            nameof(InvoiceLine.Quantity),
            nameof(InvoiceLine.UnitCost),
            nameof(InvoiceLine.Total),
            nameof(InvoiceLine.ItemID),
            $"{nameof(InvoiceLine.Item)}.{nameof(Item.ItemID)}",
            $"{nameof(InvoiceLine.Item)}.{nameof(Item.Name)}"
        };

        public override ISearchCondition GetBaseSearchCondition()
        {
            return new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                new LongSearchCondition<InvoiceLine>()
                {
                    Field = "Invoice.LocationIDFrom",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = LocationID
                },
                new LongSearchCondition<InvoiceLine>()
                {
                    Field = "Invoice.LocationIDTo",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = LocationID
                });
        }

        [HttpPut]
        public override async Task<IHttpActionResult> Put(InvoiceLine dataObject)
        {
            Invoice invoice = DataObject.GetEditableByPrimaryKey<Invoice>(dataObject.InvoiceID, null, null);

            if (invoice == null)
            {
                return NotFound();
            }

            if (!invoice.DoesEntityHavePermissionToUpdateByStatus(LocationID == invoice.LocationIDFrom))
            {
                dataObject.Errors.AddBaseMessage("Location does not have permission to update at least one field");
                return dataObject.HandleFailedValidation(this);
            }

            return await base.Put(dataObject);
        }

        [HttpDelete]
        public override IHttpActionResult Delete(long id)
        {
            InvoiceLine invoiceLine = DataObject.GetReadOnlyByPrimaryKey<InvoiceLine>(id, null, new string[] { nameof(InvoiceLine.InvoiceID )});
            if (invoiceLine == null)
            {
                return NotFound();
            }

            Invoice invoice = DataObject.GetEditableByPrimaryKey<Invoice>(invoiceLine.InvoiceID, null, null);
            if (!invoice.DoesEntityHavePermissionToUpdateByStatus(LocationID == invoice.LocationIDFrom))
            {
                invoiceLine.Errors.AddBaseMessage("Location does not have permission to delete this Invoice Line");
                return invoice.HandleFailedValidation(this);
            }

            return base.Delete(id);
        }
    }
}