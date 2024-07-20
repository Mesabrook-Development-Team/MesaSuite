using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.mesasys
{
    [Table("8F9DC746-848A-453B-9FD4-6CF3EAFC2CAF")]
    public class DiscordEmbedField : DataObject
    {
        protected DiscordEmbedField() : base() { }

        private long? _discordEmbedFieldID;
        [Field("41E6559B-21A7-40EA-A03F-AF22DDBFC7FC")]
        public long? DiscordEmbedFieldID
        {
            get { CheckGet(); return _discordEmbedFieldID; }
            set { CheckSet(); _discordEmbedFieldID = value; }
        }

        private long? _discordEmbedID;
        [Field("DCA5D98E-2194-4CF3-87E9-D17E53229C0D")]
        [Required]
        public long? DiscordEmbedID
        {
            get { CheckGet(); return _discordEmbedID; }
            set { CheckSet(); _discordEmbedID = value; }
        }

        private DiscordEmbed _discordEmbed = null;
        [Relationship("BFAEE28D-3DC8-4B31-93AE-784A19EDC080")]
        public DiscordEmbed DiscordEmbed
        {
            get { CheckGet(); return _discordEmbed; }
        }

        private string _name;
        [Field("5394B9F8-106F-4C5D-87DC-0308BDC6B4B4", DataSize = 50)]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        private string _value;
        [Field("52870B2B-A692-4914-B09F-212DA0AFF953", DataSize = 1000)]
        [Required]
        public string Value
        {
            get { CheckGet(); return _value; }
            set { CheckSet(); _value = value; }
        }

        private bool _isInline;
        [Field("B78950FD-05F8-4B2A-9E4D-C07928A76112")]
        public bool IsInline
        {
            get { CheckGet(); return _isInline; }
            set { CheckSet(); _isInline = value; }
        }
    }
}
