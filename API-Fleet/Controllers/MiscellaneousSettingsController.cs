using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using API_Fleet.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "gov", "company" })]
    public class MiscellaneousSettingsController : DataObjectController<MiscellaneousSettings>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<MiscellaneousSettings>(ms => new List<object>()
        {
            ms.MiscellaneousSettingsID,
            ms.CompanyID,
            ms.GovernmentID,
            ms.EmailImplementationIDCarReleased,
            ms.EmailImplementationIDLocomotiveReleased,
            ms.EmailImplementationIDLeaseRequestAvailable,
            ms.EmailImplementationIDLeaseBidReceived
        });

        public override ISearchCondition GetBaseSearchCondition()
        {
            return new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<MiscellaneousSettings>()
                {
                    Field = nameof(MiscellaneousSettings.CompanyID),
                    SearchConditionType = this.CompanyID() == null ? SearchCondition.SearchConditionTypes.Null : SearchCondition.SearchConditionTypes.Equals,
                    Value = this.CompanyID()
                },
                new LongSearchCondition<MiscellaneousSettings>()
                {
                    Field = nameof(MiscellaneousSettings.GovernmentID),
                    SearchConditionType = this.GovernmentID() == null ? SearchCondition.SearchConditionTypes.Null : SearchCondition.SearchConditionTypes.Equals,
                    Value = this.GovernmentID()
                });
        }

        [NonAction]
        public override Task<MiscellaneousSettings> Get(long id)
        {
            return null;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            Search<MiscellaneousSettings> miscSettingsSearch = new Search<MiscellaneousSettings>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<MiscellaneousSettings>()
                {
                    Field = nameof(MiscellaneousSettings.CompanyID),
                    SearchConditionType = this.CompanyID() == null ? SearchCondition.SearchConditionTypes.Null : SearchCondition.SearchConditionTypes.Equals,
                    Value = this.CompanyID()
                },
                new LongSearchCondition<MiscellaneousSettings>()
                {
                    Field = nameof(MiscellaneousSettings.GovernmentID),
                    SearchConditionType = this.GovernmentID() == null ? SearchCondition.SearchConditionTypes.Null : SearchCondition.SearchConditionTypes.Equals,
                    Value = this.GovernmentID()
                }));

            MiscellaneousSettings settings = miscSettingsSearch.GetReadOnly(null, await FieldsToRetrieve());
            if (settings == null)
            {
                settings = DataObjectFactory.Create<MiscellaneousSettings>();
                settings.CompanyID = this.CompanyID();
                settings.GovernmentID = this.GovernmentID();
                if (!settings.Save())
                {
                    return settings.HandleFailedValidation(this);
                }

                settings = DataObject.GetReadOnlyByPrimaryKey<MiscellaneousSettings>(settings.MiscellaneousSettingsID, null, await FieldsToRetrieve());
            }

            return Ok(settings);
        }

        [NonAction]
        public override Task<IHttpActionResult> Post(MiscellaneousSettings dataObject)
        {
            return null;
        }
    }
}