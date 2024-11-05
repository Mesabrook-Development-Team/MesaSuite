using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Updater
{
    static class Program
    {
        public const bool InternalEdition = false;

        public static SoundPlayer installMusic = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            Application.ApplicationExit += Application_ApplicationExit;
            StartupArguments.SetupArguments(args);
            Application.Run(new frmPrompts());
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (installMusic != null)
            {
                installMusic.Dispose();
            }
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (string.Equals(args.Name, "BetterFolderBrowser, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null"))
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Updater.BetterFolderBrowser.dll"))
                {
                    byte[] assemblyData = new byte[stream.Length];
                    stream.Read(assemblyData, 0, (int)stream.Length);
                    return Assembly.Load(assemblyData);
                }
            }
            else if (string.Equals(args.Name, "Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed"))
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Updater.Newtonsoft.Json.dll"))
                {
                    byte[] assemblyData = new byte[stream.Length];
                    stream.Read(assemblyData, 0, (int)stream.Length);
                    return Assembly.Load(assemblyData);
                }
            }

            return null;
        }
    }
}
