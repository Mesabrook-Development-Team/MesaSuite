using System;
using System.Windows.Forms;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public partial class AdditionalOptionsStepControl : UserControl, IStepUserControl
    {
        public AdditionalOptionsStepControl()
        {
            InitializeComponent();
        }

        public Step Step { get; set; }

        private void AdditionalOptionsStepControl_Load(object sender, EventArgs e)
        {
            chkDesktop.Checked = Step.InstallationConfiguration.MakeDesktopIcon;
            chkStartMenu.Checked = Step.InstallationConfiguration.MakeStartMenuIcon;
            chkInstallMusic.Checked = Step.InstallationConfiguration.PlayInstallMusic;

            Step.InstallationConfiguration.AcceptedToS = false;
        }

        private void chkDesktop_CheckedChanged(object sender, EventArgs e)
        {
            Step.InstallationConfiguration.MakeDesktopIcon = chkDesktop.Checked;
        }

        private void chkStartMenu_CheckedChanged(object sender, EventArgs e)
        {
            Step.InstallationConfiguration.MakeStartMenuIcon = chkStartMenu.Checked;
        }

        private void chkInstallMusic_CheckedChanged(object sender, EventArgs e)
        {
            Step.InstallationConfiguration.PlayInstallMusic = chkInstallMusic.Checked;
        }
    }
}
