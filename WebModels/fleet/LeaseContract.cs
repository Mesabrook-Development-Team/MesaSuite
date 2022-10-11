using System;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
using WebModels.gov;

namespace WebModels.fleet
{
    [Table("B551E83E-9B40-471A-860A-9DA060D74E96")]
    public class LeaseContract : DataObject
    {
        protected LeaseContract() : base() { }

        private long? _leaseContractID;
        [Field("5C9EB2CC-F7A2-409B-841A-04E74CC7D3B4")]
        public long? LeaseContractID
        {
            get { CheckGet(); return _leaseContractID; }
            set { CheckSet(); _leaseContractID = value; }
        }

        private long? _railcarID;
        [Field("2BA49A5C-F5EF-4A02-8783-4641B6BA3D7A")]
        public long? RailcarID
        {
            get { CheckGet(); return _railcarID; }
            set { CheckSet(); _railcarID = value; }
        }

        private Railcar _railcar = null;
        [Relationship("46147F77-4013-473E-814C-CEA5C616923E")]
        public Railcar Railcar
        {
            get { CheckGet(); return _railcar; }
        }

        private long? _locomotiveID;
        [Field("59B6931E-A02F-4B1F-B84E-1978C1E7FC1D")]
        public long? LocomotiveID
        {
            get { CheckGet(); return _locomotiveID; }
            set { CheckSet(); _locomotiveID = value; }
        }

        private Locomotive _locomotive;
        [Relationship("3A6F7264-DE3B-43CB-A38C-85B5F637B907")]
        public Locomotive Locomotive
        {
            get { CheckGet(); return _locomotive; }
        }

        private long? _governmentIDLessee;
        [Field("708F1F9E-90E7-42C5-8D32-37D635FD4891")]
        public long? GovernmentIDLessee
        {
            get { CheckGet(); return _governmentIDLessee; }
            set { CheckSet(); _governmentIDLessee = value; }
        }

        private Government _governmentLessee = null;
        [Relationship("42358409-9343-4BB7-873D-8B9FF074DE9E", ForeignKeyField = nameof(GovernmentIDLessee))]
        public Government GovernmentLessee
        {
            get { CheckGet(); return _governmentLessee; }
        }

        private long? _companyIDLessee;
        [Field("18B60058-F741-4255-9C9B-6D39D3E76FA3")]
        public long? CompanyIDLessee
        {
            get { CheckGet(); return _companyIDLessee; }
            set { CheckSet(); _companyIDLessee = value; }
        }

        private Company _companyLessee = null;
        [Relationship("210398E4-DCAD-46A8-8409-9C0C54503146", ForeignKeyField = nameof(CompanyIDLessee))]
        public Company CompanyLessee
        {
            get { CheckGet(); return _companyLessee; }
        }

        private decimal? _amount;
        [Field("0BD927BC-8B33-4641-B981-55A6CFC3ACA4", DataSize = 8, DataScale = 2)]
        public decimal? Amount
        {
            get { CheckGet(); return _amount; }
            set { CheckSet(); _amount = value; }
        }

        private LeaseBid.RecurringAmountTypes _recurringAmountType;
        [Field("22D6F2ED-A8C0-4C03-9655-44449024217C")]
        public LeaseBid.RecurringAmountTypes RecurringAmountType
        {
            get { CheckGet(); return _recurringAmountType; }
            set { CheckSet(); _recurringAmountType = value; }
        }

        private decimal? _recurringAmount;
        [Field("17049C5A-15E8-4CEB-8BC4-4C61A4643E0E", DataSize = 8, DataScale = 2)]
        public decimal? RecurringAmount
        {
            get { CheckGet(); return _recurringAmount; }
            set { CheckSet(); _recurringAmount = value; }
        }

        private long? _locationIDRecurringAmountSource;
        [Field("1319230B-9DFE-4D46-BA05-9486909B6000")]
        public long? LocationIDRecurringAmountSource
        {
            get { CheckGet(); return _locationIDRecurringAmountSource; }
            set { CheckSet(); _locationIDRecurringAmountSource = value; }
        }

        private Location _locationRecurringAmountSource = null;
        [Relationship("ADA1EE54-C360-47CC-9B59-255123C82761", ForeignKeyField = nameof(LocationIDRecurringAmountSource))]
        public Location LocationRecurringAmountSource
        {
            get { CheckGet(); return _locationRecurringAmountSource; }
        }

        private long? _locationIDRecurringAmountDestination;
        [Field("28F7518D-B0CB-43D6-9A52-508EC0845971")]
        public long? LocationIDRecurringAmountDestination
        {
            get { CheckGet(); return _locationIDRecurringAmountDestination; }
            set { CheckSet(); _locationIDRecurringAmountDestination = value; }
        }

        private Location _locationRecurringAmountDestination = null;
        [Relationship("0E9FECA7-33C0-49B6-B024-CE43E6285395", ForeignKeyField = nameof(LocationIDRecurringAmountDestination))]
        public Location LocationRecurringAmountDestination
        {
            get { CheckGet(); return _locationRecurringAmountDestination; }
        }

        private string _terms;
        [Field("BDE3468D-AC65-46F0-A626-71C5F7D5CC75", DataSize = -1)]
        public string Terms
        {
            get { CheckGet(); return _terms; }
            set { CheckSet(); _terms = value; }
        }

        private DateTime? _leaseTimeStart;
        [Field("206905E5-0FF8-4396-BBB5-C10BFF12734A", DataSize = 7)]
        public DateTime? LeaseTimeStart
        {
            get { CheckGet(); return _leaseTimeStart; }
            set { CheckSet(); _leaseTimeStart = value; }
        }

        private DateTime? _leaseTimeEnd;
        [Field("3F7A12FD-5537-490E-909D-880AE624D663", DataSize = 7)]
        public DateTime? LeaseTimeEnd
        {
            get { CheckGet(); return _leaseTimeEnd; }
            set { CheckSet(); _leaseTimeEnd = value; }
        }
    }
}
