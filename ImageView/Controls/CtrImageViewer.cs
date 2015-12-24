using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageView.Controls
{
    public class CtrImageViewer : PictureBox
    {
        #region Declarations

        Image _imageShow = null;

        // Image projection
        private double offsetX = 0;
        private double offsetY = 0;
        private double scaleX = 1.0f;
        private double scaleY = 1.0f;

        #endregion

        #region Properties

        public Image ImageShow
        {
            get { return _imageShow; }
            set
            {
                lock (this)
                {
                    _imageShow = value;
                    this.Invalidate();
                }
            }
        }

        #endregion
        
        #region Control life cycle

        public CtrImageViewer()
        {
            BackColor = Color.Black;
        }
        
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Redraw(pe.Graphics);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //Redraw(null);
            this.Invalidate();
        }

        #endregion

        #region Private methods

        private void Redraw(Graphics graph)
        {
            if (_imageShow == null)
            {
                return;
            }
            lock (_imageShow)
            {
                if (graph == null)
                {
                    graph = this.CreateGraphics();
                }

                // Calcular dimensiones a dibujar y centrar
                int imgDrawWidth;
                int imgDrawHeight;
                float imgDrawX = 0;
                float imgDrawY = 0;
                float relation = (float)_imageShow.Width / (float)_imageShow.Height;
                if (relation > 0)
                {
                    // Imagen mas ancha que alta
                    imgDrawHeight = (int)(this.Width / relation);
                    if (imgDrawHeight > this.Height)
                    {
                        imgDrawHeight = this.Height;
                        imgDrawWidth = (int)(this.Height * relation);
                        imgDrawX = ((this.Width - imgDrawWidth) / 2.0f);
                    }
                    else
                    {
                        imgDrawWidth = this.Width;
                        imgDrawY = ((this.Height - imgDrawHeight) / 2.0f);
                    }
                }
                else
                {
                    // Imagen mas alta que ancha
                    imgDrawWidth = (int)(this.Width * relation);
                    if (imgDrawWidth > this.Width)
                    {
                        imgDrawWidth = this.Width;
                        imgDrawHeight = (int)(this.Height / relation);
                        imgDrawY = ((this.Height - imgDrawHeight) / 2.0f);
                    }
                    else
                    {
                        imgDrawHeight = this.Height;
                        imgDrawX = ((this.Width - imgDrawWidth) / 2.0f);
                    }
                }

                graph.DrawImage(_imageShow, imgDrawX, imgDrawY, imgDrawWidth, imgDrawHeight);
                offsetX = imgDrawX;
                offsetY = imgDrawY;
                scaleX = (double)imgDrawWidth / (double)_imageShow.Width;
                scaleY = (double)imgDrawHeight / (double)_imageShow.Height;
            }
        }

        #endregion

    }
}
