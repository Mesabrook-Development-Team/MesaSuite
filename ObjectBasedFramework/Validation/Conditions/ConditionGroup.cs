using ClussPro.Base.Data.Conditions;
using ClussPro.Base.Data.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClussPro.ObjectBasedFramework.Validation.Conditions
{
    public class ConditionGroup : Condition
    {
        public ConditionGroup() : base() { }

        public ConditionGroup(ConditionGroupTypes conditionGroupType) : base()
        {
            ConditionGroupType = conditionGroupType;
        }

        public ConditionGroup(ConditionGroupTypes conditionGroupType, params Condition[] conditions) : this(conditionGroupType)
        {
            Conditions = conditions.ToList();
        }

        public ConditionGroupTypes ConditionGroupType { get; set; }
        public List<Condition> Conditions { get; set; } = new List<Condition>();
        public enum ConditionGroupTypes
        {
            And,
            Or
        }

        public override IEnumerable<string> AdditionalDataObjectFields => Conditions.SelectMany(condition => condition.AdditionalDataObjectFields);

        public override bool Evaluate(DataObject dataObject, ITransaction transaction)
        {
            switch(ConditionGroupType)
            {
                case ConditionGroupTypes.And:
                    return Conditions.TrueForAll(condition => condition.Evaluate(dataObject, transaction));
                case ConditionGroupTypes.Or:
                    return Conditions.Any(condition => condition.Evaluate(dataObject, transaction));
                default:
                    return true;
            }
        }
    }
}
