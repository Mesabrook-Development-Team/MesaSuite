using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using ClussPro.ObjectBasedFramework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.company;
using WebModels.fleet;
using WebModels.gov;
using WebModels.invoicing;

namespace MesaService.ServiceTasks
{
    public class IssueRailcarTransactionInvoices : IServiceTask
    {
        public string Name => "Issue Railcar Transaction Invoices";

        private DateTime _nextRunTime = DateTime.Now;
        public DateTime NextRunTime => _nextRunTime;

        public bool Run()
        {
            _nextRunTime = DateTime.Today.AddDays(1);

            Search<RailcarLocationTransaction> uninvoicedTransactions = new Search<RailcarLocationTransaction>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new BooleanSearchCondition<RailcarLocationTransaction>()
                {
                    Field = nameof(RailcarLocationTransaction.WillNotCharge),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = false
                },
                new LongSearchCondition<RailcarLocationTransaction>()
                {
                    Field = nameof(RailcarLocationTransaction.InvoiceID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Null
                }));

            // What's the best way to determine and bill for a change of district? Who gets the payment?
            List<string> fields = FieldPathUtility.CreateFieldPathsAsList<RailcarLocationTransaction>(rlt => new List<object>()
            {
                // Railcar fields
                rlt.Railcar.ReportingMark,
                rlt.Railcar.ReportingNumber,
                rlt.Railcar.CompanyIDOwner,
                rlt.Railcar.GovernmentIDOwner,
                rlt.Railcar.LeaseContracts.First().LeaseTimeStart,
                rlt.Railcar.LeaseContracts.First().LeaseTimeEnd,
                rlt.Railcar.LeaseContracts.First().CompanyIDLessee,
                rlt.Railcar.LeaseContracts.First().GovernmentIDLessee,

                // Track fields
                rlt.TrackIDNew,
                rlt.TrackNew.Name,
                rlt.TrackNew.RailDistrictID,
                rlt.TrackNew.RailDistrict.CompanyIDOperator,
                rlt.TrackNew.RailDistrict.GovernmentIDOperator,
                rlt.NextTransaction.TrackIDNew,
                rlt.NextTransaction.TrackNew.RailDistrictID,
                rlt.NextTransaction.TrainIDNew,

                // Train fields
                rlt.TrainIDNew,
                rlt.IsPartialTrainTrip,
                rlt.TrainNew.TrainSymbol.Name,
                rlt.TrainNew.TrainSymbol.CompanyIDOperator,
                rlt.TrainNew.TrainSymbol.GovernmentIDOperator,
                rlt.TrainNew.TrainSymbol.TrainSymbolRates.First().EffectiveTime,
                rlt.TrainNew.TrainSymbol.TrainSymbolRates.First().RatePerCar,
                rlt.TrainNew.TrainSymbol.TrainSymbolRates.First().RatePerPartialTrip
            });

            List<string> carHandlingRateFields = FieldPathUtility.CreateFieldPathsAsList<CarHandlingRate>(chr => new List<object>()
            {
                chr.EffectiveTime,
                chr.IntraDistrictRate,
                chr.InterDistrictRate,
                chr.PlacementRate
            });

            Dictionary<long?, List<CarHandlingRate>> _trackRatesByCompanyID = new Dictionary<long?, List<CarHandlingRate>>();
            Dictionary<long?, List<CarHandlingRate>> _trackRatesByGovernmentID = new Dictionary<long?, List<CarHandlingRate>>();

            Dictionary<long?, long?> locationIDPayeesByCompanyID = new Dictionary<long?, long?>();
            Dictionary<long?, long?> locationIDPayorsByCompanyID = new Dictionary<long?, long?>();

            Dictionary<Invoice, List<InvoiceLine>> invoiceLinesByInvoice = new Dictionary<Invoice, List<InvoiceLine>>();
            Dictionary<Invoice, List<RailcarLocationTransaction>> transactionsByInvoice = new Dictionary<Invoice, List<RailcarLocationTransaction>>();

