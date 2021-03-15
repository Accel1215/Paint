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
        public List<Point> points;

        public Curve(Point pointOne, Point pointTwo, int lineSize, Color lineColor) :
            base(pointOne, pointTwo, lineSize, lineColor)
        {
            points = new List<Point>();
            points.Add(pointOne);
            points.Add(pointTwo);
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

            for(int i = 0; i < points.Count(); ++i)
            {
                points[i].Offset(offset);
            }

            g.DrawCurve(pen, points.ToArray());

            pen.Dispose();
        }

        public override void DrawHash(Graphics g, Point offset)
        {
            Pen pen = new Pen(lineColor, lineSize)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            };

            for (int i = 0; i < points.Count(); ++i)
            {
                points[i].Offset(offset);
            }

            g.DrawCurve(pen, points.ToArray());
            points.Add(pointTwo);

            pen.Dispose();
        }

        public override void Hide(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.White, lineSize);

            for (int i = 0; i < points.Count(); ++i)
            {
                points[i].Offset(offset);
            }

            g.DrawCurve(pen, points.ToArray());

            pen.Dispose();
        }
    }
}
