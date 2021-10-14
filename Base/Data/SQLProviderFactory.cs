using ClussPro.Base.Data.Query;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace ClussPro.Base.Data
{
    public class SQLProviderFactory
    {
        private ISQLProvider _provider;
        private static bool isLoading = false;

        private static SQLProviderFactory _instance;
        private static SQLProviderFactory GetInstance()
        {
            while (isLoading) { Thread.Sleep(50); }
            if (_instance == null)
            {
                _instance = new SQLProviderFactory();
            }

            return _instance;
        }

        private SQLProviderFactory()
        {
            isLoading = true;
            Assembly providerAssembly = Assembly.LoadFrom(BaseConfig.SQLProviderPath);

            Type sqlProviderType = typeof(ISQLProvider);
            Type sqlProvider = providerAssembly.GetTypes().FirstOrDefault(t => t != sqlProviderType && sqlProviderType.IsAssignableFrom(t));
            if (sqlProvider == null)
            {
                isLoading = false;
                throw new EntryPointNotFoundException("Could not find a SQL Provider in the specified assembly");
            }

            _provider = (ISQLProvider)Activator.CreateInstance(sqlProvider);
            isLoading = false;
        }

        public static ISelectQuery GetSelectQuery()
        {
            return GetInstance()._provider.GetSelectQuery();
        }

        public static IUpdateQuery GetUpdateQuery()
        {
            return GetInstance()._provider.GetUpdateQuery();
        }

        public static IDeleteQuery GetDeleteQuery()
        {
            return GetInstance()._provider.GetDeleteQuery();
        }

        public static IInsertQuery GetInsertQuery()
        {
            return GetInstance()._provider.GetInsertQuery();
        }

        public static ITransaction GenerateTransaction(string connectionName = "_default")
        {
            return GetInstance()._provider.GenerateTransaction(connectionName);
        }

        public static ICreateSchema GetCreateSchemaQuery()
        {
            return GetInstance()._provider.GetCreateSchemaQuery();
        }

        public static ICreateTable GetCreateTableQuery()
        {
            return GetInstance()._provider.GetCreateTableQuery();
        }

        public static IAlterTable GetAlterTableQuery()
        {
            return GetInstance()._provider.GetAlterTableQuery();
        }

        public static IDropSchema GetDropSchemaQuery()
        {
            return GetInstance()._provider.GetDropSchemaQuery();
        }

        public static IDropTable GetDropTableQuery()
        {
            return GetInstance()._provider.GetDropTableQuery();
        }
    }
}
