using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SuperdiffusionInBilliards
{
    class GraphDrawer
    {
        Point2D min, max;
        private System.Windows.Forms.PictureBox pictureBox;
        List<Graph> graphs;

        public GraphDrawer(List<Graph> graphs, System.Windows.Forms.PictureBox pictureBox)
        {
            this.graphs = graphs;
            this.pictureBox = pictureBox;

            GetMinMaxPoints();

        }

        private void GetMinMaxPoints()
        {
            min = (Point2D)graphs[0].Min.Clone();
            max = (Point2D)graphs[0].Max.Clone();

            for (int i = 1; i < graphs.Count; i++)
            {
                if (min.X > graphs[i].Min.X)
                    min.X = graphs[i].Min.X;

                if (min.Y > graphs[i].Min.Y)
                    min.Y = graphs[i].Min.Y;

                if (max.X > graphs[i].Max.X)
                    max.X = graphs[i].Max.X;

                if (max.Y > graphs[i].Max.Y)
                    max.Y = graphs[i].Max.Y;
            }
        }

        private void DrawGrid()
        {

        }

        public void DrawGraph(Graph graph)
        {
            Point2D graphSize = new Point2D(max.X - min.X, max.Y - min.Y);
            Point2D pictureSize = new Point2D(pictureBox.Width, pictureBox.Height);

            Graphics g = pictureBox.CreateGraphics();

            for (int i = 1; i < (graph.Points.Count); i++)
            {
                Point2D point1 = DrawingHelper.ConvertCoordinate(pictureSize, graphSize, new Point2D (graph.Points[i-1].X-min.X, graph.Points[i-1].Y-min.Y));
                Point2D point2 = DrawingHelper.ConvertCoordinate(pictureSize, graphSize, new Point2D(graph.Points[i].X - min.X, graph.Points[i].Y - min.Y));

                Point pt1 = new Point(Convert.ToInt32(point1.X), Convert.ToInt32(pictureSize.Y - point1.Y));
                Point pt2 = new Point(Convert.ToInt32(point2.X), Convert.ToInt32(pictureSize.Y - point2.Y));

                //g.DrawLine(graph.Pen, pt1, pt2);
                g.DrawLine(graph.Pen, pt1, pt2);

                //System.Drawing.DrawLine(graph.Pen, point1, point2);
                //System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(`.Image);
                //gr.DrawLine(graph.Pen, pt1, pt2);
            }
            
        }
    }
}
