using System.Configuration;
using System.Text;

namespace MesaSuite.Common.Data
{
    internal class DebugResourceWriter : IResourceWriter
    {
        public string Write(DataAccess dataAccess)
        {
            string host = ConfigurationManager.AppSettings.Get("MesaSuite.Common.DebugResourceWriter.Host." + dataAccess.API.ToString());
            if (string.IsNullOrEmpty(host))
            {
                host = ConfigurationManager.AppSettings.Get("MesaSuite.Common.DebugResourceWriter.Host");
            }
            if (string.IsNullOrEmpty(host))
            {
                throw new ConfigurationErrorsException("Host must be specified when using DebugResourceWriter");
            }

            StringBuilder builder = new StringBuilder(host);
            builder.Append("/");
            builder.Append(dataAccess.Resource);
            return builder.ToString();
        }
    }
}
