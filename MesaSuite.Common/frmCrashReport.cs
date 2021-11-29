using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using MesaSuite.Common.Data;

namespace MesaSuite.Common
{
    public partial class frmCrashReport : Form
    {
        public frmCrashReport()
        {
            InitializeComponent();
        }

        private void cmdRestart_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void frmCrashReport_Load(object sender, EventArgs e)
        {
            PostData post = new PostData(DataAccess.APIs.SystemManagement, "Crash/Report");
            post.ObjectToPost = new
            {
                program = lblProgram.Text,
                exception = txtException.Text,
            };
            await post.ExecuteNoResult();

            lblProgram.Text = lblProgram.Text + " has crashed!";
            this.Text = lblProgram.Text;
            lblStatus.Text = "The MesaSuite development team has automatically been notified.";
        }

        private void lnkLblGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/CSX8600/MCSync/issues");
        }
    }
}
