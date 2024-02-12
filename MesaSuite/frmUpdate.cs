using MesaSuite.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite
{
    public partial class frmUpdate : Form
    {
        private List<Updater.MCSyncVersion> _updates;
        public frmUpdate()
        {
            InitializeComponent();
        }

        public List<Updater.MCSyncVersion> UpdaterResults
        {
            set
            {
                _updates = value;
            }
        }

        private void frmUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            if (GlobalSettings.InternalEditionMode)
            {
                Text += " (INTERNAL EDITION)";
            }

            PlayExclamation();
            StringBuilder sb = new StringBuilder();

            foreach (Updater.MCSyncVersion version in _updates)
            {
                sb.AppendLine("Version: " + version.VersionString.ToString());
                sb.AppendLine("Released: " + version.Valid.ToString("MM/dd/yyyy HH:mm"));
                sb.AppendLine("");
                sb.AppendLine("Release Notes:");
                sb.AppendLine(version.ReleaseNotes);
                sb.AppendLine("-------------------------------");
            }

            rtbUpdate.Text = sb.ToString();
        }

        public void PlayExclamation()
        {
            SystemSounds.Exclamation.Play();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Updater.DownloadAndStartUpdate(_updates.First().VersionString);
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("You have to update MCSync before you can use it. Are you sure you wish to quit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
