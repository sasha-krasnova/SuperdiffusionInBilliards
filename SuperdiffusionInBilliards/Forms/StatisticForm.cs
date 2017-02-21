﻿using System;
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
    public enum SuperdiffusionStatisticsModes { Standart, DependenceOnVelocity, DependenceOnPeriod, DependenceOnRadius }
    public partial class StatisticForm : Form
    {
        public List<RealizationSet> realizationSets;
        //private RealizationSet realizationSet;
        public SuperdiffusionStatisticsModes statMode;
        private WaitForm wf;
        //private double initVelocity;
        //private double fullTime;
        private List<Graph> graphsAverVel, graphsMSD, graphsFA, graphsSC;
        private Graph graph, graphLeastSquares, graphTheory;
        private Graph graphFA, graphFATheory, graphSC, graphSCTheory;
        private Pen pen = new Pen(Color.Black, 1);
        private Pen penLS = new Pen(Color.Red, 1);
        private Pen penTheory = new Pen(Color.Blue, 1);
        public StatisticForm()
        {
            InitializeComponent();
            //statMode = SuperdiffusionStatisticsModes.Standart;
            //if (statMode == SuperdiffusionStatisticsModes.Standart)
            //    VelOrFALabel.Text = "Зависимость средней скорости частицы от времени";
        }

        public StatisticForm(List<RealizationSet> realizationSets, SuperdiffusionStatisticsModes statMode)
            : this()
        {
            this.realizationSets = realizationSets;
            this.statMode = statMode;
            if (statMode == SuperdiffusionStatisticsModes.DependenceOnVelocity)
            {
                velOrFALabel.Text = "Зависимость ускорения Ферми от квадрата скорости рассеивателя";
                msdOrSupCoefLabel.Text = "Зависимость коэффициента супердиффузии от скорости рассеивателя";
                plotVelOrFAButton.Text = "Построить график";
                plotMSDOrSupCoefButton.Text = "Построить график";
                faTextBox.Enabled = false;
                faTheorTextBox.Enabled = false;
                scTextBox.Enabled = false;
                scTheorTextBox.Enabled = false;
            }
            else if (statMode == SuperdiffusionStatisticsModes.DependenceOnRadius)
            {
                velOrFALabel.Text = "Зависимость ускорения Ферми от среднего радиуса рассеивателя";
                msdOrSupCoefLabel.Text = "Зависимость коэффициента супердиффузии от среднего радиуса рассеивателя";
                plotVelOrFAButton.Text = "Построить график";
                plotMSDOrSupCoefButton.Text = "Построить график";
                faTextBox.Enabled = false;
                faTheorTextBox.Enabled = false;
                scTextBox.Enabled = false;
                scTheorTextBox.Enabled = false;
            }
            else if (statMode == SuperdiffusionStatisticsModes.DependenceOnPeriod)
            {
                velOrFALabel.Text = "Зависимость ускорения Ферми от периода осцилляций рассеивателя";
                msdOrSupCoefLabel.Text = "Зависимость коэффициента супердиффузии от периода осцилляций рассеивателя";
                plotVelOrFAButton.Text = "Построить график";
                plotMSDOrSupCoefButton.Text = "Построить график";
                faTextBox.Enabled = false;
                faTheorTextBox.Enabled = false;
                scTextBox.Enabled = false;
                scTheorTextBox.Enabled = false;
            }
        }

        private void plotVelOrFAButton_Click(object sender, EventArgs e)
        {
            writeInFileVelButton.Enabled = true;
            if (statMode == SuperdiffusionStatisticsModes.Standart)
            {
                graph = new Graph(realizationSets[0].AverageVelocityOnTime, pen);

                double k = GetSlope(realizationSets[0].Scenes[0].InitVelocity);
                List<Point2D> pointsLeastSquares = GetPointsForLinearGraph(realizationSets[0].AverageVelocityOnTime[0], k, realizationSets[0].Scenes[0].DeltaTime, realizationSets[0].Scenes[0].FullTime);
                graphLeastSquares = new Graph(pointsLeastSquares, penLS);
                
                double kTheory = realizationSets[0].Scenes[0].FermiAccelerationTheory();
                List<Point2D> pointsTheory = GetPointsForLinearGraph(realizationSets[0].AverageVelocityOnTime[0], kTheory, realizationSets[0].Scenes[0].DeltaTime, realizationSets[0].Scenes[0].FullTime);
                graphTheory = new Graph(pointsTheory, penTheory);
                    

                graphsAverVel = GetGraphs();

                GraphDrawer graphDrawer = new GraphDrawer(graphsAverVel, velOrFAPictureBox);
                graphDrawer.DrawGraph();

                faTextBox.Text = Convert.ToString(k);
                faTheorTextBox.Text = Convert.ToString(kTheory);
            }
            if (statMode == SuperdiffusionStatisticsModes.DependenceOnVelocity || statMode == SuperdiffusionStatisticsModes.DependenceOnRadius)
            {
                graphFA = new Graph(GetPointsFermiAcceleration(), pen);
                graphFATheory = new Graph(GetPointsFermiAccelerationTheory(), penTheory);
                //Graph graphFALeastSquares = 
                graphsFA = new List<Graph>();                     
                graphsFA.Add(graphFA);
                graphsFA.Add(graphFATheory);
                GraphDrawer graphDrawer = new GraphDrawer(graphsFA, velOrFAPictureBox);
                graphDrawer.DrawGraph();
            }
        }

        private List<Point2D> GetPointsFermiAcceleration()
        {
            List<Point2D> points = new List<Point2D>();
            foreach (RealizationSet realizationSet in realizationSets)
            {
                LeastSquares leastSquaresFA = new LeastSquares(realizationSet.AverageVelocityOnTime);
                double kFA = leastSquaresFA.Slope(realizationSet.Scenes[0].InitVelocity);
                if (statMode == SuperdiffusionStatisticsModes.DependenceOnVelocity)
                    points.Add(new Point2D(realizationSet.Scenes[0].Scatterers[0].U0 * realizationSet.Scenes[0].Scatterers[0].U0, kFA));
                if (statMode == SuperdiffusionStatisticsModes.DependenceOnRadius)
                    points.Add(new Point2D(realizationSet.Scenes[0].Scatterers[0].Radius0, kFA));
                //if (statMode == SuperdiffusionStatisticsModes.DependenceOnVelocity)
                    //points.Add(new Point2D(realizationSet.Scenes[0].Scatterers[0].U0, kFA));
            }
            return points;
        }

        private List<Point2D> GetPointsFermiAccelerationTheory()
        {
            List<Point2D> points = new List<Point2D>();
            foreach (RealizationSet realizationSet in realizationSets)
            {
                if (statMode == SuperdiffusionStatisticsModes.DependenceOnVelocity) 
                    points.Add(new Point2D(realizationSet.Scenes[0].Scatterers[0].U0 * realizationSet.Scenes[0].Scatterers[0].U0, realizationSet.Scenes[0].FermiAccelerationTheory()));
                if (statMode == SuperdiffusionStatisticsModes.DependenceOnRadius)
                    points.Add(new Point2D(realizationSet.Scenes[0].Scatterers[0].Radius0, realizationSet.Scenes[0].FermiAccelerationTheory()));
            }
            return points;
        }

        private List<Graph> GetGraphs()
        {
            List<Graph> graphs = new List<Graph>();
            graphs.Add((Graph)graph.Clone());
            graphs.Add((Graph)graphLeastSquares.Clone());
            graphs.Add((Graph)graphTheory.Clone());

            return graphs;
        }

        private List<Point2D> GetPointsForLinearGraph(Point2D initPoint, double slope, double deltaX, double fullX)
        {
            int numberOfPoints = Convert.ToInt32(fullX / deltaX);
            List<Point2D> points = new List<Point2D>();
            for (int i = 0; i < numberOfPoints; i++)
            {
                Point2D tempPoint = new Point2D();
                tempPoint.X = initPoint.X + deltaX * i;
                tempPoint.Y = slope * tempPoint.X + initPoint.Y;
                points.Add(tempPoint);
            }
            return points;
        }

        private double GetSlope(double shift)
        {
            LeastSquares leastSquares = new LeastSquares(graph.Points);
            double k = leastSquares.Slope(shift);
            return k;
        }

        private void StatisticForm_Load(object sender, EventArgs e)
        {
                wf = new WaitForm();

                Thread thread = new Thread(Run);

                thread.Start();
                wf.ShowDialog();
        }
        
        public void Run()
        {

            foreach (RealizationSet realizationSet in realizationSets)
            {
                realizationSet.Run(new StatisticsForm.StatusBarChanger(wf, realizationSet.Scenes.Count));
                Thread.Sleep(1000);
            }

            wf.CloseThread();
        }

        private void plotMSDOrSupCoefButton_Click(object sender, EventArgs e)
        {
            writeInFileMSDButton.Enabled = true;
            if (statMode == SuperdiffusionStatisticsModes.Standart)
            {
                graph = new Graph(realizationSets[0].AverageDisplacementOnTime, pen);

                double k = GetSlope(0);
                List<Point2D> pointsLeastSquares = GetPointsForLinearGraph(realizationSets[0].AverageDisplacementOnTime[0], k, realizationSets[0].Scenes[0].DeltaTime, realizationSets[0].Scenes[0].FullTime);
                graphLeastSquares = new Graph(pointsLeastSquares, penLS);

                double kTheory = realizationSets[0].Scenes[0].CoefficientOfSuperdiffusionTheory(realizationSets[0].Scenes[0].FermiAccelerationTheory());
                List<Point2D> pointsTheory = GetPointsForLinearGraph(realizationSets[0].AverageDisplacementOnTime[0], kTheory, realizationSets[0].Scenes[0].DeltaTime, realizationSets[0].Scenes[0].FullTime);
                graphTheory = new Graph(pointsTheory, penTheory);
                graphsMSD = GetGraphs();
                
                GraphDrawer graphDrawer = new GraphDrawer(graphsMSD, msdOrSupCoefPictureBox);
                graphDrawer.DrawGraph();

                scTextBox.Text = Convert.ToString(k);
                scTheorTextBox.Text = Convert.ToString(kTheory);
            }
            if (statMode == SuperdiffusionStatisticsModes.DependenceOnVelocity || statMode == SuperdiffusionStatisticsModes.DependenceOnRadius)
            {
                graphSC = new Graph(GetPointsSuperdiffusionCoefficient(), pen);
                graphSCTheory = new Graph(GetPointsSuperdiffusionCoefficientTheory(), penTheory);
                //Graph graphFALeastSquares = 
                graphsSC = new List<Graph>();
                graphsSC.Add(graphSC);
                graphsSC.Add(graphSCTheory);
                GraphDrawer graphDrawer = new GraphDrawer(graphsSC, msdOrSupCoefPictureBox);
                graphDrawer.DrawGraph();
            }
        }

        private List<Point2D> GetPointsSuperdiffusionCoefficient()
        {
            List<Point2D> points = new List<Point2D>();
            foreach (RealizationSet realizationSet in realizationSets)
            {
                LeastSquares leastSquaresFA = new LeastSquares(realizationSet.AverageDisplacementOnTime);
                double kSC = leastSquaresFA.Slope(0);
                if (statMode == SuperdiffusionStatisticsModes.DependenceOnVelocity)
                    points.Add(new Point2D(realizationSet.Scenes[0].Scatterers[0].U0, kSC));
                if (statMode == SuperdiffusionStatisticsModes.DependenceOnRadius)
                    points.Add(new Point2D(realizationSet.Scenes[0].Scatterers[0].Radius0, kSC));
                //if (statMode == SuperdiffusionStatisticsModes.DependenceOnVelocity)
                //points.Add(new Point2D(realizationSet.Scenes[0].Scatterers[0].U0, kFA));
            }
            return points;
        }

        private List<Point2D> GetPointsSuperdiffusionCoefficientTheory()
        {
            List<Point2D> points = new List<Point2D>();
            foreach (RealizationSet realizationSet in realizationSets)
            {
                if (statMode == SuperdiffusionStatisticsModes.DependenceOnVelocity)
                    points.Add(new Point2D(realizationSet.Scenes[0].Scatterers[0].U0, realizationSet.Scenes[0].CoefficientOfSuperdiffusionTheory(realizationSet.Scenes[0].FermiAccelerationTheory())));
                if (statMode == SuperdiffusionStatisticsModes.DependenceOnRadius)
                    points.Add(new Point2D(realizationSet.Scenes[0].Scatterers[0].Radius0, realizationSet.Scenes[0].CoefficientOfSuperdiffusionTheory(realizationSet.Scenes[0].FermiAccelerationTheory())));
            }
            return points;
        }
       
    }
}
