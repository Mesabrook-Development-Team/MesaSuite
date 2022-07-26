using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;

namespace WebModels.mesasys
{
    [Table("C18ADB79-2B5C-4432-92B6-18ED1C17BCA9")]
    public class OutboundEmail : DataObject
    {
        protected OutboundEmail() : base() { }

        private long? _outboundEmailID;
        [Field("992F7FAB-2D10-4B74-AA93-E05C1679009D")]
        public long? OutboundEmailID
        {
            get { CheckGet(); return _outboundEmailID; }
            set { CheckSet(); _outboundEmailID = value; }
        }

        private string _fromName;
        [Field("1A1E6919-303C-4691-8142-AD07EFFC2A2C", DataSize = 100)]
        public string FromName
        {
            get { CheckGet(); return _fromName; }
            set { CheckSet(); _fromName = value; }
        }

        private string _fromEmail;
        [Field("72F154E1-ED59-4D6B-AE48-CFF92661A76A", DataSize = 255)]
        public string FromEmail
        {
            get { CheckGet(); return _fromEmail; }
            set { CheckSet(); _fromEmail = value; }
        }

        private string _to;
        [Field("2691E58A-C459-4E14-A0E1-1CCE0C951109", DataSize = 255)]
        public string To
        {
            get { CheckGet(); return _to; }
            set { CheckSet(); _to = value; }
        }

        private string _subject;
        [Field("E26FF51D-020F-4957-8911-0A18C4D82696", DataSize = 50)]
        public string Subject
        {
            get { CheckGet(); return _subject; }
            set { CheckSet(); _subject = value; }
        }

        private string _body;
        [Field("FA394E33-93C4-40F5-93E8-478F43C03F2E", DataSize = 4000)]
        public string Body
        {
            get { CheckGet(); return _body; }
            set { CheckSet(); _body = value; }
        }
    }
}
