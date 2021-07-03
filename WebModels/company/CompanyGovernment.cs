using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.gov;

namespace WebModels.company
{
    [Table("B1BEEEEF-0FD2-417B-B59B-00202215F92F")]
    public class CompanyGovernment : DataObject
    {
        protected CompanyGovernment() : base() { }

        private long? _companyGovernmentID;
        [Field("F3602863-7D92-4891-9A9F-1B1433984961")]
        public long? CompanyGovernmentID
        {
            get { CheckGet(); return _companyGovernmentID; }
            set { CheckSet(); _companyGovernmentID = value; }
        }

        private long? _companyID;
        [Field("27E42D12-6365-46BD-801A-2ADB8CEC02D7")]
        public long? CompanyID
        {
            get { CheckGet(); return _companyID; }
            set { CheckSet(); _companyID = value; }
        }

        private Company _company = null;
        [Relationship("E2BEF5D9-6838-4585-8D48-A22328FF5CED")]
        public Company Company
        {
            get { CheckGet(); return _company; }
        }

        private long? _governmentID;
        [Field("D910B7E1-CA76-4C69-89B9-A80476855F68")]
        public long? GovernmentID
        {
            get { CheckGet(); return _governmentID; }
            set { CheckSet(); _governmentID = value; }
        }

        private Government _government;
        [Relationship("9FD3E4FF-FA26-43EF-BB4F-8F4D31A8DD4C")]
        public Government Government
        {
            get { CheckGet(); return _government; }
        }
    }
}
