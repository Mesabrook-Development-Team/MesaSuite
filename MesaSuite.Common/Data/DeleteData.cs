using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MesaSuite.Common.Data
{
    public class DeleteData : DataAccess
    {
        public DeleteData(APIs api, string resource) : base(api, resource) { }
        public Dictionary<string, string> QueryString { get; set; } = new Dictionary<string, string>();

        public async Task Execute()
        {
            await InternalExecute();
        }

        private async Task<string> InternalExecute()
        {
            StringBuilder uriBuilder = new StringBuilder(GetResourceURI());
            bool first = true;
            foreach (KeyValuePair<string, string> queryString in QueryString)
            {
                if (first)
                {
                    uriBuilder.Append("?");
                    first = false;
                }
                else
                {
                    uriBuilder.Append("&");
                }

                uriBuilder.Append(queryString.Key);
                uriBuilder.Append("=");
                uriBuilder.Append(Uri.EscapeDataString(queryString.Value));
            }

            HttpWebRequest request = WebRequest.CreateHttp(uriBuilder.ToString());
            request.Method = "DELETE";

            if (RequireAuthentication)
            {
                request.Headers.Add("Authorization", "Bearer " + Authentication.GetAuthToken());
            }
            
            try
            {
                HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
                RequestSuccessful = true;
            }
            catch(WebException ex)
            {
                await HandleResponseWebException(ex, new ResponseWebExceptionRetryCallback(InternalExecute));
            }

            return await Task.FromResult<string>(null);
        }
    }
}
