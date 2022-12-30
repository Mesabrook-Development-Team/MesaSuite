using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemManagement.Models;

namespace SystemManagement
{
    public partial class frmEditItem : Form
    {
        private Image _selectedImage;

        public long? ItemID { get; set; }

        public frmEditItem()
        {
            InitializeComponent();
        }

        private async void frmAddItem_Load(object sender, EventArgs e)
        {
            try
            {
                ShowLoader();

                GetData get = new GetData(DataAccess.APIs.SystemManagement, "ItemNamespace/GetAll");
                List<ItemNamespace> itemNamespaces = await get.GetObject<List<ItemNamespace>>() ?? new List<ItemNamespace>();
                itemNamespaces = itemNamespaces.OrderBy(ins => ins.FriendlyName).ToList();

                foreach (ItemNamespace itemNamespace in itemNamespaces)
                {
                    DropDownItem<ItemNamespace> ddi = new DropDownItem<ItemNamespace>(itemNamespace, itemNamespace.FriendlyName);
                    cboNamespace.Items.Add(ddi);
                }

                if (ItemID != null)
                {
                    get.Resource = $"Item/Get/{ItemID}";
                    get.RequestFields.Add("Image");
                    Item item = await get.GetObject<Item>();
                    if (item != null)
                    {
                        DropDownItem<ItemNamespace> ddi = cboNamespace.Items.OfType<DropDownItem<ItemNamespace>>().FirstOrDefault(ins => ins.Object.ItemNamespaceID == item.ItemNamespaceID);
                        cboNamespace.SelectedItem = ddi;
                        txtName.Text = item.Name;
                        if (item.Image != null)
                        {
                            using (MemoryStream stream = new MemoryStream(item.Image))
                            {
                                _selectedImage = Image.FromStream(stream);
                            }
                            pboxImage.Image = _selectedImage;
                        }
                    }
                }
            }
            finally
            {
                HideLoader();
            }
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

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (!this.AreFieldsPresent(new List<(string, Control)>()
            {
                ("Namespace", cboNamespace),
                ("Name", txtName)
            }))
            {
                return;
            }

            if (_selectedImage == null)
            {
                this.ShowError("Image is a required field");
            }

            byte[] image;
            using (MemoryStream imageStream = new MemoryStream())
            {
                _selectedImage.Save(imageStream, ImageFormat.Png);

                imageStream.Position = 0;
                image = new byte[imageStream.Length];
                imageStream.Read(image, 0, image.Length);
            }

            Item item = new Item()
            {
                ItemID = ItemID,
                ItemNamespaceID = cboNamespace.SelectedItem.Cast<DropDownItem<ItemNamespace>>().Object.ItemNamespaceID,
                Name = txtName.Text,
                Image = image
            };

            try
            {
                ShowLoader();
                if (ItemID == null)
                {
                    PostData post = new PostData(DataAccess.APIs.SystemManagement, "Item/Post", item);
                    await post.ExecuteNoResult();
                    if (post.RequestSuccessful)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    PutData put = new PutData(DataAccess.APIs.SystemManagement, "Item/Put", item);
                    await put.ExecuteNoResult();
                    if (put.RequestSuccessful)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            finally
            {
                HideLoader();
            }
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openImage.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            using (FileStream stream = new FileStream(openImage.FileName, FileMode.Open))
            {
                _selectedImage = Image.FromStream(stream);
            }

            pboxImage.Image = _selectedImage;

            txtName.Text = Path.GetFileNameWithoutExtension(openImage.FileName);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
