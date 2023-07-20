using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using API.Common;
using API.Common.Attributes;
using API.Common.Cache;
using API_Government.App_Code;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.gov;

namespace API_Government.Controllers
{
    public class LawController : DataObjectController<Law>
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

        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<Law>(l => new List<object>()
        {
            l.LawID,
            l.GovernmentID,
            l.Government.Name,
            l.Name,
            l.DisplayOrder,
            l.LawSections.First().LawSectionID,
            l.LawSections.First().LawID,
            l.LawSections.First().Title,
            l.LawSections.First().Detail,
            l.LawSections.First().DisplayOrder
        });

        public LawController() : base()
        {
            PostSecurityCheck += LawController_OwnerSecurityCheck;
            PutSecurityCheck += LawController_OwnerSecurityCheck;
            PatchSecurityCheck += LawController_OwnerSecurityCheck;
            DeleteSecurityCheck += LawController_OwnerSecurityCheck;
        }

        private void LawController_OwnerSecurityCheck(object sender, SecurityCheckEventArgs e)
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

            Law law = DataObject.GetReadOnlyByPrimaryKey<Law>(e.ObjectID, e.Transaction, new[] { nameof(Law.GovernmentID) });
            if (law.GovernmentID != governmentID)
            {
                e.IsValid = false;
                return;
            }
        }

        public override bool AllowGetAll => true;

        [HttpGet]
        public async Task<List<Law>> GetForGovernment()
        {
            long? governmentID = GovernmentID;
            if (governmentID == null)
            {
                return new List<Law>();
            }

            Search<Law> lawSearch = new Search<Law>(new LongSearchCondition<Law>()
            {
                Field = nameof(Law.GovernmentID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = governmentID
            });
            return lawSearch.GetReadOnlyReader(null, await FieldsToRetrieve()).ToList();
        }

#if DEBUG
        [EnableCors("*", "*", "*")]
#else
        [EnableCors("https://mesabrook.com,https://www.mesabrook.com", "*", "*")]
#endif
        [HttpGet]
        public override Task<IHttpActionResult> GetAll()
        {
            return base.GetAll();
        }
    }
}