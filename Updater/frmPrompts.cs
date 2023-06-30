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
            workflow.ConnectSteps(preconditionStep, installationDirectory, () => !StartupArguments.Uninstall && !StartupArguments.UninstallQuietly);

            TermsOfServiceStep termsOfServiceStep = new TermsOfServiceStep();
            workflow.ConnectSteps(installationDirectory, termsOfServiceStep);

            AdditionalOptionsStep additionalOptions = new AdditionalOptionsStep();
            workflow.ConnectSteps(termsOfServiceStep, additionalOptions);

            PreviewStep preview = new PreviewStep();
            workflow.ConnectSteps(additionalOptions, preview);

            InstallationStep install = new InstallationStep();
            workflow.ConnectSteps(preview, install);

            InstallationCompleteStep complete = new InstallationCompleteStep();
            workflow.ConnectSteps(install, complete, () => !install.InstallationErrors.Any());

            InstallationFailedStep failed = new InstallationFailedStep(() => install.InstallationErrors);
            workflow.ConnectSteps(install, failed, () => install.InstallationErrors.Any());

            // Uninstaller
            UninstallConfirmStep uninstallConfirmStep = new UninstallConfirmStep();
            workflow.ConnectSteps(preconditionStep, uninstallConfirmStep, () => StartupArguments.Uninstall);

            UninstallStep uninstallStep = new UninstallStep();
            workflow.ConnectSteps(uninstallConfirmStep, uninstallStep);
            workflow.ConnectSteps(preconditionStep, uninstallStep, () => StartupArguments.UninstallQuietly);

            InstallationFailedStep uninstallFailedstep = new InstallationFailedStep(() => uninstallStep.Errors);
            workflow.ConnectSteps(uninstallStep, uninstallFailedstep, () => uninstallStep.Errors.Any());

            UninstallCompleteStep uninstallCompleteStep = new UninstallCompleteStep();
            workflow.ConnectSteps(uninstallStep, uninstallCompleteStep, () => !uninstallStep.Errors.Any());

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
