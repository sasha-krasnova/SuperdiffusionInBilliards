using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    class SceneRandom : SceneSquareBase
    {
        RandomScattererSet randomSet;
        double scattererConcentration;
        public SceneRandom(Scatterer scattererSample, double fullTime, double deltaTime, double vParticle, double latticeSize, double scattererConcentration)
            : base(scattererSample, fullTime, deltaTime, vParticle, latticeSize)
        {
            this.scattererConcentration = scattererConcentration;
            randomSet = new RandomScattererSet(scattererSample, scattererConcentration);
            ReloadScetterers();
            Rectangle rect = new Rectangle(new Point2D(0, 0), new Point2D(2 * scattererSample.MaxRadius(), 2 * scattererSample.MaxRadius()));
            InitParticleCoordinates(GenerateParticleCoordinates(rect));
        }

        /// <summary>
        /// Генерирует координаты частицы вне рассеивателей 
        /// </summary>
        /// <param name="rect">Прямоугольник, в рамках которого нужно сгенерировать точку</param>
        private Point2D GenerateParticleCoordinates(Rectangle rect)
        {
            Point2D particleCoordinates = new Point2D();
            do
            {
                particleCoordinates.X = rndm.NextDouble() * (rect.RightBottom.X - rect.LeftTop.X);
                particleCoordinates.Y = rndm.NextDouble() * (rect.RightBottom.Y - rect.LeftTop.Y);
            }
            while (doesParticleConflicts(particleCoordinates));
            return particleCoordinates;
        }

        /// <summary>
        /// Проверяет находиться ли точка внутри какого-либо рассеивателя
        /// </summary>
        private bool doesParticleConflicts(Point2D particleCoordinates)
        {
            foreach (Scatterer scatterer in Scatterers)
            {
                double dist  = Point2D.getDistance(particleCoordinates, scatterer.Center);
                if(dist < scatterer.MaxRadius())
                    return true;
            }
            return false;
        }


        public override double FermiAccelerationTheory()
        {
            MeanFreePath = (1 - scattererConcentration * Math.PI * Scatterers[0].Radius0 * Scatterers[0].Radius0) / 2 / scattererConcentration / Scatterers[0].Radius0;
            double fermiAccelerationTheory = Scatterers[0].FermiAcceleration(MeanFreePath);
            return fermiAccelerationTheory;
        }

        public override double CoefficientOfSuperdiffusionTheory(double fermiAccelerationTheory)
        {
            return Math.Sqrt(fermiAccelerationTheory * MeanFreePath / 2);
        }

        protected override void ReloadScetterers() 
        {
            Scatterers = randomSet.GetScatterersForScene(Displacement, new Point2D(latticeSize, latticeSize));
        }
    }
}
