using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public class SetMCSyncPathStep : Step
    {
        public SetMCSyncPathStep() : base()
        {
            PreviousAvailable = true;
        }

        public override IStepUserControl StepUserControl => new SetMCSyncPathStepControl()
        {
            Step = this
        };

        protected override Bitmap GetInitialBanner()
        {
            return Properties.Resources.bannerGreen;
        }
    }
}
