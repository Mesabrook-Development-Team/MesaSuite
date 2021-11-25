using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public class InstallationFailedStep : Step
    {
        Func<IReadOnlyCollection<string>> _getErrorsCallback;
        public InstallationFailedStep(Func<IReadOnlyCollection<string>> getErrorsCallback) : base()
        {
            PreviousAvailable = false;
            CancelAvailable = false;
            NextText = "Close";

            _getErrorsCallback = getErrorsCallback;
        }

        public override IStepUserControl StepUserControl => new InstallationFailedStepControl()
        {
            Step = this,
            Errors = _getErrorsCallback()
        };

        protected override Bitmap GetInitialBanner()
        {
            return Properties.Resources.Image1;
        }
    }
}
