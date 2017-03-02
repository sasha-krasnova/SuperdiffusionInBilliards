using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Xml;

namespace SuperdiffusionInBilliards
{
    public enum SuperdiffusionStatisticsModes { Standart, DependenceOnVelocity, DependenceOnPeriod, DependenceOnRadius }
    public enum SuperdiffusionWriteToFileModes { Acceleration, Diffusion }

    public partial class StatisticForm : Form
    {
        public List<RealizationSet> realizationSets;
        public SuperdiffusionStatisticsModes statMode;
        private WaitForm wf;
        private List<Graph> graphsAcc, graphsDiff;
        private Graph graphAcc, graphLeastSquaresAcc, graphTheoryAcc;
        private Graph graphDiff, graphLeastSquaresDiff, graphTheoryDiff;
        private Pen pen = new Pen(Color.Black, 1);
        private Pen penLS = new Pen(Color.Red, 1);
        private Pen penTheory = new Pen(Color.Blue, 1);
        SuperdiffusionWriteToFileModes writeMode = SuperdiffusionWriteToFileModes.Acceleration;
            
        public StatisticForm()
        {
            InitializeComponent();
        }

        public StatisticForm(List<RealizationSet> realizationSets, SuperdiffusionStatisticsModes statMode)
            : this()
        {
            this.realizationSets = realizationSets;
            this.statMode = statMode;
            if (statMode != SuperdiffusionStatisticsModes.Standart)
            {
                SuperdiffusionStatisticsSettings settings = SuperdiffusionStatisticsSettings.SettingsByMode[statMode];
                velOrFALabel.Text = settings.Map["velOrFALabel"];
                msdOrSupCoefLabel.Text = settings.Map["msdOrSupCoefLabel"];
                plotVelOrFAButton.Text = settings.Map["plotVelOrFAButton"];
                plotMSDOrSupCoefButton.Text = settings.Map["plotMSDOrSupCoefButton"];
                faTextBox.Enabled = Boolean.Parse(settings.Map["faTextBox"]);
                faTheorTextBox.Enabled = Boolean.Parse(settings.Map["faTheorTextBox"]);
                scTextBox.Enabled = Boolean.Parse(settings.Map["scTextBox"]);
                scTheorTextBox.Enabled = Boolean.Parse(settings.Map["scTheorTextBox"]);
            }
        }

        private void plotVelOrFAButton_Click(object sender, EventArgs e)
        {
            writeInFileVelButton.Enabled = true;
            if (statMode == SuperdiffusionStatisticsModes.Standart)
            {
                graphAcc = new Graph(realizationSets[0].AverageVelocityOnTime, pen);

                double k = GetSlope(realizationSets[0].Scenes[0].InitVelocity, graphAcc);
                List<Point2D> pointsLeastSquares = GetPointsForLinearGraph(realizationSets[0].AverageVelocityOnTime[0], k, realizationSets[0].Scenes[0].DeltaTime, realizationSets[0].Scenes[0].FullTime);
                graphLeastSquaresAcc = new Graph(pointsLeastSquares, penLS);
                
                double kTheory = realizationSets[0].Scenes[0].FermiAccelerationTheory();
                List<Point2D> pointsTheory = GetPointsForLinearGraph(realizationSets[0].AverageVelocityOnTime[0], kTheory, realizationSets[0].Scenes[0].DeltaTime, realizationSets[0].Scenes[0].FullTime);
                graphTheoryAcc = new Graph(pointsTheory, penTheory);
                               
                faTextBox.Text = Convert.ToString(k);
                faTheorTextBox.Text = Convert.ToString(kTheory);

            }
            if (statMode == SuperdiffusionStatisticsModes.DependenceOnVelocity || statMode == SuperdiffusionStatisticsModes.DependenceOnRadius || statMode == SuperdiffusionStatisticsModes.DependenceOnPeriod)
            {
                graphAcc = new Graph(GetPointsFermiAcceleration(), pen);
                graphTheoryAcc = new Graph(GetPointsFermiAccelerationTheory(), penTheory);
            }
            graphsAcc = GetGraphsAcc();
            GraphDrawer graphDrawer = new GraphDrawer(graphsAcc, velOrFAPictureBox);
            graphDrawer.DrawGraph();
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
                if (statMode == SuperdiffusionStatisticsModes.DependenceOnPeriod)
                {
                    ScattererPeriodic scatterer = (ScattererPeriodic)realizationSet.Scenes[0].Scatterers[0].Clone();
                    points.Add(new Point2D((2 * Math.PI / scatterer.Frequency), kFA));
                }
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
                if (statMode == SuperdiffusionStatisticsModes.DependenceOnPeriod)
                {
                    ScattererPeriodic scatterer = (ScattererPeriodic)realizationSet.Scenes[0].Scatterers[0].Clone();
                    points.Add(new Point2D((2 * Math.PI / scatterer.Frequency), realizationSet.Scenes[0].FermiAccelerationTheory()));
                }
            }
            return points;
        }

