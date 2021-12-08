using System;
using System.Linq;
using System.Text;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.account;

namespace MesaService.ServiceTasks
{
    public class AuditAccountBalances : IServiceTask
    {
        public string Name => "Audit Account Balances";

        private DateTime _nextRunTime = DateTime.Now.AddSeconds(-1);
        public DateTime NextRunTime => _nextRunTime;

        public bool Run()
        {
            _nextRunTime = DateTime.Now.AddHours(1);

            StringBuilder errorBuilder = new StringBuilder();
            Search<Account> accountSearch = new Search<Account>();
            foreach(Account account in accountSearch.GetEditableReader())
            {
                FiscalQuarter currentQuarter = FiscalQuarter.Find(account.AccountID.Value, DateTime.Now, additionalFields: new string[] { "Transactions.Amount" });
                if (currentQuarter == null)
                {
                    // The Fiscal Quarter hasn't been created yet - AuditFiscalQuarters will create it later
                    continue;
                }

                decimal? newSum = currentQuarter.StartingBalance + (currentQuarter.Transactions.Sum(t => t.Amount) ?? 0m);
                if (newSum != null)
                {
                    if (account.Balance != newSum)
                    {
                        account.Balance = newSum;
                        if (!account.Save())
                        {
                            errorBuilder.AppendLine($"Account {account.AccountID} failed to save while auditing balance:");
                            errorBuilder.AppendLine(account.Errors.ToString());
                            errorBuilder.AppendLine();
                        }
                    }
                }
                else
                {
                    errorBuilder.AppendLine($"Could not audit balance on Account {account.AccountID}: Audited balance is null");
                    errorBuilder.AppendLine();
                }
            }

            if (errorBuilder.Length != 0)
            {
                throw new Exception(errorBuilder.ToString());
            }

            return true;
        }
    }
}
