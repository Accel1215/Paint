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
        private Font font;
        private Form parent;
        private string text = System.String.Empty;


        public Text(Point pointOne, Point pointTwo, int lineSize, Color lineColor, Font font, Form parent) : 
            base(pointOne, pointTwo, lineSize, lineColor)
        {
            this.font = font;
            this.parent = parent;
        }

        public override void Draw(Graphics g, Point offset)
        {
            Point normalPointOne = new Point(pointOne.X + offset.X, pointOne.Y + offset.Y);
            Point normalPointTwo = new Point(pointTwo.X + offset.X, pointTwo.Y + offset.Y);

            Normalization(ref normalPointOne, ref normalPointTwo);

            System.Drawing.Rectangle rectangle =
                System.Drawing.Rectangle.FromLTRB(normalPointOne.X, normalPointOne.Y, normalPointTwo.X, normalPointTwo.Y);

            if (text == System.String.Empty)
            {
                Pen pen = new Pen(Color.Black, 1);

                g.DrawRectangle(pen, rectangle);
                pen.Dispose();
            }
            else
            {
                g.DrawString(text, font, new SolidBrush(lineColor), rectangle);
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

            MainForm main = (MainForm)parent.ParentForm;
            main.DrawStatusBarFont();
        }

        public override void Falidate()
        {
            if (pointOne == pointTwo)
            {
                falidateStatus = StatusCheck.Bad;
                return;
            }
            if(text == System.String.Empty)
            {
                falidateStatus = StatusCheck.Bad;
                return;
            }
            falidateStatus = StatusCheck.Good;
        }

        public void Click(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                parent.Invalidate();
                text = textBox.Text;
                Falidate();
                textBox.Dispose();

                MainForm main = (MainForm)parent.ParentForm;
                main.EraseStatusBarFont();
            }
        }
    }
}
