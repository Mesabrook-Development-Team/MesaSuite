using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public class PreconditionStep : Step
    {
        public PreconditionStep() : base()
        {
            NextAvailable = false;
            PreviousAvailable = false;
            CancelAvailable = false;
        }

        public override IStepUserControl StepUserControl => new PreconditionStepControl()
        {
            Step = this
        };

        public async override Task<bool> LoadAndAutoComplete()
        {
            await Task.Run(() =>
            {
                string subKey = Program.InternalEdition ? "MesaSuiteInternalEdition" : "MesaSuite";
                RegistryKey rootUninstallKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                if (!rootUninstallKey.GetSubKeyNames().Contains(subKey))
                {
                    return;
                }

                RegistryKey mesaSuiteUninstallKey = rootUninstallKey.OpenSubKey(subKey);
                if (!mesaSuiteUninstallKey.GetValueNames().Contains("UninstallString"))
                {
                    return;
                }

                string uninstallString = mesaSuiteUninstallKey.GetValue("UninstallString", "") as string;
                try
                {
                    InstallationConfiguration.InstallDirectory = Path.GetDirectoryName(uninstallString);
                }
                catch
                {
                    string executablePath;
                    if (uninstallString.StartsWith("\""))
                    {
                        // Extract the quoted path
                        int closingQuoteIndex = uninstallString.IndexOf('"', 1);
                        executablePath = uninstallString.Substring(1, closingQuoteIndex - 1);
                    }
                    else
                    {
                        // Extract up to the first space (for unquoted paths)
                        int spaceIndex = uninstallString.IndexOf(' ');
                        executablePath = (spaceIndex > 0) ? uninstallString.Substring(0, spaceIndex) : uninstallString;
                    }

                    InstallationConfiguration.InstallDirectory = Path.GetDirectoryName(executablePath);
                }

                InstallationConfiguration.MakeDesktopIcon = bool.Parse((mesaSuiteUninstallKey.GetValue("DesktopIcon") as string) ?? "false");
                InstallationConfiguration.MakeStartMenuIcon = bool.Parse((mesaSuiteUninstallKey.GetValue("StartMenuIcon") as string) ?? "false");
            });

            if (string.IsNullOrEmpty(StartupArguments.VersionToDownload))
            {
                string apiPrefix = Program.InternalEdition ? "internalapi" : "api";
                HttpWebRequest webRequest = WebRequest.CreateHttp($"http://{apiPrefix}.mesabrook.com/mcsync/Version/GetLatest");
                //HttpWebRequest webRequest = WebRequest.CreateHttp("http://localhost:23895/Version/GetLatest");
                webRequest.Method = WebRequestMethods.Http.Get;
                HttpWebResponse response;
                try
                {
                    response = (HttpWebResponse)await webRequest.GetResponseAsync();
                }
                catch { return true; }

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    StartupArguments.VersionToDownload = reader.ReadLine();
                }

                StartupArguments.VersionToDownload = StartupArguments.VersionToDownload.Replace("\"", "");
            }

            return true;
        }

        public override bool IsPreviousStop => false;

        protected override Bitmap GetInitialBanner()
        {
            return Properties.Resources.bannerGreen;
        }
    }
}
