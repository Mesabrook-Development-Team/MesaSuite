using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;

namespace GovernmentPortal
{
    public static class PermissionsManager
    {
        private static bool _requestStop;
        private static bool _isRunning;
        private static ConcurrentDictionary<long, Dictionary<Permissions, bool>> PermissionsByGovernment = new ConcurrentDictionary<long, Dictionary<Permissions, bool>>();

        public static event EventHandler<PermissionChangeEventArgs> OnPermissionChange;

        public static void StartCheckThread(Action<Action> threadSafeCallback)
        {
            new Thread(new ParameterizedThreadStart(CheckThread)).Start(threadSafeCallback);
        }

        public static void StopCheckThread()
        {
            _requestStop = true;
        }

        private static void CheckThread(object threadSafeCallback)
        {
            Action<Action> callback = (Action<Action>)threadSafeCallback;
            if (_isRunning)
            {
                return;
            }

            _isRunning = true;
            _requestStop = false;
            PermissionsByGovernment = new ConcurrentDictionary<long, Dictionary<Permissions, bool>>();
            Dictionary<string, PropertyInfo> permissionPropertiesByName = new Dictionary<string, PropertyInfo>();
            Type officialType = typeof(Official);
            foreach (var item in Enum.GetValues(typeof(Permissions)))
            {
                PropertyInfo permissionProperty = officialType.GetProperty(item.ToString());
                permissionPropertiesByName.Add(item.ToString(), permissionProperty);
            }

            while (!_requestStop)
            {
                GetData getData = new GetData(DataAccess.APIs.GovernmentPortal, "Government/GetAllForUser");
                List<Government> companies = getData.GetObject<List<Government>>().Result;

                foreach (Government government in companies)
                {
                    getData = new GetData(DataAccess.APIs.GovernmentPortal, "Official/GetForGovernment");
                    getData.Headers.Add("GovernmentID", government.GovernmentID.ToString());
                    getData.QueryString.Add("id", government.GovernmentID.ToString());

                    Official official = getData.GetObject<Official>().Result;
                    if (official == null)
                    {
                        continue;
                    }

                    foreach (var item in Enum.GetValues(typeof(Permissions)))
                    {
                        PropertyInfo propertyInfo = permissionPropertiesByName[item.ToString()];

                        bool isNew = !PermissionsByGovernment.ContainsKey(government.GovernmentID) || !PermissionsByGovernment[government.GovernmentID].ContainsKey((Permissions)item);
                        bool previousValue = false;
                        if (!isNew)
                        {
                            previousValue = PermissionsByGovernment[government.GovernmentID][(Permissions)item];
                        }

                        if (!PermissionsByGovernment.ContainsKey(government.GovernmentID))
                        {
                            PermissionsByGovernment[government.GovernmentID] = new Dictionary<Permissions, bool>();
                        }

                        PermissionsByGovernment[government.GovernmentID][(Permissions)item] = (bool)propertyInfo.GetValue(official);

                        if (!isNew && previousValue != PermissionsByGovernment[government.GovernmentID][(Permissions)item])
                        {
                            callback(() => OnPermissionChange?.Invoke(null, new PermissionChangeEventArgs(government.GovernmentID, (Permissions)item, PermissionsByGovernment[government.GovernmentID][(Permissions)item])));
                        }
                    }
                }

                Thread.Sleep(3000);
            }

            _requestStop = false;
            _isRunning = false;
        }

        public static bool HasPermission(long governmentID, Permissions permission)
        {
            if (!PermissionsByGovernment.ContainsKey(governmentID))
            {
                return false;
            }

            if (!PermissionsByGovernment[governmentID].ContainsKey(permission))
            {
                return false;
            }

            return PermissionsByGovernment[governmentID][permission];
        }

        public enum Permissions
        {
            ManageEmails,
            ManageOfficials,
            ManageAccounts,
            CanMintCurrency
        }

        public class PermissionChangeEventArgs : EventArgs
        {
            public long GovernmentID { get; }
            public Permissions Permission { get; }
            public bool Value { get; }

            public PermissionChangeEventArgs(long governmentID, Permissions permission, bool value)
            {
                GovernmentID = governmentID;
                Permission = permission;
                Value = value;
            }
        }
    }
}
