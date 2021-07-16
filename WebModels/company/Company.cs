using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System.Collections.Generic;

namespace WebModels.company
{
    [Table("A093C2E1-2DF9-4BF2-A56C-2C3B99073792")]
    public class Company : DataObject
    {
        protected Company() : base() { }

        private long? _companyID;
        [Field("4C5C6ED3-055B-405C-B888-4B40A799FAC0")]
        public long? CompanyID
        {
            get { CheckGet(); return _companyID; }
            set { CheckSet(); _companyID = value; }
        }

        private string _name;
        [Field("BBEE1AE6-34F3-4BCB-90AA-A137CE7EA655", DataSize = 50)]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        #region Relationships
        private List<Employee> _employees = new List<Employee>();
        [RelationshipList("6C0E982B-0D55-466E-8E56-9A466D7A982C", "CompanyID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<Employee> Employees
        {
            get { CheckGet(); return _employees; }
        }
        #endregion
    }
}
