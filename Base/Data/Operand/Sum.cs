namespace ClussPro.Base.Data.Operand
{
    public class Sum : IOperand
    {
        public IOperand SumOperand { get; set; }
        public Sum(IOperand sumOperand)
        {
            SumOperand = sumOperand;
        }
    }
}
