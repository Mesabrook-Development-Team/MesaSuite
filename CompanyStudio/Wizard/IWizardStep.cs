using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyStudio.Wizard
{
    public interface IWizardStep<TData> where TData : class, new()
    {
        string NavigationName { get; }

        Control Control { get; }

        Task<List<string>> Validate();

        Task Load(TData data);

        Task Commit(TData data);
    }
}
