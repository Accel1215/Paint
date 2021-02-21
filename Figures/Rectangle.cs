﻿using System;
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
        public Rectangle(Point pointOne, Point pointTwo, int lineSize, Color lineColor, Color fillColor) : base(pointOne, pointTwo, lineSize, lineColor, fillColor) { }

        public Rectangle(int x1, int y1, int x2, int y2, int lineSize, Color lineColor, Color fillColor) : base(x1, y1, x2, y2, lineSize, lineColor, fillColor) { }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(lineColor, lineSize);

            SolidBrush solidBrush = new SolidBrush(solidColor);

            Point normPointOne = new Point(pointOne.x, pointOne.y);
            Point normPointTwo = new Point(pointTwo.x, pointTwo.y);

            Normalization(ref normPointOne, ref normPointTwo);

            System.Drawing.Rectangle rectangle = System.Drawing.Rectangle.FromLTRB(normPointOne.x, normPointOne.y, normPointTwo.x, normPointTwo.y);

            g.FillRectangle(solidBrush, rectangle);
            g.DrawRectangle(pen, rectangle);
        }

        public override void DrawHash(Graphics g)
        {
            Pen pen = new Pen(lineColor, lineSize);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            //SolidBrush solidBrush = new SolidBrush(Color.White);

            Point normPointOne = new Point(pointOne.x, pointOne.y);
            Point normPointTwo = new Point(pointTwo.x, pointTwo.y);

            Normalization(ref normPointOne, ref normPointTwo);

            System.Drawing.Rectangle rectangle = System.Drawing.Rectangle.FromLTRB(normPointOne.x, normPointOne.y, normPointTwo.x, normPointTwo.y);

            //g.FillRectangle(solidBrush, rectangle);
            g.DrawRectangle(pen, rectangle);
        }

        public override void Hide(Graphics g)
        {
            Pen pen = new Pen(Color.White, lineSize);

            SolidBrush solidBrush = new SolidBrush(Color.White);

            Point normPointOne = new Point(pointOne.x, pointOne.y);
            Point normPointTwo = new Point(pointTwo.x, pointTwo.y);

            Normalization(ref normPointOne, ref normPointTwo);

            System.Drawing.Rectangle rectangle = System.Drawing.Rectangle.FromLTRB(normPointOne.x, normPointOne.y, normPointTwo.x, normPointTwo.y);

            g.FillRectangle(solidBrush, rectangle);
            g.DrawRectangle(pen, rectangle);
        }

    }
}
