using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework;
using WebModels.mesasys;
using WebModels.security;

namespace API_System.Controllers
{
    [MesabrookAuthorization]

    public class CrashController : DataObjectController<CrashReport>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new string[]
        {
            nameof(CrashReport.CrashReportID),
            nameof(CrashReport.Program),
            nameof(CrashReport.Time),
            nameof(CrashReport.User),
            nameof(CrashReport.Exception)
        };

        public override bool AllowGetAll => true;

        [ProgramAccess("system")]
        public override Task<IHttpActionResult> GetAll()
        {
            return base.GetAll();
        }

        [ProgramAccess("system")]
        public override Task<CrashReport> Get(long id)
        {
            return base.Get(id);
        }

        [ProgramAccess("system")]
        public override Task<IHttpActionResult> Put(CrashReport dataObject)
        {
            return base.Put(dataObject);
        }

        [ProgramAccess("system")]
        public override Task<IHttpActionResult> Post(CrashReport dataObject)
        {
            return base.Post(dataObject);
        }

        [ProgramAccess("system")]
        public override IHttpActionResult Delete(long id)
        {
            return base.Delete(id);
        }

        [ProgramAccess("system")]
        public override Task<IHttpActionResult> Patch(PatchData patchData)
        {
            return base.Patch(patchData);
        }

        [HttpPost]
        public void Report(CrashReport crashReport)
        {
            SecurityProfile profile = Request.Properties["SecurityProfile"] as SecurityProfile;

            User user = DataObject.GetReadOnlyByPrimaryKey<User>(profile.UserID, null, new string[] { "Username" });
            crashReport.Time = DateTime.Now;
            crashReport.User = user.Username;

            crashReport.Save();
        }
    }
}