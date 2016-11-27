using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    public class StateOfParticle : ICloneable
    {
        private Point2D displacement;
        private Particle particle;
        private double time;

        public StateOfParticle(Particle particle, double time, Point2D displacement)
        {
            this.particle = (Particle)particle.Clone();
            this.time = time;
            this.displacement = (Point2D)displacement.Clone();
        }

/*      public StateOfParticle(Particle particle, double time, double displacementX, double displacementY) : this(particle, time)
        { 
            particle.Coordinate.X += displacementX;
            particle.Coordinate.Y += displacementY;
        }

        public StateOfParticle(StateOfParticle stateOfParticlee) : this(stateOfParticlee.particle, stateOfParticlee.time, 0, 0)
        {

        }*/

        public Point2D Displacement
        {
            get
            {
                return displacement;
            }
        }

        public StateOfParticle()
        {
        }

        public Particle Particle
        {
            get
            {
                return particle;
            }
            set
            {
                particle = value;
            }
        }

        public double Time
        {
            set
            {
                time = value;
            }
            get
            {
                return time;
            }
        }

        virtual public object Clone()
        {
            StateOfParticle newStateOfParticle = new StateOfParticle();
            newStateOfParticle.time = time;
            newStateOfParticle.particle = (Particle)particle.Clone();
            newStateOfParticle.displacement = (Point2D)displacement.Clone();
            return newStateOfParticle;
        }
    }
}
