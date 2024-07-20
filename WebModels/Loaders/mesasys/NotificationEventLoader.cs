using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Loader;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebModels.account;
using WebModels.company;
using WebModels.fleet;
using WebModels.gov;
using WebModels.invoicing;
using WebModels.mesasys;

namespace WebModels.Loaders.mesasys
{
    public class NotificationEventLoader : ILoader
    {

        public IEnumerable<LoaderObject> GetLoaderObjects()
        {
            List<LoaderObject> notificationEvents = new List<LoaderObject>();
            notificationEvents.AddRange(GetInvoiceNotificationEvents());
            notificationEvents.AddRange(GetFleetTrackingNotifications());
            notificationEvents.AddRange(GetStoreNotifications());

            return notificationEvents;
        }

        private IEnumerable<LoaderObject> GetInvoiceNotificationEvents()
        {
            yield return new LoaderNotificationEvent(NotificationEvent.NotificationEvents.CompanyWireTransferReceived,
                NotificationEvent.ScopeTypes.Company,
                "Wire Transfered Received (Location)",
                FieldPathUtility.CreateFieldPathsAsList<WireTransferHistory>(wth => new List<object>()
                {
                    wth.GovernmentFrom.Name,
                    wth.CompanyFrom.Name,
                    wth.GovernmentTo.Name,
                    wth.CompanyTo.Name,
                    wth.TransferTime,
                    wth.AccountFromMasked,
                    wth.AccountToHistorical,
                    wth.AccountToMasked,
                    wth.Amount,
                    wth.Memo
                }))
                .SetScopePermissions<Employee>(e => new List<object>()
                {
                    e.IssueWireTransfers
                });

            yield return new LoaderNotificationEvent(NotificationEvent.NotificationEvents.LocationAccountsPayableInvoiceReceived,
                NotificationEvent.ScopeTypes.Location,
                "Payable Invoice Received (Location)",
                FieldPathUtility.CreateFieldPathsAsList<Invoice>(invoice => new List<object>()
                {
                    invoice.GovernmentFrom.Name,
                    invoice.LocationFrom.Name,
                    invoice.LocationFrom.Company.Name,
                    invoice.GovernmentTo.Name,
                    invoice.LocationTo.Name,
                    invoice.LocationTo.Company.Name,
                    invoice.InvoiceNumber,
                    invoice.Description,
                    invoice.InvoiceDate,
                    invoice.DueDate,
                    invoice.Status,
                    invoice.Amount
                }))
                .SetScopePermissions<LocationEmployee>(le => new List<object>()
                {
                    le.ManageInvoices
                });

            yield return new LoaderNotificationEvent(NotificationEvent.NotificationEvents.LocationAccountsReceivableInvoiceReadyForReceipt,
                NotificationEvent.ScopeTypes.Location,
                "Receivable Invoice Ready For Receipt (Location)",
                FieldPathUtility.CreateFieldPathsAsList<Invoice>(invoice => new List<object>()
                {
                    invoice.GovernmentFrom.Name,
                    invoice.LocationFrom.Name,
                    invoice.LocationFrom.Company.Name,
                    invoice.GovernmentTo.Name,
                    invoice.LocationTo.Name,
                    invoice.LocationTo.Company.Name,
                    invoice.InvoiceNumber,
                    invoice.Description,
                    invoice.InvoiceDate,
                    invoice.DueDate,
                    invoice.Status,
                    invoice.AccountTo.AccountNumber,
                    invoice.AccountTo.Description,
                    invoice.Amount
                }))
                .SetScopePermissions<LocationEmployee>(le => new List<object>()
                {
                    le.ManageInvoices
                });

            yield return new LoaderNotificationEvent(NotificationEvent.NotificationEvents.GovernmentWireTransferReceived,
                NotificationEvent.ScopeTypes.Government,
                "Wire Transfered Received (Government)",
                FieldPathUtility.CreateFieldPathsAsList<WireTransferHistory>(wth => new List<object>()
                {
                    wth.GovernmentFrom.Name,
                    wth.CompanyFrom.Name,
                    wth.GovernmentTo.Name,
                    wth.CompanyTo.Name,
                    wth.TransferTime,
                    wth.AccountFromMasked,
                    wth.AccountToHistorical,
                    wth.AccountToMasked,
                    wth.Amount,
                    wth.Memo
                }))
                .SetScopePermissions<Official>(o => new List<object>()
                {
                    o.IssueWireTransfers
                });

            yield return new LoaderNotificationEvent(NotificationEvent.NotificationEvents.GovernmentAccountsPayableInvoiceReceived,
                NotificationEvent.ScopeTypes.Government,
                "Payable Invoice Received (Government)",
                FieldPathUtility.CreateFieldPathsAsList<Invoice>(invoice => new List<object>()
                {
                    invoice.GovernmentFrom.Name,
                    invoice.LocationFrom.Name,
                    invoice.LocationFrom.Company.Name,
                    invoice.GovernmentTo.Name,
                    invoice.LocationTo.Name,
                    invoice.LocationTo.Company.Name,
                    invoice.InvoiceNumber,
                    invoice.Description,
                    invoice.InvoiceDate,
                    invoice.DueDate,
                    invoice.Status,
                    invoice.Amount
                }))
                .SetScopePermissions<Official>(o => new List<object>()
                {
                    o.ManageInvoices
                });

            yield return new LoaderNotificationEvent(NotificationEvent.NotificationEvents.GovernmentAccountsReceivableInvoiceReadyForReceipt,
                NotificationEvent.ScopeTypes.Government,
                "Receivable Invoice Ready For Receipt (Government)",
                FieldPathUtility.CreateFieldPathsAsList<Invoice>(invoice => new List<object>()
                {
                    invoice.GovernmentFrom.Name,
                    invoice.LocationFrom.Name,
                    invoice.LocationFrom.Company.Name,
                    invoice.GovernmentTo.Name,
                    invoice.LocationTo.Name,
                    invoice.LocationTo.Company.Name,
                    invoice.InvoiceNumber,
                    invoice.Description,
                    invoice.InvoiceDate,
                    invoice.DueDate,
                    invoice.Status,
                    invoice.AccountTo.AccountNumber,
                    invoice.AccountTo.Description,
                    invoice.Amount
                }))
                .SetScopePermissions<Official>(o => new List<object>()
                {
                    o.ManageInvoices
                });
        }

