using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    class RandomScattererSet
    {
        private double scattererConcentration;
        private List<Scatterer> scatterers = new List<Scatterer>();
        private double maxScattererSampleRadius;

        public static Point2D FIELD_SIZE = new Point2D(1000, 1000);

        //private static const Point2D LATTICE_SIZE = new Point2D(100, 100);

        public RandomScattererSet(Scatterer scattererSample, double scattererConcentration)
        {
            this.scattererConcentration = scattererConcentration;
            GenerateScattererSet(scattererSample);
            maxScattererSampleRadius = scattererSample.MaxRadius();
        }

        private void GenerateScattererSet(Scatterer scattererSample)
        {
            Random rndm = new Random();

            for (int i = 0; i < ScatterersCount; i++)
            {
                Scatterer scattererTemp;
                do
                {
                    scattererTemp = GenerateScatterer(scattererSample, rndm);
                }
                while (!IsScattererPositionValid(scattererTemp));

                addScatterers(scattererTemp);
            }
        }
        private void addScatterers(Scatterer scattererTemp)
        {
            List<List<double>> displacements = getDisplacements(scattererTemp);

            foreach (double displacementX in displacements[0])
            {
                foreach (double displacementY in displacements[1])
                {
                    Scatterer sc = (Scatterer)scattererTemp.Clone();
                    sc.Center.X += displacementX;
                    sc.Center.Y += displacementY;
                    scatterers.Add(sc);
                }
            }
        }

        private Scatterer GenerateScatterer(Scatterer scattererSample, Random rndm)
        {
            Scatterer scatterer = (Scatterer)scattererSample.Clone();
            scatterer.Center.X = FIELD_SIZE.X * rndm.NextDouble();
            scatterer.Center.Y = FIELD_SIZE.Y * rndm.NextDouble();
            return scatterer;
        }

        private bool IsScattererPositionValid(Scatterer scattererTemp)
        {

            List<List<double>> displacements = getDisplacements(scattererTemp);

            foreach (double displacementX in displacements[0])
            {
                foreach (double displacementY in displacements[1])
                {
                    foreach (Scatterer scatterer in scatterers)
                    {
                        Scatterer sc = (Scatterer)scattererTemp.Clone();
                        sc.Center.X += displacementX;
                        sc.Center.Y += displacementY;
                        if (DoesScatterersConflict(scatterer, sc))
                            return false;
                    }
                }
            }
            return true;
        }

        private List<List<double>> getDisplacements(Scatterer sc)
        {
            List<List<double>> result = new List<List<double>>();

            //список смещений по x
            List<double> displacementsX = new List<double>();
            displacementsX.Add(0);

            //список смещений по y
            List<double> displacementsY = new List<double>();
            displacementsY.Add(0);

            if (sc.Center.X < sc.MaxRadius())
            {
                displacementsX.Add(FIELD_SIZE.X);
            }

            if (sc.Center.X > FIELD_SIZE.X - sc.MaxRadius())
            {
                displacementsX.Add(-FIELD_SIZE.X);
            }

            if (sc.Center.Y < sc.MaxRadius())
            {
                displacementsY.Add(FIELD_SIZE.Y);
            }

            if (sc.Center.Y > FIELD_SIZE.Y - sc.MaxRadius())
            {
                displacementsY.Add(-FIELD_SIZE.Y);
            }

            result.Add(displacementsX);
            result.Add(displacementsY);
            return result;
        }

        private bool DoesScatterersConflict(Scatterer scattererOne, Scatterer scattererTwo)
        {
            double distanceBetweenScatterers = Math.Sqrt((scattererOne.Center.X - scattererTwo.Center.X) * (scattererOne.Center.X - scattererTwo.Center.X) + (scattererOne.Center.Y - scattererTwo.Center.Y) * (scattererOne.Center.Y - scattererTwo.Center.Y));
            if (distanceBetweenScatterers < (scattererTwo.MaxRadius() + scattererOne.MaxRadius()))
                return true;
            else
                return false;
        }

        public int ScatterersCount 
        {
            get
            {
                return Convert.ToInt32(Math.Round(scattererConcentration * FIELD_SIZE.X * FIELD_SIZE.Y));
            }
        }

        public List<Scatterer> GetScatterersForScene(Point2D displacement, Point2D latticeSize)
        {
            if (FIELD_SIZE.X % latticeSize.X != 0 || FIELD_SIZE.Y % latticeSize.Y != 0)
            {
                throw new Exception("Поле не кратно ячейке.");
            }
            Point2D displacementCut = new Point2D();

            displacementCut.X = displacement.X % FIELD_SIZE.X;
            if (displacementCut.X < 0)
                displacementCut.X = displacementCut.X + FIELD_SIZE.X;
            displacementCut.Y = displacement.Y % FIELD_SIZE.Y;
            if (displacementCut.Y < 0)
                displacementCut.Y = displacementCut.Y + FIELD_SIZE.Y;
            

            List<Scatterer> scatterersForScene = new List<Scatterer>();
            foreach (Scatterer scatterer in scatterers)
            {
                if (IsScattererInRectangle(scatterer, new Rectangle(displacementCut, latticeSize)))
                {
                    Scatterer scattererTemp = (Scatterer) scatterer.Clone();
                    scattererTemp.Center.X -= displacementCut.X;
                    scattererTemp.Center.Y -= displacementCut.Y;
                    scatterersForScene.Add(scattererTemp);
                }
            }

            return scatterersForScene;
        }

        public bool IsScattererInRectangle(Scatterer scatterer, Rectangle rect)
        {
            bool isXInRectangle = scatterer.Center.X > rect.LeftTop.X - maxScattererSampleRadius && scatterer.Center.X < rect.RightBottom.X + maxScattererSampleRadius;
            bool isYInRectangle = scatterer.Center.Y > rect.LeftTop.Y - maxScattererSampleRadius && scatterer.Center.Y < rect.RightBottom.Y + maxScattererSampleRadius;
            if (isXInRectangle && isYInRectangle)
                return true;

            return false;
        }
    }
}
