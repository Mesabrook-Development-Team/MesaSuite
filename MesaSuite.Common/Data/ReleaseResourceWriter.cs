using MesaSuite.Common.Attributes;
using MesaSuite.Common.Extensions;
using System.Text;

namespace MesaSuite.Common.Data
{
    internal class ReleaseResourceWriter : IResourceWriter
    {
        public string Write(DataAccess dataAccess)
        {
            StringBuilder builder = new StringBuilder(dataAccess.UseHTTPS ? "https" : "http");
            builder.Append("://api.mesabrook.com/");
            builder.Append(dataAccess.API.GetAttribute<EnumValueAttribute>().Value);
            builder.Append("/");
            builder.Append(dataAccess.Resource);

            return builder.ToString();
        }
    }
}
