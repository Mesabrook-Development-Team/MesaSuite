using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;
using MesaSuite.Models.company;
using MesaSuite.Models.gov;
using MesaSuite.Models.mesasys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MesaSuite.NotificationsAndTasks
{
    public partial class NotificationOptionRow : UserControl
    {
        private const string ENTITY_LABEL_FORMAT = "Used in {0} {1}(s)";
        public NotificationOptionRow()
        {
            InitializeComponent();
        }

        private NotificationEvent _notificationEvent;
        public NotificationEvent NotificationEvent
        {
            get => _notificationEvent;
            set
            {
                _notificationEvent = value;
                lblText.Text = _notificationEvent.Name;
            }
        }

        public NotificationSubscriber NotificationSubscriber { get; set; }

        public List<Company> Companies { get; set; } = new List<Company>();
        public List<Location> Locations { get; set; } = new List<Location>();
        public List<Government> Governments { get; set; } = new List<Government>();

        private void foreverToggle1_ClientSizeChanged(object sender, EventArgs e)
        {
            tglEnabled.Top = lblText.Top + (lblText.Height - tglEnabled.Height) / 2;
        }

        private bool isLoading = false;
        private void NotificationOptionRow_Load(object sender, EventArgs e)
        {
            try
            {
                isLoading = true;
                chkEntities.Items.Clear();
                chkEntities.Items.Add("(Select All)");
                switch (NotificationEvent.ScopeType)
                {
                    case NotificationEvent.ScopeTypes.Global:
                        lblEntityLabel.Visible = false;
                        separator1.Visible = false;
                        pnlCollapseButton.Visible = false;
                        Height = lblText.Bottom;
                        break;
                    case NotificationEvent.ScopeTypes.Company:
                        foreach (Company company in Companies.OrderBy(c => c.Name))
                        {
                            int index = chkEntities.Items.Add(DropDownItem.Create(company, company.Name));
                            if (NotificationSubscriber?.NotificationSubscriberEntities?.Any(es => es.CompanyID == company.CompanyID) ?? false)
                            {
                                chkEntities.SetItemChecked(index, true);
                            }
                        }
                        break;
                    case NotificationEvent.ScopeTypes.Fleet:
                        foreach (Company company in Companies.OrderBy(c => c.Name))
                        {
                            int index = chkEntities.Items.Add(DropDownItem.Create(company, company.Name + " (Company)"));
                            if (NotificationSubscriber?.NotificationSubscriberEntities?.Any(es => es.CompanyID == company.CompanyID) ?? false)
                            {
                                chkEntities.SetItemChecked(index, true);
                            }
                        }

                        foreach (Government government in Governments.OrderBy(g => g.Name))
                        {
                            int index = chkEntities.Items.Add(DropDownItem.Create(government, government.Name + " (Government)"));
                            if (NotificationSubscriber?.NotificationSubscriberEntities?.Any(es => es.GovernmentID == government.GovernmentID) ?? false)
                            {
                                chkEntities.SetItemChecked(index, true);
                            }
                        }
                        break;
                    case NotificationEvent.ScopeTypes.Government:
                        foreach (Government government in Governments.OrderBy(g => g.Name))
                        {
                            int index = chkEntities.Items.Add(DropDownItem.Create(government, government.Name));
                            if (NotificationSubscriber?.NotificationSubscriberEntities?.Any(es => es.GovernmentID == government.GovernmentID) ?? false)
                            {
                                chkEntities.SetItemChecked(index, true);
                            }
                        }
                        break;
                    case NotificationEvent.ScopeTypes.Location:
                        foreach (Location location in Locations.OrderBy(l => l.Company.Name).ThenBy(l => l.Name))
                        {
                            int index = chkEntities.Items.Add(DropDownItem.Create(location, location.Company.Name + " - " + location.Name));
                            if (NotificationSubscriber?.NotificationSubscriberEntities?.Any(es => es.LocationID == location.LocationID) ?? false)
                            {
                                chkEntities.SetItemChecked(index, true);
                            }
                        }
                        break;
                }

                if (NotificationSubscriber != null)
                {
                    tglEnabled.Checked = true;
                    cmdCustomize.Enabled = true;
                    lblEntityLabel.Cursor = Cursors.Hand;
                    separator1.Cursor = Cursors.Hand;
                    pnlCollapseButton.Cursor = Cursors.Hand;
                    pnlCollapseButton.BackgroundImage = (NotificationSubscriber?.NotificationSubscriberEntities?.Count() ?? 0) > 0 ? Properties.Resources.arrow_up : Properties.Resources.error;
                }

                SetEntityLabel(NotificationSubscriber?.NotificationSubscriberEntities?.Count() ?? 0);
            }
            finally
            {
                isLoading = false;
            }
        }

        private void SetEntityLabel(int count)
        {
            string entityName = "";
            switch(NotificationEvent.ScopeType)
            {
                case NotificationEvent.ScopeTypes.Company:
                    entityName = "Company";
                    break;
                case NotificationEvent.ScopeTypes.Fleet:
                    entityName = "Entity";
                    break;
                case NotificationEvent.ScopeTypes.Government:
                    entityName = "Government";
                    break;
                case NotificationEvent.ScopeTypes.Location:
                    entityName = "Location";
                    break;
            }

            lblEntityLabel.Text = string.Format(ENTITY_LABEL_FORMAT, count, entityName);
        }

        private async void tglEnabled_CheckedChanged(object sender)
        {
            if (!tglEnabled.Enabled)
            {
                return;
            }

            try
            {
                tglEnabled.Enabled = false;
                cmdCustomize.Enabled = false;
                if (!tglEnabled.Checked && NotificationSubscriber != null)
                {
                    if (this.Confirm("Unsubscribing from this notification will clear your customized settings.\r\n\r\nDo you want to continue?"))
                    {
                        DeleteData delete = new DeleteData(DataAccess.APIs.SystemManagement, "NotificationSubscriber/Delete/" + NotificationSubscriber.NotificationSubscriberID);
                        await delete.Execute();

                        if (delete.RequestSuccessful)
                        {
                            NotificationSubscriber = null;
                        }
                        else
                        {
                            tglEnabled.Checked = true;
                        }
                    }
                    else
                    {
                        tglEnabled.Checked = true;
                    }
                }
                else if (tglEnabled.Checked)
                {
                    NotificationSubscriber = new NotificationSubscriber();
                    NotificationSubscriber.NotificationEventID = NotificationEvent.NotificationEventID;
                    NotificationSubscriber.NotificationText = NotificationEvent.DefaultNotificationText;

                    PostData post = new PostData(DataAccess.APIs.SystemManagement, "NotificationSubscriber/Post", NotificationSubscriber);
                    NotificationSubscriber notificationSubscriber = await post.Execute<NotificationSubscriber>();
                    if (post.RequestSuccessful)
                    {
                        NotificationSubscriber = notificationSubscriber;
                        if (this.Confirm("It is highly recommended to customize your notification.\r\n\r\nDo you want to do that now?"))
                        {
                            cmdCustomize_Click(sender, null);
                        }
                    }
                    else
                    {
                        tglEnabled.Checked = false;
                    }
                }
            }
            finally
            {
                tglEnabled.Enabled = true;
                cmdCustomize.Enabled = tglEnabled.Checked;
            }

            if (tglEnabled.Checked)
            {
                lblEntityLabel.Cursor = Cursors.Hand;
                separator1.Cursor = Cursors.Hand;
                pnlCollapseButton.Cursor = Cursors.Hand;
                pnlCollapseButton.BackgroundImage = (NotificationSubscriber?.NotificationSubscriberEntities?.Count() ?? 0) > 0 ? Properties.Resources.arrow_up : Properties.Resources.error;
                SetEntityLabel(NotificationSubscriber?.NotificationSubscriberEntities?.Count() ?? 0);
            }
            else
            {
                if (!isCollapsed)
                {
                    ToggleCollapse(true);
                }

                lblEntityLabel.Cursor = Cursors.No;
                separator1.Cursor = Cursors.No;
                pnlCollapseButton.Cursor = Cursors.No;
                pnlCollapseButton.BackgroundImage = Properties.Resources.delete;
                SetEntityLabel(0);
                for(int i = 0; i < chkEntities.Items.Count; i++)
                {
                    chkEntities.SetItemChecked(i, false);
                }
            }
        }

        private void cmdCustomize_Click(object sender, EventArgs e)
        {
            frmCustomizeNotification customize = new frmCustomizeNotification();
            customize.NotificationEvent = NotificationEvent;
            customize.NotificationSubscriber = NotificationSubscriber;
            customize.FormClosed += delegate { RefreshNotificationSubscriber(); };
            customize.Show();
        }

        private async void RefreshNotificationSubscriber()
        {
            GetData get = new GetData(DataAccess.APIs.SystemManagement, "NotificationSubscriber/Get/" + NotificationSubscriber.NotificationSubscriberID);
            NotificationSubscriber = await get.GetObject<NotificationSubscriber>();
        }

        private const int _collapseHeight = 57;
        private const int _expandedHeight = 157;
        private void pnlCollapseButton_Click(object sender, EventArgs e)
        {
            ToggleCollapse();
        }

        private bool isCollapsed = true;
        private void ToggleCollapse(bool ignoreEnabledCheck = false)
        {
            if (!ignoreEnabledCheck && !tglEnabled.Checked)
            {
                return;
            }

            if (isCollapsed)
            {
                Height += 100;
                chkEntities.Visible = true;
                chkEntities.Height = 100;
                isCollapsed = false;
                pnlCollapseButton.BackgroundImage = Properties.Resources.arrow_down;
            }
            else
            {
                Height -= 100;
                chkEntities.Visible = false;
                pnlCollapseButton.BackgroundImage = (NotificationSubscriber?.NotificationSubscriberEntities?.Count() ?? 0) > 0 ? Properties.Resources.arrow_up : Properties.Resources.error;
                isCollapsed = true;
            }
        }

        private void separator1_Click(object sender, EventArgs e)
        {
            ToggleCollapse();
        }

        private void lblEntityLabel_Click(object sender, EventArgs e)
        {
            ToggleCollapse();
        }

        private async void chkEntities_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isLoading || NotificationSubscriber == null)
            {
                return;
            }

            if (e.NewValue == CheckState.Checked)
            {
                if (e.Index == 0)
                {
                    for(int i = 1; i < chkEntities.Items.Count; i++)
                    {
                        chkEntities.SetItemChecked(i, true);
                    }

                    return;
                }
                else
                {
                    bool allChecked = true;
                    for(int i = 1; i < chkEntities.Items.Count; i++)
                    {
                        allChecked &= chkEntities.GetItemChecked(i);
                    }

                    chkEntities.SetItemChecked(0, allChecked);
                }

                NotificationSubscriberEntity newEntity = new NotificationSubscriberEntity();
                newEntity.NotificationSubscriberID = NotificationSubscriber.NotificationSubscriberID;
                newEntity.CompanyID = (chkEntities.Items[e.Index] as DropDownItem<Company>)?.Object?.CompanyID;
                newEntity.GovernmentID = (chkEntities.Items[e.Index] as DropDownItem<Government>)?.Object?.GovernmentID;
                newEntity.LocationID = (chkEntities.Items[e.Index] as DropDownItem<Location>)?.Object?.LocationID;
                
                PostData post = new PostData(DataAccess.APIs.SystemManagement, "NotificationSubscriberEntity/Post", newEntity);
                newEntity = await post.Execute<NotificationSubscriberEntity>();
                if (post.RequestSuccessful)
                {
                    NotificationSubscriber.NotificationSubscriberEntities.Add(newEntity);
                    SetEntityLabel(NotificationSubscriber.NotificationSubscriberEntities.Count());
                }
                else
                {
                    chkEntities.SetItemChecked(e.Index, false);
                }
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                if (e.Index == 0)
                {
                    bool allCurrentlyChecked = true;
                    for (int i = 1; i < chkEntities.Items.Count; i++)
                    {
                        allCurrentlyChecked &= chkEntities.GetItemChecked(i);
                    }

                    if (allCurrentlyChecked)
                    {
                        for (int i = 1; i < chkEntities.Items.Count; i++)
                        {
                            chkEntities.SetItemChecked(i, false);
                        }
                    }
                }
                else
                {
                    isLoading = true;
                    chkEntities.SetItemChecked(0, false);
                    isLoading = false;
                }

                long? companyID = (chkEntities.Items[e.Index] as DropDownItem<Company>)?.Object?.CompanyID;
                long? governmentID = (chkEntities.Items[e.Index] as DropDownItem<Government>)?.Object?.GovernmentID;
                long? locationID = (chkEntities.Items[e.Index] as DropDownItem<Location>)?.Object?.LocationID;

                NotificationSubscriberEntity entityToDelete = NotificationSubscriber.NotificationSubscriberEntities.Where(nse => nse.CompanyID == companyID && nse.GovernmentID == governmentID && nse.LocationID == locationID).FirstOrDefault();
                if (entityToDelete != null)
                {
                    DeleteData delete = new DeleteData(DataAccess.APIs.SystemManagement, "NotificationSubscriberEntity/Delete/" + entityToDelete.NotificationSubscriberEntityID);
                    await delete.Execute();

                    if (delete.RequestSuccessful)
                    {
                        NotificationSubscriber.NotificationSubscriberEntities.Remove(entityToDelete);
                        SetEntityLabel(NotificationSubscriber.NotificationSubscriberEntities.Count());
                    }
                    else
                    {
                        chkEntities.SetItemChecked(e.Index, true);
                    }
                }
            }
        }
    }
}
