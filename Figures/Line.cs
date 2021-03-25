using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint.Figures
{
    [Serializable()]
    class Line : Figure
    {
        public Line(Point pointOne, Point pointTwo, int lineSize, Color lineColor) :
            base(pointOne, pointTwo, lineSize, lineColor)
        { }

        public Line(int x1, int y1, int x2, int y2, int lineSize, Color lineColor) :
            base(x1, y1, x2, y2, lineSize, lineColor)
        { }

        public override void Draw(Graphics g, Point offset)
        {
            Pen pen = new Pen(lineColor, lineSize);

            Point pointOneOffset = new Point(pointOne.X + offset.X, pointOne.Y + offset.Y);
            Point pointTwoOffset = new Point(pointTwo.X + offset.X, pointTwo.Y + offset.Y);

            g.DrawLine(pen, pointOneOffset, pointTwoOffset);

            pen.Dispose();
        }

        public override void Hide(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.White, lineSize);

            Point pointOneOffset = new Point(pointOne.X + offset.X, pointOne.Y + offset.Y);
            Point pointTwoOffset = new Point(pointTwo.X + offset.X, pointTwo.Y + offset.Y);

            g.DrawLine(pen, pointOneOffset, pointTwoOffset);

            pen.Dispose();
        }

        public override void FinishDraw(Graphics g, Point offset)
        {
            Falidate();
        }

        public override void Falidate()
        {
            if (pointOne == pointTwo)
            {
                falidateStatus = StatusCheck.Bad;
            }
            else
            {
                falidateStatus = StatusCheck.Good;
            }
        }
    }
}
