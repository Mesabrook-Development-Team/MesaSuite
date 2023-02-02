using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemManagement.Models;

namespace SystemManagement
{
    public partial class frmItemManager : Form
    {
        private const int MAX_ITEMS = 50;
        private CancellationTokenSource _fetchCancelToken;
        public frmItemManager()
        {
            InitializeComponent();
        }

        private async void frmItemManager_Load(object sender, EventArgs e)
        {
            await LoadNamespaces();
            LoadData();
        }

        private async Task LoadNamespaces()
        {
            if (!IsHandleCreated) return;

            try
            {
                ShowLoader();

                GetData get = new GetData(DataAccess.APIs.SystemManagement, "ItemNamespace/GetAll");
                List<ItemNamespace> itemNamespaces = await get.GetObject<List<ItemNamespace>>() ?? new List<ItemNamespace>();
                itemNamespaces = itemNamespaces.OrderBy(ins => ins.FriendlyName).ToList();

                chkNamespaces.Items.Clear();
                chkNamespaces.Items.Add(new DropDownItem<ItemNamespace>(null, "(All)"), true);

                foreach(ItemNamespace itemNamespace in itemNamespaces)
                {
                    DropDownItem<ItemNamespace> ddi = new DropDownItem<ItemNamespace>(itemNamespace, itemNamespace.FriendlyName);
                    chkNamespaces.Items.Add(ddi, true);
                }
            }
            finally
            {
                HideLoader();
            }
        }

        private async void LoadData(bool fromSearchBox = false)
        {
            if (!IsHandleCreated) return;

            try
            {
                ShowLoader(fromSearchBox);

                if (_fetchCancelToken != null)
                {
                    _fetchCancelToken.Cancel();
                }

                _fetchCancelToken = new CancellationTokenSource();
                CancellationToken token = _fetchCancelToken.Token;

                GetData get = new GetData(DataAccess.APIs.SystemManagement, "Item/GetByQuery");
                get.QueryString.Add("t", MAX_ITEMS.ToString());

                bool allChecked = chkNamespaces.CheckedItems.OfType<DropDownItem<ItemNamespace>>().Any(ins => ins.Object == null);
                if (!allChecked)
                {
                    foreach (DropDownItem<ItemNamespace> ddi in chkNamespaces.CheckedItems.OfType<DropDownItem<ItemNamespace>>())
                    {
                        if (ddi.Object == null)
                        {
                            continue;
                        }

                        get.QueryString.Add("ins", ddi.Object.ItemNamespaceID.ToString());
                    }
                }

                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    get.QueryString.Add("q", txtSearch.Text);
                }

                if (token.IsCancellationRequested)
                {
                    return;
                }

                List<Item> items = await get.GetObject<List<Item>>() ?? new List<Item>();

                if (token.IsCancellationRequested)
                {
                    return;
                }

                lstItems.Items.Clear();
                lstItems.Groups.Clear();
                imageList.Images.Clear();

                foreach (Item item in items)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }

                    Image image = item.GetImage();
                    if (image != null)
                    {
                        imageList.Images.Add(item.ItemNamespace.Namespace + ":" + item.Name, image);
                    }

                    ListViewGroup group = lstItems.Groups[item.ItemNamespace.Namespace];
                    if (group == null)
                    {
                        group = new ListViewGroup(item.ItemNamespace.Namespace, item.ItemNamespace.FriendlyName);
                        lstItems.Groups.Add(group);
                    }

