using MesaSuite.Common.Attributes;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesaSuite.Common.Data
{
    internal class InternalEditionResourceWriter : IResourceWriter
    {
        public string Write(DataAccess dataAccess)
        {
            StringBuilder builder = new StringBuilder(dataAccess.UseHTTPS ? "https" : "http");
            builder.Append("://internalapi.mesabrook.com/");
            builder.Append(dataAccess.API.GetAttribute<EnumValueAttribute>().Value);
            builder.Append("/");
            builder.Append(dataAccess.Resource);

            return builder.ToString();
        }
    }
}
