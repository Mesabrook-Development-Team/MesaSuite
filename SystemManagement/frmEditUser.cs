using MesaSuite.Common.Collections;
using MesaSuite.Common.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemManagement.Models;

namespace SystemManagement
{
    public partial class frmEditUser : Form
    {
        public long? UserID { get; set; }
        private bool _inactivityWarningServed = false;
        private bool _inactivityDOINotificationServed = false;
        public frmEditUser()
        {
            InitializeComponent();
        }

        private async void frmUser_Load(object sender, EventArgs e)
        {
            imlSmall.Images.Add("program", Properties.Resources.program);
            imlSmall.Images.Add("security", Properties.Resources.security);
            imlLarge.Images.Add("program", Properties.Resources.program_large);
            imlLarge.Images.Add("security", Properties.Resources.security_large);

            if (UserID == null)
            {
                throw new ArgumentNullException("UserID is required");
            }

            GetData getUserInfo = new GetData(DataAccess.APIs.SystemManagement, "User/GetUser");
            getUserInfo.QueryString = new MultiMap<string, string>()
            {
                { "userid", UserID.Value.ToString() }
            };
            User user = await getUserInfo.GetObject<User>();

            if (user == null)
            {
                return;
            }

            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtDiscordID.Text = user.DiscordID;
            txtLastActivity.Text = user.LastActivity?.ToString("MM/dd/yyyy HH:mm");
            txtLastActivity.Tag = user.LastActivity;
            txtLastActivityReason.Text = user.LastActivityReason;

            _inactivityWarningServed = user.InactivityWarningServed;
            _inactivityDOINotificationServed = user.InactivityDOINotificationServed;

            if (user.LastActivity != null && user.LastActivity.Value.AddMonths(1).AddDays(-2) < DateTime.Now)
            {
                txtLastActivity.BackColor = Color.Yellow;
            }

            await LoadPrograms();
            await LoadSecurityGroups(user);

            txtFirstName.Focus();

            Enabled = true;
        }

        private async Task LoadPrograms()
        {
            lstPrograms.Items.Clear();

            GetData getUserInfo = new GetData(DataAccess.APIs.SystemManagement, "Program/GetProgramsForUser");
            getUserInfo.QueryString = new MultiMap<string, string>()
            {
                { "userid", UserID.Value.ToString() }
            };
            List<Models.Program> programs = await getUserInfo.GetObject<List<Models.Program>>() ?? new List<Models.Program>();

            foreach (Models.Program program in programs)
            {
                AddProgram(program);
            }
        }

        private void AddProgram(Models.Program program)
        {
            ListViewItem item = new ListViewItem();
            item.Text = program.Name;
            item.Tag = program.ProgramID;
            item.ImageKey = "program";
            item.Group = lstPrograms.Groups["grpPrograms"];

            lstPrograms.Items.Add(item);
        }

        private async Task LoadSecurityGroups(User user = null)
        {
            if (user == null)
            {
                GetData getUser = new GetData(DataAccess.APIs.SystemManagement, "User/GetUser");
                getUser.QueryString = new MultiMap<string, string>()
                {
                    { "userid", UserID.Value.ToString() }
                };
                user = await getUser.GetObject<User>();
            }

            if (user == null)
            {
                return;
            }

            lstSecurityGroups.Items.Clear();
            foreach(string securityGroup in user.MemberOf)
            {
                ListViewItem item = new ListViewItem();
                item.Text = securityGroup;
                item.ImageKey = "security";

                lstSecurityGroups.Items.Add(item);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            txtEmail.Text = $"{txtUsername.Text}@mesabrook.com";
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            Enabled = false;

            User user = new User()
            {
                UserID = UserID.Value,
                Username = txtUsername.Text,
                Email = txtEmail.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                DiscordID = txtDiscordID.Text,
                LastActivity = (DateTime?)txtLastActivity.Tag,
                LastActivityReason = txtLastActivityReason.Text,
                InactivityWarningServed = _inactivityWarningServed,
                InactivityDOINotificationServed = _inactivityDOINotificationServed
            };

            PutData data = new PutData(DataAccess.APIs.SystemManagement, "User/UpdateUser", user);
            await data.ExecuteNoResult();
            if (!data.RequestSuccessful)
            {
                Enabled = true;
                return;
            }

            Close();
        }

        private void cmdSelectPerms_Click(object sender, EventArgs e)
        {
            frmSelectPrograms select = new frmSelectPrograms();
            select.UserID = UserID;
            select.FormClosed += ProgramsFormClosed;
            select.Show();
        }

        private async void ProgramsFormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = (Form)sender;
            form.FormClosed -= ProgramsFormClosed;

            await LoadPrograms();
        }

        private void lstPrograms_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstPrograms.SelectedItems.Count > 0 && e.KeyCode == Keys.Delete && MessageBox.Show("Are you sure you want to remove these programs from this user?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DeletePrograms();
            }
        }

        private async void DeletePrograms()
        {
            Enabled = false;

            foreach(ListViewItem item in lstPrograms.Items)
            {
                long programID = (long)item.Tag;

                DeleteData deleteData = new DeleteData(DataAccess.APIs.SystemManagement, "Program/DeleteProgramForUser");
                deleteData.QueryString = new Dictionary<string, string>()
                {
                    { "userid", UserID.Value.ToString() },
                    { "programid", programID.ToString() }
                };
                await deleteData.Execute();
            }

            await LoadPrograms();

            Enabled = true;
        }

        private void cmdSelectSecurityGroups_Click(object sender, EventArgs e)
        {
            frmSelectSecurityGroups selectSecurityGroups = new frmSelectSecurityGroups();
            selectSecurityGroups.UserID = UserID;
            selectSecurityGroups.FormClosed += SelectSecurityGroupsFormClosed;
            selectSecurityGroups.Show();
        }

        private async void SelectSecurityGroupsFormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = (Form)sender;
            form.FormClosed -= SelectSecurityGroupsFormClosed;

            await LoadSecurityGroups();
        }

        private void lstSecurityGroups_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstSecurityGroups.SelectedItems.Count > 0 && e.KeyCode == Keys.Delete && MessageBox.Show("Are you sure you want to remove these security groups from this user?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DeleteSecurityGroups();
            }
        }

        private async void DeleteSecurityGroups()
        {
            Enabled = false;

            PatchData patch = new PatchData(DataAccess.APIs.SystemManagement, "User/PatchUser", PatchData.PatchMethods.Remove, UserID, new Dictionary<string, object>()
            {
                { "MemberOf", lstSecurityGroups.SelectedItems.Cast<ListViewItem>().Select(lvi => lvi.Text).ToList() }
            });
            await patch.Execute();
            await LoadSecurityGroups();

            Enabled = true;
        }
    }
}
