using ClussPro.Base.Data.Query;

namespace WebModels.Migrations
{
    public interface IMigration
    {
        int MigrationNumber { get; }
        void Execute(ITransaction transaction);
    }
}
