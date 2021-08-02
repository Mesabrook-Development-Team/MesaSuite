using System.Collections.Generic;

namespace ClussPro.Base.Data.Query
{
    public interface ICreateTable
    {
        string ConnectionName { get; set; }
        string SchemaName { get; set; }
        string TableName { get; set; }
        Dictionary<string, FieldSpecification> Columns { get; set; }

        void Execute(ITransaction transaction);
    }
}
