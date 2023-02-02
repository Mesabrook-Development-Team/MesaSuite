using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Web.Http;
using WebModels.netprint;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    public class PrinterController : DataObjectController<Printer>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<Printer>(p => new List<object>()
        {
            p.PrinterID,
            p.Address,
            p.Name
        });

        public override bool AllowGetAll => true;

        [HttpGet]
        public bool CheckPrinterExists([FromUri]Guid? printerID)
        {
            return new Search<Printer>(new GuidSearchCondition<Printer>()
            {
                Field = nameof(Printer.Address),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = printerID
            }).ExecuteExists(null);
        }
    }
}