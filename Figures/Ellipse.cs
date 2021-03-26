using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint.Figures
{
    [Serializable()]
    class Ellipse : Figure
    {
        private Color solidColor;


        public Ellipse(Point pointOne, Point pointTwo, Point offset, int lineSize, Color lineColor, Color fillColor) :
            base(pointOne, pointTwo, offset, lineSize, lineColor)
        {
            solidColor = fillColor;
        }

        public Ellipse(int x1, int y1, int x2, int y2, int lineSize, Color lineColor, Color fillColor) :
            base(x1, y1, x2, y2, lineSize, lineColor)
        {
            solidColor = fillColor;
        }

        public override void Draw(Graphics g, Point offset)
        {
            Pen pen = new Pen(lineColor, lineSize);

            SolidBrush solidBrush = new SolidBrush(solidColor);

            Point normalPointOne = new Point(pointOne.X + offset.X, pointOne.Y + offset.Y);
            Point normalPointTwo = new Point(pointTwo.X + offset.X, pointTwo.Y + offset.Y);

            Normalization(ref normalPointOne, ref normalPointTwo);

            System.Drawing.Rectangle rectangle =
                System.Drawing.Rectangle.FromLTRB(normalPointOne.X, normalPointOne.Y, normalPointTwo.X, normalPointTwo.Y);

            g.FillEllipse(solidBrush, rectangle);
            g.DrawEllipse(pen, rectangle);

            pen.Dispose();
            solidBrush.Dispose();
        }

        public override void Hide(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.White, lineSize);

            SolidBrush solidBrush = new SolidBrush(Color.White);

            Point normalPointOne = new Point(pointOne.X + offset.X, pointOne.Y + offset.Y);
            Point normalPointTwo = new Point(pointTwo.X + offset.X, pointTwo.Y + offset.Y);

            Normalization(ref normalPointOne, ref normalPointTwo);

            System.Drawing.Rectangle rectangle =
                System.Drawing.Rectangle.FromLTRB(normalPointOne.X, normalPointOne.Y, normalPointTwo.X, normalPointTwo.Y);

            g.FillEllipse(solidBrush, rectangle);
            g.DrawEllipse(pen, rectangle);

            pen.Dispose();
            solidBrush.Dispose();
        }

        public override void FinishDraw(Graphics g, Point offset)
        {
            Falidate();
        }

        public override void Falidate()
        {
            if(pointOne == pointTwo)
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
