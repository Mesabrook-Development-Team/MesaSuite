using ClussPro.Base.Data.Operand;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClussPro.ObjectBasedFramework.DataSearch
{
    public class IntSearchCondition : SearchCondition
    {
        public IntSearchCondition(Type dataObjectType) : base(dataObjectType) { }

        public int? Value { get; set; }
        public List<int> List { get; set; } = new List<int>();

        protected override IOperand GetRightOperand()
        {
            if (List != null && List.Any())
            {
                return (CSV<int>)List;
            }

            return new Literal(Value);
        }
    }

    public class IntSearchCondition<TDataObject> : IntSearchCondition where TDataObject : DataObject
    {
        public IntSearchCondition() : base(typeof(TDataObject)) { }
    }
}
