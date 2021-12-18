using MesaSuite.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static List<Updater.MCSyncVersion> updates = new List<Updater.MCSyncVersion>();
        [STAThread]
        static void Main(string[] args)
        {
            StartupArguments.SetupArguments(args);
            if (StartupArguments.UpdaterProcessID != -1)
            {
                Console.WriteLine("Waiting for Updater to close...");
                while (Process.GetProcesses().Any(p => p.Id == StartupArguments.UpdaterProcessID))
                {
                    Thread.Sleep(50);
                }
            }

            if (!string.IsNullOrEmpty(StartupArguments.FolderToDelete) && Directory.Exists(StartupArguments.FolderToDelete))
            {
                Directory.Delete(StartupArguments.FolderToDelete, true);
            }

            // Splash screen logic
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmSplash splash = new frmSplash();
            splash.Show();
            Stopwatch shownTime = new Stopwatch();
            shownTime.Start();
            Application.DoEvents();

            Thread initThread = new Thread(new ThreadStart(InitializeApplication));
            initThread.Start();

            while (initThread.IsAlive)
            {
                Thread.Sleep(50);
                Application.DoEvents();
            }

            while (shownTime.ElapsedMilliseconds < 1000)
            {
                Thread.Sleep(50);
            }

            shownTime.Stop();
            splash.Close();

            if (updates == null)
            {
                MessageBox.Show("An error occurred while retrieving updates.  MesaSuite may not start without checking for updates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (updates.Any())
            {
                frmUpdate update = new frmUpdate();
                update.UpdaterResults = updates;
                Application.Run(update);
                return;
            }

            if (!string.IsNullOrEmpty(StartupArguments.Run))
            {
                RunOther();
            }
            else
            {
                Application.Run(new frmMain());
            }
        }

        private static void RunOther()
        {
            switch(StartupArguments.Run)
            {
                case "mcsync":
                    MCSync.Program.Main(StartupArguments.GetArgsForApp("mcsync"));
                    break;
            }
        }

        private static void InitializeApplication()
        {
            Application.ApplicationExit += Application_ApplicationExit;
            Task<Updater.UpdaterResults> task = new Task<Updater.UpdaterResults>(Updater.Run);
            task.Start();

            InitCustomLabelFont();
            Authentication.Initialize();

            while (task.Status == TaskStatus.Running)
            {
                Thread.Sleep(50);
            }

            if (task.Status == TaskStatus.Faulted)
            {
                updates = null;
                return;
            }

            if (task.Result.HasUpdates)
            {
                updates = task.Result.UpdatesAvailable;
            }
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Authentication.Shutdown();
        }

        private static void InitCustomLabelFont()
        {
            try
            {
                //PrivateFontCollection pfc = new PrivateFontCollection();
                //int fontLength = Properties.Resources.MC_FONT.Length;
                //byte[] fontdata = Properties.Resources.MC_FONT;
                //System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
                //Marshal.Copy(fontdata, 0, data, fontLength);
                //pfc.AddMemoryFont(data, fontLength);

                // Set font here
                //lblFontTest.Font = new System.Drawing.Font(pfc.Families[0], lblFontTest.Font.Size);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
