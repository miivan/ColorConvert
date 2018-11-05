using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace colorConvert
{
    class Maximum : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusY = 1;
            int radiusX = 1;
            int[] sumR = new int[(2 * radiusX + 1) * (2 * radiusY + 1)];
            int[] sumG = new int[(2 * radiusX + 1) * (2 * radiusY + 1)];
            int[] sumB = new int[(2 * radiusX + 1) * (2 * radiusY + 1)];
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    sumR[(2 * radiusY + 1) * (l + radiusY) + k + radiusX] = sourceImage.GetPixel(idX, idY).R;
                    sumG[(2 * radiusY + 1) * (l + radiusY) + k + radiusX] = sourceImage.GetPixel(idX, idY).G;
                    sumB[(2 * radiusY + 1) * (l + radiusY) + k + radiusX] = sourceImage.GetPixel(idX, idY).B;
                }
            }
            Array.Sort(sumR);
            Array.Sort(sumG);
            Array.Sort(sumB);
            int colorR = sumR[sumR.Length - 1];
            int colorG = sumG[sumR.Length - 1];
            int colorB = sumB[sumR.Length - 1];
            return Color.FromArgb(
                Clamp(colorR, 0, 255),
                Clamp(colorG, 0, 255),
                Clamp(colorB, 0, 255));
        }
    }
}
