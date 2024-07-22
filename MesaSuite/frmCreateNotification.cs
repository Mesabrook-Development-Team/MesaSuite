using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite
{
    public partial class frmCreateNotification : Form
    {
        private int currentTab = 0;
        public frmCreateNotification()
        {
            InitializeComponent();
        }

        private void airButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void lostCancelButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void foreverButton1_Click(object sender, EventArgs e)
        {
            currentTab++;
            tabPage1.SelectedIndex = currentTab;
        }

        private void foreverButton2_Click(object sender, EventArgs e)
        {
            currentTab++;
            tabPage1.SelectedIndex = currentTab;
        }

        private void foreverButton3_Click(object sender, EventArgs e)
        {
            currentTab++;
            tabPage1.SelectedIndex = currentTab;
        }

        private void foreverButton4_Click(object sender, EventArgs e)
        {
            currentTab++;
            tabPage1.SelectedIndex = currentTab;
        }

        private void foreverButton5_Click(object sender, EventArgs e)
        {
            currentTab++;
            tabPage1.SelectedIndex = currentTab;
        }

        private void foreverButton8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabPage1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            tabPage1.SelectedIndex = tabPage1.SelectedIndex;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            tabPage1.SelectedIndex = tabPage1.SelectedIndex;
        }
    }
}
