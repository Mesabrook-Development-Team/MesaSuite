using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public class UninstallStep : Step
    {
        private Uninstaller _uninstaller;
        private UninstallStepControl ui;
        private List<string> _errors = new List<string>();
        public IReadOnlyCollection<string> Errors => _errors;
        public UninstallStep() : base()
        {
            PreviousAvailable = false;
            NextAvailable = false;
            CancelAvailable = false;
            ui = new UninstallStepControl() { Step = this };
        }

        public override IStepUserControl StepUserControl => ui;

        protected override Bitmap GetInitialBanner()
        {
            return Properties.Resources.bannerGreen;
        }

        public async override Task<bool> LoadAndAutoComplete()
        {
            _uninstaller = new Uninstaller();
            _uninstaller.InstallationConfiguration = InstallationConfiguration;
            _uninstaller.NumberOfTasks += Uninstaller_NumberOfTasks;
            _uninstaller.TaskExecuting += Uninstaller_TaskExecuting;
            _uninstaller.NonTaskExecuting += Uninstaller_NonTaskExecuting;
            _uninstaller.UninstallSucceeded += Uninstaller_UninstallSucceeded;
            _uninstaller.UninstallFailed += Uninstaller_UninstallFailed;

            _uninstaller.Uninstall();

            return false;
        }

        private void Uninstaller_UninstallFailed(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            _errors = new List<string>(_uninstaller.Errors);
            CompleteStep();
        }

        private void Uninstaller_UninstallSucceeded(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            CompleteStep();
        }

        private void UnsubscribeEvents()
        {
            _uninstaller.NumberOfTasks -= Uninstaller_NumberOfTasks;
            _uninstaller.TaskExecuting -= Uninstaller_TaskExecuting;
            _uninstaller.NonTaskExecuting -= Uninstaller_NonTaskExecuting;
            _uninstaller.UninstallSucceeded -= Uninstaller_UninstallSucceeded;
            _uninstaller.UninstallFailed -= Uninstaller_UninstallFailed;
        }

        private void Uninstaller_NonTaskExecuting(object sender, string e)
        {
            ui.UpdateStatus(e);
        }

        private void Uninstaller_TaskExecuting(object sender, string e)
        {
            ui.UpdateStatus(e, true);
        }

        private void Uninstaller_NumberOfTasks(object sender, int e)
        {
            ui.SetSteps(e);
        }
    }
}
