using System.Collections.Generic;
using System.Linq;

namespace MesaSuite.SplashScreenModifiers
{
    internal class SplashScreenModificationController
    {
        private static List<ISplashScreenModifier> SplashScreenModifiers = new List<ISplashScreenModifier>()
        {
            new ValentinesDay(),
            new AprilFoolsDay(),
            new BirthdayMesabrook(),
            new Halloween(),
            new HappyHolidays(),
            new NewYearsDay(),
            new NewYearsEve(),
            new ThanksgivingCanada(),
            new ThanksgivingUS()
        };

        public static bool Modify(frmSplash splash)
        {
            IEnumerable<ISplashScreenModifier> modifiers = SplashScreenModifiers.Where(m => m.IsValid());
            foreach(ISplashScreenModifier modifier in modifiers)
            {
                modifier.Modify(splash);
            }

            return modifiers.Any();
        }
    }
}
