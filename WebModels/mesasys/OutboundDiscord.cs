using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.mesasys
{
    [Table("D34EF778-42F0-4C60-B081-0BBCB4DE9F40")]
    public class OutboundDiscord : DataObject
    {
        protected OutboundDiscord() : base() { }

        private long? _outboundDiscordID;
        [Field("5ADFF476-8F01-4A16-B430-67B6199D959B")]
        public long? OutboundDiscordID
        {
            get { CheckGet(); return _outboundDiscordID; }
            set { CheckSet(); _outboundDiscordID = value; }
        }

        private string _dMUserID;
        [Field("16AA0F7D-B301-4673-93D5-81247E40EB71", DataSize = 20)]
        public string DMUserID
        {
            get { CheckGet(); return _dMUserID; }
            set { CheckSet(); _dMUserID = value; }
        }

        private string _channelID;
        [Field("C01E36B2-F814-45ED-8226-269BC5F6214C", DataSize = 20)]
        public string ChannelID
        {
            get { CheckGet(); return _channelID; }
            set { CheckSet(); _channelID = value; }
        }

        private string _pingRoleID;
        [Field("44D8194B-9252-4E25-ABCE-EB7E274C0D40", DataSize = 20)]
        public string PingRoleID
        {
            get { CheckGet(); return _pingRoleID; }
            set { CheckSet(); _pingRoleID = value; }
        }

        private string _pingUserID;
        [Field("20D3DD52-4918-48CA-A142-44C616564029", DataSize = 20)]
        public string PingUserID
        {
            get { CheckGet(); return _pingUserID; }
            set { CheckSet(); _pingUserID = value; }
        }

        private string _content;
        [Field("63952690-768E-4185-85D2-ECF9A7693DE2", DataSize = 1000)]
        public string Content
        {
            get { CheckGet(); return _content; }
            set { CheckSet(); _content = value; }
        }

        private long? _discordEmbedID;
        [Field("B359C73D-2908-4914-A4E1-C4A9D2C055C8")]
        public long? DiscordEmbedID
        {
            get { CheckGet(); return _discordEmbedID; }
            set { CheckSet(); _discordEmbedID = value; }
        }

        private DiscordEmbed _discordEmbed = null;
        [Relationship("31640135-2160-49B7-9E11-E589D74E4EA8")]
        public DiscordEmbed DiscordEmbed
        {
            get { CheckGet(); return _discordEmbed; }
        }

        protected override bool PreDelete(ITransaction transaction)
        {
            bool otherDeletesSuccessful = true;
            if (DiscordEmbedID != null)
            {
                DiscordEmbed discordEmbed = DataObject.GetEditableByPrimaryKey<DiscordEmbed>(DiscordEmbedID, transaction, null);
                if (!discordEmbed.Delete(transaction))
                {
                    otherDeletesSuccessful = false;
                    Errors.AddRange(discordEmbed.Errors.ToArray());
                }
            }

            return base.PreDelete(transaction) && otherDeletesSuccessful;
        }
    }
}
