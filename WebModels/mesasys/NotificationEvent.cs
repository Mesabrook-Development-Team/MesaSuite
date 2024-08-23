using ClussPro.Base.Data.Query;
using ClussPro.Base.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Utility;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels.company;
using WebModels.fleet;
using WebModels.gov;
using WebModels.security;

namespace WebModels.mesasys
{
    [Table("EE1A6909-267A-4E8B-A495-14CA8A31BA75")]
    public class NotificationEvent : DataObject, ISystemLoaded
    {
        public static Dictionary<ScopeTypes, List<string>> ValidFieldsByScopeType = new Dictionary<ScopeTypes, List<string>>();
        private static HashSet<string> _fieldPathsForSend;

        static NotificationEvent()
        {
            ValidFieldsByScopeType = new Dictionary<ScopeTypes, List<string>>()
            {
                {
                    ScopeTypes.Global,
                    new List<string>()
                },
                {
                    ScopeTypes.Company,
                    FieldPathUtility.CreateFieldPathsAsList<Employee>(e => new List<object>()
                    {
                        e.ManageEmails,
                        e.ManageEmployees,
                        e.ManageAccounts,
                        e.ManageLocations,
                        e.IssueWireTransfers
                    })
                },
                {
                    ScopeTypes.Fleet,
                    FieldPathUtility.CreateFieldPathsAsList<FleetSecurity>(f => new List<object>()
                    {
                        f.AllowSetup,
                        f.AllowLeasingManagement,
                        f.IsYardmaster,
                        f.IsTrainCrew,
                        f.AllowLoadUnload
                    })
                },
                {
                    ScopeTypes.Government,
                    FieldPathUtility.CreateFieldPathsAsList<Official>(o => new List<object>()
                    {
                        o.ManageEmails,
                        o.ManageOfficials,
                        o.ManageAccounts,
                        o.CanMintCurrency,
                        o.CanConfigureInterest,
                        o.ManageTaxes,
                        o.ManageInvoices,
                        o.IssueWireTransfers,
                        o.ManageLaws
                    })
                },
                {
                    ScopeTypes.Location,
                    FieldPathUtility.CreateFieldPathsAsList<LocationEmployee>(e => new List<object>()
                    {
                        e.ManageInvoices,
                        e.ManageInventory,
                        e.ManagePrices,
                        e.ManageRegisters
                    })
                }
            };

            _fieldPathsForSend = new HashSet<string>();
            _fieldPathsForSend.Add(nameof(Parameters));
            _fieldPathsForSend.AddRange(Schema.GetSchemaObject<NotificationSubscriber>().GetFields().Select(f => nameof(NotificationSubscribers) + "." + f.FieldName));
            _fieldPathsForSend.AddRange(Schema.GetSchemaObject<NotificationSubscriberEntity>().GetFields().Select(f => nameof(NotificationSubscribers) + "." + nameof(NotificationSubscriber.NotificationSubscriberEntities) + "." + f.FieldName));
            _fieldPathsForSend.AddRange(Schema.GetSchemaObject<DiscordEmbed>().GetFields().Select(f => nameof(NotificationSubscribers) + "." + nameof(NotificationSubscriber.DiscordEmbed) + "." + f.FieldName));
            _fieldPathsForSend.AddRange(Schema.GetSchemaObject<DiscordEmbedField>().GetFields().Select(f => nameof(NotificationSubscribers) + "." + nameof(NotificationSubscriber.DiscordEmbed) + "." + nameof(DiscordEmbed.DiscordEmbedFields) + "." + f.FieldName));
        }

        protected NotificationEvent() : base() { }

        private long? _notificationEventID;
        [Field("19F7C5C5-FB0F-422C-9307-9FC4F700D849")]
        public long? NotificationEventID
        {
            get { CheckGet(); return _notificationEventID; }
            set { CheckSet(); _notificationEventID = value; }
        }

        public enum ScopeTypes
        {
            Global,
            Company,
            Location,
            Government,
            Fleet
        }

