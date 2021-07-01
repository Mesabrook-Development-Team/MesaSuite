using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemManagement.Models;

namespace SystemManagement
{
    public partial class frmSelectPrograms : Form
    {
        public long? UserID { get; set; }
        public List<Models.Program> PreselectedPrograms { get; set; }
        List<Models.Program> _allPrograms;
        List<Models.Program> _selectedPrograms;
        List<Models.Program> _initialSelectedPrograms;
        public frmSelectPrograms()
        {
            InitializeComponent();
        }

        private async void frmSelectPrograms_Load(object sender, EventArgs e)
        {
            imlList.Images.Add("program", Properties.Resources.program);
            if (UserID == null && PreselectedPrograms == null)
            {
                throw new ArgumentNullException("UserID or PreselectedPrograms is required");
            }
            GetData get = new GetData(DataAccess.APIs.SystemManagement, "Program/GetProgramKeys");
            _allPrograms = await get.GetObject<List<Models.Program>>() ?? new List<Models.Program>();

            if (PreselectedPrograms == null)
            {
                get = new GetData(DataAccess.APIs.SystemManagement, "Program/GetProgramsForUser");
                get.QueryString = new Dictionary<string, string>()
                {
                    { "userid", UserID.Value.ToString() }
                };
                List<Models.Program> programsForUser = await get.GetObject<List<Models.Program>>() ?? new List<Models.Program>();

                _selectedPrograms = _allPrograms.Where(p => programsForUser.Any(pfu => pfu.ProgramID == p.ProgramID)).ToList();
                _initialSelectedPrograms = _selectedPrograms.Select(p => p).ToList();
            }
            else
            {
                _selectedPrograms = _allPrograms.Where(p => PreselectedPrograms.Any(pp => p.Key == pp.Key)).ToList();
                _initialSelectedPrograms = _selectedPrograms.ToList();
            }

            FillProgramsList();

            txtSearch.Focus();

            Enabled = true;
        }

        private void FillProgramsList()
        {
            lstPrograms.Items.Clear();

            foreach(Models.Program program in _allPrograms.Where(p => p.Name.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase)))
            {
                ListViewItem item = new ListViewItem();
                item.ImageKey = "program";
                item.Text = program.Name;
                item.Tag = program;
                item.Checked = _selectedPrograms.Contains(program);
                lstPrograms.Items.Add(item);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillProgramsList();
        }

        private void lstPrograms_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            Models.Program program = (Models.Program)e.Item.Tag;
            if (e.Item.Checked)
            {
                _selectedPrograms.Add(program);
            }
            else
            {
                _selectedPrograms.Remove(program);
            }
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            Enabled = false;

            if (PreselectedPrograms == null)
            {
                List<Models.Program> unselectedProgram = _initialSelectedPrograms.Except(_selectedPrograms).ToList();
                List<Models.Program> newlySelectedPrograms = _selectedPrograms.Except(_initialSelectedPrograms).ToList();

                foreach (Models.Program deletedProgram in unselectedProgram)
                {
                    UserProgram userProgram = new UserProgram()
                    {
                        UserID = UserID.Value,
                        ProgramID = deletedProgram.ProgramID
                    };

                    DeleteData delete = new DeleteData(DataAccess.APIs.SystemManagement, "Program/DeleteProgramForUser");
                    delete.QueryString.Add("userid", UserID.Value.ToString());
                    delete.QueryString.Add("programid", deletedProgram.ProgramID.ToString());
                    await delete.Execute();
                }

                if (newlySelectedPrograms.Any())
                {
                    PostData post = new PostData(DataAccess.APIs.SystemManagement, "Program/SetProgramsForUser");
                    post.ObjectToPost = newlySelectedPrograms.Select(p => new UserProgram() { UserID = UserID.Value, ProgramID = p.ProgramID }).ToList();
                    await post.ExecuteNoResult();
                }
            }
            else
            {
                PreselectedPrograms = _selectedPrograms;
            }

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
