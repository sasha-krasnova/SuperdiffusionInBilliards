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
    public partial class StatisticsForm : Form
    {
        private List<SceneBase> scenes;
        private RealizationSet realizationSet;
        private WaitForm wf;
        private double initVelocity;
        private double fullTime;
        private List<Graph> graphsAverVel, graphsMSD;
        private Graph graph, graphLeastSquares, graphTheory;
        private Pen pen = new Pen(Color.Black, 1);
        private Pen penLS = new Pen(Color.Red, 1);
        private Pen penTheory = new Pen(Color.Blue, 1);

//        private double ampOfScatVel;
//        private double lattic

        //Graphics gr;
        public StatisticsForm()
        {
            InitializeComponent();
            //gr = velocityOnTime.CreateGraphics();
        }

        public StatisticsForm(List<SceneBase> scenes, double initVelocity, double fullTime) : this()
        {
            this.initVelocity = initVelocity;
            this.scenes = scenes;
            this.fullTime = fullTime;
        }


        private void calculateCoeffisientOfSuperdif_Click(object sender, EventArgs e)
        {
            buttonWriteDispInFile.Enabled = true;
            graph = new Graph(realizationSet.AverageDisplacementOnTime, pen);

            double k = GetSlope(0);
            MakeGraphLeastSquares(0);

            double kTheory = scenes[0].CoefficientOfSuperdiffusionTheory();
            MakeGraphTheory(0, kTheory);

            graphsMSD = GetGraphs();
            
            GraphDrawer graphDrawer = new GraphDrawer(graphsMSD, meanSqareDispOnTime);
            graphDrawer.DrawGraph();

            coefOfSuperdif.Text = Convert.ToString(k);
            coefOfSuperdifTheory.Text = Convert.ToString(kTheory);

        }

        private List<Point2D> MakeLineBySlope(double slope, Point2D initPoint, double endPointX)
        {
            List<Point2D> points = new List<Point2D>();
            points.Add((Point2D)initPoint.Clone());
            points.Add(new Point2D(endPointX, slope*endPointX+initPoint.Y));
            return points;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            realizationSet = new RealizationSet(scenes);
            wf = new WaitForm();
            
            Thread thread = new Thread(Run);
    
            thread.Start();
            wf.ShowDialog();
            //realizationSet.Run();
            //wf.Close();          
        }
              
        public void Run()
        {
            
            realizationSet.Run(new StatusBarChanger(wf, scenes.Count));
            Thread.Sleep(1000);
            wf.CloseThread();
        }

        private void calculateAcceleration_Click(object sender, EventArgs e)
        {
            buttonWriteVelToFile.Enabled = true;
            //SuperdiffusionDrawingModes drawingMode = SuperdiffusionDrawingModes.Points;
            graph = new Graph(realizationSet.AverageVelocityOnTime, pen);

            double k = GetSlope(initVelocity);
            MakeGraphLeastSquares(initVelocity);

            double kTheory = scenes[0].FermiAccelerationTheory();
            MakeGraphTheory(initVelocity, kTheory);

            graphsAverVel = GetGraphs();
            
            GraphDrawer graphDrawer = new GraphDrawer(graphsAverVel, averVelOnTime);
            graphDrawer.DrawGraph();

            fermiAcceleration.Text = Convert.ToString(k);
            fermiAccelerationTheory.Text = Convert.ToString(kTheory);
            //graphDrawer.DrawGraph(graphLeastSquares);
        }

        private List<Graph> GetGraphs()
        {
            List<Graph> graphs = new List<Graph>();
            graphs.Add((Graph)graph.Clone());
            graphs.Add((Graph)graphLeastSquares.Clone());
            graphs.Add((Graph)graphTheory.Clone());

            return graphs;
        }

        private void MakeGraphLeastSquares(double shift)
        {
            double k = GetSlope(shift);
            List<Point2D> pointsLeastSquares = MakeLineBySlope(k, new Point2D(0, shift), fullTime);
            graphLeastSquares = new Graph(pointsLeastSquares, penLS);
        }

        private void MakeGraphTheory(double shift, double slope)
        {
            List<Point2D> pointsTheory = MakeLineBySlope(slope, new Point2D(0, shift), fullTime);
            graphTheory = new Graph(pointsTheory, penTheory);
        }

        private double GetSlope(double shift)
        {
            LeastSquares leastSquares = new LeastSquares(graph.Points);
            double k = leastSquares.Slope(shift);
            return k;
        }

        public class StatusBarChanger : CallbackRealSetStepFunc
        {
            private WaitForm wf;
            private int scenesCount;

            public StatusBarChanger(WaitForm wf, int scenesCount)
            {
                this.wf = wf;
                this.scenesCount = scenesCount;
            }

            public void f(int idxOfReal)
            {
                //почему + 1??
                wf.ChangePercentThread(idxOfReal + 1, scenesCount);
            }
        }

        private void buttonWriteVelToFile_Click(object sender, EventArgs e)
        {
            WriteToFile(graphsAverVel[0].Points);
        }

        private void buttonWriteDispInFile_Click(object sender, EventArgs e)
        {
            WriteToFile(graphsMSD[0].Points);
        }

        private void WriteToFile (List<Point2D> points)
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
