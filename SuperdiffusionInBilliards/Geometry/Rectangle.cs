using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    public class Rectangle
    {
        private Point2D leftTop;
        private Point2D size;

        public Rectangle(Point2D leftTop, Point2D size)
        {
            this.leftTop = leftTop;
            this.size = size;
        }

        public Point2D LeftTop
        {
            get
            {
                return leftTop;
            }
        }

        public Point2D RightBottom
        {
            get
            {
                return new Point2D(leftTop.X + size.X, leftTop.Y  + size.Y);
            }
        }

        public Point2D Size
        {
            get
            {
                return size;
            }
        }
    }
}
