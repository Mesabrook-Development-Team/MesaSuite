using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Towing
{
    public partial class frmMain : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        private Label _selectedLabel;
        private static readonly Color SAFETY_ORANGE = Color.FromArgb(255, 121, 0);
        public frmMain()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

            _selectedLabel = lblMyTickets;
            LabelButton_MouseEnter(lblMyTickets, EventArgs.Empty);
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.White, 0, label1.Location.Y + label1.Height, Width, label1.Location.Y + label1.Height);
            e.Graphics.DrawLine(Pens.White, lblMyTickets.Location.X + lblMyTickets.Width, label1.Location.Y + label1.Height, lblMyTickets.Location.X + lblMyTickets.Width, Height);
        }

        private void LabelButton_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            label.Font = new Font(label.Font, FontStyle.Bold);
            label.ForeColor = SAFETY_ORANGE;
            label.BackColor = Color.White;
        }

        private void LabelButton_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label == _selectedLabel)
            {
                return;
            }

            label.Font = new Font(label.Font, label.Font.Style ^ FontStyle.Bold);
            label.ForeColor = Color.White;
            label.BackColor = SAFETY_ORANGE;
        }

        private void LabelButton_Click(object sender, EventArgs e)
        {
            Label oldLabel = _selectedLabel;
            _selectedLabel = (Label)sender;

            LabelButton_MouseLeave(oldLabel, EventArgs.Empty);
            LabelButton_MouseEnter(_selectedLabel, EventArgs.Empty);
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
