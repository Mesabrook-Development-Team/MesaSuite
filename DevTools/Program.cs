using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClussPro.ObjectBasedFramework.Loader;
using WebModels.Migrations;

namespace DevTools
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
            if (args == null)
            {
                args = new string[0];
            }

            if (args.Contains("runmigrations", StringComparer.OrdinalIgnoreCase) || args.Contains("runloaders", StringComparer.OrdinalIgnoreCase))
            {
                bool autoSuccessful = true;
                if (args.Contains("runmigrations", StringComparer.OrdinalIgnoreCase))
                {
                    MigrationController migrationController = new MigrationController();
                    try
                    {
                        MigrationController.Run(_ => { });
                    }
                    catch
                    {
                        autoSuccessful = false;
                    }
                }

                if (args.Contains("runloaders", StringComparer.OrdinalIgnoreCase))
                {
                    try
                    {
                        LoaderController loaderController = new LoaderController();
                        loaderController.Initialize();
                        loaderController.Process();
                    }
                    catch
                    {
                        autoSuccessful = false;
                    }
                }

                Environment.ExitCode = autoSuccessful ? 0 : 1;
                Application.Exit();
                return;
            }

            Application.Run(new frmDevTools()
            {
                StartDevToolsOnLoad = args.Contains("startBackEndAuth", StringComparer.OrdinalIgnoreCase)
            });
        }
    }
}
