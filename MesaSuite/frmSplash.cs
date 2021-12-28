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
                Font lblFont = new Font("Comic Sans MS", 9);

                this.BackgroundImage = Properties.Resources.wheeze;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                pBoxLogo.Image = Properties.Resources.logoMSJoke;
                lblMessage.Font = lblFont;
                lblVersion.Text = "Version 6.9.6.9";
                lblMessage.Text = "The FitnessGram Pacer Test is a multistage aerobic capacity test that progressively gets more difficult as it continues. The 20 meter pacer test will begin in 30 seconds. Line up at the start. The running speed starts slowly, but gets faster each minute after you hear this signal. [beep] A single lap should be completed each time you hear this sound. [ding] Remember to run in a straight line, and run as long as possible. The second time you fail to complete a lap before the sound, your test is over. The test will begin on the word start. On your mark, get ready, start.";
                pboxHat.Visible = false;
            }
            else if(DateTime.Today.Month == 12 && DateTime.Today.Day == 31)
            {
                pboxHat.Visible = false;
                pBoxLogo.Image = Properties.Resources.logo_MS_Gold;
                this.BackgroundImage = Properties.Resources.bg_ny;
                lblMessage.Text = "Happy New Year's Eve from the Mesabrook Development Team!";
            }
            else if (DateTime.Today.Month == 1 && DateTime.Today.Day == 1)
            {
                pboxHat.Visible = false;
                pBoxLogo.Image = Properties.Resources.logo_MS_Gold;
                this.BackgroundImage = Properties.Resources.bg_ny;
                lblMessage.Text = "Happy " + DateTime.Today.Year + " from the Mesabrook Development Team!";
            }
            else if (DateTime.Today.Month == 12 && DateTime.Today.Day == 24 || DateTime.Today.Month == 12 && DateTime.Today.Day == 25)
            {
                pBoxLogo.Image = Properties.Resources.logo_MS_Ice;
                this.BackgroundImage = Properties.Resources.bg_xmas;
                lblMessage.Text = "Happy Holidays from the Mesabrook Development Team!";
                pboxHat.Visible = true;
            }
            else if (DateTime.Today.Month == 10 && DateTime.Today.Day == 31)
            {
                pboxHat.Visible = false;
                pBoxLogo.Image = Properties.Resources.logo_MS_Red;
                this.BackgroundImage = Properties.Resources.bg_halloween;
                lblMessage.Text = "Happy Halloween from the Mesabrook Development Team!" + Environment.NewLine + Environment.NewLine + "Background Credit: McPhysH";
            }
            else if (DateTime.Today.Month == 10 && DateTime.Today.Day == 10)
            {
                pBoxLogo.Image = Properties.Resources.logo_MS_Orange;
                this.BackgroundImage = Properties.Resources.bg_thanksgiving;
                lblMessage.Text = "Happy Thanksgiving (Canada) from the Mesabrook Development Team!";
                lblMessage.ForeColor = Color.Black;
                pboxHat.Visible = true;
                pboxHat.BackgroundImage = Properties.Resources.hat_pil;
            }
            else if (DateTime.Today.Month == 11 && DateTime.Today.Day == 24)
            {
                pBoxLogo.Image = Properties.Resources.logo_MS_Orange;
                this.BackgroundImage = Properties.Resources.bg_thanksgiving;
                lblMessage.Text = "Happy Thanksgiving (United States) from the Mesabrook Development Team!";
                pboxHat.Visible = true;
                lblMessage.ForeColor = Color.Black;
                pboxHat.BackgroundImage = Properties.Resources.hat_pil;
            }
            else if (DateTime.Today.Month == 11 && DateTime.Today.Day == 30)
            {
                pBoxLogo.Image = Properties.Resources.logo_MS_Gold;
                this.BackgroundImage = Properties.Resources.bg_ms;
                lblMessage.Text = "Happy Anniversary, Mesabrook!";
                pboxHat.Visible = true;
                lblMessage.ForeColor = Color.White;
                pboxHat.BackgroundImage = Properties.Resources.hat_bday;
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
                lblMessage.Text = "";
                pboxHat.Visible = false;
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
