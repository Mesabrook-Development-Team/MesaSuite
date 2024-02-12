using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.Utility;
using System.Collections.Generic;
using System.Linq;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [LocationAccess(RequiredPermissions = new[] { nameof(LocationEmployee.ManagePrices) })]
    public class PromotionLocationItemController : DataObjectController<PromotionLocationItem>
    {
        protected long? LocationID => long.Parse(Request.Headers.GetValues("LocationID").First());

        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<PromotionLocationItem>(pli => new List<object>()
        {
            pli.PromotionLocationItemID,
            pli.PromotionID,
            pli.LocationItemID,
            pli.PromotionPrice
        });
    }
}
