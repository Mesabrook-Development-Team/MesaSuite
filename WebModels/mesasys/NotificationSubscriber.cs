using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebModels.security;

namespace WebModels.mesasys
{
    [Table("9A2D528D-25D3-4137-8FB2-1246E3A48C17")]
    [Unique(new[] { nameof(NotificationEventID), nameof(UserID)})]
    public class NotificationSubscriber : DataObject
    {
        protected NotificationSubscriber() : base() { }

        private long? _notificationSubscriberID;
        [Field("9F0F7C7A-5B6F-4F8D-8B7C-8A8E9B9A9A9A")]
        public long? NotificationSubscriberID
        {
            get { CheckGet(); return _notificationSubscriberID; }
            set { CheckSet(); _notificationSubscriberID = value; }
        }

        private long? _notificationEventID;
        [Field("4D7F8228-C1C4-4480-8987-14966DC66BB5")]
        [Required]
        public long? NotificationEventID
        {
            get { CheckGet(); return _notificationEventID; }
            set { CheckSet(); _notificationEventID = value; }
        }

        private NotificationEvent _notificationEvent = null;
        [Relationship("22D3861D-4753-4E8C-A517-B06818F439E9")]
        public NotificationEvent NotificationEvent
        {
            get { CheckGet(); return _notificationEvent; }
        }

        private long? _userID;
        [Field("7BBDAF6A-C8E2-4D2A-BE77-C9D0458EE5F4")]
        [Required]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

        private User _user = null;
        [Relationship("37B28F31-F53F-40F5-95C4-2C0759C9A39B")]
        public User User
        {
            get { CheckGet(); return _user; }
        }

        private string _notificationText;
        [Field("64DC4C63-9E9A-4401-B1A1-1B4724F1FEF6", DataSize = 1000)]
        [Required]
        public string NotificationText
        {
            get { CheckGet(); return _notificationText; }
            set { CheckSet(); _notificationText = value; }
        }

        private bool _useDiscord;
        [Field("2C20E439-7597-441F-899F-84B83E5432DE")]
        public bool UseDiscord
        {
            get { CheckGet(); return _useDiscord; }
            set { CheckSet(); _useDiscord = value; }
        }

        private string _discordDMUserID;
        [Field("288E67A1-BD21-4474-8171-A11BB000310B", DataSize = 20)]
        public string DiscordDMUserID
        {
            get { CheckGet(); return _discordDMUserID; }
            set { CheckSet(); _discordDMUserID = value; }
        }

        private string _discordChannelID;
        [Field("A084965E-C9B3-4E61-BF69-F85747596A97", DataSize = 20)]
        public string DiscordChannelID
        {
            get { CheckGet(); return _discordChannelID; }
            set { CheckSet(); _discordChannelID = value; }
        }

        private string _discordPingRoleID;
        [Field("28584F83-94B0-4ADD-BFB3-B785F703BAC3", DataSize = 20)]
        public string DiscordPingRoleID
        {
            get { CheckGet(); return _discordPingRoleID; }
            set { CheckSet(); _discordPingRoleID = value; }
        }

        private string _discordPingUserID;
        [Field("DBDCDB61-7D5A-45A0-81F0-E3CD1D706903", DataSize = 20)]
        public string DiscordPingUserID
        {
            get { CheckGet(); return _discordPingUserID; }
            set { CheckSet(); _discordPingUserID = value; }
        }

        private string _discordContent;
        [Field("7C4B1626-AFE7-4792-8E3A-3FD012AF95E7", DataSize = 1000)]
        public string DiscordContent
        {
            get { CheckGet(); return _discordContent; }
            set { CheckSet(); _discordContent = value; }
        }

        private long? _discordEmbedID;
        [Field("67B24726-4757-49FB-AA49-DBA99264DD13")]
        public long? DiscordEmbedID
        {
            get { CheckGet(); return _discordEmbedID; }
            set { CheckSet(); _discordEmbedID = value; }
        }

