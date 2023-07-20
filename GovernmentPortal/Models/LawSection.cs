namespace GovernmentPortal.Models
{
    public class LawSection
    {
        public long? LawSectionID { get; set; }
        public long? LawID { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public byte? DisplayOrder { get; set; }
    }
}
