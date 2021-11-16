using MesaSuite.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace CompanyStudio
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Application.Run(new SecuredApplicationContext(() => new frmStudio(), "company", "Company Studio", Main, args));
        }
    }
}
