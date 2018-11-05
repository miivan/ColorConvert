using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace colorConvert
{
    class Sobel : MatrixFilter2d
    {
        public Sobel()
        {
            byY = new float[3, 3]{ {-1, -2, -1 },
                             { 0, 0, 0 },
                             { 1, 2, 1 } };
            byX = new float[3, 3]{ {-1, 0, 1 },
                             {-2, 0, 2 },
                             {-1, 0, 1 } };
        }

    }
}
