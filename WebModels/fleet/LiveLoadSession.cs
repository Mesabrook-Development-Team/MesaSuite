using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Conditions;
using ClussPro.Base.Data.Operand;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
using WebModels.gov;
using WebModels.security;

namespace WebModels.fleet
{
    [Table("C10CEE41-338C-40E6-8867-A3458A152711")]
    public class LiveLoadSession : DataObject
    {
        protected LiveLoadSession() : base() { }

        private long? _liveLoadSessionID;
        [Field("2A42E2E9-D5B8-40C9-AC85-E42A12795F7C")]
        public long? LiveLoadSessionID
        {
            get { CheckGet(); return _liveLoadSessionID; }
            set { CheckSet(); _liveLoadSessionID = value; }
        }

        private long? _liveLoadID;
        [Field("A5AE60E5-7B3C-441D-83EE-3FEA5CC70797")]
        public long? LiveLoadID
        {
            get { CheckGet(); return _liveLoadID; }
            set { CheckSet(); _liveLoadID = value; }
        }

        private LiveLoad _liveLoad = null;
        [Relationship("ABA1EDA5-05F5-469C-8E94-687418F28523")]
        public LiveLoad LiveLoad
        {
            get { CheckGet(); return _liveLoad; }
        }

        private long? _userID;
        [Field("D735A03F-1DD6-4F1E-A4B6-980FD3C3E20B")]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

        private User _user = null;
        [Relationship("53622C5E-DC45-4DA5-B4F1-01B6E6A70573")]
        public User User
        {
            get { CheckGet(); return _user; }
        }

        private long? _companyID;
        [Field("43BD7688-DE73-4863-B028-7C71346280E7")]
        public long? CompanyID
        {
            get { CheckGet(); return _companyID; }
            set { CheckSet(); _companyID = value; }
        }

        private Company _company = null;
        [Relationship("233B1255-8ED2-4F43-9C5B-D4C88C18558D")]
        public Company Company
        {
            get { CheckGet(); return _company; }
        }

        private long? _governmentID;
        [Field("DEACD673-9FB3-46D4-825F-561F7B85D188")]
        public long? GovernmentID
        {
            get { CheckGet(); return _governmentID; }
            set { CheckSet(); _governmentID = value; }
        }

        private Government _government = null;
        [Relationship("5C200F70-C77D-4894-8B62-F019E5DC5F99")]
        public Government Government
        {
            get { CheckGet(); return _government; }
        }

        private DateTime? _lastHeartbeat;
        [Field("BC3F2CA6-46C2-4AA1-9DE0-AC9A453039BF", DataSize = 7)]
        public DateTime? LastHeartbeat
        {
            get { CheckGet(); return _lastHeartbeat; }
            set { CheckSet(); _lastHeartbeat = value; }
        }

        private bool _isSessionValid = false;
        [Field("10A0A712-FE59-48E0-BDAC-EB25ECBE84FE", HasOperation = true)]
        public bool IsSessionValid
        {
            get { CheckGet(); return _isSessionValid; }
        }

        public static OperationDelegate IsSessionValidOperation
        {
            get => (alias) =>
            {
                ISelectQuery query = SQLProviderFactory.GetSelectQuery();
                query.SelectList = new List<Select>()
                {
                    new Select()
                    {
                        SelectOperand = new Case()
                        {
                            Whens = new List<Case.When>()
                            {
                                new Case.When()
                                {
                                    Condition = new Condition()
                                    {
                                        Left = (Field)"lls.LastHeartbeat",
                                        ConditionType = Condition.ConditionTypes.Less,
                                        Right = new Literal(DateTime.Now.AddMinutes(-1))
                                    },
                                    Result = new Literal(false)
                                }
                            },
                            Else = new Literal(true)
                        }
                    }
                };
                query.Table = new Table("fleet", "LiveLoadSession", "lls");
                query.WhereCondition = new Condition()
                {
                    Left = (Field)"lls.LiveLoadSessionID",
                    ConditionType = Condition.ConditionTypes.Equal,
                    Right = (Field)$"{alias}.LiveLoadSessionID"
                };

                return new SubQuery(query);
            };
        }
    }
}
