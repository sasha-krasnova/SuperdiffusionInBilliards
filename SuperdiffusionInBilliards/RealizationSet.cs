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

        public RealizationSet(List<SceneBase> scenes)
        {
            this.scenes = scenes;
        }

        public void Run()
        {
            foreach (SceneBase scene in scenes)
            {
                scene.Run();
                //List<StateOfParticle> statisticsTemp = new List<StateOfParticle>();
                //statisticsTemp = scene.Statistics;
                //statisticsSet.Add(statisticsTemp);
                statisticsSet.Add(scene.Statistics);
            }
            getTimes();
            getAverageVelocities();
            getAverageDisplacements();

        }

        private void getTimes()
        {
            times = new List<double>();
            foreach(StateOfParticle state in statisticsSet[0])
            {
                times.Add(state.Time);
            }
        }

        private void getAverageVelocities()
        {
            averageVelocities = new List<double>();
            //List<List>
            for (int i = 0; i < statisticsSet[0].Count; i++)
            {
                List<double> stepVelocities = new List<double>();
                foreach (List<StateOfParticle> states in statisticsSet)
                {
                    stepVelocities.Add(states[i].Particle.Velocity.norm());
                }
                averageVelocities.Add(Averaging.Average(stepVelocities));
            }
        }

        private void getAverageDisplacements()
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
    }
}
