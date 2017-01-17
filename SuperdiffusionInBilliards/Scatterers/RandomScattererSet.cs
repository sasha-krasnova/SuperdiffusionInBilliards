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
        private static Point2D FIELD_SIZE = new Point2D(100, 100);
        //private static const Point2D LATTICE_SIZE = new Point2D(100, 100);

        public RandomScattererSet(Scatterer scattererSample, double scattererConcentration)
        {
            this.scattererConcentration = scattererConcentration;
            GenerateScattererSet(scattererSample);
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
                while (IsScattererPositionValid(scattererTemp));
                scatterers.Add(scattererTemp);
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
    }
}
