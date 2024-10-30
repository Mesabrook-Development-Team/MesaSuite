using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace MesaSuite.Common
{
    public partial class ImageDisposer : Component
    {
        public List<Image> Images { get; set; } = new List<Image>();
        public ImageDisposer()
        {
            InitializeComponent();
            this.Disposed += ImageDisposer_Disposed;
        }

        private void ImageDisposer_Disposed(object sender, EventArgs e)
        {
            foreach(Image image in Images)
            {
                try
                {
                    image.Dispose();
                }
                catch { }
            }
        }

        public ImageDisposer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
