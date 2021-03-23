using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint.Figures
{
    [Serializable()]
    class Text : Figure
    {
        Font font;
        Form parent;
        MainForm mainParent;
        public string text = System.String.Empty;

        public Text(Point pointOne, Point pointTwo, int lineSize, Color lineColor, Font font, Form parent, MainForm main) : 
            base(pointOne, pointTwo, lineSize, lineColor)
        {
            this.font = font;
            this.parent = parent;
            mainParent = main;
        }

        public override void Draw(Graphics g, Point offset)
        {
            if(text == System.String.Empty)
            {
                Pen pen = new Pen(Color.Black, 1);

                Point normalPointOne = new Point(pointOne.X + offset.X, pointOne.Y + offset.Y);
                Point normalPointTwo = new Point(pointTwo.X + offset.X, pointTwo.Y + offset.Y);

                Normalization(ref normalPointOne, ref normalPointTwo);

                System.Drawing.Rectangle rectangle =
                    System.Drawing.Rectangle.FromLTRB(normalPointOne.X, normalPointOne.Y, normalPointTwo.X, normalPointTwo.Y);

                g.DrawRectangle(pen, rectangle);
                pen.Dispose();
            }
            else
            {
                Point normalPointOne = new Point(pointOne.X + offset.X, pointOne.Y + offset.Y);
                Point normalPointTwo = new Point(pointTwo.X + offset.X, pointTwo.Y + offset.Y);

                Normalization(ref normalPointOne, ref normalPointTwo);

                System.Drawing.Rectangle rectangle =
                    System.Drawing.Rectangle.FromLTRB(normalPointOne.X, normalPointOne.Y, normalPointTwo.X, normalPointTwo.Y);

                g.DrawString(text, font, new SolidBrush(lineColor), rectangle);
            }            
        }

        public void Click(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if(e.KeyCode == Keys.Enter)
            {
                parent.Invalidate();
                text = textBox.Text;
                CheckFalidate();
                mainParent.EraseStatusBarFont();
                textBox.Dispose();
            }
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

        public override void FinishDraw(Graphics g, Point offset)
        {
            TextBox textBox = new TextBox();
            textBox.Parent = parent;

            Point normalPointOne = new Point(pointOne.X + offset.X, pointOne.Y + offset.Y);
            Point normalPointTwo = new Point(pointTwo.X + offset.X, pointTwo.Y + offset.Y);

            Normalization(ref normalPointOne, ref normalPointTwo);

            textBox.Location = normalPointOne;
            textBox.Size = new Size(normalPointTwo.X - normalPointOne.X, normalPointTwo.Y - normalPointOne.Y);
            textBox.Multiline = true;
            textBox.Font = font;
            textBox.ForeColor = lineColor;
            textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Click);

            mainParent.DrawStatusBarFont();
        }

        public override void CheckFalidate()
        {
            if (pointOne == pointTwo)
            {
                isCorrect = StatusCheck.Bad;
                return;
            }
            if(text == System.String.Empty)
            {
                isCorrect = StatusCheck.Bad;
                return;
            }
            isCorrect = StatusCheck.Good;
        }
    }
}
