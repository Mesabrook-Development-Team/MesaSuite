using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.company;
using WebModels.gov;
using WebModels.mesasys;

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

        private long? _emailImplementationIDCarReleased;
        [Field("F14652D7-FB58-4C0A-8D18-E94B3B39F54D")]
        public long? EmailImplementationIDCarReleased
        {
            get { CheckGet(); return _emailImplementationIDCarReleased; }
            set { CheckSet();_emailImplementationIDCarReleased = value; }
        }

        private EmailImplementation _emailImplementationCarReleased = null;
        [Relationship("E5A2EFAC-1847-467F-A6AA-38EC0D007EAC", ForeignKeyField = nameof(EmailImplementationIDCarReleased))]
        public EmailImplementation EmailImplementationCarReleased
        {
            get { CheckGet(); return _emailImplementationCarReleased; }
        }

        private long? _emailImplementationIDLocomotiveReleased;
        [Field("720270C5-9445-4833-BF83-02A0C5011C5F")]
        public long? EmailImplementationIDLocomotiveReleased
        {
            get { CheckGet(); return _emailImplementationIDLocomotiveReleased; }
            set { CheckSet(); _emailImplementationIDLocomotiveReleased = value; }
        }

        private EmailImplementation _emailImplementationLocomotiveReleased = null;
        [Relationship("B96D992E-E7D1-4768-9F47-918537D88C22", ForeignKeyField = nameof(EmailImplementationIDLocomotiveReleased))]
        public EmailImplementation EmailImplementationLocomotiveReleased
        {
            get { CheckGet(); return _emailImplementationLocomotiveReleased; }
        }

        private long? _emailImplementationIDLeaseRequestAvailable;
        [Field("709F2F96-1A44-4617-BE3E-07FF4ACA7864")]
        public long? EmailImplementationIDLeaseRequestAvailable
        {
            get { CheckGet(); return _emailImplementationIDLeaseRequestAvailable; }
            set { CheckSet(); _emailImplementationIDLeaseRequestAvailable = value; }
        }

        private EmailImplementation _emailImplementationLeaseRequestAvailable = null;
        [Relationship("65C47A22-478E-4CEC-88E9-4AF96D599E4A", ForeignKeyField = nameof(EmailImplementationIDLeaseRequestAvailable))]
        public EmailImplementation EmailImplementationLeaseRequestAvailable
        {
            get { CheckGet(); return _emailImplementationLeaseRequestAvailable; }
        }

        private long? _emailImplementationIDLeaseBidReceived;
        [Field("15797E8F-E29A-4DF1-AEC6-49B53C98C308")]
        public long? EmailImplementationIDLeaseBidReceived
        {
            get { CheckGet(); return _emailImplementationIDLeaseBidReceived; }
            set { CheckSet(); _emailImplementationIDLeaseBidReceived = value; }
        }

        private EmailImplementation _emailImplementationLeaseBidReceived = null;
        [Relationship("32C28810-2F28-4A37-BC48-F15D761B7428", ForeignKeyField = nameof(EmailImplementationIDLeaseBidReceived))]
        public EmailImplementation EmailImplementationLeaseBidReceived
        {
            get { CheckGet(); return _emailImplementationLeaseBidReceived; }
        }

        protected override bool PostSave(ITransaction transaction)
        {
            if (!IsInsert)
            {
                if (IsFieldDirty(nameof(EmailImplementationIDCarReleased)))
                {
                    Errors.AddRange(DeleteOldEmailImplementationID((long?)GetDirtyValue(nameof(EmailImplementationIDCarReleased)), transaction).ToArray());
                }

                if (IsFieldDirty(nameof(EmailImplementationIDLocomotiveReleased)))
                {
                    Errors.AddRange(DeleteOldEmailImplementationID((long?)GetDirtyValue(nameof(EmailImplementationIDLocomotiveReleased)), transaction).ToArray());
                }
            }

            if (Errors.Any())
            {
                return false;
            }

            return base.PostSave(transaction);
        }

        private Errors DeleteOldEmailImplementationID(long? emailImplementationID, ITransaction transaction)
        {
            if (emailImplementationID == null)
            {
                return new Errors();
            }

            DataObject implementation = DataObject.GetEditableByPrimaryKey<EmailImplementation>(emailImplementationID, transaction, null);
            if (!implementation.Delete(transaction))
            {
                return implementation.Errors;
            }

            return new Errors();
        }
    }
}
