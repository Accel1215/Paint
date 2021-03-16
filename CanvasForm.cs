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

        public Size workPlaceSize;

        public CanvasForm(Size size)
        {
            InitializeComponent();
            array = new List<Figure>();
            workPlaceSize = size;
            Size = size;
            AutoScrollMinSize = size;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if((e.X > workPlaceSize.Width) || (e.Y > workPlaceSize.Height))
            {
                return;
            }

            isMousePresed = true;

            MainWindowForm m = (MainWindowForm)ParentForm;

            switch (m.figureType)
            {
                case FigureType.Line:
                    {
                        e.Location.Offset(AutoScrollPosition);
                        array.Add(new Figures.Line(e.Location, e.Location, m.lineWidth, m.lineColor));
                        break;
                    }

                case FigureType.Curve:
                    {
                        e.Location.Offset(AutoScrollPosition);
                        array.Add(new Figures.Curve(e.Location, e.Location, m.lineWidth, m.lineColor));
                        break;
                    }

                case FigureType.Rectangle:
                    {
                        e.Location.Offset(AutoScrollPosition);
                        array.Add(new Figures.Rectangle(e.Location, e.Location, m.lineWidth, m.lineColor, m.solidColor));
                        break;
                    }

                case FigureType.Ellipse:
                    {
                        e.Location.Offset(AutoScrollPosition);
                        array.Add(new Figures.Ellipse(e.Location, e.Location, m.lineWidth, m.lineColor, m.solidColor));
                        break;
                    }

            }



        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMousePresed)
            {
                Point mousePoint = new Point(e.X - AutoScrollPosition.X, e.Y - AutoScrollPosition.Y);
                array.Last().MouseMove(buffer.Graphics, mousePoint, AutoScrollPosition);
                Invalidate();
                //buffer.Render();
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
                if(!IsFigureInCanvas(array.Last(),e.Location))
                {
                    array.Last().Hide(buffer.Graphics, AutoScrollPosition);
                    Invalidate();
                    array.RemoveAt(array.Count - 1);
                }
                else
                {
                    array.Last().Draw(buffer.Graphics, AutoScrollPosition);
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
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(startPoint, workPlaceSize);
            System.Drawing.SolidBrush solidBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

            buffer.Graphics.FillRectangle(solidBrush, rectangle);

            foreach (Figure i in array)
            {
                i.Draw(buffer.Graphics, AutoScrollPosition);
            }

            buffer.Render(e.Graphics);
        }

        private void Canvas_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainWindowForm m = (MainWindowForm)ParentForm;
            m.DisableSave();
            buffer.Dispose();
            //contex.Dispose();
            Dispose();
        }

        private void Canvas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(isModificated)
            {
                DialogResult dialogResult =  MessageBox.Show("Save your last changes?", Text, MessageBoxButtons.YesNoCancel);

                if(dialogResult == DialogResult.Yes)
                {
                    MainWindowForm mainWindow = (MainWindowForm)MdiParent;

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
            //Уменьшает количество бликов
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            contex = BufferedGraphicsManager.Current;
            contex.MaximumBuffer = new Size(workPlaceSize.Width, workPlaceSize.Height);

            buffer = contex.Allocate(CreateGraphics(), new System.Drawing.Rectangle(0, 0, workPlaceSize.Width, workPlaceSize.Height));

            System.Drawing.Point startPoint = new System.Drawing.Point(0, 0);
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(startPoint, workPlaceSize);
            System.Drawing.SolidBrush solidBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

            buffer.Graphics.FillRectangle(solidBrush, rectangle);
        }

        private bool IsFigureInCanvas(Figure f, Point p)
        {
            Type t = f.GetType();

            if(t.Equals(typeof(Curve)))
            {
                Curve curve = (Curve)f;
                for(int i = 0; i < curve.points.Count; ++i)
                {
                    if ((curve.points[i].X - AutoScrollPosition.X > workPlaceSize.Width) || (curve.points[i].Y - AutoScrollPosition.Y > workPlaceSize.Height) ||
                    (curve.points[i].X - AutoScrollPosition.X < 0) || (curve.points[i].Y - AutoScrollPosition.Y < 0))
                    {
                        return false;
                    }
                }
            }

            if ((p.X - AutoScrollPosition.X > workPlaceSize.Width) || (p.Y - AutoScrollPosition.Y > workPlaceSize.Height) ||
                    (p.X - AutoScrollPosition.X < 0) || (p.Y - AutoScrollPosition.Y < 0))
            {
                return false;
            }

            return true;
        }
    }
}
