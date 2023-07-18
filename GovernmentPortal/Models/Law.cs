using System.Collections.Generic;

namespace GovernmentPortal.Models
{
    public class Law
    {
        public long? LawID { get; set; }
        public long? GovernmentID { get; set; }
        public string Name { get; set; }
        public byte? DisplayOrder { get; set; }
        public List<LawSection> LawSections { get; set; }
    }
}
