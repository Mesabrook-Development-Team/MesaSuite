using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels.gov;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("system")]
    public class GovernmentController : DataObjectController<Government>
    {
        public override bool AllowGetAll => true;

        public override IEnumerable<string> DefaultRetrievedFields => new List<string>()
        {
            nameof(Government.GovernmentID),
            nameof(Government.Name),
            nameof(Government.EmailDomain),
            nameof(Government.CanMintCurrency),
            nameof(Government.CanConfigureInterest)
        };

        [ProgramAccess(new string[0])]
        public async Task<List<Government>> GetAllForUser()
        {
            Search<Government> GovernmentSearch = new Search<Government>(new ExistsSearchCondition<Government>()
            {
                RelationshipName = nameof(Government.Officials),
                ExistsType = ExistsSearchCondition<Government>.ExistsTypes.Exists,
                Condition = new LongSearchCondition<Official>()
                {
                    Field = nameof(Official.UserID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = SecurityProfile.UserID
                }
            });

            return await Task.Run(() => GovernmentSearch.GetReadOnlyReader(null, DefaultRetrievedFields).ToList());
        }
    }
}
