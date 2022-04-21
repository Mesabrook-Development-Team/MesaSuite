using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.company;
using WebModels.gov;
using WebModels.invoicing;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [LocationAccess(RequiredPermissions = new[] { nameof(LocationEmployee.ManageInvoices) })]
    public class InvoiceController : DataObjectController<Invoice>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new[]
        {
            nameof(Invoice.InvoiceID),
            nameof(Invoice.LocationIDTo),
            $"{nameof(Invoice.LocationTo)}.{nameof(Location.Name)}",
            $"{nameof(Invoice.LocationTo)}.{nameof(Location.CompanyID)}",
            $"{nameof(Invoice.LocationTo)}.{nameof(Location.Company)}.{nameof(Company.Name)}",
            nameof(Invoice.LocationIDFrom),
            nameof(Invoice.GovernmentIDTo),
            $"{nameof(Invoice.GovernmentTo)}.{nameof(Government.Name)}",
            nameof(Invoice.GovernmentIDFrom),
            nameof(Invoice.InvoiceNumber),
            nameof(Invoice.InvoiceDate),
            nameof(Invoice.DueDate),
            nameof(Invoice.Description),
            nameof(Invoice.AccountIDTo),
            nameof(Invoice.AccountToHistorical),
            nameof(Invoice.AccountIDFrom),
            nameof(Invoice.AccountToHistorical),
            nameof(Invoice.CreationType),
            nameof(Invoice.Status),
            $"{nameof(Invoice.InvoiceLines)}.{nameof(InvoiceLine.InvoiceLineID)}",
            $"{nameof(Invoice.InvoiceLines)}.{nameof(InvoiceLine.InvoiceID)}",
            $"{nameof(Invoice.InvoiceLines)}.{nameof(InvoiceLine.Quantity)}",
            $"{nameof(Invoice.InvoiceLines)}.{nameof(InvoiceLine.UnitCost)}",
            $"{nameof(Invoice.InvoiceLines)}.{nameof(InvoiceLine.Total)}",
            $"{nameof(Invoice.InvoiceLines)}.{nameof(InvoiceLine.Description)}"
        };

        public override bool AllowGetAll => true;

        private long LocationID => long.Parse(Request.Headers.GetValues("LocationID").First());

        public override ISearchCondition GetBaseSearchCondition()
        {
            return new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                new LongSearchCondition<Invoice>()
                {
                    Field = "LocationIDFrom",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = LocationID
                },
                new LongSearchCondition<Invoice>()
                {
                    Field = "LocationIDTo",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = LocationID
                });
        }

        [HttpPut]
        public override async Task<IHttpActionResult> Put(Invoice dataObject)
        {
            Invoice dbInvoice = await GetPutObjectResult(dataObject);

            if (!dbInvoice.DoesLocationHavePermissionToUpdateByStatus(LocationID) || !dbInvoice.DoesLocationHavePermissionToUpdateFields(LocationID))
            {
                dbInvoice.Errors.AddBaseMessage("Location does not have permission to update at least one field");
                return dbInvoice.HandleFailedValidation(this);
            }
            
            return await base.Put(dataObject);
        }

        [HttpDelete]
        public override IHttpActionResult Delete(long id)
        {
            Search<Invoice> invoiceSearch = new Search<Invoice>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                GetBaseSearchCondition(),
                new LongSearchCondition<Invoice>()
                {
                    Field = "InvoiceID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                }));

            Invoice invoice = invoiceSearch.GetEditable();
            if (invoice == null)
            {
                return NotFound();
            }

            if (!invoice.DoesLocationHavePermissionToDelete(LocationID))
            {
                invoice.Errors.AddBaseMessage("Location does not have permission to delete this Invoice");
                return invoice.HandleFailedValidation(this);
            }

            return base.Delete(id);
        }

        [HttpPut]
        public IHttpActionResult Issue(Invoice invoice)
        {
            Invoice dbInvoice = new Search<Invoice>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                GetBaseSearchCondition(),
                new LongSearchCondition<Invoice>()
                {
                    Field = "InvoiceID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = invoice.InvoiceID
                })).GetEditable();

            if (dbInvoice == null)
            {
                return NotFound();
            }

            if (dbInvoice.CreationType != Invoice.CreationTypes.AccountsReceivable || dbInvoice.LocationIDFrom != LocationID)
            {
                dbInvoice.Errors.AddBaseMessage("Only Locations that created an Accounts Receivable Invoice may issue it");
                return dbInvoice.HandleFailedValidation(this);
            }

            dbInvoice.IssueInvoice();
            if (dbInvoice.Errors.Any())
            {
                return dbInvoice.HandleFailedValidation(this);
            }

            return Ok(dbInvoice);
        }

        [HttpPut]
        public IHttpActionResult Receive(Invoice invoice)
        {
            Invoice dbInvoice = new Search<Invoice>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                GetBaseSearchCondition(),
                new LongSearchCondition<Invoice>()
                {
                    Field = "InvoiceID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = invoice.InvoiceID
                })).GetEditable();

            if (dbInvoice == null)
            {
                return NotFound();
            }

            if (dbInvoice.CreationType != Invoice.CreationTypes.AccountsPayable || dbInvoice.LocationIDFrom != LocationID)
            {
                dbInvoice.Errors.AddBaseMessage("Only Locations that created an Accounts Receivable Invoice may issue it");
                return dbInvoice.HandleFailedValidation(this);
            }


            return Ok(dbInvoice);
        }
    }
}