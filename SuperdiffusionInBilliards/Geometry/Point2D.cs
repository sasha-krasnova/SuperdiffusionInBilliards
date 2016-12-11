using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SuperdiffusionInBilliards
{
    public class Point2D : ICloneable, ICsvLine
    {
        double x, y;

        public Point2D()
        {

        }

        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public object Clone()
        {
            return new Point2D(x, y);
        }

        public double Norm()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public Point ConvertToPoint()
        {
            return new Point(Convert.ToInt32(x), Convert.ToInt32(y));
        }

        public String GetCSV()
        {
            return Convert.ToString(x) + ";" + Convert.ToString(y) + ";";
        }
    }
}
