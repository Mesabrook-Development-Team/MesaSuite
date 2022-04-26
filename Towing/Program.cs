using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MesaSuite.Common;

namespace Towing
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main(string[] args)
        {
            Application.Run(new SecuredApplicationContext(() => new frmMain(), "tow", "Tow Tickets", restartArgs => Main(restartArgs), args));
        }
    }
}
