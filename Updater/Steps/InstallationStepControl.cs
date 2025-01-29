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
    public partial class InstallationStepControl : UserControl, IStepUserControl
    {
        public InstallationStepControl()
        {
            InitializeComponent();
        }

        public void UpdateStatus(string text, bool incrementProgress = false)
        {
            ExecuteAction(() =>
            {
                lblStatus.Text = text;
                if (incrementProgress)
                {
                    prgProgress.Increment(1);
                }
            });
        }

        public void SetSteps(int steps)
        {
            ExecuteAction(() => prgProgress.Maximum = steps);
        }

        private void ExecuteAction(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        public Step Step { get; set; }

        private void InstallationStepControl_Load(object sender, EventArgs e)
        {
            chkPlayMusic.Checked = Step.InstallationConfiguration.PlayInstallMusic;
        }

        private void chkPlayMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (Program.installMusic != null)
            {
                Program.installMusic.Stop();
                Program.installMusic.Dispose();
                Program.installMusic = null;
            }

            if (chkPlayMusic.Checked)
            {
                Program.installMusic = new System.Media.SoundPlayer(Properties.Resources.music);
                Program.installMusic.PlayLooping();
            }
        }
    }
}
