using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    public class StateOfParticleDetailed : StateOfParticle
    {
        private Point2D displacement;
        private List<Circle> circles; 
        public StateOfParticleDetailed(Particle particle, double time, Point2D displacement, List<Circle> circles) 
            : base(particle, time)
        {
            this.displacement = (Point2D)displacement.Clone();
            this.circles = circles;
        }

        public Point2D Displacement
        {
            get
            {
                return displacement;
            }
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
            newStateOfParticleDetailed.displacement = (Point2D)displacement.Clone();
            newStateOfParticleDetailed.circles = circles;
            return newStateOfParticleDetailed;
        }

    }
}
