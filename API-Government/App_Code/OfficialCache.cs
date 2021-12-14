using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebModels.gov;

namespace API_Government.App_Code
{
    public class OfficialCache
    {
        private static Dictionary<long, Dictionary<long, CachedOfficial>> _officialsByUserIDByGovernmentID = new Dictionary<long, Dictionary<long, CachedOfficial>>();

        public async static Task<CachedOfficial> GetCachedOfficial(long governmentID, long userID)
        {
            if (!_officialsByUserIDByGovernmentID.ContainsKey(governmentID))
            {
                _officialsByUserIDByGovernmentID[governmentID] = new Dictionary<long, CachedOfficial>();
            }

            if (!_officialsByUserIDByGovernmentID[governmentID].ContainsKey(userID) || _officialsByUserIDByGovernmentID[governmentID][userID].CacheExpiration <= DateTime.Now)
            {
                Search<Official> officialSearch = new Search<Official>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<Official>()
                    {
                        Field = "UserID",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = userID
                    },
                    new LongSearchCondition<Official>()
                    {
                        Field = "GovernmentID",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = governmentID
                    }));

                HashSet<string> fields = new HashSet<string>(Official.GetPermissionFieldNames())
                {
                    nameof(Official.OfficialID),
                    nameof(Official.UserID),
                    nameof(Official.GovernmentID)
                };

                Official official = await Task.Run(() => officialSearch.GetReadOnly(null, fields));

                CachedOfficial cachedOfficial = new CachedOfficial()
                {
                    CacheExpiration = DateTime.Now.AddSeconds(30),
                    UserID = userID,
                    GovernmentID = governmentID
                };

                if (official != null)
                {
                    cachedOfficial.OfficialID = official.OfficialID.Value;

                    SchemaObject officialSchemaObject = Schema.GetSchemaObject<Official>();
                    foreach(string permissionField in Official.GetPermissionFieldNames())
                    {
                        Field field = officialSchemaObject.GetField(permissionField);
                        if ((bool)field.GetValue(official))
                        {
                            cachedOfficial.Permissions.Add(permissionField);
                        }
                    }
                }

                _officialsByUserIDByGovernmentID[governmentID][userID] = cachedOfficial;
            }

            return _officialsByUserIDByGovernmentID[governmentID][userID];
        }

        public class CachedOfficial
        {
            public long GovernmentID { get; set; }
            public long OfficialID { get; set; }
            public long UserID { get; set; }
            public DateTime CacheExpiration { get; set; }
            public HashSet<string> Permissions { get; set; } = new HashSet<string>();
        }
    }
}