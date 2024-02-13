using CompanyStudio.Wizard;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyStudio.Wizard.DemoWizard
{
    public partial class NameStep : UserControl, IWizardStep<WhatsYourNameData>
    {
        public NameStep()
        {
            InitializeComponent();
        }

        public string NavigationName => "Name";

        public Control Control => this;

        Task IWizardStep<WhatsYourNameData>.Commit(WhatsYourNameData data)
        {
            data.Name = txtName.Text;
            return Task.CompletedTask;
        }

        Task IWizardStep<WhatsYourNameData>.Load(WhatsYourNameData data)
        {
            txtName.Text = data.Name;
            return Task.CompletedTask;
        }

        Task<List<string>> IWizardStep<WhatsYourNameData>.Validate()
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errors.Add("Please enter your name");
            }

            return Task.FromResult(errors);
        }
    }
}
