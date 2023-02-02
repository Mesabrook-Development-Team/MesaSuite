using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.Utility;
using System.Collections.Generic;
using WebModels.mesasys;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("system")]
    public class ItemNamespaceController : DataObjectController<ItemNamespace>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<ItemNamespace>(ins => new List<object>()
        {
            ins.ItemNamespaceID,
            ins.Namespace,
            ins.FriendlyName
        });

        public override bool AllowGetAll => true;
    }
}