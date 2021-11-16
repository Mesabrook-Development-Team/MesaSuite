using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MesaSuite.Common.Data;
using SystemManagement.Models;

namespace SystemManagement
{
    public partial class frmCrashReport : Form
    {
        public long CrashReportID { get; set; }
        public frmCrashReport()
        {
            InitializeComponent();
        }

        private async void frmCrashReport_Load(object sender, EventArgs e)
        {
            Enabled = false;

            GetData get = new GetData(DataAccess.APIs.SystemManagement, "Crash/Get");
            get.QueryString.Add("id", CrashReportID.ToString());

            CrashReport crashReport = await get.GetObject<CrashReport>();
            txtProgram.Text = crashReport.Program;
            txtTime.Text = crashReport.Time.ToString("MM/dd/yyyy HH:mm:ss");
            txtUser.Text = crashReport.User;
            txtException.Text = crashReport.Exception;

            Enabled = true;
            BringToFront();
        }

        private async void cmdDelete_Click(object sender, EventArgs e)
        {
            Enabled = false;

            DeleteData delete = new DeleteData(DataAccess.APIs.SystemManagement, "Crash/Delete");
            delete.QueryString.Add("id", CrashReportID.ToString());
            await delete.Execute();

            if (delete.RequestSuccessful)
            {
                Close();
            }

            Enabled = true;
            BringToFront();
        }
    }
}
