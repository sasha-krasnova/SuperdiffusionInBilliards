using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    static public class MathAdditional
    {
        static public double Atan2(double y, double x)
        {
            double atan = Math.Atan2(y, x);
            if (y > 0 && x < 0 || y > 0 && x < 0)
                atan += Math.PI;
            return atan;
        }
           
    }
}
