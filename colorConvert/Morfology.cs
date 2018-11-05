using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace colorConvert
{
    class Morfology : Filters
    {
        protected float[,] kernel = null;
        protected string type;
        protected Morfology() { }
        public Morfology(float[,] kernel, string type)
        {
            this.kernel = kernel;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            int maxR = 255;
            int minR = 0;
            int maxG = 255;
            int minG = 0;
            int maxB = 255;
            int minB = 0;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    if (kernel[k + radiusX, l + radiusY] == 1)
                    {
                        maxR = maxR > neighborColor.R ? neighborColor.R : maxR;
                        minR = minR < neighborColor.R ? neighborColor.R : minR;
                        maxG = maxG > neighborColor.G ? neighborColor.G : maxG;
                        minG = minG < neighborColor.G ? neighborColor.G : minG;
                        maxB = maxB > neighborColor.B ? neighborColor.B : maxB;
                        minB = minB < neighborColor.B ? neighborColor.B : minB;
                    }
                    
                }
            int resultR = 0;
            int resultG = 0;
            int resultB = 0;
            if (type == "dilation")
            { 
                resultR = maxR;
                resultG = maxG;
                resultB = maxB;
            }
            else if (type == "erosion")
            {
                resultR = minR;
                resultG = minG;
                resultB = minB;
            }
            return Color.FromArgb(resultR, resultG, resultB);
        }
    }
}
