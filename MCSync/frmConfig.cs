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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            pnlWhitelist.Visible = true;
            fadeTimer.Start();
        }

        private void fButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Opacity = 0;
            Close();
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmWhitelist"] != null || Application.OpenForms["frmPaths"] != null)
            {
                label1.Visible = false;
                label9.Visible = false;
                fButtonCancel.Visible = false;

                pnlPaths.Visible = false;
                pnlWhitelists.Visible = false;
            }
            else
            {
                label1.Visible = true;
                label9.Visible = true;
                fButtonCancel.Visible = true;

                pnlPaths.Visible = true;
                pnlWhitelists.Visible = true;
            }
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

            label1.Visible = false;
            label9.Visible = false;

            pnlPaths.Visible = false;
            pnlWhitelists.Visible = false;
            fButtonCancel.Visible = false;

            frmPaths.Show();
            frmPaths.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmPaths frmPaths = new frmPaths();

            frmPaths.TopLevel = false;

            pnlWhitelist.Controls.Add(frmPaths);
            pnlWhitelist.Show();
            pnlWhitelist.BringToFront();

            label1.Visible = false;
            label9.Visible = false;
            fButtonCancel.Visible = false;

            pnlPaths.Visible = false;
            pnlWhitelists.Visible = false;

            frmPaths.Show();
            frmPaths.BringToFront();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frmPaths frmPaths = new frmPaths();

            frmPaths.TopLevel = false;

            pnlWhitelist.Controls.Add(frmPaths);
            pnlWhitelist.Show();
            pnlWhitelist.BringToFront();

            label1.Visible = false;
            label9.Visible = false;
            fButtonCancel.Visible = false;

            pnlPaths.Visible = false;
            pnlWhitelists.Visible = false;

            frmPaths.Show();
            frmPaths.BringToFront();
        }

        private void pnlWhitelists_Click(object sender, EventArgs e)
        {
            frmWhitelist frmWhitelist = new frmWhitelist();

            frmWhitelist.TopLevel = false;

            pnlWhitelist.Controls.Add(frmWhitelist);
            pnlWhitelist.Show();
            pnlWhitelist.BringToFront();

            label1.Visible = false;
            label9.Visible = false;
            fButtonCancel.Visible = false;

            pnlPaths.Visible = false;
            pnlWhitelists.Visible = false;

            frmWhitelist.Show();
            frmWhitelist.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmWhitelist frmWhitelist = new frmWhitelist();

            frmWhitelist.TopLevel = false;

            pnlWhitelist.Controls.Add(frmWhitelist);
            pnlWhitelist.Show();
            pnlWhitelist.BringToFront();

            label1.Visible = false;
            label9.Visible = false;
            fButtonCancel.Visible = false;

            pnlPaths.Visible = false;
            pnlWhitelists.Visible = false;

            frmWhitelist.Show();
            frmWhitelist.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            frmWhitelist frmWhitelist = new frmWhitelist();

            frmWhitelist.TopLevel = false;

            pnlWhitelist.Controls.Add(frmWhitelist);
            pnlWhitelist.Show();
            pnlWhitelist.BringToFront();

            label1.Visible = false;
            label9.Visible = false;
            fButtonCancel.Visible = false;

            pnlPaths.Visible = false;
            pnlWhitelists.Visible = false;

            frmWhitelist.Show();
            frmWhitelist.BringToFront();
        }
    }
}