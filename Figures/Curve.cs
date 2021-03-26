using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint.Figures
{
    [Serializable()]
    class Curve : Figure
    {
        private List<Point> points;

        public List<Point> Points => points;


        public Curve(Point pointOne, Point pointTwo, Point offset, int lineSize, Color lineColor) :
            base(pointOne, pointTwo, offset, lineSize, lineColor)
        {
            points = new List<Point>();

            points.Add(new Point(pointOne.X - offset.X, pointOne.Y - offset.Y));
            points.Add(new Point(pointTwo.X - offset.X, pointTwo.Y - offset.Y));
        }

        public Curve(int x1, int y1, int x2, int y2, int lineSize, Color lineColor) :
            base(x1, y1, x2, y2, lineSize, lineColor)
        {
            points = new List<Point>();
            points.Add(new Point(x1, y1));
            points.Add(new Point(x2, y2));
        }

        public override void Draw(Graphics g, Point offset)
        {
            Pen pen = new Pen(lineColor, lineSize);

            Point[] p = points.ToArray();

            for (int i = 0; i < p.Count(); ++i)
            {
                p[i].X += offset.X;
                p[i].Y += offset.Y;
            }

            g.DrawCurve(pen, p);

            pen.Dispose();
        }

        public override void Hide(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.White, lineSize);

            Point[] p = points.ToArray();

            for (int i = 0; i < p.Count(); ++i)
            {
                p[i].X += offset.X;
                p[i].Y += offset.Y;
            }

            g.DrawCurve(pen, p);

            pen.Dispose();
        }

        public override void FinishDraw(Graphics g, Point offset)
        {
            Falidate();
        }

        public override void Falidate()
        {
            if (points.Count() == 2)
            {
                falidateStatus = StatusCheck.Bad;
            }
            else
            {
                falidateStatus = StatusCheck.Good;
            }
        }

        public override void MouseMove(Graphics g, Point mousePosition, Point offset)
        {
            pointTwo.X = mousePosition.X - offset.X;
            pointTwo.Y = mousePosition.Y - offset.Y;

            points.Add(pointTwo);
        }
    }
}
