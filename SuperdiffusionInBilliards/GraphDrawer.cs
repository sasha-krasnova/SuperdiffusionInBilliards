using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
