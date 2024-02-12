using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Updater.UpdateWorkflow;
using WK.Libraries.BetterFolderBrowserNS;

namespace Updater.Steps
{
    public partial class SetMCSyncPathStepControl : UserControl, IStepUserControl
    {
        public SetMCSyncPathStepControl()
        {
            InitializeComponent();
        }

        public Step Step { get; set; }

        private void SetMCSyncPathStepControl_Load(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(Step.InstallationConfiguration.InstallDirectory, "userpreferences.json")))
            {
                string fileContents = File.ReadAllText(Path.Combine(Step.InstallationConfiguration.InstallDirectory, "userpreferences.json"));
                string minecraftDirectory = TryGetDirectoryFromPreferences(fileContents, "minecraftDirectory");
                if (string.IsNullOrEmpty(minecraftDirectory))
                {
                    minecraftDirectory = TryGetDirectoryFromPreferences(fileContents, "modsDirectory");
                    if (!string.IsNullOrEmpty(minecraftDirectory))
                    {
                        minecraftDirectory = minecraftDirectory.Substring(0, minecraftDirectory.LastIndexOf("\\"));
                    }
                }

                if (!string.IsNullOrEmpty(minecraftDirectory))
                {
                    txtMinecraftDirectory.Text = minecraftDirectory.Replace("\\\\", "\\").TrimEnd('\\');
                }
            }
        }

        private string TryGetDirectoryFromPreferences(string file, string directoryName)
        {
            string searchString = $"\"{directoryName}\":";
            if (file.Contains(searchString))
            {
                // Bring cursor up to just after the property
                string workingString = file.Substring(file.IndexOf(searchString) + searchString.Length);

                // Cut off the first quote of the value
                workingString = workingString.Substring(workingString.IndexOf("\"") + 1);

                // Get everything up to (and not including) the ending quote of the value
                workingString = workingString.Substring(0, workingString.IndexOf("\""));

                if (!string.IsNullOrEmpty(workingString))
                {
                    return workingString;
                }
            }

            return null;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser browser = new BetterFolderBrowser();
            browser.Title = "Select .minecraft folder";
            browser.Multiselect = false;
            browser.RootFolder = txtMinecraftDirectory.Text;
            if (browser.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtMinecraftDirectory.Text = browser.SelectedPath;
        }

        private void txtMinecraftDirectory_TextChanged(object sender, EventArgs e)
        {
            Step.InstallationConfiguration.MinecraftDirectory = txtMinecraftDirectory.Text;
        }
    }
}
