using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater.UpdateWorkflow
{
    public sealed class Workflow
    {
        private ScreenElements _screenElements;
        private InstallationConfiguration _installationConfiguration;
        private Dictionary<Step, List<Connection>> StepConnections { get; set; } = new Dictionary<Step, List<Connection>>();
        private Stack<Step> StepHistory = new Stack<Step>();

        public Step StarterStep { get; set; }
        private Step CurrentStep { get; set; }

        public async void NextClicked()
        {
            if (await CurrentStep.NextClicked())
            {
                LoadNextStep();
                ProcessStep();
            }
        }

        public async void PreviousClicked()
        {
            if (await CurrentStep.PreviousClicked())
            {
                LoadPreviousStep();
                ProcessStep();
            }
        }

        public void CancelClicked()
        {
            if (MessageBox.Show("Are you sure you want to cancel the installation of MesaSuite?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            CurrentStep.CancelClicked();
            Application.Exit();
        }

        public void StartWorkflow(ScreenElements screenElements)
        {
            _screenElements = screenElements;
            _installationConfiguration = new InstallationConfiguration();

            CurrentStep = StarterStep;

            ProcessStep();
        }

        private async void ProcessStep()
        {
            if (CurrentStep == null)
            {
                return;
            }

            CurrentStep.InstallationConfiguration = _installationConfiguration;

            Control userControl = (Control)CurrentStep.StepUserControl;
            _screenElements.UserControlPanel.Controls.Clear();
            _screenElements.UserControlPanel.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;

            _screenElements.Banner.Image = CurrentStep.Banner;
            _screenElements.NextButton.Enabled = CurrentStep.NextAvailable;
            _screenElements.PreviousButton.Enabled = CurrentStep.PreviousAvailable;
            _screenElements.CancelButton.Enabled = CurrentStep.CancelAvailable;

            CurrentStep.BannerChanged += CurrentStep_BannerChanged;
            CurrentStep.CancelAvailableChanged += CurrentStep_CancelAvailableChanged;
            CurrentStep.NextAvailableChanged += CurrentStep_NextAvailableChanged;
            CurrentStep.PreviousAvailableChanged += CurrentStep_PreviousAvailableChanged;

            if (await CurrentStep.LoadAndAutoComplete())
            {
                LoadNextStep();
                ProcessStep();
                return;
            }
        }

        private void CurrentStep_PreviousAvailableChanged(object sender, EventArgs e)
        {
            _screenElements.PreviousButton.Enabled = CurrentStep.PreviousAvailable;
        }

        private void CurrentStep_NextAvailableChanged(object sender, EventArgs e)
        {
            _screenElements.NextButton.Enabled = CurrentStep.NextAvailable;
        }

        private void CurrentStep_CancelAvailableChanged(object sender, EventArgs e)
        {
            _screenElements.CancelButton.Enabled = CurrentStep.CancelAvailable;
        }

        private void CurrentStep_BannerChanged(object sender, EventArgs e)
        {
            _screenElements.Banner.Image = CurrentStep.Banner;
        }

        private void LoadNextStep()
        {
            StepHistory.Push(CurrentStep);
            UnsubscribeCurrentStep();

            if (!StepConnections.ContainsKey(CurrentStep))
            {
                CurrentStep = null;
                Application.Exit();
            }
            else
            {
                foreach (Connection connection in StepConnections[CurrentStep])
                {
                    if (connection.ConnectionCondition())
                    {
                        CurrentStep = connection.NextStep;
                        return;
                    }
                }

                CurrentStep = null;
                Application.Exit();
            }
        }

        private void UnsubscribeCurrentStep()
        {
            CurrentStep.PreviousAvailableChanged -= CurrentStep_PreviousAvailableChanged;
            CurrentStep.NextAvailableChanged -= CurrentStep_NextAvailableChanged;
            CurrentStep.CancelAvailableChanged -= CurrentStep_CancelAvailableChanged;
            CurrentStep.BannerChanged -= CurrentStep_BannerChanged;
        }

        private void LoadPreviousStep()
        {
            UnsubscribeCurrentStep();
            do
            {
                CurrentStep = StepHistory.Pop();
            }
            while (!CurrentStep.IsPreviousStop);
        }

        public void ConnectSteps(Step originStep, Step nextStep, Func<bool> condition = null)
        {
            if (!StepConnections.ContainsKey(originStep))
            {
                StepConnections[originStep] = new List<Connection>();
            }
            StepConnections[originStep].Add(new Connection(nextStep, condition ?? (() => true)));
        }

        private class Connection
        {
            public Step NextStep { get; set; }
            public Func<bool> ConnectionCondition { get; set; }

            public Connection(Step nextStep, Func<bool> connectionCondition)
            {
                NextStep = nextStep;
                ConnectionCondition = connectionCondition;
            }
        }

        public class ScreenElements
        {
            public Button NextButton { get; set; }
            public Button PreviousButton { get; set; }
            public Button CancelButton { get; set; }
            public Panel UserControlPanel { get; set; }
            public PictureBox Banner { get; set; }
        }
    }
}
