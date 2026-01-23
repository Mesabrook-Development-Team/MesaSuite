using System;
using System.Windows.Forms;

namespace FleetTracking
{
    public class LoadVisualHandler : IDisposable
    {
        private Control[] controls;

        public LoadVisualHandler(params Control[] controls)
        {
            this.controls = controls;

            foreach(Control control in controls)
            {
                try
                {
                    switch (control)
                    {
                        case Loader loader:
                            loader.BringToFront();
                            loader.Enabled = true;
                            loader.Visible = true;
                            break;
                        default:
                            control.Enabled = false;
                            break;
                    }
                }
                catch { }
            }
        }

        public void Dispose()
        {
            foreach(Control control in controls)
            {
                try
                {
                    switch (control)
                    {
                        case Loader loader:
                            loader.Visible = false;
                            break;
                        default:
                            control.Enabled = true;
                            break;
                    }
                }
                catch { }
            }
        }
    }
}