        private List<Graph> GetGraphsAcc()
        {
            List<Graph> graphs = new List<Graph>();
            graphs.Add((Graph)graphAcc.Clone());
            graphs.Add((Graph)graphTheoryAcc.Clone());
            if (statMode == SuperdiffusionStatisticsModes.Standart)
                graphs.Add((Graph)graphLeastSquaresAcc.Clone());
            
            return graphs;
        }
        private List<Graph> GetGraphsDiff()
        {
            List<Graph> graphs = new List<Graph>();
            graphs.Add((Graph)graphDiff.Clone());
            graphs.Add((Graph)graphTheoryDiff.Clone());
            if (statMode == SuperdiffusionStatisticsModes.Standart)
                graphs.Add((Graph)graphLeastSquaresDiff.Clone());

            return graphs;
        }

        private List<Point2D> GetPointsForLinearGraph(Point2D initPoint, double slope, double deltaX, double fullX)
        {
            int numberOfPoints = Convert.ToInt32(fullX / deltaX)+1;
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

        private double GetSlope(double shift, Graph graph)
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
            int ind = 0;
            foreach (RealizationSet realizationSet in realizationSets)
            {
                if (statMode == SuperdiffusionStatisticsModes.Standart)
                    realizationSet.Run(new StatisticForm.StatusBarChanger(wf, realizationSet.Scenes.Count));
                else
                {
                    realizationSet.Run();
                    wf.ChangePercentThread(ind + 1, realizationSets.Count);
                }
                ind++;
            }
            Thread.Sleep(1000);
            wf.CloseThread();
        }

        private void plotMSDOrSupCoefButton_Click(object sender, EventArgs e)
        {
            writeInFileMSDButton.Enabled = true;
            if (statMode == SuperdiffusionStatisticsModes.Standart)
            {
                graphDiff = new Graph(realizationSets[0].AverageDisplacementOnTime, pen);

                double k = GetSlope(0, graphDiff);
                List<Point2D> pointsLeastSquares = GetPointsForLinearGraph(realizationSets[0].AverageDisplacementOnTime[0], k, realizationSets[0].Scenes[0].DeltaTime, realizationSets[0].Scenes[0].FullTime);
                graphLeastSquaresDiff = new Graph(pointsLeastSquares, penLS);

                double kTheory = realizationSets[0].Scenes[0].CoefficientOfSuperdiffusionTheory(realizationSets[0].Scenes[0].FermiAccelerationTheory());
                List<Point2D> pointsTheory = GetPointsForLinearGraph(realizationSets[0].AverageDisplacementOnTime[0], kTheory, realizationSets[0].Scenes[0].DeltaTime, realizationSets[0].Scenes[0].FullTime);
                graphTheoryDiff = new Graph(pointsTheory, penTheory);
                

                scTextBox.Text = Convert.ToString(k);
                scTheorTextBox.Text = Convert.ToString(kTheory);
            }
            if (statMode == SuperdiffusionStatisticsModes.DependenceOnVelocity || statMode == SuperdiffusionStatisticsModes.DependenceOnRadius || statMode == SuperdiffusionStatisticsModes.DependenceOnPeriod)
            {
                graphDiff = new Graph(GetPointsSuperdiffusionCoefficient(), pen);
                graphTheoryDiff = new Graph(GetPointsSuperdiffusionCoefficientTheory(), penTheory);
            }
            graphsDiff = GetGraphsDiff();
            GraphDrawer graphDrawer = new GraphDrawer(graphsDiff, msdOrSupCoefPictureBox);
            graphDrawer.DrawGraph();
        }

