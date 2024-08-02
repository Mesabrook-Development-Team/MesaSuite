using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Utility;
using System.Collections.Generic;
using System.Linq;
using WebModels.mesasys;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    public class NotificationSubscriberEntityController : DataObjectController<NotificationSubscriberEntity>
    {
        public override IEnumerable<string> DefaultRetrievedFields => Schema.GetSchemaObject<NotificationSubscriberEntity>().GetFields().Select(f => f.FieldName);

        public override ISearchCondition GetBaseSearchCondition()
        {
            return new LongSearchCondition<NotificationSubscriberEntity>()
            {
                Field = FieldPathUtility.CreateFieldPathsAsList<NotificationSubscriberEntity>(nse => new List<object>() { nse.NotificationSubscriber.UserID }).First(),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = SecurityProfile.UserID
            };
        }
    }
}
