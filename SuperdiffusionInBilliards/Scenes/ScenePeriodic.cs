using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    abstract public class ScenePeriodic : SceneBase
    {
        private Line[] lines;                   // Массив линий
        private int lastScattererIndex = -1;    // Индекс последнего рассеивателя, с которым произошло соударение. Если последнее соударение было с линией, то значение этого параметра -1
        private int lastLineIndex = -1;         // Индекс последней линии, с которой произошло соударение. Если последнее соударение было с рассеивателем, то значение этого параметра -1

        public ScenePeriodic(Scatterer[] scatterers, double fullTime, double deltaTime, double vParticle)
            : base (scatterers, fullTime, deltaTime, vParticle)
        {

        }

        public int LastScattererIndex
        {
            get
            {
                return lastScattererIndex;
            }
            set
            {
                LastScattererIndex = value;
            }
        }

        public int LastLineIndex
        {
            get
            {
                return lastLineIndex;
            }
            set
            {
                lastLineIndex = value;
            }
        }


        public Line[] Lines
        {
            get
            {
                return lines;
            }
            set
            {
                lines = value;
            }
        }

        abstract public override void GetNextCollision();

        abstract public override double FermiAccelerationTheory();

        abstract public override double CoefficientOfSuperdiffusionTheory();
    }
}
