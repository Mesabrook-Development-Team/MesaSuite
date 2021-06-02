using ClussPro.Base.Data.Conditions;
using System.Collections.Generic;

namespace ClussPro.Base.Data.Operand
{
    public class Case : IOperand
    {
        public List<When> Whens { get; set; } = new List<When>();
        public IOperand Else { get; set; }

        public class When
        {
            public ICondition Condition { get; set; }
            public IOperand Result { get; set; }
        }
    }
}
