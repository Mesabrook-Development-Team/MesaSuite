using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite.Common.Wizard
{
    public class EndStep<TData> : IWizardStep<TData> where TData : class, new()
    {
        public string NavigationName => "End";

        public Control Control => new Control();

        public WizardController<TData> Controller { set => _ = value; }

        public async Task Commit(TData data)
        {
            
        }

        public async Task Load(TData data)
        {
            
        }

        public async Task<List<string>> Validate()
        {
            return new List<string>();
        }
    }
}
