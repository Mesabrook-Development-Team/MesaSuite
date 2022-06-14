using System;
using System.Drawing;

namespace MesaSuite.SplashScreenModifiers
{
    internal class ValentinesDay : ISplashScreenModifier
    {
        public bool IsValid() => DateTime.Today.Month == 2 && DateTime.Today.Day == 14;

        public void Modify(frmSplash splash)
        {
            splash.pBoxLogo.Image = Properties.Resources.logo_MS_pink;
            splash.BackgroundImage = Properties.Resources.bg_hearts;
            splash.lblMessage.Text = "Happy Valentine's / Singles Awareness Day";
            splash.pboxHat.Visible = false;
            splash.lblMessage.ForeColor = Color.White;
        }
    }
}
