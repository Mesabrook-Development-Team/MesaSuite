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

        private void PreconditionStepControl_Load(object sender, System.EventArgs e)
        {
            lblHeader.Text = Program.InternalEdition ?
                "Welcome to the MesaSuite Internal Edition Installer!" :
                "Welcome to the MesaSuite Installer!";
        }
    }
}
