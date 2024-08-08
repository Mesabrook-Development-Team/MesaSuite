using MesaSuite.Common.Wizard;
using MesaSuite.Models.mesasys;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite.NotificationsAndTasks.NotificationEventWizard
{
    [ToolboxItem(false)]
    public partial class FinishStep : UserControl, IWizardStep<NotificationEvent>
    {
        public FinishStep()
        {
            InitializeComponent();
        }

        public string NavigationName => "Finish";

        public Control Control => this;

        public Task Commit(NotificationEvent data)
        {
            return Task.CompletedTask;
        }

        Task IWizardStep<NotificationEvent>.Load(NotificationEvent data)
        {
            return Task.CompletedTask;
        }

        Task<List<string>> IWizardStep<NotificationEvent>.Validate()
        {
            return Task.FromResult(new List<string>());
        }
    }
}
