using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebModels.security;

namespace WebModels.auth
{
    [Table("1F5BACCF-41DC-40E7-B3F3-1896C5D20759")]
    public class Token : DataObject
    {
        protected Token() : base() { }

        private long? _tokenID;
        [Field("EB96B9AF-56B6-44CB-876B-3923A7687472")]
        public long? TokenID
        {
            get { CheckGet(); return _tokenID; }
            set { CheckSet(); _tokenID = value; }
        }

        private long? _clientID;
        [Field("345CEA11-A22D-4C7B-B87E-8224500B6634")]
        [Required]
        public long? ClientID
        {
            get { CheckGet(); return _clientID; }
            set { CheckSet(); _clientID = value; }
        }

        private Client _client;
        [Relationship("D80CBEF8-6C4B-4EA7-BD9F-35E45BA2E8E8")]
        public Client Client
        {
            get { CheckGet(); return _client; }
        }

        private DateTime? _grantTime;
        [Field("CEED86AA-2E8F-49B1-89AE-8C811C127585", DataSize = 7)]
        [Required]
        public DateTime? GrantTime
        {
            get { CheckGet(); return _grantTime; }
            set { CheckSet(); _grantTime = value; }
        }

        private Guid? _accessToken;
        [Field("76FD74AB-4D3F-4CEB-8A44-BB6060106A5E")]
        [Required]
        public Guid? AccessToken
        {
            get { CheckGet(); return _accessToken; }
            set { CheckSet(); _accessToken = value; }
        }

        private Guid? _refreshToken;
        [Field("D38A928C-6A1F-4F12-B457-538113DF330B")]
        public Guid? RefreshToken
        {
            get { CheckGet(); return _refreshToken; }
            set { CheckSet(); _refreshToken = value; }
        }

        private DateTime? _expiration;
        [Field("5B94F05E-81D6-44DD-8AE0-F7050BDACAB3", DataSize = 7)]
        [Required]
        public DateTime? Expiration
        {
            get { CheckGet(); return _expiration; }
            set { CheckSet(); _expiration = value; }
        }

        private DateTime? _revokeTime;
        [Field("B2470CD2-467C-4D3C-856D-4CED73BB0644", DataSize = 7)]
        public DateTime? RevokeTime
        {
            get { CheckGet(); return _revokeTime; }
            set { CheckSet(); _revokeTime = value; }
        }

        private string _revokeReason;
        [Field("19AF146E-A607-4C2B-9D35-D752DAD8EB8E", DataSize = 100)]
        public string RevokeReason
        {
            get { CheckGet(); return _revokeReason; }
            set { CheckSet(); _revokeReason = value; }
        }

        private bool _refreshTokenUsed = false;
        [Field("DC316673-52CE-46B7-83D8-3E067CFDD766")]
        public bool RefreshTokenUsed
        {
            get { CheckGet(); return _refreshTokenUsed; }
            set { CheckSet(); _refreshTokenUsed = value; }
        }

        private long? _userID;
        [Field("46AAAB2A-65D2-4743-9061-5208F5619E04")]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

        private User _user;
        [Relationship("60FB1FDE-6753-404A-802A-B3D5987A6C4E")]
        public User User
        {
            get { CheckGet(); return _user; }
        }

        protected override bool PreSave(ITransaction transaction)
        {
            if (IsInsert)
            {
                Search<Token> activeTokenSearch = new Search<Token>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<Token>()
                    {
                        Field = nameof(ClientID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = ClientID
                    },
                    new LongSearchCondition<Token>()
                    {
                        Field = nameof(RevokeTime),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Null
                    }));

                foreach(Token activeToken in activeTokenSearch.GetEditableReader(transaction))
                {
                    activeToken.RevokeTime = DateTime.Now;
                    activeToken.RevokeReason = "Newer session created";
                    activeToken.Save(transaction);
                }
            }
            return base.PreSave(transaction);
        }
    }
}