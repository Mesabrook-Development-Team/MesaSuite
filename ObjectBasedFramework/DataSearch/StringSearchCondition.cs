using ClussPro.Base.Data.Operand;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClussPro.ObjectBasedFramework.DataSearch
{
    public class StringSearchCondition : SearchCondition
    {
        public StringSearchCondition(Type dataObjectType) : base(dataObjectType) { }

        public string Value { get; set; }
        public List<string> Values { get; set; } = new List<string>();

        protected override IOperand GetRightOperand()
        {
            if (Values != null && Values.Any())
            {
                return (CSV<string>)Values;
            }

            return new Literal(Value);
        }
    }

    public class StringSearchCondition<T> : StringSearchCondition where T:DataObject
    {
        public StringSearchCondition() : base(typeof(T)) { }
    }
}
