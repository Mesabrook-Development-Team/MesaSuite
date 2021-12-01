using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace MesaSuite
{
    public class Updater
    {
        public static async Task<UpdaterResults> RunAsync()
        {
            return await System.Threading.Tasks.Task.Run(() => Run());
        }

        public static UpdaterResults Run()
        {
            List<MCSyncVersion> versions = MCSyncVersion.GetVersions();
            // Get versions valid now
            versions = versions.Where(v => v.Valid <= DateTime.Now).ToList();

            Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            int currentVersionValue = (currentVersion.Major * 8) + (currentVersion.Minor * 4) + (currentVersion.Build * 2) + currentVersion.Revision;

            // Identify which versions we're behind on
            versions = versions.Where(v => v.VersionValue > currentVersionValue).ToList();

            return new UpdaterResults()
            {
                HasUpdates = versions.Any(),
                UpdatesAvailable = versions
            };
        }

        public static void DownloadAndStartUpdate(string versionToDownload)
        {
            byte[] data;
            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential("Reporting", "NetLogon");
                data = client.DownloadData(new Uri("ftp://www.clussmanproductions.com/support/MCSyncNew/updater.exe"));
            }

            File.WriteAllBytes($"Updater.exe", data);
            Process.Start($"Updater.exe", $"-processID {Process.GetCurrentProcess().Id} -version {versionToDownload}");
        }

        public class MCSyncVersion
        {
            private MCSyncVersion() { }

            public static List<MCSyncVersion> GetVersions()
            {
                List<MCSyncVersion> versions = new List<MCSyncVersion>();
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings.Get("MesaSuite.VersionURL"));
                webRequest.Accept = "application/json";
                webRequest.Method = WebRequestMethods.Http.Get;

                try
                {
                    string jsonReply;
                    using (Stream responseStream = webRequest.GetResponse().GetResponseStream())
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        jsonReply = reader.ReadToEnd();
                    }

                    versions = JsonConvert.DeserializeObject<List<MCSyncVersion>>(jsonReply);

                    return versions.OrderByDescending(v => v.Valid).ToList();
                }
                catch(WebException ex)
                {
                    return null;
                }
            }

            public byte Major { get; set; }
            public byte Minor { get; set; }
            public byte Revision { get; set; }
            public byte Build { get; set; }
            public DateTime Valid { get; set; }
            public string ReleaseNotes { get; set; }

            // Calculated
            public string VersionString
            {
                get { return $"{Major}.{Minor}.{Revision}.{Build}"; }
            }
            public int VersionValue
            {
                get
                {
                    return (Major * 8) + (Minor * 4) + (Revision * 2) + Build;
                }
            }
        }

        public class UpdaterResults
        {
            public bool HasUpdates { get; set; }
            public List<MCSyncVersion> UpdatesAvailable { get; set; }
        }
    }
}
