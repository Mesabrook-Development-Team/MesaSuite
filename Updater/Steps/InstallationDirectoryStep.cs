using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public class InstallationDirectoryStep : Step
    {
        public InstallationDirectoryStep() : base()
        {
            PreviousAvailable = false;
        }

        public override IStepUserControl StepUserControl => new InstallationDirectoryStepControl()
        {
            Step = this
        };

        protected override Bitmap GetInitialBanner()
        {
            return Properties.Resources.Image1;
        }

        public async override Task<bool> NextClicked()
        {
            if (string.IsNullOrEmpty(InstallationConfiguration.InstallDirectory))
            {
                MessageBox.Show("Install Directory is a required field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
