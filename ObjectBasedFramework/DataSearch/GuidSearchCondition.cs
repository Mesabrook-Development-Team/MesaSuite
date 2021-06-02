using ClussPro.Base.Data.Operand;
using System;
using System.Collections.Generic;

namespace ClussPro.ObjectBasedFramework.DataSearch
{
    public class GuidSearchCondition : SearchCondition
    {
        public GuidSearchCondition(Type dataObjectType) : base(dataObjectType) { }

        public Guid? Value { get; set; }
        public List<Guid?> Values { get; set; } = new List<Guid?>();

        protected override IOperand GetRightOperand()
        {
            if (SearchConditionType == SearchConditionTypes.List || SearchConditionType == SearchConditionTypes.NotList)
            {
                return (CSV<Guid?>)Values;
            }
            else
            {
                return new Literal(Value);
            }
        }
    }

    public class GuidSearchCondition<T> : GuidSearchCondition where T:DataObject
    {
        public GuidSearchCondition() : base(typeof(T)) { }
    }
}
