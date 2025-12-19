using System;
using System.Collections.Generic;
using System.Linq;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
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

            List<string> fieldPaths = FieldPathUtility.CreateFieldPathsAsList<Account>(a => new object[]
            {
                a.AccountID,
                a.FiscalQuarters.First().Quarter,
                a.FiscalQuarters.First().StartingBalance,
                a.FiscalQuarters.First().EndingBalance,
                a.FiscalQuarters.First().Year,
                a.FiscalQuarters.First().Transactions.First().Amount
            });

            Search<Account> accountSearch = new Search<Account>();

            byte currentQuarter = FiscalQuarter.GetQuarterForDate(DateTime.Now);

            foreach (Account account in accountSearch.GetReadOnlyReader(null, fieldPaths))
            {
                bool hasCurrentQuarter = false;
                decimal lastEndingBalance = 0M;

                short lastYear = (short)DateTime.Now.Year;
                byte lastQuarter = (byte)(currentQuarter - 1);
                if (lastQuarter < 1)
                {
                    lastQuarter = 4;
                    lastYear -= 1;
                }

                foreach (FiscalQuarter fiscalQuarter in account.FiscalQuarters.OrderBy(fq => fq.Year).ThenBy(fq => fq.Quarter))
                {
                    // First check to see if there was a gap between the last FiscalQuarter and the iterated FiscalQuarter
                    byte expectedQuarter = (byte)(lastQuarter + 1);
                    short expectedYear = lastYear;
                    if (expectedQuarter > 4)
                    {
                        expectedQuarter = 1;
                        expectedYear++;
                    }

                    if (fiscalQuarter.Quarter != expectedQuarter || fiscalQuarter.Year != expectedYear)
                    {
                        for (int year = expectedYear; year <= fiscalQuarter.Year; year++)
                        {
                            for (byte quarter = expectedQuarter; quarter <= 4 && (quarter != currentQuarter || year != DateTime.Now.Year); quarter++)
                            {
                                using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
                                {
                                    FiscalQuarter missingFiscalQuarter = FiscalQuarter.FindOrCreate(account.AccountID.Value, new DateTime(year, quarter * 3, 1), transaction);
                                    missingFiscalQuarter.EndingBalance = missingFiscalQuarter.StartingBalance;
                                    if (!missingFiscalQuarter.Save(transaction))
                                    {
                                        throw new Exception("Could not update Fiscal Quarter:\r\n" + fiscalQuarter.Errors.ToString());
                                    }

                                    lastQuarter = missingFiscalQuarter.Quarter.Value;
                                    lastYear = missingFiscalQuarter.Year.Value;
                                    lastEndingBalance = missingFiscalQuarter.EndingBalance.Value;

                                    transaction.Commit();
                                }
                            }

                            expectedQuarter = 1;
                        }
                    }

                    bool isCurrentQuarter = fiscalQuarter.Quarter == currentQuarter && fiscalQuarter.Year == DateTime.Now.Year;
                    hasCurrentQuarter |= isCurrentQuarter;
                    decimal transactionTotalThisQuarter = fiscalQuarter.Transactions?.Sum(t => t.Amount) ?? 0M;

                    if (fiscalQuarter.StartingBalance != lastEndingBalance || (!isCurrentQuarter && fiscalQuarter.EndingBalance != fiscalQuarter.StartingBalance + transactionTotalThisQuarter) || (isCurrentQuarter && fiscalQuarter.EndingBalance != null))
                    {
                        using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
                        {
                            FiscalQuarter editableFiscalQuarter = DataObject.GetEditableByPrimaryKey<FiscalQuarter>(fiscalQuarter.FiscalQuarterID, transaction, null);
                            editableFiscalQuarter.StartingBalance = lastEndingBalance;
                            if (!isCurrentQuarter)
                            {
                                editableFiscalQuarter.EndingBalance = editableFiscalQuarter.StartingBalance + transactionTotalThisQuarter;
                            }
                            else
                            {
                                editableFiscalQuarter.EndingBalance = null;
                            }

                            if (!editableFiscalQuarter.Save(transaction))
                            {
                                throw new Exception("Could not update Fiscal Quarter:\r\n" + fiscalQuarter.Errors.ToString());
                            }
                            lastEndingBalance = editableFiscalQuarter.EndingBalance ?? 0M;
                            transaction.Commit();
                        }
                    }
                    else
                    {
                        lastEndingBalance = fiscalQuarter.EndingBalance ?? 0M;
                    }
                    lastYear = fiscalQuarter.Year.Value;
                    lastQuarter = fiscalQuarter.Quarter.Value;
                }

                if (!hasCurrentQuarter)
                {
                    for (short year = lastYear; year <= DateTime.Now.Year; year++)
                    {
                        for (byte quarter = lastQuarter; quarter <= 4; quarter++)
                        {
                            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
                            {
                                FiscalQuarter missingQuarter = FiscalQuarter.FindOrCreate(account.AccountID.Value, new DateTime(year, quarter * 3, 1), transaction);
                                if (missingQuarter.Quarter != currentQuarter || missingQuarter.Year != DateTime.Now.Year)
                                {
                                    missingQuarter.EndingBalance = missingQuarter.StartingBalance;
                                    if (!missingQuarter.Save(transaction))
                                    {
                                        throw new Exception("Could not update Fiscal Quarter:\r\n" + missingQuarter.Errors.ToString());
                                    }
                                }
                                transaction.Commit();
                            }

                            if (year == DateTime.Now.Year && quarter == currentQuarter)
                            {
                                break;
                            }
                        }

                        lastQuarter = 1;
                    }
                }
            }

            return true;
        }
    }
}
