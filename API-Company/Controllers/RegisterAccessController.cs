using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [RegisterAccess]
    public class RegisterAccessController : DataObjectController<Register>
    {
        private Guid RegisterIdentifier => (Guid)Request.Properties["RegisterIdentifier"];

        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<Register>(r => new List<object>()
        {
            r.RegisterID,
            r.Name,
            r.Identifier,
            r.CurrentStatus.RegisterStatusID,
            r.CurrentStatus.ChangeTime,
            r.CurrentStatus.Status,
            r.CurrentStatus.Initiator
        });

        public override ISearchCondition GetBaseSearchCondition()
        {
            return new GuidSearchCondition<Register>()
            {
                Field = nameof(Register.Identifier),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = RegisterIdentifier
            };
        }

        [HttpGet]
        public async Task<Register> Get()
        {
            return new Search<Register>(GetBaseSearchCondition()).GetReadOnly(null, await FieldsToRetrieve());
        }

        [HttpGet]
        [RegisterAccess(RequireRegisterIdentifier = false)]
        public async Task<IHttpActionResult> GetByIdentifier(string id)
        {
            if (!Request.Headers.Contains("PlayerName"))
            {
                return new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this);
            }

            string username = Request.Headers.GetValues("PlayerName").First();

            if (!Guid.TryParse(id , out Guid identifier))
            {
                return BadRequest("id was not of the correct format");
            }

            Search<Register> registerSearch = new Search<Register>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new GuidSearchCondition<Register>()
                {
                    Field = nameof(Register.Identifier),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = identifier
                },
                new ExistsSearchCondition<Register>()
                {
                    RelationshipName = $"{nameof(Register.Location)}.{nameof(Location.LocationEmployees)}",
                    ExistsType = ExistsSearchCondition<Register>.ExistsTypes.Exists,
                    Condition = new StringSearchCondition<LocationEmployee>()
                    {
                        Field = $"{nameof(LocationEmployee.Employee)}.{nameof(Employee.User)}.{nameof(WebModels.security.User.Username)}",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = username
                    }
                }));

            Register register = registerSearch.GetReadOnly(null, await FieldsToRetrieve());
            return register == null ? (IHttpActionResult)NotFound() : Ok(register);
        }
    }
}
