using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    public class ScattererHarmonic : ScattererPeriodic
    {
        public ScattererHarmonic(Point2D center, double radius0, double u0, double period, double initOscPhase)
            : base (center, radius0, u0, period, initOscPhase)
        {

        }

        public ScattererHarmonic()
            : base ()
        { 
        
        }

        public override double Radius(double time)
        {
            double radius = Radius0 + U0 * Math.Sin(Frequency * time + InitOscPhase) / Frequency;
            return radius;
        }

        public override double MaxRadius()
        {
            return Radius0 + U0 * Math.Sin(Math.PI / 2) / Frequency;
        }

        public override object Clone()
        {
            return new ScattererHarmonic(Center, Radius0, U0, 2 * Math.PI / Frequency, InitOscPhase);
        }

        public override double FermiAcceleration(double meanFreePath)
        {
            return U0 * U0 / meanFreePath;
        }
    }
}
