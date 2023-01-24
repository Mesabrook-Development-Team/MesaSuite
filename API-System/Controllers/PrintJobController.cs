using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebModels.netprint;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    public class PrintJobController : DataObjectController<PrintJob>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<PrintJob>(pj => new List<object>()
        {
            pj.PrintJobID,
            pj.PrinterID,
            pj.DocumentName,
            pj.Finalized,
            pj.PrintPages.First().PrintJobID,
            pj.PrintPages.First().PrintPageID,
            pj.PrintPages.First().DisplayOrder,
            pj.PrintPages.First().PrintLines.First().PrintLineID,
            pj.PrintPages.First().PrintLines.First().PrintPageID,
            pj.PrintPages.First().PrintLines.First().Alignment,
            pj.PrintPages.First().PrintLines.First().DisplayOrder,
            pj.PrintPages.First().PrintLines.First().Text
        });

        [HttpGet]
        public async Task<List<PrintJob>> GetForPrinter([FromUri] Guid? printerID)
        {
            Search<PrintJob> printJobSearch = new Search<PrintJob>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new GuidSearchCondition<PrintJob>()
                {
                    Field = nameof(PrintJob.Printer) + "." + nameof(Printer.Address),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = printerID
                },
                new BooleanSearchCondition<PrintJob>()
                {
                    Field = nameof(PrintJob.Finalized),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = true
                }));

            printJobSearch.SearchOrders.Add(new SearchOrder() { OrderField = $"{nameof(PrintJob.PrintPages)}.{nameof(PrintPage.DisplayOrder)}" });
            printJobSearch.SearchOrders.Add(new SearchOrder() { OrderField = $"{nameof(PrintJob.PrintPages)}.{nameof(PrintPage.PrintLines)}.{nameof(PrintLine.DisplayOrder)}" });
            return printJobSearch.GetReadOnlyReader(null, await FieldsToRetrieve()).ToList();
        }
    }
}