namespace FleetTracking.Models
{
    public class EmailImplementation
    {
        public long? EmailImplementationID { get; set; }
        public long? EmailTemplateID { get; set; }
        public EmailTemplate EmailTemplate { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
