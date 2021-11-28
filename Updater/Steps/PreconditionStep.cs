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
                RegistryKey rootUninstallKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                if (!rootUninstallKey.GetSubKeyNames().Contains("MesaSuite"))
                {
                    return;
                }

                RegistryKey mesaSuiteUninstallKey = rootUninstallKey.OpenSubKey("MesaSuite");
                if (!mesaSuiteUninstallKey.GetValueNames().Contains("UninstallString"))
                {
                    return;
                }

                string uninstallString = mesaSuiteUninstallKey.GetValue("UninstallString", "") as string;
                InstallationConfiguration.InstallDirectory = Path.GetFullPath(uninstallString);
            });

            if (string.IsNullOrEmpty(StartupArguments.VersionToDownload))
            {
                //HttpWebRequest webRequest = WebRequest.CreateHttp("https://mcsync.api.mesabrook.com/Version/GetLatest");
                HttpWebRequest webRequest = WebRequest.CreateHttp("http://localhost:23895/Version/GetLatest");
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
