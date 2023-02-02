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
        public frmWhitelist()
        {
            InitializeComponent();
        }

        private void frmWhitelist_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            Dictionary<string, object> configValues = UserPreferences.Get().Sections.GetOrDefault("mcsync", new Dictionary<string, object>());
            
            // Resource Packs
            if (configValues.ContainsKey("resourcepacks_whitelist"))
            {
                string[] whitelist = configValues["resourcepacks_whitelist"].Cast<JArray>()?.ToObject<string[]>() ?? configValues["resourcepacks_whitelist"].Cast<string[]>();
                if (whitelist != null)
                {
                    txtResourcePacks.Lines = whitelist;
                }
            }

            // Mods
            if (configValues.ContainsKey("mods_whitelist"))
            {
                string[] whitelist = configValues["mods_whitelist"].Cast<JArray>()?.ToObject<string[]>() ?? configValues["mods_whitelist"].Cast<string[]>();
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
            configValues["mods_whitelist"] = txtItems.Lines;
            configValues["resourcepacks_whitelist"] = txtResourcePacks.Lines;
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
