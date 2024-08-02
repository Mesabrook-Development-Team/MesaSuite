using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using System.Collections.Generic;
using System.Linq;
using WebModels.mesasys;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    public class NotificationSubscriberController : DataObjectController<NotificationSubscriber>
    {
        public override IEnumerable<string> DefaultRetrievedFields => Schema.GetSchemaObject<NotificationSubscriber>().GetFields().Select(f => f.FieldName)
                                                                        .Concat(Schema.GetSchemaObject<NotificationSubscriberEntity>().GetFields().Select(f => nameof(NotificationSubscriber.NotificationSubscriberEntities) + "." + f.FieldName))
                                                                        .Concat(Schema.GetSchemaObject<DiscordEmbed>().GetFields().Select(f => nameof(NotificationSubscriber.DiscordEmbed) + "." + f.FieldName))
                                                                        .Concat(Schema.GetSchemaObject<DiscordEmbedField>().GetFields().Select(f => nameof(NotificationSubscriber.DiscordEmbed) + "." + nameof(DiscordEmbed.DiscordEmbedFields) + "." + f.FieldName));

        public override ISearchCondition GetBaseSearchCondition()
        {
            return new LongSearchCondition<NotificationSubscriber>()
            {
                Field = nameof(NotificationSubscriber.UserID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = SecurityProfile.UserID
            };
        }

        public override bool AllowGetAll => true;

        protected override void PrePostCommit(NotificationSubscriber dataObject)
        {
            dataObject.UserID = SecurityProfile.UserID;
            base.PrePostCommit(dataObject);
        }
    }
}
