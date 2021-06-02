using ClussPro.Base.Data.Conditions;
using System.Collections.Generic;
using System.Linq;

namespace ClussPro.ObjectBasedFramework.DataSearch
{
    public class SearchConditionGroup : ISearchCondition
    {
        public SearchConditionGroup() { }
        public SearchConditionGroup(SearchConditionGroupTypes searchConditionGroupType, params ISearchCondition[] searchConditions)
        {
            SearchConditionGroupType = searchConditionGroupType;
            SearchConditions = searchConditions.ToList();
        }

        public SearchConditionGroupTypes SearchConditionGroupType { get; set; }
        public List<ISearchCondition> SearchConditions { get; set; }

        public enum SearchConditionGroupTypes
        {
            And,
            Or
        }

        public ICondition GetCondition(Dictionary<string, string> tableAliasesByFieldPath, string upperFieldPathToIgnore = "", string[] ignoredUpperFieldPaths = null)
        {
            ConditionGroup conditionGroup = new ConditionGroup();
            if (SearchConditionGroupType == SearchConditionGroupTypes.And)
            {
                conditionGroup.ConditionGroupType = ConditionGroup.ConditionGroupTypes.And;
            }
            else
            {
                conditionGroup.ConditionGroupType = ConditionGroup.ConditionGroupTypes.Or;
            }

            conditionGroup.Conditions.AddRange(SearchConditions.Select(sc => sc.GetCondition(tableAliasesByFieldPath, upperFieldPathToIgnore, ignoredUpperFieldPaths)).Where(condition => condition != null));

            if (conditionGroup.Conditions.Any())
            {
                return conditionGroup;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<string> GetFieldPaths()
        {
            return SearchConditions.SelectMany(sc => sc.GetFieldPaths());
        }
    }
}
