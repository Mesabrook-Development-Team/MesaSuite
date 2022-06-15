using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using API_Government.Attributes;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.gov;
using WebModels.invoicing;

namespace API_Government.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("gov")]
    [GovernmentAccess(RequiredPermissions = new [] { nameof(Official.ManageInvoices) })]
    public class InvoiceLineController : DataObjectController<InvoiceLine>
    {
        private long GovernmentID => long.Parse(Request.Headers.GetValues("GovernmentID").First());

        public override IEnumerable<string> DefaultRetrievedFields => new[]
        {
            nameof(InvoiceLine.InvoiceLineID),
            nameof(InvoiceLine.InvoiceID),
            nameof(InvoiceLine.Description),
            nameof(InvoiceLine.Quantity),
            nameof(InvoiceLine.UnitCost),
            nameof(InvoiceLine.Total)
        };

        public override ISearchCondition GetBaseSearchCondition()
        {
            return new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                new LongSearchCondition<InvoiceLine>()
                {
                    Field = "Invoice.GovernmentIDFrom",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = GovernmentID
                },
                new LongSearchCondition<InvoiceLine>()
                {
                    Field = "Invoice.GovernmentIDTo",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = GovernmentID
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

            if (!invoice.DoesEntityHavePermissionToUpdateByStatus(GovernmentID == invoice.GovernmentIDFrom))
            {
                dataObject.Errors.AddBaseMessage("Government does not have permission to update at least one field");
                return dataObject.HandleFailedValidation(this);
            }

            return await base.Put(dataObject);
        }

        [HttpDelete]
        public override IHttpActionResult Delete(long id)
        {
            InvoiceLine invoiceLine = DataObject.GetReadOnlyByPrimaryKey<InvoiceLine>(id, null, new string[] { nameof(InvoiceLine.InvoiceID) });
            if (invoiceLine == null)
            {
                return NotFound();
            }

            Invoice invoice = DataObject.GetEditableByPrimaryKey<Invoice>(invoiceLine.InvoiceID, null, null);
            if (!invoice.DoesEntityHavePermissionToUpdateByStatus(GovernmentID == invoice.GovernmentIDFrom))
            {
                invoiceLine.Errors.AddBaseMessage("Government does not have permission to delete this Invoice Line");
                return invoice.HandleFailedValidation(this);
            }

            return base.Delete(id);
        }
    }
}