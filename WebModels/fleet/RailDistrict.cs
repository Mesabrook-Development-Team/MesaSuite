using System.Collections.Generic;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
using WebModels.gov;

namespace WebModels.fleet
{
    [Table("48602ED1-6509-49F4-8DEE-F8FBB1D0616B")]
    public class RailDistrict : DataObject
    {
        protected RailDistrict() : base() { }

        private long? _railDistrictID;
        [Field("AF09EA37-81AE-4B19-8312-264D610D187A")]
        public long? RailDistrictID
        {
            get { CheckGet(); return _railDistrictID; }
            set { CheckSet(); _railDistrictID = value; }
        }

        private long? _companyIDOperator;
        [Field("FA5F0770-1705-43AF-A195-58EDEE552A3A")]
        public long? CompanyIDOperator
        {
            get { CheckGet(); return _companyIDOperator; }
            set { CheckSet(); _companyIDOperator = value; }
        }

        private Company _companyOperator = null;
        [Relationship("55A4722B-7762-49A9-9D01-944AB8A6AE6B", ForeignKeyField = nameof(CompanyIDOperator))]
        public Company CompanyOperator
        {
            get { CheckGet(); return _companyOperator; }
        }

        private long? _governmentIDOperator;
        [Field("1A7344BA-249E-4754-9926-F6AA9EE16C41")]
        public long? GovernmentIDOperator
        {
            get { CheckGet(); return _governmentIDOperator; }
            set { CheckSet(); _governmentIDOperator = value; }
        }

        private Government _governmentOperator = null;
        [Relationship("9684E8B6-86AA-46D6-AFA2-047E76EA8710", ForeignKeyField = nameof(GovernmentIDOperator))]
        public Government GovernmentOperator
        {
            get { CheckGet(); return _governmentOperator; }
        }

        private string _name;
        [Field("94F33093-62E5-4F1B-A774-36CE7706BC77", DataSize = 50)]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        #region Relationships
        #region fleet
        private List<Track> _tracks = new List<Track>();
        [RelationshipList("5A874719-E581-40FF-85A1-6912FFBD664A", nameof(Track.RailDistrictID))]
        public IReadOnlyCollection<Track> Tracks
        {
            get { CheckGet(); return _tracks; }
        }
        #endregion
        #endregion
    }
}
