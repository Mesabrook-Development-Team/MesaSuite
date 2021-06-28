using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data.Query;

namespace DatabaseMigration.Migrations
{
    public class Migration000001 : IMigration
    {
        public int MigrationNumber => 1;

        public void Execute(ITransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
