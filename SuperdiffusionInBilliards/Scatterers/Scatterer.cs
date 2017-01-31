using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    abstract public class Scatterer : Function, ICloneable
    {
        private Point2D center;     //Координаты центра рассеивателя
        private double radius0, u0; //Средний радиус рассеивателя, амплитуда скорости рассеивателя
        //StateOfParticle statesOfParticle;   //Состояние частицы??? Зачем оно здесь???

        public Scatterer(Point2D center, double radius0, double u0)
        {
            this.center = (Point2D)center.Clone();
            this.u0 = u0;
            this.radius0 = radius0;
        }

        public Scatterer()
        {
        }

        /*public static Scatterer GetScattererByType(ScattererType scType)
        {
            Scatterer scatterer = null;
            if (scType == ScattererType.Harmonic)
                scatterer = new ScattererHarmonic();
            return scatterer;
        }*/

        public override double F(double x)
        {
            return (Radius(x));
        }

        public abstract double Radius(double time);

        public abstract double ScattererVelocity(double time);
        
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
            set
            {
                radius0 = value;
            }
        }

        public double U0
        {
            get
            {
                return u0;
            }
        }

        public abstract double MaxRadius();

        abstract public object Clone();

        public abstract double FermiAcceleration(double lambda);

    }
}
