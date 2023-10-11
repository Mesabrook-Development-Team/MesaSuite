using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.company;
using WebModels.gov;

namespace WebModels.mesasys
{
    [Table("1F37720E-04B1-4716-BE7F-423276D40C26")]
    public class EmailTemplate : DataObject, ISystemLoaded
    {
        protected EmailTemplate() : base() { }

        private long? _emailTemplateID;
        [Field("5A009460-F08F-4608-91CC-690F6D30EB13")]
        public long? EmailTemplateID
        {
            get { CheckGet(); return _emailTemplateID; }
            set { CheckSet(); _emailTemplateID = value; }
        }

        private Guid? _systemID;
        [Field("F080CF98-BEAB-4FD0-A0EF-253EEA77D8F1")]
        public Guid? SystemID
        {
            get { CheckGet(); return _systemID; }
            set { CheckSet(); _systemID = value; }
        }

        private byte[] _systemHash;
        [Field("45DADF60-9729-4A41-9641-1078A778E866")]
        public byte[] SystemHash
        {
            get { CheckGet(); return _systemHash; }
            set { CheckSet(); _systemHash = value; }
        }

        private string _name;
        [Field("6C9D56A3-186E-473A-AE4D-483DD386AB3F", DataSize = 255, IsSystemLoaded = true)]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        private string _templateSchema;
        [Field("E17A3B04-1476-4575-8F0C-0CD939B7EA7E", DataSize = 30, IsSystemLoaded = true)]
        public string TemplateSchema
        {
            get { CheckGet(); return _templateSchema; }
            set { CheckSet(); _templateSchema = value; }
        }

        private string _templateObject;
        [Field("907B19CE-C82F-444F-8E76-924077FD35E8", DataSize = 100)]
        public string TemplateObject
        {
            get { CheckGet(); return _templateObject; }
            set { CheckSet(); _templateObject = value; }
        }

        private string _template;
        [Field("3146B64C-FF09-407D-885A-4D503563FFE3", DataSize = 4000, IsSystemLoaded = true)]
        public string Template
        {
            get { CheckGet(); return _template; }
            set { CheckSet(); _template = value; }
        }

        private string _allowedFields;
        [Field("EADD9DE5-2FF3-4255-ACC7-A520BA4DDD9B", DataSize = -1, IsSystemLoaded = true)]
        public string AllowedFields
        {
            get { CheckGet(); return _allowedFields; }
            set { CheckSet(); _allowedFields = value; }
        }

        public enum SecurityCheckTypes
        {
            WireTransferHistory,
            Invoicing,
            FleetTracking,
            StoreRegister
        }

        private SecurityCheckTypes _securityCheckType;
        [Field("E006A7E4-1AE4-4375-98FB-98B685BC5612")]
        public SecurityCheckTypes SecurityCheckType
        {
            get { CheckGet(); return _securityCheckType; }
            set { CheckSet(); _securityCheckType = value; }
        }

        public bool SecurityCheck(long? userID, long? companyID, long? locationID, long? governmentID)
        {
            switch(SecurityCheckType)
            {
                case SecurityCheckTypes.WireTransferHistory:
                    return CheckWireTransferHistorySecurity(userID, companyID, governmentID);
                case SecurityCheckTypes.Invoicing:
                    return CheckInvoicingSecurity(userID, locationID, governmentID);
                case SecurityCheckTypes.StoreRegister:
                    return CheckRegisterSecurity(userID, locationID);
            }

            return true;
        }

