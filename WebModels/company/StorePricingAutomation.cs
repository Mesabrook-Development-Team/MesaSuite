using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System.Collections.Generic;

namespace WebModels.company
{
    [Table("7E717BD8-55A0-41EC-A92A-9951DFA6CF45")]
    [Unique(new[] { nameof(LocationID) })]
    public class StorePricingAutomation : DataObject
    {
        protected StorePricingAutomation() : base() { }

        private long? _storePricingAutomationID;
        [Field("D06187BE-E844-4315-9A87-E5F7D419F6CA")]
        public long? StorePricingAutomationID
        {
            get { CheckGet(); return _storePricingAutomationID; }
            set { CheckGet(); _storePricingAutomationID = value; }
        }

        private long? _locationID;
        [Field("E8E7E4B8-6E9F-4E6D-8E6C-6A7B9E6A6D5B")]
        [Required]
        public long? LocationID
        {
            get { CheckGet(); return _locationID; }
            set { CheckGet(); _locationID = value; }
        }

        private Location _location = null;
        [Relationship("4EDCC491-4F49-4340-AB8F-515C32CD7E5C")]
        public Location Location
        {
            get { CheckGet(); return _location; }
        }

        private bool _isEnabled;
        [Field("3EFDDC2C-B1D2-4FB2-8B5E-A5CB2E255CB9")]
        public bool IsEnabled
        {
            get { CheckGet(); return _isEnabled; }
            set { CheckGet(); _isEnabled = value; }
        }

        private bool _pushAdd;
        [Field("D7DA6F2F-FD68-43A0-B590-66512CEA51A6")]
        public bool PushAdd
        {
            get { CheckGet(); return _pushAdd; }
            set { CheckGet(); _pushAdd = value; }
        }

        private bool _pushUpdate;
        [Field("FFBC8807-51F9-4506-B1E0-3FB78E7CA0F0")]
        public bool PushUpdate
        {
            get { CheckGet(); return _pushUpdate; }
            set { CheckGet(); _pushUpdate = value; }
        }

        private bool _pushDelete;
        [Field("8F904E3F-919E-48E0-B9DA-F017CBE94F5F")]
        public bool PushDelete
        {
            get { CheckGet(); return _pushDelete; }
            set { CheckGet(); _pushDelete = value; }
        }

        #region Relationships
        #region company
        private List<StorePricingAutomationLocation> _storePricingAutomationLocations = new List<StorePricingAutomationLocation>();
        [RelationshipList("33467335-FA12-4DC0-BD8F-FE47D6C00415", nameof(StorePricingAutomationLocation.StorePricingAutomationID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<StorePricingAutomationLocation> StorePricingAutomationLocations
        {
            get { CheckGet(); return _storePricingAutomationLocations; }
        }
        #endregion
        #endregion
    }
}
