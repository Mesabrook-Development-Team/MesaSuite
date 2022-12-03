using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.TrainSymbols
{
    public partial class TrainSymbolList : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application = null;
        public FleetTrackingApplication Application { set => _application = value; }
        public bool SelectionMode { get; set; }
        public Func<TrainSymbol, bool> Filter { get; set; }

        public TrainSymbol SelectedSymbol
        {
            get
            {
                if (dgvList.SelectedRows.Count <= 0)
                {
                    return null;
                }

                return dgvList.SelectedRows[0].Tag as TrainSymbol;
            }
        }

        public TrainSymbolList()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvList);
        }

        private async void TrainSymbolList_Load(object sender, EventArgs e)
        {
            if (SelectionMode)
            {
                toolStrip1.Visible = false;
                dgvList.Location = new Point(0, 0);
                dgvList.Size = new Size(dgvList.Width, rdoMySymbols.Top - 3);
            }

            await LoadData();
        }

        private async Task LoadData()
        {
            loader.BringToFront();
            loader.Visible = true;

            try
            {
                dgvList.Rows.Clear();

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "TrainSymbol/GetAll";
                List<TrainSymbol> trainSymbols = await get.GetObject<List<TrainSymbol>>() ?? new List<TrainSymbol>();
                if (Filter != null)
                {
                    label1.Visible = false;
                    rdoAllSymbols.Visible = false;
                    rdoMySymbols.Visible = false;
                    dgvList.Size = new Size(dgvList.Width, Height - dgvList.Top);

                    trainSymbols = trainSymbols.Where(Filter).ToList();
                }

                foreach(TrainSymbol trainSymbol in trainSymbols)
                {
                    int rowIndex = dgvList.Rows.Add();
                    DataGridViewRow row = dgvList.Rows[rowIndex];

                    row.Cells[colName.Name].Value = trainSymbol.Name;
                    row.Cells[colOperator.Name].Value = trainSymbol.CompanyIDOperator != null ? trainSymbol.CompanyOperator.Name : trainSymbol.GovernmentOperator?.Name;
                    row.Tag = trainSymbol;
                }

                Filter_CheckedChanged(null, EventArgs.Empty);
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void Filter_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton filterButton && !filterButton.Checked)
            {
                return;
            }

            foreach(DataGridViewRow row in dgvList.Rows)
            {
                row.Visible = true;

                TrainSymbol symbol = row.Tag as TrainSymbol;
                if (symbol != null && rdoMySymbols.Checked)
                {
                    row.Visible = _application.IsCurrentEntity(symbol.CompanyIDOperator, symbol.GovernmentIDOperator);
                }
            }

            dgvList_SelectionChanged(sender, e);
        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            mnuDelete.Enabled = dgvList.Rows.Cast<DataGridViewRow>().Any(row => row.Tag is TrainSymbol s && _application.IsCurrentEntity(s.CompanyIDOperator, s.GovernmentIDOperator));
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvList.Rows[e.RowIndex];
            TrainSymbol symbol = row.Tag as TrainSymbol;
            if (symbol == null)
            {
                return;
            }

            TrainSymbolDetail detail = new TrainSymbolDetail()
            {
                Application = _application,
                TrainSymbolID = symbol.TrainSymbolID
            };
            detail.OnSave += Detail_OnSave;
            Form detailForm = _application.OpenForm(detail);
            detailForm.Text = "Train Symbol";
        }

        private async void Detail_OnSave(object sender, EventArgs e)
        {
            await LoadData();
        }

        private void mnuAdd_Click(object sender, EventArgs e)
        {
            TrainSymbolDetail detail = new TrainSymbolDetail()
            {
                Application = _application
            };
            detail.OnSave += Detail_OnSave;

            Form detailForm = _application.OpenForm(detail);
            detailForm.Text = "Train Symbol";
        }

        private async void mnuDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count <= 0 || !this.Confirm("Are you sure you want to delete these Train Symbol(s)?"))
            {
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            try
            {
                DeleteData delete = _application.GetAccess<DeleteData>();
                delete.API = DataAccess.APIs.FleetTracking;

                foreach(DataGridViewRow row in dgvList.SelectedRows)
                {
                    TrainSymbol symbol = row.Tag as TrainSymbol;
                    if (symbol == null)
                    {
                        continue;
                    }

                    delete.Resource = $"TrainSymbol/Delete/{symbol.TrainSymbolID}";
                    await delete.Execute();
                }
            }
            finally
            {
                loader.Visible = false;
            }

            await LoadData();
        }
    }
}
