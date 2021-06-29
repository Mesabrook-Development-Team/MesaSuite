using ClussPro.Base.Data.Query;
using System.Data.SqlClient;

namespace ClussPro.SqlServerProvider.ScriptWriters
{
    internal static class OrderWriter
    {
        public static string WriteOrder(Order order, SqlParameterCollection parameters)
        {
            string sql = OperandWriter.WriteOperand(order.Field, parameters);

            switch(order.OrderDirection)
            {
                case Order.OrderDirections.Ascending:
                    sql += " ASC";
                    break;
                case Order.OrderDirections.Descending:
                    sql += " DESC";
                    break;
            }

            return sql;
        }
    }
}
