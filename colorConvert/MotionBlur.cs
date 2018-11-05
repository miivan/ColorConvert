using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace colorConvert
{
    class MotionBlur : MatrixFilter
    {
        public MotionBlur()
        {
            int n = 5;
            kernel = new float[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    kernel[i, j] = 0;
                    kernel[i, i] = 1;
                }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    kernel[i, j] /= n;
        }
    }
}
