using System.Collections.Generic;
using System.Linq;
using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [CompanyAccess(RequiredPermissions = new string[] { nameof(Employee.ManageLocations) })]
    public class LocationGovernmentController : DataObjectController<LocationGovernment>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new string[]
        {
            nameof(LocationGovernment.LocationGovernmentID),
            nameof(LocationGovernment.GovernmentID),
            nameof(LocationGovernment.LocationID),
            nameof(LocationGovernment.PaySalesTax)
        };

        public override SearchCondition GetBaseSearchCondition()
        {
            long companyID = long.Parse(Request.Headers.GetValues("CompanyID").First());
            return new LongSearchCondition<LocationGovernment>()
            {
                Field = "Location.CompanyID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = companyID
            };
        }
    }
}