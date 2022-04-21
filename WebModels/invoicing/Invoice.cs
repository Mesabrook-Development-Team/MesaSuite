using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using WebModels.account;
using WebModels.company;
using WebModels.gov;
using WebModels.invoicing.Attributes;

namespace WebModels.invoicing
{
    [Table("0EB0BE0D-2853-4D8E-927D-FA69176BAA8D")]
    public class Invoice : DataObject
    {
        protected Invoice() : base() { }

        private long? _invoiceID;
        [Field("11769A34-759B-4192-9BF8-1372D0319AC8")]
        public long? InvoiceID
        {
            get { CheckGet(); return _invoiceID; }
            set { CheckSet(); _invoiceID = value; }
        }

        private long? _governmentIDFrom;
        [Field("62330C50-6839-424E-AEED-93A84A5A789D")]
        [SentPermission(SentPermissionAttribute.SenderTypes.Sender)]
        public long? GovernmentIDFrom
        {
            get { CheckGet(); return _governmentIDFrom; }
            set { CheckSet(); _governmentIDFrom = value; }
        }

        private Government _governmentFrom = null;
        [Relationship("AA91092D-F505-4E43-BCBC-654084563CFD", ForeignKeyField = nameof(GovernmentIDFrom))]
        public Government GovernmentFrom
        {
            get { CheckGet(); return _governmentFrom; }
        }

        private long? _locationIDFrom;
        [Field("80E15F51-CBDC-4BC2-9E4D-DA6083CEE91E")]
        [SentPermission(SentPermissionAttribute.SenderTypes.Sender)]
        public long? LocationIDFrom
        {
            get { CheckGet(); return _locationIDFrom; }
            set { CheckSet(); _locationIDFrom = value; }
        }

        private Location _locationFrom = null;
        [Relationship("024A40BC-74B0-429D-8982-6327C36FE05A", ForeignKeyField = nameof(LocationIDFrom))]
        public Location LocationFrom
        {
            get { CheckGet(); return _locationFrom; }
        }

        private long? _governmentIDTo;
        [Field("5BA54999-723C-41B1-8D14-A56241031E0F")]
        [SentPermission(SentPermissionAttribute.SenderTypes.Sender)]
        public long? GovernmentIDTo
        {
            get { CheckGet(); return _governmentIDTo; }
            set { CheckSet(); _governmentIDTo = value; }
        }

        private Government _governmentTo = null;
        [Relationship("F4702ABC-4AAF-41A2-B669-5E4B9547B58E", ForeignKeyField = nameof(GovernmentIDTo))]
        public Government GovernmentTo
        {
            get { CheckGet(); return _governmentTo; }
        }

        private long? _locationIDTo;
        [Field("7705AACE-7EFD-457D-92A2-307CAD435E09")]
        [SentPermission(SentPermissionAttribute.SenderTypes.Sender)]
        public long? LocationIDTo
        {
            get { CheckGet(); return _locationIDTo; }
            set { CheckSet(); _locationIDTo = value; }
        }

        private Location _locationTo = null;
        [Relationship("D2882202-3CC6-4FD1-80DE-9051CE6FFA9D", ForeignKeyField = nameof(LocationIDTo))]
        public Location LocationTo
        {
            get { CheckGet(); return _locationTo; }
        }

        private string _invoiceNumber;
        [Field("30F4F4AC-8503-48D7-8377-BD847E174A49", DataSize = 11)]
        [Required]
        public string InvoiceNumber
        {
            get { CheckGet(); return _invoiceNumber; }
            set { CheckSet(); _invoiceNumber = value; }
        }

        private string _description;
        [Field("B6152DA9-0BDE-43B0-B428-49689E6BF21E", DataSize = 300)]
        [Required]
        public string Description
        {
            get { CheckGet(); return _description; }
            set { CheckSet(); _description = value; }
        }

        private DateTime? _invoiceDate;
        [Field("0B19B097-5619-4C48-8C8B-B04F27CDB4C0", DataSize = 7)]
        [Required]
        [SentPermission(SentPermissionAttribute.SenderTypes.Sender)]
        public DateTime? InvoiceDate
        {
            get { CheckGet(); return _invoiceDate; }
            set { CheckSet(); _invoiceDate = value; }
        }

        private DateTime? _dueDate;
        [Field("D53E474E-D7C2-4A09-B6A5-1A10070BDC9F", DataSize = 7)]
        public DateTime? DueDate
        {
            get { CheckGet(); return _dueDate; }
            set { CheckSet(); _dueDate = value; }
        }

        public enum CreationTypes
        {
            Blank,
            AccountsPayable,
            AccountsReceivable
        }