        private bool CheckWireTransferHistorySecurity(long? userID, long? companyID, long? governmentID)
        {
            if (userID == null)
            {
                return false;
            }

            if (companyID != null)
            {
                Search<Employee> employeeSearch = new Search<Employee>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<Employee>()
                    {
                        Field = nameof(Employee.CompanyID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = companyID
                    },
                    new LongSearchCondition<Employee>()
                    {
                        Field = nameof(Employee.UserID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = userID
                    }));

                return employeeSearch.GetReadOnly(null, new[] { nameof(Employee.IssueWireTransfers) })?.IssueWireTransfers ?? false;
            }
            else if (governmentID != null)
            {
                Search<Official> officialSearch = new Search<Official>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<Official>()
                    {
                        Field = nameof(Official.GovernmentID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = governmentID
                    },
                    new LongSearchCondition<Official>()
                    {
                        Field = nameof(Official.UserID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = userID
                    }));

                return officialSearch.GetReadOnly(null, new[] { nameof(Official.IssueWireTransfers) })?.IssueWireTransfers ?? false;
            }

            return false;
        }

        private bool CheckInvoicingSecurity(long? userID, long? locationID, long? governmentID)
        {
            if (userID == null)
            {
                return false;
            }

            if (locationID != null)
            {
                Search<LocationEmployee> locationEmployeeSearch = new Search<LocationEmployee>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<LocationEmployee>()
                    {
                        Field = $"{nameof(LocationEmployee.Employee)}.{nameof(Employee.UserID)}",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = userID
                    },
                    new LongSearchCondition<LocationEmployee>()
                    {
                        Field = nameof(LocationEmployee.LocationID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = locationID
                    }));

                return locationEmployeeSearch.GetReadOnly(null, new[] { nameof(LocationEmployee.ManageInvoices) })?.ManageInvoices ?? false;
            }
            else if (governmentID != null)
            {
                Search<Official> officialSearch = new Search<Official>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<Official>()
                    {
                        Field = nameof(Official.GovernmentID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = governmentID
                    },
                    new LongSearchCondition<Official>()
                    {
                        Field = nameof(Official.UserID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = userID
                    }));

                return officialSearch.GetReadOnly(null, new[] { nameof(Official.ManageInvoices) })?.ManageInvoices ?? false;
            }

            return false;
        }

        private bool CheckRegisterSecurity(long? userID, long? locationID)
        {
            if (userID == null || locationID == null)
            {
                return false;
            }

            Search<LocationEmployee> locEmplSearch = new Search<LocationEmployee>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<LocationEmployee>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<LocationEmployee>(le => new List<object>() { le.Employee.UserID }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = userID
                },
                new LongSearchCondition<LocationEmployee>()
                {
                    Field = nameof(LocationEmployee.LocationID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = locationID
                }));

            return locEmplSearch.GetReadOnly(null, new[] { nameof(LocationEmployee.ManageRegisters)} )?.ManageRegisters ?? false;
        }

        #region Relationships
        private List<EmailImplementation> _emailImplementations = new List<EmailImplementation>();
        [RelationshipList("5A7A20F8-7301-4AAB-90E3-BCD5697234FA", nameof(EmailImplementation.EmailTemplateID))]
        public IReadOnlyCollection<EmailImplementation> EmailImplementations
        {
            get { CheckGet(); return _emailImplementations; }
        }
        #endregion

        public static class EmailTemplates
        {
            // INVOICING
            public static readonly Guid WireTransferReceived = new Guid("E80AB286-A196-4D19-A3D4-90DCC3EE3CE1");
            public static readonly Guid AccountsPayableInvoiceReceived = new Guid("17CAC754-4ACD-489E-9945-CA970AA2F18E");
            public static readonly Guid AccountsReceivableInvoiceReadyForReceipt = new Guid("74A6C54A-EA00-43F5-8612-0BC76224149B");

            // FLEET TRACKING
            public static readonly Guid RailcarReleasedReceived = new Guid("80F22108-A726-447F-9BCC-5790F4C45748");
            public static readonly Guid LocomotiveReleasedReceived = new Guid("B4F7CBDA-AA69-42B2-A683-A305D59E7A3D");
            public static readonly Guid NewLeaseRequestAvailable = new Guid("11F1DB20-A81A-4E89-81E0-47660CD66F1C");
            public static readonly Guid LeaseBidReceived = new Guid("3B22A796-0C6A-4079-92C3-A3971E8DC526");
        }
    }
}
