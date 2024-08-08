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
    public partial class CustomNotificationRow : UserControl
    {
        public NotificationEvent NotificationEvent { get; set; }

        public CustomNotificationRow()
        {
            InitializeComponent();
        }

        private void CustomNotificationRow_Load(object sender, EventArgs e)
        {
            lblName.Text = NotificationEvent.Name;
            lblInfo.Text = $"Category: {NotificationEvent.Category}\r\nScope: {NotificationEvent.ScopeType}\r\nPublished: {(NotificationEvent.IsPublished ? "Yes" : "No")}";
        }
    }
}
