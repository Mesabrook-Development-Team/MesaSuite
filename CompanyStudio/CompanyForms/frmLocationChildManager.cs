using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio.CompanyForms
{
    public partial class frmLocationChildManager : Form
    {
        public delegate Task<bool> SaveActionDelegate();

        public ThemeBase Theme { get; set; }
        public Control ChildControl { get; set; }
        public SaveActionDelegate SaveAction { get; set; }

        public frmLocationChildManager()
        {
            InitializeComponent();
        }

        public frmLocationChildManager(ThemeBase theme, Control childControl, SaveActionDelegate saveAction) : this()
        {
            Theme = theme;
            ChildControl = childControl;
            SaveAction = saveAction;
        }

        private void frmLocationChildManager_Load(object sender, EventArgs e)
        {
            pnlElement.Controls.Add(ChildControl);
            ChildControl.Location = new Point(0, 0);
            ChildControl.Size = pnlElement.Size;
            ChildControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

            studioFormExtender.ApplyStyle(this, Theme);
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (!await SaveAction())
            {
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
