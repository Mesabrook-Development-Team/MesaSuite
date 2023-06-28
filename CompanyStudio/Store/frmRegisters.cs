using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyStudio.Extensions;
using CompanyStudio.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace CompanyStudio.Store
{
    public partial class frmRegisters : BaseCompanyStudioContent, ILocationScoped
    {
        private const string registerIconName = "register";
        public frmRegisters()
        {
            InitializeComponent();
        }

        public Location LocationModel { get; set; }

        private void frmRegisters_Load(object sender, EventArgs e)
        {
            imageList.Images.Add(registerIconName, Properties.Resources.cash_register);
            LoadList();
        }

        private async Task LoadList()
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                lstRegisters.Items.Clear();
                GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Register/GetAll");
                get.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                List<Register> registers = await get.GetObject<List<Register>>() ?? new List<Register>();

                foreach(Register register in registers)
                {
                    ListViewItem registerItem = new ListViewItem(register.Name, registerIconName);
                    registerItem.SubItems.Add(register.CurrentStatus?.Status.ToString().ToDisplayName());
                    registerItem.Tag = register;
                    lstRegisters.Items.Add(registerItem);
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            frmRegister registerForm = new frmRegister();
            Studio.DecorateStudioContent(registerForm);
            registerForm.FormClosed += RegisterForm_FormClosed;
            registerForm.Show(Studio.dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmRegister)sender).FormClosed -= RegisterForm_FormClosed;
            LoadList();
        }

        private async void toolDelete_Click(object sender, EventArgs e)
        {
            if (lstRegisters.SelectedItems.Count <= 0 || !this.Confirm("Are you sure you want to delete these Registers?"))
            {
                return;
            }

            try
            {
                foreach (ListViewItem item in lstRegisters.SelectedItems)
                {
                    Register register = (Register)item.Tag;
                    DeleteData delete = new DeleteData(DataAccess.APIs.CompanyStudio, $"Register/Delete/{register.RegisterID}");
                    delete.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                    await delete.Execute();
                }
                await LoadList();
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void lstRegisters_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                LoadList();
            }
            else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                toolDelete.PerformClick();
            }
        }

        private void lstRegisters_DoubleClick(object sender, EventArgs e)
        {
            if (lstRegisters.SelectedItems.Count <= 0)
            {
                return;
            }

            ListViewItem item = lstRegisters.SelectedItems[0];
            Register register = (Register)item.Tag;
            frmRegister frmRegister = new frmRegister();
            frmRegister.RegisterID = register.RegisterID;
            Studio.DecorateStudioContent(frmRegister);
            frmRegister.FormClosed -= RegisterForm_FormClosed;
            frmRegister.Show(Studio.dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private async void toolOnline_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in lstRegisters.SelectedItems)
                {
                    Register register = (Register)item.Tag;
                    await SetStatus(register.RegisterID, RegisterStatus.Statuses.Online);
                }

                await LoadList();
            }
            finally { loader.Visible = false; }
        }

        private async void toolOffline_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in lstRegisters.SelectedItems)
                {
                    Register register = (Register)item.Tag;
                    await SetStatus(register.RegisterID, RegisterStatus.Statuses.Offline);
                }

                await LoadList();
            }
            finally { loader.Visible = false; }
        }

        private async Task SetStatus(long? registerID, RegisterStatus.Statuses status)
        {
            loader.BringToFront();
            loader.Visible = true;

            RegisterStatus registerStatus = new RegisterStatus();
            registerStatus.RegisterID = registerID;
            registerStatus.Status = status;

            PostData post = new PostData(DataAccess.APIs.CompanyStudio, "RegisterStatus/Post", registerStatus);
            post.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
            await post.ExecuteNoResult();
        }
    }
}
