using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SuperdiffusionInBilliards
{
    public enum SuperdiffusionDrawingModes {Points, Polyline, PointsAndPolyline}
    class Graph
    {
        private Point2D min, max;
        private List<Point2D> points;
        //private System.Drawing.Color color;
        private System.Drawing.Pen pen;
        private SuperdiffusionDrawingModes drawingMode = SuperdiffusionDrawingModes.Polyline;
        private bool render = true;

        public Graph(List<Point2D> points, System.Drawing.Pen pen, SuperdiffusionDrawingModes drawingMode, bool render)
            : this(points, pen, drawingMode)
        {
            this.render = render;
        }

        public Graph(List<Point2D> points, System.Drawing.Pen pen, SuperdiffusionDrawingModes drawingMode) : this(points, pen)
        {
            this.drawingMode = drawingMode;
        }

        public Graph(List<Point2D> points, System.Drawing.Pen pen)
        {
            this.pen = pen;
            this.points = points;

            CalculateMinMaxPoints();

        }

        private void CalculateMinMaxPoints()
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

        public bool Render
        {
            get
            {
                return render;
            }
        }

        public SuperdiffusionDrawingModes DrawingMode
        {
            get
            {
                return drawingMode;
            }
        }

        public List<Point2D> Points
        {
            get
            {
                return points;
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

        public System.Drawing.Pen Pen
        {
            get
            {
                return pen;
            }
        }

        public object Clone()
        {
            return new Graph(points, (Pen)pen.Clone(),drawingMode, render);

        }

    }
}
