using System.Collections.Generic;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
using WebModels.gov;

namespace WebModels.fleet
{
    [Table("8D14543C-895B-409B-B2EF-9298AF326273")]
    public class TrainSymbol : DataObject
    {
        protected TrainSymbol() : base() { }

        private long? _trainSymbolID;
        [Field("8CF91B57-5FDA-43A5-BDD5-04E8F93F0CBA")]
        public long? TrainSymbolID
        {
            get { CheckGet(); return _trainSymbolID; }
            set { CheckSet(); _trainSymbolID = value; }
        }

        private long? _companyIDOperator;
        [Field("C9D296F5-FC5D-4F31-8DFE-170174023AC3")]
        public long? CompanyIDOperator
        {
            get { CheckGet(); return _companyIDOperator; }
            set { CheckSet(); _companyIDOperator = value; }
        }

        private Company _companyOperator = null;
        [Relationship("FAACA34A-7A69-4723-8959-3B125AFAB119", ForeignKeyField = nameof(CompanyIDOperator))]
        public Company CompanyOperator
        {
            get { CheckGet(); return _companyOperator; }
        }

        private long? _governmentIDOperator;
        [Field("D6D6D7E8-E892-4BA6-A4E3-E831C2B70C4B")]
        public long? GovernmentIDOperator
        {
            get { CheckGet(); return _governmentIDOperator; }
            set { CheckSet(); _governmentIDOperator = value; }
        }

        private Government _governmentOperator = null;
        [Relationship("767ED93E-C1D9-4C50-A53A-EC674B85ED20", ForeignKeyField = nameof(GovernmentIDOperator))]
        public Government GovernmentOperator
        {
            get { CheckGet(); return _governmentOperator; }
        }

        private string _name;
        [Field("25AF32D5-5DE1-4E08-87FE-9DB04AB8C1CD", DataSize = 15)]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        private string _description;
        [Field("D82E57A3-88CB-4789-B2E4-24C24D9AFD1C", DataSize = 200)]
        public string Description
        {
            get { CheckGet(); return _description; }
            set { CheckSet(); _description = value; }
        }

        #region Relationships
        #region fleet
        private List<Train> _trains = new List<Train>();
        [RelationshipList("C154F5C3-5080-4B8F-A041-7FCAF4B0838C", nameof(Train.TrainSymbolID))]
        public IReadOnlyCollection<Train> Trains
        {
            get { CheckGet(); return _trains; }
        }

        private List<TrainSymbolRate> _trainSymbolRates = new List<TrainSymbolRate>();
        [RelationshipList("2C92A970-766D-420D-9E58-FDCA133963E6", nameof(TrainSymbolRate.TrainSymbolID))]
        public IReadOnlyCollection<TrainSymbolRate> TrainSymbolRates
        {
            get { CheckGet(); return _trainSymbolRates; }
        }
        #endregion
        #endregion
    }
}
