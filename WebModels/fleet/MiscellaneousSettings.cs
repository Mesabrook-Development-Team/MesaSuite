using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.company;
using WebModels.gov;

namespace WebModels.fleet
{
    [Table("D4001DEE-6AA2-4F52-A63D-33A867EF7787")]
    public class MiscellaneousSettings : DataObject
    {
        protected MiscellaneousSettings() : base() { }

        private long? _miscellaneousSettingsID;
        [Field("B3BC9A00-7831-43F7-BA7F-628B7C18F20E")]
        public long? MiscellaneousSettingsID
        {
            get { CheckGet(); return _miscellaneousSettingsID; }
            set { CheckSet(); _miscellaneousSettingsID = value; }
        }

        private long? _companyID;
        [Field("E8BBC341-2F56-4256-8ACA-31B72E82A3CF")]
        public long? CompanyID
        {
            get { CheckGet(); return _companyID; }
            set { CheckSet(); _companyID = value; }
        }

        private Company _company = null;
        [Relationship("48EDB284-E722-416B-B636-E8AABF9015E7")]
        public Company Company
        {
            get { CheckGet(); return _company; }
        }

        private long? _governmentID;
        [Field("FBD8857F-1997-4794-97C3-472C625B8182")]
        public long? GovernmentID
        {
            get { CheckGet(); return _governmentID; }
            set { CheckSet(); _governmentID = value; }
        }

        private Government _government = null;
        [Relationship("04280A33-91CC-4E46-93FD-6D9E09214C23")]
        public Government Government
        {
            get { CheckGet(); return _government; }
        }

        private long? _locationIDInvoicePayee;
        [Field("D32CF264-4482-4FC9-9120-5B4801FD385D")]
        public long? LocationIDInvoicePayee
        {
            get { CheckGet(); return _locationIDInvoicePayee; }
            set { CheckSet(); _locationIDInvoicePayee = value; }
        }

        private Location _locationInvoicePayee = null;
        [Relationship("37A73798-9BE2-4B9A-9B99-FBB813AF30AE", ForeignKeyField = nameof(LocationIDInvoicePayee))]
        public Location LocationInvoicePayee
        {
            get { CheckGet(); return _locationInvoicePayee; }
        }

        private long? _locationIDInvoicePayor;
        [Field("C0636646-8964-4578-BCD2-BF60D7022DDA")]
        public long? LocationIDInvoicePayor
        {
            get { CheckGet(); return _locationIDInvoicePayor; }
            set { CheckSet(); _locationIDInvoicePayor = value; }
        }

        private Location _locationInvoicePayor = null;
        [Relationship("87EA3B44-2D17-4121-AE33-5593D233B4C3", ForeignKeyField = nameof(LocationIDInvoicePayor))]
        public Location LocationInvoicePayor
        {
            get { CheckGet(); return _locationInvoicePayor; }
        }
    }
}
