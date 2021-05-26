using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCSync
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void cmdBrowseMods_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select Mods folder";
            dialog.SelectedPath = txtModsDirectory.Text;
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtModsDirectory.Text = dialog.SelectedPath;
        }

        private void cmdBrowseResourcePacks_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select Resource Packs folder";
            dialog.SelectedPath = txtResourcePacksDirectory.Text;
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtResourcePacksDirectory.Text = dialog.SelectedPath;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Config config = new Config();
            config.ModsDirectory = txtModsDirectory.Text;
            config.ResourcePackDirectory = txtResourcePacksDirectory.Text;
            config.ConfigFilesDirectory = txtConfigDirectory.Text;

            if (rbClient.Checked)
            {
                config.Mode = Config.Modes.Client;
            }
            else if (rbServer.Checked)
            {
                config.Mode = Config.Modes.Server;
            }

            Config.SaveConfiguration(config);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            Config config = Config.LoadConfiguration();
            txtModsDirectory.Text = config.ModsDirectory;
            txtResourcePacksDirectory.Text = config.ResourcePackDirectory;
            txtConfigDirectory.Text = config.ConfigFilesDirectory;
            rbClient.Checked = config.Mode == Config.Modes.Client;
            rbServer.Checked = config.Mode == Config.Modes.Server;
        }

        private void cmdBrowseConfig_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select Config folder";
            dialog.SelectedPath = txtConfigDirectory.Text;
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtConfigDirectory.Text = dialog.SelectedPath;
        }
    }
}