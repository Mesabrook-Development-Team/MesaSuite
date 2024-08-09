using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.company;

namespace WebModels.purchasing
{
    [Table("ADDD00B9-4C42-4A50-A5B2-52A5C372145B")]
    public class FulfillmentPlanRoute : DataObject
    {
        protected FulfillmentPlanRoute() : base() { }

        private long? _fulfillmentPlanRouteID;
        [Field("0AA67479-AF27-40B1-830A-613A265F90B4")]
        public long? FulfillmentPlanRouteID
        {
            get { CheckGet(); return _fulfillmentPlanRouteID; }
            set { CheckSet(); _fulfillmentPlanRouteID = value; }
        }

        private long? _fulfillmentPlanID;
        [Field("7653E68D-4C8C-4AB1-9703-62AA8E09D844")]
        public long? FulfillmentPlanID
        {
            get { CheckGet(); return _fulfillmentPlanID; }
            set { CheckSet(); _fulfillmentPlanID = value; }
        }

        private FulfillmentPlan _fulfillmentPlan = null;
        [Relationship("CC18FE42-EF47-4030-AD4A-EE8582BB5B8A")]
        public FulfillmentPlan FulfillmentPlan
        {
            get { CheckGet(); return _fulfillmentPlan; }
        }

        private byte? _sortOrder;
        [Field("F393D793-60F8-48D9-B2C0-76750728733C")]
        public byte? SortOrder
        {
            get { CheckGet(); return _sortOrder; }
            set { CheckSet(); _sortOrder = value; }
        }

        private long? _companyIDFrom;
        [Field("CB97E108-879C-4989-A318-8B769E5B4B44")]
        public long? CompanyIDFrom
        {
            get { CheckGet(); return _companyIDFrom; }
            set { CheckSet(); _companyIDFrom = value; }
        }

        private Company _companyFrom = null;
        [Relationship("64A5C97C-4200-4945-8DD4-E4DE057DF23D", ForeignKeyField = nameof(CompanyIDFrom))]
        public Company CompanyFrom
        {
            get { CheckGet(); return _companyFrom; }
        }

        private long? _companyIDTo;
        [Field("17135D20-7C1C-4E04-BF59-67FE915F3610")]
        public long? CompanyIDTo
        {
            get { CheckGet(); return _companyIDTo; }
            set { CheckSet(); _companyIDTo = value; }
        }

        private Company _companyTo = null;
        [Relationship("32F41E3C-E26C-4BF9-817A-1BFCA46BF326", ForeignKeyField = nameof(CompanyIDTo))]
        public Company CompanyTo
        {
            get { CheckGet(); return _companyTo; }
        }
    }
}
