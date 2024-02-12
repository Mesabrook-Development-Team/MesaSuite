using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ImmersibrookAccess]
    public class LocationEmployeeIBAccessController : ApiController
    {
        private readonly List<string> LocationFields = FieldPathUtility.CreateFieldPathsAsList<LocationEmployee>(le => new List<object>()
        {
            le.ManagePrices,
            le.ManageRegisters,
            le.ManageInventory,
            le.LocationID,
            le.Location.LocationID,
            le.Location.Name,
            le.Location.CompanyID,
            le.Location.Company.CompanyID,
            le.Location.Company.Name
        });

        [HttpGet]
        public List<LocationEmployee> GetLocationClearanceForPlayer(string id)
        {
            Search<LocationEmployee> employeeLocationSearch = new Search<LocationEmployee>(new StringSearchCondition<LocationEmployee>()
            {
                Field = FieldPathUtility.CreateFieldPathsAsList<LocationEmployee>(le => new List<object>() { le.Employee.User.Username }).First(),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
                //Value = "CSX8600"
            });

            return employeeLocationSearch.GetReadOnlyReader(null, LocationFields).ToList();
        }

        [HttpGet]
        public LocationEmployee GetLocationForPlayerLocation(string player, long locationID)
        {
            Search<LocationEmployee> locEmpSearch = new Search<LocationEmployee>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<LocationEmployee>()
                {
                    Field = nameof(LocationEmployee.LocationID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = locationID
                },
                new StringSearchCondition<LocationEmployee>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<LocationEmployee>(le => new List<object>() { le.Employee.User.Username }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = player
                    //Value = "CSX8600"
                }));

            return locEmpSearch.GetReadOnly(null, LocationFields);
        }
    }
}