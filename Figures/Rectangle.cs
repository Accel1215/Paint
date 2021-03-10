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
        public Color solidColor;

        public Rectangle(Point pointOne, Point pointTwo, int lineSize, Color lineColor, Color fillColor) : 
            base(pointOne, pointTwo, lineSize, lineColor) 
        {
            solidColor = fillColor;
        }

        public Rectangle(int x1, int y1, int x2, int y2, int lineSize, Color lineColor, Color fillColor) : 
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

            g.FillRectangle(solidBrush, rectangle);
            g.DrawRectangle(pen, rectangle);

            pen.Dispose();
            solidBrush.Dispose();
        }

        public override void DrawHash(Graphics g, Point offset)
        {
            Pen pen = new Pen(lineColor, lineSize)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            };

            Point normalPointOne = new Point(pointOne.X + offset.X, pointOne.Y + offset.Y);
            Point normalPointTwo = new Point(pointTwo.X + offset.X, pointTwo.Y + offset.Y);

            Normalization(ref normalPointOne, ref normalPointTwo);

            System.Drawing.Rectangle rectangle = 
                System.Drawing.Rectangle.FromLTRB(normalPointOne.X, normalPointOne.Y, normalPointTwo.X, normalPointTwo.Y);

            g.DrawRectangle(pen, rectangle);

            pen.Dispose();
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

            g.FillRectangle(solidBrush, rectangle);
            g.DrawRectangle(pen, rectangle);

            pen.Dispose();
            solidBrush.Dispose();
        }

    }
}