            StringBuilder errorBuilder = new StringBuilder();
            foreach (RailcarLocationTransaction uninvoicedTransaction in uninvoicedTransactions.GetEditableReader(null, fields))
            {
                decimal? feeTotal = 0M;
                string feeDescription = $"Reporting Mark: {uninvoicedTransaction.Railcar.ReportingMark}{uninvoicedTransaction.Railcar.ReportingNumber} ";

                long? companyIDPayee = null;
                long? governmentIDPayee = null;

                if (uninvoicedTransaction.TrackIDNew != null)
                {
                    if (uninvoicedTransaction.TrackNew?.RailDistrict?.CompanyIDOperator == null && uninvoicedTransaction.TrackNew?.RailDistrict?.GovernmentIDOperator == null)
                    {
                        continue; // We don't know who to pay
                    }

                    if (uninvoicedTransaction.NextTransaction?.TrackIDNew == null && uninvoicedTransaction.NextTransaction?.TrainIDNew == null)
                    {
                        continue; // We can't do anything here until the next move so we know to charge properly for inter/intradistrict or only a placement
                    }

                    // Garner proper fee
                    CarHandlingRate handlingRate = null;
                    if (uninvoicedTransaction.TrackNew.RailDistrict.CompanyIDOperator != null)
                    {
                        companyIDPayee = uninvoicedTransaction.TrackNew.RailDistrict.CompanyIDOperator;
                        if (!_trackRatesByCompanyID.ContainsKey(uninvoicedTransaction.TrackNew.RailDistrict.CompanyIDOperator))
                        {
                            Search<CarHandlingRate> rateSearch = new Search<CarHandlingRate>(new LongSearchCondition<CarHandlingRate>()
                            {
                                Field = nameof(CarHandlingRate.CompanyID),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = uninvoicedTransaction.TrackNew.RailDistrict.CompanyIDOperator
                            });
                            _trackRatesByCompanyID[uninvoicedTransaction.TrackNew.RailDistrict.CompanyIDOperator] = rateSearch.GetReadOnlyReader(null, carHandlingRateFields).OrderByDescending(chr => chr.EffectiveTime).ToList();
                        }

                        handlingRate = _trackRatesByCompanyID[uninvoicedTransaction.TrackNew.RailDistrict.CompanyIDOperator].FirstOrDefault(chr => chr.EffectiveTime <= uninvoicedTransaction.TransactionTime);
                    }
                    else if (uninvoicedTransaction.TrackNew.RailDistrict.GovernmentIDOperator != null)
                    {
                        governmentIDPayee = uninvoicedTransaction.TrackNew.RailDistrict.GovernmentIDOperator;
                        if (!_trackRatesByGovernmentID.ContainsKey(uninvoicedTransaction.TrackNew.RailDistrict.GovernmentIDOperator))
                        {
                            Search<CarHandlingRate> rateSearch = new Search<CarHandlingRate>(new LongSearchCondition<CarHandlingRate>()
                            {
                                Field = nameof(CarHandlingRate.GovernmentID),
                                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                                Value = uninvoicedTransaction.TrackNew.RailDistrict.GovernmentIDOperator
                            });
                            _trackRatesByGovernmentID[uninvoicedTransaction.TrackNew.RailDistrict.GovernmentIDOperator] = rateSearch.GetReadOnlyReader(null, carHandlingRateFields).OrderByDescending(chr => chr.EffectiveTime).ToList();
                        }

                        handlingRate = _trackRatesByGovernmentID[uninvoicedTransaction.TrackNew.RailDistrict.GovernmentIDOperator].FirstOrDefault(chr => chr.EffectiveTime <= uninvoicedTransaction.TransactionTime);
                    }

                    if (handlingRate == null)
                    {
                        continue; // No fees apply for this timeframe
                    }

                    feeTotal = handlingRate.PlacementRate; // We for sure will want to charge the placement rate
                    feeDescription += $"Track Placement Fee ({uninvoicedTransaction.TrackNew.Name})";

                    if (uninvoicedTransaction.NextTransaction.TrainIDNew == null) // If the next transaction is NOT a train, that means we need to charge a movement fee
                    {
                        if (uninvoicedTransaction.NextTransaction.TrackNew.RailDistrictID == uninvoicedTransaction.TrackNew.RailDistrictID) // Intradistrict movement
                        {
                            feeTotal += handlingRate.IntraDistrictRate;
                            feeDescription += " + Intradistrict Fee";
                        }
                        else // We changed districts
                        {
                            feeTotal += handlingRate.InterDistrictRate;
                            feeDescription += " + Interdistrict Fee";
                        }
                    }
                }
                else if (uninvoicedTransaction.TrainIDNew != null)
                {
                    // Get proper train fee
                    TrainSymbolRate symbolRate = uninvoicedTransaction.TrainNew.TrainSymbol.TrainSymbolRates?.OrderByDescending(tsr => tsr.EffectiveTime).FirstOrDefault(tsr => tsr.EffectiveTime <= uninvoicedTransaction.TransactionTime);
                    if (symbolRate == null)
                    {
                        // No rate right now
                        continue;
                    }

                    governmentIDPayee = uninvoicedTransaction.TrainNew.TrainSymbol.GovernmentIDOperator;
                    companyIDPayee = uninvoicedTransaction.TrainNew.TrainSymbol.CompanyIDOperator;

                    if (uninvoicedTransaction.IsPartialTrainTrip)
                    {
                        feeTotal = symbolRate.RatePerPartialTrip;
                        feeDescription += $"Partial Train Trip ({uninvoicedTransaction.TrainNew.TrainSymbol.Name})";
                    }
                    else
                    {
                        feeTotal = symbolRate.RatePerCar;
                        feeDescription += $"Train Trip ({uninvoicedTransaction.TrainNew.TrainSymbol.Name})";
                    }
                }

                // Who are we charging?
                LeaseContract leasedTo = uninvoicedTransaction.Railcar.LeaseContracts.FirstOrDefault(lc => lc.LeaseTimeStart <= uninvoicedTransaction.TransactionTime && lc.LeaseTimeEnd >= uninvoicedTransaction.TransactionTime);
                long? companyIDChargeTo = null;
                long? governmentIDChargeTo = null;
                if (leasedTo != null)
                {
                    companyIDChargeTo = leasedTo.CompanyIDLessee;
                    governmentIDChargeTo = leasedTo.GovernmentIDLessee;
                }
                else
                {
                    companyIDChargeTo = uninvoicedTransaction.Railcar.CompanyIDOwner;
                    governmentIDChargeTo = uninvoicedTransaction.Railcar.GovernmentIDOwner;
                }

                if (companyIDChargeTo == null && governmentIDChargeTo == null)
                {
                    continue; // There's no one to charge. Weird, but ok
                }

                if (companyIDPayee != null && !locationIDPayeesByCompanyID.ContainsKey(companyIDPayee))
                {
                    MiscellaneousSettings settings = new Search<MiscellaneousSettings>(new LongSearchCondition<MiscellaneousSettings>()
                    {
                        Field = nameof(MiscellaneousSettings.CompanyID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = companyIDPayee
                    }).GetReadOnly(null, new[] { nameof(MiscellaneousSettings.LocationIDInvoicePayee) });

                    if (settings?.LocationIDInvoicePayee == null)
                    {
                        continue; // No payee setup at this time
                    }

                    locationIDPayeesByCompanyID[companyIDPayee] = settings.LocationIDInvoicePayee;
                }

                if (companyIDChargeTo != null && !locationIDPayorsByCompanyID.ContainsKey(companyIDChargeTo))
                {
                    MiscellaneousSettings settings = new Search<MiscellaneousSettings>(new LongSearchCondition<MiscellaneousSettings>()
                    {
                        Field = nameof(MiscellaneousSettings.CompanyID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = companyIDChargeTo
                    }).GetReadOnly(null, new[] { nameof(MiscellaneousSettings.LocationIDInvoicePayor) });

                    if (settings?.LocationIDInvoicePayor == null)
                    {
                        continue; // No payor setup at this time
                    }

                    locationIDPayorsByCompanyID[companyIDChargeTo] = settings.LocationIDInvoicePayor;
                }

                if ((governmentIDPayee != null && governmentIDChargeTo != null && governmentIDPayee == governmentIDChargeTo) ||
                    (companyIDPayee != null && companyIDChargeTo != null && companyIDPayee == companyIDChargeTo)) // Can't charge same person
                {
                    uninvoicedTransaction.WillNotCharge = true;
                    if (!uninvoicedTransaction.Save(null))
                    {
                        errorBuilder.AppendLine("Failed to save Rail Transaction after determining Will Not Charge:");
                        foreach (Error error in uninvoicedTransaction.Errors)
                        {
                            errorBuilder.AppendLine("* " + error.Message);
                        }
                        errorBuilder.AppendLine();
                    }
                    continue;
                }

                Invoice invoice = invoiceLinesByInvoice.Keys.FirstOrDefault(inv => inv.GovernmentIDFrom == governmentIDPayee &&
                                                                                   (companyIDPayee == null || inv.LocationIDFrom == locationIDPayeesByCompanyID[companyIDPayee]) &&
                                                                                   inv.GovernmentIDTo == governmentIDChargeTo &&
                                                                                   (companyIDChargeTo == null || inv.LocationIDTo == locationIDPayorsByCompanyID[companyIDChargeTo]));

                if (invoice == null)
                {
                    invoice = DataObjectFactory.Create<Invoice>();
                    invoice.GovernmentIDFrom = governmentIDPayee;
                    invoice.LocationIDFrom = companyIDPayee == null ? (long?)null : locationIDPayeesByCompanyID[companyIDPayee];
                    invoice.GovernmentIDTo = governmentIDChargeTo;
                    invoice.LocationIDTo = companyIDChargeTo == null ? (long?)null : locationIDPayorsByCompanyID[companyIDChargeTo];

                    if (invoice.GovernmentIDFrom != null)
                    {
                        Government government = DataObject.GetReadOnlyByPrimaryKey<Government>(invoice.GovernmentIDFrom, null, new[]
                        {
                            nameof(Government.InvoiceNumberPrefix),
                            nameof(Government.NextInvoiceNumber)
                        });

                        invoice.InvoiceNumber = $"{government.InvoiceNumberPrefix}{government.NextInvoiceNumber}";
                    }
                    else if (invoice.LocationIDFrom != null)
                    {
                        Location location = DataObject.GetReadOnlyByPrimaryKey<Location>(invoice.LocationIDFrom, null, new[]
                        {
                            nameof(Location.InvoiceNumberPrefix),
                            nameof(Location.NextInvoiceNumber)
                        });

                        invoice.InvoiceNumber = $"{location.InvoiceNumberPrefix}{location.NextInvoiceNumber}";
                    }
                    invoice.Description = "Automated Invoice for the handling of railcars";
                    invoice.InvoiceDate = DateTime.Now;
                    invoice.DueDate = DateTime.Now.AddDays(7);
                    invoice.Status = Invoice.Statuses.WorkInProgress;
                    invoiceLinesByInvoice.Add(invoice, new List<InvoiceLine>());
                }

                InvoiceLine invoiceLine = DataObjectFactory.Create<InvoiceLine>();
                invoiceLine.Quantity = 1;
                invoiceLine.UnitCost = feeTotal;
                invoiceLine.Total = feeTotal;
                invoiceLine.Description = feeDescription;
                invoiceLinesByInvoice[invoice].Add(invoiceLine);

                if (!transactionsByInvoice.ContainsKey(invoice))
                {
                    transactionsByInvoice.Add(invoice, new List<RailcarLocationTransaction>());
                }

                transactionsByInvoice[invoice].Add(uninvoicedTransaction);
            }

            foreach(KeyValuePair<Invoice, List<InvoiceLine>> kvp in invoiceLinesByInvoice)
            {
                using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
                {
                    Invoice invoice = kvp.Key;
                    if (!invoice.Save(transaction))
                    {
                        errorBuilder.AppendLine("Failed to save Invoice:");
                        foreach(Error error in invoice.Errors)
                        {
                            errorBuilder.AppendLine("* " + error.Message);
                        }
                        errorBuilder.AppendLine();
                        continue;
                    }

                    foreach(InvoiceLine line in kvp.Value)
                    {
                        line.InvoiceID = invoice.InvoiceID;
                        if (!line.Save(transaction))
                        {
                            if (transaction.IsActive)
                            {
                                transaction.Rollback();
                            }

                            errorBuilder.AppendLine("Failed to save Invoice Line:");
                            foreach (Error error in line.Errors)
                            {
                                errorBuilder.AppendLine("* " + error.Message);
                            }
                            break;
                        }
                    }

                    invoice.Status = Invoice.Statuses.Sent;
                    if (!invoice.Save(transaction, new List<Guid>() { Invoice.ValidationIDs.V_SentStatusValid}))
                    {
                        errorBuilder.AppendLine("Failed to send Invoice:");
                        foreach (Error error in invoice.Errors)
                        {
                            errorBuilder.AppendLine("* " + error.Message);
                        }
                        errorBuilder.AppendLine();
                        continue;
                    }

                    foreach(RailcarLocationTransaction railTransaction in transactionsByInvoice[invoice])
                    {
                        railTransaction.InvoiceID = invoice.InvoiceID;
                        if (!railTransaction.Save(transaction))
                        {
                            errorBuilder.AppendLine("Failed to save Rail Transaction:");
                            foreach (Error error in railTransaction.Errors)
                            {
                                errorBuilder.AppendLine("* " + error.Message);
                            }
                            errorBuilder.AppendLine();
                            continue;
                        }
                    }

                    if (transaction.IsActive)
                    {
                        transaction.Commit();
                    }
                }
            }

            if (errorBuilder.Length > 0)
            {
                throw new Exception("At least one error occurred while saving Invoices/Invoice Lines/RailTransactions:\r\n" + errorBuilder.ToString());
            }

            return true;
        }
    }
}

