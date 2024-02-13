using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [LocationAccess(RequiredPermissions = new[] { nameof(LocationEmployee.ManageRegisters) })]
    public class RegisterStatusController : DataObjectController<RegisterStatus>
    {
        private long LocationID => long.Parse(Request.Headers.GetValues("LocationID").First());

        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<RegisterStatus>(rs => new List<object>()
        {
            rs.RegisterStatusID,
            rs.RegisterID,
            rs.ChangeTime,
            rs.Status,
            rs.Initiator
        });

        public override ISearchCondition GetBaseSearchCondition()
        {
            return new LongSearchCondition<RegisterStatus>()
            {
                Field = FieldPathUtility.CreateFieldPathsAsList<RegisterStatus>(rs => new List<object>() { rs.Register.LocationID }).First(),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = LocationID
            };
        }

        [HttpGet]
        public async Task<List<RegisterStatus>> GetForRegister(long? id)
        {
            Search<RegisterStatus> statusSearch = new Search<RegisterStatus>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                GetBaseSearchCondition(),
                new LongSearchCondition<RegisterStatus>()
                {
                    Field = nameof(RegisterStatus.RegisterID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                }));
            statusSearch.Take = 50;

            return statusSearch.GetReadOnlyReader(null, await FieldsToRetrieve()).ToList();
        }

        [NonAction]
        public override Task<IHttpActionResult> Put(RegisterStatus dataObject)
        {
            return Task.FromResult<IHttpActionResult>(new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this));
        }

        [NonAction]
        public override Task<IHttpActionResult> Patch(PatchData patchData)
        {
            return Task.FromResult<IHttpActionResult>(new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this));
        }

        protected override void PrePostCommit(RegisterStatus dataObject)
        {
            base.PrePostCommit(dataObject);

            dataObject.ChangeTime = DateTime.Now;
            dataObject.Initiator = DataObject.GetReadOnlyByPrimaryKey<WebModels.security.User>(SecurityProfile.UserID, null, new[] { nameof(WebModels.security.User.Username) })?.Username;
        }
    }
}