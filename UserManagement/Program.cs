using System.Windows.Forms;

namespace UserManagement
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.Run(new frmManage());
        }
    }
}
