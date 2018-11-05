using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace colorConvert
{
    class TopHat : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int resultR = Clamp(Form1.undoImage.GetPixel(x, y).R - sourceImage.GetPixel(x, y).R, 0, 255);
            int resultG = Clamp(Form1.undoImage.GetPixel(x, y).G - sourceImage.GetPixel(x, y).G, 0, 255);
            int resultB = Clamp(Form1.undoImage.GetPixel(x, y).B - sourceImage.GetPixel(x, y).B, 0, 255);
            return Color.FromArgb(resultR, resultG, resultB);
        }
    }
}
