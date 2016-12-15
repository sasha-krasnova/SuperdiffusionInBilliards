﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    public class SceneSquereLattice : ScenePeriodic
    {
        private double latticeSize;     //Размер ячейки для квадратной решетки
        public SceneSquereLattice(Scatterer[] scatterers, double fullTime, double deltaTime, double vParticle, double latticeSize)
            : base(scatterers, fullTime, deltaTime, vParticle)
        {
            InitParticleCoordinates(new Point2D(latticeSize / 2, latticeSize / 16));
            this.latticeSize = latticeSize;
            Lines = new Line[4];    // Создаем массив из черырех линий
            Lines[0] = new Line(0, 1, 0);
            Lines[1] = new Line(1, 0, -latticeSize);
            Lines[2] = new Line(0, 1, -latticeSize);
            Lines[3] = new Line(1 ,0, 0);

            // Присваиваем значения центрам рассеивателей
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
            double fermiAccelerationTheory;
            if (Scatterers[0] is ScattererPeriodic)
                fermiAccelerationTheory = Scatterers[0].U0 * Scatterers[0].U0 / lambda;
            else
                fermiAccelerationTheory = Scatterers[0].U0 * Scatterers[0].U0 / 3 / lambda;
            return fermiAccelerationTheory;
        }

        public override double CoefficientOfSuperdiffusionTheory()
        {
            double coefficietnOfSuperdif;
            double part1 = 4 * latticeSize * latticeSize * Scatterers[0].U0 * Scatterers[0].U0 * (Scatterers[0].Radius0 + Scatterers[4].Radius0) * (latticeSize - 2 * Scatterers[0].Radius0);
            double part2 = 3 * Math.PI * (latticeSize * latticeSize - Math.PI * (Scatterers[0].Radius0 * Scatterers[0].Radius0 + Scatterers[4].Radius0 * Scatterers[4].Radius0)) * (latticeSize * latticeSize - Math.PI * (Scatterers[0].Radius0 * Scatterers[0].Radius0 + Scatterers[4].Radius0 * Scatterers[4].Radius0));
            coefficietnOfSuperdif = Math.Sqrt(part1 / part2);
            return coefficietnOfSuperdif;
        }

        /// <summary>
        /// Функция производит следующее соударение. Ищет времена соударения со всеми элементами сцены и выбирает наименьшее положительное
        /// </summary>
        public override void GetNextCollision()
        {
            bool minTimeForLines = false;   // true - если последнее соударение произошло с линией, false - если последнее соударения было с рассеивателем
            do
            {
                //Ищем время столкновения с каждым рассевателем

                CollisionTime minCollTimeSc = new CollisionTime(0, false);  // Минимальное время соударения со всеми рассеивателями
                int minIndexSc = 0;     // Индекс рассеивателя, время соударения с которым минимально. Не должно ли здесь быть -1? Или это не имеет значения?
                for (int i = 0; i < Scatterers.Length; i++)
                {
                    CollisionTime collisionTime = ParticleScene.FindCollisionTimeScatterer(Scatterers[i]);  // Ищем время соударерния с i-тым рассеивателем, если оно существует
                    if (collisionTime.Existence && (collisionTime.Time < minCollTimeSc.Time || !minCollTimeSc.Existence))   // Если существует минимальне время соударения с рассеивателями, и если время соударерния с i-м рассеивателем существует, сравниваем его с минимальным временем
                    {
                        minIndexSc = i;
                        minCollTimeSc = collisionTime;
                    }
                
                }

                //Ищем время столкновения с каждой линией

                CollisionTime minCollTimeL = new CollisionTime(0, false);   // Минимальное время соударения со всеми линиями
                int minIndexL = 0;      // Индекс линии, время соударения с которой минимально
                for (int i = 0; i < Lines.Length; i++)  
                {
                    if (i != LastLineIndex)
                    {
                        CollisionTime collisionTime = ParticleScene.FindCollisionTimeLine(Lines[i]);    // Ищем время соударения с i-той линией, если оно существует
                        if (collisionTime.Existence && (collisionTime.Time < minCollTimeL.Time || !minCollTimeL.Existence)) // Если существует минимальное время соударения с линией, и существует время соударения с i-той линией, сравниваем его с минимальным временем
                        {
                            minIndexL = i;
                            minCollTimeL = collisionTime;
                        }
                    }
                }

                //minTimeForLines = false;
                // Если минимальное время соударения с линией меньше минимального времени соударения с рассеивателем, или время соударения с рассеивателем не существует
                if (!minCollTimeSc.Existence || minCollTimeL.Time < minCollTimeSc.Time)
                {
                    minTimeForLines = true; // Соударение произошло с линией
                    Time += minCollTimeL.Time;  // Прибавляем к текущему времени время, прошедшее с последнего соударения до декущего

                    // Преобразуем ту координату частицы, которая не фиксированна для линии
                    if (minIndexL == 0 || minIndexL == 2)
                        ParticleScene.Coordinate.X += ParticleScene.Velocity.X * minCollTimeL.Time;
                    else
                        ParticleScene.Coordinate.Y += ParticleScene.Velocity.Y * minCollTimeL.Time;

                    // В зависимости от индекса линии, с которой произошло соударение, преобразуем координаты частицы
                    if (minIndexL == 0)
                    {
                        ParticleScene.Coordinate.Y = 0;
                        //Записываем точки до этого момента. Не должен ли здесь проверяться мод?
                        GenerateDots();
                        Displacement.Y -= latticeSize;
                        ParticleScene.Coordinate.Y = latticeSize;
                        LastLineIndex = 2;
                    }
                    else if(minIndexL == 1)
                    {
                        ParticleScene.Coordinate.X = latticeSize;
                        GenerateDots();
                        Displacement.X += latticeSize;
                        ParticleScene.Coordinate.X = 0;
                        LastLineIndex = 3;
                    }
                    else if (minIndexL == 2)
                    {
                        ParticleScene.Coordinate.Y = latticeSize;
                        GenerateDots();
                        Displacement.Y += latticeSize;
                        ParticleScene.Coordinate.Y = 0;
                        LastLineIndex = 0;
                    }
                    else if (minIndexL == 3)
                    {
                        ParticleScene.Coordinate.X = 0;
                        GenerateDots();
                        Displacement.X -= latticeSize;
                        ParticleScene.Coordinate.X = latticeSize;
                        LastLineIndex = 1;
                    }

                    // Сохраняем текущую точку
                    SetOldState();
                    //LastScattererIndex = -1;
                }
                else if(minCollTimeSc.Existence)
                {
                    Time += minCollTimeSc.Time;
                    //LastScattererIndex = minIndexSc;

                    ParticleScene = ParticleScene.MakeScattererCollision(Scatterers[minIndexSc], minCollTimeSc.Time, Time);
                    //Записываем точки до этого момента
                    //Сохраняем текущую точку
                    GenerateDots();
                    SetOldState();
                    LastLineIndex = -1;
                    minTimeForLines = false;
                }
                else
                {
                    throw new Exception("Не произошло столкновение ни с чем");
                }
            }
            while (minTimeForLines);
        }
    }
}
