using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    abstract public class Scatterer : Function
    {
        private Point2D center;
        private double radius0, u0;
        StateOfParticle statesOfParticle;

        public Scatterer(Point2D center, double radius0, double u0)
        {
            this.center = (Point2D)center.Clone();
            this.u0 = u0;
            this.radius0 = radius0;
        }

        public override double F(double x)
        {
            return (Radius(x));
        }

        public abstract double Radius(double time);

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

        public double Radius0
        {
            get
            {
                return radius0;
            }
        }

        public double U0
        {
            get
            {
                return u0;
            }
        }

    }
}
