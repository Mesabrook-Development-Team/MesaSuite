using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace Updater
{
    static class Program
    {
        public const bool InternalEdition = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            StartupArguments.SetupArguments(args);
            Application.Run(new frmPrompts());
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (!string.Equals(args.Name, "BetterFolderBrowser, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null"))
            {
                return null;
            }

            using(Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Updater.BetterFolderBrowser.dll"))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, (int)stream.Length);
                return Assembly.Load(assemblyData);
            }
        }
    }
}
