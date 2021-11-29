using System.Drawing;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public class UninstallConfirmStep : Step
    {
        public UninstallConfirmStep() : base()
        {
            PreviousAvailable = false;
            NextText = "Uninstall";
        }

        public override IStepUserControl StepUserControl => new UninstallConfirmStepControl()
        {
            Step = this
        };

        protected override Bitmap GetInitialBanner()
        {
            return Properties.Resources.bannerGreen;
        }
    }
}
