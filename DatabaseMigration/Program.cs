using ClussPro.Base.Data;
using ClussPro.Base.Data.Operand;
using ClussPro.Base.Data.Query;
using DatabaseMigration.Migrations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DatabaseMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Determining last migration number");
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

            int maxMigration = result.Rows.Count != 0 ? (int)result.Rows[0][0] : 0;

            Console.WriteLine("Loading migrations");
            List<IMigration> migrations = new List<IMigration>();
            foreach(Type migration in Assembly.GetExecutingAssembly().GetTypes().Where(t => t != typeof(IMigration) && typeof(IMigration).IsAssignableFrom(t)))
            {
                migrations.Add((IMigration)Activator.CreateInstance(migration));
            }

            migrations = migrations.Where(m => m.MigrationNumber > maxMigration).OrderBy(m => m.MigrationNumber).ToList();

            foreach(IMigration migration in migrations)
            {
                Console.Write("Running migration {0} ", migration.MigrationNumber);
                ConsoleColor foregroundColor = Console.ForegroundColor;

                ITransaction transaction = null;
                try
                {
                    transaction = SQLProviderFactory.GenerateTransaction();
                    migration.Execute(transaction);
                    transaction.Commit();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("SUCCESS");
                    Console.ForegroundColor = foregroundColor;
                }
                catch(Exception ex)
                {
                    if (transaction != null && transaction.IsActive)
                    {
                        transaction.Rollback();
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("FAILED");
                    Console.ForegroundColor = foregroundColor;
                    Console.WriteLine();
                    Console.WriteLine(ex.ToString());

                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Database Migration execution complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
