using System;
using System.Drawing;

namespace MesaSuite.SplashScreenModifiers
{
    internal class ThanksgivingUS : ISplashScreenModifier
    {
        public bool IsValid()
        {
            if (DateTime.Today.Month != 11) { return false; }

            DateTime workingDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            while (workingDate.DayOfWeek != DayOfWeek.Thursday)
            {
                workingDate = workingDate.AddDays(1);
            }

            return DateTime.Today.Day == workingDate.Day + 21; // Fourth Thursday in November
        }

        public void Modify(frmSplash splash)
        {
            splash.pBoxLogo.Image = Properties.Resources.logo_MS_Orange;
            splash.BackgroundImage = Properties.Resources.bg_thanksgiving;
            splash.lblMessage.Text = "Happy Thanksgiving (United States) from the Mesabrook Development Team!";
            splash.pboxHat.Visible = true;
            splash.lblMessage.ForeColor = Color.Black;
            splash.pboxHat.BackgroundImage = Properties.Resources.hat_pil;
        }
    }
}
