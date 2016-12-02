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
    public partial class DrawingForm : Form
    {
        private List<StateOfParticle> statistics;
        private int statIdx;
        private Graphics gr;
        private Pen p;
        private Point2D latticeSize;

        public DrawingForm()
        {
            InitializeComponent();
            gr = pictureBox1.CreateGraphics();
            p = new Pen(Color.Black);
            statIdx = 0;
        }

        public DrawingForm(List<StateOfParticle> statistics, Point2D latticeSize) : this()
        {
            this.latticeSize = latticeSize;
            this.statistics = statistics;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            /*Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, new Point(20, 20), new Point(40, 40));*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (statIdx >= statistics.Count)
            {
                timer1.Enabled = false;
                MessageBox.Show("the end");
                return;
            }
            Point2D pictureSize = new Point2D(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = SuperdiffusionInBilliards.Properties.Resources.clear;
            gr = Graphics.FromImage(pictureBox1.Image);
            //Вытираем


            StateOfParticleDetailed stat = (StateOfParticleDetailed)statistics[statIdx];

            //1)рисуем круги
            foreach (Circle circle in stat.Circles)
            {
                Point2D leftTop = DrawingHelper.ConvertCoordinate(pictureSize, latticeSize, new Point2D((circle.Center.X - circle.Radius), (circle.Center.Y - circle.Radius)));
                Point2D semiaxis = DrawingHelper.ConvertCoordinate(pictureSize, latticeSize, new Point2D((2 * circle.Radius), (2 * circle.Radius)));
                gr.DrawEllipse(p, (float)leftTop.X, (float)leftTop.Y, (float)semiaxis.X, (float)semiaxis.Y);
            }



            //2)рисуем точку
            Point2D particle = DrawingHelper.ConvertCoordinate(pictureSize, latticeSize, stat.Particle.Coordinate);
            gr.DrawEllipse(p, (float)particle.X - 2, (float)particle.Y - 2, 4, 4);
            statIdx++;
            pictureBox1.Refresh();
         
        }

        private void DrawingForm_Load(object sender, EventArgs e)
        {

        }

 
    }
}
