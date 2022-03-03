using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyStudio.Extensions;
using CompanyStudio.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace CompanyStudio.CompanyForms
{
    public partial class LocationGovernments : UserControl
    {
        public Company Company { get; set; }
        public Location LocationModel { get; set; }
        public LocationGovernments()
        {
            InitializeComponent();
        }

        public LocationGovernments(Company company, Location locationModel) : this()
        {
            Company = company;
            LocationModel = locationModel;
        }

        private async void LocationGovernments_Load(object sender, EventArgs e)
        {
            loader.BringToFront();
            loader.Visible = true;

            GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Government/GetAll");
            get.AddCompanyHeader(Company.CompanyID);
            List<Government> governments = await get.GetObject<List<Government>>() ?? new List<Government>();

            DataGridViewComboBoxColumn governmentsCol = (DataGridViewComboBoxColumn)dgvGovernments.Columns["colGovernment"];
            governmentsCol.DisplayMember = nameof(Government.Name);
            governmentsCol.ValueMember = nameof(Government.GovernmentID);
            governmentsCol.DataSource = governments;

            foreach (LocationGovernment locationGovernment in LocationModel.LocationGovernments)
            {
                int rowIndex = dgvGovernments.Rows.Add();
                DataGridViewRow row = dgvGovernments.Rows[rowIndex];

                row.Cells["colLocationGovernmentID"].Value = locationGovernment.LocationGovernmentID;
                row.Cells["colGovernment"].Value = locationGovernment.GovernmentID;
                row.Cells["colHasSalesTax"].Value = locationGovernment.PaySalesTax;
            }

            loader.Visible = false;
        }

        public async Task<bool> Save()
        {
            if (!IsHandleCreated)
            {
                return true;
            }

            if (LocationModel == null)
            {
                throw new ArgumentNullException("LocationModel", "LocationModel must be set before saving Location Governments");
            }

            List<LocationGovernment> itemsToSave = new List<LocationGovernment>();
            List<LocationGovernment> itemsToCreate = new List<LocationGovernment>();
            List<LocationGovernment> itemsToDelete = new List<LocationGovernment>();


            foreach(DataGridViewRow row in dgvGovernments.Rows.Cast<DataGridViewRow>().Where(dgv => !dgv.IsNewRow))
            {
                if (row.Cells["colGovernment"].Value == null || ((long)row.Cells["colGovernment"].Value) == default)
                {
                    this.ShowError("Government is required on row " + row.Index);
                    return false;
                }

                LocationGovernment item = new LocationGovernment();

                if (row.Cells["colLocationGovernmentID"].Value != null && ((long)row.Cells["colLocationGovernmentID"].Value) != default)
                {
                    item.LocationGovernmentID = (long)row.Cells["colLocationGovernmentID"].Value;
                    itemsToSave.Add(item);
                }
                else
                {
                    itemsToCreate.Add(item);
                }


                item.LocationID = LocationModel.LocationID;
                item.GovernmentID = (long)row.Cells["colGovernment"].Value;
                item.PaySalesTax = (bool)(row.Cells["colHasSalesTax"].Value ?? false);
            }

            itemsToDelete.AddRange(LocationModel.LocationGovernments.Where(lg => !itemsToSave.Concat(itemsToCreate).Any(item => item.LocationGovernmentID == lg.LocationGovernmentID)));

            HashSet<long> governmentIDs = new HashSet<long>();
            foreach (LocationGovernment item in itemsToSave.Concat(itemsToCreate))
            {
                if (!governmentIDs.Add(item.GovernmentID))
                {
                    this.ShowError("Governments may only be specified once");
                    return false;
                }
            }

            bool success = true;
            foreach(LocationGovernment item in itemsToDelete)
            {
                DeleteData delete = new DeleteData(DataAccess.APIs.CompanyStudio, $"LocationGovernment/Delete/{item.LocationGovernmentID}");
                delete.AddCompanyHeader(Company.CompanyID);
                await delete.Execute();
                success = success && delete.RequestSuccessful;
            }

            foreach(LocationGovernment update in itemsToSave)
            {
                PutData put = new PutData(DataAccess.APIs.CompanyStudio, "LocationGovernment/Put", update);
                put.AddCompanyHeader(Company.CompanyID);
                await put.ExecuteNoResult();
                success = success && put.RequestSuccessful;
            }

            foreach(LocationGovernment create in itemsToCreate)
            {
                PostData post = new PostData(DataAccess.APIs.CompanyStudio, "LocationGovernment/Post", create);
                post.AddCompanyHeader(Company.CompanyID);
                await post.ExecuteNoResult();
                success &= post.RequestSuccessful;
            }

            return success;
        }
    }
}
