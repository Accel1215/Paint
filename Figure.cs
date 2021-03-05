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
            pointOne.X = x1;
            pointOne.Y = y1;

            pointTwo.X = x2;
            pointTwo.Y = y2;

            this.lineSize = lineSize;
            this.lineColor = lineColor;
            this.solidColor = solidColor;
        }

        public abstract void Draw(Graphics g, Point offset);

        public abstract void DrawHash(Graphics g, Point offset);

        public abstract void Hide(Graphics g, Point offset);

        public void Normalization(ref Point pointOne, ref Point pointTwo)
        {
            if ((pointOne.X <= pointTwo.X) && (pointOne.Y >= pointTwo.Y))
            {
                int tmp;

                tmp = pointOne.Y;
                pointOne.Y = pointTwo.Y;
                pointTwo.Y = tmp;

            }
            else if ((pointOne.X >= pointTwo.X) && (pointOne.Y >= pointTwo.Y))
            {
                int tmp;

                tmp = pointOne.Y;
                pointOne.Y = pointTwo.Y;
                pointTwo.Y = tmp;

                tmp = pointOne.X;
                pointOne.X = pointTwo.X;
                pointTwo.X = tmp;

            }
            else if ((pointOne.X >= pointTwo.X) && (pointOne.Y <= pointTwo.Y))
            {
                int tmp;

                tmp = pointOne.X;
                pointOne.X = pointTwo.X;
                pointTwo.X = tmp;

            }
        }

        public void MouseMove(Graphics g, Point mousePosition, Point offset)
        {
            Hide(g, offset);

            pointTwo.X = mousePosition.X;
            pointTwo.Y = mousePosition.Y;

            DrawHash(g, offset);
        }
    }
}
