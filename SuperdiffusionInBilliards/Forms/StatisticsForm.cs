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

        /*private void drawVelocityOnTime_Click(object sender, EventArgs e)
        {  
            Pen pen = new Pen(Color.Black, 1);
            Graph graph = new Graph(realizationSet.AverageVelocityOnTime, pen);
            List<Graph> graphs = new List<Graph>();
            graphs.Add((Graph)graph.Clone());
            GraphDrawer graphDrawer = new GraphDrawer(graphs, averVelOnTime);
            graphDrawer.DrawGraph();

            
            Graphics g2 = velOnTime.CreateGraphics();
            Rectangle rect2 = new Rectangle(0, 0, velOnTime.Width / 2, velOnTime.Height / 2);
            g2.DrawEllipse(graph.Pen, rect2);
            g2.DrawLine(new Pen(Brushes.Red, 4), new Point(2, 2), new Point(10, 100));

            Graphics g = averVelOnTime.CreateGraphics();
            Rectangle rect = new Rectangle(0, 0, averVelOnTime.Width / 2, averVelOnTime.Height / 2);
            g.DrawEllipse(graph.Pen, rect);
            g.DrawLine(new Pen(Brushes.Red, 4), new Point(2, 2), new Point(10, 100));

            Graphics g1 = meanSqareDispOnTime.CreateGraphics();
            Rectangle rect1 = new Rectangle(0, 0, meanSqareDispOnTime.Width / 2, meanSqareDispOnTime.Height / 2);
            g1.DrawEllipse(graph.Pen, rect1);
            g1.DrawLine(new Pen(Brushes.Red, 4), new Point(2, 2), new Point(10, 100));
        }*/

        private void calculateCoeffisientOfSuperdif_Click(object sender, EventArgs e)
        {
            buttonWriteDispInFile.Enabled = true;
            Graph graph = new Graph(realizationSet.AverageDisplacementOnTime, pen);

            LeastSquares leastSquares = new LeastSquares(realizationSet.AverageDisplacementOnTime);
            double k = leastSquares.Slope(0);
            List<Point2D> pointsLeastSquares = MakeLineBySlope(k, new Point2D(0, 0), fullTime);
            Graph graphLeastSquares = new Graph(pointsLeastSquares, penLS);

            double kTheory = scenes[0].CoefficientOfSuperdiffusionTheory();
            List<Point2D> pointsTheory = MakeLineBySlope(kTheory, new Point2D(0, 0), fullTime);
            Graph graphTheory = new Graph(pointsTheory, penTheory);
            
            
            graphsMSD = new List<Graph>();
            graphsMSD.Add((Graph)graph.Clone());
            graphsMSD.Add((Graph)graphLeastSquares.Clone());
            graphsMSD.Add((Graph)graphTheory.Clone());

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
            Graph graph = new Graph(realizationSet.AverageVelocityOnTime, pen);

            LeastSquares leastSquares = new LeastSquares(realizationSet.AverageVelocityOnTime);
            double k = leastSquares.Slope(initVelocity);
            List<Point2D> pointsLeastSquares = MakeLineBySlope(k, new Point2D(0, initVelocity), fullTime);
            Graph graphLeastSquares = new Graph(pointsLeastSquares, penLS);

            double kTheory = scenes[0].FermiAccelerationTheory();
            List<Point2D> pointsTheory = MakeLineBySlope(kTheory, new Point2D(0, initVelocity), fullTime);
            Graph graphTheory = new Graph(pointsTheory, penTheory);

            graphsAverVel = new List<Graph>();
            graphsAverVel.Add((Graph)graph.Clone());
            graphsAverVel.Add((Graph)graphLeastSquares.Clone());
            graphsAverVel.Add((Graph)graphTheory.Clone());

            GraphDrawer graphDrawer = new GraphDrawer(graphsAverVel, averVelOnTime);
            graphDrawer.DrawGraph();

            fermiAcceleration.Text = Convert.ToString(k);
            fermiAccelerationTheory.Text = Convert.ToString(kTheory);
            //graphDrawer.DrawGraph(graphLeastSquares);
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
