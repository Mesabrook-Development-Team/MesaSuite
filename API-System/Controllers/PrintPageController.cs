using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.Utility;
using System.Collections.Generic;
using WebModels.netprint;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    public class PrintPageController : DataObjectController<PrintPage>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<PrintPage>(pp => new List<object>()
        {
            pp.PrintJobID,
            pp.PrintPageID,
            pp.DisplayOrder
        });
    }
}