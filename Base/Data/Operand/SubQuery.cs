using ClussPro.Base.Data.Query;

namespace ClussPro.Base.Data.Operand
{
    public class SubQuery : IOperand
    {
        public SubQuery() { }
        public SubQuery(ISelectQuery selectSubQuery)
        {
            this.SelectSubQuery = selectSubQuery;
        }
        public ISelectQuery SelectSubQuery { get; set; }
    }
}
