using System.Windows.Forms;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public partial class PreconditionStepControl : UserControl, IStepUserControl
    {
        public PreconditionStepControl()
        {
            InitializeComponent();
        }

        public Step Step { get; set; }
    }
}
