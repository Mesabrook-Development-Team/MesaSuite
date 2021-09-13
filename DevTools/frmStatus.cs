using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevTools
{
    public partial class frmStatus : Form
    {
        public frmStatus()
        {
            InitializeComponent();
        }

        public void Append(string text)
        {
            Invoke(new MethodInvoker(() =>
            {
                textBox1.AppendText(text + "\r\n");
                textBox1.Select(textBox1.Text.Length, 0);
                textBox1.ScrollToCaret();
            }));
        }
    }
}
