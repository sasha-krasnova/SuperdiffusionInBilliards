using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    static public class LeastSquares
    {
        //static public List<double> ShiftAndSlope(List<Point2D> pointsForApprox)
        static public List<double> ShiftAndSlope(List<Point2D> pointsForApprox)
        {
            List<double> coefficients = new List<double>();
            double a, b;
            double sumX = 0;
            double sumX2 = 0;
            double sumY = 0;
            double sumXY = 0;
            int numOfPoints = 0;
            foreach (Point2D point in pointsForApprox)
            {
                numOfPoints += 1;
                sumX += point.X;
                sumY += point.Y;
                sumX2 += (point.X*point.X);
                sumXY += (point.X * point.Y);
            }
            a = (numOfPoints * sumXY - sumY)/(numOfPoints * sumX2 - sumX);
            b = (sumY - a * sumX) / numOfPoints;
            coefficients.Add(a);
            coefficients.Add(b);
            return coefficients;
        }
        
        static public double Slope(List<Point2D> pointsForApprox, double b)
        {
            double slope;
            double sumX = 0;
            double sumX2 = 0;
            double sumXY = 0;
            foreach (Point2D point in pointsForApprox)
            {
                sumX += point.X;
                sumX2 += (point.X * point.X);
                sumXY += (point.X * point.Y);
            }
            slope = (sumXY - b * sumX) / sumX2;
            return 0;
        }
    }
}
