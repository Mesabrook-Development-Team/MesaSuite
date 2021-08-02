using ClussPro.Base.Data.Conditions;

namespace ClussPro.Base.Data.Query
{
    public interface IDeleteQuery
    {
        string ConnectionName { get; set; }
        Table Table { get; set; }
        ICondition Condition { get; set; }

        void Execute(ITransaction transaction);
    }
}
