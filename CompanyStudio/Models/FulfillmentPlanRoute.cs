﻿namespace CompanyStudio.Models
{
    public class FulfillmentPlanRoute
    {
        public long? FulfillmentPlanRouteID { get; set; }
        public long? FulfillmentPlanID { get; set; }
        public FulfillmentPlan FulfillmentPlan { get; set; }
        public byte? SortOrder { get; set; }
        public long? CompanyIDFrom { get; set; }
        public Company CompanyFrom { get; set; }
        public long? CompanyIDTo { get; set; }
        public Company CompanyTo { get; set; }
        public long? GovernmentIDFrom { get; set; }
        public Government GovernmentFrom { get; set; }
        public long? GovernmentIDTo { get; set; }
        public Government GovernmentTo { get; set; }

        public string From => GovernmentIDFrom != null ? GovernmentFrom?.Name + " (Government)" : CompanyFrom?.Name;
        public string To => GovernmentIDTo != null ? GovernmentTo?.Name + " (Government)" : CompanyTo?.Name;
    }
}
