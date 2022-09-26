using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MesaSuite.Common;
using MesaSuite.Common.Extensions;
using Newtonsoft.Json.Linq;

namespace MCSync
{
    public partial class frmWhitelist : Form
    {
        public string WhitelistName { get; set; }
        public frmWhitelist()
        {
            InitializeComponent();
        }

        private void frmWhitelist_Load(object sender, EventArgs e)
        {
            Dictionary<string, object> configValues = UserPreferences.Get().Sections.GetOrDefault("mcsync", new Dictionary<string, object>());
            if (configValues.ContainsKey(WhitelistName))
            {
                string[] whitelist = configValues[WhitelistName].Cast<JArray>()?.ToObject<string[]>() ?? configValues[WhitelistName].Cast<string[]>();
                if (whitelist != null)
                {
                    txtItems.Lines = whitelist;
                }
            }
        }

        private void fButtonSave_Click(object sender, EventArgs e)
        {
            UserPreferences userPreferences = UserPreferences.Get();
            Dictionary<string, object> configValues = userPreferences.Sections.GetOrSetDefault("mcsync", new Dictionary<string, object>());
            configValues[WhitelistName] = txtItems.Lines;
            userPreferences.Save();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void fButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
