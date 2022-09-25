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
            backgroundChooser();
            lblVersion.Text = "Version " + Application.ProductVersion;
            pnlMainTimer.Start();
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
            frmConfig config = new frmConfig();

            config.TopLevel = false;
            config.ControlBox = false;
            config.Dock = DockStyle.Fill;
            config.FormBorderStyle = FormBorderStyle.None;

            pnlForm.Controls.Add(config);
            config.Show();
        }

        private void frmMain_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Process.Start("https://mesabrook.com/mcsync/index.html");
        }

        private void fButtonSync_Click(object sender, EventArgs e)
        {
            frmSync sync = new frmSync();
            sync.TopLevel = false;
            sync.ControlBox = false;
            sync.Dock = DockStyle.Fill;
            sync.FormBorderStyle = FormBorderStyle.None;

            pnlForm.Controls.Add(sync);
            sync.Show();
        }

        private void pnlMainTimer_Tick(object sender, EventArgs e)
        {
            var frmConfig = Application.OpenForms["frmConfig"];
            var frmSync = Application.OpenForms["frmSync"];

            if(frmSync != null || frmConfig != null)
            {
                pnlMain.Visible = false;
            }
            else
            {
                pnlMain.Visible = true;
            }
        }
    }
}
