using System;
using System.Linq;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.account;

namespace MesaService.ServiceTasks
{
    public class AuditFiscalQuarters : IServiceTask
    {
        public string Name => "Audit Fiscal Quarters";

        private DateTime _nextRunTime = DateTime.Now.AddSeconds(-1);
        public DateTime NextRunTime => _nextRunTime;

        public bool Run()
        {
            _nextRunTime = DateTime.Today.AddDays(1);

            byte quarter = FiscalQuarter.GetQuarterForDate(DateTime.Today);

            Search<Account> accountSearch = new Search<Account>(new ExistsSearchCondition<Account>()
            {
                RelationshipName = "FiscalQuarters",
                ExistsType = ExistsSearchCondition<Account>.ExistsTypes.NotExists,
                Condition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new ByteSearchCondition<FiscalQuarter>()
                    {
                        Field = "Quarter",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = quarter
                    },
                    new ShortSearchCondition<FiscalQuarter>()
                    {
                        Field = "Year",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = (short)DateTime.Today.Year
                    })
            });

            foreach (Account account in accountSearch.GetReadOnlyReader(null, new string[] { "AccountID" }))
            {
                using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
                {
                    FiscalQuarter closingFiscalQuarter = FiscalQuarter.FindOrCreate(account.AccountID.Value, DateTime.Today.AddMonths(-3), transaction, new string[] { "Transactions.Amount" });
                    closingFiscalQuarter.EndingBalance = (closingFiscalQuarter.StartingBalance + closingFiscalQuarter.Transactions?.Sum(t => t.Amount)) ?? 0M;
                    if (!closingFiscalQuarter.Save(transaction))
                    {
                        throw new Exception("Could not update closing Fiscal Quarter:\r\n" + closingFiscalQuarter.Errors.ToString());
                    }

                    FiscalQuarter.FindOrCreate(account.AccountID.Value, DateTime.Today, transaction);

                    transaction.Commit();
                }
            }

            return true;
        }
    }
}
