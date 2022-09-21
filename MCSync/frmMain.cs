using MesaSuite.Common;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using WK.Libraries.BetterFolderBrowserNS;
using static MCSync.Syncer;

namespace MCSync
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            pnlConfig.Visible = false;
            backgroundChooser();
            lblVersion.Text = "MCSync " + Application.ProductVersion;

            Dictionary<string, object> configValues = UserPreferences.Get().Sections.GetOrSetDefault("mcsync", () => new Dictionary<string, object>());
            txtMinecraftFolder.Text = configValues.GetOrSetDefault("minecraftDirectory", string.Empty).Cast<string>();
            txtModsDirectory.Text = configValues.GetOrSetDefault("modsDirectory", string.Empty).Cast<string>();
            txtResourcePacksDirectory.Text = configValues.GetOrSetDefault("resourcePackDirectory", "").Cast<string>();
            txtConfigDirectory.Text = configValues.GetOrSetDefault("configFilesDirectory", "").Cast<string>();
            txtOResourcesDirectory.Text = configValues.GetOrSetDefault("oResourcesDirectory", "").Cast<string>();
            Enum.TryParse(configValues.GetOrSetDefault("mode", SyncMode.Client.ToString()).Cast<string>(), true, out SyncMode syncMode);

            rbClient.Checked = syncMode == SyncMode.Client;
            rbServer.Checked = syncMode == SyncMode.Server;

            overrideFoldersCheckBox.Checked = string.IsNullOrEmpty(configValues.GetOrDefault("minecraftDirectory").Cast<string>());
            overrideFoldersCheckBox_CheckedChanged(this, EventArgs.Empty);
            cboxBalloonTips.Checked = configValues.GetOrDefault("showBalloonTips", true).Cast<bool>();
        }

        public void backgroundChooser()
        {
            try
            {
                int rand = new Random().Next(1, 105);

                var request = WebRequest.Create("https://mesabrook.com/backgrounds/background" + rand + ".png");

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    BackgroundImage = Bitmap.FromStream(stream);
                    BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            catch (Exception ex)
            {
                BackgroundImage = Properties.Resources.b1;
            }
        }

        private void fancyButton1_Click(object sender, EventArgs e)
        {
            pnlMain.Hide();
            pnlConfig.Show();
            pnlConfig.BringToFront();
        }

        private void frmMain_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Process.Start("https://mesabrook.com/mcsync/index.html");
        }

        private void fButtonSync_Click(object sender, EventArgs e)
        {
            frmSync sync = new frmSync();
            pnlMain.Visible = false;
            sync.ShowDialog(this);
        }

        private void fButtonCancel_Click(object sender, EventArgs e)
        {
            pnlConfig.Hide();
            pnlMain.Show();
        }

        private void cmdModsWhitelist_Click(object sender, EventArgs e)
        {
            frmWhitelist whitelist = new frmWhitelist();
            whitelist.Text = "Mods Whitelist";
            whitelist.WhitelistName = "mods_whitelist";
            whitelist.lblIntro.Text = "Edit your Mods whitelist.";
            whitelist.ShowDialog();
        }

        private void cmdResourcePacksWhitelist_Click(object sender, EventArgs e)
        {
            frmWhitelist whitelist = new frmWhitelist();
            whitelist.Text = "Resource Packs Whitelist";
            whitelist.WhitelistName = "resourcepacks_whitelist";
            whitelist.lblIntro.Text = "Edit your Resource Packs whitelist.";
            whitelist.ShowDialog();
        }

        private void fButtonSave_Click(object sender, EventArgs e)
        {
            UserPreferences userPreferences = UserPreferences.Get();
            Dictionary<string, object> configValues = userPreferences.Sections.GetOrSetDefault("mcsync", new Dictionary<string, object>());

            configValues["modsDirectory"] = txtModsDirectory.Text;
            configValues["resourcePackDirectory"] = txtResourcePacksDirectory.Text;
            configValues["configFilesDirectory"] = txtConfigDirectory.Text;
            configValues["oResourcesDirectory"] = txtOResourcesDirectory.Text;
            configValues["showBalloonTips"] = cboxBalloonTips.Checked.ToString();

            if (rbClient.Checked)
            {
                configValues["mode"] = SyncMode.Client.ToString();
            }
            else if (rbServer.Checked)
            {
                configValues["mode"] = SyncMode.Server.ToString();
            }

            userPreferences.Save();
            pnlConfig.Visible = false;
            pnlMain.Show();
        }

        private void txtMinecraftFolder_TextChanged(object sender, EventArgs e)
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
        }

        private void rbServer_CheckedChanged(object sender, EventArgs e)
        {
            if (rbServer.Checked)
            {
                txtResourcePacksDirectory.Text = txtConfigDirectory.Text + "\\immersiverailroading";
            }
            else
            {
                txtResourcePacksDirectory.Text = txtMinecraftFolder.Text + "\\resourcepacks";
            }
        }

        private void overrideFoldersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            txtModsDirectory.Enabled = overrideFoldersCheckBox.Checked;
            txtResourcePacksDirectory.Enabled = overrideFoldersCheckBox.Checked;
            txtConfigDirectory.Enabled = overrideFoldersCheckBox.Checked;
            txtOResourcesDirectory.Enabled = overrideFoldersCheckBox.Checked;
            cmdBrowseMods.Enabled = overrideFoldersCheckBox.Checked;
            cmdBrowseResourcePacks.Enabled = overrideFoldersCheckBox.Checked;
            cmdBrowseConfig.Enabled = overrideFoldersCheckBox.Checked;
            cmdBrowseOResources.Enabled = overrideFoldersCheckBox.Checked;

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
            }
        }

        private void cboxBalloonTips_CheckedChanged(object sender, EventArgs e)
        {

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
    }
}
