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
            List<SceneBase> scenes= new List<SceneBase>();
            for (int i = 0; i < Convert.ToInt64(numberOfRealisations.Text); i++)
            {
                scenes.Add(GetScene());
            }
            RealizationSet realizationSet = new RealizationSet(scenes);
            realizationSet.Run();

            Graph graph = new Graph(realizationSet.AverageVelocityOnTime, Color.Black);

            StatisticsForm sf = new StatisticsForm();
            sf.Show();
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


    }
}
