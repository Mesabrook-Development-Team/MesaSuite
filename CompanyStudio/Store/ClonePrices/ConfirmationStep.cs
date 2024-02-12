using CompanyStudio.Extensions;
using CompanyStudio.Models;
using CompanyStudio.Wizard;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyStudio.Store.ClonePrices
{
    public partial class ConfirmationStep : UserControl, IWizardStep<ClonePricesWizardData>
    {
        public ConfirmationStep()
        {
            InitializeComponent();
        }

        public string NavigationName => "Confirm";

        public Control Control => this;

        public Task Commit(ClonePricesWizardData data) { return Task.CompletedTask; }

        async Task IWizardStep<ClonePricesWizardData>.Load(ClonePricesWizardData data)
        {
            StringBuilder builder = new StringBuilder();

            GetData get;
            foreach((long?, long?) companyIDLocationID in data.CompanyIDLocationIDDestinations)
            {
                get = new GetData(DataAccess.APIs.CompanyStudio, "Location/Get/" + companyIDLocationID.Item2);
                get.AddLocationHeader(companyIDLocationID.Item1, companyIDLocationID.Item2);
                Location location = await get.GetObject<Location>();
                builder.AppendLine(location != null ? $"{location.Name} ({location.Company.Name})" : "???");

                builder.Append("├─Items to add: ");
                builder.AppendLine(data.AddedItemsByLocationID.GetOrDefault(companyIDLocationID.Item2, new List<long?>()).Count.ToString());
                builder.Append("├─Items to update: ");
                builder.AppendLine(data.UpdatedItemsByLocationID.GetOrDefault(companyIDLocationID.Item2, new List<long?>()).Count.ToString()); 
                builder.Append("└─Items to delete: ");
                builder.AppendLine(data.DeletedItemsByLocationID.GetOrDefault(companyIDLocationID.Item2, new List<long?>()).Count.ToString());
                builder.AppendLine();
            }

            txtChanges.Text = builder.ToString();
        }

        Task<List<string>> IWizardStep<ClonePricesWizardData>.Validate() { return Task.FromResult(new List<string>()); }
    }
}