        private IEnumerable<LoaderObject> GetFleetTrackingNotifications()
        {
            yield return new LoaderNotificationEvent(NotificationEvent.NotificationEvents.RailcarReleasedReceived,
                NotificationEvent.ScopeTypes.Fleet,
                "Railcar Release Received",
                FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new List<object>()
                {
                    r.ReportingMark,
                    r.ReportingNumber,
                    r.CompanyPossessor.Name,
                    r.GovernmentPossessor.Name,
                    r.TrackDestination.Name,
                    r.RailLocation.Position,
                    r.RailLocation.Track.Name,
                    r.RailLocation.Train.TimeOnDuty,
                    r.RailLocation.Train.TrainSymbol.Name
                }))
                .SetScopePermissions<FleetSecurity>(fs => new List<object>()
                {
                    fs.AllowSetup
                });

            yield return new LoaderNotificationEvent(NotificationEvent.NotificationEvents.LocomotiveReleasedReceived,
                NotificationEvent.ScopeTypes.Fleet,
                "Locomotive Release Received",
                FieldPathUtility.CreateFieldPathsAsList<Locomotive>(l => new List<object>()
                {
                    l.ReportingMark,
                    l.ReportingNumber,
                    l.CompanyPossessor.Name,
                    l.GovernmentPossessor.Name,
                    l.RailLocation.Position,
                    l.RailLocation.Track.Name,
                    l.RailLocation.Train.TimeOnDuty,
                    l.RailLocation.Train.TrainSymbol.Name
                }))
                .SetScopePermissions<FleetSecurity>(fs => new List<object>()
                {
                    fs.AllowSetup
                });

            yield return new LoaderNotificationEvent(NotificationEvent.NotificationEvents.NewLeaseRequestAvailable,
                NotificationEvent.ScopeTypes.Fleet,
                "New Lease Request Available",
                FieldPathUtility.CreateFieldPathsAsList<LeaseRequest>(lr => new List<object>()
                {
                    lr.LeaseRequestID,
                    lr.CompanyRequester.Name,
                    lr.GovernmentRequester.Name,
                    lr.LeaseType,
                    lr.RailcarType,
                    lr.TrackDeliveryLocation.Name,
                    lr.Purpose,
                    lr.BidEndTime
                }))
                .SetScopePermissions<FleetSecurity>(fs => new List<object>()
                {
                    fs.AllowSetup
                });

