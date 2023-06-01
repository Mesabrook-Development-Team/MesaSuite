using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.auth;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    public class ClientController : DataObjectController<Client>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<Client>(c => new List<object>()
        {
            c.ClientID,
            c.ClientIdentifier,
            c.Type,
            c.ClientName,
            c.UserCount,
            c.RedirectionURI
        });

        public override ISearchCondition GetBaseSearchCondition()
        {
            return new LongSearchCondition<Client>()
            {
                Field = nameof(Client.UserID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = SecurityProfile.UserID
            };
        }

        public override bool AllowGetAll => true;

        [HttpDelete]
        public override IHttpActionResult Delete(long id)
        {
            Search<Client> clientSearch = new Search<Client>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Client>()
                {
                    Field = nameof(Client.ClientID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                },
                GetBaseSearchCondition()));
            Client client = clientSearch.GetEditable();
            if (client == null)
            {
                return NotFound();
            }

            Search<Token> tokens = new Search<Token>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Token>()
                {
                    Field = nameof(Token.ClientID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = client.ClientID
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

            foreach(Token token in tokens.GetReadOnlyReader(null, new[] { nameof(Token.UserID), nameof(Token.ClientID) }))
            {
                UserController.NotifyOAuthServerOfProgramChanges("RemoveApp", $"userid={token.UserID}&clientid={token.ClientID}");
            }

            if (!client.Delete())
            {
                return client.HandleFailedValidation(this);
            }

            return Ok();
        }

        protected override void PrePostCommit(Client dataObject)
        {
            base.PrePostCommit(dataObject);
            dataObject.UserID = SecurityProfile.UserID;
        }
    }
}