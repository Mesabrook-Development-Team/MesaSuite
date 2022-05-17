using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebModels.company;

namespace API_Company.App_Code
{
    public class EmployeeCache
    {
        private static Dictionary<long, Dictionary<long, CachedEmployee>> _employeesByUserIDByCompanyID = new Dictionary<long, Dictionary<long, CachedEmployee>>();

        public async static Task<CachedEmployee> GetCachedEmployee(long companyID, long userID)
        {
            if (!_employeesByUserIDByCompanyID.ContainsKey(companyID))
            {
                _employeesByUserIDByCompanyID[companyID] = new Dictionary<long, CachedEmployee>();
            }

            if (!_employeesByUserIDByCompanyID[companyID].ContainsKey(userID) || _employeesByUserIDByCompanyID[companyID][userID].CacheExpiration <= DateTime.Now)
            {
                Search<Employee> employeeSearch = new Search<Employee>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<Employee>()
                    {
                        Field = "UserID",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = userID
                    },
                    new LongSearchCondition<Employee>()
                    {
                        Field = "CompanyID",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = companyID
                    }));

                HashSet<string> fields = new HashSet<string>(Employee.GetPermissionFieldNames())
                {
                    nameof(Employee.EmployeeID),
                    nameof(Employee.UserID),
                    nameof(Employee.CompanyID),
                    $"{nameof(Employee.LocationEmployees)}.{nameof(LocationEmployee.LocationID)}"
                };

                Employee employee = await Task.Run(() => employeeSearch.GetReadOnly(null, fields));

                CachedEmployee cachedEmployee = new CachedEmployee()
                {
                    CacheExpiration = DateTime.Now.AddSeconds(30),
                    UserID = userID,
                    CompanyID = companyID
                };

                if (employee != null)
                {
                    cachedEmployee.EmployeeID = employee.EmployeeID.Value;

                    SchemaObject employeeSchemaObject = Schema.GetSchemaObject<Employee>();
                    foreach(string permissionField in Employee.GetPermissionFieldNames())
                    {
                        Field field = employeeSchemaObject.GetField(permissionField);

                        if (permissionField.StartsWith(nameof(Employee.LocationEmployees)))
                        {
                            string permission = permissionField.Replace($"{nameof(Employee.LocationEmployees)}.", "");
                            foreach(LocationEmployee locationEmployee in employee.LocationEmployees)
                            {
                                if ((bool)field.GetValue(locationEmployee))
                                {
                                    if (!cachedEmployee.PermissionsByLocationID.ContainsKey(locationEmployee.LocationID.Value))
                                    {
                                        cachedEmployee.PermissionsByLocationID[locationEmployee.LocationID.Value] = new HashSet<string>();
                                    }

                                    cachedEmployee.PermissionsByLocationID[locationEmployee.LocationID.Value].Add(permission);
                                }
                            }
                        }
                        else
                        {
                            if ((bool)field.GetValue(employee))
                            {
                                cachedEmployee.Permissions.Add(permissionField);
                            }
                        }
                    }
                }

                _employeesByUserIDByCompanyID[companyID][userID] = cachedEmployee;
            }

            return _employeesByUserIDByCompanyID[companyID][userID];
        }

        public class CachedEmployee
        {
            public long CompanyID { get; set; }
            public long EmployeeID { get; set; }
            public long UserID { get; set; }
            public DateTime CacheExpiration { get; set; }
            public HashSet<string> Permissions { get; set; } = new HashSet<string>();
            public Dictionary<long, HashSet<string>> PermissionsByLocationID { get; set; } = new Dictionary<long, HashSet<string>>();
        }
    }
}