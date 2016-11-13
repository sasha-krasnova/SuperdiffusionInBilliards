using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    public class Particle : ICloneable
    {
        private Point2D coordinate, velocity;
        private SceneBase sceneCeller;

        public Particle()
        {
        }

        public Particle(Point2D coordinate, Point2D velocity, SceneBase sceneCeller)
        {
            this.coordinate = (Point2D)coordinate.Clone();
            this.velocity = (Point2D)velocity.Clone();
            this.sceneCeller = sceneCeller;
        }

        public Point2D Coordinate
        {
            get
            {
                return coordinate;
            }
            set
            {
                coordinate = value;
            }
        }

        public Point2D Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }

        public CollisionTime FindCollisionTimeScatterer(Scatterer scatterer)
        {
            Function f = new CollisionTimeEquation(scatterer, this, sceneCeller.Time);
            List<double> rutes = NewtonsMethod.Solve(f, 0);
            CollisionTime minCollisionTime = new CollisionTime(0, false);
            foreach (double rute in rutes)
            {
                if((rute < minCollisionTime.Time || !minCollisionTime.Existence) && rute > 0)
                {
                    minCollisionTime.Time = rute;
                    minCollisionTime.Existence = true;
                }
            }
            return minCollisionTime;
        }

        public CollisionTime FindCollisionTimeLine(Line line)
        {
            CollisionTime collisionTime = new CollisionTime(0, false);
            if ((line.A * velocity.X + line.B * velocity.Y) != 0)
            {
                collisionTime.Time = -(line.A * coordinate.X + line.B * coordinate.Y + line.C) / (line.A * velocity.X + line.B * velocity.Y);
                if(collisionTime.Time > 0)
                    collisionTime.Existence = true;
            }
            return collisionTime;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scatterer"></param>
        /// <param name="collisionTime"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public Particle MakeScattererCollision(Scatterer scatterer, double collisionTime, double time)
        {
            Particle newParticle = (Particle)Clone();
            newParticle.coordinate.X = velocity.X * collisionTime + coordinate.X;
            newParticle.coordinate.Y = velocity.Y * collisionTime + coordinate.Y;
            double tetta = MathAdditional.Atan2(newParticle.coordinate.Y, newParticle.coordinate.X);
            double vn = velocity.X * Math.Cos(tetta) + velocity.Y * Math.Sin(tetta);
            double vt = -velocity.X * Math.Sin(tetta) + velocity.Y * Math.Cos(tetta);
            vn = -vn + 2 * scatterer.Derivative(time);
            newParticle.velocity.X = vn * Math.Cos(tetta) - vt * Math.Sin(tetta);
            newParticle.velocity.Y = vn * Math.Sin(tetta) + vt * Math.Cos(tetta);
            return newParticle;
        }

        public object Clone()
        {
            return new Particle(coordinate, velocity, sceneCeller);
        }
    }
}
