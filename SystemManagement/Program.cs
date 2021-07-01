using MesaSuite.Common;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SystemManagement
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.Run(new CustomContext(new frmManage()));
        }
    }

    public class CustomContext : ApplicationContext
    {
        public CustomContext(Form mainForm) : base(mainForm)
        {
            Authentication.OnProgramUpdate += Authentication_OnProgramUpdate;
        }

        private void Authentication_OnProgramUpdate(object sender, System.EventArgs e)
        {
            if (!Authentication.Programs.Contains("system"))
            {
                Authentication.OnProgramUpdate -= Authentication_OnProgramUpdate;
                MessageBox.Show("You no longer have access to use this system.", "Insufficient Security", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                ExitThread();
            }
        }
    }
}
