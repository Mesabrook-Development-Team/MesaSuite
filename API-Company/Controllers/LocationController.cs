using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.company;
using WebModels.gov;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [CompanyAccess(RequiredPermissions = new string[] { nameof(Employee.ManageLocations) })]
    public class LocationController : DataObjectController<Location>
    {
        public override bool AllowGetAll => true;
        public override IEnumerable<string> DefaultRetrievedFields => new string[]
        {
            nameof(Location.LocationID),
            nameof(Location.CompanyID),
            nameof(Location.Name),
            nameof(Location.InvoiceNumberPrefix),
            nameof(Location.NextInvoiceNumber)
        };

        protected override IEnumerable<string> RequestableFields => new string[]
        {
            nameof(Location.EmailImplementationIDPayableInvoice),
            nameof(Location.EmailImplementationIDReadyForReceipt),
            $"{nameof(Location.LocationEmployees)}.{nameof(LocationEmployee.LocationEmployeeID)}",
            $"{nameof(Location.LocationEmployees)}.{nameof(LocationEmployee.LocationID)}",
            $"{nameof(Location.LocationEmployees)}.{nameof(LocationEmployee.EmployeeID)}",
            $"{nameof(Location.LocationEmployees)}.{nameof(LocationEmployee.ManageInvoices)}",
            $"{nameof(Location.LocationEmployees)}.{nameof(LocationEmployee.ManagePrices)}",
            $"{nameof(Location.LocationEmployees)}.{nameof(LocationEmployee.ManageRegisters)}",
            $"{nameof(Location.LocationEmployees)}.{nameof(LocationEmployee.ManageInventory)}",
            $"{nameof(Location.LocationEmployees)}.{nameof(LocationEmployee.Employee)}.{nameof(Employee.EmployeeID)}",
            $"{nameof(Location.LocationEmployees)}.{nameof(LocationEmployee.Employee)}.{nameof(Employee.EmployeeName)}",
            $"{nameof(Location.LocationGovernments)}.{nameof(LocationGovernment.LocationGovernmentID)}",
            $"{nameof(Location.LocationGovernments)}.{nameof(LocationGovernment.LocationID)}",
            $"{nameof(Location.LocationGovernments)}.{nameof(LocationGovernment.GovernmentID)}",
            $"{nameof(Location.LocationGovernments)}.{nameof(LocationGovernment.PaySalesTax)}",
            $"{nameof(Location.LocationGovernments)}.{nameof(LocationGovernment.Government)}.{nameof(Government.GovernmentID)}",
            $"{nameof(Location.LocationGovernments)}.{nameof(LocationGovernment.Government)}.{nameof(Government.Name)}"
        };

        public override ISearchCondition GetBaseSearchCondition()
        {
            long companyID = long.Parse(Request.Headers.GetValues("CompanyID").First());
            return new LongSearchCondition<Location>()
            {
                Field = "CompanyID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = companyID
            };
        }

        [HttpGet]
        [CompanyAccess]
        [LocationAccess]
        public override Task<Location> Get(long id)
        {
            return base.Get(id);
        }
    }
}