using CompanyStudio.Properties;
using CompanyStudio.Wizard;
using MesaSuite.Common.Collections;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyStudio.Wizard.DemoWizard
{
    internal class WhatsYourNameController : WizardController<WhatsYourNameData>
    {
        protected override string WindowTitle => "What's your name wizard";

        protected override Image Logo => Resources.sport_raquet;

        protected override string ScreenTitle => "What's Your Name?";

        protected override string RunButtonCaption => "Gib Name";

        protected override MultiMap<IWizardStep<WhatsYourNameData>, StepConnection> GetConnections()
        {
            MultiMap<IWizardStep<WhatsYourNameData>, StepConnection> connections = new MultiMap<IWizardStep<WhatsYourNameData>, StepConnection>();

            NameStep nameStep = new NameStep();
            AgeStep ageStep = new AgeStep();

            connections.Add(nameStep, new StepConnection(ageStep));
            connections.Add(ageStep, new StepConnection(new EndStep<WhatsYourNameData>()));

            return connections;
        }

        protected override Task WizardComplete(WhatsYourNameData data)
        {
            MessageBox.Show($"Your name is {data.Name} and you are {data.Age} years old");

            return Task.CompletedTask;
        }
    }
}
