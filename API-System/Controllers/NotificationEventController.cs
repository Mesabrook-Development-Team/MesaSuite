using API.Common;
using API.Common.Attributes;
using API.Common.Cache;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebModels.mesasys;
using WebModels.security;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    public class NotificationEventController : ApiController
    {
        private IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<NotificationEvent>(ne => new List<object>()
        {
            ne.NotificationEventID,
            ne.Category,
            ne.ScopeType,
            ne.Name,
            ne.Parameters,
            ne.DefaultNotificationText,
            ne.SystemID,
            ne.UserIDOwner,
            ne.UserOwner.Username
        });

        [HttpGet]
        public async Task<List<NotificationEvent>> GetAllForUser()
        {
            SecurityProfile securityProfile = (SecurityProfile)Request.Properties["SecurityProfile"];
            return await NotificationEvent.GetNotificationEventsForUserID(securityProfile.UserID, DefaultRetrievedFields);
        }
    }
}