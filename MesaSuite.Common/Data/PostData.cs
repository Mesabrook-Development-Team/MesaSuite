using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace MesaSuite.Common.Data
{
    public class PostData : DataAccess
    {
        public object ObjectToPost { get; set; }
        public PostData(APIs api, string resource) : base(api, resource) { }
        public PostData(APIs api, string resource, object objectToPost) : base(api, resource)
        {
            ObjectToPost = objectToPost;
        }

        public async Task<T> Execute<T>()
        {
            string json = await GetJson();

            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task ExecuteNoResult()
        {
            await GetJson();
        }

        private async Task<string> GetJson()
        {
            HttpWebRequest request = WebRequest.CreateHttp(GetResourceURI());
            request.Method = WebRequestMethods.Http.Post;
            if (RequireAuthentication)
            {
                request.Headers.Add("Authorization", "Bearer " + Authentication.GetAuthToken());
            }
            request.ContentType = "application/json";

            string json = JsonConvert.SerializeObject(ObjectToPost);

            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                await writer.WriteAsync(json);
            }

            try
            {
                WebResponse response = await request.GetResponseAsync();
                string responseJson;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    responseJson = await reader.ReadToEndAsync();
                }
                RequestSuccessful = true;
                return responseJson;
            }
            catch(WebException ex)
            {
                return await HandleResponseWebException(ex, new ResponseWebExceptionRetryCallback(GetJson));
            }
        }
    }
}
