using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
using WebModels.mesasys;

namespace WebModels.fleet
{
    [Table("1A94E2CD-D57A-4590-8AAE-C171A1119653")]
    public class LeaseBid : DataObject
    {
        protected LeaseBid() : base() { }

        private long? _leaseBidID;
        [Field("B2249CAF-200D-4003-8180-13BF012BAF4B")]
        public long? LeaseBidID
        {
            get { CheckGet(); return _leaseBidID; }
            set { CheckSet(); _leaseBidID = value; }
        }

        private long? _leaseRequestID;
        [Field("E0F3B87A-3C60-4C1C-9A39-42ECD375DE00")]
        public long? LeaseRequestID
        {
            get { CheckGet(); return _leaseRequestID; }
            set { CheckSet(); _leaseRequestID = value; }
        }

        private LeaseRequest _leaseRequest = null;
        [Relationship("13DAFC9E-7D18-4E92-900C-DCDF8A7942BB")]
        public LeaseRequest LeaseRequest
        {
            get { CheckGet(); return _leaseRequest; }
        }

        private long? _locomotiveID;
        [Field("3F6D42C3-C73C-4994-B72F-1687B6CB06FA")]
        public long? LocomotiveID
        {
            get { CheckGet(); return _locomotiveID; }
            set { CheckSet(); _locomotiveID = value; }
        }

        private Locomotive _locomotive = null;
        [Relationship("16F3048A-F5E4-4C22-B7C3-3E0774BBED52")]
        public Locomotive Locomotive
        {
            get { CheckGet(); return _locomotive; }
        }

        private long? _railcarID;
        [Field("3F4A4328-28A5-4A29-A549-5F7ABF5ED4DF")]
        public long? RailcarID
        {
            get { CheckGet(); return _railcarID; }
            set { CheckSet(); _railcarID = value; }
        }

        private Railcar _railcar = null;
        [Relationship("0E49F1C3-93E0-4029-9264-6E247878ED4C")]
        public Railcar Railcar
        {
            get { CheckGet(); return _railcar; }
        }

        private decimal? _leaseAmount;
        [Field("73B76825-BD46-45E8-81F8-1297CFAA766F", DataSize = 8, DataScale = 2)]
        public decimal? LeaseAmount
        {
            get { CheckGet(); return _leaseAmount; }
            set { CheckSet(); _leaseAmount = value; }
        }

        public enum RecurringAmountTypes
        {
            None,
            Daily,
            Weekly,
            Biweekly,
            Monthly,
            Quarterly
        }

        private RecurringAmountTypes _recurringAmountType;
        [Field("07E88E71-1053-418C-B981-D7E56BBBCE55")]
        public RecurringAmountTypes RecurringAmountType
        {
            get { CheckGet(); return _recurringAmountType; }
            set { CheckSet(); _recurringAmountType = value; }
        }

        private decimal? _recurringAmount;
        [Field("6744C35A-E1E9-43B3-AF11-21D283287A88", DataSize = 8, DataScale = 2)]
        public decimal? RecurringAmount
        {
            get { CheckGet(); return _recurringAmount; }
            set { CheckSet(); _recurringAmount = value; }
        }

        private long? _locationIDInvoiceDestination;
        [Field("E3733AEB-1EF4-4C32-8B91-4B30D2E0AD31")]
        public long? LocationIDInvoiceDestination
        {
            get { CheckGet(); return _locationIDInvoiceDestination; }
            set { CheckSet(); _locationIDInvoiceDestination = value; }
        }

        private Location _locationInvoiceDestination = null;
        [Relationship("94458C3F-F110-495C-8272-9F69468F1561", ForeignKeyField = nameof(LocationIDInvoiceDestination))]
        public Location LocationInvoiceDestination
        {
            get { CheckGet(); return _locationInvoiceDestination; }
        }

        private string _terms;
        [Field("28445847-F414-4CDE-8D5F-A546D310C844", DataSize = -1)]
        public string Terms
        {
            get { CheckGet(); return _terms; }
            set { CheckSet(); _terms = value; }
        }

        protected override bool PostSave(ITransaction transaction)
        {
            if (IsInsert)
            {
                Search<MiscellaneousSettings> settingsSearch = new Search<MiscellaneousSettings>(new LongSearchCondition<MiscellaneousSettings>()
                {
                    Field = nameof(MiscellaneousSettings.EmailImplementationIDLeaseBidReceived),
                    SearchConditionType = SearchCondition.SearchConditionTypes.NotNull
                });

                foreach (MiscellaneousSettings settings in settingsSearch.GetReadOnlyReader(transaction, new[] { nameof(MiscellaneousSettings.EmailImplementationIDLeaseBidReceived) }))
                {
                    EmailImplementation implementation = DataObject.GetEditableByPrimaryKey<EmailImplementation>(settings.EmailImplementationIDLeaseBidReceived, transaction, null);
                    implementation.SendEmail<LeaseBid>(LeaseBidID, transaction);
                }
            }
            return base.PostSave(transaction);
        }
    }
}