        private DiscordEmbed _discordEmbed = null;
        [Relationship("506BC6D4-59F0-4F4F-A8F5-6A07859A5F97")]
        public DiscordEmbed DiscordEmbed
        {
            get { CheckGet(); return _discordEmbed; }
        }

        private bool _useEmail;
        [Field("5BCBF650-B5B2-4782-A519-F3CDDE85DD01")]
        public bool UseEmail
        {
            get { CheckGet(); return _useEmail; }
            set { CheckSet(); _useEmail = value; }
        }

        private string _emailFromName;
        [Field("B2DD944C-0E43-409F-87FB-B9AEF3CCE9E6", DataSize = 100)]
        [RequiredWhen(nameof(UseEmail), true)]
        public string EmailFromName
        {
            get { CheckGet(); return _emailFromName; }
            set { CheckSet(); _emailFromName = value; }
        }

        private string _emailFromEmail;
        [Field("6A038E1A-795D-4197-B36A-C544ECF1C4A7", DataSize = 255)]
        [RequiredWhen(nameof(UseEmail), true)]
        public string EmailFromEmail
        {
            get { CheckGet(); return _emailFromEmail; }
            set { CheckSet(); _emailFromEmail = value; }
        }

        private string _emailTo;
        [Field("D1D4CAF0-4A22-4763-B4D1-3A828CB2182A", DataSize = 255)]
        [RequiredWhen(nameof(UseEmail), true)]
        public string EmailTo
        {
            get { CheckGet(); return _emailTo; }
            set { CheckSet(); _emailTo = value; }
        }

        private string _emailSubject;
        [Field("87283136-65A2-42A1-90A3-90565CE9CAFB", DataSize = 50)]
        [RequiredWhen(nameof(UseEmail), true)]
        public string EmailSubject
        {
            get { CheckGet(); return _emailSubject; }
            set { CheckSet(); _emailSubject = value; }
        }

        private string _emailBody;
        [Field("89E62751-8E54-4DE9-9880-0049FEE1D51B", DataSize = 4000)]
        [RequiredWhen(nameof(UseEmail), true)]
        public string EmailBody
        {
            get { CheckGet(); return _emailBody; }
            set { CheckSet(); _emailBody = value; }
        }

        private bool _isReportableInGame;
        [Field("140AE24A-464B-4CE1-A76F-53AA7D7CC0AD")]
        public bool IsReportableInGame
        {
            get { CheckGet(); return _isReportableInGame; }
            set { CheckSet(); _isReportableInGame = value; }
        }

        private bool _markReadAfterDelivery;
        [Field("883566F1-9B07-4D56-8A79-BFF7181C373F")]
        public bool MarkReadAfterDelivery
        {
            get { CheckGet(); return _markReadAfterDelivery; }
            set { CheckSet(); _markReadAfterDelivery = value; }
        }

