using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SuperdiffusionInBilliards
{
    class TestFunction : Function
    {
        override public double F(double x)
        {
            return (Math.Exp(x) - 100);
        }
    }
}
