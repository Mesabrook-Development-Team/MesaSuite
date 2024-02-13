using System;
using System.Windows.Forms;
using Updater.UpdateWorkflow;
using WK.Libraries.BetterFolderBrowserNS;

namespace Updater.Steps
{
    public partial class InstallationDirectoryStepControl : UserControl, IStepUserControl
    {
        public InstallationDirectoryStepControl()
        {
            InitializeComponent();
        }

        public Step Step { get; set; }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser installLocationDialog = new BetterFolderBrowser
            {
                Title = "Select installation directory",
                RootFolder = Step.InstallationConfiguration.InstallDirectory
            };

            if (installLocationDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Step.InstallationConfiguration.InstallDirectory = installLocationDialog.SelectedPath;
            txtInstallDirectory.Text = installLocationDialog.SelectedPath;
        }

        private void txtInstallDirectory_TextChanged(object sender, EventArgs e)
        {
            Step.InstallationConfiguration.InstallDirectory = txtInstallDirectory.Text;
        }

        private void InstallationDirectoryStepControl_Load(object sender, EventArgs e)
        {
            lblHeader.Text = Program.InternalEdition ?
                "Welcome to the MesaSuite Internal Edition Installer!" :
                "Welcome to the MesaSuite Installer!";
            txtInstallDirectory.Text = Step.InstallationConfiguration.InstallDirectory;
        }
    }
}