        private ScopeTypes _scopeType;
        [Field("B7B6D786-55B7-43E4-9432-D9AF6F045259", IsSystemLoaded = true)]
        [Required]
        public ScopeTypes ScopeType
        {
            get { CheckGet(); return _scopeType; }
            set { CheckSet(); _scopeType = value; }
        }

        private string _category;
        [Field("F235558D-EA25-420A-A8DE-BA55B4549982", DataSize = 50, IsSystemLoaded = true)]
        public string Category
        {
            get { CheckGet(); return _category; }
            set { CheckSet(); _category = value; }
        }

        private string _scopePermissions;
        [Field("AC02D1C9-B244-40A8-AE2B-1C1B65356FA2", DataSize = -1, IsSystemLoaded = true)]
        public string ScopePermissions
        {
            get { CheckGet(); return _scopePermissions; }
            set { CheckSet(); _scopePermissions = value; }
        }

        public string[] GetScopePermissionArray()
        {
            return ScopePermissions.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private string _name;
        [Field("A8039FD4-CEA1-4843-AB55-3809B57A999B", DataSize = 50, IsSystemLoaded = true)]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        private bool _isPublished = false;
        [Field("975F799F-D63A-4CC8-A7AA-3454566B7F17")]
        public bool IsPublished
        {
            get { CheckGet(); return _isPublished; }
            set { CheckSet(); _isPublished = value; }
        }

        private string _parameters;
        [Field("C793EDD0-DA0B-4BE6-927B-ABC7DCF34EC9", DataSize = -1, IsSystemLoaded = true)]
        public string Parameters
        {
            get { CheckGet(); return _parameters; }
            set { CheckSet(); _parameters = value; }
        }

        private long? _userIDOwner;
        [Field("10207268-9D28-4086-8D36-0397A8FACE72")]
        public long? UserIDOwner
        {
            get { CheckGet(); return _userIDOwner; }
            set { CheckSet(); _userIDOwner = value; }
        }

        private string _defaultNotificationText;
        [Field("BE49C1FF-3977-42CE-A5AB-9E39DE2034C2", DataSize = 1000, IsSystemLoaded = true)]
        public string DefaultNotificationText
        {
            get { CheckGet(); return _defaultNotificationText; }
            set { CheckSet(); _defaultNotificationText = value; }
        }

        private User _userOwner;
        [Relationship("B96CE2CE-96AE-4C6B-8C81-688C16402141", ForeignKeyField = nameof(UserIDOwner))]
        public User UserOwner
        {
            get { CheckGet(); return _userOwner; }
        }

        private Guid? _userSecret;
        [Field("A4112B6D-E21A-4829-8979-0D5C09404342")]
        public Guid? UserSecret
        {
            get { CheckGet(); return _userSecret; }
            set { CheckSet(); _userSecret = value; }
        }

        private Guid? _systemID;
        [Field("3A09F1BF-41D6-4E14-80AD-856901236705", IsSystemLoaded = true)]
        public Guid? SystemID
        {
            get { CheckGet(); return _systemID; }
            set { CheckSet(); _systemID = value; }
        }

        private byte[] _systemHash;
        [Field("1B6C3218-67D0-4164-BD59-02C841CF11AA", IsSystemLoaded = true)]
        public byte[] SystemHash
        {
            get { CheckGet(); return _systemHash; }
            set { CheckSet(); _systemHash = value; }
        }

        #region Relationships
        #region mesasys
        private List<NotificationSubscriber> _notificationSubscribers = new List<NotificationSubscriber>();
        [RelationshipList("837364D5-4380-4462-82F6-45CF27F96689", nameof(NotificationSubscriber.NotificationEventID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<NotificationSubscriber> NotificationSubscribers
        {
            get { CheckGet(); return _notificationSubscribers; }
        }

        private List<NotificationEventEntity> _notificationEventEntities = new List<NotificationEventEntity>();
        [RelationshipList("EB4A4054-A763-462A-A953-2BDF67A46871", nameof(NotificationEventEntity.NotificationEventID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<NotificationEventEntity> NotificationEventEntities
        {
            get { CheckGet(); return _notificationEventEntities; }
        }
        #endregion
        #endregion

        public struct NotificationEntityScope
        {
            public long? CompanyID { get; set; }
            public long? LocationID { get; set; }
            public long? GovernmentID { get; set; }
        }

        public static void SendSystemNotification<TBaseObject>(Guid notificationID, long primaryKey, NotificationEntityScope entityScope, ITransaction transaction) where TBaseObject : DataObject
        {
            NotificationEvent notificationEvent = new Search<NotificationEvent>(
                new GuidSearchCondition<NotificationEvent>()
                {
                    Field = nameof(NotificationEvent.SystemID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = notificationID
                })
                .GetReadOnly(null, _fieldPathsForSend);

            if (notificationEvent == null)
            {
                throw new ArgumentException("NotificationEvent with specified SystemID was not found");
            }

            TBaseObject baseObject = null;
            if (!string.IsNullOrEmpty(notificationEvent.Parameters))
            {
                baseObject = DataObject.GetReadOnlyByPrimaryKey<TBaseObject>(primaryKey, transaction, notificationEvent.Parameters.Split(','));
            }

            foreach(NotificationSubscriber notificationSubscriber in notificationEvent.NotificationSubscribers)
            {
                if (HasValidSecurity(notificationEvent.ScopeType, notificationEvent.ScopePermissions.Split(','), notificationSubscriber, entityScope))
                {
                    notificationSubscriber.SendNotification(baseObject);
                }
            }
        }

        private static bool HasValidSecurity(ScopeTypes scopeType, IEnumerable<string> permissions, NotificationSubscriber notificationSubscriber, NotificationEntityScope entityScope)
        {
            if (scopeType == ScopeTypes.Global)
            {
                return true;
            }

            Type searchObject;
            switch(scopeType)
            {
                case ScopeTypes.Company:
                    if (!notificationSubscriber.NotificationSubscriberEntities.Any(se => se.CompanyID == entityScope.CompanyID))
                    {
                        return false;
                    }
                    searchObject = typeof(Employee);
                    break;
                case ScopeTypes.Fleet:
                    if (!notificationSubscriber.NotificationSubscriberEntities.Any(se => (se.CompanyID != null && se.CompanyID == entityScope.CompanyID) || (se.LocationID != null && se.LocationID == entityScope.LocationID)))
                    {
                        return false;
                    }
                    searchObject = typeof(FleetSecurity);
                    break;
                case ScopeTypes.Government:
                    if (!notificationSubscriber.NotificationSubscriberEntities.Any(se => se.GovernmentID == entityScope.GovernmentID))
                    {
                        return false;
                    }
                    searchObject = typeof(Official);
                    break;
                case ScopeTypes.Location:
                    if (!notificationSubscriber.NotificationSubscriberEntities.Any(se => se.LocationID == entityScope.LocationID))
                    {
                        return false;
                    }
                    searchObject = typeof(LocationEmployee);
                    break;
                default:
                    throw new InvalidOperationException("Scope Type was not recognized for determining security");
            }

            SearchConditionGroup conditionGroup = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And);
            foreach(string permission in permissions)
            {
                conditionGroup.SearchConditions.Add(new BooleanSearchCondition(searchObject)
                {
                    Field = permission,
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = true
                });
            }

            ApplyEntityUserIDFilterForScopeSecurity(scopeType, conditionGroup, notificationSubscriber, entityScope);

            return new Search(searchObject, conditionGroup).ExecuteExists(null);
        }

        private static void ApplyEntityUserIDFilterForScopeSecurity(ScopeTypes scopeType, SearchConditionGroup conditionGroup, NotificationSubscriber notificationSubscriber, NotificationEntityScope entityScope)
        {
            switch(scopeType)
            {
                case ScopeTypes.Company:
                    conditionGroup.SearchConditions.Add(new LongSearchCondition<Employee>()
                    {
                        Field = nameof(Employee.UserID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = notificationSubscriber.UserID
                    });
                    conditionGroup.SearchConditions.Add(new LongSearchCondition<Employee>()
                    {
                        Field = nameof(Employee.CompanyID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = entityScope.CompanyID
                    });
                    break;
                case ScopeTypes.Fleet:
                    conditionGroup.SearchConditions.Add(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                        new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                            new LongSearchCondition<FleetSecurity>()
                            {
                                Field = FieldPathUtility.CreateFieldPathsAsList<FleetSecurity>(fs => new List<object>() { fs.Employee.UserID }).First(),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = notificationSubscriber.UserID
                            },
                            new LongSearchCondition<FleetSecurity>()
                            {
                                Field = FieldPathUtility.CreateFieldPathsAsList<FleetSecurity>(fs => new List<object>() { fs.Employee.CompanyID }).First(),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = entityScope.CompanyID
                            }),
                        new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                            new LongSearchCondition<FleetSecurity>()
                            {
                                Field = FieldPathUtility.CreateFieldPathsAsList<FleetSecurity>(fs => new List<object>() { fs.Official.UserID }).First(),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = notificationSubscriber.UserID
                            },
                            new LongSearchCondition<FleetSecurity>()
                            {
                                Field = FieldPathUtility.CreateFieldPathsAsList<FleetSecurity>(fs => new List<object>() { fs.Official.GovernmentID }).First(),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = entityScope.GovernmentID
                            })));
                    break;
                case ScopeTypes.Government:
                    conditionGroup.SearchConditions.Add(new LongSearchCondition<Official>()
                    {
                        Field = nameof(Official.UserID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = notificationSubscriber.UserID
                    });
                    conditionGroup.SearchConditions.Add(new LongSearchCondition<Official>()
                    {
                        Field = nameof(Official.GovernmentID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = entityScope.GovernmentID
                    });
                    break;
                case ScopeTypes.Location:
                    conditionGroup.SearchConditions.Add(new LongSearchCondition<LocationEmployee>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<LocationEmployee>(le => new List<object>() { le.Employee.UserID }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = notificationSubscriber.UserID
                    });
                    conditionGroup.SearchConditions.Add(new LongSearchCondition<LocationEmployee>()
                    {
                        Field = nameof(LocationEmployee.LocationID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = entityScope.LocationID
                    });
                    break;
            }
        }

        public static async Task<List<NotificationEvent>> GetNotificationEventsForUserID(long? userID, IEnumerable<string> fields)
        {
            List<string> userFields = FieldPathUtility.CreateFieldPathsAsList<User>(u => new List<object>()
            {
                u.UserPrograms.First().Program.Key,
            });

            userFields.AddRange(Schema.GetSchemaObject<Employee>().GetFields().Select(f => nameof(User.Employees) + "." + f.FieldName));
            userFields.AddRange(Schema.GetSchemaObject<LocationEmployee>().GetFields().Select(f => nameof(User.Employees) + "." + nameof(Employee.LocationEmployees) + "." + f.FieldName));
            userFields.AddRange(Schema.GetSchemaObject<Official>().GetFields().Select(f => nameof(User.Officials) + "." + f.FieldName));
            userFields.AddRange(Schema.GetSchemaObject<FleetSecurity>().GetFields().Select(f => nameof(User.Employees) + "." + nameof(Employee.FleetSecurity) + "." + f.FieldName));
            userFields.AddRange(Schema.GetSchemaObject<FleetSecurity>().GetFields().Select(f => nameof(User.Officials) + "." + nameof(Official.FleetSecurity) + "." + f.FieldName));

            User user = await Task.Run(() => DataObject.GetReadOnlyByPrimaryKey<User>(userID, null, userFields));
            List<NotificationEvent> notificationEvents = await Task.Run(() => new Search<NotificationEvent>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                new GuidSearchCondition<NotificationEvent>()
                {
                    Field = nameof(SystemID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.NotNull
                },
                new BooleanSearchCondition<NotificationEvent>()
                {
                    Field = nameof(IsPublished),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = true
                })).GetReadOnlyReader(null, fields.Append(nameof(ScopePermissions))).ToList());

            List<NotificationEvent> validForUser = new List<NotificationEvent>();
            foreach(NotificationEvent notificationEvent in notificationEvents)
            {
                switch(notificationEvent.ScopeType)
                {
                    case ScopeTypes.Global:
                        validForUser.Add(notificationEvent);
                        break;
                    case ScopeTypes.Company:
                        if (!user.UserPrograms.Any(up => "company".Equals(up.Program.Key, StringComparison.OrdinalIgnoreCase)))
                        {
                            continue;
                        }

                        bool hasAllRequiredPermissionsInAtLeastOneCompany = false;
                        foreach(Employee employee in user.Employees ?? new List<Employee>())
                        {
                            bool hasAllRequiredPermissions = true;
                            foreach(string requiredPermission in notificationEvent.GetScopePermissionArray())
                            {
                                try
                                {
                                    hasAllRequiredPermissions &= employee.GetValue<bool>(requiredPermission);
                                }
                                catch(Exception ex)
                                {
                                    #if DEBUG
                                    throw ex;
                                    #endif
                                }
                            }

                            if (hasAllRequiredPermissions)
                            {
                                hasAllRequiredPermissionsInAtLeastOneCompany = true;
                                break;
                            }
                        }

                        if (hasAllRequiredPermissionsInAtLeastOneCompany)
                        {
                            validForUser.Add(notificationEvent);
                        }
                        break;
                    case ScopeTypes.Fleet:
                        if (!user.UserPrograms.Any(up => "company".Equals(up.Program.Key, StringComparison.OrdinalIgnoreCase) || "gov".Equals(up.Program.Key, StringComparison.OrdinalIgnoreCase)))
                        {
                            continue;
                        }

                        bool hasAllRequiredPermissionInAtLeastOneEntity = false;
                        foreach (Employee employee in user.Employees ?? new List<Employee>())
                        {
                            if (employee.FleetSecurity == null)
                            {
                                continue;
                            }

                            bool hasAllRequiredPermissions = true;
                            foreach (string requiredPermission in notificationEvent.GetScopePermissionArray())
                            {
                                try
                                {
                                    hasAllRequiredPermissions &= employee.FleetSecurity.GetValue<bool>(requiredPermission);
                                }
                                catch (Exception ex)
                                {
                                    #if DEBUG
                                    throw ex;
                                    #endif
                                }
                            }

                            if (hasAllRequiredPermissions)
                            {
                                hasAllRequiredPermissionInAtLeastOneEntity = true;
                                break;
                            }
                        }

                        if (!hasAllRequiredPermissionInAtLeastOneEntity)
                        {
                            foreach (Official official in user.Officials ?? new List<Official>())
                            {
                                if (official.FleetSecurity == null)
                                {
                                    continue;
                                }

                                bool hasAllRequiredPermissions = true;
                                foreach (string requiredPermission in notificationEvent.GetScopePermissionArray())
                                {
                                    try
                                    {
                                        hasAllRequiredPermissions &= official.FleetSecurity.GetValue<bool>(requiredPermission);
                                    }
                                    catch (Exception ex)
                                    {
                                        #if DEBUG
                                        throw ex;
                                        #endif
                                    }
                                }

                                if (hasAllRequiredPermissions)
                                {
                                    hasAllRequiredPermissionInAtLeastOneEntity = true;
                                    break;
                                }
                            }
                        }

                        if(hasAllRequiredPermissionInAtLeastOneEntity)
                        {
                            validForUser.Add(notificationEvent);
                        }
                        break;
                    case ScopeTypes.Government:
                        if (!user.UserPrograms.Any(up => "gov".Equals(up.Program.Key, StringComparison.OrdinalIgnoreCase)))
                        {
                            continue;
                        }


                        bool hasAllRequiredPermissionsInAtLeastOneGovernment = false;
                        foreach (Official official in user.Officials ?? new List<Official>())
                        {
                            bool hasAllRequiredPermissions = true;
                            foreach (string requiredPermission in notificationEvent.GetScopePermissionArray())
                            {
                                try
                                {
                                    hasAllRequiredPermissions &= official.GetValue<bool>(requiredPermission);
                                }
                                catch (Exception ex)
                                {
                                    #if DEBUG
                                    throw ex;
                                    #endif
                                }
                            }

                            if (hasAllRequiredPermissions)
                            {
                                hasAllRequiredPermissionsInAtLeastOneGovernment = true;
                                break;
                            }
                        }

                        if (hasAllRequiredPermissionsInAtLeastOneGovernment)
                        {
                            validForUser.Add(notificationEvent);
                        }
                        break;
                    case ScopeTypes.Location:
                        if (!user.UserPrograms.Any(up => "company".Equals(up.Program.Key, StringComparison.OrdinalIgnoreCase)))
                        {
                            continue;
                        }

                        bool hasAllRequiredPermissionsInAtLeastOneLocation = false;
                        foreach (LocationEmployee locationEmployee in user.Employees?.SelectMany(e => e.LocationEmployees) ?? new List<LocationEmployee>())
                        {
                            bool hasAllRequiredPermissions = true;
                            foreach (string requiredPermission in notificationEvent.GetScopePermissionArray())
                            {
                                try
                                {
                                    hasAllRequiredPermissions &= locationEmployee.GetValue<bool>(requiredPermission);
                                }
                                catch (Exception ex)
                                {
                                    #if DEBUG
                                    throw ex;
                                    #endif
                                }
                            }

                            if (hasAllRequiredPermissions)
                            {
                                hasAllRequiredPermissionsInAtLeastOneLocation = true;
                                break;
                            }
                        }

                        if (hasAllRequiredPermissionsInAtLeastOneLocation)
                        {
                            validForUser.Add(notificationEvent);
                        }
                        break;
                }
            }

            return validForUser;
        }

        public static class Categories
        {
            public static class Company
            {
                public static string Finance = "Finance";
                public static string StoreFront = "Store Alerts";
            }

            public static class Government
            {
                public static string Finance = "Finance";
            }

            public static class FleetTracking
            {
                public static string EquipmentRelease = "Equipment Releases";
                public static string Leasing = "Leasing Alerts";
            }
        }

        public static class NotificationEvents
        {
            // INVOICING
            public static readonly Guid CompanyWireTransferReceived = new Guid("E80AB286-A196-4D19-A3D4-90DCC3EE3CE1");
            public static readonly Guid LocationAccountsPayableInvoiceReceived = new Guid("17CAC754-4ACD-489E-9945-CA970AA2F18E");
            public static readonly Guid LocationAccountsReceivableInvoiceReadyForReceipt = new Guid("74A6C54A-EA00-43F5-8612-0BC76224149B");
            public static readonly Guid GovernmentWireTransferReceived = new Guid("ED9E7B69-78C6-4EB4-905F-CEC0D39928E7");
            public static readonly Guid GovernmentAccountsPayableInvoiceReceived = new Guid("FC60D728-1405-4F4F-882A-985C48A54EBB");
            public static readonly Guid GovernmentAccountsReceivableInvoiceReadyForReceipt = new Guid("B76888D8-D2DB-47B8-9168-936431EEA2D9");

            // FLEET TRACKING
            public static readonly Guid RailcarReleasedReceived = new Guid("80F22108-A726-447F-9BCC-5790F4C45748");
            public static readonly Guid LocomotiveReleasedReceived = new Guid("B4F7CBDA-AA69-42B2-A683-A305D59E7A3D");
            public static readonly Guid NewLeaseRequestAvailable = new Guid("11F1DB20-A81A-4E89-81E0-47660CD66F1C");
            public static readonly Guid LeaseBidReceived = new Guid("3B22A796-0C6A-4079-92C3-A3971E8DC526");

            // STORE
            public static readonly Guid RegisterOffline = new Guid("BE8CC96C-5E19-409E-858E-2B0F397C3B94");
        }
    }
}
