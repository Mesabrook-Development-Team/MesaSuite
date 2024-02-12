using System;
using System.Drawing;

namespace MesaSuite.SplashScreenModifiers
{
    internal class IndepdenceDay : ISplashScreenModifier
    {
        public bool IsValid() => DateTime.Today.Month == 7 && DateTime.Today.Day == 4;

        public void Modify(frmSplash splash)
        {
            splash.pBoxLogo.Image = Properties.Resources.logo_new_3;
            splash.BackgroundImage = Properties.Resources.bg_usa;
            splash.lblMessage.Text = "Happy Independence Day!";
            splash.pboxHat.Visible = true;
            splash.pboxHat.BackgroundImage = Properties.Resources.hat_usa;
            splash.lblMessage.ForeColor = Color.White;
        }
    }
}
