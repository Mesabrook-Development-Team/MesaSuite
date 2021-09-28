using MesaSuite.Common.Attributes;
using MesaSuite.Common.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace MesaSuite.Common.Data
{
    public class PatchData : DataAccess
    {
        private PatchMethods _patchMethod;
        private long? _primaryKey;
        private Dictionary<string, object> _values;
        public PatchData(APIs api, string resource, PatchMethods patchMethod, long? primaryKeyOfRecord, Dictionary<string, object> valuesToUpdate) : base(api, resource)
        {
            _patchMethod = patchMethod;
            _primaryKey = primaryKeyOfRecord;
            _values = valuesToUpdate;
        }

        public async Task Execute()
        {
            await InternalExecute();
        }

        private async Task<string> InternalExecute()
        {
            HttpWebRequest request = WebRequest.CreateHttp(GetResourceURI());
            request.ContentType = "application/json";
            request.Method = "PATCH";

            if (RequireAuthentication)
            {
                request.Headers.Add("Authorization", "Bearer " + Authentication.GetAuthToken());
            }

            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {

                string patchRequest = JsonConvert.SerializeObject(new PatchInfo()
                {
                    PrimaryKey = _primaryKey,
                    Method = _patchMethod.GetValue(),
                    Values = _values
                });

                writer.Write(patchRequest);
            }

            try
            {
                await request.GetResponseAsync();
                RequestSuccessful = true;
            }
            catch(WebException ex)
            {
                await HandleResponseWebException(ex, new ResponseWebExceptionRetryCallback(InternalExecute));
            }

            return await Task.FromResult<string>(null);
        }

        public enum PatchMethods
        {
            [EnumValue("add")]
            Add,
            [EnumValue("remove")]
            Remove,
            [EnumValue("replace")]
            Replace
        }
    }
}