        /*private List<LineInFile> MakeDataForFile()
        {
            return null;
        }*/

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
                if (statMode == SuperdiffusionStatisticsModes.DependenceOnPeriod)
                {
                    ScattererPeriodic scatterer = (ScattererPeriodic)realizationSet.Scenes[0].Scatterers[0].Clone();
                    points.Add(new Point2D(2 * Math.PI / scatterer.Frequency, kSC));
                }
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
                if (statMode == SuperdiffusionStatisticsModes.DependenceOnPeriod)
                {
                    ScattererPeriodic scatterer = (ScattererPeriodic)realizationSet.Scenes[0].Scatterers[0].Clone();
                    points.Add(new Point2D(2 * Math.PI / scatterer.Frequency, realizationSet.Scenes[0].CoefficientOfSuperdiffusionTheory(realizationSet.Scenes[0].FermiAccelerationTheory())));
                }
            }
            return points;
        }

        private void WriteToFile()
        //private void WriteToFile(List<LineInFile> linesInFile)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    /*using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(fileName))

                        foreach (ICsvLine line in fileContent)
                        {
                            file.WriteLine(line.GetCSV());
                        }*/
                    List<Parameter> parameters = new List<Parameter>();
                    parameters = GetParametersForFile();

                    List<ICsvLine> fileContent = new List<ICsvLine>(parameters);
                    
                    TitlesInFile titles = new TitlesInFile(GetTitles());
                    fileContent.Add(titles);

                    List<LineInFile> data = new List<LineInFile>();

                    if (writeMode == SuperdiffusionWriteToFileModes.Acceleration)
                    {
                        data = GetDataForFile(graphsAcc);
                    }
                    else
                    {
                        data = GetDataForFile(graphsDiff);
                    }

                    fileContent.AddRange(data);

                    CsvFileWriter csvFileWriter = new CsvFileWriter(saveFileDialog1.FileName, fileContent);
                    
                    csvFileWriter.WriteToFile();
                    MessageBox.Show("Записано");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Произошла ошибка при записи в файл" + e);
                }
            }         
        }
        /*private void WriteParametersInFile(string fileName)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(fileName))
                //foreach (string line in parametersForFile)
                file.WriteLine();
        }*/

        private List<LineInFile> GetDataForFile(List<Graph> graphs)
        {
            List<LineInFile> data = new List<LineInFile>();
            
            //foreach (Point2D point in graphs[0].Points)
            for (int i = 0; i < graphs[0].Points.Count(); i++)
            {
                List<double> values = new List<double>();
                values.Add(graphs[0].Points[i].X);
                foreach (Graph graph in graphs)
                {
                    values.Add(graph.Points[i].Y);
                
                }
                LineInFile lineTemp = new LineInFile(values);
                data.Add(lineTemp);
            }

            return data;
        }


        private List<string> GetTitles()
        {
            List<string> titles = new List<string>();
            if (statMode == SuperdiffusionStatisticsModes.Standart)
            {
                titles.Add("Время");
                if (writeMode == SuperdiffusionWriteToFileModes.Acceleration)
                {
                    titles.Add("Скорость");
                    titles.Add("Скорость. Теория");
                    titles.Add("Скорость. МНК");
                }
                else
                {
                    titles.Add("Среднеквадратичное отклонение");
                    titles.Add("Среднеквадратичное отклонение. Теория");
                    titles.Add("Среднеквадратичное отклонение. МНК");
                }
            }
            if (statMode == SuperdiffusionStatisticsModes.DependenceOnVelocity)
            {
                titles.Add("Скорость рассеивателя");
                if (writeMode == SuperdiffusionWriteToFileModes.Acceleration)
                {
                    
                    titles.Add("Ускорение Ферми");
                    titles.Add("Ускорение Ферми. Теория");
                }
                else
                {
                    titles.Add("Коэффициент супердиффузии");
                    titles.Add("Коэффициент супердиффузии. Теория");
                }
            }
            if (statMode == SuperdiffusionStatisticsModes.DependenceOnRadius)
            {
                titles.Add("Средний радиус рассеивателя");
                if (writeMode == SuperdiffusionWriteToFileModes.Acceleration)
                {
                    titles.Add("Ускорение Ферми");
                    titles.Add("Ускорение Ферми. Теория");
                }
                else
                {
                    titles.Add("Коэффициент супердиффузии");
                    titles.Add("Коэффициент супердиффузии. Теория");
                }
            }
            if (statMode == SuperdiffusionStatisticsModes.DependenceOnPeriod)
            {
                titles.Add("Период осцилляций рассеивателя");
                if (writeMode == SuperdiffusionWriteToFileModes.Acceleration)
                {
                    titles.Add("Ускорение Ферми");
                    titles.Add("Ускорение Ферми. Теория");
                }
                else
                {
                    titles.Add("Коэффициент супердиффузии");
                    titles.Add("Коэффициент супердиффузии. Теория");
                }
            }
            //if (
            return titles;
        }

        private List<Parameter> GetParametersForFile()
        {
            List<Parameter> parameters = new List<Parameter>();

            Parameter initialVelocity = new Parameter("Начальная скорость частицы = ", realizationSets[0].Scenes[0].InitVelocity);
            parameters.Add(initialVelocity);

            if (!(statMode == SuperdiffusionStatisticsModes.DependenceOnVelocity))
            {
                Parameter amplitudeOfScattererVelocity = new Parameter("Амплитуда колебаний скорости рассеивателей = ", realizationSets[0].Scenes[0].Scatterers[0].U0);
                parameters.Add(amplitudeOfScattererVelocity);
            }

            if (!(statMode == SuperdiffusionStatisticsModes.DependenceOnPeriod))
            {
                ScattererPeriodic scatterer = (ScattererPeriodic)realizationSets[0].Scenes[0].Scatterers[0].Clone();
                Parameter periodOfScattererOsc = new Parameter("Период колебаний стенки рассеивателей (для периодических колебаний) = ", 2 * Math.PI / scatterer.Frequency);
                parameters.Add(periodOfScattererOsc);
            }

            if (!(statMode == SuperdiffusionStatisticsModes.DependenceOnRadius))
            {
                //ScattererPeriodic averageRadius = (ScattererPeriodic)realizationSets[0].Scenes[0].Scatterers[0].Clone();
                Parameter averageRadius = new Parameter("Средний радиус рассеивателей = ", realizationSets[0].Scenes[0].Scatterers[0].Radius0);
                parameters.Add(averageRadius);
            }
                        
            if (realizationSets[0].Scenes[0] is SceneSquareLattice)
            {
                SceneSquareLattice scene = (SceneSquareLattice)realizationSets[0].Scenes[0];
                Parameter averageRadiusOfCentralSc = new Parameter("Средний радиус центрального рассеивателя = ", scene.Scatterers[4].Radius0);
                parameters.Add(averageRadiusOfCentralSc);
            
                Parameter latticeSize = new Parameter("Размер решетки (для периодической решетки) = ", scene.LatticeSize);
                parameters.Add(latticeSize);
            }

            Parameter fullTime = new Parameter("Время эксперимента = ", realizationSets[0].Scenes[0].FullTime);
            parameters.Add(fullTime);

            Parameter deltaTime = new Parameter("Время между точками на графике (для зависимости от времени) = ", realizationSets[0].Scenes[0].DeltaTime);
            parameters.Add(deltaTime);

            Parameter numberOfRealisations = new Parameter("Количество реализаций = ", realizationSets[0].Scenes.Count);
            parameters.Add(numberOfRealisations);

            if (realizationSets[0].Scenes[0] is SceneRandom)
            {
                SceneRandom scene = (SceneRandom)realizationSets[0].Scenes[0];
                Parameter scattererConcentration = new Parameter("Средний радиус центрального рассеивателя = ", scene.ScattererConcentration);
                parameters.Add(scattererConcentration);
            }

            return parameters;
        }

        private void writeInFileVelButton_Click(object sender, EventArgs e)
        {
            WriteToFile();
        }

        private void writeInFileMSDButton_Click(object sender, EventArgs e)
        {
            writeMode = SuperdiffusionWriteToFileModes.Diffusion;
            WriteToFile();
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
                wf.ChangePercentThread(idxOfReal + 1, scenesCount);
            }
        }

    }
}
