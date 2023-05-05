namespace ClussPro.Base.Data.Operand
{
    public class IsNull : IOperand
    {
        public IOperand MainOperand { get; set; }
        public IOperand FallbackOperand { get; set; }

        public IsNull() { }
        public IsNull(IOperand mainOperand, IOperand fallbackOperand)
        {
            MainOperand = mainOperand;
            FallbackOperand = fallbackOperand;
        }
    }
}
