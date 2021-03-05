using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Figures
{
    [Serializable()]
    class Rectangle : Figure
    {
        public Rectangle(Point pointOne, Point pointTwo, int lineSize, Color lineColor, Color fillColor) : 
            base(pointOne, pointTwo, lineSize, lineColor, fillColor) { }

        public Rectangle(int x1, int y1, int x2, int y2, int lineSize, Color lineColor, Color fillColor) : 
            base(x1, y1, x2, y2, lineSize, lineColor, fillColor) { }

        public override void Draw(Graphics g, System.Drawing.Point offset)
        {
            Pen pen = new Pen(lineColor, lineSize);

            SolidBrush solidBrush = new SolidBrush(solidColor);

            Point normPointOne = new Point(pointOne.x + offset.X, pointOne.y + offset.Y);
            Point normPointTwo = new Point(pointTwo.x + offset.X, pointTwo.y + offset.Y);

            Normalization(ref normPointOne, ref normPointTwo);

            System.Drawing.Rectangle rectangle = 
                System.Drawing.Rectangle.FromLTRB(normPointOne.x, normPointOne.y, normPointTwo.x, normPointTwo.y);

            g.FillRectangle(solidBrush, rectangle);
            g.DrawRectangle(pen, rectangle);

            pen.Dispose();
            solidBrush.Dispose();
        }

        public override void DrawHash(Graphics g, System.Drawing.Point offset)
        {
            Pen pen = new Pen(lineColor, lineSize)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            };

            Point normPointOne = new Point(pointOne.x + offset.X, pointOne.y + offset.Y);
            Point normPointTwo = new Point(pointTwo.x + offset.X, pointTwo.y + offset.Y);

            Normalization(ref normPointOne, ref normPointTwo);

            System.Drawing.Rectangle rectangle = 
                System.Drawing.Rectangle.FromLTRB(normPointOne.x, normPointOne.y, normPointTwo.x, normPointTwo.y);

            g.DrawRectangle(pen, rectangle);

            pen.Dispose();
        }

        public override void Hide(Graphics g, System.Drawing.Point offset)
        {
            Pen pen = new Pen(Color.White, lineSize);

            SolidBrush solidBrush = new SolidBrush(Color.White);

            Point normPointOne = new Point(pointOne.x + offset.X, pointOne.y + offset.Y);
            Point normPointTwo = new Point(pointTwo.x + offset.X, pointTwo.y + offset.Y);

            Normalization(ref normPointOne, ref normPointTwo);

            System.Drawing.Rectangle rectangle = 
                System.Drawing.Rectangle.FromLTRB(normPointOne.x, normPointOne.y, normPointTwo.x, normPointTwo.y);

            g.FillRectangle(solidBrush, rectangle);
            g.DrawRectangle(pen, rectangle);

            pen.Dispose();
            solidBrush.Dispose();
        }

    }
}
