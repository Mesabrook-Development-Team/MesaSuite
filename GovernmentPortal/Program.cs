using System.Windows.Forms;
using MesaSuite.Common;

namespace GovernmentPortal
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main(string[] args)
        {
            Application.Run(new SecuredApplicationContext(() => new frmPortal(), "gov", "Government Portal", (restartArgs) => Main(restartArgs), args));
        }
    }
}
