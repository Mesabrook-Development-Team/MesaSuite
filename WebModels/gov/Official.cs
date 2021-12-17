using System.Collections.Generic;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Conditions;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using WebModels.security;

namespace WebModels.gov
{
    [Table("3C2F6AAE-3223-4E4F-B07C-844D31C0BE67")]
    [Unique(new string[] { "UserID", "GovernmentID" })]
    public class Official : DataObject
    {
        protected Official() : base() { }

        private long? _officialID;
        [Field("1C3754E1-2797-46E7-B7AA-7D6375DC447F")]
        public long? OfficialID
        {
            get { CheckGet(); return _officialID; }
            set { CheckSet(); _officialID = value; }
        }

        private long? _governmentID;
        [Field("B4937A6B-8336-4803-A233-8DE4A80E9440")]
        [Required]
        public long? GovernmentID
        {
            get { CheckGet(); return _governmentID; }
            set { CheckSet(); _governmentID = value; }
        }

        private Government _government = null;
        [Relationship("F3479D1C-11BC-4314-9EDE-5C7796B2CB2A")]
        public Government Government
        {
            get { CheckGet(); return _government; }
        }

        private long? _userID;
        [Field("CFC7EF40-C3A7-4706-BA61-1B43457C78CD")]
        [Required]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

        private User _user = null;
        [Relationship("56F4BB82-D9E9-48F8-BC96-683702586C51")]
        public User User
        {
            get { CheckGet(); return _user; }
        }

        private bool _manageEmails;
        [Field("2ED98E91-2F3E-4013-9335-182A35A712BC")]
        public bool ManageEmails
        {
            get { CheckGet(); return _manageEmails; }
            set { CheckSet(); _manageEmails = value; }
        }

        private bool _manageOfficials;
        [Field("5F32A587-D829-4842-AFCB-93262903D653")]
        public bool ManageOfficials
        {
            get { CheckGet(); return _manageOfficials; }
            set { CheckSet(); _manageOfficials = value; }
        }

        private string _officialName;
        [Field("51C127CE-45FB-4512-8325-00CF355510EA", HasOperation = true)]
        public string OfficialName
        {
            get { CheckGet(); return _officialName; }
        }

        public static OperationDelegate OfficialNameOperation
        {
            get
            {
                return alias =>
                {
                    ISelectQuery userSelect = SQLProviderFactory.GetSelectQuery();
                    userSelect.SelectList = new List<Select>()
                    {
                        new Select() { SelectOperand = (ClussPro.Base.Data.Operand.Field)"U.Username" }
                    };
                    userSelect.Table = new Table("security", "User", "U");
                    userSelect.WhereCondition = new Condition()
                    {
                        Left = (ClussPro.Base.Data.Operand.Field)"U.UserID",
                        ConditionType = Condition.ConditionTypes.Equal,
                        Right = (ClussPro.Base.Data.Operand.Field)$"{alias}.UserID"
                    };

                    return new ClussPro.Base.Data.Operand.SubQuery(userSelect);
                };
            }
        }

        public static IEnumerable<string> GetPermissionFieldNames()
        {
            yield return nameof(ManageEmails);
            yield return nameof(ManageOfficials);
        }
    }
}
