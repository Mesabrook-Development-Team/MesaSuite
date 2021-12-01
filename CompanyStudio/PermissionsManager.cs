using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CompanyStudio.Models;
using MesaSuite.Common.Data;

namespace CompanyStudio
{
    public static class PermissionsManager
    {
        private static bool _requestStop;
        private static bool _isRunning;
        private static ConcurrentDictionary<long, Dictionary<Permissions, bool>> PermissionsByCompany = new ConcurrentDictionary<long, Dictionary<Permissions, bool>>();

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
            PermissionsByCompany = new ConcurrentDictionary<long, Dictionary<Permissions, bool>>();
            Dictionary<string, PropertyInfo> permissionPropertiesByName = new Dictionary<string, PropertyInfo>();
            Type employeeType = typeof(Employee);
            foreach (var item in Enum.GetValues(typeof(Permissions)))
            {
                PropertyInfo permissionProperty = employeeType.GetProperty(item.ToString());
                permissionPropertiesByName.Add(item.ToString(), permissionProperty);
            }

            while (!_requestStop)
            {
                GetData getData = new GetData(DataAccess.APIs.CompanyStudio, "Company/GetForEmployee");
                List<Company> companies = getData.GetObject<List<Company>>().Result;

                foreach (Company company in companies)
                {
                    getData = new GetData(DataAccess.APIs.CompanyStudio, "Employee/GetForCompany");
                    getData.Headers.Add("CompanyID", company.CompanyID.ToString());
                    getData.QueryString.Add("id", company.CompanyID.ToString());

                    Employee employee = getData.GetObject<Employee>().Result;
                    if (employee == null)
                    {
                        continue;
                    }

                    foreach (var item in Enum.GetValues(typeof(Permissions)))
                    {
                        PropertyInfo propertyInfo = permissionPropertiesByName[item.ToString()];

                        bool isNew = !PermissionsByCompany.ContainsKey(company.CompanyID) || !PermissionsByCompany[company.CompanyID].ContainsKey((Permissions)item);
                        bool previousValue = false;
                        if (!isNew)
                        {
                            previousValue = PermissionsByCompany[company.CompanyID][(Permissions)item];
                        }

                        if (!PermissionsByCompany.ContainsKey(company.CompanyID))
                        {
                            PermissionsByCompany[company.CompanyID] = new Dictionary<Permissions, bool>();
                        }

                        PermissionsByCompany[company.CompanyID][(Permissions)item] = (bool)propertyInfo.GetValue(employee);

                        if (!isNew && previousValue != PermissionsByCompany[company.CompanyID][(Permissions)item])
                        {
                            callback(() => OnPermissionChange?.Invoke(null, new PermissionChangeEventArgs(company.CompanyID, (Permissions)item, PermissionsByCompany[company.CompanyID][(Permissions)item])));
                        }
                    }
                }

                Thread.Sleep(3000);
            }

            _requestStop = false;
            _isRunning = false;
        }

        public static bool HasPermission(long companyID, Permissions permission)
        {
            if (!PermissionsByCompany.ContainsKey(companyID))
            {
                return false;
            }

            if (!PermissionsByCompany[companyID].ContainsKey(permission))
            {
                return false;
            }

            return PermissionsByCompany[companyID][permission];
        }

        public enum Permissions
        {
            ManageEmails,
            ManageEmployees,
            ManageAccounts
        }

        public class PermissionChangeEventArgs : EventArgs
        {
            public long CompanyID { get; }
            public Permissions Permission { get; }
            public bool Value { get; }

            public PermissionChangeEventArgs(long companyID, Permissions permission, bool value)
            {
                CompanyID = companyID;
                Permission = permission;
                Value = value;
            }
        }
    }
}
