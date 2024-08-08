using MesaSuite.Common.Utility;
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
    public partial class CollectingInfoStep : UserControl, IWizardStep<NotificationEvent>
    {
        public CollectingInfoStep()
        {
            InitializeComponent();

            cboScopes.Items.Clear();
            foreach(NotificationEvent.ScopeTypes item in Enum.GetValues(typeof(NotificationEvent.ScopeTypes)))
            {
                cboScopes.Items.Add(new DropDownItem<NotificationEvent.ScopeTypes>(item, item.ToString()));
            }
        }

        public string NavigationName => "Collecting Info";

        public Control Control => this;

        public Task Commit(NotificationEvent data)
        {
            data.Name = txtName.Text;
            data.ScopeType = (cboScopes.SelectedItem as DropDownItem<NotificationEvent.ScopeTypes>)?.Object ?? NotificationEvent.ScopeTypes.Global ;
            return Task.CompletedTask;
        }

        Task IWizardStep<NotificationEvent>.Load(NotificationEvent data)
        {
            txtName.Text = data.Name;
            cboScopes.SelectedItem = cboScopes.Items.OfType<DropDownItem<NotificationEvent.ScopeTypes>>().FirstOrDefault(x => x.Object == data.ScopeType);
            return Task.CompletedTask;
        }

        Task<List<string>> IWizardStep<NotificationEvent>.Validate()
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errors.Add("Name is required");
            }

            if (cboScopes.SelectedItem == null)
            {
                errors.Add("Scope is required");
            }

            return Task.FromResult(errors);
        }
    }
}
