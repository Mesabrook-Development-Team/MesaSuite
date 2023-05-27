using API.Common;
using API.Common.Attributes;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebModels.auth;

namespace OAuth.Controllers
{
    [AllowedIPsOnly]
    [PresharedAuth]
    public class CheckController : Controller
    {
        [HttpPost]
        public ActionResult UserHasBeenDeleted(long? userid)
        {
            if (userid == null)
            {
                return HttpNotFound();
            }

            Search<Token> tokenSearch = new Search<Token>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And, 
                new DateTimeSearchCondition<Token>()
                {
                    Field = nameof(Token.RevokeTime),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Null
                },
                new BooleanSearchCondition<Token>()
                {
                    Field = nameof(Token.RefreshTokenUsed),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = false
                },
                new LongSearchCondition<Token>()
                {
                    Field = nameof(Token.UserID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = userid
                }));

            Search<Code> codeSearch = new Search<Code>(new LongSearchCondition<Code>()
            {
                Field = nameof(Code.UserID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Null
            });

            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                foreach (Token token in tokenSearch.GetEditableReader(transaction))
                {
                    token.RevokeTime = DateTime.Now;
                    token.RevokeReason = "User deleted";
                    if (!token.Save(transaction))
                    {
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
                    }
                }

                foreach(Code code in codeSearch.GetEditableReader(transaction))
                {
                    if (!code.Delete(transaction))
                    {
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
                    }
                }

                transaction.Commit();
            }

            try
            {
                App_Code.SecurityCache.Revoke(userid.Value);
                return new HttpStatusCodeResult(200);
            }
            catch
            {
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult LogOutFromApp(long? userID, long? clientID)
        {
            Client client = DataObject.GetReadOnlyByPrimaryKey<Client>(clientID, null, new[] { nameof(Client.ClientIdentifier) });
            if (client == null)
            {
                return HttpNotFound();
            }

            Search<Token> tokenSearch = new Search<Token>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                   new DateTimeSearchCondition<Token>()
                   {
                       Field = nameof(Token.RevokeTime),
                       SearchConditionType = SearchCondition.SearchConditionTypes.Null
                   },
                   new BooleanSearchCondition<Token>()
                   {
                       Field = nameof(Token.RefreshTokenUsed),
                       SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                       Value = false
                   },
                   new LongSearchCondition<Token>()
                   {
                       Field = nameof(Token.UserID),
                       SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                       Value = userID
                   },
                   new LongSearchCondition<Token>()
                   {
                       Field = nameof(Token.ClientID),
                       SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                       Value = clientID
                   }));

            Search<Code> codeSearch = new Search<Code>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Code>()
                {
                    Field = nameof(Code.UserID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = userID
                },
                new GuidSearchCondition<Code>()
                {
                    Field = nameof(Code.ClientIdentifier),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = client.ClientIdentifier
                }));

            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                foreach (Token token in tokenSearch.GetEditableReader(transaction))
                {
                    token.RevokeTime = DateTime.Now;
                    token.RevokeReason = "User remotely logged out of app";
                    if (!token.Save(transaction))
                    {
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
                    }
                }

                foreach (Code code in codeSearch.GetEditableReader(transaction))
                {
                    if (!code.Delete(transaction))
                    {
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
                    }
                }

                transaction.Commit();
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult RemoveApp(FormCollection form)
        {
            if (!form.AllKeys.Contains("userid") || !form.AllKeys.Contains("clientid") ||
                !long.TryParse(form["userid"], out long userID) || !long.TryParse(form["clientid"], out long clientID))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Search<UserClient> userClientSearch = new Search<UserClient>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<UserClient>()
                {
                    Field = nameof(UserClient.UserID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = userID
                },
                new LongSearchCondition<UserClient>()
                {
                    Field = nameof(UserClient.ClientID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = clientID
                }));

            UserClient userClient = userClientSearch.GetEditable(readOnlyFields: new[] { $"{nameof(UserClient.Client)}.{nameof(Client.ClientIdentifier)}" });
            if (userClient == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }

            Search<Token> tokenSearch = new Search<Token>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Token>()
                {
                    Field = nameof(Token.UserID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = userID
                },
                new LongSearchCondition<Token>()
                {
                    Field = nameof(Token.ClientID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = clientID
                },
                new DateTimeSearchCondition<Token>()
                {
                    Field = nameof(Token.RevokeTime),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Null
                },
                new BooleanSearchCondition<Token>()
                {
                    Field = nameof(Token.RefreshTokenUsed),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = false
                }));

            Search<Code> codeSearch = new Search<Code>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new GuidSearchCondition<Code>()
                {
                    Field = nameof(Code.ClientIdentifier),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = userClient.Client.ClientIdentifier
                },
                new LongSearchCondition<Code>()
                {
                    Field = nameof(Code.UserID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = userID
                }));

            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                foreach(Token token in tokenSearch.GetEditableReader(transaction))
                {
                    SecurityCache.Revoke(token.AccessToken.ToString());

                    token.RevokeTime = DateTime.Now;
                    token.RevokeReason = "User removed access from app";
                    if (!token.Save(transaction))
                    {
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
                    }
                }

                foreach(Code code in codeSearch.GetEditableReader(transaction))
                {
                    if (!code.Delete(transaction))
                    {
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
                    }
                }

                if (!userClient.Delete(transaction))
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
                }

                transaction.Commit();
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
    }
}
