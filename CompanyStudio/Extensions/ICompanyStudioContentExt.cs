using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio.Extensions
{
    internal static class ICompanyStudioContentExt
    {
        internal static void Show(this BaseCompanyStudioContent content, DockPanel dock = null, DockState? dockState = null)
        {
            if (content is DockContent dockContent)
            {
                if (dockState != null)
                {
                    dockContent.Show(dock, dockState.Value);
                }
                else
                {
                    dockContent.Show(dock);
                }
            }
            else
            {
                ((Form)content).Show();
            }
        }
    }
}
