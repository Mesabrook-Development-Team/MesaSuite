using System;
using System.Collections.Generic;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework;
using WebModels.mesasys;
using WebModels.security;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("system")]

    public class CrashController : DataObjectController<CrashReport>
    {
        public override IEnumerable<string> AllowedFields => new string[]
        {
            nameof(CrashReport.CrashReportID),
            nameof(CrashReport.Program),
            nameof(CrashReport.Time),
            nameof(CrashReport.User),
            nameof(CrashReport.Exception)
        };

        public override bool AllowGetAll => true;

        [HttpPost]
        [OverrideActionFilters]
        [MesabrookAuthorization]
        [ProgramAccess(null)]
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