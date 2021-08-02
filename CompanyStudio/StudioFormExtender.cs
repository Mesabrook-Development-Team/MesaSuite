using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio
{
    public partial class StudioFormExtender : Component
    {
        public StudioFormExtender()
        {
            InitializeComponent();
        }

        public StudioFormExtender(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ApplyStyle(Form form, ThemeBase theme)
        {
            form.BackColor = theme.ColorPalette.CommandBarToolbarDefault.Background;
            form.ForeColor = theme.ColorPalette.CommandBarMenuDefault.Text;

            foreach(Button button in form.Controls.OfType<Button>())
            {
                button.ForeColor = Color.Black;
            }

            foreach(Loader loader in form.Controls.OfType<Loader>())
            {
                loader.BackColor = Color.Transparent;
            }

            foreach(ListView listView in form.Controls.OfType<ListView>())
            {
                listView.BackColor = theme.ColorPalette.CommandBarToolbarDefault.Background;
                listView.ForeColor = theme.ColorPalette.CommandBarMenuDefault.Text;
            }

            foreach (TreeView treeView in form.Controls.OfType<TreeView>())
            {
                treeView.BackColor = theme.ColorPalette.CommandBarToolbarDefault.Background;
                treeView.ForeColor = theme.ColorPalette.CommandBarMenuDefault.Text;
            }

            foreach (ListBox listBox in form.Controls.OfType<ListBox>())
            {
                listBox.BackColor = theme.ColorPalette.CommandBarToolbarDefault.Background;
                listBox.ForeColor = theme.ColorPalette.CommandBarMenuDefault.Text;
            }
        }
    }
}
