using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using API.Common.Extensions;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.security;

namespace API_System.Controllers
{
    public class InactivityController : ApiController
    {
#if DEBUG
        [EnableCors("*", "*", "*")]
#else
        [EnableCors("https://mesabrook.com,https://www.mesabrook.com", "*", "*")]
#endif
        [HttpPut]
        public IHttpActionResult ResetInactivity(ResetInactivityParameter parameter)
        {
            if (string.IsNullOrEmpty(parameter.username))
            {
                return BadRequest("Username is a required field");
            }

            Search<User> userSearch = new Search<User>(new StringSearchCondition<User>()
            {
                Field = nameof(WebModels.security.User.Username),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = parameter.username
            });

            User user = userSearch.GetEditable();
            if (user == null)
            {
                return BadRequest("User not found");
            }

            user.InactivityWarningServed = false;
            user.LastActivity = DateTime.Now;
            user.LastActivityReason = parameter.reason;
            if (!user.Save())
            {
                return user.HandleFailedValidation(this);
            }

            return Ok();
        }

        private IHttpActionResult ErrorJson(Dictionary<string, string> errors)
        {
            return Json(new
            {
                error = "bad_request",
                error_description = errors
            });
        }

        public class ResetInactivityParameter
        {
            public string username { get; set; }
            public string reason { get; set; }
        }
    }
}