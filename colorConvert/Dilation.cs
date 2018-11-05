using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace colorConvert
{
    class Dilation : Morfology
    {
        public Dilation()
        {
            kernel = new float[5, 5]{ { 0, 1, 1, 1, 0 },
                                      { 1, 1, 1, 1, 1 },
                                      { 1, 1, 1, 1, 1 },
                                      { 1, 1, 1, 1, 1 },
                                      { 0, 1, 1, 1, 0 } };
            type = "dilation";
        }
    }
}
