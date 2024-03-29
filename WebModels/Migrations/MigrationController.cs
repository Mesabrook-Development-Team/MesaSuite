﻿using ClussPro.Base.Data;
using ClussPro.Base.Data.Operand;
using ClussPro.Base.Data.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace WebModels.Migrations
{
    public class MigrationController
    {
        public static void Run(Action<string> statusCallback)
        {
            statusCallback?.Invoke("Determining last migration number");
            ISelectQuery selectQuery = SQLProviderFactory.GetSelectQuery();
            selectQuery.Table = new Table("mesasys", "MigrationHistory");
            selectQuery.PageSize = 1;
            selectQuery.SelectList = new List<Select>()
            {
                new Select() { SelectOperand = (Field)"MigrationNumber" }
            };
            selectQuery.OrderByList = new List<Order>()
            {
                new Order()
                {
                    Field = "MigrationNumber",
                    OrderDirection = Order.OrderDirections.Descending
                }
            };

            DataTable result = selectQuery.Execute(null);

            int maxMigration = result.Rows.Count != 0 ? (int)result.Rows[0][0] : -1;

            statusCallback?.Invoke("Loading migrations");
            List<IMigration> migrations = new List<IMigration>();
            foreach(Type migration in Assembly.GetExecutingAssembly().GetTypes().Where(t => t != typeof(IMigration) && typeof(IMigration).IsAssignableFrom(t)))
            {
                migrations.Add((IMigration)Activator.CreateInstance(migration));
            }

            migrations = migrations.Where(m => m.MigrationNumber > maxMigration).OrderBy(m => m.MigrationNumber).ToList();

            if (maxMigration == -1)
            {
                statusCallback?.Invoke("No migration history found.  Assuming fresh database.  Setting max migration number.");

                IInsertQuery insert = SQLProviderFactory.GetInsertQuery();
                insert.Table = new Table("mesasys", "MigrationHistory");
                insert.FieldValueList.Add(new FieldValue()
                {
                    FieldName = "MigrationNumber",
                    Value = migrations.Max(mig => mig.MigrationNumber)
                });
                insert.Execute<long>(null);
            }
            else
            {
                foreach (IMigration migration in migrations)
                {
                    Console.Write("Running migration {0} ", migration.MigrationNumber);

                    ITransaction transaction = null;
                    try
                    {
                        transaction = SQLProviderFactory.GenerateTransaction();
                        migration.Execute(transaction);

                        IUpdateQuery updateQuery = SQLProviderFactory.GetUpdateQuery();
                        updateQuery.Table = new Table("mesasys", "MigrationHistory");
                        updateQuery.FieldValueList = new List<FieldValue>()
                        {
                            new FieldValue() { FieldName = "MigrationNumber", Value = migration.MigrationNumber }
                        };
                        updateQuery.Execute(transaction);

                        transaction.Commit();

                        statusCallback?.Invoke("SUCCESS");
                    }
                    catch (Exception ex)
                    {
                        if (transaction != null && transaction.IsActive)
                        {
                            transaction.Rollback();
                        }

                        statusCallback?.Invoke("FAILED");
                        statusCallback?.Invoke("");
                        statusCallback?.Invoke(ex.ToString());

                        break;
                    }
                }
            }

            statusCallback?.Invoke("");
            statusCallback?.Invoke("Database Migration execution complete.");
        }
    }
}
