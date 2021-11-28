using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public class InstallationCompleteStep : Step
    {
        InstallationCompleteStepControl ui;
        public InstallationCompleteStep() : base()
        {
            PreviousAvailable = false;
            CancelAvailable = false;
            NextText = "Close";
            ui = new InstallationCompleteStepControl()
            {
                Step = this
            };
        }

        public override IStepUserControl StepUserControl => ui;

        protected override Bitmap GetInitialBanner()
        {
            return Properties.Resources.bannerGreen;
        }
        public async override Task<bool> NextClicked()
        {
            if (ui.LaunchMesaSuiteOnClose)
            {
                Process.Start(Path.Combine(InstallationConfiguration.InstallDirectory, "MesaSuite.exe"));
            }
            return true;
        }
    }
}
