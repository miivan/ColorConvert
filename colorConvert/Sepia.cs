using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace colorConvert
{
    class Sepia : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            float intensity = 0.36f * sourceColor.R + 0.53f * sourceColor.G + 0.11f * sourceColor.B;

            float k = 36f;
            float R = intensity + 2f * k;
            float G = intensity + 0.5f * k;
            float B = intensity - 1f * k;

            return Color.FromArgb(Clamp((int)R, 0, 255), Clamp((int)G, 0, 255), Clamp((int)B, 0, 255));
        }

    }
}
