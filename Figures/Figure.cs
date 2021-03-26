using Paint.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public enum FigureType
    {
        Line = 0,
        Curve = 1,
        Rectangle = 2,
        Ellipse = 3,
        Text = 4
    }

    public enum StatusCheck
    {
        NotChecked = 0,
        Good = 1,
        Bad = 2
    }

    [Serializable()]
    abstract public class Figure
    {
        protected Point pointOne;
        protected Point pointTwo;

        protected Color lineColor;
        protected int lineSize;

        public StatusCheck falidateStatus = StatusCheck.NotChecked;

        public Figure(Point pointOne, Point pointTwo, Point offset, int lineSize, Color lineColor)
        {
            this.pointOne.X = pointOne.X - offset.X;
            this.pointOne.Y = pointOne.Y - offset.Y;
            this.pointTwo.X = pointTwo.X - offset.X;
            this.pointTwo.Y = pointTwo.Y - offset.Y;

            this.lineSize = lineSize;
            this.lineColor = lineColor;
        }

        public Figure(int x1, int y1, int x2, int y2, int lineSize, Color lineColor)
        {
            pointOne.X = x1;
            pointOne.Y = y1;

            pointTwo.X = x2;
            pointTwo.Y = y2;

            this.lineSize = lineSize;
            this.lineColor = lineColor;
        }

        public abstract void Draw(Graphics g, Point offset);

        public abstract void Hide(Graphics g, Point offset);

        public abstract void FinishDraw(Graphics g, Point offset);

        public abstract void Falidate();

        public virtual void MouseMove(Graphics g, Point mousePosition, Point offset)
        {
            pointTwo.X = mousePosition.X - offset.X;
            pointTwo.Y = mousePosition.Y - offset.Y;
        }

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

    }
}
