using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Updater
{
    public class Updater
    {
        public InstallationConfiguration InstallationConfiguration { get; set; }

        public event EventHandler<int> NumberOfTasks;
        public event EventHandler<string> NonTaskExecuting;
        public event EventHandler<string> TaskExecuting;
        public event EventHandler UpdateFailed;
        public event EventHandler UpdateSucceeded;

        private List<string> _errors = new List<string>();

        public IReadOnlyCollection<string> Errors => _errors;

        public async Task BeginUpdate()
        {
            await Task.Run(() => PerformUpdate());
        }

        private void PerformUpdate()
        {
            if (StartupArguments.MCSyncProcessID != -1)
            {
                NonTaskExecuting?.Invoke(this, "Waiting for MCSync to close...");
                while(Process.GetProcesses().Any(p => p.Id == StartupArguments.MCSyncProcessID))
                {
                    Thread.Sleep(50);
                }
            }

            if (string.IsNullOrEmpty(StartupArguments.VersionToDownload))
            {
                _errors.Add("Invalid version specified");
                UpdateFailed?.Invoke(this, new EventArgs());
                return;
            }

            NetworkCredential ftpCredentials = new NetworkCredential("Reporting", "NetLogon");
            FtpWebRequest webRequest = (FtpWebRequest)WebRequest.Create($"ftp://www.clussmanproductions.com/support/MCSyncNew/updates/{StartupArguments.VersionToDownload}");
            webRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            webRequest.Credentials = ftpCredentials;
            
            string files;
            try
            {
                using (Stream responseStream = webRequest.GetResponse().GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    files = reader.ReadToEnd();
                }
            }
            catch(WebException)
            {
                _errors.Add("Invalid version specified");
                UpdateFailed?.Invoke(this, new EventArgs());
                return;
            }

            using (StringReader reader = new StringReader(files))
            {
                string file;

                int counter = 0;
                while ((file = reader.ReadLine()) != null)
                {
                    counter++;
                }

                NumberOfTasks?.Invoke(this, counter);
            }

            using (StringReader reader = new StringReader(files))
            {
                string file;
                while ((file = reader.ReadLine()) != null)
                {
                    TaskExecuting?.Invoke(this, "Downloading " + file);

                    webRequest = (FtpWebRequest)WebRequest.Create($"ftp://www.clussmanproductions.com/support/MCSyncNew/updates/{StartupArguments.VersionToDownload}/{file}");
                    webRequest.Credentials = ftpCredentials;
                    webRequest.Method = WebRequestMethods.Ftp.DownloadFile;

                    using (Stream responseStream = webRequest.GetResponse().GetResponseStream())
                    using (Stream fileStream = File.Create(Path.Combine(InstallationConfiguration.InstallDirectory, file)))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
            }

            StringBuilder argumentBuilder = new StringBuilder($"-processID {Process.GetCurrentProcess().Id}");
            if (!string.IsNullOrEmpty(StartupArguments.FolderToDelete))
            {
                argumentBuilder.Append($" -folder {StartupArguments.FolderToDelete}");
            }

            UpdateSucceeded?.Invoke(this, new EventArgs());
        }
    }
}
