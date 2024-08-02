
using System.Collections.Generic;

namespace MesaSuite.Models.mesasys
{
    public class NotificationSubscriber
    {

        public long? NotificationSubscriberID { get; set; }

        public long? NotificationEventID { get; set; }

        public NotificationEvent NotificationEvent { get; }

        public long? UserID { get; set; }

        public string NotificationText { get; set; }

        public bool UseDiscord { get; set; }

        public string DiscordDMUserID { get; set; }

        public string DiscordChannelID { get; set; }

        public string DiscordPingRoleID { get; set; }

        public string DiscordPingUserID { get; set; }

        public string DiscordContent { get; set; }

        public long? DiscordEmbedID { get; set; }

        public DiscordEmbed DiscordEmbed { get; set; }

        public bool UseEmail { get; set; }

        public string EmailFromName { get; set; }

        public string EmailFromEmail { get; set; }

        public string EmailTo { get; set; }

        public string EmailSubject { get; set; }

        public string EmailBody { get; set; }

        public bool IsReportableInGame { get; set; }

        public bool MarkReadAfterDelivery { get; set; }

        public List<NotificationSubscriberEntity> NotificationSubscriberEntities { get; } = new List<NotificationSubscriberEntity>();
    }
}