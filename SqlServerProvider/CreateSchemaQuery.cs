﻿using ClussPro.Base.Data.Query;
using System.Data.SqlClient;

namespace ClussPro.SqlServerProvider
{
    public class CreateSchemaQuery : BaseTransactionalQuery, ICreateSchema
    {
        public string SchemaName { get; set; }

        public void Execute(ITransaction transaction)
        {
            CheckedTransactionExecute(transaction, (localTransaction) =>
            {
                string sql = $" if not exists (select * from sys.schemas where name='{SchemaName}') exec('CREATE SCHEMA [{SchemaName}]')";

                using (SqlCommand command = new SqlCommand(sql, localTransaction.SQLTransaction.Connection, localTransaction.SQLTransaction))
                {
                    command.ExecuteNonQuery();
                }
            });
        }
    }
}
