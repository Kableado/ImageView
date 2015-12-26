using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImageView
{
    public partial class FrmImageView : Form
    {
        private string _directoryPath = null;
        private List<string> _files = null;
        private string _imagePath = null;

        private List<string> files
        {
            get
            {
                if (_files == null)
                {
                    _files = Directory.GetFiles(_directoryPath).ToList();
                }
                return _files;
            }
        }

        public FrmImageView(string imagePath)
        {
            InitializeComponent();
            _directoryPath = Path.GetDirectoryName(imagePath);
            SetImage(imagePath);
        }

        private bool SetImage(string imagePath)
        {
            _imagePath = imagePath;
            Image image;
            try
            {
                using (var bmpTemp = new Bitmap(_imagePath))
                {
                    FixImageOrientation(bmpTemp);
                    image = new Bitmap(bmpTemp);
                }
            }
            catch (Exception) { return false; }
            picImageView.ImageShow = image;
            Text = Path.GetFileName(_imagePath);
            return true;
        }

        private string NextFile(string filename)
        {
            int idx = files.IndexOf(filename);
            idx++;
            if (idx >= files.Count)
            {
                return null;
            }
            return files[idx];
        }

        private string PrevFile(string filename)
        {
            int idx = files.IndexOf(filename);
            idx--;
            if (idx < 0)
            {
                return null;
            }
            return files[idx];
        }

        private bool NextImage()
        {
            string filename = _imagePath;
            do
            {
                filename = NextFile(filename);
                if (filename == null) { return false; }
                if (SetImage(filename)) { return true; }
            } while (true);
        }

        private bool PrevImage()
        {
            string filename = _imagePath;
            do
            {
                filename = PrevFile(filename);
                if (filename == null) { return false; }
                if (SetImage(filename)) { return true; }
            } while (true);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextImage();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            PrevImage();
        }

        private void btnSelectInExplorer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", _imagePath));
        }

        public static short GetExifOrientation(Image photo)
        {
            const int orientationIndex = 0x0112;
            try
            {
                PropertyItem prop = photo.GetPropertyItem(orientationIndex);
                return BitConverter.ToInt16(prop.Value, 0);
            }
            catch (Exception) { return 0; }
        }

        public static void FixImageOrientation(Image image)
        {
            short orientation = GetExifOrientation(image);
            if (orientation == 6)
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            if (orientation == 3)
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            if (orientation == 8)
            {
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete this image?", "", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }

            string fileToDelete = _imagePath;
            if (NextImage() == false)
            {
                if (PrevImage() == false)
                {
                    return;
                }
            }
            File.Delete(fileToDelete);
        }
    }
}
