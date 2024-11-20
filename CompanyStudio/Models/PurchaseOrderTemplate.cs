using System;

namespace CompanyStudio.Models
{
    [Serializable]
    public class PurchaseOrderTemplate
    {
        public long? PurchaseOrderTemplateID { get; set; }
        public long? LocationID { get; set; }
        public long? CompanyID { get; set; }
        public long? PurchaseOrderTemplateFolderID { get; set; }
        public long? PurchaseOrderID { get; set; }
        public string Name { get; set; }
    }
}
