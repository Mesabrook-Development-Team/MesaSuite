﻿using ClussPro.Base.Data;
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
                if (fieldSpecification.DefaultValue != null)
                {
                    sqlBuilder.Append($"DEFAULT '{fieldSpecification.DefaultValue}' NOT NULL");
                }

                using (SqlCommand command = new SqlCommand(sqlBuilder.ToString(), localTransaction.SQLTransaction.Connection, localTransaction.SQLTransaction))
                {
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

        public void DropColumn(string columnName, ITransaction transaction)
        {
            CheckedTransactionExecute(transaction, trans =>
            {
                string query = $"ALTER TABLE [{Schema}].[{Table}] DROP COLUMN [{columnName}]";

                using(SqlCommand command = new SqlCommand(query, trans.SQLTransaction.Connection, trans.SQLTransaction))
                {
                    command.ExecuteNonQuery();
                }
            });
        }

        public void AlterColumn(string columnName, FieldSpecification fieldSpecification, ITransaction transaction = null)
        {
            CheckedTransactionExecute(transaction, trans =>
            {
                string query = $"ALTER TABLE [{Schema}].[{Table}] ALTER COLUMN [{columnName}] {fieldSpecification.ToSqlDataType()}";

                using (SqlCommand command = new SqlCommand(query, trans.SQLTransaction.Connection, trans.SQLTransaction))
                {
                    command.ExecuteNonQuery();
                }
            });
        }
    }
}
