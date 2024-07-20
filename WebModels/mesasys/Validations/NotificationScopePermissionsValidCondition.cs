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
    public class NotificationScopePermissionsValidCondition : Condition
    {

        public override bool Evaluate(DataObject dataObject, ITransaction transaction)
        {
            if (!(dataObject is NotificationEvent notificationEvent))
            {
                throw new InvalidCastException("dataObject was expected to be a NotificationEvent");
            }

            List<string> validPermissions = NotificationEvent.ValidFieldsByScopeType.GetOrDefault(notificationEvent.ScopeType, new List<string>());
            string[] selectedPermissions = notificationEvent.ScopePermissions.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return selectedPermissions.All(p => validPermissions.Contains(p));
        }
    }
}
