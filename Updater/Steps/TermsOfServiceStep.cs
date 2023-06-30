using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public class TermsOfServiceStep : Step
    {
        public TermsOfServiceStep() : base() 
        {

        }

        public override IStepUserControl StepUserControl => new TermsOfServiceStepControl()
        {
            Step = this
        };

        protected override Bitmap GetInitialBanner()
        {
            return Properties.Resources.bannerGreen;
        }

        public async override Task<bool> NextClicked()
        {
            if (!InstallationConfiguration.AcceptedToS)
            {
                MessageBox.Show("You must accept the Terms of Service to proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
