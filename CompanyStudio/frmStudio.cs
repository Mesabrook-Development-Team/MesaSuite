using CompanyStudio.Models;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio
{
    public partial class frmStudio : Form
    {
        Dictionary<string, ThemeBase> themes = new Dictionary<string, ThemeBase>();
        ThemeBase currentTheme = null;

        private void InitializeThemeLookup()
        {
            themes.Add("dark", vS2015DarkTheme);
            themes.Add("light", vS2015LightTheme);
            themes.Add("blue", vS2015BlueTheme);
        }

        public event EventHandler<Company> OnCompanyAdded;
        public event EventHandler<Company> OnCompanyRemoved;
        
        Dictionary<Type, BaseCompanyStudioContent> formsByType = new Dictionary<Type, BaseCompanyStudioContent>();
        private Company _activeCompany;
        public Company ActiveCompany
        {
            get { return _activeCompany; }
            set
            {
                _activeCompany = value;
                toolCompanyDropDown.SelectedItem = _activeCompany?.Name;
                emailToolStripMenuItem.Visible = PermissionsManager.HasPermission(_activeCompany?.CompanyID ?? -1, PermissionsManager.Permissions.ManageEmails);
                employeesToolStripMenuItem.Visible = PermissionsManager.HasPermission(_activeCompany?.CompanyID ?? -1, PermissionsManager.Permissions.ManageEmployees);
                accountsToolStripMenuItem.Visible = PermissionsManager.HasPermission(_activeCompany?.CompanyID ?? -1, PermissionsManager.Permissions.ManageAccounts);
            }
        }
        private List<Company> _companies = new List<Company>();
        public IReadOnlyCollection<Company> Companies => new List<Company>(_companies);

        public frmStudio()
        {
            InitializeComponent();
            InitializeThemeLookup();
        }

        private void frmStudio_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Clussman Productions\MesaSuite");
            string theme = key.GetValue("CStudioTheme") as string;
            if (string.IsNullOrEmpty(theme) || !themes.ContainsKey(theme))
            {
                theme = "dark";
                key.SetValue("CStudioTheme", theme);
            }

            currentTheme = themes[theme];

            SetThemeMenuChecked();
            ApplyTheme();


            frmCompanyConnect connect = GetForm<frmCompanyConnect>();
            connect.Shown += Connect_Shown_FirstTime;
            connect.Show();

            frmCompanyExplorer companyExplorer = GetForm<frmCompanyExplorer>();
            companyExplorer.Show(dockPanel, DockState.DockLeft);

            PermissionsManager.OnPermissionChange += PermissionsManager_OnPermissionChange;
            PermissionsManager.StartCheckThread((method) => Invoke(method));
        }

        private void PermissionsManager_OnPermissionChange(object sender, PermissionsManager.PermissionChangeEventArgs e)
        {
            if (e.CompanyID == (ActiveCompany?.CompanyID ?? -1))
            {
                switch(e.Permission)
                {
                    case PermissionsManager.Permissions.ManageEmails:
                        emailToolStripMenuItem.Visible = e.Value;
                        break;
                    case PermissionsManager.Permissions.ManageEmployees:
                        employeesToolStripMenuItem.Visible = e.Value;
                        break;
                    case PermissionsManager.Permissions.ManageAccounts:
                        accountsToolStripMenuItem.Visible = e.Value;
                        break;
                }
            }
        }

        private void Connect_Shown_FirstTime(object sender, EventArgs e)
        {
            frmCompanyConnect connect = GetForm<frmCompanyConnect>(false);
            connect.Shown -= Connect_Shown_FirstTime;
            connect.BringToFront();
        }

        private void SetThemeMenuChecked()
        {
            foreach (ToolStripMenuItem item in mnuThemes.DropDownItems)
            {
                item.Checked = false;
            }

            if (currentTheme == vS2015LightTheme)
            {
                mnuLightTheme.Checked = true;
            }
            else if (currentTheme == vS2015DarkTheme)
            {
                mnuDarkTheme.Checked = true;
            }
            else if (currentTheme == vS2015BlueTheme)
            {
                mnuBlueTheme.Checked = true;
            }
        }

        private void ApplyTheme()
        {
            if (dockPanel.Contents.OfType<BaseCompanyStudioContent>().Any(c => c.IsDirty))
            {
                MessageBox.Show("Please save all documents before switching themes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                dockPanel.SaveAsXml(memoryStream, Encoding.UTF8);
                memoryStream.Position = 0;
                foreach(IDockContent content in dockPanel.Contents.ToList())
                {
                    content.DockHandler.Close();
                }

                currentTheme.ApplyTo(dockPanel);

                dockPanel.LoadFromXml(memoryStream, HandlePersistString);
            }
            toolStripExtender.SetStyle(mnuBanner, VisualStudioToolStripExtender.VsVersion.Vs2015, currentTheme);
            toolStripExtender.SetStyle(toolStrip, VisualStudioToolStripExtender.VsVersion.Vs2015, currentTheme);

            foreach (BaseCompanyStudioContent item in dockPanel.Contents.OfType<BaseCompanyStudioContent>())
            {
                item.Theme = currentTheme;
            }

            frmCompanyConnect connect = GetForm<frmCompanyConnect>(false);
            if (connect != null)
            {
                connect.Theme = currentTheme;
            }
        }

        private IDockContent HandlePersistString(string persistString)
        {
            try
            {
                JObject jObject = JObject.Parse(persistString);
                Type studioType = Type.GetType(jObject.Property("type").Value.Value<string>());

                BaseCompanyStudioContent content = GetForm(studioType);
                content.HandlePersistString(persistString);

                return content;
            }
            catch { }

            Type nonStudioType = Type.GetType(persistString);
            return (IDockContent)Activator.CreateInstance(nonStudioType);
        }

        private void mnuTheme_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            string theme = (string)menu.Tag;

            currentTheme = themes[theme];
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Clussman Productions\MesaSuite");
            key.SetValue("CStudioTheme", theme);

            SetThemeMenuChecked();
            ApplyTheme();
        }

        public T GetForm<T>(bool createNew = true) where T:BaseCompanyStudioContent
        {
            return GetForm(typeof(T), createNew) as T;
        }

        public BaseCompanyStudioContent GetForm(Type formType, bool createNew = true)
        {
            BaseCompanyStudioContent returnValue;
            if (!formsByType.ContainsKey(formType) || ((Form)formsByType[formType]).IsDisposed)
            {
                if (!createNew)
                {
                    return null;
                }
                else
                {
                    returnValue = (BaseCompanyStudioContent)Activator.CreateInstance(formType);
                    DecorateStudioContent(returnValue);

                    formsByType[formType] = returnValue;
                }
            }
            else
            {
                returnValue = formsByType[formType];
            }

            return returnValue;
        }

        public void DecorateStudioContent(BaseCompanyStudioContent content)
        {
            content.Theme = currentTheme;
            content.Studio = this;
            content.Company = ActiveCompany;
            content.OnIsDirtyChange += Content_OnIsDirtyChange;
        }

        private void Content_OnIsDirtyChange(object sender, EventArgs e)
        {
            
        }

        public void AddCompany(Company company)
        {
            _companies.Add(company);
            toolCompanyDropDown.Items.Add(company.Name);
            OnCompanyAdded?.Invoke(this, company);
        }

        public void RemoveCompany(Company company)
        {
            _companies.Remove(company);
            toolCompanyDropDown.Items.Remove(company.Name);

            if (company == ActiveCompany)
            {
                ActiveCompany = null;
            }

            OnCompanyRemoved(this, company);
        }

        private void mnuCompanyExplorer_Click(object sender, EventArgs e)
        {
            GetForm<frmCompanyExplorer>().Show(dockPanel, DockState.DockLeft);
        }

        private void toolCompanyDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveCompany = Companies.FirstOrDefault(c => c.Name == (string)toolCompanyDropDown.SelectedItem);
        }

        string valueWhenCompanyDropDownEntered = null;
        private void toolCompanyDropDown_Enter(object sender, EventArgs e)
        {
            valueWhenCompanyDropDownEntered = toolCompanyDropDown.SelectedItem as string;
        }

        private void toolCompanyDropDown_Leave(object sender, EventArgs e)
        {
            if (!toolCompanyDropDown.Items.Contains(toolCompanyDropDown.Text))
            {
                toolCompanyDropDown.SelectedItem = valueWhenCompanyDropDownEntered;
            }

            valueWhenCompanyDropDownEntered = null;
        }

        private void mnuEmailExplorer_Click(object sender, EventArgs e)
        {
            foreach(Email.frmEmailExplorer openEmailExplorers in dockPanel.Contents.OfType<Email.frmEmailExplorer>())
            {
                if (openEmailExplorers.Company == ActiveCompany)
                {
                    openEmailExplorers.Activate();
                    return;
                }
            }

            Email.frmEmailExplorer emailExplorer = new Email.frmEmailExplorer();
            DecorateStudioContent(emailExplorer);
            emailExplorer.Show(dockPanel, DockState.DockRight);
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            if (dockPanel.ActiveDocument is ISaveable saveable)
            {
                try
                {
                    saveable.Save();
                }
                catch { }
            }
        }

        private void toolSaveAll_Click(object sender, EventArgs e)
        {
            foreach(ISaveable saveable in dockPanel.Documents.OfType<ISaveable>())
            {
                try
                {
                    saveable.Save();
                }
                catch { }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch(keyData)
            {
                case Keys.S | Keys.Control | Keys.Shift:
                    toolSaveAll.PerformClick();
                    return true;
                case Keys.S | Keys.Control:
                    toolSave.PerformClick();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void mnuEmployeeExplorer_Click(object sender, EventArgs e)
        {
            foreach (Employees.frmEmployeeExplorer openEmployeeExplorer in dockPanel.Contents.OfType<Employees.frmEmployeeExplorer>())
            {
                if (openEmployeeExplorer.Company == ActiveCompany)
                {
                    openEmployeeExplorer.Activate();
                    return;
                }
            }

            Employees.frmEmployeeExplorer employeeExplorer = new Employees.frmEmployeeExplorer();
            DecorateStudioContent(employeeExplorer);
            employeeExplorer.Show(dockPanel, DockState.DockRight);
        }

        private void frmStudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            PermissionsManager.StopCheckThread();
        }

        private void mnuAccountExplorer_Click(object sender, EventArgs e)
        {
            Accounts.frmAccountExplorer accountExplorer = dockPanel.Contents.OfType<Accounts.frmAccountExplorer>().Where(acctExplorer => acctExplorer.Company == ActiveCompany).FirstOrDefault();

            if (accountExplorer != null)
            {
                accountExplorer.Activate();
                return;
            }

            accountExplorer = new Accounts.frmAccountExplorer();
            DecorateStudioContent(accountExplorer);
            accountExplorer.Show(dockPanel, DockState.DockRight);
        }

        private void mnuCategories_Click(object sender, EventArgs e)
        {
            Accounts.frmCategories categories = new Accounts.frmCategories();
            categories.Theme = currentTheme;
            categories.Company = ActiveCompany;
            categories.Show();
        }
    }
}
