using ClussPro.Base.Data.Query;

namespace DatabaseMigration.Migrations
{
    public interface IMigration
    {
        int MigrationNumber { get; }
        void Execute(ITransaction transaction);
    }
}
