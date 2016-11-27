using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    public class StateOfParticleDetailed : StateOfParticle
    {
        private List<Circle> circles; 
        public StateOfParticleDetailed(Particle particle, double time, Point2D displacement, List<Circle> circles)
            : base(particle, time, displacement)
        {

            this.circles = circles;
        }

       

        public List<Circle> Circles
        {
            get
            {
                return circles;
            }
        }

        override public object Clone()
        {
            StateOfParticleDetailed newStateOfParticleDetailed = (StateOfParticleDetailed)base.Clone();
            newStateOfParticleDetailed.circles = circles;
            return newStateOfParticleDetailed;
        }

    }
}
