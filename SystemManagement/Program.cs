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
            Application.Run(new SecuredApplicationContext(() => new frmManage(), "system", "System Management", Main, args));
        }
    }
}
