using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    public class RealizationSet
    {

        private List<SceneBase> scenes;
        private List<List<StateOfParticle>> statisticsSet = new List<List<StateOfParticle>>();

        private List<double> averageVelocities;
        //private List<Point2D> averageDisplacementsPoint2D;
        private List<double> averageDisplacements;
        private List<Point2D> averageDisplacementOnTime;
        private List<double> times;
        private List<Point2D> averageVelocityOnTime;

        public RealizationSet(List<SceneBase> scenes)
        {
            this.scenes = scenes;
        }

        public List<Point2D> AverageVelocityOnTime
        {
            get
            {
                return averageVelocityOnTime;
            }
        }

        public List<double> AverageVelocities
        {
            get
            {
                return averageVelocities;
            }
        }

        public List<Point2D> AverageDisplacementOnTime
        {
            get
            {
                return averageDisplacementOnTime;
            }
        }

        public List<SceneBase> Scenes
        {
            get
            {
                return scenes;
            }
        }

/*        public List<double> AverageVelocities
        {
            get
            {
                return averageVelocities;
            }
        }

        public List<double> Times
        {
            get
            {
                return times;
            }
        }
*/

        public void Run(CallbackRealSetStepFunc callBack = null)
        {

            for (int i = 0; i < scenes.Count; i++)
            {
                SceneBase scene = scenes[i];
                scene.Run();
                //SceneBase sceneTemp = new SceneBase;
                List<StateOfParticle> statisticsTemp = new List<StateOfParticle>();
                statisticsTemp = scene.Statistics;
                statisticsSet.Add(statisticsTemp);
                //statisticsSet.Add(scene.Statistics);
                if (callBack != null)
                    callBack.f(i);
            }
            CalculateTimes();
            CalculateAverageVelocitiesAndDisplacements();
            //CalculateAverageDisplacements();
            CalculateVelocityAndDisplacementOnTime();
            //CalculateDisplacementOnTime();

        }

        private void CalculateTimes()
        {
            times = new List<double>();
            foreach(StateOfParticle state in statisticsSet[0])
            {
                times.Add(state.Time);
            }
        }

/*        private void CalculateAverageVelocities()
        {
            averageVelocities = new List<double>();
            //List<List>
            for (int i = 0; i < statisticsSet[0].Count; i++)
            {
                List<double> stepVelocities = new List<double>();
                foreach (List<StateOfParticle> states in statisticsSet)
                {
                    stepVelocities.Add(states[i].Particle.Velocity.Norm());
                }
                averageVelocities.Add(Averaging.Average(stepVelocities));
            }
        }
*/
        private void CalculateAverageVelocitiesAndDisplacements()
        {
            averageVelocities = new List<double>();
            averageDisplacements = new List<double>();
            //List<List>
            for (int i = 0; i < statisticsSet[0].Count; i++)
            {
                List<double> stepVelocities = new List<double>();
                List<double> stepDisplacements2 = new List<double>();
                foreach (List<StateOfParticle> states in statisticsSet)
                {
                    stepVelocities.Add(states[i].Particle.Velocity.Norm());
                    stepDisplacements2.Add(states[i].Displacement.Norm() * states[i].Displacement.Norm());
                }
                averageVelocities.Add(Averaging.Average(stepVelocities));
                averageDisplacements.Add(Math.Sqrt(Averaging.Average(stepDisplacements2)));
            }
        }
/*
        private void CalculateAverageDisplacements()
        {
            averageDisplacements = new List<Point2D>();
            for (int i = 0; i < statisticsSet[0].Count; i++)
            {
                List<Point2D> stepDisplacements = new List<Point2D>();
                foreach (List<StateOfParticle> states in statisticsSet)
                {
                    stepDisplacements.Add(states[i].Displacement);

                }

                averageDisplacements.Add(Averaging.Average(stepDisplacements));
            }
        }
*/
        private void CalculateVelocityAndDisplacementOnTime()
        {
            averageVelocityOnTime = new List<Point2D>();
            averageDisplacementOnTime = new List<Point2D>();
            for (int i = 0; i < times.Count; i++)
            {
                Point2D pointVelTemp = new Point2D(times[i], averageVelocities[i]);
                averageVelocityOnTime.Add(pointVelTemp);
                Point2D pointDispTemp = new Point2D(times[i], averageDisplacements[i]);
                averageDisplacementOnTime.Add(pointDispTemp);
            }
        }

/*        private void CalculateDisplacementOnTime()
        {
            averageDisplacementOnTime = new List<Point2D>();
            for (int i = 0; i < times.Count; i++)
            {
                Point2D averageDispTemp = (Point2D)averageDisplacements[i].Clone();
                double averDispTemp = averageDispTemp.Norm();
                Point2D pointTemp = new Point2D(times[i], averageDisplacements[i].Norm());
                averageDisplacementOnTime.Add(pointTemp);
            }
        }
*/

    }
}
