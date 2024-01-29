using CompanyStudio.Wizard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyStudio.Store.ClonePrices
{
    public partial class WelcomeStep : UserControl, IWizardStep<ClonePricesWizardData>
    {
        public WelcomeStep()
        {
            InitializeComponent();
        }

        public string NavigationName => "Welcome";

        public Control Control => this;

        async Task IWizardStep<ClonePricesWizardData>.Commit(ClonePricesWizardData data)
        {
            data.DefaultAdd = chkDefaultAdd.Checked;
            data.DefaultUpdate = chkDefaultUpdate.Checked;
            data.DefaultDelete = chkDefaultDelete.Checked;
        }

        async Task IWizardStep<ClonePricesWizardData>.Load(ClonePricesWizardData data)
        {
            chkDefaultAdd.Checked = data.DefaultAdd;
            chkDefaultUpdate.Checked = data.DefaultUpdate;
            chkDefaultDelete.Checked = data.DefaultDelete;
        }

        async Task<List<string>> IWizardStep<ClonePricesWizardData>.Validate()
        {
            return new List<string>();
        }
    }
}