        #region Relationships
        #region mesasys
        private List<Notification> _notifications = new List<Notification>();
        [RelationshipList("46CD982B-41A6-40F4-822B-74B3A88AB57A", nameof(Notification.NotificationSubscriberID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<Notification> Notifications
        {
            get { CheckGet(); return _notifications; }
        }

        private List<NotificationSubscriberEntity> _notificationSubscriberEntities = new List<NotificationSubscriberEntity>();
        [RelationshipList("FBE4C5A7-7082-414C-8B0C-0A643FDCFCB0", nameof(NotificationSubscriberEntity.NotificationSubscriberID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<NotificationSubscriberEntity> NotificationSubscriberEntities
        {
            get { CheckGet(); return _notificationSubscriberEntities; }
        }
        #endregion
        #endregion

        public void SendNotification<TBaseObject>(TBaseObject baseObject) where TBaseObject : DataObject
        {
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                Notification notification = DataObjectFactory.Create<Notification>();
                notification.NotificationSubscriberID = NotificationSubscriberID;
                notification.NotificationTime = DateTime.Now;
                notification.Message = Unbind(NotificationText, baseObject);
                notification.IsReportableInGame = IsReportableInGame;
                notification.Save(transaction);

                if (UseDiscord)
                {
                    OutboundDiscord outboundDiscord = DataObjectFactory.Create<OutboundDiscord>();
                    outboundDiscord.DMUserID = DiscordDMUserID;
                    outboundDiscord.ChannelID = DiscordChannelID;
                    outboundDiscord.PingRoleID = DiscordPingRoleID;
                    outboundDiscord.PingUserID = DiscordPingUserID;
                    outboundDiscord.Content = Unbind(DiscordContent, baseObject);

                    if (DiscordEmbedID != null)
                    {
                        DiscordEmbed outboundEmbed = DataObjectFactory.Create<DiscordEmbed>();
                        DiscordEmbed.Copy(outboundEmbed);
                        outboundEmbed.Description = Unbind(outboundEmbed.Description, baseObject);
                        outboundEmbed.URL = Unbind(outboundEmbed.URL, baseObject);
                        outboundEmbed.AuthorName = Unbind(outboundEmbed.AuthorName, baseObject);
                        outboundEmbed.AuthorURL = Unbind(outboundEmbed.AuthorURL, baseObject);
                        outboundEmbed.AuthorIconURL = Unbind(outboundEmbed.AuthorIconURL, baseObject);
                        outboundEmbed.ThumbnailURL = Unbind(outboundEmbed.ThumbnailURL, baseObject);
                        outboundEmbed.ImageURL = Unbind(outboundEmbed.ImageURL, baseObject);
                        outboundEmbed.FooterText = Unbind(outboundEmbed.FooterText, baseObject);
                        outboundEmbed.FooterIconURL = Unbind(outboundEmbed.FooterIconURL, baseObject);
                        outboundEmbed.Title = Unbind(outboundEmbed.Title, baseObject);
                        if (outboundEmbed.Save(transaction))
                        {
                            if (DiscordEmbed.DiscordEmbedFields != null)
                            {
                                foreach (DiscordEmbedField discordEmbedField in DiscordEmbed.DiscordEmbedFields)
                                {
                                    DiscordEmbedField outboundField = DataObjectFactory.Create<DiscordEmbedField>();
                                    discordEmbedField.Copy(outboundField);
                                    discordEmbedField.DiscordEmbedID = outboundEmbed.DiscordEmbedID;
                                    discordEmbedField.Name = Unbind(discordEmbedField.Name, baseObject);
                                    discordEmbedField.Value = Unbind(discordEmbedField.Value, baseObject);
                                    discordEmbedField.Save(transaction);
                                }
                            }

                            outboundDiscord.DiscordEmbedID = outboundEmbed.DiscordEmbedID;
                        }

                        outboundDiscord.Save(transaction);
                    }
                }

                if (UseEmail)
                {
                    OutboundEmail outboundEmail = DataObjectFactory.Create<OutboundEmail>();
                    outboundEmail.FromName = Unbind(EmailFromName, baseObject);
                    outboundEmail.FromEmail = Unbind(EmailFromEmail, baseObject);
                    outboundEmail.To = Unbind(EmailTo, baseObject);
                    outboundEmail.Subject = Unbind(EmailSubject, baseObject);
                    outboundEmail.Body = Unbind(EmailBody, baseObject);
                    outboundEmail.Save(transaction);
                }
            }
        }

        private string Unbind<T>(string textWithBinding, T obj) where T : DataObject
        {
            string unboundText = textWithBinding;
            string[] availableBindings = NotificationEvent.Parameters.Split(',');
            foreach(string key in availableBindings)
            {
                unboundText = unboundText.Replace($"{{{key}}}", obj.GetValue(key)?.ToString() ?? "");
            }

            return unboundText;
        }
    }
}
