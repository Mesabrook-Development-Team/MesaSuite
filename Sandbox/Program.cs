using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Loader;
using ClussPro.ObjectBasedFramework.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebModels.account;
using WebModels.hMailServer.dbo;
using WebModels.security;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = DataObjectFactory.Create<User>();
            //Schema.Deploy();

            HttpWebRequest request = WebRequest.CreateHttp("http://localhost:65171/AccessCode/Verify");
            request.Method = "PUT";
            request.ContentType = "application/json";
            Console.Write("Enter OAuth Token:");
            request.Headers.Add("Authorization", "Bearer " + Console.ReadLine());

            Console.Write("Enter Door Code:");
            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write("\"" + Console.ReadLine() + "\"");
            }

            WebResponse response;
            try
            {
                response = request.GetResponse();
            }
            catch(WebException ex)
            {
                response = ex.Response;
            }

            string responseData;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                responseData = reader.ReadToEnd();
            }

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
