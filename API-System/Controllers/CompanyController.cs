using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebModels.company;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("system")]
    public class CompanyController : DataObjectController<Company>
    {
        public override bool AllowGetAll => true;

        public override IEnumerable<string> DefaultRetrievedFields => new List<string>()
        {
            nameof(Company.CompanyID),
            nameof(Company.Name),
            nameof(Company.EmailDomain)
        };

        [ProgramAccess(new string[0])]
        public async Task<List<Company>> GetAllForUser()
        {
            Search<Company> companySearch = new Search<Company>(new ExistsSearchCondition<Company>()
            {
                RelationshipName = nameof(Company.Employees),
                ExistsType = ExistsSearchCondition<Company>.ExistsTypes.Exists,
                Condition = new LongSearchCondition<Employee>()
                {
                    Field = nameof(Employee.UserID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = SecurityProfile.UserID
                }
            });

            return await Task.Run(() => companySearch.GetReadOnlyReader(null, DefaultRetrievedFields).ToList());
        }
    }
}
