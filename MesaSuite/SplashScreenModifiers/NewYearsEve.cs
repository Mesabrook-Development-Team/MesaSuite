using System;

namespace MesaSuite.SplashScreenModifiers
{
    internal class NewYearsEve : ISplashScreenModifier
    {
        public bool IsValid() => DateTime.Today.Month == 12 && DateTime.Today.Day == 31;

        public void Modify(frmSplash splash)
        {
            splash.pboxHat.Visible = false;
            splash.pBoxLogo.Image = Properties.Resources.logo_MS_Gold;
            splash.BackgroundImage = Properties.Resources.bg_ny;
            splash.lblMessage.Text = "Happy New Year's Eve from the Mesabrook Development Team!";
        }
    }
}
