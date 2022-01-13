using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace GovernmentPortal.Officials
{
    public partial class OfficialExplorerControl : UserControl, IExplorerControl<Official>
    {
        public event EventHandler IsDirtyChanged;
        
        public long GovernmentID { get; set; }

        public bool GovCanMintCurrency { get; set; }

        private bool _suppressDirty;
        public OfficialExplorerControl()
        {
            InitializeComponent();
        }

        private bool _isDirty;
        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                _isDirty = value;
                IsDirtyChanged?.Invoke(this, new EventArgs());
            }
        }

        public Official Model { get; set; }

        private frmGenericExplorer<Official> _explorer = null;
        public frmGenericExplorer<Official> Explorer { set => _explorer = value; }

        public async void OnDeleteClicked()
        {
            if (Model == null)
            {
                MessageBox.Show("Cannot fire an unhired Official.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                /*
                 Manager:           "Would you like a job, starting now?"
                 Official Prospect: "Boy would I!"
                 Manager:           "You're fired."
                */
                return;
            }

            if (MessageBox.Show("Are you sure you want to fire this Official?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            DeleteData delete = new DeleteData(DataAccess.APIs.GovernmentPortal, $"Official/Delete/{Model.OfficialID}");
            delete.Headers.Add("GovernmentID", GovernmentID.ToString());
            await delete.Execute();

            if (delete.RequestSuccessful)
            {
                IsDirty = false;
                _explorer.LoadAllItems(true);
                Dispose();
                return;
            }
            loader.Visible = false;
        }

        public async void OnSaveClicked()
        {
            if (cboUsers.SelectedItem == null)
            {
                this.ShowError("User is a required field.");
                return;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                DropDownItem<User> selectedUser = cboUsers.SelectedItem.Cast<DropDownItem<User>>();
                if (Model == null)
                {
                    Model = new Official();
                    Model.GovernmentID = GovernmentID;
                }

                Model.UserID = selectedUser.Object.UserID;
                Model.ManageEmails = chkEmails.Checked;
                Model.ManageOfficials = chkOfficials.Checked;
                Model.ManageAccounts = chkManageAccounts.Checked;
                Model.CanMintCurrency = GovCanMintCurrency ? chkMintCurrency.Checked : false;

                if (Model.OfficialID == default(long))
                {
                    PostData post = new PostData(DataAccess.APIs.GovernmentPortal, "Official/Post", Model);
                    post.Headers.Add("GovernmentID", GovernmentID.ToString());
                    Official returnedOfficial = await post.Execute<Official>();
                    if (post.RequestSuccessful)
                    {
                        Model = returnedOfficial;
                        IsDirty = false;
                    }
                }
                else
                {
                    PutData put = new PutData(DataAccess.APIs.GovernmentPortal, "Official/Put", Model);
                    put.Headers.Add("GovernmentID", GovernmentID.ToString());
                    Official returnedOfficial = await put.Execute<Official>();
                    if (put.RequestSuccessful)
                    {
                        Model = returnedOfficial;
                        IsDirty = false;
                    }
                }

                _explorer.LoadAllItems(true, selectedUser.Text);
                Dispose();
            }
            finally
            {
                if (!IsDisposed)
                {
                    loader.Visible = false;
                }
            }
        }

        private async void OfficialExplorerControl_Load(object sender, EventArgs e)
        {
            _suppressDirty = true;
            loader.BringToFront();
            loader.Visible = true;

            chkMintCurrency.Enabled = GovCanMintCurrency;

            GetData getUsers = new GetData(DataAccess.APIs.GovernmentPortal, "Official/Candidates");
            getUsers.Headers.Add("GovernmentID", GovernmentID.ToString());
            List<User> users = await getUsers.GetObject<List<User>>();
            if (users != null)
            {
                foreach (User user in users)
                {
                    cboUsers.Items.Add(new DropDownItem<User>(user, user.Username));
                }
            }

            if (Model != null && Model.OfficialID != 0)
            {
                cboUsers.Items.Insert(0, new DropDownItem<User>(new User() { UserID = Model.UserID, Username = Model.OfficialName }, Model.OfficialName));
                cboUsers.SelectedIndex = 0;
                cboUsers.Enabled = false;

                chkEmails.Checked = Model.ManageEmails;
                chkOfficials.Checked = Model.ManageOfficials;
                chkManageAccounts.Checked = Model.ManageAccounts;
                chkMintCurrency.Checked = Model.CanMintCurrency;
            }

            loader.Visible = false;
            _suppressDirty = false;

            PermissionsManager.OnPermissionChange += PermissionsManager_OnPermissionChange;
        }

        private void PermissionsManager_OnPermissionChange(object sender, PermissionsManager.PermissionChangeEventArgs e)
        {
            if (e.GovernmentID == GovernmentID && e.Permission == PermissionsManager.Permissions.ManageOfficials && !e.Value)
            {
                _explorer.ForceClose();
            }
        }

        private void FormValueChanged(object sender, EventArgs e)
        {
            if (_suppressDirty)
            {
                return;
            }

            IsDirty = true;
        }
    }
}
