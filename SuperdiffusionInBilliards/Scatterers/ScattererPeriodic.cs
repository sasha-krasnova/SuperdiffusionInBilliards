using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    abstract public class ScattererPeriodic : Scatterer
    {
        private double frequency; //Частота колебаний скорости рассеивателя
        private double initOscPhase;
        public ScattererPeriodic(Point2D center, double radius0, double u0, double period, double initOscPhase)
            : base(center, radius0, u0)
        {
            this.initOscPhase = initOscPhase;
            frequency = 2 * Math.PI / period;
        }

        public ScattererPeriodic() 
            : base()
        {

        }

        public override double ScattererVelocity(double time)
        {
            return Derivative(time);
        }

        public double Frequency
        {
            get
            {
                return frequency;
            }
        }

        public double InitOscPhase
        {
            get
            {
                return initOscPhase;
            }
        }
    }
}
