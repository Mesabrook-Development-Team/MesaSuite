using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
using WebModels.gov;

namespace WebModels.account
{
    [Table("7150BBD0-9C9A-4E47-AC50-F8A56FFBA60A")]
    public class WireTransferHistory : DataObject
    {
        protected WireTransferHistory() : base() { }

        private long? _wireTransferHistoryID;
        [Field("5808695E-C0C5-4A10-B972-060123A91C75")]
        public long? WireTransferHistoryID
        {
            get { CheckGet(); return _wireTransferHistoryID; }
            set { CheckSet(); _wireTransferHistoryID = value; }
        }

        private long? _governmentIDFrom;
        [Field("230AF060-EFFD-4907-B5FE-7D92D232F424")]
        public long? GovernmentIDFrom
        {
            get { CheckGet(); return _governmentIDFrom; }
            set { CheckSet(); _governmentIDFrom = value; }
        }

        private Government _governmentFrom = null;
        [Relationship("96711BD7-DDFE-47BE-BD08-DF145B71F085", ForeignKeyField = nameof(GovernmentIDFrom))]
        public Government GovernmentFrom
        {
            get { CheckGet(); return _governmentFrom; }
        }

        private long? _locationIDFrom;
        [Field("5EC9731C-1B74-4B74-B59C-EEE181C88AA5")]
        public long? LocationIDFrom
        {
            get { CheckGet(); return _locationIDFrom; }
            set { CheckSet(); _locationIDFrom = value; }
        }

        private Location _locationFrom = null;
        [Relationship("1F20202A-2CEA-40A2-BDF9-1C4E7DBA7094", ForeignKeyField = nameof(LocationIDFrom))]
        public Location LocationFrom
        {
            get { CheckGet(); return _locationFrom; }
        }

        private string _to;
        [Field("32DF54FB-BCF4-4564-81EB-92FE4C9E616B", DataSize = 103)]
        public string To
        {
            get { CheckGet(); return _to; }
            set { CheckSet(); _to = value; }
        }

        private string _accountFromHistorical;
        [Field("36E26D03-23F0-431F-8506-FB9ED4A8AFB2", DataSize = 69)]
        public string AccountFromHistorical
        {
            get { CheckGet(); return _accountFromHistorical; }
            set { CheckSet(); _accountFromHistorical = value; }
        }

        private string _accountToMasked;
        [Field("61658C74-7810-4B70-B071-EF7430EC74F3", DataSize = 16)]
        public string AccountToMasked
        {
            get { CheckGet(); return _accountToMasked; }
            set { CheckSet(); _accountToMasked = value; }
        }

        private decimal? _amount;
        [Field("8197F6B0-E48C-44BD-9D8F-B7822A148F70", DataSize = 9, DataScale = 2)]
        public decimal? Amount
        {
            get { CheckGet(); return _amount; }
            set { CheckSet(); _amount = value; }
        }
    }
}
