using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClussPro.SqlServerProvider
{
    public class InsertQuery : BaseTransactionalQuery, IInsertQuery
    {
        public Table Table { get; set; }
        public List<FieldValue> FieldValueList { get; set; } = new List<FieldValue>();

        public T Execute<T>(ITransaction transaction)
        {
            return (T)CheckedTransactionExecuteWithResult(transaction, localTransaction =>
            {
                T primaryKey = default(T);
                using (SqlCommand command = new SqlCommand(null, localTransaction.SQLTransaction.Connection, localTransaction.SQLTransaction))
                {
                    command.CommandText = GetSQL(command.Parameters);
                    primaryKey = (T)Convert.ChangeType(command.ExecuteScalar(), typeof(T));
                }

                return primaryKey;
            });
        }

        private string GetSQL(SqlParameterCollection parameters)
        {
            StringBuilder sqlBuilder = new StringBuilder("INSERT INTO ");
            sqlBuilder.Append(ScriptWriters.SelectableWriter.WriteSelectable(Table, parameters));
            sqlBuilder.Append(" (");

            bool first = true;
            foreach(FieldValue fieldValue in FieldValueList)
            {
                if (!first)
                {
                    sqlBuilder.Append(", ");
                }

                first = false;

                sqlBuilder.Append($"[{fieldValue.FieldName}]");
            }

            sqlBuilder.Append(") VALUES (");

            first = true;
            foreach(FieldValue fieldValue in FieldValueList)
            {
                if (!first)
                {
                    sqlBuilder.Append(", ");
                }

                first = false;

                string parameterNumber = parameters.Count.ToString();
                sqlBuilder.Append($"@{parameterNumber}");
                parameters.AddWithValue(parameterNumber, fieldValue.Value ?? (fieldValue.FieldType == FieldSpecification.FieldTypes.Binary ? (object)SqlBinary.Null : (object)DBNull.Value));
            }

            sqlBuilder.Append("); SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]");

            return sqlBuilder.ToString();
        }
    }
}
