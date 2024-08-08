using MesaSuite.Common.Collections;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite.Common.Wizard
{
    public abstract class WizardController<TData> where TData : class, new()
    {
        protected event EventHandler WizardStarting;

        private IWizardShell _shell;
        private MultiMap<IWizardStep<TData>, StepConnection> _connections = new MultiMap<IWizardStep<TData>, StepConnection>();
        private IWizardStep<TData> _currentStep;
        private TData _data;
        private Dictionary<IWizardStep<TData>, ListViewItem> _listViewItemsByStep = new Dictionary<IWizardStep<TData>, ListViewItem>();
        private Stack<IWizardStep<TData>> _breadcrumbs = new Stack<IWizardStep<TData>>();

        protected abstract string WindowTitle { get; }
        protected abstract Image Logo { get; }
        protected abstract string ScreenTitle { get; }
        protected abstract string RunButtonCaption { get; }
        protected virtual bool UseNavigation { get; } = true;
        protected virtual Type WizardShellType { get; } = typeof(frmWizardShell);
        
        public class StepConnection
        {
            public IWizardStep<TData> NextStep { get; set; }
            public Func<TData, bool> Condition { get; set; } = (_) => true;

            public StepConnection(IWizardStep<TData> nextStep)
            {
                NextStep = nextStep;
            }
        }

        protected abstract MultiMap<IWizardStep<TData>, StepConnection> GetConnections();
        protected abstract Task WizardComplete(TData data);

        public void StartWizard()
        {
            if (!typeof(IWizardShell).IsAssignableFrom(WizardShellType))
            {
                throw new InvalidCastException("WizardShellType must implement IWizardShell");
            }

            _shell = (IWizardShell)Activator.CreateInstance(WizardShellType);

            _data = new TData();
            _connections = GetConnections();
            _shell.Navigation.Items.Clear();

            foreach(IWizardStep<TData> step in _connections.Keys)
            {
                if (step is EndStep<TData>)
                {
                    continue;
                }

                ListViewItem item = new ListViewItem();
                item.Tag = step;
                item.Text = step.NavigationName;
                item.ImageKey = "success";
                _listViewItemsByStep.Add(step, item);
                _shell.Navigation.Items.Add(item);

                if (step is IUsesWizardLoader usesLoader)
                {
                    usesLoader.ShowLoader = _shell.ShowLoader;
                    usesLoader.HideLoader = _shell.HideLoader;
                }
            }

            _shell.SetWindowText(WindowTitle);
            _shell.Logo.Image = Logo;
            _shell.Title.Text = ScreenTitle;
            _shell.RunButton.Text = RunButtonCaption;
            if (!UseNavigation)
            {
                _shell.Navigation.Visible = false;
                _shell.Content.Width = _shell.Content.Width + (_shell.Content.Left - _shell.Navigation.Left);
                _shell.Content.Location = new Point(_shell.Navigation.Left, _shell.Navigation.Top);
            }
            _shell.Navigation.SelectedIndexChanged += LstNav_SelectedIndexChanged;
            _shell.NextButton.Click += CmdNext_Click;
            _shell.BackButton.Click += CmdBack_Click;
            _shell.RunButton.Click += CmdRun_Click;
            _shell.CancelButton.Click += CmdCancel_Click;
            _shell.ShowWizard();

            DisplayStep(_connections.First().Key);
        }

        private async Task DisplayStep(IWizardStep<TData> step)
        {
            _shell.Content.Controls.Clear();

            _currentStep = step;
            suppressLstNavSelectedIndexChanged = true;
            foreach(ListViewItem item in _shell.Navigation.Items)
            {
                item.Selected = item.Tag == _currentStep;
            }
            suppressLstNavSelectedIndexChanged = false;

            await _currentStep.Load(_data);

            Control stepControl = _currentStep.Control;
            _shell.Content.Controls.Add(stepControl);
            stepControl.Dock = DockStyle.Fill;

            _shell.BackButton.Enabled = _connections.Keys.First() != _currentStep;
            _shell.NextButton.Enabled = _connections.Keys.Contains(_currentStep) && !(_connections[_currentStep].FirstOrDefault(sc => sc.Condition(_data))?.NextStep is EndStep<TData>);
        }

        bool suppressLstNavSelectedIndexChanged;
        private async void LstNav_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressLstNavSelectedIndexChanged || _shell.Navigation.SelectedItems.Count == 0)
            {
                return;
            }

            if (!await ValidateAndCommitCurrentStep())
            {
                return;
            }

            await DisplayStep((IWizardStep<TData>)_shell.Navigation.SelectedItems.OfType<ListViewItem>().First().Tag);
        }

        private async void CmdNext_Click(object sender, EventArgs e)
        {
            if (!await ValidateAndCommitCurrentStep())
            {
                return;
            }

            IWizardStep<TData> nextStep = _connections[_currentStep].First(sc => sc.Condition(_data)).NextStep;
            _breadcrumbs.Push(_currentStep);

            await DisplayStep(nextStep);
        }

        private async Task<bool> ValidateAndCommitCurrentStep()
        {
            List<string> errors = await _currentStep.Validate();
            if (errors != null && errors.Any())
            {
                _listViewItemsByStep[_currentStep].ImageKey = "error";
                _shell.Content.ShowError("The following errors occurred:\r\n" + String.Join("\r\n", errors));
                return false;
            }

            _listViewItemsByStep[_currentStep].ImageKey = "success";
            await _currentStep.Commit(_data);

            return true;
        }

        private async void CmdBack_Click(object sender, EventArgs e)
        {
            IWizardStep<TData> previousStep;
            if (_breadcrumbs.Count > 0)
            {
                previousStep = _breadcrumbs.Pop();
            }
            else
            {
                previousStep = _connections.Keys.First();
            }

            await DisplayStep(previousStep);
        }

        private async void CmdRun_Click(object sender, EventArgs e)
        {
            IWizardStep<TData> nextStep = _connections.Keys.First();
            bool hasErrors = false;
            while (nextStep != null && !(nextStep is EndStep<TData>))
            {
                List<string> errors = await nextStep.Validate();
                if (errors.Any())
                {
                    ListViewItem nextStepItem = _shell.Navigation.Items.OfType<ListViewItem>().FirstOrDefault(lvi => lvi.Tag == nextStep);
                    if (nextStepItem != null)
                    {
                        nextStepItem.ImageKey = "error";
                    }

                    _shell.Content.ShowError("The following errors occurred:\r\n" + String.Join("\r\n", errors));
                    hasErrors = true;
                }
                else
                {
                    await nextStep.Commit(_data);
                }

                nextStep = _connections[nextStep].FirstOrDefault(sc => sc.Condition(_data))?.NextStep;
            }

            if (!hasErrors)
            {
                _shell.ShowLoader();
                await WizardComplete(_data);
                _shell.CloseWizard();
            }
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            _shell.CloseWizard();
        }

        protected void ForceCloseWizard()
        {
            if (_shell.Content.InvokeRequired)
            {
                _shell.Content.Invoke(new MethodInvoker(() => _shell.CloseWizard()));
            }
            else
            {
                _shell.CloseWizard();
            }
        }
    }
}
