using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

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
    }
}
