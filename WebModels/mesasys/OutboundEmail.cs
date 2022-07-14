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

        private string _from;
        [Field("4D827A7C-CB43-473B-A353-1C8B58B98E4A", DataSize = 255)]
        public string From
        {
            get { CheckGet(); return _from; }
            set { CheckSet(); _from = value; }
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
