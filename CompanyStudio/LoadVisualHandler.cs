using System;
using System.Windows.Forms;

namespace CompanyStudio
{
    public class LoadVisualHandler : IDisposable
    {
        private Control[] controls;

        public LoadVisualHandler(params Control[] controls)
        {
            this.controls = controls;

            foreach(Control control in controls)
            {
                if (!control.IsHandleCreated)
                {
                    continue;
                }

                switch(control)
                {
                    case Loader loader:
                        loader.BringToFront();
                        loader.Visible = true;
                        break;
                    default:
                        control.Enabled = false;
                        break;
                }
            }
        }

        public void Dispose()
        {
            foreach(Control control in controls)
            {
                if (!control.IsHandleCreated)
                {
                    continue;
                }
                switch(control)
                {
                    case Loader loader:
                        loader.Visible = false;
                        break;
                    default:
                        control.Enabled = true;
                        break;
                }
            }
        }
    }
}
