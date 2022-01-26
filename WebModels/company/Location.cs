using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.invoicing;

namespace WebModels.company
{
    [Table("A3A28E39-0FA0-423C-B6D4-43F2802ED19D")]
    public class Location : DataObject
    {
        protected Location() : base() { }

        private long? _locationID;
        [Field("BC041BDE-50B5-4D80-8081-9A06C79BFA65")]
        public long? LocationID
        {
            get { CheckGet(); return _locationID; }
            set { CheckSet(); _locationID = value; }
        }

        private long? _companyID;
        [Field("0254C75D-C356-45C0-AB7A-A68C75D8B42F")]
        public long? CompanyID
        {
            get { CheckGet(); return _companyID; }
            set { CheckSet(); _companyID = value; }
        }

        private Company _company = null;
        [Relationship("45F492F3-A94B-46DD-9D2C-7DEE83652741")]
        public Company Company
        {
            get { CheckGet(); return _company; }
        }

        private string _name;
        [Field("1FB1B286-C72B-462A-ABD4-E149EF13BCC4", DataSize = 50)]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value;}
        }

        private string _invoiceNumberPrefix;
        [Field("FC1EE2D9-48EA-4F74-88FE-A0559D2D60E0", DataSize = 3)]
        public string InvoiceNumberPrefix
        {
            get { CheckGet(); return _invoiceNumberPrefix; }
            set { CheckSet(); _invoiceNumberPrefix = value; }
        }

        private string _nextInvoiceNumber;
        [Field("C3BB92AA-9EEC-4B80-8116-9CDD43B558EC", DataSize = 8)]
        public string NextInvoiceNumber
        {
            get { CheckGet(); return _nextInvoiceNumber; }
            set { CheckSet(); _nextInvoiceNumber = value; }
        }

        #region Relationships
        #region company
        private List<LocationEmployee> _locationEmployees = new List<LocationEmployee>();
        [RelationshipList("04569132-78B1-42E6-BD47-5729B5B392ED", "LocationID")]
        public IReadOnlyCollection<LocationEmployee> LocationEmployees
        {
            get { CheckGet(); return _locationEmployees; }
        }

        private List<LocationGovernment> _locationGovernments = new List<LocationGovernment>();
        [RelationshipList("5C8358F5-676C-468E-A745-EBAF6754C67E", "LocationID")]
        public IReadOnlyCollection<LocationGovernment> LocationGovernments
        {
            get { CheckGet(); return _locationGovernments; }
        }
        #endregion
        #region invoicing
        private List<Invoice> _invoicesFrom = new List<Invoice>();
        [RelationshipList("6DD822E0-7449-4F56-AF7C-559C44E94EA0", "LocationIDFrom")]
        public IReadOnlyCollection<Invoice> InvoicesFrom
        {
            get { CheckGet(); return _invoicesFrom; }
        }

        private List<Invoice> _invoicesTo = new List<Invoice>();
        [RelationshipList("1C3F6214-C3E8-4882-9F10-10CF7BC7A8DE", "InvoiceIDTo")]
        public IReadOnlyCollection<Invoice> InvoicesTo
        {
            get { CheckGet(); return _invoicesTo; }
        }
        #endregion
        #endregion
    }
}
