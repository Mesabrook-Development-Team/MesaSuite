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

        public void ApplyStyle(Control control, ThemeBase theme)
        {
            control.BackColor = theme.ColorPalette.CommandBarToolbarDefault.Background;
            control.ForeColor = theme.ColorPalette.CommandBarMenuDefault.Text;

            foreach(Button button in control.Controls.OfType<Button>())
            {
                button.ForeColor = Color.Black;
            }

            foreach(Loader loader in control.Controls.OfType<Loader>())
            {
                loader.BackColor = Color.Transparent;
            }

            foreach(ListView listView in control.Controls.OfType<ListView>())
            {
                listView.BackColor = theme.ColorPalette.CommandBarToolbarDefault.Background;
                listView.ForeColor = theme.ColorPalette.CommandBarMenuDefault.Text;
            }

            foreach (TreeView treeView in control.Controls.OfType<TreeView>())
            {
                treeView.BackColor = theme.ColorPalette.CommandBarToolbarDefault.Background;
                treeView.ForeColor = theme.ColorPalette.CommandBarMenuDefault.Text;
            }

            foreach (ListBox listBox in control.Controls.OfType<ListBox>())
            {
                listBox.BackColor = theme.ColorPalette.CommandBarToolbarDefault.Background;
                listBox.ForeColor = theme.ColorPalette.CommandBarMenuDefault.Text;
            }

            foreach(TabControl tabControl in control.Controls.OfType<TabControl>())
            {
                foreach(TabPage page in tabControl.TabPages)
                {
                    ApplyStyle(page, theme);
                }
            }

            foreach(DataGridView dataGridView in control.Controls.OfType<DataGridView>())
            {
                dataGridView.BackgroundColor = theme.ColorPalette.CommandBarToolbarDefault.Background;
                dataGridView.ForeColor = Color.Black;
            }

            foreach(ToolStrip toolStrip in control.Controls.OfType<ToolStrip>())
            {
                toolStrip.BackColor = theme.ColorPalette.CommandBarToolbarDefault.Background;
                toolStrip.ForeColor = theme.ColorPalette.CommandBarMenuDefault.Text;
            }

            foreach(Panel panel in control.Controls.OfType<Panel>())
            {
                ApplyStyle(panel, theme);
            }

            foreach(UserControl userControl in control.Controls.OfType<UserControl>())
            {
                ApplyStyle(userControl, theme);
            }

            foreach(GroupBox groupBox in control.Controls.OfType<GroupBox>())
            {
                //groupBox.ForeColor = theme.ColorPalette.CommandBarMenuDefault.Text;
                //groupBox.BackColor = theme.ColorPalette.CommandBarToolbarDefault.Background;

                ApplyStyle(groupBox, theme);
            }
        }
    }
}