        private CreationTypes _creationType = CreationTypes.Blank;
        [Field("82E1EA52-12F0-4EA6-91A6-002FE51AF8EB", DataSize = 18)]
        [Required]
        [SentPermission(SentPermissionAttribute.SenderTypes.Sender)]
        public CreationTypes CreationType
        {
            get { CheckGet(); return _creationType; }
            set { CheckSet(); _creationType = value; }
        }

        public enum Statuses
        {
            WorkInProgress,
            Sent,
            Complete
        }

        private Statuses _status = Statuses.WorkInProgress;
        [Field("A889CD9D-34B1-42F8-B8C6-EF1D9C7AB834", DataSize = 14)]
        [Required]
        public Statuses Status
        {
            get { CheckGet(); return _status; }
            set { CheckSet(); _status = value; }
        }

        private long? _accountIDFrom;
        [Field("90F797A8-260C-4DF9-BDC2-D8903FC99921")]
        [SentPermission(SentPermissionAttribute.SenderTypes.Payor)]
        public long? AccountIDFrom
        {
            get { CheckGet(); return _accountIDFrom; }
            set { CheckSet(); _accountIDFrom = value; }
        }

        private Account _accountFrom = null;
        [Relationship("FF407B7F-7143-4CD2-8B2E-89163D98A0AA", ForeignKeyField = nameof(AccountIDFrom))]
        public Account AccountFrom
        {
            get { CheckGet(); return _accountFrom; }
        }

        private string _accountFromHistorical;
        [Field("2A433479-1DE9-4BC8-863D-B38E361C2304", DataSize = 69)]
        [SentPermission(SentPermissionAttribute.SenderTypes.Payor)]
        public string AccountFromHistorical
        {
            get { CheckGet(); return _accountFromHistorical; }
            set { CheckSet(); _accountFromHistorical = value; }
        }

        private long? _accountIDTo;
        [Field("95AEABA8-2F38-41F3-BADC-567371799282")]
        [SentPermission(SentPermissionAttribute.SenderTypes.Payee)]
        public long? AccountIDTo
        {
            get { CheckGet(); return _accountIDTo; }
            set { CheckSet(); _accountIDTo = value;}
        }

        private Account _accountTo = null;
        [Relationship("D598522C-227E-4414-A775-6D78F3B7D38E", ForeignKeyField = nameof(AccountIDTo))]
        public Account AccountTo
        {
            get { CheckGet(); return _accountTo; }
        }

        private string _accountToHistorical;
        [Field("585999BD-71D9-43D3-BFFA-E1973CC1D5B6")]
        [SentPermission(SentPermissionAttribute.SenderTypes.Payee)]
        public string AccountToHistorical
        {
            get { CheckGet(); return _accountToHistorical; }
            set { CheckSet(); _accountToHistorical = value; }
        }

