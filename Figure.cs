using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    [Serializable()]
    abstract class Figure
    {
        protected Point pointOne = new Point(0, 0);
        protected Point pointTwo = new Point(0, 0);

        protected Color solidColor;
        protected Color lineColor;
        protected int lineSize;

        public Figure(Point pointOne, Point pointTwo, int lineSize, Color lineColor, Color solidColor)
        {
            this.pointOne = pointOne;
            this.pointTwo = pointTwo;

            this.lineSize = lineSize;
            this.lineColor = lineColor;
            this.solidColor = solidColor;
        }

        public Figure(int x1, int y1, int x2, int y2, int lineSize, Color lineColor, Color solidColor)
        {
            pointOne.x = x1;
            pointOne.y = y1;

            pointTwo.x = x2;
            pointTwo.y = y2;

            this.lineSize = lineSize;
            this.lineColor = lineColor;
            this.solidColor = solidColor;
        }

        public abstract void Draw(Graphics g);

        public abstract void DrawHash(Graphics g);

        public abstract void Hide(Graphics g);

        public void Normalization(ref Point pointOne, ref Point pointTwo)
        {
            if ((pointOne.x <= pointTwo.x) && (pointOne.y >= pointTwo.y))
            {
                int tmp;

                tmp = pointOne.y;
                pointOne.y = pointTwo.y;
                pointTwo.y = tmp;

            }
            else if ((pointOne.x >= pointTwo.x) && (pointOne.y >= pointTwo.y))
            {
                int tmp;

                tmp = pointOne.y;
                pointOne.y = pointTwo.y;
                pointTwo.y = tmp;

                tmp = pointOne.x;
                pointOne.x = pointTwo.x;
                pointTwo.x = tmp;

            }
            else if ((pointOne.x >= pointTwo.x) && (pointOne.y <= pointTwo.y))
            {
                int tmp;

                tmp = pointOne.x;
                pointOne.x = pointTwo.x;
                pointTwo.x = tmp;

            }
        }

        public void MouseMove(Graphics g, Point mousePosition)
        {
            Hide(g);

            pointTwo.x = mousePosition.x;
            pointTwo.y = mousePosition.y;

            DrawHash(g);
        }
    }

    [Serializable()]
    class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

}
