using System;
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
    [Table("9882F85A-BF24-4DA9-96A3-4DE7028ED44A")]
    public class Railcar : DataObject
    {
        protected Railcar() : base() { }

        private long? _railcarID;
        [Field("BC542631-BBAD-4577-9E3C-0AFD0E4A2864")]
        public long? RailcarID
        {
            get { CheckGet(); return _railcarID; }
            set { CheckSet(); _railcarID = value; }
        }

        private long? _railcarModelID;
        [Field("3D8E9CAC-11E8-4275-8927-AEC060C46EF8")]
        public long? RailcarModelID
        {
            get { CheckGet(); return _railcarModelID; }
            set { CheckSet(); _railcarModelID = value; }
        }

        private RailcarModel _railcarModel = null;
        [Relationship("7B567E44-8C75-479A-B9A9-ADAE6BB5A55C")]
        public RailcarModel RailcarModel
        {
            get { CheckGet(); return _railcarModel; }
        }

        private long? _governmentIDOwner;
        [Field("4BB5C98B-5F6E-4536-B5C8-39AD581379C9")]
        public long? GovernmentIDOwner
        {
            get { CheckGet(); return _governmentIDOwner; }
            set { CheckSet(); _governmentIDOwner = value; }
        }

        private Government _governmentOwner = null;
        [Relationship("D5ACE143-9B86-4044-84E4-E02D486FA9A0", ForeignKeyField = nameof(GovernmentIDOwner))]
        public Government GovernmentOwner
        {
            get { CheckGet(); return _governmentOwner; }
        }

        private long? _companyIDOwner;
        [Field("0C1ACEB6-F0CF-4B2D-BBB3-71A9A6A26CEA")]
        public long? CompanyIDOwner
        {
            get { CheckGet(); return _companyIDOwner; }
            set { CheckSet(); _companyIDOwner = value; }
        }

        private Company _companyOwner = null;
        [Relationship("A04C27FD-5DC3-4F94-A337-B6A71BC0AE1A", ForeignKeyField = nameof(CompanyIDOwner))]
        public Company CompanyOwner
        {
            get { CheckGet(); return _companyOwner; }
        }

        private string _reportingMark;
        [Field("DF38F559-C558-476E-B3D0-15828D80DAB0")]
        public string ReportingMark
        {
            get { CheckGet(); return _reportingMark; }
            set { CheckSet(); _reportingMark = value; }
        }

        private int? _reportingNumber;
        [Field("0EBE9191-DCA9-49A4-BE99-C0FEC9E27CAA")]
        public int? ReportingNumber
        {
            get { CheckGet(); return _reportingNumber; }
            set { CheckSet(); _reportingNumber = value; }
        }

        private byte[] _imageOverride;
        [Field("E3AC3FC5-C625-4BD2-9DB8-1E2AFDA60CCB")]
        public byte[] ImageOverride
        {
            get { CheckGet(); return _imageOverride; }
            set { CheckSet(); _imageOverride = value; }
        }
    }
}
