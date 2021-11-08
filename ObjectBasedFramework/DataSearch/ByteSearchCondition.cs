using ClussPro.Base.Data.Operand;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClussPro.ObjectBasedFramework.DataSearch
{
    public class ByteSearchCondition : SearchCondition
    {
        public ByteSearchCondition(Type dataObjectType) : base(dataObjectType) { }

        public byte? Value { get; set; }
        public List<byte> List { get; set; } = new List<byte>();

        protected override IOperand GetRightOperand()
        {
            if (List != null && List.Any())
            {
                return (CSV<byte>)List;
            }

            return new Literal(Value);
        }
    }

    public class ByteSearchCondition<TDataObject> : ByteSearchCondition where TDataObject:DataObject
    {
        public ByteSearchCondition() : base(typeof(TDataObject)) { }
    }
}
