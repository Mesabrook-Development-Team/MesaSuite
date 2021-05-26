using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StartupArguments.SetupArguments(args);
            if (string.IsNullOrEmpty(StartupArguments.VersionToDownload))
            {
                MessageBox.Show("At least a -version argument needs to be supplied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.Run(new frmMain());
        }
    }
}
