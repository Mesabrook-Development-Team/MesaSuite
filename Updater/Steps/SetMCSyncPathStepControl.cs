using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            txtMinecraftDirectory.Text = "Adam pls give me some love";
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
    }
}
