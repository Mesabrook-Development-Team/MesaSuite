using ClussPro.Base.Data;
using ClussPro.Base.Data.Conditions;
using ClussPro.Base.Data.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClussPro.SqlServerProvider
{
    public class SelectQuery : BaseTransactionalQuery, ISelectQuery
    {
        public List<Select> SelectList { get; set; } = new List<Select>();
        public Table Table { get; set; }
        public ICondition WhereCondition { get; set; }
        public List<Join> JoinList { get; set; } = new List<Join>();
        public int PageSize { get; set; } = -1;
        public List<Order> OrderByList { get; set; } = new List<Order>();

        public DataTable Execute(ITransaction transaction)
        {
            return CheckedTransactionExecuteWithResult(transaction, localTransaction =>
            {
                DataTable dataTable = new DataTable();
                using (SqlCommand command = new SqlCommand(null, localTransaction.SQLTransaction.Connection, localTransaction.SQLTransaction))
                {
                    string sql = GetSQL(command.Parameters);
                    command.CommandText = sql;

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        foreach (DataRow row in dataReader.GetSchemaTable().Rows)
                        {
                            dataTable.Columns.Add(row["ColumnName"] as string, row["DataType"] as Type);
                        }

                        while (dataReader.Read())
                        {
                            DataRow row = dataTable.NewRow();
                            foreach (DataColumn column in dataTable.Columns)
                            {
                                object rawValue = dataReader[column.ColumnName];
                                object convertedValue = rawValue == DBNull.Value ? DBNull.Value : Convert.ChangeType(rawValue, column.DataType);

                                row[column] = convertedValue;
                            }

                            dataTable.Rows.Add(row);
                        }
                    }
                }

                return dataTable;
            }) as DataTable;
        }

        internal string GetSQL(SqlParameterCollection parameters)
        {
            StringBuilder sqlBuilder = new StringBuilder("SELECT ");

            if (PageSize != -1)
            {
                sqlBuilder.Append($"TOP {PageSize} ");
            }

            WriteSelectList(sqlBuilder, parameters);

            if (Table != null)
            {
                sqlBuilder.Append($"FROM {ScriptWriters.TableWriter.WriteTable(Table)} ");
            }

            WriteJoinList(sqlBuilder, parameters);

            if (WhereCondition != null)
            {
                sqlBuilder.Append($"WHERE {ScriptWriters.ConditionWriter.WriteCondition(WhereCondition, parameters)} ");
            }

            return sqlBuilder.ToString();
        }

        private void WriteSelectList(StringBuilder sqlBuilder, SqlParameterCollection parameters)
        {
            bool first = true;
            foreach (Select select in SelectList)
            {
                if (!first)
                {
                    sqlBuilder.Append(", ");
                }
                first = false;

                sqlBuilder.Append(ScriptWriters.OperandWriter.WriteOperand(select.SelectOperand, parameters));

                if (!string.IsNullOrEmpty(select.Alias))
                {
                    sqlBuilder.Append($" AS {select.Alias}");
                }
            }

            sqlBuilder.Append(" ");
        }

        private void WriteJoinList(StringBuilder sqlBuilder, SqlParameterCollection parameters)
        {
            foreach(Join join in JoinList)
            {
                switch(join.JoinType)
                {
                    case Join.JoinTypes.Inner:
                        sqlBuilder.Append("INNER ");
                        break;
                    case Join.JoinTypes.Left:
                        sqlBuilder.Append("LEFT ");
                        break;
                    default:
                        throw new InvalidCastException("Could not determine Join Type when writing");
                }

                sqlBuilder.Append("JOIN ");
                sqlBuilder.Append(ScriptWriters.TableWriter.WriteTable(join.Table));
                sqlBuilder.Append(" ON ");
                sqlBuilder.Append(ScriptWriters.ConditionWriter.WriteCondition(join.Condition, parameters));
                sqlBuilder.Append(" ");
            }
        }

        private void WriteOrderList(StringBuilder sqlBuilder, SqlParameterCollection parameters)
        {
            if (!OrderByList.Any())
            {
                return;
            }

            sqlBuilder.Append(" ORDER BY ");
            bool first = true;
            foreach(Order order in OrderByList)
            {
                if (!first)
                {
                    sqlBuilder.Append(", ");
                }

                first = false;
                sqlBuilder.Append(ScriptWriters.OrderWriter.WriteOrder(order, parameters));
            }
        }
    }
}
