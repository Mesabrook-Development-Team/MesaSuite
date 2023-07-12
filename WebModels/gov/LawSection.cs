using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Schema.Attributes;

namespace WebModels.gov
{
    [Table("4F63CD0E-BA2D-4C64-B0C1-F3EC354E2CFE")]
    public class LawSection : DataObject
    {
        protected LawSection() : base() { }

        private long? _lawSectionID;
        [Field("CD46FED7-C13B-424B-8F7F-39E958E4C64E")]
        public long? LawSectionID
        {
            get { CheckGet(); return _lawSectionID; }
            set { CheckSet(); _lawSectionID = value; }
        }

        private long? _lawID;
        [Field("8BF34F8F-7290-4529-A381-552025DCBE4B")]
        public long? LawID
        {
            get { CheckGet(); return _lawID; }
            set { CheckSet(); _lawID = value; }
        }

        private Law _law = null;
        [Relationship("8A2A7239-F1D4-42D1-B848-87AC427DBEA7")]
        public Law Law
        {
            get { CheckGet(); return _law; }
        }

        private string _title;
        [Field("4E1A6F80-E847-4DDF-B669-3E8470D5E3C8", DataSize = 30)]
        public string Title
        {
            get { CheckGet(); return _title; }
            set { CheckSet(); _title = value;}
        }

        private string _detail;
        [Field("CE5AF076-3AE7-4B93-830E-4AE787666946", DataSize = -1)]
        public string Detail
        {
            get { CheckGet(); return _detail; }
            set { CheckSet(); _detail = value; }
        }
    }
}
