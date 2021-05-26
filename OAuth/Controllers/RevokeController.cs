using ClussPro.ObjectBasedFramework.DataSearch;
using OAuth.Models.auth;
using System;
using System.Web.Mvc;

namespace OAuth.Controllers
{
    public class RevokeController : Controller
    {
        [HttpPost]
        public ActionResult Index(string reason)
        {
            string authorizationHeader = Request.Headers.Get("Authorization");
            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.Contains("Bearer "))
            {
                return Error(401, null, null);
            }

            string tokenString = authorizationHeader.Replace("Bearer ", "");
            if (!Guid.TryParse(tokenString, out Guid token))
            {
                return Error(400, "invalid_request", "Malformed token");
            }

            Search<Token> tokenSearch = new Search<Token>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new GuidSearchCondition<Token>()
                {
                    Field = "AccessToken",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = token
                },
                new DateTimeSearchCondition<Token>()
                {
                    Field = "RevokeTime",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Null
                },
                new DateTimeSearchCondition<Token>()
                {
                    Field = "Expiration",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Greater,
                    Value = DateTime.Now
                },
                new BooleanSearchCondition<Token>()
                {
                    Field = "RefreshTokenUsed",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = false
                }));

            Token foundToken = tokenSearch.GetEditable();
            if (foundToken == null)
            {
                return Error(401, "invalid_token", "The access token provided is expired, revoked, malformed, or invalid for other reasons.");
            }

            foundToken.RevokeTime = DateTime.Now;
            foundToken.RevokeReason = reason;
            
            if (!foundToken.Save())
            {
                return Error(500, "server_error", "An error occurred processing the request");
            }

            return new HttpStatusCodeResult(200);
        }

        private ActionResult Error(int code, string error, string error_description)
        {
            string authenticateHeader = "Bearer";

            if (error != null)
            {
                authenticateHeader += ",error=" + error;
            }

            if (error_description != null)
            {
                authenticateHeader += ",error_description=" + error_description;
            }

            Response.Headers.Add("WWW-Authenticate", authenticateHeader);

            return new HttpStatusCodeResult(code);
        }
    }
}