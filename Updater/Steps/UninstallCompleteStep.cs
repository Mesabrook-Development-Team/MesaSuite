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
    public class UninstallCompleteStep : Step
    {
        public UninstallCompleteStep() : base()
        {
            PreviousAvailable = false;
            CancelAvailable = false;
            NextText = "Close";
        }

        public override IStepUserControl StepUserControl => new UninstallCompleteStepControl()
        {
            Step = this
        };

        protected override Bitmap GetInitialBanner()
        {
            return Properties.Resources.bannerGreen;
        }
    }
}
