using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FleetTracking
{
    public partial class DataGridViewStylizer : Component
    {
        public DataGridViewStylizer()
        {
            InitializeComponent();
        }

        public DataGridViewStylizer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ApplyStyle(DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                Font = new Font(FontFamily.GenericSansSerif, 8.25F, FontStyle.Bold)
            };
            dataGridView.DefaultCellStyle = new DataGridViewCellStyle()
            {
                SelectionBackColor = Color.DarkGray
            };
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
