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
            if (DateTime.Today.Month == 4  && DateTime.Today.Day == 1)
            {
                this.BackgroundImage = Properties.Resources.tmpBackground;
                pBoxLogo.Image = Properties.Resources.logoMSJoke;
                lblVersion.Text = "Version 6.9.6.9";
            }
            else
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
                lblVersion.Text = "Version " + Application.ProductVersion;
            }
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            Opacity += 0.2;
        }

        private void frmSplash_FormClosing(object sender, FormClosingEventArgs e)
        {
            fadeTimer.Stop();
        }
    }
}
