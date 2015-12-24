using System;
using System.Collections.Generic;
using System.Drawing;
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
            get {
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
                image = Bitmap.FromFile(_imagePath);
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

        private void NextImage()
        {
            string filename = _imagePath;
            do
            {
                filename = NextFile(filename);
                if (filename == null) { break; }
                if (SetImage(filename)) { break; }
            } while (true);
        }

        private void PrevImage()
        {
            string filename = _imagePath;
            do
            {
                filename = PrevFile(filename);
                if (filename == null) { break; }
                if (SetImage(filename)) { break; }
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
    }
}
