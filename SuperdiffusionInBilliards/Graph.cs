using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    public enum SuperdiffusionDrawingModes {Points, Polyline, PointsAndPolyline}
    class Graph
    {
        private Point2D min, max;
        private List<Point2D> points;
        private System.Drawing.Color color;
        private SuperdiffusionDrawingModes drawingMode = SuperdiffusionDrawingModes.Points;
        private bool render = true;

        public Graph(List<Point2D> points, System.Drawing.Color color)
        {
            this.color = color;
            this.points = points;

            GetMinMaxPoints();

        }

        private void GetMinMaxPoints()
        {
            min = new Point2D(points[0].X, points[0].Y);
            max = (Point2D)min.Clone();

            for (int i = 1; i < points.Count; i++)
            {
                if (points[i].X < min.X)
                    min.X = points[i].X;

                if (points[i].X > max.X)
                    max.X = points[i].X;

                if (points[i].Y < min.Y)
                    min.Y = points[i].Y;

                if (points[i].Y > max.Y)
                    max.Y = points[i].Y;
            }

        }

        public Point2D Min
        {
            get
            {
                return min;
            }
        }

        public Point2D Max
        {
            get
            {
                return max;
            }
        }

    }
}
