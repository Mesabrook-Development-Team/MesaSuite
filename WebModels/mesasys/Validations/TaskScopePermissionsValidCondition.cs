using ClussPro.Base.Data.Query;
using ClussPro.Base.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Utility;
using ClussPro.ObjectBasedFramework.Validation.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.company;
using WebModels.fleet;
using WebModels.gov;

namespace WebModels.mesasys.Validations
{
    public class TaskScopePermissionsValidCondition : Condition
    {
        private static Dictionary<TaskEvent.ScopeTypes, List<string>> _validFieldsByScopeType = new Dictionary<TaskEvent.ScopeTypes, List<string>>();

        static TaskScopePermissionsValidCondition()
        {
            _validFieldsByScopeType = new Dictionary<TaskEvent.ScopeTypes, List<string>>()
            {
                {
                    TaskEvent.ScopeTypes.Global,
                    new List<string>()
                },
                {
                    TaskEvent.ScopeTypes.Company,
                    FieldPathUtility.CreateFieldPathsAsList<Employee>(e => new List<object>()
                    {
                        e.ManageEmails,
                        e.ManageEmployees,
                        e.ManageAccounts,
                        e.ManageLocations,
                        e.IssueWireTransfers
                    })
                },
                {
                    TaskEvent.ScopeTypes.Fleet,
                    FieldPathUtility.CreateFieldPathsAsList<FleetSecurity>(f => new List<object>()
                    {
                        f.AllowSetup,
                        f.AllowLeasingManagement,
                        f.IsYardmaster,
                        f.IsTrainCrew,
                        f.AllowLoadUnload
                    })
                },
                {
                    TaskEvent.ScopeTypes.Government,
                    FieldPathUtility.CreateFieldPathsAsList<Official>(o => new List<object>()
                    {
                        o.ManageEmails,
                        o.ManageOfficials,
                        o.ManageAccounts,
                        o.CanMintCurrency,
                        o.CanConfigureInterest,
                        o.ManageTaxes,
                        o.ManageInvoices,
                        o.IssueWireTransfers,
                        o.ManageLaws
                    })
                },
                {
                    TaskEvent.ScopeTypes.Location,
                    FieldPathUtility.CreateFieldPathsAsList<LocationEmployee>(e => new List<object>()
                    {
                        e.ManageInvoices,
                        e.ManageInventory,
                        e.ManagePrices,
                        e.ManageRegisters
                    })
                }
            };
        }

        public override bool Evaluate(DataObject dataObject, ITransaction transaction)
        {
            if (!(dataObject is TaskEvent TaskEvent))
            {
                throw new InvalidCastException("dataObject was expected to be a TaskEvent");
            }

            List<string> validPermissions = _validFieldsByScopeType.GetOrDefault(TaskEvent.ScopeType, new List<string>());
            string[] selectedPermissions = TaskEvent.ScopePermissions.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return selectedPermissions.All(p => validPermissions.Contains(p));
        }
    }
}
