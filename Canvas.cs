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
        public Canvas()
        {
            InitializeComponent();
            array = new List<Figure>();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            isMousePresed = true;

            MainWindow m = (MainWindow)this.ParentForm;

            array.Add(new Rectangle(e.X, e.Y, e.X, e.Y, m.lineSize, m.lineColor, m.solidColor));
            g = CreateGraphics();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMousePresed)
            {
                Point mousePoint = new Point(e.X, e.Y);
                array.Last().MouseMove(g, mousePoint);
                isMouseMoved = true;
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMousePresed && !isMouseMoved)
            {
                array.RemoveAt(array.Count - 1);
                isMousePresed = false;
                isMouseMoved = false;
            }
            else if (isMousePresed && isMouseMoved)
            {
                array.Last().Draw(g);
                Invalidate();
                isMousePresed = false;
                isMouseMoved = false;
                isModificated = true;
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure i in array)
            {
                g = CreateGraphics();
                i.Draw(g);
                g.Dispose();
            }
        }

        private void Canvas_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainWindow m = (MainWindow)this.ParentForm;
            m.DisableSave();
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
                else if(dialogResult == DialogResult.No)
                {

                }
                else if(dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        internal List<Figure> Array { get => array; set => array = value; }

        System.Drawing.Graphics g;
        List<Figure> array;
        bool isMousePresed = false;
        bool isMouseMoved = false;
        public bool isModificated = false;
        public string FilePathSave = "";
    }
}
