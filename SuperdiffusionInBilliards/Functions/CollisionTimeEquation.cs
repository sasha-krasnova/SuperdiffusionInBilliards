using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    public class CollisionTimeEquation : Function
    {
        private Scatterer scatterer;
        private Particle particle;
        private double time0;

        public CollisionTimeEquation(Scatterer scatterer, Particle particle, double time0)
        {
            this.scatterer = scatterer;
            this.particle = particle;
            this.time0 = time0;
        }

        public override double F(double t)
        {
            double part1 = (particle.Velocity.X * t + particle.Coordinate.X - scatterer.Center.X) * (particle.Velocity.X * t + particle.Coordinate.X - scatterer.Center.X);
            double part2 = (particle.Velocity.Y * t + particle.Coordinate.Y - scatterer.Center.Y) * (particle.Velocity.Y * t + particle.Coordinate.Y - scatterer.Center.Y);
            double part3 = scatterer.Radius(time0 + t) * scatterer.Radius(time0 + t);
            return part1 + part2 - part3;
        }
    }
}
