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
    public partial class Canvas : Form
    {
        public Canvas()
        {
            InitializeComponent();
            array = new List<Figure>();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            g = CreateGraphics();
            mousePresed = true;
            array.Add(new Rectangle(e.X, e.Y, e.X, e.Y));
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousePresed)
            {
                Point mousePoint = new Point(e.X, e.Y);
                array.Last().MouseMove(g, mousePoint);
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (mousePresed)
            {
                array.Last().Draw(g);
                Invalidate();
                mousePresed = false;
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure i in array)
            {
                i.Draw(g);
            }
        }


        System.Drawing.Graphics g;
        List<Figure> array;
        bool mousePresed = false;
    }
}
