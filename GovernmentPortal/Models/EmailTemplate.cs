using System.Collections.Generic;

namespace GovernmentPortal.Models
{
    public class EmailTemplate
    {
        public long? EmailTemplateID { get; set; }
        public string Name { get; set; }
        public string TemplateSchema { get; set; }
        public string TemplateObject { get; set; }
        public string Template { get; set; }
        public string AllowedFields { get; set; }

        public List<EmailImplementation> EmailImplementations { get; set; }
    }
}
