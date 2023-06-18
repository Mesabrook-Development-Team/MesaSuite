using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModels.account;
using WebModels.gov;

namespace MesaService.ServiceTasks
{
    public class IssueAccountInterest : IServiceTask
    {
        public string Name => "Issue Account Interest to all Accounts";

        private DateTime _nextRunTime = DateTime.Now;
        public DateTime NextRunTime => _nextRunTime;

        public bool Run()
        {
            _nextRunTime = _nextRunTime.AddHours(1);

            InterestConfiguration configuration = new Search<InterestConfiguration>().GetEditable();
            if (configuration == null || configuration.NextInterestRun == null || configuration.NextInterestRun > DateTime.Now)
            {
                return true;
            }

            if (configuration.NextInterestRun.Value.Day >= 15) // Set to first day of next month
            {
                configuration.NextInterestRun = configuration.NextInterestRun.Value.AddMonths(1).AddDays(-(configuration.NextInterestRun.Value.Day - 1)).Date;
            }
            else // Set to the 15th of this month
            {
                configuration.NextInterestRun = configuration.NextInterestRun.Value.AddDays(15 - configuration.NextInterestRun.Value.Day).Date;
            }
            if (!configuration.Save())
            {
                Console.WriteLine("Could not update next interest run. Aborting.");
                Console.WriteLine(string.Join(", ", configuration.Errors.Select(e => e.Message).ToArray()));
                return false;
            }

            List<string> readOnlyFields = FieldPathUtility.CreateFieldPathsAsList<Account>(a => new List<object>()
            {
                a.Government.Accounts.First().Balance,
                a.Company.Accounts.First().Balance,
                a.Company.Locations.First().LocationID
            });

            Dictionary<long?, decimal> companyIDBalances = new Dictionary<long?, decimal>();
            Dictionary<long?, decimal> governmentIDBalances = new Dictionary<long?, decimal>();

            Search<Account> accountSearch = new Search<Account>();
            foreach(Account account in accountSearch.GetEditableReader(null, readOnlyFields))
            {
                decimal currentTotalBalance = 0;
                decimal maxBalance = 0;
                decimal interestPercent = 0;
                if (account.CompanyID != null)
                {
                    maxBalance = configuration.WealthCapLocation ?? 0;
                    interestPercent = (configuration.RateLocation ?? 0) / 100;

                    if (!companyIDBalances.ContainsKey(account.CompanyID))
                    {
                        companyIDBalances.Add(account.CompanyID, 0);
                        foreach (Account companyAccount in account.Company.Accounts)
                        {
                            companyIDBalances[account.CompanyID] += companyAccount.Balance ?? 0;
                        }
                    }

                    currentTotalBalance = companyIDBalances[account.CompanyID] / account.Company.Locations.Count;
                }
                else if (account.GovernmentID != null)
                {
                    maxBalance = configuration.WealthCapGovernment ?? 0;
                    interestPercent = (configuration.RateGovernment ?? 0) / 100;

                    if (!governmentIDBalances.ContainsKey(account.GovernmentID))
                    {
                        governmentIDBalances.Add(account.GovernmentID, 0);
                        foreach (Account governmentAccount in account.Government.Accounts)
                        {
                            governmentIDBalances[account.GovernmentID] += governmentAccount.Balance ?? 0;
                        }
                    }

                    currentTotalBalance = governmentIDBalances[account.GovernmentID];
                }

                if (currentTotalBalance >= maxBalance)
                {
                    continue;
                }

                decimal amountToAdd = (account.Balance ?? 0) * interestPercent;
                if (currentTotalBalance + amountToAdd > maxBalance)
                {
                    amountToAdd = maxBalance - amountToAdd;
                }

                using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
                {
                    if (!account.Deposit(amountToAdd, Transaction.DescriptionFormats.INTEREST_PAYMENT, transaction))
                    {
                        Console.WriteLine("WARNING - Failed to deposit " + amountToAdd + " into account " + account.AccountNumber);
                        Console.WriteLine(string.Join(", ", account.Errors.Select(e => e.Message).ToArray()));
                    }
                    transaction.Commit();
                }

                if (account.CompanyID != null)
                {
                    companyIDBalances[account.CompanyID] += amountToAdd;
                }
                else if (account.GovernmentID != null)
                {
                    governmentIDBalances[account.GovernmentID] += amountToAdd;
                }
            }

            return true;
        }
    }
}
