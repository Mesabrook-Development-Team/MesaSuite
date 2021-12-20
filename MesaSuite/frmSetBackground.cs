using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MesaSuite.Common;
using MesaSuite.Common.Extensions;

namespace MesaSuite
{
    public partial class frmSetBackground : Form
    {
        private frmMain _mainForm;
        public frmSetBackground()
        {
            InitializeComponent();
        }

        public frmSetBackground(frmMain mainForm) : this()
        {
            _mainForm = mainForm;
        }

        private void frmSetBackground_Load(object sender, EventArgs e)
        {
            UserPreferences preferences = UserPreferences.Get();

            pboxCurrentWallpaper.BackgroundImage = frmMain.ActiveForm.BackgroundImage;
            txtWallpaperPath.Text = preferences.GetPreferencesForSection("mcsync").GetOrSetDefault("wallpaperPath", defaultValue: null).Cast<string>();

            string imageLayoutString = preferences.GetPreferencesForSection("mcsync").GetOrSetDefault("imageLayout", defaultValue: null).Cast<string>();
            ImageLayout imageLayout = ImageLayout.None;
            if (!string.IsNullOrEmpty(imageLayoutString) && Enum.TryParse(imageLayoutString, true, out ImageLayout parsedImageLayout))
            {
                imageLayout = parsedImageLayout;
            }

            pboxCurrentWallpaper.BackgroundImageLayout = imageLayout;
            rBNone.Checked = imageLayout == ImageLayout.None;
            rBStretch.Checked = imageLayout == ImageLayout.Stretch;
            rBTile.Checked = imageLayout == ImageLayout.Tile;
            rBZoom.Checked = imageLayout == ImageLayout.Zoom;
            rBCenter.Checked = imageLayout == ImageLayout.Center;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset all personalization settings?", "Reset Personalization", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }

            UserPreferences userPreferences = UserPreferences.Get();
            Dictionary<string, object> settings = userPreferences.GetPreferencesForSection("mcsync");
            settings["wallpaperPath"] = null;
            settings["imageLayout"] = ImageLayout.None.ToString();
            settings["buttonClickSfx"] = true;
            userPreferences.Save();

            _mainForm.UpdateLook();
            Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            UserPreferences userPreferences = UserPreferences.Get();
            Dictionary<string, object> preferences = userPreferences.GetPreferencesForSection("mcsync");
            preferences["wallpaperPath"] = txtWallpaperPath.Text;
            preferences["imageLayout"] = pboxCurrentWallpaper.BackgroundImageLayout.ToString();
            
            userPreferences.Save();
            _mainForm.UpdateLook();

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
            pboxCurrentWallpaper.BackgroundImageLayout = ImageLayout.None;
        }

        private void rBTile_CheckedChanged(object sender, EventArgs e)
        {
            pboxCurrentWallpaper.BackgroundImageLayout = ImageLayout.Tile;
        }

        private void rBStretch_CheckedChanged(object sender, EventArgs e)
        {
            pboxCurrentWallpaper.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void rBCenter_CheckedChanged(object sender, EventArgs e)
        {
            pboxCurrentWallpaper.BackgroundImageLayout = ImageLayout.Center;
        }

        private void rBZoom_CheckedChanged(object sender, EventArgs e)
        {
            pboxCurrentWallpaper.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
