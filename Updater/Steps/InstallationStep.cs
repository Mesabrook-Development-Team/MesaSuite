using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public class InstallationStep : Step
    {
        private List<string> _installationErrors = new List<string>();
        public IReadOnlyCollection<string> InstallationErrors => _installationErrors;

        InstallationStepControl ui;
        Updater updater;

        public InstallationStep() : base()
        {
            PreviousAvailable = false;
            NextAvailable = false;
            CancelAvailable = false;
            ui = new InstallationStepControl()
            {
                Step = this
            };
            updater = new Updater();
        }

        public override IStepUserControl StepUserControl => ui;

        protected override Bitmap GetInitialBanner()
        {
            return Properties.Resources.bannerGreen;
        }

        public async override Task<bool> LoadAndAutoComplete()
        {
            if (Program.installMusic != null)
            {
                Program.installMusic.Dispose();
            }

            Program.installMusic = new System.Media.SoundPlayer(Properties.Resources.music);
            Program.installMusic.PlayLooping();

            updater.InstallationConfiguration = InstallationConfiguration;
            updater.NumberOfTasks += Updater_NumberOfTasks;
            updater.NonTaskExecuting += Updater_NonTaskExecuting;
            updater.TaskExecuting += Updater_TaskExecuting;
            updater.UpdateFailed += Updater_UpdateFailed;
            updater.UpdateSucceeded += Updater_UpdateSucceeded;

            updater.BeginUpdate();

            return false;
        }

        private void UnsubscribeUpdaterEvents()
        {
            updater.NumberOfTasks -= Updater_NumberOfTasks;
            updater.NonTaskExecuting -= Updater_NonTaskExecuting;
            updater.TaskExecuting -= Updater_TaskExecuting;
            updater.UpdateFailed -= Updater_UpdateFailed;
            updater.UpdateSucceeded -= Updater_UpdateSucceeded;
        }

        private void Updater_UpdateSucceeded(object sender, EventArgs e)
        {
            UnsubscribeUpdaterEvents();
            CompleteStep();
        }

        private void Updater_UpdateFailed(object sender, EventArgs e)
        {
            UnsubscribeUpdaterEvents();
            _installationErrors = new List<string>(updater.Errors);
            CompleteStep();
        }

        private void Updater_TaskExecuting(object sender, string e)
        {
            ui.UpdateStatus(e, true);
        }

        private void Updater_NonTaskExecuting(object sender, string e)
        {
            ui.UpdateStatus(e);
        }

        private void Updater_NumberOfTasks(object sender, int e)
        {
            ui.SetSteps(e);
        }
    }
}
