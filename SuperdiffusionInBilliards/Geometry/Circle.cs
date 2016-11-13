using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    public class Circle : ICloneable
    {
        private double radius;
        private Point2D center;

        public Circle()
        {

        }

        public Circle (double radius, Point2D center)
        {
            center = (Point2D)center.Clone();
            this.radius = radius;
        }

        public Point2D Center
        {
            get
            {
                return center;
            }
            set
            {
                center = (Point2D)value.Clone();
            }
        }
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }

        public object Clone()
        {
            return new Circle(radius, center);
        }
    }
}
