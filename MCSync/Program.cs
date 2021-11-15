using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using MesaSuite.Common;
using MesaSuite.Common.Extensions;

namespace MCSync
{
    public static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            MigrateConfigs();

            if (args != null && args.Contains("mcsync.nogui"))
            {
                NonInteractiveRun nonInteractiveRun = new NonInteractiveRun();
                nonInteractiveRun.Run();

                while(nonInteractiveRun.IsRunning)
                {
                    Thread.Sleep(500);
                }
            }
            else
            {
                Console.WriteLine("Interactive mode - closing console");
                FreeConsole();
                frmMain mainForm = new frmMain();
                Application.Run(mainForm);
            }
        }

        private static void MigrateConfigs()
        {
            UserPreferences userPreferences = UserPreferences.Get();
            Dictionary<string, object> configValues = userPreferences.Sections.GetOrSetDefault("mcsync", new Dictionary<string, object>());
            if (File.Exists("config.xml"))
            {
                XDocument oldConfig = XDocument.Load("config.xml");
                configValues["modsDirectory"] = oldConfig.Root?.Element("ModsDirectory")?.Value ?? string.Empty;
                configValues["resourcePackDirectory"] = oldConfig.Root?.Element("ResourcePackDirectory")?.Value ?? string.Empty;
                configValues["configFilesDirectory"] = oldConfig.Root?.Element("ConfigFilesDirectory")?.Value ?? string.Empty;
                configValues["mode"] = oldConfig.Root?.Element("Mode")?.Value ?? string.Empty;

                userPreferences.Save();

                File.Delete("config.xml");
            }

            if (File.Exists("mods_white_list.txt"))
            {
                string[] lines = File.ReadAllLines("mods_white_list.txt");
                configValues["mods_whitelist"] = lines;

                userPreferences.Save();

                File.Delete("mods_white_list.txt");
            }

            if (File.Exists("resourcepacks_white_list.txt"))
            {
                string[] lines = File.ReadAllLines("resourcepacks_white_list.txt");
                configValues["resourcepacks_whitelist"] = lines;

                userPreferences.Save();

                File.Delete("resourcepacks_white_list.txt");
            }
        }
    }
}
