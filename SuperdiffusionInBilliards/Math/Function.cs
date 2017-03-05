using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    abstract public class Function
    {
        public const double DELTA_X = 0.001;

        public abstract double F(double x);

        public double Derivative(double x)
        {
            return ((F(x + DELTA_X) - F(x - DELTA_X)) / (2 * DELTA_X));
        }

        public double Integral(double a, double b)
        {
            int numberOfPoints = 1000;
            double sum = 0;
            double deltaX = (b - a) / numberOfPoints;
            for (int i = 0; i < numberOfPoints; i++)
            {
                double f1 = F(i * deltaX);
                double f2 = F((i + 1) * deltaX);
                sum += (f1 + f2) / 2 * deltaX;
            }
            return sum;
        }
    }
}
