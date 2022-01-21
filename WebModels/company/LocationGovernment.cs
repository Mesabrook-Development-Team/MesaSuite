using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.gov;

namespace WebModels.company
{
    [Table("00562464-0E3B-4AD2-87B0-3B92684210B8")]
    public class LocationGovernment : DataObject
    {
        protected LocationGovernment() : base() { }

        private long? _locationGovernmentID;
        [Field("9D31A51E-280B-4B85-9B51-25DD1B4B87CD")]
        public long? LocationGovernmentID
        {
            get { CheckGet(); return _locationGovernmentID; }
            set { CheckSet(); _locationGovernmentID = value; }
        }

        private long? _locationID;
        [Field("B78818C0-492B-4AEB-BD9C-D09A4E91A656")]
        public long? LocationID
        {
            get { CheckGet(); return _locationID; }
            set { CheckSet(); _locationID = value; }
        }

        private Location _location = null;
        [Relationship("88C827E9-268B-4EDE-B81C-5B336C8BF944")]
        public Location Location
        {
            get { CheckGet(); return _location; }
        }

        private long? _governmentID;
        [Field("FA841068-BBBE-4F67-A722-ECB77DF26780")]
        public long? GovernmentID
        {
            get { CheckGet(); return _governmentID; }
            set { CheckSet(); _governmentID = value; }
        }

        private Government _government = null;
        [Relationship("85C65BBE-C4E0-4308-9700-9587059019E7")]
        public Government Government
        {
            get { CheckGet(); return _government; }
        }

        private bool _manageInvoices;
        [Field("1A264E06-DC32-4DD7-A88A-868D22F18C3E")]
        public bool ManageInvoices
        {
            get { CheckGet(); return _manageInvoices; }
            set { CheckSet(); _manageInvoices = value; }
        }
    }
}
