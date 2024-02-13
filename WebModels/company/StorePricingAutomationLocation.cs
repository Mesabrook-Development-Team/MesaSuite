using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;

namespace WebModels.company
{
    [Table("AB648404-AECB-4BE8-B129-4B136946B7DA")]
    [Unique(new[] { nameof(StorePricingAutomationID), nameof(LocationIDDestination) })]
    public class StorePricingAutomationLocation : DataObject
    {
        protected StorePricingAutomationLocation() : base() { }

        private long? _storePricingAutomationLocationID;
        [Field("EB89950D-A767-468C-AE14-A3D7AE98C6E0")]
        public long? StorePricingAutomationLocationID
        {
            get { CheckGet(); return _storePricingAutomationLocationID; }
            set { CheckSet(); _storePricingAutomationLocationID = value; }
        }

        private long? _storePricingAutomationID;
        [Field("B9D7E9E9-1B8C-4A3D-9F5E-9B9B7E9B7E9B")]
        [Required]
        public long? StorePricingAutomationID
        {
            get { CheckGet(); return _storePricingAutomationID; }
            set { CheckSet(); _storePricingAutomationID = value; }
        }

        private StorePricingAutomation _storePricingAutomation = null;
        [Relationship("65909F38-38AB-4B13-BC91-6DF65C77512F")]
        public StorePricingAutomation StorePricingAutomation
        {
            get { CheckGet(); return _storePricingAutomation; }
        }

        private long? _locationIDDestination;
        [Field("C94E7943-6E5D-432B-955B-C34E1667DA25")]
        [Required]
        public long? LocationIDDestination
        {
            get { CheckGet(); return _locationIDDestination; }
            set { CheckSet(); _locationIDDestination = value; }
        }

        private Location _locationDestination = null;
        [Relationship("B0D7E9E9-1B8C-4A3D-9F5E-9B9B7E9B7E9B", ForeignKeyField = nameof(LocationIDDestination))]
        public Location LocationDestination
        {
            get { CheckGet(); return _locationDestination; }
        }
    }
}
