using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    public abstract class SceneSquareBase : SceneBase
    {
        protected double latticeSize;     //Размер ячейки для квадратной решетки

        public SceneSquareBase(Scatterer scattererSample, double fullTime, double deltaTime, double vParticle, double latticeSize)
            : base(scattererSample, fullTime, deltaTime, vParticle)
        {
            this.latticeSize = latticeSize;
            Lines = new Line[4];    // Создаем массив из черырех линий
            Lines[0] = new Line(0, 1, 0);
            Lines[1] = new Line(1, 0, -latticeSize);
            Lines[2] = new Line(0, 1, -latticeSize);
            Lines[3] = new Line(1, 0, 0);
        }
    }
}
