using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    class SceneRandom : SceneSquareBase
    {
        public SceneRandom(Scatterer scattererSample, double fullTime, double deltaTime, double vParticle, double latticeSize)
            : base(scattererSample, fullTime, deltaTime, vParticle, latticeSize)
        {
        }

        public override double FermiAccelerationTheory()
        {
            return 0;
        }

        public override double CoefficientOfSuperdiffusionTheory()
        {
            return 0;
        }

        public override void GetNextCollision()
        {
        }
    }
}
