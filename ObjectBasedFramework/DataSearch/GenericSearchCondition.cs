using ClussPro.Base.Data.Operand;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClussPro.ObjectBasedFramework.DataSearch
{
    public class GenericSearchCondition : SearchCondition
    {
        public GenericSearchCondition(Type dataObjectType) : base(dataObjectType) { }

        public object Value { get; set; }
        public List<object> Values { get; set; }

        protected override IOperand GetRightOperand()
        {
            if (Values != null && Values.Any())
            {
                return (CSV<object>)Values;
            }

            return new Literal(Value);
        }
    }

    public class GenericSearchCondition<T> : GenericSearchCondition where T:DataObject
    {
        public GenericSearchCondition() : base(typeof(T)) { }
    }
}
