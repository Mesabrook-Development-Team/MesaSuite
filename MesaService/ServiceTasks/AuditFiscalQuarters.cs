using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
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

            List<string> fields = FieldPathUtility.CreateFieldPathsAsList<Account>(a => new object[]
            {
                a.AccountID,
                a.FiscalQuarters.First().FiscalQuarterID,
                a.FiscalQuarters.First().Quarter,
                a.FiscalQuarters.First().Year,
                a.FiscalQuarters.First().StartingBalance,
                a.FiscalQuarters.First().EndingBalance,
                a.FiscalQuarters.First().Transactions.First().Amount
            });

            Search<Account> accountSearch = new Search<Account>();
            byte currentQuarter = FiscalQuarter.GetQuarterForDate(DateTime.Today);

            foreach(Account account in accountSearch.GetReadOnlyReader(null, fields))
            {
                IOrderedEnumerable<FiscalQuarter> fiscalQuarters = account.FiscalQuarters.OrderBy(fq => fq.Year).ThenBy(fq => fq.Quarter);
                if (!fiscalQuarters.Any()) // Create missing, current fiscal quarter
                {
                    CreateFiscalQuarter(account.AccountID, (short)DateTime.Now.Year, currentQuarter, fields);
                    continue; // Skip further processing as only one fiscal quarter is required for an account that was missing any
                }

                decimal lastEndingBalance = 0M;
                byte quarterIterator = fiscalQuarters.First().Quarter.Value;

                for(short yearIterator = fiscalQuarters.First().Year.Value; yearIterator <= DateTime.Today.Year; yearIterator++)
                {
                    for(; quarterIterator <= 4; quarterIterator++)
                    {
                        FiscalQuarter fiscalQuarter = fiscalQuarters.FirstOrDefault(fq => fq.Quarter == quarterIterator && fq.Year == yearIterator);
                        if (fiscalQuarter == null)
                        {
                            fiscalQuarter = CreateFiscalQuarter(account.AccountID, yearIterator, quarterIterator, fields);
                        }

                        bool isCurrentQuarter = quarterIterator == currentQuarter && yearIterator == DateTime.Today.Year;
                        decimal? endingBalance = isCurrentQuarter ? (decimal?)null : lastEndingBalance + fiscalQuarter.Transactions.Sum(t => t.Amount ?? 0M);
                        if (fiscalQuarter.StartingBalance != lastEndingBalance || fiscalQuarter.EndingBalance != endingBalance)
                        {
                            UpdateFiscalQuarter(fiscalQuarter.FiscalQuarterID, lastEndingBalance, endingBalance);
                        }

                        lastEndingBalance = endingBalance ?? 0M;

                        if (isCurrentQuarter)
                        {
                            break;
                        }
                    }

                    quarterIterator = 1;
                }
            }

            return true;
        }

        private void UpdateFiscalQuarter(long? fiscalQuarterID, decimal lastEndingBalance, decimal? endingBalance)
        {
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                FiscalQuarter fiscalQuarter = DataObject.GetEditableByPrimaryKey<FiscalQuarter>(fiscalQuarterID, transaction, null);
                fiscalQuarter.StartingBalance = lastEndingBalance;
                fiscalQuarter.EndingBalance = endingBalance;
                if (!fiscalQuarter.Save(transaction))
                {
                    throw new Exception($"Unable to update balances on Fiscal Quarter {fiscalQuarterID}: {fiscalQuarter.Errors}");
                }

                transaction.Commit();
            }
        }

        private FiscalQuarter CreateFiscalQuarter(long? accountID, short yearIterator, byte quarterIterator, List<string> accountFields)
        {
            FiscalQuarter fiscalQuarter;
            List<string> fields = accountFields
                                    .Where(f => f.StartsWith("FiscalQuarters."))
                                    .Select(f => f.Substring("FiscalQuarters.".Length))
                                    .ToList();
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                fiscalQuarter = FiscalQuarter.FindOrCreate(accountID.Value, new DateTime(yearIterator, quarterIterator * 3, 1), transaction, fields);

                transaction.Commit();
            }

            return fiscalQuarter;
        }
    }
}
