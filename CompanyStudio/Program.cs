using MesaSuite.Common;
using System.Windows.Forms;

namespace CompanyStudio
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SecuredApplicationContext(new frmStudio(), "company"));
        }
    }
}
