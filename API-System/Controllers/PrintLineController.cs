using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.Utility;
using System.Collections.Generic;
using WebModels.netprint;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    public class PrintLineController : DataObjectController<PrintLine>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<PrintLine>(pl => new List<object>()
        {
            pl.PrintLineID,
            pl.PrintPageID,
            pl.DisplayOrder,
            pl.Alignment,
            pl.Text
        });


    }
}