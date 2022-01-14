using System;
using System.Drawing;
using System.Windows.Forms;

namespace MesaSuite.SplashScreenModifiers
{
    internal class AprilFoolsDay : ISplashScreenModifier
    {
        public bool IsValid() => DateTime.Today.Month == 4 && DateTime.Today.Day == 1;

        public void Modify(frmSplash splash)
        {
            Font lblFont = new Font("Comic Sans MS", 9);

            splash.BackgroundImage = Properties.Resources.wheeze;
            splash.BackgroundImageLayout = ImageLayout.Stretch;
            splash.pBoxLogo.Image = Properties.Resources.logoMSJoke;
            splash.lblMessage.Font = lblFont;
            splash.lblVersion.Text = "Version 6.9.6.9";
            splash.lblMessage.Text = "The FitnessGram Pacer Test is a multistage aerobic capacity test that progressively gets more difficult as it continues. The 20 meter pacer test will begin in 30 seconds. Line up at the start. The running speed starts slowly, but gets faster each minute after you hear this signal. [beep] A single lap should be completed each time you hear this sound. [ding] Remember to run in a straight line, and run as long as possible. The second time you fail to complete a lap before the sound, your test is over. The test will begin on the word start. On your mark, get ready, start.";
            splash.pboxHat.Visible = false;
        }
    }
}
