using System;
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
                exception = txtException.Text
            };
            await post.ExecuteNoResult();

            lblStatus.Text = "has crashed.  The MesaSuite development team has automatically been notified.";
        }
    }
}
