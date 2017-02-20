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
        public SuperdiffusionStatisticsModes statMode;
        public StatisticForm()
        {
            InitializeComponent();
            statMode = SuperdiffusionStatisticsModes.Standart;
            if (statMode == SuperdiffusionStatisticsModes.Standart)
                VelOrFALabel.Text = "Зависимость средней скорости частицы от времени";
        }

        public StatisticForm(List<RealizationSet> realizationSets, SuperdiffusionStatisticsModes statMode)
            : this()
        {
            this.realizationSets = realizationSets;
        }
    }
}
