using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.SqlServerProvider.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ClussPro.SqlServerProvider
{
    public class CreateTableQuery : BaseTransactionalQuery, ICreateTable
    {
        public string SchemaName { get; set; }
        public string TableName { get; set; }
        public Dictionary<string, FieldSpecification> Columns { get; set; } = new Dictionary<string, FieldSpecification>();

        public void Execute(ITransaction transaction)
        {
            CheckedTransactionExecute(transaction, (localTransaction) =>
            {
                using (SqlCommand command = new SqlCommand(null, localTransaction.SQLTransaction.Connection, localTransaction.SQLTransaction))
                {
                    command.CommandText = GetSQL();
                    command.ExecuteNonQuery();
                }
            });
        }

        private string GetSQL()
        {
            StringBuilder builder = new StringBuilder("CREATE TABLE ");
            builder.Append($"[{SchemaName}].[{TableName}] (");

            bool first = true;
            foreach(KeyValuePair<string, FieldSpecification> col in Columns)
            {
                if (!first)
                {
                    builder.Append(", ");
                }
                first = false;

                builder.Append($"[{col.Key}] {col.Value.ToSqlDataType()} ");

                if (col.Value.IsPrimary)
                {
                    builder.Append("PRIMARY KEY IDENTITY ");
                }

                if (col.Value.DefaultValue != null)
                {
                    builder.Append($"DEFAULT '{col.Value.DefaultValue}' NOT NULL");
                }
            }

            builder.Append(")");

            return builder.ToString();
        }
    }
}
