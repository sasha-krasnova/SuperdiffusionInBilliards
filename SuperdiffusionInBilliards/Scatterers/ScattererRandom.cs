using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    class ScattererRandom : Scatterer
    {
        private static Random rndm = new Random();
        
        public ScattererRandom(Point2D center, double radius0, double u0)
            : base(center, radius0, u0)
        {
        }

        public override double Radius(double time)
        {
            return Radius0;
        }

        public override object Clone()
        {
            return new ScattererRandom(Center, Radius0, U0);
        }

        public override double ScattererVelocity(double time)
        {
            return U0 * rndm.NextDouble();
            //return U0;
        }

        public override double MaxRadius()
        {
            return Radius0;
        }

        public override double FermiAcceleration(double lambda)
        {
            return U0 * U0 / 3 / lambda;
        }
    }
}
