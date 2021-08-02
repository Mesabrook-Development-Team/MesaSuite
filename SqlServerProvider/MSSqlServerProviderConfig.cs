using ClussPro.Base.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClussPro.SqlServerProvider
{
    internal static class MSSqlServerProviderConfig
    {
        private static bool _forceLoad = true;
        private static object _forceLoadLock = new object();

        private static Dictionary<string, string> _connectionStrings = new Dictionary<string, string>();
        public static string GetConnectionString(string name)
        {
            Load();
            return _connectionStrings.GetOrDefault(name);
        }

        private static void Load()
        {
            lock (_forceLoadLock)
            {
                if (!_forceLoad)
                {
                    return;
                }

                _forceLoad = false;

                _connectionStrings = new Dictionary<string, string>();

                foreach (string connectionStringKey in ConfigurationManager.AppSettings.AllKeys.Where(k => k.StartsWith("MSSQLProvider.ConnectionString", StringComparison.OrdinalIgnoreCase)))
                {
                    string variant = connectionStringKey.Replace("MSSQLProvider.ConnectionString", "");
                    if (string.IsNullOrEmpty(variant))
                    {
                        _connectionStrings.Add("_default", ConfigurationManager.AppSettings.Get(connectionStringKey));
                    }
                    else
                    {
                        variant = variant.Substring(1);
                        _connectionStrings.Add(variant, ConfigurationManager.AppSettings.Get(connectionStringKey));
                    }
                }
            }
        }
    }

    [XmlRoot("MSSqlServerProviderConfig")]
    public class Config
    {
        public string ConnectionString { get; set; } = "";
    }
}
