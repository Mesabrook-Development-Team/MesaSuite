using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.mesasys
{
    [Table("333E9844-B57E-4A52-BBE4-74285CC6873A")]
    public class DiscordEmbed : DataObject
    {
        protected DiscordEmbed() : base() { }

        private long? _discordEmbedID;
        [Field("8461A2E7-741C-4628-A985-2F5692AD81AB")]
        public long? DiscordEmbedID
        {
            get { CheckGet(); return _discordEmbedID; }
            set { CheckSet(); _discordEmbedID = value; }
        }

        private string _description;
        [Field("F176D3F3-9858-40C2-94A3-55BC3C70C00E", DataSize = 100)]
        public string Description
        {
            get { CheckGet(); return _description; }
            set { CheckSet(); _description = value; }
        }

        private long _color;
        [Field("A4139091-8465-4309-891B-57D76F0EB724")]
        public long Color
        {
            get { CheckGet(); return _color; }
            set { CheckSet(); _color = value; }
        }

        private string _uRL;
        [Field("2CA040DC-1A00-4A7F-B6E8-F3345A2E6DD0", DataSize = 255)]
        public string URL
        {
            get { CheckGet(); return _uRL; }
            set { CheckSet(); _uRL = value; }
        }

        private string _authorName;
        [Field("3C50DE5A-BD06-48A8-8DFB-C7568002AB92", DataSize = 50)]
        public string AuthorName
        {
            get { CheckGet(); return _authorName; }
            set { CheckSet(); _authorName = value; }
        }

        private string _authorURL;
        [Field("C144B2C2-F799-4413-80A6-EF1B4C2982C1", DataSize = 255)]
        public string AuthorURL
        {
            get { CheckGet(); return _authorURL; }
            set { CheckSet(); _authorURL = value; }
        }

        private string _authorIconURL;
        [Field("2A3A40FC-501F-477B-BEC7-E08A99A5F9A2", DataSize = 255)]
        public string AuthorIconURL
        {
            get {  CheckGet(); return _authorIconURL; }
            set { CheckSet(); _authorIconURL = value; }
        }

        private string _thumbnailURL;
        [Field("934EFE1C-26D3-46BD-A5EA-B716D03C01A1", DataSize = 255)]
        public string ThumbnailURL
        {
            get { CheckGet(); return _thumbnailURL; }
            set { CheckSet(); _thumbnailURL = value; }
        }

        private string _imageURL;
        [Field("0C5E9FF3-443A-4FBD-BE59-AD38B8BF9A27", DataSize = 255)]
        public string ImageURL
        {
            get { CheckGet(); return _imageURL; }
            set { CheckSet(); _imageURL = value; }
        }

        private string _footerText;
        [Field("2C06F05E-4711-4C5F-99A3-9E7AE1C8B3C3", DataSize = 100)]
        public string FooterText
        {
            get {  CheckGet(); return _footerText; }
            set { CheckSet(); _footerText = value; }
        }

        private string _footerIconURL;
        [Field("E4ACA1A8-1BEC-4F48-BA64-6F8158B2C864", DataSize = 255)]
        public string FooterIconURL
        {
            get { CheckGet(); return _footerIconURL; }
            set { CheckSet(); _footerIconURL = value; }
        }

        private string _title;
        [Field("9627815F-1F34-47B6-99D2-00BCBC9279C4", DataSize = 100)]
        public string Title
        {
            get { CheckGet(); return _title; }
            set { CheckSet(); _title = value; }
        }

        #region Relationships
        #region mesasys
        private List<DiscordEmbedField> _discordEmbedFields = new List<DiscordEmbedField>();
        [RelationshipList("CDF40C0F-57F7-47F2-A74B-2A785D2620D2", nameof(DiscordEmbedField.DiscordEmbedID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<DiscordEmbedField> DiscordEmbedFields
        {
            get { CheckGet(); return _discordEmbedFields; }
        }

        private List<OutboundDiscord> _outboundDiscords = new List<OutboundDiscord>();
        [RelationshipList("C1277CC0-7BC8-4CA4-B377-039CB2C3A507", nameof(OutboundDiscord.DiscordEmbedID), AutoRemoveReferences = true)]
        public IReadOnlyCollection<OutboundDiscord> OutboundDiscords
        {
            get { CheckGet(); return _outboundDiscords; }
        }

        private List<NotificationSubscriber> _notificationSubscribers = new List<NotificationSubscriber>();
        [RelationshipList("B7EC50CA-B6C9-4B78-A440-60431792AFAC", nameof(NotificationSubscriber.DiscordEmbedID), AutoRemoveReferences = true)]
        public IReadOnlyCollection<NotificationSubscriber> NotificationSubscribers
        {
            get { CheckGet(); return _notificationSubscribers; }
        }
        #endregion
        #endregion
    }
}