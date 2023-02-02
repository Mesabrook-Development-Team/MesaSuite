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
    public partial class frmEditItemNamespace : Form
    {
        public long? ItemNamespaceID { get; set; }
        public bool DisableNamespace { get; set; }

        public frmEditItemNamespace()
        {
            InitializeComponent();
        }

        private void HideLoader()
        {
            foreach (Control control in Controls)
            {
                control.Enabled = true;
            }

            loader.BringToFront();
            loader.Visible = false;
        }

        private void ShowLoader()
        {
            foreach (Control control in Controls)
            {
                control.Enabled = false;
            }

            loader.BringToFront();
            loader.Visible = true;
        }

        private async void frmEditItemNamespace_Load(object sender, EventArgs e)
        {
            txtNamespace.Enabled = !DisableNamespace;

            if (ItemNamespaceID != null)
            {
                try
                {
                    ShowLoader();

                    GetData get = new GetData(DataAccess.APIs.SystemManagement, $"ItemNamespace/Get/{ItemNamespaceID}");
                    ItemNamespace itemNamespace = await get.GetObject<ItemNamespace>();

                    if (itemNamespace != null)
                    {
                        txtNamespace.Text = itemNamespace.Namespace;
                        txtFriendlyName.Text = itemNamespace.FriendlyName;
                    }
                }
                finally
                {
                    HideLoader();
                }
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (!this.AreFieldsPresent(new List<(string, Control)>()
            {
                ("Namespace", txtNamespace),
                ("Friendly Name", txtFriendlyName)
            }))
            {
                return;
            }

            try
            {
                ShowLoader();
                ItemNamespace itemNamespace = new ItemNamespace()
                {
                    ItemNamespaceID = ItemNamespaceID,
                    Namespace = txtNamespace.Text,
                    FriendlyName = txtFriendlyName.Text
                };

                if (ItemNamespaceID == null)
                {
                    PostData post = new PostData(DataAccess.APIs.SystemManagement, "ItemNamespace/Post", itemNamespace);
                    await post.ExecuteNoResult();
                    if (post.RequestSuccessful)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    PutData put = new PutData(DataAccess.APIs.SystemManagement, "ItemNamespace/Put", itemNamespace);
                    await put.ExecuteNoResult();
                    if (put.RequestSuccessful)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            catch
            {
                HideLoader();
            }
        }
    }
}
