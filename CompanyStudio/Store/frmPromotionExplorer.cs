using CompanyStudio.Extensions;
using CompanyStudio.Models;
using MesaSuite.Common;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio.Store
{
    public partial class frmPromotionExplorer : BaseCompanyStudioContent, ILocationScoped
    {
        private List<Promotion> promotions = new List<Promotion>();

        public frmPromotionExplorer()
        {
            InitializeComponent();
        }

        public Location LocationModel { get; set; }

        private void frmPromotionExplorer_Load(object sender, EventArgs e)
        {
            dgvPromotions.DefaultCellStyle.BackColor = dgvPromotions.BackgroundColor;
            dgvPromotions.GridColor = dgvPromotions.BackgroundColor;

            UserPreferences preferences = UserPreferences.Get();
            mnuShowActive.Checked = preferences.GetPreferencesForSection("company").GetOrSetDefault("showActivePromotions", true).Cast<bool>();
            mnuShowHistorical.Checked = preferences.GetPreferencesForSection("company").GetOrSetDefault("showHistoricalPromotions", false).Cast<bool>();
            preferences.Save();

            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Promotion/GetAll");
                get.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                promotions = await get.GetObject<List<Promotion>>() ?? new List<Promotion>();

                FillDataGridView();

                dgvPromotions.Sort(colStartDate, System.ComponentModel.ListSortDirection.Descending);
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void FillDataGridView()
        {
            dgvPromotions.Rows.Clear();

            List<Promotion> filteredPromotions = new List<Promotion>();
            if (mnuShowActive.Checked)
            {
                filteredPromotions.AddRange(promotions.Where(p => p.EndTime > DateTime.Now));
            }

            if (mnuShowHistorical.Checked)
            {
                filteredPromotions.AddRange(promotions.Where(p => p.EndTime <= DateTime.Now));
            }

            foreach (Promotion promotion in filteredPromotions)
            {
                int rowIndex = dgvPromotions.Rows.Add();
                DataGridViewRow row = dgvPromotions.Rows[rowIndex];
                row.Cells[0].Value = promotion.Name;
                row.Cells[1].Value = promotion.StartTime?.ToString("MM/dd/yyyy");
                row.Cells[2].Value = promotion.EndTime?.ToString("MM/dd/yyyy");
                row.Cells[3].Value = promotion.PromotionLocationItems?.Count ?? 0;
                row.Tag = promotion;
            }
        }

        private void mnuAddPromo_Click(object sender, EventArgs e)
        {
            frmPromotion newPromo = new frmPromotion();
            Studio.DecorateStudioContent(newPromo);
            newPromo.LocationModel = LocationModel;
            newPromo.Company = Company;
            newPromo.FormClosed += EditPromotion_FormClosed;
            newPromo.OnSave += EditPromotion_OnSave;
            newPromo.Show(Studio.dockPanel, DockState.Document);
        }

        private void dgvPromotions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvPromotions.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = dgvPromotions.Rows[e.RowIndex];
            Promotion promotion = (Promotion)row.Tag;

            frmPromotion editPromotion = new frmPromotion();
            editPromotion.PromotionID = promotion.PromotionID;
            Studio.DecorateStudioContent(editPromotion);
            editPromotion.Company = Company;
            editPromotion.LocationModel = LocationModel;
            editPromotion.FormClosed += EditPromotion_FormClosed;
            editPromotion.OnSave += EditPromotion_OnSave;
            editPromotion.Show(Studio.dockPanel, DockState.Document);
        }

        private void EditPromotion_OnSave(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                LoadData();
            }
        }

        private void EditPromotion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsHandleCreated)
            {
                LoadData();
            }
        }

        private void mnuShowActive_Click(object sender, EventArgs e)
        {
            mnuShowActive.Checked = !mnuShowActive.Checked;

            UserPreferences preferences = UserPreferences.Get();
            preferences.GetPreferencesForSection("company")["showActivePromotions"] = mnuShowActive.Checked;
            preferences.Save();

            FillDataGridView();
        }

        private void mnuShowHistorical_Click(object sender, EventArgs e)
        {
            mnuShowHistorical.Checked = !mnuShowHistorical.Checked;

            UserPreferences preferences = UserPreferences.Get();
            preferences.GetPreferencesForSection("company")["showHistoricalPromotions"] = mnuShowHistorical.Checked;
            preferences.Save();

            FillDataGridView();
        }

        private async void mnuDelete_Click(object sender, EventArgs e)
        {
            if (!this.Confirm("Are you sure you want to delete these Promotions?"))
            {
                return;
            }

            List<frmPromotion> promotionsToClose = new List<frmPromotion>();
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                foreach (DataGridViewRow row in dgvPromotions.SelectedRows)
                {
                    if (!(row.Tag is Promotion promotion))
                    {
                        continue;
                    }

                    DeleteData delete = new DeleteData(DataAccess.APIs.CompanyStudio, $"Promotion/Delete/{promotion.PromotionID}");
                    delete.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                    await delete.Execute();

                    if (!delete.RequestSuccessful)
                    {
                        return;
                    }

                    IEnumerable<frmPromotion> openPromotions = Application.OpenForms.OfType<frmPromotion>().Where(p => p.PromotionID == promotion.PromotionID);
                    if (openPromotions != null)
                    {
                        promotionsToClose.AddRange(openPromotions);
                    }
                }

                promotionsToClose.ForEach(p => p.Close());
            }
            finally
            {
                loader.Visible = false;
            }

            LoadData();
        }

        private void dgvPromotions_SelectionChanged(object sender, EventArgs e)
        {
            mnuDelete.Enabled = (dgvPromotions.SelectedRows.Count > 0);
        }
    }
}
