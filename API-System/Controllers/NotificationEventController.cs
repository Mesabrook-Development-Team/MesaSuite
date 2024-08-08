using API.Common;
using API.Common.Attributes;
using API.Common.Cache;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System.Collections.Generic;
using System.Linq;
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
            ne.IsPublished,
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

        [HttpGet]
        public async Task<List<NotificationEvent>> GetCustomNotificationsForUser()
        {
            SecurityProfile securityProfile = (SecurityProfile)Request.Properties["SecurityProfile"];
            Search<NotificationEvent> notificationEventSearch = new Search<NotificationEvent>(new LongSearchCondition<NotificationEvent>()
            {
                Field = nameof(NotificationEvent.UserIDOwner),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = securityProfile.UserID
            });

            return await Task.Run(() => notificationEventSearch.GetReadOnlyReader(null, DefaultRetrievedFields).ToList());
        }
    }
}