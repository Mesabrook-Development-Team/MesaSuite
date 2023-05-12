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
            Dictionary<string, object> configValues = UserPreferences.Get().Sections.GetOrSetDefault("mcsync", () => new Dictionary<string, object>());
            txtMinecraftFolder.Text = configValues.GetOrSetDefault("minecraftDirectory", string.Empty).Cast<string>();
            txtModsDirectory.Text = configValues.GetOrSetDefault("modsDirectory", string.Empty).Cast<string>();
            txtResourcePacksDirectory.Text = configValues.GetOrSetDefault("resourcePackDirectory", "").Cast<string>();
            txtConfigDirectory.Text = configValues.GetOrSetDefault("configFilesDirectory", "").Cast<string>();
            txtOResourcesDirectory.Text = configValues.GetOrSetDefault("oResourcesDirectory", "").Cast<string>();
            txtAnimationDirectory.Text = configValues.GetOrSetDefault("animationDirectory", "").Cast<string>();
            txtSignPacksDirectory.Text = configValues.GetOrSetDefault("signPacksDirectory", "").Cast<string>();
            Enum.TryParse(configValues.GetOrSetDefault("mode", SyncMode.Client.ToString()).Cast<string>(), true, out SyncMode syncMode);

            rbClient.Checked = syncMode == SyncMode.Client;
            rbServer.Checked = syncMode == SyncMode.Server;

            overrideFoldersCheckBox.Checked = string.IsNullOrEmpty(configValues.GetOrDefault("minecraftDirectory").Cast<string>());
            overrideFoldersCheckBox_CheckedChanged(overrideFoldersCheckBox, EventArgs.Empty);
            BringToFront();
        }

        private void overrideFoldersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            txtModsDirectory.Enabled = overrideFoldersCheckBox.Checked;
            txtResourcePacksDirectory.Enabled = overrideFoldersCheckBox.Checked;
            txtConfigDirectory.Enabled = overrideFoldersCheckBox.Checked;
            txtOResourcesDirectory.Enabled = overrideFoldersCheckBox.Checked;
            txtAnimationDirectory.Enabled = overrideFoldersCheckBox.Checked;
            txtSignPacksDirectory.Enabled = overrideFoldersCheckBox.Checked;
            cmdBrowseMods.Enabled = overrideFoldersCheckBox.Checked;
            cmdBrowseResourcePacks.Enabled = overrideFoldersCheckBox.Checked;
            cmdBrowseConfig.Enabled = overrideFoldersCheckBox.Checked;
            cmdBrowseOResources.Enabled = overrideFoldersCheckBox.Checked;
            cmdBrowseAnimation.Enabled = overrideFoldersCheckBox.Checked;
            cmdBrowseSignPacks.Enabled = overrideFoldersCheckBox.Checked;

            txtMinecraftFolder.Enabled = !overrideFoldersCheckBox.Checked;
            cmdMinecraftFolder.Enabled = !overrideFoldersCheckBox.Checked;

            if (!overrideFoldersCheckBox.Checked)
            {
                txtModsDirectory.Text = txtMinecraftFolder.Text + "\\mods";

                if (rbServer.Checked)
                {
                    txtResourcePacksDirectory.Text = txtMinecraftFolder.Text + "\\config\\immersiverailroading";
                }
                else
                {
                    txtResourcePacksDirectory.Text = txtMinecraftFolder.Text + "\\resourcepacks";
                }

                txtConfigDirectory.Text = txtMinecraftFolder.Text + "\\config";
                txtOResourcesDirectory.Text = txtMinecraftFolder.Text + "\\oresources";
                txtAnimationDirectory.Text = txtMinecraftFolder.Text + "\\config\\customloadingscreen";
                txtSignPacksDirectory.Text = txtMinecraftFolder.Text + "\\tc_signpacks";
            }
        }

        private void fButtonSave_Click(object sender, EventArgs e)
        {
            UserPreferences userPreferences = UserPreferences.Get();
            Dictionary<string, object> configValues = userPreferences.Sections.GetOrSetDefault("mcsync", new Dictionary<string, object>());

            configValues["modsDirectory"] = txtModsDirectory.Text;
            configValues["resourcePackDirectory"] = txtResourcePacksDirectory.Text;
            configValues["configFilesDirectory"] = txtConfigDirectory.Text;
            configValues["oResourcesDirectory"] = txtOResourcesDirectory.Text;
            configValues["animationDirectory"] = txtAnimationDirectory.Text;
            configValues["signPacksDirectory"] = txtSignPacksDirectory.Text;

            if (rbClient.Checked)
            {
                configValues["mode"] = SyncMode.Client.ToString();
            }
            else if (rbServer.Checked)
            {
                configValues["mode"] = SyncMode.Server.ToString();
            }

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

        private void cmdBrowseMods_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser browser = new BetterFolderBrowser();
            browser.Title = "Select Mods folder";
            browser.Multiselect = false;
            browser.RootFolder = txtModsDirectory.Text;
            if (browser.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtModsDirectory.Text = browser.SelectedPath;
        }

        private void cmdBrowseResourcePacks_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser browser = new BetterFolderBrowser();
            browser.Title = "Select Resource Packs folder";
            browser.Multiselect = false;
            browser.RootFolder = txtResourcePacksDirectory.Text;
            if (browser.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtResourcePacksDirectory.Text = browser.SelectedPath;
        }

        private void cmdBrowseConfig_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser browser = new BetterFolderBrowser();
            browser.Title = "Select Config folder";
            browser.Multiselect = false;
            browser.RootFolder = txtConfigDirectory.Text;
            if (browser.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtConfigDirectory.Text = browser.SelectedPath;
        }

        private void cmdBrowseOResources_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser browser = new BetterFolderBrowser();
            browser.Title = "Select OResources folder";
            browser.Multiselect = false;
            browser.RootFolder = txtOResourcesDirectory.Text;
            if (browser.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtOResourcesDirectory.Text = browser.SelectedPath;
        }

        private void cmdBrowseAnimation_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser browser = new BetterFolderBrowser();
            browser.Title = "Select Custom Loading Screen folder";
            browser.Multiselect = false;
            browser.RootFolder = txtAnimationDirectory.Text;
            if (browser.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtAnimationDirectory.Text = browser.SelectedPath;
        }

        private void cmdBrowseSignPacks_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser browser = new BetterFolderBrowser();
            browser.Title = "Select Sign Packs folder";
            browser.Multiselect = false;
            browser.RootFolder = txtAnimationDirectory.Text;
            if (browser.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtSignPacksDirectory.Text = browser.SelectedPath;
        }

        private void fButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtMinecraftFolder_TextChanged(object sender, EventArgs e)
        {
            if (!overrideFoldersCheckBox.Checked)
            {
                txtModsDirectory.Text = txtMinecraftFolder.Text + "\\mods";

                if (rbServer.Checked)
                {
                    txtResourcePacksDirectory.Text = txtMinecraftFolder.Text + "\\config\\immersiverailroading";
                }
                else
                {
                    txtResourcePacksDirectory.Text = txtMinecraftFolder.Text + "\\resourcepacks";
                }

                txtConfigDirectory.Text = txtMinecraftFolder.Text + "\\config";
                txtOResourcesDirectory.Text = txtMinecraftFolder.Text + "\\oresources";
                txtAnimationDirectory.Text = txtMinecraftFolder.Text + "\\config\\customloadingscreen";
                txtSignPacksDirectory.Text = txtMinecraftFolder.Text + "\\tc_signpacks";
            }
        }
    }
}
