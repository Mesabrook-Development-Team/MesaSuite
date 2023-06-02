using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    public class Migration000021 : IMigration
    {
        public int MigrationNumber => 21;

        public void Execute(ITransaction transaction)
        {
            IDeleteQuery deleteQuery = SQLProviderFactory.GetDeleteQuery();
            deleteQuery.Table = new Table("auth", "Token");
            deleteQuery.Execute(transaction);

            deleteQuery.Table = new Table("auth", "Client");
            deleteQuery.Execute(transaction);
        }
    }
}
