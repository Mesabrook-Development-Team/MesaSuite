using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.Utility;
using System.Collections.Generic;
using WebModels.company;
using WebModels.purchasing;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [LocationAccess(RequiredPermissions = new[] { nameof(LocationEmployee.ManagePurchaseOrders) })]
    public class PurchaseOrderTemplateController : DataObjectController<PurchaseOrderTemplate>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<PurchaseOrderTemplate>(pot => new List<object>()
        {
            pot.PurchaseOrderTemplateID,
            pot.PurchaseOrderTemplateFolderID,
            pot.LocationID,
            pot.GovernmentID,
            pot.PurchaseOrderID,
            pot.Name
        });

        public override bool AllowGetAll => true;
    }
}
