using ClussPro.Base.Data.Operand;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClussPro.ObjectBasedFramework.DataSearch
{
    public class ShortSearchCondition : SearchCondition
    {
        public ShortSearchCondition(Type dataObjectType) : base(dataObjectType) { }

        public short? Value { get; set; }
        public List<short> List { get; set; } = new List<short>();

        protected override IOperand GetRightOperand()
        {
            if (List != null && List.Any())
            {
                return (CSV<short>)List;
            }

            return new Literal(Value);
        }
    }

    public class ShortSearchCondition<TDataObject> : ShortSearchCondition where TDataObject:DataObject
    {
        public ShortSearchCondition() : base(typeof(TDataObject)) { }
    }
}
