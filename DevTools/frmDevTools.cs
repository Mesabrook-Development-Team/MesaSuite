using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Loader;
using ClussPro.ObjectBasedFramework.Schema;
using WebModels.mesasys;
using WebModels.Migrations;

namespace DevTools
{
    public partial class frmDevTools : Form
    {
        private string currentLocation;
        private string baseLocation;
        public frmDevTools()
        {
            InitializeComponent();
        }

        private void frmDevTools_Load(object sender, EventArgs e)
        {
            currentLocation = Assembly.GetExecutingAssembly().Location;
            currentLocation = currentLocation.Substring(0, currentLocation.LastIndexOf('\\'));
            if (!currentLocation.EndsWith("DevTools\\bin\\Debug"))
            {
                MessageBox.Show("Dev Tools is starting in a location that isn't the Debug folder.\r\n\r\nThis confuses the Dev Tools.\r\n\r\nPlease make sure you start this through Visual Studio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            baseLocation = currentLocation + "\\..\\..\\..\\";
            string webConfigFile = baseLocation + "API-System\\Web.config";
            XDocument config = XDocument.Load(webConfigFile);
            XElement appSettingsElement = config.Descendants("appSettings").First();
            txtSQLProviderLocation.Text = GetConfigValue(appSettingsElement, "Base.SQLProvider");
            txtConnectionString.Text = GetConfigValue(appSettingsElement, "MSSQLProvider.ConnectionString");
            txtMailConnectionString.Text = GetConfigValue(appSettingsElement, "MSSQLProvider.ConnectionString.hmailserver");
            txtAddress.Text = GetConfigValue(appSettingsElement, "LDAPAddress");
            txtContainer.Text = GetConfigValue(appSettingsElement, "LDAPContainer");
            txtGroup.Text = GetConfigValue(appSettingsElement, "LDAPGroupName");
            txtUser.Text = GetConfigValue(appSettingsElement, "LDAPUser");
            txtPassword.Text = GetConfigValue(appSettingsElement, "LDAPPassword");

            config = XDocument.Load(baseLocation + "MesaSuite\\App.config");
            appSettingsElement = config.Descendants("appSettings").First();

            rdoSysLive.Checked = IsLive(appSettingsElement, key => key.EndsWith("Host.SystemManagement"), val => val.StartsWith("http://localhost"));
            rdoSysLocal.Checked = !IsLive(appSettingsElement, key => key.EndsWith("Host.SystemManagement"), val => val.StartsWith("http://localhost"));

            rdoCompanyLive.Checked = IsLive(appSettingsElement, key => key.EndsWith("Host.CompanyStudio"), val => val.StartsWith("http://localhost"));
            rdoCompanyLocal.Checked = !IsLive(appSettingsElement, key => key.EndsWith("Host.CompanyStudio"), val => val.StartsWith("http://localhost"));

            rdoSyncLive.Checked = IsLive(appSettingsElement, key => key.EndsWith("Host.MCSync"), val => val.StartsWith("http://localhost"));
            rdoSyncLocal.Checked = !IsLive(appSettingsElement, key => key.EndsWith("Host.MCSync"), val => val.StartsWith("http://localhost"));

            rdoAuthLive.Checked = IsLive(appSettingsElement, key => key.EndsWith("AuthHost"), val => val.StartsWith("http://localhost"));
            rdoAuthLocal.Checked = !IsLive(appSettingsElement, key => key.EndsWith("AuthHost"), val => val.StartsWith("http://localhost"));

            rdoVersionLive.Checked = IsLive(appSettingsElement, key => key.EndsWith("VersionURL"), val => val.StartsWith("http://localhost"));
            rdoVersionLocal.Checked = !IsLive(appSettingsElement, key => key.EndsWith("VersionURL"), val => val.StartsWith("http://localhost"));
        }

        private string GetConfigValue(XElement appSettings, string name)
        {
            return appSettings.Elements().Where(e => e.Attribute("key").Value == name).Single().Attribute("value").Value;
        }

        private void SetConfigValue(XElement appSettings, string name, string value)
        {
            XElement element = appSettings.Elements().Where(e => e.Attribute("key").Value == name).SingleOrDefault();
            if (element != null)
            {
                element.Attribute("value").Value = value;
            }
        }

        private bool IsLive(XElement appSettingsElement, Func<string, bool> keySelector, Func<string, bool> isDebugValueSelector)
        {
            XElement workingElement = appSettingsElement.Elements().Where(e => keySelector(e.Attribute("key").Value)).FirstOrDefault();
            return workingElement == null || !isDebugValueSelector(workingElement.Attribute("value").Value);
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open MS SQL Provider";
            openFileDialog.Filter = "DLL Files|*.dll";
            openFileDialog.InitialDirectory = Path.GetDirectoryName(txtSQLProviderLocation.Text);
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtSQLProviderLocation.Text = openFileDialog.FileName;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetConfigOptions(baseLocation + "API-Company\\Web.config");
                SetConfigOptions(baseLocation + "API-MCSync\\Web.config");
                SetConfigOptions(baseLocation + "API-System\\Web.config");
                SetConfigOptions(baseLocation + "OAuth\\Web.config");
                SetConfigOptions(baseLocation + "DevTools\\App.config");
                SetConfigOptions(baseLocation + "Sandbox\\App.config");
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred:\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ConfigurationManager.AppSettings.Set("Base.SQLProvider", txtSQLProviderLocation.Text);
            ConfigurationManager.AppSettings.Set("MSSQLProvider.ConnectionString", txtConnectionString.Text);
            ConfigurationManager.AppSettings.Set("MSSQLProvider.ConnectionString.hmailserver", txtMailConnectionString.Text);

            XDocument mesaSuiteConfig = XDocument.Load(baseLocation + "MesaSuite\\App.config");
            XElement appSettingsElement = mesaSuiteConfig.Descendants("appSettings").First();

            try
            {
                SetLiveLocalOptions(appSettingsElement, rdoSyncLive, "MCSync", "API-MCSync\\API-MCSync.csproj");
                SetLiveLocalOptions(appSettingsElement, rdoSyncLive, "SystemManagement", "API-System\\API-System.csproj");
                SetLiveLocalOptions(appSettingsElement, rdoSyncLive, "CompanyStudio", "API-Company\\API-Company.csproj");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Authentication
            string authHost = rdoAuthLive.Checked ? "https://auth.mesabrook.com" : GetIISUrlFromProject(baseLocation + "OAuth\\OAuth.csproj");
            XElement authHostElement = appSettingsElement.Elements().FirstOrDefault(el => el.Attribute("key").Value == "MesaSuite.Common.AuthHost");
            if (authHostElement == null)
            {
                authHostElement = new XElement("add", new XAttribute("key", "MesaSuite.Common.AuthHost"), new XAttribute("value", ""));
                appSettingsElement.Add(authHostElement);
            }

            authHostElement.Attribute("value").Value = authHost;

            // Version
            string version = rdoVersionLive.Checked ? "http://mcsync.api.mesabrook.com/version" : GetIISUrlFromProject(baseLocation + "API-MCSync\\API-MCSync.csproj") + "/version"; 
            XElement versionElement = appSettingsElement.Elements().FirstOrDefault(el => el.Attribute("key").Value == "MesaSuite.VersionURL");
            if (versionElement == null)
            {
                versionElement = new XElement("add", new XAttribute("key", "MesaSuite.VersionURL"), new XAttribute("value", ""));
                appSettingsElement.Add(versionElement);
            }

            versionElement.Attribute("value").Value = version;

            mesaSuiteConfig.Save(baseLocation + "MesaSuite\\App.config");

            MessageBox.Show("All configs set!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void SetConfigOptions(string configPath)
        {
            XDocument config = XDocument.Load(configPath);
            XElement appSettingsElement = config.Descendants("appSettings").First();

            SetConfigValue(appSettingsElement, "Base.SQLProvider", txtSQLProviderLocation.Text);
            SetConfigValue(appSettingsElement, "MSSQLProvider.ConnectionString", txtConnectionString.Text);
            SetConfigValue(appSettingsElement, "MSSQLProvider.ConnectionString.hmailserver", txtMailConnectionString.Text);
            SetConfigValue(appSettingsElement, "LDAPAddress", txtAddress.Text);
            SetConfigValue(appSettingsElement, "LDAPContainer", txtContainer.Text);
            SetConfigValue(appSettingsElement, "LDAPGroupName", txtGroup.Text);
            SetConfigValue(appSettingsElement, "LDAPUser", txtUser.Text);
            SetConfigValue(appSettingsElement, "LDAPPassword", txtPassword.Text);

            config.Save(configPath);
        }

        private void SetLiveLocalOptions(XElement appSettings, RadioButton live, string system, string projectPath)
        {
            XElement resourceWriterElement = appSettings.Elements().Where(e => e.Attribute("key").Value.Equals($"MesaSuite.Common.ResourceWriter.{system}")).FirstOrDefault();
            if (resourceWriterElement == null)
            {
                resourceWriterElement = new XElement("add", new XAttribute("key", $"MesaSuite.Common.ResourceWriter.{system}"), new XAttribute("value", ""));
                appSettings.Add(resourceWriterElement);
            }

            if (!live.Checked)
            {
                resourceWriterElement.Attribute("value").Value = "MesaSuite.Common.Data.DebugResourceWriter";
                XElement hostElement = appSettings.Elements().Where(e => e.Attribute("key").Value.Equals($"MesaSuite.Common.DebugResourceWriter.Host.{system}")).FirstOrDefault();
                if (hostElement == null)
                {
                    hostElement = new XElement("add", new XAttribute("key", $"MesaSuite.Common.DebugResourceWriter.Host.{system}"), new XAttribute("value", ""));
                    appSettings.Add(hostElement);
                }

                string csProjPath = baseLocation + projectPath;
                string iisUrl = GetIISUrlFromProject(csProjPath);

                hostElement.Attribute("value").Value = iisUrl;
            }
            else
            {
                resourceWriterElement.Attribute("value").Value = "MesaSuite.Common.Data.ReleaseResourceWriter";
            }
        }

        private static string GetIISUrlFromProject(string csProjPath)
        {
            XDocument csProj = XDocument.Load(csProjPath);
            XNamespace ns = "http://schemas.microsoft.com/developer/msbuild/2003";
            XElement iisUrl = csProj.Descendants(ns + "IISUrl").FirstOrDefault();
            if (iisUrl == null)
            {
                throw new KeyNotFoundException($"Could not find IIS URL in project {csProjPath}");
            }

            return iisUrl.Value;
        }

        private async void cmdDeploy_Click(object sender, EventArgs e)
        {
            cmdDeploy.Text = "Deploying...";
            cmdDeploy.Enabled = false;
            try
            {
                MigrationHistory history = DataObjectFactory.Create<MigrationHistory>();
                await Task.Run(Schema.Deploy);
                MessageBox.Show("Schema deployed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred deploying schema:\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmdDeploy.Text = "Run";
            cmdDeploy.Enabled = true;
        }

        private async void cmdMigrations_Click(object sender, EventArgs e)
        {
            cmdMigrations.Text = "Running...";
            cmdMigrations.Enabled = false;
            frmStatus status = new frmStatus();
            status.Show();

            try
            {
                await Task.Run(() => MigrationController.Run(update =>
                {
                    if (!status.IsDisposed)
                    {
                        status.Append(update);
                    }
                }));
                MessageBox.Show("Migrations run!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred running migrations:\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            status.Close();

            cmdMigrations.Text = "Run";
            cmdMigrations.Enabled = true;
        }

        private async void cmdLoaders_Click(object sender, EventArgs e)
        {
            cmdLoaders.Text = "Running...";
            cmdLoaders.Enabled = false;

            try
            {
                LoaderController controller = new LoaderController();
                controller.Initialize();

                await Task.Run(controller.Process);

                MessageBox.Show("Loaders run!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred running loaders:\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmdLoaders.Text = "Run";
            cmdLoaders.Enabled = true;
        }
    }
}
