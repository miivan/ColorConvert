using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace colorConvert
{
    class Wave : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double wave = x + 20 * Math.Sin(2 * Math.PI * y / 30);
            int R = sourceImage.GetPixel(Clamp((int)wave, 0, sourceImage.Width - 1), y).R;
            int G = sourceImage.GetPixel(Clamp((int)wave, 0, sourceImage.Width - 1), y).G;
            int B = sourceImage.GetPixel(Clamp((int)wave, 0, sourceImage.Width - 1), y).B;

            return Color.FromArgb(R, G, B);
        }
    }
}
