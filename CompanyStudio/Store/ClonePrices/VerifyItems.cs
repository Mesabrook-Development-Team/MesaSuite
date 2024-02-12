using CompanyStudio.Extensions;
using CompanyStudio.Models;
using CompanyStudio.Wizard;
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

namespace CompanyStudio.Store.ClonePrices
{
    public partial class VerifyItems : UserControl, IWizardStep<ClonePricesWizardData>
    {
        private const string CHECK_COL_NAME = "colAdd";
        private const string IMAGE_COL_NAME = "colImage";
        private const string ITEM_COL_NAME = "colItem";
        private const string QUANTITY_COL_NAME = "colQuantity";
        private const string BASE_PRICE_COL_NAME = "colBasePrice";

        private readonly Func<(long?, long?), ClonePricesWizardData, List<LocationItem>> _itemPopulationFunction;
        private readonly string _checkboxHeader;
        private Func<ClonePricesWizardData, Dictionary<long?, List<long?>>> _dictionaryToFill;
        public VerifyItems(Func<(long?, long?), ClonePricesWizardData, List<LocationItem>> itemPopulationFunction, string checkboxHeader, Func<ClonePricesWizardData, Dictionary<long?, List<long?>>> dictionaryToFill)
        {
            InitializeComponent();
            _itemPopulationFunction = itemPopulationFunction;
            _checkboxHeader = checkboxHeader;
            _dictionaryToFill = dictionaryToFill;
        }

        public string NavigationName => $"Verify {_checkboxHeader}";

        public Control Control => this;

        public async Task Commit(ClonePricesWizardData data)
        {
            Dictionary<long?, List<long?>> dictionary = _dictionaryToFill(data);
            dictionary.Clear();

            foreach(DataGridView dataGridView in flow.Controls.OfType<GroupBox>().SelectMany(gp => gp.Controls.OfType<DataGridView>()))
            {
                long? locationID = (long?)dataGridView.Tag;
                foreach(DataGridViewRow row in dataGridView.Rows)
                {
                    bool isChecked = row.Cells[CHECK_COL_NAME].Value is bool && (bool)row.Cells[CHECK_COL_NAME].Value;
                    if (!isChecked)
                    {
                        continue;
                    }

                    LocationItem locationItem = (LocationItem)row.Tag;
                    dictionary.GetOrSetDefault(locationID, () => new List<long?>()).Add(locationItem.LocationItemID);
                }
            }
        }

        async Task IWizardStep<ClonePricesWizardData>.Load(ClonePricesWizardData data)
        {
            lblTitle.Text = "Verify the items you want to " + _checkboxHeader.ToLower();
            flow.Controls.Clear();

            Dictionary<long?, List<long?>> dictionary = _dictionaryToFill(data);

            foreach ((long?, long?) companyIDLocationID in data.CompanyIDLocationIDDestinations)
            {
                List<LocationItem> itemsToPopulate = _itemPopulationFunction(companyIDLocationID, data);
                if (!itemsToPopulate.Any())
                {
                    continue;
                }

                GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Location/Get/" + companyIDLocationID.Item2);
                get.AddLocationHeader(companyIDLocationID.Item1, companyIDLocationID.Item2);
                Location location = await get.GetObject<Location>();

                GroupBox groupBox = CreateGroupBox(location.Name + " (" + location.Company.Name + ")");
                DataGridView grid = CreateDataGridView();
                grid.Tag = companyIDLocationID.Item2;

                foreach (LocationItem item in itemsToPopulate)
                {
                    int rowIndex = grid.Rows.Add();
                    DataGridViewRow row = grid.Rows[rowIndex];
                    row.Cells[CHECK_COL_NAME].Value = dictionary.GetOrDefault(companyIDLocationID.Item2, new List<long?>()).Contains(item.LocationItemID);
                    row.Cells[IMAGE_COL_NAME].Value = item.Item.GetImage();
                    row.Cells[ITEM_COL_NAME].Value = item.Item.Name;
                    row.Cells[QUANTITY_COL_NAME].Value = item.Quantity;
                    row.Cells[BASE_PRICE_COL_NAME].Value = item.BasePrice;
                    row.Tag = item;
                }

                groupBox.Controls.Add(grid);
                flow.Controls.Add(groupBox);
            }
        }

        private GroupBox CreateGroupBox(string name)
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Width = flow.Width - 10;
            groupBox.Text = name;
            return groupBox;
        }

        private DataGridView CreateDataGridView()
        {
            DataGridView grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.Columns.AddRange(
                new DataGridViewCheckBoxColumn()
                {
                    Name = CHECK_COL_NAME,
                    HeaderText = _checkboxHeader,
                    Width = 40
                },
                new DataGridViewImageColumn()
                {
                    Name = IMAGE_COL_NAME,
                    HeaderText = "Image",
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 40
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = ITEM_COL_NAME,
                    HeaderText = "Item",
                    ReadOnly = true,
                    Width = 200
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = QUANTITY_COL_NAME,
                    HeaderText = "Quantity",
                    ReadOnly = true,
                    Width = 85
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = BASE_PRICE_COL_NAME,
                    HeaderText = "Base Price",
                    ReadOnly = true,
                    Width = 85
                });
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToOrderColumns = false;
            grid.Height = 150;

            return grid;
        }

        async Task<List<string>> IWizardStep<ClonePricesWizardData>.Validate()
        {
            return new List<string>();
        }
    }
}
