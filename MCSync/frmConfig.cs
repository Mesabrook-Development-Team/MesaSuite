using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MesaSuite.Common;
using MesaSuite.Common.Extensions;
using WK.Libraries.BetterFolderBrowserNS;
using static MCSync.Syncer;

namespace MCSync
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            pnlWhitelist.Visible = true;
            fadeTimer.Start();
        }

        private void cmdModsWhitelist_Click(object sender, EventArgs e)
        {
            frmWhitelist whitelist = new frmWhitelist();
            whitelist.TopLevel = false;

            pnlWhitelist.Controls.Add(whitelist);
            pnlWhitelist.Show();
            pnlWhitelist.BringToFront();
            whitelist.Show();
        }

        private void cmdResourcePacksWhitelist_Click(object sender, EventArgs e)
        {
            frmWhitelist whitelist = new frmWhitelist();
            whitelist.TopLevel = false;

            pnlWhitelist.Controls.Add(whitelist);
            pnlWhitelist.Show();
            pnlWhitelist.BringToFront();
            whitelist.Show();
        }

        private void fButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Opacity = 0;
            Close();
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
        }

        private void fButtonPaths_Click(object sender, EventArgs e)
        {
            frmPaths frmPaths = new frmPaths();

            frmPaths.TopLevel = false;

            pnlWhitelist.Controls.Add(frmPaths);
            pnlWhitelist.Show();
            pnlWhitelist.BringToFront();
            frmPaths.Show();
        }

        private void pnlWhitelist_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlPaths_Click(object sender, EventArgs e)
        {
            frmPaths frmPaths = new frmPaths();

            frmPaths.TopLevel = false;

            pnlWhitelist.Controls.Add(frmPaths);
            pnlWhitelist.Show();
            pnlWhitelist.BringToFront();
            frmPaths.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmPaths frmPaths = new frmPaths();

            frmPaths.TopLevel = false;

            pnlWhitelist.Controls.Add(frmPaths);
            pnlWhitelist.Show();
            pnlWhitelist.BringToFront();
            frmPaths.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frmPaths frmPaths = new frmPaths();

            frmPaths.TopLevel = false;

            pnlWhitelist.Controls.Add(frmPaths);
            pnlWhitelist.Show();
            pnlWhitelist.BringToFront();
            frmPaths.Show();
        }

        private void pnlWhitelists_Click(object sender, EventArgs e)
        {
            frmWhitelist frmWhitelist = new frmWhitelist();

            frmWhitelist.TopLevel = false;

            pnlWhitelist.Controls.Add(frmWhitelist);
            pnlWhitelist.Show();
            pnlWhitelist.BringToFront();
            frmWhitelist.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmWhitelist frmWhitelist = new frmWhitelist();

            frmWhitelist.TopLevel = false;

            pnlWhitelist.Controls.Add(frmWhitelist);
            pnlWhitelist.Show();
            pnlWhitelist.BringToFront();
            frmWhitelist.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            frmWhitelist frmWhitelist = new frmWhitelist();

            frmWhitelist.TopLevel = false;

            pnlWhitelist.Controls.Add(frmWhitelist);
            pnlWhitelist.Show();
            pnlWhitelist.BringToFront();
            frmWhitelist.Show();
        }
    }
}