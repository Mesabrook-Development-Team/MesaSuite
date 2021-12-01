using System;
using System.Collections.Generic;
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
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                foreach(string info in Task.Informations)
                {
                    MessageBox.Show(info, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                MessageBox.Show("Sync complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            });
        }

        private void Task_StatusUpdate(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                Task task = (Task)sender;
                DataGridViewRow row = rowsByTask[task];

                row.Cells[1].Value = task.Status;
            });
        }

        private void frmSync_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
