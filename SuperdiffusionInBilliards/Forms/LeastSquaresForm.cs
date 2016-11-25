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
    public partial class LeastSquaresForm : Form
    {
        public LeastSquaresForm()
        {
            InitializeComponent();
            //slopeText.Text = "lflflf";
        }

        private void calculateLeastSquares_Click(object sender, EventArgs e)
        {
            List<Point2D> pointsForApprox = new List<Point2D>();
            Point2D tempPoint = new Point2D(0, 11);
            pointsForApprox.Add((Point2D)tempPoint.Clone());
            //Point2D point1 = new Point2D();
            //point1 = point;
            //Point2D pointNew = (Point2D)point.Clone();
                    
            for (int i = 0; i <= 10; i++)
            {
                tempPoint.X += 1;
                tempPoint.Y += 5540;

                pointsForApprox.Add((Point2D)tempPoint.Clone());               
            }

            LeastSquares mnk = new LeastSquares(pointsForApprox);
            Line lineMNK = mnk.ShiftAndSlope();
            string slopeString = Convert.ToString(lineMNK.A);
            string shiftString = Convert.ToString(lineMNK.C);
            slopeText.Text = slopeString;
            shiftText.Text = shiftString;
            //MessageBox.Show(coefficients.ToString());

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
