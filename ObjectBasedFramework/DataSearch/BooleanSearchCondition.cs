using ClussPro.Base.Data.Operand;
using System;

namespace ClussPro.ObjectBasedFramework.DataSearch
{
    public class BooleanSearchCondition : SearchCondition
    {
        public BooleanSearchCondition(Type dataObjectType) : base(dataObjectType) { }

        public bool Value { get; set; }

        protected override IOperand GetRightOperand()
        {
            if (SearchConditionType == SearchConditionTypes.List || SearchConditionType == SearchConditionTypes.NotList)
            {
                throw new InvalidOperationException("List-type search conditions are invalid with BooleanSearchConditions");
            }
            else
            {
                return new Literal(Value);
            }
        }
    }

    public class BooleanSearchCondition<T> : BooleanSearchCondition where T:DataObject
    {
        public BooleanSearchCondition() : base(typeof(T)) { }
    }
}
