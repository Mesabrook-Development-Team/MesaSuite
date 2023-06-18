using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.ModelBinding;
using WebModels.auth;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    public class PersonalAccessTokenController : DataObjectController<PersonalAccessToken>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<PersonalAccessToken>(pat => new List<object>()
        {
            pat.PersonalAccessTokenID,
            pat.UserID,
            pat.Name,
            pat.Expiration,
            pat.CanRefreshInactivity,
            pat.CanPerformNetworkPrinting
        });

        public override ISearchCondition GetBaseSearchCondition()
        {
            return new LongSearchCondition<PersonalAccessToken>()
            {
                Field = nameof(PersonalAccessToken.UserID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = SecurityProfile.UserID
            };
        }

        public override bool AllowGetAll => true;

        [HttpPost]
        public override async Task<IHttpActionResult> Post(PersonalAccessToken dataObject)
        {
            dataObject.UserID = SecurityProfile.UserID;
            if (!dataObject.Save())
            {
                return dataObject.HandleFailedValidation(this);
            }

            List<string> fields = new List<string>(await FieldsToRetrieve()) { nameof(PersonalAccessToken.Token) };
            return Created($"Get/" + dataObject.PersonalAccessTokenID, DataObject.GetReadOnlyByPrimaryKey<PersonalAccessToken>(dataObject.PersonalAccessTokenID, null, fields));
        }
    }
}