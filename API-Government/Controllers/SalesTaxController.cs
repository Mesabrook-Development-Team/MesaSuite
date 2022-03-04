using System.Collections.Generic;
using System.Linq;
using API.Common;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.gov;

namespace API_Government.Controllers
{
    public class SalesTaxController : DataObjectController<SalesTax>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new[]
        {
            nameof(SalesTax.SalesTaxID),
            nameof(SalesTax.GovernmentID),
            nameof(SalesTax.EffectiveDate),
            nameof(SalesTax.Rate)
        };

        public override bool AllowGetAll => true;

        public override SearchCondition GetBaseSearchCondition()
        {
            long governmentID = long.Parse(Request.Headers.GetValues("GovernmentID").First());

            return new LongSearchCondition<SalesTax>()
            {
                Field = "GovernmentID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = governmentID
            };
        }
    }
}