            yield return new LoaderNotificationEvent(NotificationEvent.NotificationEvents.LeaseBidReceived,
                NotificationEvent.ScopeTypes.Fleet,
                "Lease Bid Received",
                FieldPathUtility.CreateFieldPathsAsList<LeaseBid>(lb => new List<object>()
                {
                    lb.LeaseRequestID,
                    lb.LeaseAmount,
                    lb.RecurringAmountType,
                    lb.RecurringAmount,
                    lb.Terms,
                    lb.LeaseRequest.TrackDeliveryLocation.Name,
                    lb.LeaseRequest.LeaseType,
                    lb.LeaseRequest.RailcarType,
                    lb.LeaseRequest.Purpose,
                    lb.LeaseRequest.BidEndTime,
                    lb.Railcar.ReportingMark,
                    lb.Railcar.ReportingNumber,
                    lb.Railcar.RailcarModel.Name,
                    lb.Railcar.RailcarModel.CargoCapacity,
                    lb.Railcar.RailcarModel.Length,
                    lb.Railcar.CompanyOwner.Name,
                    lb.Railcar.GovernmentOwner.Name,
                    lb.Railcar.RailLocation.Track.Name,
                    lb.Railcar.RailLocation.Train.TrainSymbol.Name,
                    lb.Railcar.RailLocation.Train.TimeOnDuty,
                    lb.Locomotive.ReportingMark,
                    lb.Locomotive.ReportingNumber,
                    lb.Locomotive.LocomotiveModel.Name,
                    lb.Locomotive.LocomotiveModel.IsSteamPowered,
                    lb.Locomotive.LocomotiveModel.WaterCapacity,
                    lb.Locomotive.LocomotiveModel.FuelCapacity,
                    lb.Locomotive.LocomotiveModel.Length,
                    lb.Locomotive.CompanyOwner.Name,
                    lb.Locomotive.GovernmentOwner.Name,
                    lb.Locomotive.RailLocation.Track.Name,
                    lb.Locomotive.RailLocation.Train.TrainSymbol.Name,
                    lb.Locomotive.RailLocation.Train.TimeOnDuty
                }))
                .SetScopePermissions<FleetSecurity>(fs => new List<object>()
                {
                    fs.AllowSetup
                });
        }

        private IEnumerable<LoaderObject> GetStoreNotifications()
        {
            yield return new LoaderNotificationEvent(NotificationEvent.NotificationEvents.RegisterOffline,
                NotificationEvent.ScopeTypes.Location,
                "Register Offline",
                FieldPathUtility.CreateFieldPathsAsList<RegisterStatus>(rs => new List<object>()
                {
                    rs.ChangeTime,
                    rs.Status,
                    rs.Initiator,
                    rs.Register.Name,
                    rs.Register.Location.Name,
                    rs.Register.Location.Company.Name
                }))
                .SetScopePermissions<LocationEmployee>(le => new List<object>()
                {
                    le.ManageRegisters
                });
        }

        private class LoaderNotificationEvent : LoaderObject<NotificationEvent>
        {
            public LoaderNotificationEvent(Guid systemID,
                                           NotificationEvent.ScopeTypes scopeType,
                                           string name,
                                           List<string> parameters) : base(systemID)
            {
                ScopeType = scopeType;
                Name = name;
                Parameters = parameters;
            }

            public NotificationEvent.ScopeTypes ScopeType { get; set; }
            public string ScopePermissions { get; private set; }
            public string Name { get; set; }
            public List<string> Parameters { get; set; }
            private string ParametersString => string.Join(",", Parameters ?? new List<string>());

            public LoaderNotificationEvent SetScopePermissions<TScopeObject>(Expression<Func<TScopeObject, List<object>>> expression) where TScopeObject: DataObject
            {
                List<string> validFields = NotificationEvent.ValidFieldsByScopeType[ScopeType];
                List<string> selectedFields = FieldPathUtility.CreateFieldPathsAsList(expression);
                if (!selectedFields.All(f => validFields.Contains(f)))
                {
                    throw new InvalidOperationException("All fields must be defined in NotificationEvent.ValidFieldsByScopeType");
                }

                ScopePermissions = string.Join(",", selectedFields);

                return this;
            }

            public override Dictionary<string, object> GetValuesByField()
            {
                DataObjectValues = (ne) => new Dictionary<object, object>()
                {
                    { ne.ScopeType, ScopeType },
                    { ne.ScopePermissions, ScopePermissions },
                    { ne.Name, Name },
                    { ne.Parameters, ParametersString }
                };

                return base.GetValuesByField();
            }
        }
    }
}
