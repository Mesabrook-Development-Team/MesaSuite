using ClussPro.ObjectBasedFramework.DataSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModels.security;

namespace API_System.App_Code
{
    public class ImmersibrookUserCache
    {
        private static DateTime? _cacheRefresh = DateTime.Now.AddSeconds(-1);
        private static HashSet<long?> _immersibrookUsers = new HashSet<long?>();
        private static object _refreshLock = new object();

        public static bool IsImmersibrookUser(long? userID)
        {
            lock (_refreshLock)
            {
                if (_cacheRefresh < DateTime.Now)
                {
                    RefreshCache();
                }
            }

            return _immersibrookUsers.Contains(userID);
        }

        private static void RefreshCache()
        {
            _immersibrookUsers = new HashSet<long?>();

            Search<User> userSearch = new Search<User>(new BooleanSearchCondition<User>()
            {
                Field = nameof(User.IsImmersibrook),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = true
            });

            _immersibrookUsers = new HashSet<long?>(userSearch.GetReadOnlyReader(null, new[] { nameof(User.IsImmersibrook) }).Select(u => u.UserID));

            _cacheRefresh = DateTime.Now.AddSeconds(30);
        }
    }
}
