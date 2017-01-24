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
                scatterers.Add(scattererTemp);
            }
        }

        private Scatterer GenerateScatterer(Scatterer scattererSample, Random rndm)
        {
            Scatterer scatterer = (Scatterer)scattererSample.Clone();
            scatterer.Center.X = (FIELD_SIZE.X - 2 * maxScattererSampleRadius) * rndm.NextDouble() + maxScattererSampleRadius;
            scatterer.Center.Y = (FIELD_SIZE.Y - 2 * maxScattererSampleRadius) * rndm.NextDouble() + maxScattererSampleRadius;
            return scatterer;
        }

        private bool IsScattererPositionValid(Scatterer scattererTemp)
        {

            foreach (Scatterer scatterer in scatterers)
            {
                if (DoesScatterersConflict(scatterer, scattererTemp))
                    return false;
            }
            return true;
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

        public List<Scatterer> GetScatterersForScene(Point2D displacement, Point2D lattiseSize)
        {
            if (FIELD_SIZE.X % lattiseSize.X != 0 || FIELD_SIZE.Y % lattiseSize.Y != 0)
            {
                throw new Exception("Поле не кратно ячейке.");
            }
            Point2D displacementCut = new Point2D();
            displacementCut.X = displacement.X % FIELD_SIZE.X;
            displacementCut.Y = displacement.Y % FIELD_SIZE.Y;

            List<Scatterer> scatterersForScene = new List<Scatterer>();
            foreach (Scatterer scatterer in scatterers)
            {
                if (IsScattererInRectangle(scatterer, new Rectangle(displacementCut, lattiseSize)))
                {
                    scatterersForScene.Add(scatterer);
                }
            }

            return scatterersForScene;
        }

        public bool IsScattererInRectangle(Scatterer scatterer, Rectangle rect)
        {
       //     maxScattererSampleRadius;
            bool isXInRectangle = scatterer.Center.X > rect.LeftTop.X - maxScattererSampleRadius && scatterer.Center.X < rect.RightBottom.X + maxScattererSampleRadius;
            bool isYInRectangle = scatterer.Center.Y > rect.LeftTop.Y - maxScattererSampleRadius && scatterer.Center.Y < rect.RightBottom.Y + maxScattererSampleRadius;
            if (isXInRectangle && isYInRectangle)
                return true;
            else
                return false;
            //TODO: написать код
        }
    }
}