        #region Relationships
        #region invoicing
        private List<InvoiceLine> _invoiceLines = new List<InvoiceLine>();
        [RelationshipList("151E4019-12B6-47B3-9F62-3F5B9B5F7A4D", "InvoiceID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<InvoiceLine> InvoiceLines
        {
            get { CheckGet(); return _invoiceLines;}
        }

        private List<InvoiceSalesTax> _invoiceSalesTaxes = new List<InvoiceSalesTax>();
        [RelationshipList("C0A1D2DB-B35A-446F-AF5C-3CF18C2D043A", "InvoiceID")]
        public IReadOnlyCollection<InvoiceSalesTax> InvoiceSalesTaxes
        {
            get { CheckGet(); return _invoiceSalesTaxes; }
        }
        #endregion
        #endregion

        public bool DoesLocationHavePermissionToUpdateByStatus(long locationID)
        {
            bool isPayee = LocationIDFrom == locationID;
            bool isSender = (isPayee && CreationType == CreationTypes.AccountsReceivable) || (LocationIDTo == locationID && CreationType == CreationTypes.AccountsPayable);

            if (Status == Statuses.Complete ||
                (Status == Statuses.WorkInProgress &&
                    ((CreationType == CreationTypes.AccountsReceivable && LocationIDFrom != locationID) || (CreationType == CreationTypes.AccountsPayable && LocationIDTo != locationID))))
            {
                return false;
            }

            return true;
        }

        public bool DoesLocationHavePermissionToUpdateFields(long locationID)
        {
            bool isPayee = LocationIDFrom == locationID;
            bool isSender = (isPayee && CreationType == CreationTypes.AccountsReceivable) || (LocationIDTo == locationID && CreationType == CreationTypes.AccountsPayable);

            if (Status == Statuses.Complete ||
                (Status == Statuses.WorkInProgress && 
                    ((CreationType == CreationTypes.AccountsReceivable && LocationIDFrom != locationID) || (CreationType == CreationTypes.AccountsPayable && LocationIDTo != locationID))))
            {
                return false;
            }

            foreach(PropertyInfo propInfo in GetType().GetProperties().Where(prop => prop.GetCustomAttribute<SentPermissionAttribute>() != null))
            {
                if (!IsFieldDirty(propInfo.Name))
                {
                    continue;
                }

                SentPermissionAttribute updaterPermission = propInfo.GetCustomAttribute<SentPermissionAttribute>();
                if ((updaterPermission.UpdaterOption == SentPermissionAttribute.SenderTypes.Payee && !isPayee) ||
                    (updaterPermission.UpdaterOption == SentPermissionAttribute.SenderTypes.Payor && isPayee) ||
                    (updaterPermission.UpdaterOption == SentPermissionAttribute.SenderTypes.Sender && !isSender) ||
                    (updaterPermission.UpdaterOption == SentPermissionAttribute.SenderTypes.Recipient && isSender))
                {
                    return false;
                }
            }

            return true;
        }

        public bool DoesLocationHavePermissionToDelete(long locationID)
        {
            bool isPayee = LocationIDFrom == locationID;
            return (CreationType == CreationTypes.AccountsReceivable && isPayee) || (CreationType == CreationTypes.AccountsPayable && !isPayee);
        }

        protected override bool PostSave(ITransaction transaction)
        {
            if (IsInsert)
            {
                bool isAccountsReceivable = CreationType == CreationTypes.AccountsReceivable;
                long? locationID;
                if ((isAccountsReceivable && LocationIDFrom == null) || (!isAccountsReceivable && LocationIDTo == null))
                {
                    return base.PostSave(transaction);
                }
                else if (isAccountsReceivable)
                {
                    locationID = LocationIDFrom;
                }
                else
                {
                    locationID = LocationIDTo;
                }

                Location location = DataObject.GetEditableByPrimaryKey<Location>(locationID, transaction, null);
                string nextInvoiceNumber = location.InvoiceNumberPrefix + location.NextInvoiceNumber;
                if (!nextInvoiceNumber.Equals(InvoiceNumber))
                {
                    return base.PostSave(transaction);
                }

                string newInvoiceNumber = InvoiceNumber.Substring(location.InvoiceNumberPrefix.Length);
                if (!int.TryParse(newInvoiceNumber, out int newInvoiceNumberInt))
                {
                    return base.PostSave(transaction);
                }

                newInvoiceNumberInt++;
                newInvoiceNumber = newInvoiceNumberInt.ToString().PadLeft(newInvoiceNumber.Length, '0');
                location.NextInvoiceNumber = newInvoiceNumber;
                if (!location.Save(transaction))
                {
                    Errors.AddRange(location.Errors.ToArray());
                }
            }
            return base.PostSave(transaction);
        }

        public void IssueInvoice()
        {
            if (Status != Statuses.WorkInProgress)
            {
                Errors.AddBaseMessage("An Invoice may only be issued if it is in Work In Progress status");
            }

            Status = Statuses.Sent;
            Save();
        }

        public void ReceiveInvoice()
        {
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                Search<InvoiceLine> childLineSearch = new Search<InvoiceLine>(new LongSearchCondition<InvoiceLine>()
                {
                    Field = "InvoiceID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = InvoiceID
                });

                decimal invoiceTotal = childLineSearch.GetReadOnlyReader(transaction, new[] { "Total" }).Sum(il => il.Total).Value;

                decimal taxRate = 1M;
                if (LocationIDFrom != null)
                {
                    Search<LocationGovernment> locationGovernmentSearch = new Search<LocationGovernment>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                        new LongSearchCondition<LocationGovernment>()
                        {
                            Field = nameof(LocationGovernment.LocationID),
                            SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                            Value = LocationIDFrom
                        },
                        new BooleanSearchCondition<LocationGovernment>()
                        {
                            Field = nameof(LocationGovernment.PaySalesTax),
                            SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                            Value = true
                        }));

                    string[] searchFields = new string[]
                    {
                        $"{nameof(LocationGovernment.Government)}.{nameof(Government.EffectiveSalesTax)}.{nameof(SalesTax.Rate)}"
                    };

                    foreach(LocationGovernment locationGovernment in locationGovernmentSearch.GetReadOnlyReader(transaction, searchFields))
                    {
                        taxRate += locationGovernment.Government.EffectiveSalesTax?.Rate ?? 0M;
                    }
                }

                invoiceTotal *= taxRate;

                Account sourceAccount = DataObject.GetEditableByPrimaryKey<Account>(AccountIDFrom, transaction, null);
                if (sourceAccount.Balance < invoiceTotal)
                {
                    Errors.AddBaseMessage("The Payor's Account has insufficient funds available");
                    return;
                }

                try
                {
                    
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
