using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MesaSuite.SplashScreenModifiers;

namespace MesaSuite
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            fadeTimer.Start();
            lblVersion.Text = "Version " + Application.ProductVersion;
            if (!SplashScreenModificationController.Modify(this))
            {
                try
                {
                    int rand = new Random().Next(1, 105);

                    var request = WebRequest.Create("https://mesabrook.com/backgrounds/background" + rand + ".png");

                    using (var response = request.GetResponse())
                    using(var stream = response.GetResponseStream())
                    {
                        BackgroundImage = Bitmap.FromStream(stream);
                        BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
                catch(Exception OopsieWoopsiesWeHadALittleFuckyWuckyUwU)
                {
                    BackgroundImage = Properties.Resources.bg1;
                }

                pBoxLogo.Image = Properties.Resources.logoMS;
                lblMessage.Text = "";
                pboxHat.Visible = false;
            }
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            Opacity += 0.2;
            if (Opacity >= 1)
            {
                Opacity = 1;
                fadeTimer.Stop();
            }
        }

        private void frmSplash_FormClosing(object sender, FormClosingEventArgs e)
        {
            fadeTimer.Stop();
        }
    }
}
