using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;

namespace WebModels.company
{
    [Table("497C8DED-10B5-4F24-BE72-5AECA70B2382")]
    public class LocationEmployee : DataObject
    {
        protected LocationEmployee() : base() { }

        private long? _locationEmployeeID;
        [Field("EA47570C-5252-4411-B3FE-4864F24C9DC1")]
        public long? LocationEmployeeID
        {
            get { CheckGet(); return _locationEmployeeID; }
            set { CheckSet(); _locationEmployeeID = value; }
        }

        private long? _locationID;
        [Field("9954534E-F835-4685-9189-68390763FAB0")]
        public long? LocationID
        {
            get { CheckGet(); return _locationID; }
            set { CheckSet(); _locationID = value; }
        }

        private Location _location = null;
        [Relationship("BA1C689D-90CE-4C9A-9F90-3F1C79AACDFF")]
        public Location Location
        {
            get { CheckGet(); return _location; }
        }

        private long? _employeeID;
        [Field("EC60F9E4-C295-4907-BCFD-66DC6C7F95E4")]
        public long? EmployeeID
        {
            get { CheckGet(); return _employeeID; }
            set { CheckSet(); _employeeID = value; }
        }

        private Employee _employee = null;
        [Relationship("0DC3CFF5-F505-45BD-AA29-E79B1FDD6B61")]
        public Employee Employee
        {
            get { CheckGet(); return _employee; }
        }

        private bool _manageInvoices;
        [Field("63324678-DF65-4435-81BB-5F97BBB77D1C")]
        public bool ManageInvoices
        {
            get { CheckGet(); return _manageInvoices; }
            set { CheckSet(); _manageInvoices = value; }
        }
    }
}
