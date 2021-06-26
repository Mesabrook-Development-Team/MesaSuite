using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;

namespace WebModels.dbo
{
    [Table("2B39AC98-8B1B-430F-9570-D6AB9F82782D")]
    public class MCSyncVersion : DataObject
    {
        protected MCSyncVersion() : base() { }

        private long? _mCSyncVersionID = null;
        [Field("7B976DE2-1204-43F3-A3B0-BB6965387692")]
        public long? MCSyncVersionID
        {
            get { CheckGet(); return _mCSyncVersionID; }
            set { CheckSet(); }
        }

        private byte _major;
        [Field("592869A1-9D10-4C44-9FA5-386365D66E43")]
        public byte Major
        {
            get { CheckGet(); return _major; }
            set { CheckSet(); _major = value; }
        }

        private byte _minor;
        [Field("1563FEDD-2B16-41A7-AEBB-637ED5449113")]
        public byte Minor
        {
            get { CheckGet(); return _minor; }
            set { CheckSet(); _minor = value; }
        }

        private byte _revision;
        [Field("3C14CDF1-81FA-4285-A43F-3C67B3A8F7C8")]
        public byte Revision
        {
            get { CheckGet(); return _revision; }
            set { CheckSet(); _revision = value; }
        }

        private byte _build;
        [Field("46B8EF35-CDAB-42DE-9CC4-1BE70FC7B3AA")]
        public byte Build
        {
            get { CheckGet(); return _build; }
            set { CheckSet(); _build = value; }
        }

        private DateTime? _valid;
        [Field("A66BA749-51A4-420F-AA00-9343C9B02B96", DataSize = 7)]
        public DateTime? Valid
        {
            get { CheckGet(); return _valid; }
            set { CheckSet(); _valid = value; }
        }

        private string _releaseNotes;
        [Field("B91AC51E-0EB7-43CA-8BAB-AB5E13A669B5")]
        public string ReleaseNotes
        {
            get { CheckGet(); return _releaseNotes; }
            set { CheckSet(); _releaseNotes = value; }
        }
    }
}