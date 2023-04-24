using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.SqlServerProvider.Extensions;
using ClussPro.SqlServerProvider.ScriptWriters;
using System;
using System.Data.SqlClient;
using System.Text;

namespace ClussPro.SqlServerProvider
{
    public class AlterTableQuery : BaseTransactionalQuery, IAlterTable
    {
        public string Schema { get; set; }
        public string Table { get; set; }

        public void AddColumn(string columnName, FieldSpecification fieldSpecification, ITransaction transaction = null)
        {
            CheckedTransactionExecute(transaction, localTransaction =>
            {
                StringBuilder sqlBuilder = new StringBuilder("ALTER TABLE ");
                sqlBuilder.Append($"[{Schema}].[{Table}] ");
                sqlBuilder.Append($"ADD {columnName} {fieldSpecification.ToSqlDataType()}");
                string defaultParameterName = null;
                if (fieldSpecification.DefaultValue != null)
                {
                    defaultParameterName = Guid.NewGuid().ToString("N");
                    sqlBuilder.Append($"DEFAULT @{defaultParameterName}");
                }

                using (SqlCommand command = new SqlCommand(sqlBuilder.ToString(), localTransaction.SQLTransaction.Connection, localTransaction.SQLTransaction))
                {
                    if (defaultParameterName != null)
                    {
                        command.Parameters.AddWithValue(defaultParameterName, fieldSpecification.DefaultValue);
                    }

                    command.ExecuteNonQuery();
                }
            });
        }

        public void AddForeignKey(string constraintName, string foreignKeyName, string parentSchema, string parentTable, string parentField, ITransaction transaction = null)
        {
            CheckedTransactionExecute(transaction, (localTransaction) =>
            {
                StringBuilder sqlBuilder = new StringBuilder("ALTER TABLE ");
                sqlBuilder.Append($"[{Schema}].[{Table}] ADD CONSTRAINT {constraintName} FOREIGN KEY");
                sqlBuilder.Append($"({foreignKeyName}) REFERENCES [{parentSchema}].[{parentTable}] ({parentField})");

                using (SqlCommand command = new SqlCommand(sqlBuilder.ToString(), localTransaction.SQLTransaction.Connection, localTransaction.SQLTransaction))
                {
                    command.ExecuteNonQuery();
                }
            });
        }

        public void DropConstraint(string constraintName, ITransaction transaction = null)
        {
            CheckedTransactionExecute(transaction, localTransaction =>
            {
                StringBuilder sqlBuilder = new StringBuilder("ALTER TABLE ");
                sqlBuilder.Append($"[{Schema}].[{Table}] DROP CONSTRAINT {constraintName}");

                using (SqlCommand command = new SqlCommand(sqlBuilder.ToString(), localTransaction.SQLTransaction.Connection, localTransaction.SQLTransaction))
                {
                    command.ExecuteNonQuery();
                }
            });
        }
    }
}
