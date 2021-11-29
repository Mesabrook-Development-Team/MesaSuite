using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public partial class PreviewStepControl : UserControl, IStepUserControl
    {
        public PreviewStepControl()
        {
            InitializeComponent();
        }

        public Step Step { get; set; }

        private void PreviewStepControl_Load(object sender, EventArgs e)
        {
            txtDirectory.Text = Step.InstallationConfiguration.InstallDirectory;
            chkDesktop.Checked = Step.InstallationConfiguration.MakeDesktopIcon;
            chkStartMenu.Checked = Step.InstallationConfiguration.MakeStartMenuIcon;
        }
    }
}
