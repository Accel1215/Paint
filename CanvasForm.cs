using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paint.Figures;
using System.Drawing;

namespace Paint
{
    [Serializable()]
    public partial class CanvasForm : Form
    {
        List<Figure> array;

        public BufferedGraphics buffer;
        public BufferedGraphicsContext contex;

        bool isMousePresed = false;
        bool isMouseMoved = false;
        public bool isModificated = false;

        public string FilePathSave = System.String.Empty;

        public Size size;

        public CanvasForm(Size size)
        {
            InitializeComponent();
            array = new List<Figure>();
            this.size = size;
            this.Size = new Size(size.Width + 50,size.Height + 50);
            this.AutoScrollMinSize = size;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if((e.X > size.Width) || (e.Y > size.Height))
            {
                return;
            }

            isMousePresed = true;

            MainWindowForm m = (MainWindowForm)this.ParentForm;

            switch (m.figureType)
            {
                case FigureType.Line:
                    {
                        e.Location.Offset(this.AutoScrollPosition);
                        array.Add(new Figures.Line(e.Location, e.Location, m.lineWidth, m.lineColor));
                        break;
                    }

                case FigureType.Curve:
                    {
                        e.Location.Offset(this.AutoScrollPosition);
                        array.Add(new Figures.Curve(e.Location, e.Location, m.lineWidth, m.lineColor));
                        break;
                    }

                case FigureType.Rectangle:
                    {
                        e.Location.Offset(this.AutoScrollPosition);
                        array.Add(new Figures.Rectangle(e.Location, e.Location, m.lineWidth, m.lineColor, m.solidColor));
                        break;
                    }

                case FigureType.Ellipse:
                    {
                        e.Location.Offset(this.AutoScrollPosition);
                        array.Add(new Figures.Ellipse(e.Location, e.Location, m.lineWidth, m.lineColor, m.solidColor));
                        break;
                    }

            }



        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMousePresed)
            {
                Point mousePoint = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
                array.Last().MouseMove(buffer, mousePoint, this.AutoScrollPosition);
                Invalidate();
                buffer.Render();
                isMouseMoved = true;
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {

            if (isMousePresed && !isMouseMoved)
            {
                array.RemoveAt(array.Count - 1);
            }
            else if (isMousePresed && isMouseMoved)
            {
                if ((e.X - this.AutoScrollPosition.X > size.Width) || (e.Y - this.AutoScrollPosition.Y > size.Height)||
                    (e.X - this.AutoScrollPosition.X < 0) || (e.Y - this.AutoScrollPosition.Y < 0))
                {
                    array.Last().Hide(buffer.Graphics, this.AutoScrollPosition);
                    Invalidate();
                    array.RemoveAt(array.Count - 1);
                }
                else
                {
                    array.Last().Draw(buffer.Graphics, this.AutoScrollPosition);
                    Invalidate();
                    isModificated = true; 
                }
            }

            isMousePresed = false;
            isMouseMoved = false;

        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Point startPoint = new System.Drawing.Point(0, 0);
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(startPoint, this.size);
            System.Drawing.SolidBrush solidBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

            buffer.Graphics.FillRectangle(solidBrush, rectangle);

            foreach (Figure i in array)
            {
                i.Draw(buffer.Graphics, this.AutoScrollPosition);
            }

            buffer.Render(e.Graphics);
        }

        private void Canvas_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainWindowForm m = (MainWindowForm)this.ParentForm;
            m.DisableSave();
            this.Dispose();
        }

        private void Canvas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(isModificated)
            {
                DialogResult dialogResult =  MessageBox.Show("Save your last changes?", this.Text, MessageBoxButtons.YesNoCancel);

                if(dialogResult == DialogResult.Yes)
                {
                    MainWindowForm mainWindow = (MainWindowForm)this.MdiParent;

                    mainWindow.SaveToolStripMenuItem_Click(sender, e);
                }
                else if(dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        internal List<Figure> Array { get => array; set => array = value; }

        private void Canvas_Load(object sender, EventArgs e)
        {

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            contex = BufferedGraphicsManager.Current;
            contex.MaximumBuffer = new Size(this.Width - 20, this.Height - 20);

            buffer = contex.Allocate(CreateGraphics(), new System.Drawing.Rectangle(0, 0, Width- 50, Height - 50));

            System.Drawing.Point startPoint = new System.Drawing.Point(0, 0);
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(startPoint, this.size);
            System.Drawing.SolidBrush solidBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

            buffer.Graphics.FillRectangle(solidBrush, rectangle);

        }
    }
}
