using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MesaSuite
{
    public partial class frmSetBackground : Form
    {
        public frmSetBackground()
        {
            InitializeComponent();
        }

        private void frmSetBackground_Load(object sender, EventArgs e)
        {
            pboxCurrentWallpaper.BackgroundImage = frmMain.ActiveForm.BackgroundImage;
            txtWallpaperPath.Text = Properties.Settings.Default.wallpaperPath;

            if (Properties.Settings.Default.imageLayout == "None")
            {
                pboxCurrentWallpaper.BackgroundImageLayout = ImageLayout.None;
                rBNone.Checked = true;
            }
            else if (Properties.Settings.Default.imageLayout == "Stretch")
            {
                pboxCurrentWallpaper.BackgroundImageLayout = ImageLayout.Stretch;
                rBStretch.Checked = true;
            }
            else if (Properties.Settings.Default.imageLayout == "Tile")
            {
                pboxCurrentWallpaper.BackgroundImageLayout = ImageLayout.Tile;
                rBTile.Checked = true;
            }
            else if (Properties.Settings.Default.imageLayout == "Zoom")
            {
                pboxCurrentWallpaper.BackgroundImageLayout = ImageLayout.Zoom;
                rBZoom.Checked = true;
            }
            else if (Properties.Settings.Default.imageLayout == "Center")
            {
                pboxCurrentWallpaper.BackgroundImageLayout = ImageLayout.Center;
                rBCenter.Checked = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset all personalization settings?", "Reset Personalization", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }

            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();

            var frmMain = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
            frmMain.UpdateLook();
            Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.wallpaperPath = txtWallpaperPath.Text;

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
            
            var frmMain = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
            frmMain.UpdateLook();

            Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdWallpaper.ShowDialog();

            if(result == DialogResult.OK)
            {
                txtWallpaperPath.Text = ofdWallpaper.FileName;
                Image img = new Bitmap(ofdWallpaper.FileName);
                pboxCurrentWallpaper.BackgroundImage = img;
            }
        }

        private void rBNone_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.imageLayout = "None";
            pboxCurrentWallpaper.BackgroundImageLayout = ImageLayout.None;
        }

        private void rBTile_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.imageLayout = "Tile";
            pboxCurrentWallpaper.BackgroundImageLayout = ImageLayout.Tile;
        }

        private void rBStretch_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.imageLayout = "Stretch";
            pboxCurrentWallpaper.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void rBCenter_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.imageLayout = "Center";
            pboxCurrentWallpaper.BackgroundImageLayout = ImageLayout.Center;
        }

        private void rBZoom_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.imageLayout = "Zoom";
            pboxCurrentWallpaper.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
