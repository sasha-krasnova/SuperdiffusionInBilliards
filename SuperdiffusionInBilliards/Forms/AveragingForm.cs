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
    public partial class AveragingForm : Form
    {
        public AveragingForm()
        {
            InitializeComponent();
        }

        private void average_Click(object sender, EventArgs e)
        {
            List<double> values = new List<double>();
            values.Add(1);
            values.Add(3);
            //values.Add(2);
            //values.Add(3);
            //values.Add(2);
            //values.Add(1);
            //values.Add(5);
            double averageValue = Averaging.Average(values);
            double dispersion = Averaging.Dispersion(values);
            averageValueTextBox.Text = Convert.ToString(averageValue);
            dispersionTextBox.Text = Convert.ToString(dispersion);
        }
    }
}
