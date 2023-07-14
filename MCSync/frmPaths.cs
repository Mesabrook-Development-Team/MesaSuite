using MesaSuite.Common.Extensions;
using MesaSuite.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MCSync.Syncer;
using WK.Libraries.BetterFolderBrowserNS;
using System.Diagnostics;

namespace MCSync
{
    public partial class frmPaths : Form
    {
        public frmPaths()
        {
            InitializeComponent();
        }

        private void frmPaths_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            Dock = DockStyle.Fill;
            BringToFront();

            Dictionary<string, object> configValues = UserPreferences.Get().Sections.GetOrSetDefault("mcsync", () => new Dictionary<string, object>());
            txtMinecraftFolder.Text = configValues.GetOrSetDefault("minecraftDirectory", string.Empty).Cast<string>();
        }

        private void fButtonSave_Click(object sender, EventArgs e)
        {
            UserPreferences userPreferences = UserPreferences.Get();
            Dictionary<string, object> configValues = userPreferences.Sections.GetOrSetDefault("mcsync", new Dictionary<string, object>());

            configValues["modsDirectory"] = txtMinecraftFolder.Text + "\\mods";
            configValues["resourcePackDirectory"] = txtMinecraftFolder.Text + "\\resourcepacks";
            configValues["configFilesDirectory"] = txtMinecraftFolder.Text + "\\config";
            configValues["oResourcesDirectory"] = txtMinecraftFolder.Text + "\\oresources";
            configValues["animationDirectory"] = txtMinecraftFolder.Text + "\\config\\customloadingscreen";
            configValues["signPacksDirectory"] = txtMinecraftFolder.Text + "\\tc_signpacks";
            userPreferences.Save();

            DialogResult = DialogResult.OK;
            Opacity = 0;
            Close();
        }

        private void cmdMinecraftFolder_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser browser = new BetterFolderBrowser();
            browser.Title = "Select .minecraft folder";
            browser.Multiselect = false;
            browser.RootFolder = txtMinecraftFolder.Text;
            if (browser.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtMinecraftFolder.Text = browser.SelectedPath;
        }

        private void fButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void fButtonExplorer_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    Arguments = "%APPDATA%",
                    FileName = "explorer.exe"
                };
                Process.Start(psi);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in Operation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
