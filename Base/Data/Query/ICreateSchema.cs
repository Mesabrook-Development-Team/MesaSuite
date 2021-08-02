namespace ClussPro.Base.Data.Query
{
    public interface ICreateSchema
    {
        string ConnectionName { get; set; }
        string SchemaName { get; set; }

        void Execute(ITransaction transaction);
    }
}
