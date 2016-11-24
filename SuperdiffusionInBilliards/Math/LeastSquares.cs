using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    public class LeastSquares
    {
        private double slope, shift;
        private double sumX = 0;
        private double sumX2 = 0;
        private double sumY = 0;
        private double sumXY = 0;
        private int numOfPoints = 0;
    
        public LeastSquares(List<Point2D> pointsForApprox)
        {
            numOfPoints = pointsForApprox.Count;
            foreach (Point2D point in pointsForApprox)
            {
                sumX += point.X;
                sumY += point.Y;
                sumX2 += (point.X * point.X);
                sumXY += (point.X * point.Y);
            }
        }
        public List<double> ShiftAndSlope()
        {
            List<double> coefficients = new List<double>();
            slope = (numOfPoints * sumXY - sumX * sumY)/(numOfPoints * sumX2 - sumX * sumX);
            shift = (sumY - slope * sumX) / numOfPoints;
            coefficients.Add(slope);
            coefficients.Add(shift);
            return coefficients;
        }
        
        public double Slope(double b)
        {
           slope = (sumXY - b * sumX) / sumX2;
           return slope;
        }
    }
}
