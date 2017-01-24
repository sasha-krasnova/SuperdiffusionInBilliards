using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    class SceneRandom : SceneSquareBase
    {
        RandomScattererSet randomSet;
        public SceneRandom(Scatterer scattererSample, double fullTime, double deltaTime, double vParticle, double latticeSize, double scattererConcentration)
            : base(scattererSample, fullTime, deltaTime, vParticle, latticeSize)
        {
            randomSet = new RandomScattererSet(scattererSample, scattererConcentration);
            ReloadScetterers();

        }

        public override double FermiAccelerationTheory()
        {
            return 0;
        }

        public override double CoefficientOfSuperdiffusionTheory()
        {
            return 0;
        }

        protected override void ReloadScetterers() 
        {
            randomSet.GetScatterersForScene(Displacement, new Point2D(latticeSize, latticeSize));
        }
    }
}
