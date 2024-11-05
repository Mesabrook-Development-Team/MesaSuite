using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using WebModels.company;
using WebModels.gov;

namespace WebModels.purchasing
{
    [Table("47BC90AA-598A-4E48-931D-7796C72E91B5")]
    public class PurchaseOrderTemplate : DataObject
    {
        protected PurchaseOrderTemplate() : base() { }

        private long? _purchaseOrderTemplateID;
        [Field("A6FD264B-AFD0-482C-9532-34318B733AAF")]
        public long? PurchaseOrderTemplateID
        {
            get { CheckGet(); return _purchaseOrderTemplateID; }
            set { CheckSet(); _purchaseOrderTemplateID = value; }
        }

        private long? _companyID;
        [Field("5D0D96B1-972E-4D46-861E-1378A2A782C6")]
        public long? CompanyID
        {
            get { CheckGet(); return _companyID; }
            set { CheckSet(); _companyID = value; }
        }

        private Company _company = null;
        [Relationship("751395DE-8D3E-46DD-9674-15A23AD65F80")]
        public Company Company
        {
            get { CheckGet(); return _company; }
            set { CheckSet(); _company = value; }
        }

        private long? _governmentID;
        [Field("4760E621-E3E7-4BC8-BF5B-20B7D077F286")]
        public long? GovernmentID
        {
            get { CheckGet(); return _governmentID; }
            set { CheckSet(); _governmentID = value; }
        }

        private Government _government = null;
        [Relationship("FF053568-7604-4931-85B4-C6D937F08A13")]
        public Government Government
        {
            get { CheckGet(); return _government; }
            set { CheckSet(); _government = value; }
        }

        private long? _purchaseOrderTemplateFolderID;
        [Field("D1228BCD-0A08-4BE7-B4CC-A67E0744A0DA")]
        public long? PurchaseOrderTemplateFolderID
        {
            get { CheckGet(); return _purchaseOrderTemplateFolderID; }
            set { CheckSet(); _purchaseOrderTemplateFolderID = value; }
        }

        private PurchaseOrderTemplateFolder _purchaseOrderTemplateFolder = null;
        [Relationship("3FC5226A-41F6-46E4-B0DB-373FAB38C3EA")]
        public PurchaseOrderTemplateFolder PurchaseOrderTemplateFolder
        {
            get { CheckGet(); return _purchaseOrderTemplateFolder; }
            set { CheckSet(); _purchaseOrderTemplateFolder = value; }
        }

        private long? _purchaseOrderID;
        [Field("D5F2368B-A49D-483B-82A7-ADCFA7FEB212")]
        [Required]
        public long? PurchaseOrderID
        {
            get { CheckGet(); return _purchaseOrderID; }
            set { CheckSet(); _purchaseOrderID = value; }
        }

        private PurchaseOrder _purchaseOrder = null;
        [Relationship("FD206D30-80BA-423D-9A60-FAC57E4D8176")]
        public PurchaseOrder PurchaseOrder
        {
            get { CheckGet(); return _purchaseOrder; }
            set { CheckSet(); _purchaseOrder = value; }
        }

        private string _name;
        [Field("22417948-32F8-4D2E-AD7A-8D537C65BFE8", DataSize = 255)]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }
    }
}
