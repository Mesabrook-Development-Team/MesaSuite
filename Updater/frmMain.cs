using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            Updater updater = new Updater();

            updater.NumberOfTasks += Updater_NumberOfTasks;
            updater.TaskExecuting += Updater_TaskExecuting;
            updater.InvalidVersion += Updater_InvalidVersion;
            updater.NonTaskExecuting += Updater_NonTaskExecuting;

            await updater.BeginUpdate();
            Application.Exit();
        }

        private void Updater_NumberOfTasks(object sender, int e)
        {
            Invoke(new MethodInvoker(() =>
            {
                dlProgress.Maximum = e;
            }));
        }

        private void Updater_TaskExecuting(object sender, string e)
        {
            Invoke(new MethodInvoker(() =>
            {
                dlProgress.Value++;
                lblProgress.Text = e;
            }));
        }

        private void Updater_InvalidVersion(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                MessageBox.Show("Invalid Version Detected. Check the version number and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }));
        }

        private void Updater_NonTaskExecuting(object sender, string e)
        {
            Invoke(new MethodInvoker(() =>
            {
                lblProgress.Text = e;
            }));
        }
    }
}