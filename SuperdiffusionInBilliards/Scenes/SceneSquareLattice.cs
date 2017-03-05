using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    public class SceneSquareLattice : SceneSquareBase
    {
        //double meanFreePath;
        double scatterersPerimeter;
        public SceneSquareLattice(Scatterer scattererSample, Scatterer centralScattererSample, double fullTime, double deltaTime, double vParticle, double latticeSize)
            : base(scattererSample, fullTime, deltaTime, vParticle, latticeSize)
        {
            InitParticleCoordinates(new Point2D(latticeSize / 2, latticeSize / 16));
            

            // Присваиваем значения центрам рассеивателей

            //Scatterer scatterer = Scatterer.GetScattererByType(scTypeWithRadius.Type);

            for (int i = 0; i < 4; i++)
            {
                Scatterers.Add((Scatterer)scattererSample.Clone());
                //Scatterers[i] = (Scatterer)scattererSample.Clone();
            }

            Scatterers.Add((Scatterer)centralScattererSample.Clone());
            
            Scatterers[0].Center.X = 0;
            Scatterers[0].Center.Y = 0;

            Scatterers[1].Center.X = latticeSize;
            Scatterers[1].Center.Y = 0;

            Scatterers[2].Center.X = latticeSize;
            Scatterers[2].Center.Y = latticeSize;

            Scatterers[3].Center.X = 0;
            Scatterers[3].Center.Y = latticeSize;

            Scatterers[4].Center.X = latticeSize / 2;
            Scatterers[4].Center.Y = latticeSize / 2;

            
            if(Scatterers[0] is ScattererPeriodic)
            {
                ScattererPeriodic scatterer = (ScattererPeriodic) Scatterers[0].Clone();
                MeanFreePath = Integral(0, 2 * Math.PI / scatterer.Frequency) / (2 * Math.PI / scatterer.Frequency);
                //scatterersPerimeter = 2 * Math.PI * (Scatterers[0].Radius0 + Scatterers[4].Radius0);
                //double area = latticeSize * latticeSize - Math.PI * (Scatterers[0].Radius0 * Scatterers[0].Radius0 + Scatterers[4].Radius0 * Scatterers[4].Radius0);
                //double meanFreePathWithoutAveraging = Math.PI * area / scatterersPerimeter;
            }
            else
            {
                scatterersPerimeter = 2 * Math.PI * (Scatterers[0].Radius0 + Scatterers[4].Radius0);
                double area = latticeSize * latticeSize - Math.PI * (Scatterers[0].Radius0 * Scatterers[0].Radius0 + Scatterers[4].Radius0 * Scatterers[4].Radius0);
                MeanFreePath = Math.PI * area / scatterersPerimeter;
            }
        }

        public override double F(double x)
        {
            double scatterersPerimeter = 2 * Math.PI * (Scatterers[0].Radius(x) + Scatterers[4].Radius(x));
            double area = latticeSize * latticeSize - Math.PI * (Scatterers[0].Radius(x) * Scatterers[0].Radius(x) + Scatterers[4].Radius(x) * Scatterers[4].Radius(x));
            double meanFreePath = Math.PI * area / scatterersPerimeter;
            return meanFreePath;
            //throw new NotImplementedException();
        }

        public override double FermiAccelerationTheory()
        {
            double fermiAccelerationTheory = Scatterers[0].FermiAcceleration(MeanFreePath);
            return fermiAccelerationTheory;
        }

        public override double CoefficientOfSuperdiffusionTheory(double fermiAccelerationTheory)
        {
            double coefficietnOfSuperdif;
            double meanSqareOfJump = latticeSize * latticeSize;
            double corridorsWidth = 4 * (latticeSize - Scatterers[0].Radius0);
            coefficietnOfSuperdif = Math.Sqrt(meanSqareOfJump * corridorsWidth * fermiAccelerationTheory / 2 / scatterersPerimeter / MeanFreePath);
            return coefficietnOfSuperdif;
        }
    }
}
