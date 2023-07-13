using ClussPro.Base.Extensions;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using WebModels.company;
using WebModels.security;

namespace API_Company.App_Code
{
    internal class RegisterUserCache
    {
        private static DateTime? _cacheRefresh = DateTime.Now.AddSeconds(-1);
        private static HashSet<long?> _registerUserIDs = new HashSet<long?>();
        private static Dictionary<Guid?, CachedRegister> _registersByIdentifier = new Dictionary<Guid?, CachedRegister>();
        private static object _refreshLock = new object();

        public static bool IsUserARegister(long? userID)
        {
            lock (_refreshLock)
            {
                if (_cacheRefresh < DateTime.Now)
                {
                    RefreshCache();
                }
            }

            return _registerUserIDs.Contains(userID);
        }

        public static CachedRegister GetRegisterByIdentifier(Guid? identifier)
        {
            lock (_refreshLock)
            {
                if (_cacheRefresh < DateTime.Now)
                {
                    RefreshCache();
                }
            }

            return _registersByIdentifier.GetOrDefault(identifier);
        }

        private static void RefreshCache()
        {
            _registerUserIDs = new HashSet<long?>();
            _registersByIdentifier = new Dictionary<Guid?, CachedRegister>();

            Search<User> userSearch = new Search<User>(new BooleanSearchCondition<User>()
            {
                Field = nameof(User.IsStoreRegister),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = true
            });

            foreach (User user in userSearch.GetReadOnlyReader(null, new[] { nameof(User.UserID) }))
            {
                _registerUserIDs.Add(user.UserID);
            }

            Search<Register> registerSearch = new Search<Register>();
            List<string> registerFields = FieldPathUtility.CreateFieldPathsAsList<Register>(r => new List<object>()
            {
                r.Identifier,
                r.LocationID,
                r.Location.CompanyID
            });
            foreach(Register register in registerSearch.GetReadOnlyReader(null, registerFields))
            {
                CachedRegister cachedRegister = new CachedRegister()
                {
                    Identifier = register.Identifier,
                    LocationID = register.LocationID,
                    CompanyID = register.Location?.CompanyID
                };

                _registersByIdentifier.Add(register.Identifier, cachedRegister);
            }

            _cacheRefresh = DateTime.Now.AddSeconds(30);
        }

        public class CachedRegister
        {
            public long? CompanyID { get; set; }
            public long? LocationID { get; set; }
            public Guid? Identifier { get; set; }
        }
    }
}
