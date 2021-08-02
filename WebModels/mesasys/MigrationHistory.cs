using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;

namespace WebModels.mesasys
{
    [Table("4DF8BD06-9BFF-435D-B19B-677C56B7ECCE")]
    public class MigrationHistory : DataObject
    {
        protected MigrationHistory() : base() { }

        private long? _migrationHistoryID;
        [Field("2333ACC1-1827-40D6-88BE-0B97C7238CEB")]
        public long? MigrationHistoryID
        {
            get { CheckGet(); return _migrationHistoryID; }
            set { CheckSet(); _migrationHistoryID = value; }
        }

        private int? _migrationNumber;
        [Field("29BFB35A-6C57-4F58-AE24-9013097158FB")]
        public int? MigrationNumber
        {
            get { CheckGet(); return _migrationNumber; }
            set { CheckSet(); _migrationNumber = value; }
        }
    }
}
