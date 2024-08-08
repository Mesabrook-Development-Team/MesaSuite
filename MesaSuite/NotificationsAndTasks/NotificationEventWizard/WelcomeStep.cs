using MesaSuite.Common.Wizard;
using MesaSuite.Models.mesasys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite.NotificationsAndTasks.NotificationEventWizard
{
    [ToolboxItem(false)]
    public partial class WelcomeStep : UserControl, IWizardStep<NotificationEvent>
    {
        public WelcomeStep()
        {
            InitializeComponent();
        }

        public string NavigationName => "Intro";
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
