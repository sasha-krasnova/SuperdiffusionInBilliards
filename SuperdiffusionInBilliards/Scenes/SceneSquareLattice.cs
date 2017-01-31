using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    public class SceneSquareLattice : SceneSquareBase
    {
        
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
        }

        public override double FermiAccelerationTheory()
        {
            double area = latticeSize * latticeSize - Math.PI * (Scatterers[0].Radius0 * Scatterers[0].Radius0 + Scatterers[4].Radius0 * Scatterers[4].Radius0);
            double perimeter = 2 * Math.PI * (Scatterers[0].Radius0 + Scatterers[4].Radius0);
            double lambda = Math.PI * area / perimeter;
            double fermiAccelerationTheory = Scatterers[0].FermiAcceleration(lambda);
            return fermiAccelerationTheory;
        }

        public override double CoefficientOfSuperdiffusionTheory()
        {
            double coefficietnOfSuperdif;
            double part1 = 2 * latticeSize * latticeSize * Scatterers[0].U0 * Scatterers[0].U0 * (Scatterers[0].Radius0 + Scatterers[4].Radius0) * (latticeSize - 2 * Scatterers[0].Radius0);
            double part2 = Math.PI * (latticeSize * latticeSize - Math.PI * (Scatterers[0].Radius0 * Scatterers[0].Radius0 + Scatterers[4].Radius0 * Scatterers[4].Radius0)) * (latticeSize * latticeSize - Math.PI * (Scatterers[0].Radius0 * Scatterers[0].Radius0 + Scatterers[4].Radius0 * Scatterers[4].Radius0));
            coefficietnOfSuperdif = Math.Sqrt(part1 / part2);
            return coefficietnOfSuperdif;
        }
    }
}
