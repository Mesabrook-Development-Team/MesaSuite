using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Updater.Steps;
using Updater.UpdateWorkflow;

namespace Updater
{
    public partial class frmPrompts : Form
    {
        Workflow workflow;
        // ==================== STEP SETUP
        private void SetupWorkflowSteps()
        {
            PreconditionStep preconditionStep = new PreconditionStep();
            InstallationDirectoryStep installationDirectory = new InstallationDirectoryStep();
            workflow.ConnectSteps(preconditionStep, installationDirectory);

            AdditionalOptionsStep additionalOptions = new AdditionalOptionsStep();
            workflow.ConnectSteps(installationDirectory, additionalOptions);

            // Setup starter step
            workflow.StarterStep = preconditionStep;
        }
        // ==================== END STEP SETUP

        public frmPrompts()
        {
            InitializeComponent();
        }

        private void frmPrompts_Load(object sender, EventArgs e)
        {
            workflow = new Workflow();
            SetupWorkflowSteps();
            workflow.StartWorkflow(new Workflow.ScreenElements()
            {
                Banner = picBanner,
                CancelButton = cmdCancel,
                NextButton = cmdNext,
                PreviousButton = cmdBack,
                UserControlPanel = panelControl
            });
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            workflow.NextClicked();
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            workflow.PreviousClicked();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            workflow.CancelClicked();
        }
    }
}
