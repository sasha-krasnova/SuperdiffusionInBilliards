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

        private void button1_Click_1(object sender, EventArgs e)
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
                scene = new SceneSquereLattice(scatterers, Convert.ToDouble(fullTime.Text), Convert.ToDouble(deltaTime.Text), Convert.ToDouble(initialVelocity.Text),Convert.ToDouble(latticeSize.Text));
            }


            scene.Run();


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
            //RadioButton rb = (RadioButton)sender;
            //rb.Checked = true;
           // randomScene.Checked = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /*Scatterer[] scatterers = null;
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


            scene.Run();


            DrawingForm df = new DrawingForm(scene.Statistics, new Point2D(Convert.ToDouble(latticeSize.Text), Convert.ToDouble(latticeSize.Text)));
            df.Show();*/

        }

        private void statistics_Click(object sender, EventArgs e)
        {
            StatisticsForm sf = new StatisticsForm();
            sf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Point2D> pointsForApprox = new List<Point2D>();
            Point2D point = new Point2D (0, 0);
            pointsForApprox.Add(point);
            
            for (int i = 1; i <= 1; i++)
            {
                point.X += 1;
                point.Y += 2;
                pointsForApprox.Add(point);
            }



        }

    }
}
