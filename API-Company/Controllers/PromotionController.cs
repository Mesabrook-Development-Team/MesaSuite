using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System.Collections.Generic;
using System.Linq;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [LocationAccess(RequiredPermissions = new[] { nameof(LocationEmployee.ManagePrices) })]
    public class PromotionController : DataObjectController<Promotion>
    {
        protected long? LocationID => long.Parse(Request.Headers.GetValues("LocationID").First());

        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<Promotion>(p => new List<object>()
        {
            p.PromotionID,
            p.LocationID,
            p.StartTime,
            p.EndTime,
            p.Name,
            p.PromotionLocationItems.First().PromotionLocationItemID,
            p.PromotionLocationItems.First().PromotionID,
            p.PromotionLocationItems.First().LocationItemID,
            p.PromotionLocationItems.First().PromotionPrice
        });

        public override ISearchCondition GetBaseSearchCondition()
        {
            return new LongSearchCondition<Promotion>()
            {
                Field = nameof(Promotion.LocationID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = LocationID
            };
        }

        public override bool AllowGetAll => true;
    }
}
