namespace ClussPro.Base.Data.Operand
{
    public class Count : IOperand
    {
        public IOperand Of { get; set; }

        public Count(IOperand of)
        {
            Of = of;
        }
    }
}
