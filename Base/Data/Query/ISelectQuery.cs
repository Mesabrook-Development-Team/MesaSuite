using ClussPro.Base.Data.Conditions;
using System.Collections.Generic;
using System.Data;

namespace ClussPro.Base.Data.Query
{
    public interface ISelectQuery
    {
        string ConnectionName { get; set; }
        List<Select> SelectList { get; set; }
        ISelectable Table { get; set; }
        ICondition WhereCondition { get; set; }
        List<Join> JoinList { get; set; }
        int PageSize { get; set; }
        List<Order> OrderByList { get; set; }

        DataTable Execute(ITransaction transaction);
    }
}
