using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemManagement.Models;

namespace SystemManagement
{
    public partial class frmItemImporter : Form
    {
        Dictionary<string, Image> imagesByNamespaceName = new Dictionary<string, Image>();
        public frmItemImporter()
        {
            InitializeComponent();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            DialogResult res = openFolder.ShowDialog();
            if (res != DialogResult.OK)
            {
                return;
            }

            txtImportFolder.Text = openFolder.SelectedFolder;
        }

        private void ShowLoader()
        {
            foreach(Control control in Controls)
            {
                if (control == loader) continue;

                control.Enabled = false;
            }

            loader.BringToFront();
            loader.Visible = true;
        }

        private void ShowUploader()
        {
            foreach (Control control in Controls)
            {
                if (control == pnlUpload) continue;

                control.Enabled = false;
            }

            pnlUpload.BringToFront();
            pnlUpload.Visible = true;
        }

        private void HideLoader()
        {
            foreach (Control control in Controls)
            {
                control.Enabled = true;
            }

            loader.Visible = false;
            pnlUpload.Visible = false;
        }

        private async void cmdStartImport_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtImportFolder.Text))
            {
                this.ShowError("An import folder is required");
                return;
            }

            cmdStartImport.Visible = false;

            try
            {
                ShowLoader();

                GetData get = new GetData(DataAccess.APIs.SystemManagement, "ItemNamespace/GetAll");
                List<ItemNamespace> namespaces = await get.GetObject<List<ItemNamespace>>() ?? new List<ItemNamespace>();

                get.Resource = "Item/GetAll";
                List<Item> items = await get.GetObject<List<Item>>() ?? new List<Item>(); // This will probably take a while

                HashSet<byte[]> hashes = items.Select(i => i.Hash).ToHashSet();

                grpPreview.Controls.Clear();

                TabControl tabControl = new TabControl();
                tabControl.Dock = DockStyle.Fill;
                grpPreview.Controls.Add(tabControl);

                void CtrlMthd(Action action)
                {
                    Invoke(new MethodInvoker(action));
                };

                await Task.Run(() =>
                {
                    foreach (string directory in Directory.EnumerateDirectories(txtImportFolder.Text))
                    {
                        string[] nameParts = directory.Split('_');
                        if (nameParts.Length < 3)
                        {
                            this.ShowWarning("The following directory is not in the expected format of yyyy-MM-dd_HH:mm:ss_namespace:\r\n\r\n" + directory + "\r\n\r\nIt will be skipped.");
                            continue;
                        }

                        string itemNamespace = "";
                        for (int i = 2; i < nameParts.Length; i++)
                        {
                            itemNamespace += nameParts[i];
                        }

                        ItemNamespace existingNamespace = namespaces.FirstOrDefault(ins => string.Equals(ins.Namespace, itemNamespace, StringComparison.OrdinalIgnoreCase));
                        TabPage tabPage = null;
                        ListView listView = null;
                        ImageList imageList = null;

                        foreach (string file in Directory.EnumerateFiles(directory, "*.png", SearchOption.TopDirectoryOnly))
                        {
                            Image image;
                            using (FileStream fileStream = new FileStream(file, FileMode.Open))
                            {
                                image = Image.FromStream(fileStream);
                            }

                            using (MemoryStream stream = new MemoryStream())
                            {
                                image.Save(stream, ImageFormat.Png);
                                stream.Position = 0;
                                image = Image.FromStream(stream);
                            }

                            string imageName = Path.GetFileNameWithoutExtension(file);
                            imageName = imageName.TrimStart('_');
                            imageName = imageName.Replace('_', ' ').Trim();

                            imagesByNamespaceName.Add($"{itemNamespace}:{imageName}", image);

                            bool willAddToList = existingNamespace == null;
                            if (!willAddToList)
                            {
                                byte[] imageBytes;
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    image.Save(stream, ImageFormat.Png);
                                    stream.Position = 0;

                                    imageBytes = new byte[stream.Length];
                                    stream.Read(imageBytes, 0, imageBytes.Length);
                                }

                                byte[] hash = GenerateHashBasedOnWebModelsHashingStrategy(imageBytes, existingNamespace.ItemNamespaceID);

                                willAddToList = !hashes.Any(ba => ba.SequenceEqual(hash));
                            }

                            if (willAddToList)
                            {
                                if (tabPage == null)
                                {
                                    CtrlMthd(() =>
                                    {
                                        imageList = new ImageList(components)
                                        {
                                            ImageSize = new Size(32, 32)
                                        };

                                        tabPage = new TabPage()
                                        {
                                            Name = "tab" + itemNamespace,
                                            Text = existingNamespace?.FriendlyName ?? itemNamespace + "*",
                                            Tag = existingNamespace
                                        };
                                        tabControl.TabPages.Add(tabPage);

                                        listView = new ListView()
                                        {
                                            Name = "lv" + itemNamespace,
                                            LargeImageList = imageList,
                                            View = View.LargeIcon,
                                            Dock = DockStyle.Fill
                                        };
                                        tabPage.Controls.Add(listView);
                                    });
                                }

                                CtrlMthd(() =>
                                {
                                    imageList.Images.Add(imageName, image);
                                    ListViewItem item = new ListViewItem(imageName, imageName);
                                    listView.Items.Add(item);
                                });
                            }
                        }
                    }
                });
            }
            finally
            {
                HideLoader();
                cmdCommit.Enabled = true;
            }
        }

        private byte[] GenerateHashBasedOnWebModelsHashingStrategy(byte[] image, long? namespaceID)
        {
            byte[] nameBytes = Encoding.UTF8.GetBytes(string.Format("{0}", namespaceID));

            byte[] prehashBytes = new byte[nameBytes.Length + image.Length];
            Array.Copy(nameBytes, prehashBytes, nameBytes.Length);
            Array.Copy(image, 0, prehashBytes, nameBytes.Length, image.Length);

            using (MD5 md5 = MD5.Create())
            {
                return md5.ComputeHash(prehashBytes);
            }
        }

        private async void cmdCommit_Click(object sender, EventArgs e)
        {
            try
            {
                TabControl tabControl = grpPreview.Controls.OfType<TabControl>().Single();

                ShowUploader();

                prgNamespace.Maximum = tabControl.TabPages.Count;
                prgNamespace.Value = 0;
                prgNamespace.Step = 1;

                foreach(TabPage tabPage in tabControl.TabPages)
                {
                    prgNamespace.Increment(1);
                    lblNamespace.Text = "Namespace: " + tabPage.Text;

                    ListView listView = tabPage.Controls.OfType<ListView>().Single();
                    prgItem.Maximum = listView.Items.Count;
                    prgItem.Value = 0;
                    prgItem.Step = 1;

                    ItemNamespace itemNamespace = tabPage.Tag.Cast<ItemNamespace>();
                    if (itemNamespace == null)
                    {
                        itemNamespace = new ItemNamespace()
                        {
                            Namespace = tabPage.Text.Substring(0, tabPage.Text.Length - 1),
                            FriendlyName = tabPage.Text.Substring(0, tabPage.Text.Length - 1)
                        };

                        PostData post = new PostData(DataAccess.APIs.SystemManagement, "ItemNamespace/Post", itemNamespace);
                        itemNamespace = await post.Execute<ItemNamespace>();

                        new frmEditItemNamespace()
                        {
                            ItemNamespaceID = itemNamespace.ItemNamespaceID,
                            DisableNamespace = true
                        }.ShowDialog();
                    }

                    foreach (ListViewItem item in listView.Items)
                    {
                        prgItem.Increment(1);
                        lblItem.Text = "Item: " + item.Text;

                        Image image = imagesByNamespaceName[$"{itemNamespace.Namespace}:{item.Text}"];
                        byte[] imageData;
                        using (MemoryStream stream = new MemoryStream())
                        {
                            image.Save(stream, ImageFormat.Png);

                            stream.Position = 0;

                            imageData = new byte[stream.Length];
                            stream.Read(imageData, 0, imageData.Length);
                        }

                        Item newItem = new Item()
                        {
                            ItemNamespaceID = itemNamespace.ItemNamespaceID,
                            Name = item.Text,
                            Image = imageData
                        };

                        PostData post = new PostData(DataAccess.APIs.SystemManagement, "Item/Post", newItem);
                        await post.ExecuteNoResult();
                    }
                }
            }
            finally
            {
                HideLoader();
            }

            Close();
        }
    }
}
