using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace colorConvert
{
    class Emboss : MatrixFilter
    {
        public Emboss()
        {
            kernel = new float[3, 3] { { 0, 1, 0 },
                                       { 1, 0, -1 },
                                       { 0, -1, 0 } };
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            float intensity = 0;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                    intensity = 0.36f * resultR + 0.53f * resultG + 0.11f * resultB + 120;
                }
            return Color.FromArgb(
                Clamp((int)intensity, 0, 255),
                Clamp((int)intensity, 0, 255),
                Clamp((int)intensity, 0, 255));
        }
    }
}
