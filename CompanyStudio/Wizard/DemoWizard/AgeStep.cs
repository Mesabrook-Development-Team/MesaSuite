using CompanyStudio.Wizard;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyStudio.Wizard.DemoWizard
{
    public partial class AgeStep : UserControl, IWizardStep<WhatsYourNameData>
    {
        public AgeStep()
        {
            InitializeComponent();
        }

        public string NavigationName => "Age";

        public Control Control => this;

        Task IWizardStep<WhatsYourNameData>.Commit(WhatsYourNameData data)
        {
            data.Age = txtAge.Text;
            return Task.CompletedTask;
        }

        Task IWizardStep<WhatsYourNameData>.Load(WhatsYourNameData data)
        {
            txtAge.Text = data.Age;
            return Task.CompletedTask;
        }

        Task<List<string>> IWizardStep<WhatsYourNameData>.Validate()
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrEmpty(txtAge.Text))
            {
                errors.Add("Please enter your age");
            }

            if (!int.TryParse(txtAge.Text, out _))
            {
                errors.Add("Age must be a number");
            }

            return Task.FromResult(errors);
        }
    }
}
