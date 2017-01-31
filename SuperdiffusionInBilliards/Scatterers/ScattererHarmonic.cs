using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    public class ScattererHarmonic : ScattererPeriodic
    {
        public ScattererHarmonic(Point2D center, double radius0, double u0, double period)
            : base (center, radius0, u0, period)
        {

        }

        public ScattererHarmonic()
            : base ()
        { 
        
        }

        public override double Radius(double time)
        {
            double radius = Radius0 + U0 * Math.Sin(Frequency * time) / Frequency;
            return radius;
        }

        public override double MaxRadius()
        {
            return Radius0 + U0 * Math.Sin(Math.PI / 2) / Frequency;
        }

        public override object Clone()
        {
            return new ScattererHarmonic(Center, Radius0, U0, 2 * Math.PI / Frequency);
        }

        public override double FermiAcceleration(double lambda)
        {
            return U0 * U0 /lambda;
        }
    }
}
