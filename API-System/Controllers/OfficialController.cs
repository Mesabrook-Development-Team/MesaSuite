using API.Common;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebModels.gov;

namespace API_System.Controllers
{
    public class OfficialController : DataObjectController<Official>
    {
        public override IEnumerable<string> AllowedFields => new List<string>()
        {
            nameof(Official.OfficialID),
            nameof(Official.GovernmentID),
            nameof(Official.UserID),
            nameof(Official.ManageEmails),
            nameof(Official.ManageOfficials)
        };

        [HttpGet]
        public List<Official> GetOfficialsForGovernment(long id)
        {
            List<string> fields = Schema.GetSchemaObject<Official>().GetFields().Select(f => $"Officials.{f.FieldName}").ToList();
            return DataObject.GetReadOnlyByPrimaryKey<Government>(id, null, AllowedFields).Officials.ToList();
        }
    }
}