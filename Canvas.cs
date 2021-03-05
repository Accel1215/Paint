using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paint.Figures;

namespace Paint
{
    [Serializable()]
    public partial class Canvas : Form
    {

        System.Drawing.Graphics g;
        List<Figure> array;

        bool isMousePresed = false;
        bool isMouseMoved = false;
        public bool isModificated = false;

        public string FilePathSave = System.String.Empty;

        public System.Drawing.Size size;

        public Canvas(System.Drawing.Size size)
        {
            InitializeComponent();
            array = new List<Figure>();
            this.size = size;
            this.AutoScrollMinSize = size;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if((e.X > size.Width) || (e.Y > size.Height))
            {
                return;
            }

            isMousePresed = true;

            MainWindow m = (MainWindow)this.ParentForm;

            array.Add(new Rectangle(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y, e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y, m.lineWidth, m.lineColor, m.solidColor));
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMousePresed)
            {
                Point mousePoint = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
                array.Last().MouseMove(g, mousePoint, this.AutoScrollPosition);
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
                    array.Last().Hide(g, this.AutoScrollPosition);
                    Invalidate();
                    array.RemoveAt(array.Count - 1);
                }
                else
                {
                    array.Last().Draw(g, this.AutoScrollPosition);
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

            g.FillRectangle(solidBrush, rectangle);

            foreach (Figure i in array)
            {
                i.Draw(g, this.AutoScrollPosition);
            }
        }

        private void Canvas_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainWindow m = (MainWindow)this.ParentForm;
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
                    MainWindow mainWindow = (MainWindow)this.MdiParent;

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
            g = CreateGraphics();
        }
    }
}
