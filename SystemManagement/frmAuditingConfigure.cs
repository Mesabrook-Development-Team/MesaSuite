using MesaSuite.Common.Data;
using MesaSuite.Common.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemManagement.Models;

namespace SystemManagement
{
    public partial class frmAuditingConfigure : Form
    {
        private long? configID;

        public frmAuditingConfigure()
        {
            InitializeComponent();
        }

        private async void frmAuditingConfigure_Load(object sender, EventArgs e)
        {
            GetData get = new GetData(DataAccess.APIs.SystemManagement, "ItemNamespace/GetAll");
            List<ItemNamespace> itemNamespaces = await get.GetObject<List<ItemNamespace>>() ?? new List<ItemNamespace>();

            foreach(ItemNamespace itemNamespace in itemNamespaces.OrderBy(ns => ns.FriendlyName))
            {
                cboNamespaces.Items.Add(new DropDownItem<ItemNamespace>(itemNamespace, itemNamespace.FriendlyName));
            }

            get = new GetData(DataAccess.APIs.SystemManagement, "BlockAuditAlertConfig/Get");
            BlockAuditAlertConfig blockAuditAlertConfig = await get.GetObject<BlockAuditAlertConfig>() ?? new BlockAuditAlertConfig();
            configID = blockAuditAlertConfig.BlockAuditAlertConfigID;
            _suppressDiscordIDChange = true;
            txtDiscordIDs.Text = blockAuditAlertConfig.DiscordIDs;
            _suppressDiscordIDChange = false;

            _suppressValidated = true;
            foreach(BlockAuditAlertConfigBlock block in blockAuditAlertConfig.BlockAuditAlertConfigBlocks?.OrderBy(baacb => baacb.BlockName) ?? Enumerable.Empty<BlockAuditAlertConfigBlock>())
            {
                AddRowToDataGridView(block);
            }
            _suppressValidated = false;
        }

        private void AddRowToDataGridView(BlockAuditAlertConfigBlock block)
        {
            DataGridViewRow row = dgvBlocks.Rows[dgvBlocks.Rows.Add()];
            row.Cells[colBlockName.Name].Value = block.BlockName;
            row.Cells[colAlertPlace.Name].Value = block.AlertPlace;
            row.Cells[colAlertBreak.Name].Value = block.AlertBreak;
            row.Cells[colAlertUse.Name].Value = block.AlertUse;
            row.Tag = block;
        }

        bool _suppressValidated;
        private async void dgvBlocks_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvBlocks.Rows.Count || _suppressValidated || !IsHandleCreated)
            {
                return;
            }

            DataGridViewRow row = dgvBlocks.Rows[e.RowIndex];
            if (row.IsNewRow) return;
            BlockAuditAlertConfigBlock block = row.Tag as BlockAuditAlertConfigBlock;

            if (block == null)
            {
                block = new BlockAuditAlertConfigBlock()
                {
                    BlockAuditAlertConfigID = configID
                };
            }

            block.BlockName = row.Cells[colBlockName.Name].Value as string;
            block.AlertPlace = row.Cells[colAlertPlace.Name].Value as bool? ?? false;
            block.AlertBreak = row.Cells[colAlertBreak.Name].Value as bool? ?? false;
            block.AlertUse = row.Cells[colAlertUse.Name].Value as bool? ?? false;

            if (block.BlockAuditAlertConfigBlockID == null)
            {
                PostData post = new PostData(DataAccess.APIs.SystemManagement, "BlockAuditAlertConfigBlock/Post", block);
                block = await post.Execute<BlockAuditAlertConfigBlock>();
                if (post.RequestSuccessful)
                {
                    row.Tag = block;
                    DisplaySaved();
                }
            }
            else
            {
                PutData put = new PutData(DataAccess.APIs.SystemManagement, "BlockAuditAlertConfigBlock/Put", block);
                await put.ExecuteNoResult();
                if (put.RequestSuccessful)
                {
                    DisplaySaved();
                }
            }

            _suppressValidated = true;
            if (!IsHandleCreated) return;
            dgvBlocks.Sort(colBlockName, System.ComponentModel.ListSortDirection.Ascending);
            _suppressValidated = false;
        }

        private async void dgvBlocks_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            BlockAuditAlertConfigBlock block = e.Row.Tag as BlockAuditAlertConfigBlock;
            if (block == null)
            {
                return;
            }

            DeleteData delete = new DeleteData(DataAccess.APIs.SystemManagement, "BlockAuditAlertConfigBlock/Delete/" + block.BlockAuditAlertConfigBlockID);
            await delete.Execute();

            if (delete.RequestSuccessful)
            {
                DisplaySaved();
            }
        }

        private void DisplaySaved()
        {
            lblSaved.Visible = true;

            tmrSaveLabelTimer.Stop();
            tmrSaveLabelTimer.Start();
        }

        private void tmrSaveLabelTimer_Tick(object sender, EventArgs e)
        {
            lblSaved.Visible = false;
            tmrSaveLabelTimer.Stop();
        }

        private bool _suppressDiscordIDChange;
        private async void txtDiscordIDs_TextChanged(object sender, EventArgs e)
        {
            if (_suppressDiscordIDChange) return;

            BlockAuditAlertConfig config = new BlockAuditAlertConfig()
            {
                BlockAuditAlertConfigID = configID,
                DiscordIDs = txtDiscordIDs.Text
            };

            PutData put = new PutData(DataAccess.APIs.SystemManagement, "BlockAuditAlertConfig/Put", config);
            await put.ExecuteNoResult();
            if (put.RequestSuccessful)
            {
                DisplaySaved();
            }
        }

        private async void cmdAddNamespace_Click(object sender, EventArgs e)
        {
            DropDownItem<ItemNamespace> ddi = cboNamespaces.SelectedItem as DropDownItem<ItemNamespace>;
            if (ddi == null) return;

            DialogResult res = MessageBox.Show("Default Alert Place to checked?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Cancel) return;
            bool alertPlace = res == DialogResult.Yes;

            res = MessageBox.Show("Default Alert Break to checked?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Cancel) return;
            bool alertBreak = res == DialogResult.Yes;

            res = MessageBox.Show("Default Alert Use to checked?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Cancel) return;
            bool alertUse = res == DialogResult.Yes;

            cmdAddNamespace.Enabled = false;

            try
            {
                GetData get = new GetData(DataAccess.APIs.SystemManagement, "Item/GetByQuery");
                get.QueryString.Add("t", int.MaxValue.ToString());
                get.QueryString.Add("ins", ddi.Object.ItemNamespaceID.ToString());

                _suppressValidated = true;
                dgvBlocks.ReadOnly = true;
                foreach(Item item in await get.GetObject<List<Item>>() ?? new List<Item>())
                {
                    BlockAuditAlertConfigBlock block = new BlockAuditAlertConfigBlock()
                    {
                        BlockAuditAlertConfigID = configID,
                        BlockName = item.Name,
                        AlertPlace = alertPlace,
                        AlertBreak = alertBreak,
                        AlertUse = alertUse
                    };

                    PostData post = new PostData(DataAccess.APIs.SystemManagement, "BlockAuditAlertConfigBlock/Post", block);
                    block = await post.Execute<BlockAuditAlertConfigBlock>();

                    if (post.RequestSuccessful)
                    {
                        AddRowToDataGridView(block);
                    }
                }

                dgvBlocks.Sort(colBlockName, System.ComponentModel.ListSortDirection.Ascending);
                dgvBlocks.ReadOnly = false;
                _suppressValidated = false;
            }
            finally
            {
                cmdAddNamespace.Enabled = true;
            }
        }
    }
}
