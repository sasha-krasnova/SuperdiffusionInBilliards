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
            //staticticsStandart.Checked = true;
            //averageRadiusOfCentralSc.Enabled = false;
        }
        
        /// <summary>
        /// Делает доступными все TextBox
        /// </summary>
        private void MakeAllTextBoxesEnabled()
        {
            initialVelocity.Enabled = true;
            amplitudeOfScattererVelocity.Enabled = true;
            periodOfScattererOsc.Enabled = true;
            averageRadius.Enabled = true;
            averageRadiusOfCentralSc.Enabled = true;
            latticeSize.Enabled = true;
            fullTime.Enabled = true;
            deltaTime.Enabled = true;
            numberOfRealisations.Enabled = true;
            scattererConcentrationTextBox.Enabled = true;

            textBoxInitAmp.Enabled = true;
            textBoxStepAmp.Enabled = true;
            textBoxNumPointsAmp.Enabled = true;

            textBoxInitRadius.Enabled = true;
            textBoxStepRadius.Enabled = true;
            textBoxNumPointsRadius.Enabled = true;

            textBoxInitPeriod.Enabled = true;
            textBoxStepPeriod.Enabled = true;
            textBoxNumPointsPeriod.Enabled = true;

        }

        /// <summary>
        /// Создает образец рассеивателя в зависимости от того, какой тип рассеивателявыбран 
        /// </summary>
        /// <param name="amplitudeOfScattererVelocity">Амплитуда скорости рассеивателя</param>
        /// <param name="periodOfScattererOsc">Период колебаний рассеивателя</param>
        /// <param name="averageRadius">Средний радиус рассеивателя</param>
        /// <returns></returns>
        private Scatterer GetScattererSample(double amplitudeOfScattererVelocity, double periodOfScattererOsc, double averageRadius)
        {
            Scatterer scattererSample = null;

            //Если выбран гармонический рассеиватель
            if (harmonicScatterer.Checked)
            {
                scattererSample = new ScattererHarmonic(new Point2D(0, 0), averageRadius, amplitudeOfScattererVelocity , periodOfScattererOsc);
            }
            //Если выбран случайный рассеиватель
            else if (randomScatterer.Checked)
            {
                scattererSample = new ScattererRandom(new Point2D(0, 0), averageRadius, amplitudeOfScattererVelocity);
            }

            return scattererSample;
        }

        /// <summary>
        /// Создает сцену в зависимости от того, какой тип сцены выбран
        /// </summary>
        /// <param name="amplitudeOfScattererVelocity">Амплитуда скорости рассеивателя</param>
        /// <param name="periodOfScattererOsc">Период колебаний рассеивателя</param>
        /// <param name="averageRadius">Средний радиус рассеиватееля (не центрального из квадратной ячейки, а обычного)</param>
        /// <returns></returns>
        private SceneBase GetScene(double amplitudeOfScattererVelocity, double periodOfScattererOsc, double averageRadius)
        {
            SceneBase scene = null;
            Scatterer scattererSample = GetScattererSample(amplitudeOfScattererVelocity, periodOfScattererOsc, averageRadius);
            if (squareScene.Checked)
            {
                Scatterer centralScattererSample = GetScattererSample(amplitudeOfScattererVelocity, periodOfScattererOsc, Convert.ToDouble(averageRadiusOfCentralSc.Text));
                scene = new SceneSquareLattice(scattererSample, centralScattererSample, Convert.ToDouble(fullTime.Text), Convert.ToDouble(deltaTime.Text), Convert.ToDouble(initialVelocity.Text), Convert.ToDouble(latticeSize.Text));
            }
            
            if (randomScene.Checked)
            {
                scene = new SceneRandom(scattererSample, Convert.ToDouble(fullTime.Text), Convert.ToDouble(deltaTime.Text), Convert.ToDouble(initialVelocity.Text), Convert.ToDouble(latticeSize.Text), Convert.ToDouble(scattererConcentrationTextBox.Text));
            }

            return scene;
        }
        /// <summary>
        /// Запускает одну реализацию с графикой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startWithGraphics_Click_1(object sender, EventArgs e)
        {

            SceneBase scene = GetScene(Convert.ToDouble(amplitudeOfScattererVelocity.Text), Convert.ToDouble(periodOfScattererOsc.Text), Convert.ToDouble(averageRadius.Text));

            //WaitForm wf = new WaitForm();
            //wf.Show();
            scene.StatMode = SuperdiffusionRunModes.Detail;
            scene.Run();
            //wf.Close();
            DrawingForm df = new DrawingForm(scene.Statistics, new Point2D(Convert.ToDouble(latticeSize.Text), Convert.ToDouble(latticeSize.Text)));
            df.Show();
        }

        private void randomScene_CheckedChanged(object sender, EventArgs e)
        {
            averageRadiusOfCentralSc.Enabled = false;
            scattererConcentrationTextBox.Enabled = true;
        }

        private void squareScene_CheckedChanged(object sender, EventArgs e)
        {
            averageRadiusOfCentralSc.Enabled = true;
            scattererConcentrationTextBox.Enabled = false;
        }

        private void triangularScene_CheckedChanged(object sender, EventArgs e)
        {
            averageRadiusOfCentralSc.Enabled = false;
        }

        /*private void randomScene_Click(object sender, EventArgs e)
        {
        }*/

        /// <summary>
        /// Запускает расчет статистики. 
        /// Стандартная - зависимость скорости частицы и среднеквадратичного отклонения от времени.
        /// Зависимость от скорости рассеивателя - зависимость ускорения Ферми и коэффициента супердиффузии от амплитуды скорости рассеивателя
        /// Зависимость от радиуса рассеивателя - зависимость ускорения Ферми и коэффициента супердиффузии от радиуса рассеивателей
        /// Зависимость от периода колебаний - зависимость ускорения Ферми и коэффициента супердиффузии от периода колебаний рассеивателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statistics_Click(object sender, EventArgs e)
        {
            if (staticticsStandart.Checked)
            {
                List<SceneBase> scenes = new List<SceneBase>();
                
                for (int i = 0; i < Convert.ToInt64(numberOfRealisations.Text); i++)
                {

                    scenes.Add(GetScene(Convert.ToDouble(amplitudeOfScattererVelocity.Text), Convert.ToDouble(periodOfScattererOsc.Text), Convert.ToDouble(averageRadius.Text)));
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

            if (statisticsOnScatRadius.Checked)
            {
                List<RealizationSet> realizationSets = new List<RealizationSet>();
                double averageRadius;
                for (int i = 0; i < Convert.ToInt32(textBoxNumPointsRadius.Text); i++)
                {
                    averageRadius = Convert.ToDouble(textBoxInitRadius.Text) + i * Convert.ToDouble(textBoxStepRadius.Text);
                    RealizationSet realizationSetTemp = new RealizationSet(GetScenes(averageRadius));
                    realizationSets.Add(realizationSetTemp);
                    //List<SceneBase> scenes = new List<SceneBase>();
                }
                //StatisticsOnScatVelForm sAmpF = new StatisticsOnScatVelForm(realizationSets, Convert.ToDouble(initialVelocity.Text));
                //sAmpF.Show();
            }
        }

        private List<SceneBase> GetScenes(double ampOfScVel)
        {
            List<SceneBase> scenes = new List<SceneBase>();
            for (int i = 0; i < Convert.ToInt64(numberOfRealisations.Text); i++)
            {
                scenes.Add(GetScene(ampOfScVel, Convert.ToDouble(periodOfScattererOsc.Text), Convert.ToDouble(averageRadius.Text)));
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
            MakeAllTextBoxesEnabled();

            amplitudeOfScattererVelocity.Enabled = false;
            
            textBoxInitRadius.Enabled = false;
            textBoxStepRadius.Enabled = false;
            textBoxNumPointsRadius.Enabled = false;

            textBoxInitPeriod.Enabled = false;
            textBoxStepPeriod.Enabled = false;
            textBoxNumPointsPeriod.Enabled = false;
        }

        private void statisticsOnScatRadius_CheckedChanged(object sender, EventArgs e)
        {
            MakeAllTextBoxesEnabled();
            
            averageRadius.Enabled = false;
            
            textBoxInitAmp.Enabled = false;
            textBoxStepAmp.Enabled = false;
            textBoxNumPointsAmp.Enabled = false;

            textBoxInitPeriod.Enabled = false;
            textBoxStepPeriod.Enabled = false;
            textBoxNumPointsPeriod.Enabled = false;

         }

        private void statisticsOnPeriod_CheckedChanged(object sender, EventArgs e)
        {
            MakeAllTextBoxesEnabled();

            periodOfScattererOsc.Enabled = false;
            
            textBoxInitAmp.Enabled = false;
            textBoxStepAmp.Enabled = false;
            textBoxNumPointsAmp.Enabled = false;

            textBoxInitRadius.Enabled = false;
            textBoxStepRadius.Enabled = false;
            textBoxNumPointsRadius.Enabled = false;
        }

        private void staticticsStandart_CheckedChanged(object sender, EventArgs e)
        {
            MakeAllTextBoxesEnabled();
            
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

        private void button2_Click(object sender, EventArgs e)
        {
            ScattererHarmonic scattererSample = new ScattererHarmonic(new Point2D(0, 0), Convert.ToDouble(averageRadius.Text), Convert.ToDouble(amplitudeOfScattererVelocity.Text), Convert.ToDouble(periodOfScattererOsc.Text));
            RandomScattererSet rndmScattererSet = new RandomScattererSet(scattererSample, 0.0001);
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

        /*private void startWithGraphics_Click_1(object sender, EventArgs e)
        {

        }*/

        /*private void randomScene_CheckedChanged_1(object sender, EventArgs e)
        {
            averageRadiusOfCentralSc.Enabled = false;
        }*/
    }
}
