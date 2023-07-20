using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Common;
using API.Common.Attributes;
using API.Common.Cache;
using API_Government.App_Code;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.gov;

namespace API_Government.Controllers
{
    public class LawSectionController : DataObjectController<LawSection>
    {
        protected long? GovernmentID
        {
            get
            {
                if (Request.Headers.Contains("GovernmentID") && long.TryParse(Request.Headers.GetValues("GovernmentID").First(), out long governmentID))
                {
                    return governmentID;
                }

                return null;
            }
        }

        protected long? UserID
        {
            get
            {
                if (MesabrookAuthorizationAttribute.CheckHeadersForSecurity(ActionContext).Result != null)
                {
                    return null;
                }

                SecurityProfile profile = SecurityCache.Get(Request.Headers.Authorization.Parameter);
                if (profile == null)
                {
                    return null;
                }

                if (!ProgramCache.UserHasProgram(profile.UserID, "gov").Result)
                {
                    return null;
                }

                return profile.UserID;
            }
        }

        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<LawSection>(ls => new List<object>()
        {
            ls.LawSectionID,
            ls.LawID,
            ls.Title,
            ls.Detail,
            ls.DisplayOrder
        });

        public LawSectionController() : base()
        {
            PostSecurityCheck += LawSectionController_OwnerSecurityCheck;
            PutSecurityCheck += LawSectionController_OwnerSecurityCheck;
            PatchSecurityCheck += LawSectionController_OwnerSecurityCheck;
            DeleteSecurityCheck += LawSectionController_OwnerSecurityCheck;
        }

        private void LawSectionController_OwnerSecurityCheck(object sender, SecurityCheckEventArgs e)
        {
            long? userID = UserID;
            long? governmentID = GovernmentID;

            if (userID == null || governmentID == null)
            {
                e.IsValid = false;
                return;
            }

            OfficialCache.CachedOfficial cachedOfficial = OfficialCache.GetCachedOfficial(governmentID.Value, userID.Value).Result;
            if (cachedOfficial.OfficialID == 0 || !cachedOfficial.Permissions.Contains(nameof(Official.ManageLaws)))
            {
                e.IsValid = false;
                return;
            }

            LawSection lawSection = DataObject.GetReadOnlyByPrimaryKey<LawSection>(e.ObjectID, e.Transaction, new[] { $"{nameof(LawSection.Law)}.{nameof(Law.GovernmentID)}" });
            if (lawSection.Law.GovernmentID != governmentID)
            {
                e.IsValid = false;
                return;
            }
        }
    }
}