using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace colorConvert
{
    class Glass : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Random rand = new Random();
            double X = x + ((double)rand.Next(100) / 100 - 0.5) * 10;
            double Y = y + ((double)rand.Next(100) / 100 - 0.5) * 10;

            int R = sourceImage.GetPixel(Clamp((int)X, 0, sourceImage.Width - 1), Clamp((int)Y, 0, sourceImage.Height - 1)).R;
            int G = sourceImage.GetPixel(Clamp((int)X, 0, sourceImage.Width - 1), Clamp((int)Y, 0, sourceImage.Height - 1)).G;
            int B = sourceImage.GetPixel(Clamp((int)X, 0, sourceImage.Width - 1), Clamp((int)Y, 0, sourceImage.Height - 1)).B;

            return Color.FromArgb(R, G, B);
        }
    }
}
