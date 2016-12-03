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
    public partial class StatisticsForm : Form
    {
        private List<SceneBase> scenes;
        private RealizationSet realizationSet;
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

        private void drawVelocityOnTime_Click(object sender, EventArgs e)
        {
            realizationSet = new RealizationSet(scenes);
            WaitForm wf = new WaitForm();
            wf.Show();
            realizationSet.Run();
            Pen pen = new Pen(Color.Black, 1);
            Graph graph = new Graph(realizationSet.AverageVelocityOnTime, pen);
            List<Graph> graphs = new List<Graph>();
            graphs.Add((Graph)graph.Clone());
            GraphDrawer graphDrawer = new GraphDrawer(graphs, velOnTime);
            graphDrawer.DrawGraph(graph);
            wf.Close();
            
            /*Graphics g2 = velOnTime.CreateGraphics();
            Rectangle rect2 = new Rectangle(0, 0, velOnTime.Width / 2, velOnTime.Height / 2);
            g2.DrawEllipse(graph.Pen, rect2);
            g2.DrawLine(new Pen(Brushes.Red, 4), new Point(2, 2), new Point(10, 100));*/

            Graphics g = averVelOnTime.CreateGraphics();
            Rectangle rect = new Rectangle(0, 0, averVelOnTime.Width / 2, averVelOnTime.Height / 2);
            g.DrawEllipse(graph.Pen, rect);
            g.DrawLine(new Pen(Brushes.Red, 4), new Point(2, 2), new Point(10, 100));

            Graphics g1 = meanSqareDispOnTime.CreateGraphics();
            Rectangle rect1 = new Rectangle(0, 0, meanSqareDispOnTime.Width / 2, meanSqareDispOnTime.Height / 2);
            g1.DrawEllipse(graph.Pen, rect1);
            g1.DrawLine(new Pen(Brushes.Red, 4), new Point(2, 2), new Point(10, 100));

        }

    }
}
