using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    static public class Averaging
    {
        static public double Average(List<double> values)
        {
            int numberOfValues = values.Count;
            double sumOfValues = 0;
            foreach (double value in values)
            {
                sumOfValues += value;
            }
            double averageValue = sumOfValues / numberOfValues;
            return averageValue;
        }

        static public Point2D Average(List<Point2D> values)
        {
            List<double> arrayX = new List<double>();
            List<double> arrayY = new List<double>();
            foreach (Point2D point in values)
            {
                arrayX.Add(point.X);
                arrayY.Add(point.Y);
            }
            return new Point2D(Average(arrayX),Average(arrayY));
        }

        static public double Dispersion(List<double> values)
        {
            double averageValue = Average(values);
            List<double> values2 = new List<double>();
            double value2 = 0;

            foreach (double value in values)
            {
                value2 = value * value;
                values2.Add(value2);
            }

            double averageValue2 = Average(values2);
            double dispersion = averageValue2 - averageValue * averageValue;
            
            return dispersion;
        }
    }
}
