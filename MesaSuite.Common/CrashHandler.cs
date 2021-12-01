using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesaSuite.Common
{
    public static class CrashHandler
    {
        public static bool HandleCrash(string programName, Exception ex)
        {
            frmCrashReport crashReport = new frmCrashReport();
            crashReport.lblProgram.Text = programName;
            crashReport.txtException.Text = ex.ToString();

            return crashReport.ShowDialog() == System.Windows.Forms.DialogResult.OK;
        }
    }
}
