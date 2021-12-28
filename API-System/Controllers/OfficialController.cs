using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebModels.gov;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("system")]
    public class OfficialController : DataObjectController<Official>
    {
        public override IEnumerable<string> AllowedFields => new List<string>()
        {
            nameof(Official.OfficialID),
            nameof(Official.GovernmentID),
            nameof(Official.UserID),
            nameof(Official.ManageEmails),
            nameof(Official.ManageOfficials),
            nameof(Official.OfficialName)
        };

        [HttpGet]
        public List<Official> GetOfficialsForGovernment(long id)
        {
            List<string> fields = Schema.GetSchemaObject<Official>().GetFields().Select(f => $"Officials.{f.FieldName}").ToList();
            return DataObject.GetReadOnlyByPrimaryKey<Government>(id, null, fields).Officials.Where(o => o.ManageOfficials).ToList();
        }

        [HttpGet]
        public Official GetByUserID(long userID, long governmentID)
        {
            return new Search<Official>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Official>()
                {
                    Field = "GovernmentID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = governmentID
                },
                new LongSearchCondition<Official>()
                {
                    Field = "UserID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = userID
                })).GetReadOnly(null, AllowedFields);
        }
    }
}