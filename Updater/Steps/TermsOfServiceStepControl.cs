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
    public partial class TermsOfServiceStepControl : UserControl, IStepUserControl
    {
        public TermsOfServiceStepControl()
        {
            InitializeComponent();
        }

        public Step Step { get; set; }

        private void TermsOfServiceStepControl_Load(object sender, EventArgs e)
        {

        }

        private void chkBoxAccept_CheckedChanged(object sender, EventArgs e)
        {
            Step.InstallationConfiguration.AcceptedToS = chkBoxAccept.Checked;
        }
    }
}
