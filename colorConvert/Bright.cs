using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace colorConvert 
{
    class Bright : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            return Color.FromArgb(Clamp(sourceColor.R + 33, 0, 255), Clamp(sourceColor.G + 33, 0, 255), Clamp(sourceColor.B + 33, 0, 255));
        }
    }
}
