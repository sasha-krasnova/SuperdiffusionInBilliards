using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SuperdiffusionInBilliards
{
    static class DrawingHelper
    {
        static public Point2D ConvertCoordinate (Point2D pictureSize, Point2D latticeSize, Point2D pointForDrawing)
        {
            Point2D coefficient = new Point2D(pictureSize.X / latticeSize.X, pictureSize.Y / latticeSize.Y);

            return new Point2D(pointForDrawing.X * coefficient.X, pointForDrawing.Y * coefficient.Y);
        }
    }
}
