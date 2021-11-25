using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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

            return true;
        }

        public override bool IsPreviousStop => false;

        protected override Bitmap GetInitialBanner()
        {
            return Properties.Resources.Image1;
        }
    }
}
