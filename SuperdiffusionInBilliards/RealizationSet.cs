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
        private List<Point2D> averageDisplacements;
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

        public void Run()
        {
            foreach (SceneBase scene in scenes)
            {
                scene.Run();
                //SceneBase sceneTemp = new SceneBase;
                List<StateOfParticle> statisticsTemp = new List<StateOfParticle>();
                statisticsTemp = scene.Statistics;
                statisticsSet.Add(statisticsTemp);
                //statisticsSet.Add(scene.Statistics);
            }
            GetTimes();
            GetAverageVelocities();
            GetAverageDisplacements();
            GetVelocityOnTime();

        }

        private void GetTimes()
        {
            times = new List<double>();
            foreach(StateOfParticle state in statisticsSet[0])
            {
                times.Add(state.Time);
            }
        }

        private void GetAverageVelocities()
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

        private void GetAverageDisplacements()
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

        private void GetVelocityOnTime()
        {
            averageVelocityOnTime = new List<Point2D>();
            for (int i = 0; i < times.Count; i++)
            {
                Point2D pointTemp = new Point2D(times[i], averageVelocities[i]);
                averageVelocityOnTime.Add(pointTemp);
            }
        }

    }
}
