using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
using WebModels.gov;

namespace WebModels.fleet
{
    [Table("26F0E07C-E054-49E2-92DB-E535B77D2D66")]
    public class Locomotive : DataObject
    {
        protected Locomotive() : base() { }

        private long? _locomotiveID;
        [Field("D384203E-3299-4C49-8665-1D0E6DACA869")]
        public long? LocomotiveID
        {
            get { CheckGet(); return _locomotiveID; }
            set { CheckSet(); _locomotiveID = value; }
        }

        private long? _locomotiveModelID;
        [Field("8022037A-D18B-4079-91B7-1548ECF7DB57")]
        public long? LocomotiveModelID
        {
            get { CheckGet(); return _locomotiveModelID; }
            set { CheckSet(); _locomotiveModelID = value; }
        }

        private LocomotiveModel _locomotiveModel;
        [Relationship("7EB177E3-4349-4911-A33A-383021795AFC")]
        public LocomotiveModel LocomotiveModel
        {
            get { CheckGet(); return _locomotiveModel; }
        }

        private long? _governmentIDOwner;
        [Field("4D5DAEC4-CC37-4A13-9ED7-2F3424BA857C")]
        public long? GovernmentIDOwner
        {
            get { CheckGet(); return _governmentIDOwner; }
            set { CheckSet(); _governmentIDOwner = value; }
        }

        private Government _governmentOwner;
        [Relationship("81492311-52BE-4428-9AC4-D22A3683035D", ForeignKeyField = nameof(GovernmentIDOwner))]
        public Government GovernmentOwner
        {
            get { CheckGet(); return _governmentOwner; }
        }

        private long? _companyIDOwner;
        [Field("50320BAA-1C2D-4E1A-B866-8EF94895A068")]
        public long? CompanyIDOwner
        {
            get { CheckGet(); return _companyIDOwner; }
            set { CheckSet(); _companyIDOwner = value; }
        }

        private Company _companyOwner;
        [Relationship("5B907DAA-5DF5-4850-97AF-4C67124312BC", ForeignKeyField = nameof(CompanyIDOwner))]
        public Company CompanyOwner
        {
            get { CheckGet(); return _companyOwner; }
        }

        private string _reportingMark;
        [Field("5F2C40A0-5BB6-4B9A-BF69-C70F207653BF", DataSize = 4)]
        public string ReportingMark
        {
            get { CheckGet(); return _reportingMark; }
            set { CheckSet(); _reportingMark = value; }
        }

        private int? _reportingNumber;
        [Field("562D76BB-B754-4DCA-9D1F-AAE91058E69C")]
        public int? ReportingNumber
        {
            get { CheckGet(); return _reportingNumber; }
            set { CheckSet(); _reportingNumber = value; }
        }

        private byte[] _imageOverride;
        [Field("AB6F6E20-63FC-4E70-BA04-7D55A146A622")]
        public byte[] ImageOverride
        {
            get { CheckGet(); return _imageOverride; }
            set { CheckSet(); _imageOverride = value; }
        }
    }
}
