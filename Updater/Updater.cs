using IWshRuntimeLibrary;
using Microsoft.Win32;
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

            if (!DownloadFiles())
            {
                return;
            }

            if (!UpdateRegistry())
            {
                return;
            }

            AddIcons();

            UpdateSucceeded?.Invoke(this, new EventArgs());
        }

        private bool DownloadFiles()
        {
            if (string.IsNullOrEmpty(StartupArguments.VersionToDownload))
            {
                _errors.Add("Invalid version specified");
                UpdateFailed?.Invoke(this, new EventArgs());
                return false;
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
            catch (WebException)
            {
                _errors.Add("Invalid version specified");
                UpdateFailed?.Invoke(this, new EventArgs());
                return false;
            }

            using (StringReader reader = new StringReader(files))
            {
                string file;

                int counter = 0;
                while ((file = reader.ReadLine()) != null)
                {
                    counter++;
                }

                NumberOfTasks?.Invoke(this, counter + 2); // Adding 2 - one for registry, one for icons
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
                    using (Stream fileStream = System.IO.File.Create(Path.Combine(InstallationConfiguration.InstallDirectory, file)))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
            }

            return true;
        }

        private bool UpdateRegistry()
        {
            TaskExecuting?.Invoke(this, "Registering MesaSuite...");
            try
            {
                RegistryKey mesasuiteKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\MesaSuite", true);
                mesasuiteKey.SetValue("DisplayName", "MesaSuite");
                mesasuiteKey.SetValue("ApplicationVersion", StartupArguments.VersionToDownload);
                mesasuiteKey.SetValue("Publisher", "Clussman Productions");
                mesasuiteKey.SetValue("DisplayIcon", Path.Combine(InstallationConfiguration.InstallDirectory, "MesaSuite.exe"));
                mesasuiteKey.SetValue("DisplayVersion", StartupArguments.VersionToDownload);
                mesasuiteKey.SetValue("URLInfoAbout", "https://www.mesabrook.com/mcsync/index.html");
                mesasuiteKey.SetValue("Contact", "cnwaj@hotmail.com");
                mesasuiteKey.SetValue("InstallDate", DateTime.Now.ToString("yyyyMMdd"));
                mesasuiteKey.SetValue("UninstallString", Path.Combine(InstallationConfiguration.InstallDirectory, "Updater.exe") + " -uninstallquiet");
                mesasuiteKey.SetValue("DesktopIcon", InstallationConfiguration.MakeDesktopIcon);
                mesasuiteKey.SetValue("StartMenuIcon", InstallationConfiguration.MakeStartMenuIcon);
                mesasuiteKey.Close();
            }
            catch(Exception ex)
            {
                _errors.Add("Failed to register MesaSuite in system registry:\r\n" + ex.ToString());
                UpdateFailed?.Invoke(this, new EventArgs());
                return false;
            }

            return true;
        }

        private bool AddIcons()
        {
            TaskExecuting?.Invoke(this, "Creating icons...");
            if (InstallationConfiguration.MakeDesktopIcon)
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "MesaSuite.lnk"));
                shortcut.Description = "Launches MesaSuite";
                shortcut.IconLocation = Path.Combine(InstallationConfiguration.InstallDirectory, "icon.ico");
                shortcut.TargetPath = Path.Combine(InstallationConfiguration.InstallDirectory, "MesaSuite.exe");
                shortcut.WorkingDirectory = InstallationConfiguration.InstallDirectory;
                shortcut.Save();
            }

            if (InstallationConfiguration.MakeStartMenuIcon)
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu), "Programs", "MesaSuite.lnk"));
                shortcut.Description = "Launches MesaSuite";
                shortcut.IconLocation = Path.Combine(InstallationConfiguration.InstallDirectory, "icon.ico");
                shortcut.TargetPath = Path.Combine(InstallationConfiguration.InstallDirectory, "MesaSuite.exe");
                shortcut.WorkingDirectory = InstallationConfiguration.InstallDirectory;
                shortcut.Save();
            }

            return true;
        }
    }
}
