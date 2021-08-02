using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;

namespace WebModels.hMailServer.dbo
{
    [Table("F2FED850-4C09-41C5-A136-4EF700E3A5DA", TableName = "hm_distributionlistsrecipients", ConnectionName = "hmailserver")]
    public class DistributionListRecipient : DataObject
    {
        protected DistributionListRecipient() : base() { }

        private int? _distributionListRecipientID;
        [Field("0D279782-7F96-4B02-94F3-D00DC2B91CF1", IsPrimaryKey = true)]
        public int? DistributionListRecipientID
        {
            get { CheckGet(); return _distributionListRecipientID; }
            set { CheckSet(); _distributionListRecipientID = value; }
        }

        private int? _distributionListRecipientListID;
        [Field("A952300A-6168-4FA8-B25E-613DB0E3365E")]
        [Required]
        public int? DistributionListRecipientListID
        {
            get { CheckGet(); return _distributionListRecipientListID; }
            set { CheckSet(); _distributionListRecipientListID = value; }
        }

        private DistributionList _distributionListRecipientList;
        [Relationship("76C26C9D-95FC-4C3E-A487-614F0CB6FA5B", ParentKeyField = "DistributionListID")]
        public DistributionList DistributionListRecipientList
        {
            get { CheckGet(); return _distributionListRecipientList; }
        }

        private string _distributionListRecipientAddress;
        [Field("33098A1F-50D6-4BB2-88E5-E041AE96FD54", DataSize = 255)]
        [Required]
        public string DistributionListRecipientAddress
        {
            get { CheckGet(); return _distributionListRecipientAddress; }
            set { CheckSet(); _distributionListRecipientAddress = value; }
        }
    }
}