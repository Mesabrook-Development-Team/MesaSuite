using MesaSuite.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemManagement.Models;

namespace SystemManagement
{
    public partial class frmNewUser : Form
    {
        public frmManage ManageForm { get; set; }
        public frmNewUser()
        {
            InitializeComponent();
        }

        private async void frmNewUser_Load(object sender, EventArgs e)
        {
            imlList.Images.Add("program", Properties.Resources.program);
            imlList.Images.Add("security", Properties.Resources.security);
            GetData getData = new GetData(DataAccess.APIs.SystemManagement, "ActiveDirectoryUser/GetAllActiveDirectoryUsers");

            List<string> users = await getData.GetObject<List<string>>() ?? new List<string>();
            if (!getData.RequestSuccessful)
            {
                return;
            }

            cboUsers.Items.Add("");

            foreach(string user in users)
            {
                cboUsers.Items.Add(user);
            }

            cboUsers.Focus();

            Enabled = true;
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            Enabled = false;
            string user = cboUsers.SelectedItem as string;

            if (!string.IsNullOrEmpty(user))
            {
                await SaveExistingADUser();
            }
            else
            {
                await SaveNewADUser();
            }
        }

        private async Task SaveExistingADUser()
        {
            string user = cboUsers.SelectedItem as string;

            User userObject = new User()
            {
                Username = user,
                Email = $"{user}@mesabrook.com",
                DiscordID = txtDiscordID.Text,
                LastActivity = DateTime.Now,
                LastActivityReason = "New user created"
            };

            PostData post = new PostData(DataAccess.APIs.SystemManagement, "User/PostUserExisting", userObject);
            await post.ExecuteNoResult();

            if (post.RequestSuccessful)
            {
                Close();
            }
            else
            {
                Enabled = true;
            }
        }

        private async Task SaveNewADUser()
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Username, First Name, and Last Name are required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string password = Guid.NewGuid().ToString("N");
            User userObject = new User()
            {
                Username = txtUsername.Text,
                Email = $"{txtUsername.Text}@mesabrook.com",
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Password = password,
                MemberOf = lstSecurityGroups.Items.Cast<ListViewItem>().Select(lvi => lvi.Text).ToList(),
                DiscordID = txtDiscordID.Text,
                LastActivity = DateTime.Now,
                LastActivityReason = "New user created",
                InactivityDOINotificationServed = false,
                InactivityWarningServed = false
            };

            PostData post = new PostData(DataAccess.APIs.SystemManagement, "User/PostUserNew", userObject);
            userObject = await post.Execute<User>();

            if (post.RequestSuccessful)
            {
                List<UserProgram> userPrograms = new List<UserProgram>();
                foreach(Models.Program program in lstPrograms.Items.Cast<ListViewItem>().Select(lvi => (Models.Program)lvi.Tag))
                {
                    userPrograms.Add(new UserProgram()
                    {
                        UserID = userObject.UserID,
                        ProgramID = program.ProgramID
                    });
                }

                if (userPrograms.Any())
                {
                    post = new PostData(DataAccess.APIs.SystemManagement, "Program/SetProgramsForUser", new { newlySelectedPrograms  = userPrograms });
                    await post.ExecuteNoResult();

                    if (!post.RequestSuccessful)
                    {
                        MessageBox.Show("The user saved successfully, however, the programs did not.  Recommend manually checking programs.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                Clipboard.SetText(password);
                MessageBox.Show($"This user's new password is {password}.\r\n\r\nIt has been copied to your clipboard.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            else
            {
                Enabled = true;
            }
        }

        private void DetectExistingOrNew(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) && 
                string.IsNullOrEmpty(txtFirstName.Text) &&
                string.IsNullOrEmpty(txtLastName.Text) &&
                string.IsNullOrEmpty(txtDiscordID.Text) &&
                lstSecurityGroups.Items.Count == 0 &&
                lstPrograms.Items.Count == 0)
            {
                cboUsers.Enabled = true;
            }
            else
            {
                cboUsers.Enabled = false;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            txtEmail.Text = txtUsername.Text + "@mesabrook.com";

            DetectExistingOrNew(sender, e);
        }

        private void cboUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hasSelectedItem = !string.IsNullOrEmpty(cboUsers.SelectedItem as string);

            txtUsername.Enabled = !hasSelectedItem;
            txtFirstName.Enabled = !hasSelectedItem;
            txtLastName.Enabled = !hasSelectedItem;
            cmdSelectSG.Enabled = !hasSelectedItem;
            cmdSelectPrograms.Enabled = !hasSelectedItem;
        }

        private void cmdSelectSG_Click(object sender, EventArgs e)
        {
            frmSelectSecurityGroups selectSGs = new frmSelectSecurityGroups();
            selectSGs.PreselectedSecurityGroups = lstSecurityGroups.Items.Cast<ListViewItem>().Select(lvi => lvi.Text).ToList();
            selectSGs.FormClosed += SelectSGsFormClosed;
            selectSGs.Show();
        }

        private void SelectSGsFormClosed(object sender, FormClosedEventArgs e)
        {
            frmSelectSecurityGroups selectSGs = (frmSelectSecurityGroups)sender;
            lstSecurityGroups.Items.Clear();
            
            foreach(string securityGroup in selectSGs.PreselectedSecurityGroups)
            {
                ListViewItem item = new ListViewItem();
                item.ImageKey = "security";
                item.Text = securityGroup;

                lstSecurityGroups.Items.Add(item);
            }

            DetectExistingOrNew(sender, e);
        }

        private void cmdSelectPrograms_Click(object sender, EventArgs e)
        {
            frmSelectPrograms selectPrograms = new frmSelectPrograms();
            selectPrograms.PreselectedPrograms = lstPrograms.Items.Cast<ListViewItem>().Select(lvi => (Models.Program)lvi.Tag).ToList();
            selectPrograms.FormClosed += SelectProgramsFormClosed;
            selectPrograms.Show();
        }

        private void SelectProgramsFormClosed(object sender, FormClosedEventArgs e)
        {
            frmSelectPrograms selectPrograms = (frmSelectPrograms)sender;
            lstPrograms.Items.Clear();

            foreach(Models.Program program in selectPrograms.PreselectedPrograms)
            {
                ListViewItem item = new ListViewItem();
                item.ImageKey = "program";
                item.Tag = program;
                item.Text = program.Name;
                lstPrograms.Items.Add(item);
            }

            DetectExistingOrNew(sender, e);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
