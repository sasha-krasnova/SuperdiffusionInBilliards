using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        //private List<Graph> graphsAverVel, graphsMSD;
        //private Graph graph, graphLeastSquares, graphTheory;
        //private Pen pen = new Pen(Color.Black, 1);
        //private Pen penLS = new Pen(Color.Red, 1);
        //private Pen penTheory = new Pen(Color.Blue, 1);
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
                velOrFALabel.Text = "Зависимость ускорения Ферми от скорости рассеивателя";
                msdOrSupCoefLabel.Text = "Зависимость коэффициента супердиффузии от скорости рассеивателя";
                plotVelOrFAButton.Text = "Построить график";
                plotMSDOrSupCoefButton.Text = "Построить график";
                faTextBox.Enabled = false;
                faTheorTextBox.Enabled = false;
                msdTextBox.Enabled = false;
                msdTheorTextBox.Enabled = false;
            }
            else if (statMode == SuperdiffusionStatisticsModes.DependenceOnRadius)
            {
                velOrFALabel.Text = "Зависимость ускорения Ферми от среднего радиуса рассеивателя";
                msdOrSupCoefLabel.Text = "Зависимость коэффициента супердиффузии от среднего радиуса рассеивателя";
                plotVelOrFAButton.Text = "Построить график";
                plotMSDOrSupCoefButton.Text = "Построить график";
                faTextBox.Enabled = false;
                faTheorTextBox.Enabled = false;
                msdTextBox.Enabled = false;
                msdTheorTextBox.Enabled = false;
            }
            else if (statMode == SuperdiffusionStatisticsModes.DependenceOnPeriod)
            {
                velOrFALabel.Text = "Зависимость ускорения Ферми от периода осцилляций рассеивателя";
                msdOrSupCoefLabel.Text = "Зависимость коэффициента супердиффузии от периода осцилляций рассеивателя";
                plotVelOrFAButton.Text = "Построить график";
                plotMSDOrSupCoefButton.Text = "Построить график";
                faTextBox.Enabled = false;
                faTheorTextBox.Enabled = false;
                msdTextBox.Enabled = false;
                msdTheorTextBox.Enabled = false;
            }
        }

        private void plotVelOrFAButton_Click(object sender, EventArgs e)
        {

        }

       
    }
}
