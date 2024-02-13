using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework;
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
    [ImmersibrookAccess]
    [RegisterAccess]
    public class RegisterAccessController : DataObjectController<Register>
    {
        private Guid RegisterIdentifier => (Guid)Request.Properties["RegisterIdentifier"];

        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<Register>(r => new List<object>()
        {
            r.RegisterID,
            r.LocationID,
            r.Name,
            r.Identifier,
            r.CurrentTaxRate,
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

        [HttpPost]
        public IHttpActionResult SetStatus(RegisterStatus status)
        {
            Register register = new Search<Register>(GetBaseSearchCondition()).GetReadOnly(null, new[] { nameof(Register.RegisterID) });

            status.RegisterID = register.RegisterID;
            status.ChangeTime = DateTime.Now;

            if (!status.Save())
            {
                return status.HandleFailedValidation(this);
            }

            return Created("RegisterStatus/Get/" + status.RegisterStatusID, status);
        }
    }
}
