using ClussPro.Base.Data.Operand;
using System;
using System.Collections.Generic;

namespace ClussPro.ObjectBasedFramework.DataSearch
{
    public class DateTimeSearchCondition : SearchCondition
    {
        public DateTimeSearchCondition(Type dataObjectType) : base(dataObjectType) { }
        public DateTime? Value { get; set; }
        public List<DateTime?> Values { get; set; } = new List<DateTime?>();

        protected override IOperand GetRightOperand()
        {
            if (SearchConditionType == SearchConditionTypes.List || SearchConditionType == SearchConditionTypes.NotList)
            {
                return (CSV<DateTime?>)Values;
            }
            else
            {
                return new Literal(Value);
            }
        }
    }

    public class DateTimeSearchCondition<T> : DateTimeSearchCondition where T:DataObject
    {
        public DateTimeSearchCondition() : base(typeof(T)) { }
    }
}
