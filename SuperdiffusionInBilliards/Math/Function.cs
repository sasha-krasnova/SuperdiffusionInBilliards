using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    abstract public class Function
    {
        public const double deltaX = 0.001;

        public abstract double F(double x);

        public double Derivative(double x)
        {
            return ((F(x + deltaX) - F(x - deltaX)) / (2 * deltaX));
        }
    }
}
