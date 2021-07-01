using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;

namespace WebModels.dbo
{
    [Table("0170EEDF-E986-462C-9074-566297EA629A")]
    public class MCSyncFile : DataObject
    {
        protected MCSyncFile() : base() { }

        private long? _mCSyncFileID = null;
        [Field("1D10C15E-8E80-4543-9359-FA09954510AE")]
        public long? MCSyncFileID
        {
            get { CheckGet(); return _mCSyncFileID; }
            set { CheckSet(); _mCSyncFileID = value; }
        }

        private string _fileType;
        [Field("0D9D535B-ACE4-43D8-9DD4-6842AE927D6C", DataSize = 13)]
        public string FileType
        {
            get { CheckGet(); return _fileType; }
            set { CheckSet(); }
        }

        private string _path;
        [Field("609369C2-C109-4906-93EC-293D0363B786")]
        public string Path
        {
            get { CheckGet(); return _path; }
            set { CheckSet(); }
        }

        private string _filename;
        [Field("DDD53D46-CF26-4F72-8BA5-5091C1B16C07")]
        public string Filename
        {
            get { CheckGet(); return _filename; }
            set { CheckSet(); }
        }

        private byte[] _checksum;
        [Field("BC1AE001-A394-4C8B-A7AE-B856889A7F9A")]
        public byte[] Checksum
        {
            get { CheckGet(); return _checksum; }
            set { CheckSet(); }
        }

        private string _downloadType;
        [Field("A7C402D7-5BD6-4F46-AE37-4EEEA98BFC20")]
        public string DownloadType
        {
            get { CheckGet(); return _downloadType; }
            set { CheckSet(); }
        }
    }
}