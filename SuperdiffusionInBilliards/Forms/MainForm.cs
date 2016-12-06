using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperdiffusionInBilliards
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            staticticsStandart.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Function f = new TestFunction();
            List<double> roots = NewtonsMethod.Solve(f, 0);
            foreach(double root in roots)
            {
                MessageBox.Show(root.ToString());
            }
        }

        private SceneBase GetScene()
        {
            Scatterer[] scatterers = null;
            SceneBase scene = null;
            if (squareScene.Checked)
            {
                scatterers = new Scatterer[5];
                if (harmonicScatterer.Checked)
                {
                    for (int i = 0; i < scatterers.Length - 1; i++)
                    {
                        scatterers[i] = new ScattererHarmonic(new Point2D(0, 0), Convert.ToDouble(averageRadius.Text), Convert.ToDouble(amplitudeOfScattererVelocity.Text), Convert.ToDouble(periodOfScattererOsc.Text));
                    }
                    scatterers[4] = new ScattererHarmonic(new Point2D(0, 0), Convert.ToDouble(averageRadiusOfCentralSc.Text), Convert.ToDouble(amplitudeOfScattererVelocity.Text), Convert.ToDouble(periodOfScattererOsc.Text));
                }
                scene = new SceneSquereLattice(scatterers, Convert.ToDouble(fullTime.Text), Convert.ToDouble(deltaTime.Text), Convert.ToDouble(initialVelocity.Text), Convert.ToDouble(latticeSize.Text));
            }
            return scene;
        }

        private SceneBase GetScene(double ampOfScattererVelocity)
        {
            Scatterer[] scatterers = null;
            SceneBase scene = null;
            if (squareScene.Checked)
            {
                scatterers = new Scatterer[5];
                if (harmonicScatterer.Checked)
                {
                    for (int i = 0; i < scatterers.Length - 1; i++)
                    {
                        scatterers[i] = new ScattererHarmonic(new Point2D(0, 0), Convert.ToDouble(averageRadius.Text), ampOfScattererVelocity, Convert.ToDouble(periodOfScattererOsc.Text));
                    }
                    scatterers[4] = new ScattererHarmonic(new Point2D(0, 0), Convert.ToDouble(averageRadiusOfCentralSc.Text), ampOfScattererVelocity, Convert.ToDouble(periodOfScattererOsc.Text));
                }
                scene = new SceneSquereLattice(scatterers, Convert.ToDouble(fullTime.Text), Convert.ToDouble(deltaTime.Text), Convert.ToDouble(initialVelocity.Text), Convert.ToDouble(latticeSize.Text));
            }
            return scene;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            SceneBase scene = GetScene();

            WaitForm wf = new WaitForm();
            wf.Show();
            scene.StatMode = SuperdiffusionRunModes.Detail;
            scene.Run();
            wf.Close();
            DrawingForm df = new DrawingForm(scene.Statistics, new Point2D(Convert.ToDouble(latticeSize.Text), Convert.ToDouble(latticeSize.Text)));
            df.Show();
        }

        private void randomScene_CheckedChanged(object sender, EventArgs e)
        {
            averageRadiusOfCentralSc.Enabled = false;
        }

        private void squareScene_CheckedChanged(object sender, EventArgs e)
        {
            averageRadiusOfCentralSc.Enabled = true;
        }

        private void triangularScene_CheckedChanged(object sender, EventArgs e)
        {
            averageRadiusOfCentralSc.Enabled = false;
        }

        private void randomScene_Click(object sender, EventArgs e)
        {
        }

        private void statistics_Click(object sender, EventArgs e)
        {
            if (staticticsStandart.Checked)
            {
                List<SceneBase> scenes = new List<SceneBase>();
                
                for (int i = 0; i < Convert.ToInt64(numberOfRealisations.Text); i++)
                {
                    
                    scenes.Add(GetScene());
                }


                //Pen pen = new Pen(Color.Black);
                //Graph graph = new Graph(realizationSet.AverageVelocityOnTime, pen);

                StatisticsForm sf = new StatisticsForm(scenes, Convert.ToDouble(initialVelocity.Text), Convert.ToDouble(fullTime.Text));
                sf.Show();
            }

            if (statisticsOnScatVel.Checked)
            {
                List<RealizationSet> realizationSets = new List<RealizationSet>();
                double ampOfScVel;
                for (int i = 0; i < Convert.ToInt32(textBoxNumPointsAmp.Text); i++)
                {
                    ampOfScVel = Convert.ToDouble(textBoxInitAmp.Text) + i * Convert.ToDouble(textBoxStepAmp.Text);
                    RealizationSet realizationSetTemp = new RealizationSet(GetScenes(ampOfScVel));
                    realizationSets.Add(realizationSetTemp);
                    //List<SceneBase> scenes = new List<SceneBase>();
                }
                StatisticsOnScatVelForm sAmpF = new StatisticsOnScatVelForm(realizationSets, Convert.ToDouble(initialVelocity.Text));
                sAmpF.Show();
            }
        }

        private List<SceneBase> GetScenes(double ampOfScVel)
        {
            List<SceneBase> scenes = new List<SceneBase>();
            for (int i = 0; i < Convert.ToInt64(numberOfRealisations.Text); i++)
            {
                scenes.Add(GetScene(ampOfScVel));
            }
            return scenes;
        }

        private void leastSquares_Click(object sender, EventArgs e)
        {
            LeastSquaresForm lsf = new LeastSquaresForm();
            lsf.Show();
        }

        private void averagingForm_Click(object sender, EventArgs e)
        {
            AveragingForm af = new AveragingForm();
            af.Show();
        }

        private void statisticsOnScatVel_CheckedChanged(object sender, EventArgs e)
        {
            amplitudeOfScattererVelocity.Enabled = false;
            averageRadius.Enabled = true;
            periodOfScattererOsc.Enabled = true;

            textBoxInitAmp.Enabled = true;
            textBoxStepAmp.Enabled = true;
            textBoxNumPointsAmp.Enabled = true;

            textBoxInitRadius.Enabled = false;
            textBoxStepRadius.Enabled = false;
            textBoxNumPointsRadius.Enabled = false;

            textBoxInitPeriod.Enabled = false;
            textBoxStepPeriod.Enabled = false;
            textBoxNumPointsPeriod.Enabled = false;
        }

        private void statisticsOnScatRadius_CheckedChanged(object sender, EventArgs e)
        {
            averageRadius.Enabled = false;
            periodOfScattererOsc.Enabled = true;
            amplitudeOfScattererVelocity.Enabled = true;

            textBoxInitAmp.Enabled = false;
            textBoxStepAmp.Enabled = false;
            textBoxNumPointsAmp.Enabled = false;

            textBoxInitRadius.Enabled = true;
            textBoxStepRadius.Enabled = true;
            textBoxNumPointsRadius.Enabled = true;

            textBoxInitPeriod.Enabled = false;
            textBoxStepPeriod.Enabled = false;
            textBoxNumPointsPeriod.Enabled = false;

        }

        private void statisticsOnPeriod_CheckedChanged(object sender, EventArgs e)
        {
            periodOfScattererOsc.Enabled = false;
            amplitudeOfScattererVelocity.Enabled = true;
            averageRadius.Enabled = true;

            textBoxInitAmp.Enabled = false;
            textBoxStepAmp.Enabled = false;
            textBoxNumPointsAmp.Enabled = false;

            textBoxInitRadius.Enabled = false;
            textBoxStepRadius.Enabled = false;
            textBoxNumPointsRadius.Enabled = false;

            textBoxInitPeriod.Enabled = true;
            textBoxStepPeriod.Enabled = true;
            textBoxNumPointsPeriod.Enabled = true;

        }

        private void staticticsStandart_CheckedChanged(object sender, EventArgs e)
        {
            amplitudeOfScattererVelocity.Enabled = true;
            averageRadius.Enabled = true;
            periodOfScattererOsc.Enabled = true;
            
            textBoxInitAmp.Enabled = false;
            textBoxStepAmp.Enabled = false;
            textBoxNumPointsAmp.Enabled = false;

            textBoxInitRadius.Enabled = false;
            textBoxStepRadius.Enabled = false;
            textBoxNumPointsRadius.Enabled = false;

            textBoxInitPeriod.Enabled = false;
            textBoxStepPeriod.Enabled = false;
            textBoxNumPointsPeriod.Enabled = false;

        }

        private void harmonicScatterer_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
