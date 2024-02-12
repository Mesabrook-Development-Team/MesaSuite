using System;

namespace MesaSuite.SplashScreenModifiers
{
    internal class HappyHolidays : ISplashScreenModifier
    {
        public bool IsValid() => DateTime.Today.Month == 12 && (DateTime.Today.Day == 24 || DateTime.Today.Day == 25);

        public void Modify(frmSplash splash)
        {
            splash.pBoxLogo.Image = Properties.Resources.logo_new_7;
            splash.BackgroundImage = Properties.Resources.bg_xmas;
            splash.lblMessage.Text = "Happy Holidays from the Mesabrook Development Team!";
            splash.pboxHat.Visible = true;
        }
    }
}
