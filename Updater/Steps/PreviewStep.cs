using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public class PreviewStep : Step
    {
        public PreviewStep() : base()
        {
            NextText = "Install";
        }

        public override IStepUserControl StepUserControl => new PreviewStepControl()
        {
            Step = this
        };

        protected override Bitmap GetInitialBanner()
        {
            return Properties.Resources.Image1;
        }
    }
}
