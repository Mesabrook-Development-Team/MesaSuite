using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MesaSuite.Common
{
    public class SecuredApplicationContext : ApplicationContext
    {
        public delegate void RestartApplicationDelegate(string[] args);

        private string _programName;
        private string _displayName;
        private RestartApplicationDelegate _restartApplicationDelegate;
        private string[] _args;
        private Form _contextMainForm;
        public SecuredApplicationContext(Func<Form> createMainForm, string programName, string programDisplayName, RestartApplicationDelegate restartApplicationDelegate, string[] args)
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, true);
            Application.ThreadException += Application_ThreadException;
            MainForm = createMainForm();
            _contextMainForm = MainForm;
            if (GlobalSettings.InternalEditionMode)
            {
                _contextMainForm.Text += " (INTERNAL EDITION)";
            }
            _programName = programName;
            _displayName = programDisplayName;
            _restartApplicationDelegate = restartApplicationDelegate;
            _args = args;
            Authentication.OnProgramUpdate += Authentication_OnProgramUpdate;
        }

        private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Application.ThreadException -= Application_ThreadException;
            CloseAllForms();
            if (!MainForm.IsDisposed && MainForm.IsHandleCreated)
            {
                MainForm.Hide();
            }

            if (CrashHandler.HandleCrash(_displayName, e.Exception))
            {
                Thread thread = new Thread(new ThreadStart(() => _restartApplicationDelegate(_args)));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }

            if (!MainForm.IsDisposed && MainForm.IsHandleCreated)
            {
                if (MainForm.InvokeRequired)
                {
                    MainForm.Invoke(new MethodInvoker(MainForm.Close));
                }
                else
                {
                    MainForm.Close();
                }
            }
            Application.ExitThread();
        }

        private void Authentication_OnProgramUpdate(object sender, System.EventArgs e)
        {
            if (!Authentication.Programs.Contains(_programName))
            {
                Authentication.OnProgramUpdate -= Authentication_OnProgramUpdate;
                _contextMainForm.Invoke(new MethodInvoker(() => // Ensures all forms are on the same thread
                {
                    CloseAllForms();

                    if (!_contextMainForm.IsDisposed && _contextMainForm.IsHandleCreated)
                    {
                        _contextMainForm.Close();
                    }

                }));
                MessageBox.Show("You no longer have access to use this system.", "Insufficient Security", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void CloseAllForms()
        {
            foreach (Form form in Application.OpenForms.OfType<Form>().Where(f => !f.InvokeRequired && f != _contextMainForm).ToList())
            {
                if (form.IsDisposed)
                {
                    continue;
                }

                if (form.IsHandleCreated)
                {
                    try
                    {
                        form.Close();
                    }
                    catch { }
                }
            }
        }
    }
}