                    ListViewItem listItem = new ListViewItem(item.Name, item.ItemNamespace.Namespace + ":" + item.Name, group);
                    listItem.Tag = item;
                    lstItems.Items.Add(listItem);
                }
            }
            finally
            {
                HideLoader(fromSearchBox);
            }
        }

        private void ShowLoader(bool allowSearchBox = false)
        {
            loader.BringToFront();
            loader.Visible = true;
            if (!allowSearchBox)
            {
                toolStrip.Enabled = false;
            }
            else
            {
                foreach(ToolStripItem item in toolStrip.Items)
                {
                    item.Enabled = item == txtSearch;
                }
            }
            splitContainer.Enabled = false;
        }

        private void HideLoader(bool allowSearchBox = false)
        {
            loader.Visible = false;
            if (!allowSearchBox)
            {
                toolStrip.Enabled = true;
            }
            else
            {
                foreach (ToolStripItem item in toolStrip.Items)
                {
                    item.Enabled = true;
                }
            }
            splitContainer.Enabled = true;
        }

        private void toolAddItem_Click(object sender, EventArgs e)
        {
            frmEditItem editItem = new frmEditItem();
            editItem.FormClosed += (s, ea) => { LoadData(); };
            editItem.Show();
        }

        private void toolAddNamespace_Click(object sender, EventArgs e)
        {
            frmEditItemNamespace editNamespace = new frmEditItemNamespace();
            editNamespace.FormClosed += async (s, ea) => { await LoadNamespaces(); LoadData(); };
            editNamespace.Show();
        }

        private void ctxNamespace_Opening(object sender, CancelEventArgs e)
        {
            mnuEditNamespace.Enabled = chkNamespaces.SelectedItems.Count > 0;
            mnuDeleteNamespace.Enabled = chkNamespaces.SelectedItems.Count > 0;
        }

        private void ctxItem_Opening(object sender, CancelEventArgs e)
        {
            mnuEditItem.Enabled = lstItems.SelectedItems.Count > 0;
            mnuDeleteItem.Enabled = lstItems.SelectedItems.Count > 0;
        }

        private void mnuEditNamespace_Click(object sender, EventArgs e)
        {
            if (chkNamespaces.SelectedItems.Count <= 0)
            {
                return;
            }

            DropDownItem<ItemNamespace> ddi = chkNamespaces.SelectedItems[0].Cast<DropDownItem<ItemNamespace>>();
            if (ddi?.Object == null)
            {
                return;
            }

            frmEditItemNamespace editNamespace = new frmEditItemNamespace()
            {
                ItemNamespaceID = ddi.Object.ItemNamespaceID
            };
            editNamespace.FormClosed += async (s, ea) => { await LoadNamespaces(); LoadData(); };
            editNamespace.Show();
        }

        private async void mnuDeleteNamespace_Click(object sender, EventArgs e)
        {
            if (chkNamespaces.SelectedItems.Count <= 0 || !this.Confirm("Are you sure you want to delete these Namespaces?"))
            {
                return;
            }

            foreach(DropDownItem<ItemNamespace> ddi in chkNamespaces.SelectedItems.OfType<DropDownItem<ItemNamespace>>())
            {
                if (ddi.Object == null)
                {
                    continue;
                }

                if (lstItems.Groups.OfType<ListViewGroup>().Any(lvg => lvg.Header == ddi.Object.FriendlyName))
                {
                    this.ShowError("Cannot delete namespace '" + ddi.Object.FriendlyName + "' - it is currently in use");
                    return;
                }
            }

            try
            {
                ShowLoader();

                DeleteData delete = new DeleteData(DataAccess.APIs.SystemManagement, "ItemNamespace/Delete");

                foreach (DropDownItem<ItemNamespace> ddi in chkNamespaces.SelectedItems.OfType<DropDownItem<ItemNamespace>>())
                {
                    if (ddi.Object == null)
                    {
                        continue;
                    }

                    delete.Resource = $"ItemNamespace/Delete/{ddi.Object.ItemNamespaceID}";
                    await delete.Execute();
                }
            }
            finally
            {
                HideLoader();
            }

            await LoadNamespaces();
        }

        private void mnuEditItem_Click(object sender, EventArgs e)
        {
            OpenItems();
        }

        private void lstItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenItems();
        }

        private void OpenItems()
        {
            if (lstItems.SelectedItems.Count <= 0)
            {
                return;
            }

            if (lstItems.SelectedItems.Count > 10 && !this.Ask("Are you sure you want to open " + lstItems.SelectedItems.Count + " items?"))
            {
                return;
            }

            foreach(Item item in lstItems.SelectedItems.Cast<ListViewItem>().Select(lvi => lvi.Tag).OfType<Item>())
            {
                frmEditItem editItem = new frmEditItem()
                {
                    ItemID = item.ItemID
                };
                editItem.FormClosed += (s, ea) => LoadData();
                editItem.Show();
            }
        }

        private bool _suppressItemCheck = false;
        private void chkNamespaces_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_suppressItemCheck) return;

            DropDownItem<ItemNamespace> namespaceChecked = chkNamespaces.Items[e.Index].Cast<DropDownItem<ItemNamespace>>();
            if (namespaceChecked == null)
            {
                return;
            }

            if (namespaceChecked.Object == null) // Is "all" checkbox
            {
                try
                {
                    _suppressItemCheck = true;

                    for(int i = 0; i < chkNamespaces.Items.Count; i++)
                    {
                        chkNamespaces.SetItemChecked(i, e.NewValue == CheckState.Checked);
                    }
                }
                finally
                {
                    _suppressItemCheck = false;
                }
            }
            else
            {
                bool allShouldBeChecked = true;
                for(int i = 1; i < chkNamespaces.Items.Count; i++)
                {
                    if (i == e.Index)
                    {
                        allShouldBeChecked &= e.NewValue == CheckState.Checked;
                    }
                    else
                    {
                        allShouldBeChecked &= chkNamespaces.GetItemChecked(i);
                    }
                }

                try
                {
                    _suppressItemCheck = true;
                    chkNamespaces.SetItemChecked(0, allShouldBeChecked);
                }
                finally
                {
                    _suppressItemCheck = false;
                }
            }

            BeginInvoke(new MethodInvoker(() => LoadData()));
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            LoadData(true);
        }

        private void toolImportItems_Click(object sender, EventArgs e)
        {
            frmItemImporter importer = new frmItemImporter();
            importer.FormClosed += async (s, ea) => { await LoadNamespaces(); LoadData(); };
            importer.Show();
        }

        private async void mnuDeleteItem_Click(object sender, EventArgs e)
        {
            if (lstItems.SelectedItems.Count <= 0 || !this.Confirm("Are you sure you want to delete these Items?"))
            {
                return;
            }

            try
            {
                ShowLoader();

                DeleteData deleteData = new DeleteData(DataAccess.APIs.SystemManagement, "Item/Delete");
                foreach(ListViewItem item in lstItems.SelectedItems)
                {
                    Item itemToDelete = item.Tag.Cast<Item>();
                    deleteData.Resource = $"Item/Delete/{itemToDelete.ItemID}";
                    await deleteData.Execute();
                }
            }
            finally
            {
                HideLoader();
            }

            LoadData();
        }
    }
}
