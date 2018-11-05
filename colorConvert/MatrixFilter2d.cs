using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace colorConvert
{
    class MatrixFilter2d : Filters
    {
        protected float[,] byY = null;
        protected float[,] byX = null;
        protected MatrixFilter2d(){}
        public MatrixFilter2d(float[,] byX, float[,] byY)
        {
            this.byX = byX;
            this.byY = byX;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = byX.GetLength(0) / 2;
            int radiusY = byX.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            float resultRY = 0;
            float resultGY = 0;
            float resultBY = 0;
            float resultRX = 0;
            float resultGX = 0;
            float resultBX = 0;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultRY += neighborColor.R * byY[k + radiusX, l + radiusY];
                    resultGY += neighborColor.G * byY[k + radiusX, l + radiusY];
                    resultBY += neighborColor.B * byY[k + radiusX, l + radiusY];
                    resultRX += neighborColor.R * byX[k + radiusX, l + radiusY];
                    resultGX += neighborColor.G * byX[k + radiusX, l + radiusY];
                    resultBX += neighborColor.B * byX[k + radiusX, l + radiusY];
                    resultR = (float)Math.Sqrt(resultRX * resultRX + resultRY * resultRY);
                    resultG = (float)Math.Sqrt(resultGX * resultGX + resultGY * resultGY);
                    resultB = (float)Math.Sqrt(resultBX * resultBX + resultBY * resultBY);
                }
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255));
        }
    }
}
