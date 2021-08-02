using System.Linq;
using System.Windows.Forms;

namespace MesaSuite.Common
{
    public class SecuredApplicationContext : ApplicationContext
    {
        private string _programName;
        public SecuredApplicationContext(Form mainForm, string programName) : base(mainForm)
        {
            Authentication.OnProgramUpdate += Authentication_OnProgramUpdate;
            _programName = programName;
        }

        private void Authentication_OnProgramUpdate(object sender, System.EventArgs e)
        {
            if (!Authentication.Programs.Contains(_programName))
            {
                Authentication.OnProgramUpdate -= Authentication_OnProgramUpdate;
                MessageBox.Show("You no longer have access to use this system.", "Insufficient Security", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                ExitThread();
            }
        }
    }
}
