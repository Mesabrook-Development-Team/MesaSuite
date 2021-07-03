using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System.Collections.Generic;
using WebModels.company;

namespace WebModels.gov
{
    [Table("D15CC830-79DE-4E62-B94C-C9B0BCDF87E1")]
    public class Government : DataObject
    {
        protected Government() : base() { }

        private long? _governmentID;
        [Field("1D644994-0A53-45E9-B390-4FAE8517F15A")]
        public long? GovernmentID
        {
            get { CheckGet(); return _governmentID; }
            set { CheckSet(); _governmentID = value; }
        }

        private string _name;
        [Field("F36C5AC3-A345-4B0E-808B-B6D205234659", DataSize = 50)]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        #region Relationships
        #region company
        private List<CompanyGovernment> _companyGovernments = new List<CompanyGovernment>();
        [RelationshipList("5BB7CEE6-A449-4DA2-9C00-C5BD6957E460", "GovernmentID")]
        public IReadOnlyCollection<CompanyGovernment> CompanyGovernments
        {
            get { CheckGet(); return _companyGovernments; }
        }
        #endregion
        #endregion
    }
}
