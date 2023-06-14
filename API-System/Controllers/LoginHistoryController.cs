using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.auth;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    public class LoginHistoryController : ApiController
    {
        private long? UserID => ((SecurityProfile)Request.Properties["SecurityProfile"]).UserID;

        [HttpGet]
        public List<App> GetAppsForUser()
        {
            Search<Client> clientSearch = new Search<Client>(new ExistsSearchCondition<Client>()
            {
                RelationshipName = nameof(Client.UserClients),
                ExistsType = ExistsSearchCondition<Client>.ExistsTypes.Exists,
                Condition = new LongSearchCondition<UserClient>()
                {
                    Field = nameof(UserClient.UserID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = UserID
                }
            });

            List<string> fields = FieldPathUtility.CreateFieldPathsAsList<Client>(c => new List<object>()
            {
                c.ClientID,
                c.ClientName,
                c.Tokens.First().RevokeTime,
                c.Tokens.First().RefreshTokenUsed
            });

            List<App> apps = new List<App>();
            foreach(Client client in clientSearch.GetReadOnlyReader(null, fields))
            {
                App app = new App()
                {
                    ClientID = client.ClientID,
                    ClientName = client.ClientName,
                    CurrentlyLoggedIn = client.Tokens?.Any(t => t.RevokeTime == null && !t.RefreshTokenUsed) ?? false
                };
                apps.Add(app);
            }

            return apps;
        }

        [HttpGet]
        public List<History> GetLoginHistoryForApp(long? id)
        {
            Search<Token> tokenSearch = new Search<Token>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Token>()
                {
                    Field = nameof(Token.UserID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = UserID
                },
                new LongSearchCondition<Token>()
                {
                    Field = nameof(Token.ClientID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                }));
            tokenSearch.SearchOrders = new List<SearchOrder>()
            {
                new SearchOrder() { OrderField = nameof(Token.GrantTime), OrderDirection = SearchOrder.OrderDirections.Descending }
            };
            tokenSearch.Take = 50;

            List<string> fields = FieldPathUtility.CreateFieldPathsAsList<Token>(t => new List<object>()
            {
                t.GrantTime,
                t.ClientID,
                t.Client.ClientName,
                t.RevokeTime,
                t.RevokeReason,
                t.RefreshTokenUsed
            });

            List<History> histories = new List<History>();
            foreach(Token token in tokenSearch.GetReadOnlyReader(null, fields))
            {
                History history = new History()
                {
                    ClientID = token.ClientID,
                    ClientName = token.Client.ClientName,
                    GrantTime = token.GrantTime,
                    RevokeReason = token.RevokeReason,
                    RevokeTime = token.RevokeTime,
                    WasRefreshed = token.RefreshTokenUsed
                };
                histories.Add(history);
            }

            return histories;
        }

        [HttpGet]
        public List<History> GetAllRevokesForApp(long? id)
        {
            Search<Token> tokenSearch = new Search<Token>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Token>()
                {
                    Field = nameof(Token.UserID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = UserID
                },
                new LongSearchCondition<Token>()
                {
                    Field = nameof(Token.ClientID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                },
                new DateTimeSearchCondition<Token>()
                {
                    Field = nameof(Token.RevokeTime),
                    SearchConditionType = SearchCondition.SearchConditionTypes.NotNull
                }));
            tokenSearch.SearchOrders = new List<SearchOrder>()
            {
                new SearchOrder() { OrderField = nameof(Token.GrantTime), OrderDirection = SearchOrder.OrderDirections.Descending }
            };

            List<string> fields = FieldPathUtility.CreateFieldPathsAsList<Token>(t => new List<object>()
            {
                t.GrantTime,
                t.ClientID,
                t.Client.ClientName,
                t.RevokeTime,
                t.RevokeReason
            });

            List<History> histories = new List<History>();
            foreach (Token token in tokenSearch.GetReadOnlyReader(null, fields))
            {
                History history = new History()
                {
                    ClientID = token.ClientID,
                    ClientName = token.Client.ClientName,
                    GrantTime = token.GrantTime,
                    RevokeReason = token.RevokeReason,
                    RevokeTime = token.RevokeTime
                };
                histories.Add(history);
            }

            return histories;
        }

        [HttpPut]
        public IHttpActionResult LogOutFromApp(long? id)
        {
            int statusCode = UserController.NotifyOAuthServerOfProgramChanges("LogOutFromApp", $"userID={UserID}&clientID={id}");
            return StatusCode((HttpStatusCode)statusCode);
        }

        [HttpPut]
        public IHttpActionResult RemoveApp(long? id)
        {
            int statusCode = UserController.NotifyOAuthServerOfProgramChanges("RemoveApp", $"userid={UserID}&clientid={id}");
            return StatusCode((HttpStatusCode)statusCode);
        }

        public class App
        {
            public long? ClientID { get; set; }
            public string ClientName { get; set; }
            public bool CurrentlyLoggedIn { get; set; }
        }
        
        public class History
        {
            public long? ClientID { get; set; }
            public string ClientName { get; set; }
            public DateTime? GrantTime { get; set; }
            public DateTime? RevokeTime { get; set; }
            public bool WasRefreshed { get; set; }
            public string RevokeReason { get; set; }
        }
    }

}