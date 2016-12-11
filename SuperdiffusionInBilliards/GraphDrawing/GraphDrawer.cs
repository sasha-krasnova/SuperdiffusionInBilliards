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

            CalculateMinMaxPoints();

        }

        private void CalculateMinMaxPoints()
        {
            min = (Point2D)graphs[0].Min.Clone();
            max = (Point2D)graphs[0].Max.Clone();

            for (int i = 1; i < graphs.Count; i++)
            {
                if (min.X > graphs[i].Min.X)
                    min.X = graphs[i].Min.X;

                if (min.Y > graphs[i].Min.Y)
                    min.Y = graphs[i].Min.Y;

                if (max.X < graphs[i].Max.X)
                    max.X = graphs[i].Max.X;

                if (max.Y < graphs[i].Max.Y)
                    max.Y = graphs[i].Max.Y;
            }
        }

        private void DrawGrid()
        {

        }

        public void DrawGraph()
        {
            Point2D graphSize = new Point2D(max.X - min.X, max.Y - min.Y);
            Point2D pictureSize = new Point2D(pictureBox.Width, pictureBox.Height);

            Graphics g = pictureBox.CreateGraphics();
            foreach (Graph graph in graphs)
            {
                
                Point2D point1 = DrawingHelper.ConvertCoordinate(pictureSize, graphSize, new Point2D(graph.Points[0].X - min.X, graph.Points[0].Y - min.Y));
                //Point pt1 = point1.ConvertToPoint(); 
                Point pt1 = new Point(Convert.ToInt32(point1.X), Convert.ToInt32(pictureSize.Y - point1.Y));
                if (graph.DrawingMode == SuperdiffusionDrawingModes.Points)
                    //g.FillRectangle(Brushes.Black, pt1.X-1, pt1.Y-1, 3, 3);
                    g.DrawEllipse(graph.Pen, pt1.X-1, pt1.Y-1, 3, 3);

                for (int i = 1; i < (graph.Points.Count); i++)
                {
                    
                    Point2D point2 = DrawingHelper.ConvertCoordinate(pictureSize, graphSize, new Point2D(graph.Points[i].X - min.X, graph.Points[i].Y - min.Y));
                    Point pt2 = new Point(Convert.ToInt32(point2.X), Convert.ToInt32(pictureSize.Y - point2.Y));

                    if (graph.DrawingMode == SuperdiffusionDrawingModes.Polyline)
                        g.DrawLine(graph.Pen, pt1, pt2);
                    else if (graph.DrawingMode == SuperdiffusionDrawingModes.Points)
                        //g.FillRectangle(Brushes.Black, pt2.X-1, pt2.Y-1, 3, 3);
                        g.DrawEllipse(graph.Pen, pt2.X-1, pt2.Y-1, 3, 3);

                    pt1 = pt2;
                }
            }
            
        }
    }
}
