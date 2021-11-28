using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public class AdditionalOptionsStep : Step
    {
        public override IStepUserControl StepUserControl => new AdditionalOptionsStepControl()
        {
            Step = this
        };

        protected override Bitmap GetInitialBanner()
        {
            return Properties.Resources.bannerGreen;
        }
    }
}
