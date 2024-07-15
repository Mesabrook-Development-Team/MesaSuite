using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.security;

namespace WebModels.mesasys
{
    [Table("9A2D528D-25D3-4137-8FB2-1246E3A48C17")]
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

        private bool _useDiscordDM;
        [Field("2C20E439-7597-441F-899F-84B83E5432DE")]
        public bool UseDiscordDM
        {
            get { CheckGet(); return _useDiscordDM; }
            set { CheckSet(); _useDiscordDM = value; }
        }

        private string _discordDMText;
        [Field("353DEBF7-30BC-45B4-B52D-21D05B176FBC", DataSize = 1000)]
        public string DiscordDMText
        {
            get { CheckGet(); return _discordDMText; }
            set { CheckSet(); _discordDMText = value; }
        }

        private bool _useDiscordChannel;
        [Field("7BD4659F-5283-4FCB-AF65-22F1CC66331A")]
        public bool UseDiscordChannel
        {
            get { CheckGet(); return _useDiscordChannel; }
            set { CheckSet(); _useDiscordChannel = value; }
        }

        private string _discordChannelText;
        [Field("BFAF86B9-EA16-47B4-8278-BDF11C5496A8", DataSize = 1000)]
        public string DiscordChannelText
        {
            get { CheckGet(); return _discordChannelText; }
            set { CheckSet(); _discordChannelText = value; }
        }

        private bool _useEmail;
        [Field("5BCBF650-B5B2-4782-A519-F3CDDE85DD01")]
        public bool UseEmail
        {
            get { CheckGet(); return _useEmail; }
            set { CheckSet(); _useEmail = value; }
        }

        private string _emailText;
        [Field("0AD7B2AA-2882-441F-96C2-239E76E46E71", DataSize = 1000)]
        public string EmailText
        {
            get { CheckGet(); return _emailText; }
            set { CheckSet(); _emailText = value; }
        }

        private bool _useInGame;
        [Field("140AE24A-464B-4CE1-A76F-53AA7D7CC0AD")]
        public bool UseInGame
        {
            get { CheckGet(); return _useInGame; }
            set { CheckSet(); _useInGame = value; }
        }

        private string _inGameText;
        [Field("3B2DFA7C-D89E-4502-B47B-A1C16E30FE85", DataSize = 1000)]
        public string InGameText
        {
            get { CheckGet(); return _inGameText; }
            set { CheckSet(); _inGameText = value; }
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
        [RelationshipList("46CD982B-41A6-40F4-822B-74B3A88AB57A", nameof(Notification.NotificationSubscriberID))]
        public IReadOnlyCollection<Notification> Notifications
        {
            get { CheckGet(); return _notifications; }
        }
        #endregion
        #endregion
    }
}
