using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SuperdiffusionInBilliards
{
    public partial class StatisticsOnScatVelForm : Form
    {
        List<RealizationSet> realizationSets;
        WaitForm wf;
        double initVelocity;
        List<Graph> graphsFA;

        public StatisticsOnScatVelForm()
        {
            InitializeComponent();
        }

        public StatisticsOnScatVelForm(List<RealizationSet> realizationSets, double initVelocity)
            : this()
        {
            this.realizationSets = realizationSets;
            this.initVelocity = initVelocity;
        }

        private void StatisticsOnScatVelForm_Load(object sender, EventArgs e)
        {
            
            wf = new WaitForm();

            Thread thread = new Thread(Run);

            thread.Start();
            wf.ShowDialog();
            //realizationSet.Run();
            //wf.Close();          

        }

        private void Run()
        {
            
            foreach (RealizationSet realizationSet in realizationSets)
            {
                realizationSet.Run(new StatisticsForm.StatusBarChanger(wf, realizationSet.Scenes.Count));
                Thread.Sleep(1000);
            }
            
            wf.CloseThread();
        }

        private void buttonPlotGraphs_Click(object sender, EventArgs e)
        {
            List<Point2D> pointsFA = new List<Point2D>();
            List<Point2D> pointsSC = new List<Point2D>();
            Pen pen = new Pen(Color.Black, 1);

            foreach (RealizationSet realizationSet in realizationSets)
            {
                //List<Point2D> pointsFermiAccTemp = realizationSet.AverageVelocityOnTime;
                LeastSquares leastSquaresFA = new LeastSquares(realizationSet.AverageVelocityOnTime);
                double kFA = leastSquaresFA.Slope(initVelocity);
                pointsFA.Add(new Point2D(realizationSet.Scenes[0].Scatterers[0].U0 * realizationSet.Scenes[0].Scatterers[0].U0, kFA));

                //List<Point2D> pointsSuperdifCoefTemp = realizationSet.AverageDisplacementOnTime;
                LeastSquares leastSquaresSC = new LeastSquares(realizationSet.AverageDisplacementOnTime);
                double kSC = leastSquaresSC.Slope(0);
                pointsSC.Add(new Point2D(Math.Sqrt(realizationSet.Scenes[0].Scatterers[0].U0), kSC));
            }

            Graph graphFA = new Graph(pointsFA, pen);
            graphsFA = new List<Graph>();
            graphsFA.Add(graphFA);
            GraphDrawer graphDrawerFA = new GraphDrawer(graphsFA, pictureBoxFermiAcc);
            graphDrawerFA.DrawGraph();

            Graph graphSC = new Graph(pointsSC, pen);
            List<Graph> graphsSC = new List<Graph>();
            graphsSC.Add(graphSC);
            GraphDrawer graphDrawerSC = new GraphDrawer(graphsSC, pictureBoxSuperdifCoef);
            graphDrawerSC.DrawGraph();

        }

        private void buttonFermiAcc_Click(object sender, EventArgs e)
        {
            WriteToFile(graphsFA[0].Points);
        }

        private void WriteToFile(List<Point2D> points)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CsvFileWriter csvFileWriter = new CsvFileWriter(saveFileDialog1.FileName, new List<ICsvLine>(points));
                    csvFileWriter.WriteToFile();
                    MessageBox.Show("Записано");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Произошла ошибка при записи в файл" + e);
                }
            }
        }


    }
}
