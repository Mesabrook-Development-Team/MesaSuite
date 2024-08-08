using MesaSuite.Common.Collections;
using MesaSuite.Common.Wizard;
using MesaSuite.Models.mesasys;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace MesaSuite.NotificationsAndTasks.NotificationEventWizard
{
    public class NotificationEventWizardController : WizardController<NotificationEvent>
    {
        protected override string WindowTitle => "New Notification Event";

        protected override Image Logo => Properties.Resources.add;

        protected override string ScreenTitle => "New Notification Event";

        protected override string RunButtonCaption => "Create";

        protected override Type WizardShellType => typeof(frmNotificationEventWizardShell);

        protected override MultiMap<IWizardStep<NotificationEvent>, StepConnection> GetConnections()
        {
            MultiMap<IWizardStep<NotificationEvent>, StepConnection> connections = new MultiMap<IWizardStep<NotificationEvent>, StepConnection>();

            WelcomeStep welcomeStep = new WelcomeStep();
            CollectingInfoStep collectingInfoStep = new CollectingInfoStep();
            FinishStep finishStep = new FinishStep();

            connections.Add(welcomeStep, new StepConnection(collectingInfoStep));
            connections.Add(collectingInfoStep, new StepConnection(finishStep));
            connections.Add(finishStep, new StepConnection(new EndStep<NotificationEvent>()));

            return connections;
        }

        protected override Task WizardComplete(NotificationEvent data)
        {
            return Task.CompletedTask;
        }
    }
}
