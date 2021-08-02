namespace ClussPro.Base.Data.Query
{
    public interface IDropSchema
    {
        string ConnectionName { get; set; }
        string Schema { get; set; }
        void Execute(ITransaction transaction);
    }
}
