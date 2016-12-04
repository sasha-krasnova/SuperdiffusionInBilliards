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

        //Graphics gr;
        public StatisticsForm()
        {
            InitializeComponent();
            //gr = velocityOnTime.CreateGraphics();
        }

        public StatisticsForm(List<SceneBase> scenes) : this()
        {

            this.scenes = scenes;
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

        private void drawMeanSqDisp_Click(object sender, EventArgs e)
        {

        }

        private void calculateCoeffisientOfSuperdif_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Black, 1);
            Graph graph = new Graph(realizationSet.AverageDisplacementOnTime, pen);
            //LeastSquares leastSquares = LeastSquares(realizationSet.AverageDisplacementOnTime);
            List<Graph> graphs = new List<Graph>();
            graphs.Add((Graph)graph.Clone());
            GraphDrawer graphDrawer = new GraphDrawer(graphs, meanSqareDispOnTime);
            graphDrawer.DrawGraph();
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

        class StatusBarChanger : CallbackRealSetStepFunc
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

        public void Run()
        {
            
            realizationSet.Run(new StatusBarChanger(wf, scenes.Count));
            Thread.Sleep(1000);
            wf.CloseThread();
        }

        private void calculateAcceleration_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Black, 1);
            Pen penLS = new Pen(Color.Red, 1);
            Graph graph = new Graph(realizationSet.AverageVelocityOnTime, pen);

            LeastSquares leastSquares = new LeastSquares(realizationSet.AverageVelocityOnTime);
            double k = leastSquares.Slope(10);
            List<Point2D> pointsLeastSquares = new List<Point2D>();
            Point2D point1 = new Point2D(0, 10);
            pointsLeastSquares.Add((Point2D)point1.Clone());
            Point2D point2 = new Point2D(graph.Points[graph.Points.Count - 1].X, k*graph.Points[graph.Points.Count - 1].X + 10);
            pointsLeastSquares.Add((Point2D)point2.Clone());
            Graph graphLeastSquares = new Graph(pointsLeastSquares, penLS); 
            List<Graph> graphs = new List<Graph>();

            graphs.Add((Graph)graph.Clone());
            graphs.Add((Graph)graphLeastSquares.Clone());
            GraphDrawer graphDrawer = new GraphDrawer(graphs, averVelOnTime);
            graphDrawer.DrawGraph();

            fermiAcceleration.Text = Convert.ToString(k);
            //graphDrawer.DrawGraph(graphLeastSquares);
        }
    }
}
