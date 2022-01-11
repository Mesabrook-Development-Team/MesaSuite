using System;

namespace MesaSuite.SplashScreenModifiers
{
    internal class NewYearsDay : ISplashScreenModifier
    {
        public bool IsValid() => DateTime.Today.Month == 1 && DateTime.Today.Day == 1;

        public void Modify(frmSplash splash)
        {
            splash.pboxHat.Visible = false;
            splash.pBoxLogo.Image = Properties.Resources.logo_MS_Gold;
            splash.BackgroundImage = Properties.Resources.bg_ny;
            splash.lblMessage.Text = "Happy " + DateTime.Today.Year + " from the Mesabrook Development Team!";
        }
    }
}
