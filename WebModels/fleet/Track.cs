﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
using WebModels.gov;

namespace WebModels.fleet
{
    [Table("A65E0F0C-6EC2-4943-B345-B5983B05DFD6")]
    public class Track : DataObject
    {
        protected Track() : base() { }

        private long? _trackID;
        [Field("435C7B8C-C8B5-497B-AF2D-E2A21AAC7A12")]
        public long? TrackID
        {
            get { CheckGet(); return _trackID; }
            set { CheckSet(); _trackID = value; }
        }

        private long? _railDistrictID;
        [Field("FAB1095C-38F9-4629-BFAB-0DF9EB15E56C")]
        public long? RailDistrictID
        {
            get { CheckGet(); return _railDistrictID; }
            set { CheckSet(); _railDistrictID = value; }
        }

        private RailDistrict _railDistrict = null;
        [Relationship("ECED49EB-5387-4EE6-86BB-B1BF2803EE56")]
        public RailDistrict RailDistrict
        {
            get { CheckGet(); return _railDistrict; }
        }

        private long? _companyIDOwner;
        [Field("7D10A7ED-4886-4BBF-87E9-EBE39AB51B5D")]
        public long? CompanyIDOwner
        {
            get { CheckGet(); return _companyIDOwner; }
            set { CheckSet(); _companyIDOwner = value; }
        }

        private Company _companyOwner = null;
        [Relationship("12705E87-42E6-478D-92D3-F9147FB86F36", ForeignKeyField = nameof(CompanyIDOwner) )]
        public Company CompanyOwner
        {
            get { CheckGet(); return _companyOwner; }
        }

        private long? _governmentIDOwner;
        [Field("68F0A114-E1FC-43D3-BAC5-8087C737DB28")]
        public long? GovernmentIDOwner
        {
            get { CheckGet(); return _governmentIDOwner; }
            set { CheckSet(); _governmentIDOwner = value; }
        }

        private Government _governmentOwner = null;
        [Relationship("6851039E-CDF1-4AA5-8C68-BA5AD2AC79F2", ForeignKeyField = nameof(GovernmentIDOwner) )]
        public Government GovernmentOwner
        {
            get { CheckGet(); return _governmentOwner; }
        }

        private string _name;
        [Field("D9D14F78-33C7-4C53-A4B4-31967FF51DE0", DataSize = 30)]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        private decimal? _length;
        [Field("EA80FD21-C139-4682-9976-0EF39023AAFD", DataSize = 6, DataScale = 2)]
        public decimal? Length
        {
            get { CheckGet(); return _length; }
            set { CheckSet(); _length = value; }
        }

        #region Relationships
        #region fleet
        private List<RailLocation> _railLocations = new List<RailLocation>();
        [RelationshipList("02D1BA12-0F58-4C9C-9BFC-EF5DD97C4807", nameof(RailLocation.TrackID))]
        public IReadOnlyCollection<RailLocation> RailLocations
        {
            get { CheckGet(); return _railLocations; }
        }

        private List<RailcarLocationTransaction> _railcarLocationTransactions = new List<RailcarLocationTransaction>();
        [RelationshipList("96B47121-BA09-4A89-8EDE-79211E8E9330", nameof(RailcarLocationTransaction.TrackIDNew))]
        public IReadOnlyCollection<RailcarLocationTransaction> RailcarLocationTransactions
        {
            get { CheckGet(); return _railcarLocationTransactions; }
        }
        #endregion
        #endregion
    }
}
