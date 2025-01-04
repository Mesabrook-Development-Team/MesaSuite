using ClussPro.ObjectBasedFramework.DataSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.invoicing;

namespace MesaService.ServiceTasks
{
    internal class PayAPInvoicesTask : IServiceTask
    {
        public string Name => "Pay AP Invoices";

        private DateTime? _nextRunTime = DateTime.Now;
        public DateTime NextRunTime => throw new NotImplementedException();

        public bool Run()
        {
            if (DateTime.Now > _nextRunTime)
            {
                _nextRunTime = DateTime.Today.AddDays(1).AddHours(-1);
            }

            Search<AutomaticInvoicePaymentConfiguration> configurationSearch = new Search<AutomaticInvoicePaymentConfiguration>(new DecimalSearchCondition<AutomaticInvoicePaymentConfiguration>()
            {
                Field = nameof(AutomaticInvoicePaymentConfiguration.RemainingAmount),
                SearchConditionType = SearchCondition.SearchConditionTypes.Greater,
                Value = 0
            });
        }
    }
}
