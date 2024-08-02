using MesaSuite.Common.Data;
using MesaSuite.Models.company;
using MesaSuite.Models.gov;
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

namespace MesaSuite.NotificationsAndTasks
{
    public partial class frmNotificationCenter : Form
    {
        public frmNotificationCenter()
        {
            InitializeComponent();
        }

        private async void frmNotificationCenter_Load(object sender, EventArgs e)
        {
            await ReloadOptions();
        }

        private async Task ReloadOptions()
        {
            optionsLoader.Visible = true;

            tabGeneral.TabPages.Clear();
            tabCompany.TabPages.Clear();
            tabGovernment.TabPages.Clear();
            tabFleetTracking.TabPages.Clear();

            GetData get = new GetData(DataAccess.APIs.SystemManagement, "NotificationEvent/GetAllForUser");
            List<NotificationEvent> notificationEvents = await get.GetObject<List<NotificationEvent>>() ?? new List<NotificationEvent>();
            get = new GetData(DataAccess.APIs.SystemManagement, "NotificationSubscriber/GetAll");
            List<NotificationSubscriber> notificationSubscribers = await get.GetObject<List<NotificationSubscriber>>() ?? new List<NotificationSubscriber>();
            get = new GetData(DataAccess.APIs.SystemManagement, "Company/GetAllForUser");
            List<Company> companies = await get.GetObject<List<Company>>() ?? new List<Company>();
            get = new GetData(DataAccess.APIs.SystemManagement, "Location/GetAllForUser");
            List<Location> locations = await get.GetObject<List<Location>>() ?? new List<Location>();
            get = new GetData(DataAccess.APIs.SystemManagement, "Government/GetAllForUser");
            List<Government> governments = await get.GetObject<List<Government>>() ?? new List<Government>();

            foreach(IGrouping<NotificationEvent.ScopeTypes, NotificationEvent> notificationsByScope in notificationEvents.GroupBy(ne => ne.ScopeType))
            {
                TabControl control;
                switch(notificationsByScope.Key)
                {
                    case NotificationEvent.ScopeTypes.Global:
                        control = tabGeneral;
                        break;
                    case NotificationEvent.ScopeTypes.Company:
                    case NotificationEvent.ScopeTypes.Location:
                        control = tabCompany;
                        break;
                    case NotificationEvent.ScopeTypes.Fleet:
                        control = tabFleetTracking;
                        break;
                    case NotificationEvent.ScopeTypes.Government:
                        control = tabGovernment;
                        break;
                    default:
                        continue;
                }

                control.Parent.Visible = true;

                foreach(NotificationEvent notificationEvent in notificationsByScope)
                {
                    TabPage tabPage = control.TabPages.OfType<TabPage>().FirstOrDefault(tp => tp.Text.Equals(notificationEvent.Category, StringComparison.OrdinalIgnoreCase));
                    if (tabPage == null)
                    {
                        tabPage = new TabPage(notificationEvent.Category);
                        control.TabPages.Add(tabPage);
                    }

                    Panel table = tabPage.Controls.OfType<Panel>().FirstOrDefault();
                    if (table == null)
                    {
                        table = new Panel();
                        tabPage.Controls.Add(table);
                        table.BorderStyle = BorderStyle.FixedSingle;
                        table.Dock = DockStyle.Fill;
                        table.AutoScroll = true;
                    }

                    NotificationOptionRow row = new NotificationOptionRow()
                    {
                        NotificationEvent = notificationEvent,
                        Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                        NotificationSubscriber = notificationSubscribers.FirstOrDefault(ns => ns.NotificationEventID == notificationEvent.NotificationEventID),
                        Companies = companies,
                        Locations = locations,
                        Governments = governments
                    };
                    table.Controls.Add(row);
                    row.Top = table.Controls.OfType<Control>().Where(ctrl => ctrl != row).Any() ? table.Controls.OfType<Control>().Where(ctrl => ctrl != row).Max(ctrl => ctrl.Bottom) : 0;
                    row.Width = table.Width;
                    row.ClientSizeChanged += NotificationOptionRow_ClientSizeChanged;
                }
            }

            optionsLoader.Visible = false;
        }

        private void NotificationOptionRow_ClientSizeChanged(object sender, EventArgs e)
        {
            NotificationOptionRow row = sender as NotificationOptionRow;
            NotificationOptionRow previousRow = row;

            foreach(NotificationOptionRow ctrl in row.Parent.Controls.OfType<NotificationOptionRow>().Where(r => r.Top > row.Top).OrderBy(r => r.Top))
            {
                ctrl.Top = previousRow.Bottom;
                previousRow = ctrl;
            }
        }
    }
}
