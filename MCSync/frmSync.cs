using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.Windows.Forms;

namespace MCSync
{
    public partial class frmSync : Form
    {
        private Dictionary<Task, DataGridViewRow> rowsByTask = new Dictionary<Task, DataGridViewRow>();
        
        public frmSync()
        {
            InitializeComponent();
        }

        private void frmSync_Load(object sender, EventArgs e)
        {
            Syncer syncer = new Syncer();
            syncer.TaskAdded += Syncer_TaskAdded;
            syncer.SyncComplete += Syncer_SyncComplete;

            syncer.BeginSync();
        }

        private void Syncer_SyncComplete(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                foreach(string error in Task.Errors)
                {
                    MessageBox.Show("An error occurred during sync: \n\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
                }

                foreach(string info in Task.Informations)
                {
                    MessageBox.Show(info, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                }

                MessageBox.Show("Sync complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pbarOverall.Value = pbarOverall.Maximum;
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                Application.ExitThread();
            });
        }

        private void Syncer_TaskAdded(object sender, Task e)
        {
            Invoke((MethodInvoker)delegate
            {
                int index = dgvTasks.Rows.Add();
                DataGridViewRow row = dgvTasks.Rows[index];

                row.Cells[0].Value = e.TaskDescription;
                row.Cells[1].Value = e.Status;

                rowsByTask[e] = row;

                e.StatusUpdate += Task_StatusUpdate;
                pbarOverall.Maximum = dgvTasks.Rows.Count;
                TaskbarManager.Instance.SetProgressValue(dgvTasks.Rows.Count, pbarOverall.Maximum);
            });
        }

        private void Task_StatusUpdate(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                Task task = (Task)sender;
                DataGridViewRow row = rowsByTask[task];

                row.Cells[1].Value = task.Status;
                richTextBox1.Text = "Current Task: \n" + task.TaskDescription;

                pbarOverall.Value = dgvTasks.Rows.OfType<DataGridViewRow>().Where(dgvr => !string.Equals("Waiting", dgvr.Cells[1].Value as string, StringComparison.OrdinalIgnoreCase)).Count();
                TaskbarManager.Instance.SetProgressValue(pbarOverall.Value, pbarOverall.Maximum);
            });
        }

        private void frmSync_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(btnDetails.Text.Contains("Show"))
            {
                Size = new System.Drawing.Size(644, 525);
                btnDetails.Text = "Hide Details";
            }
            else
            {
                Size = new System.Drawing.Size(644, 162);
                btnDetails.Text = "Show Details";
            }
        }
    }
}
