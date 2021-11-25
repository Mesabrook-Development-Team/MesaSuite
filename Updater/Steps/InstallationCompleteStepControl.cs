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
    public partial class InstallationCompleteStepControl : UserControl, IStepUserControl
    {
        public InstallationCompleteStepControl()
        {
            InitializeComponent();
        }

        public Step Step { get; set; }

        public bool LaunchMesaSuiteOnClose => chkLaunch.Checked;
    }
}
