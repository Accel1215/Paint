using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class LineSize : Form
    {
        public LineSize()
        {
            InitializeComponent();
        }

        public int GetSize()
        {
            return Convert.ToInt32(this.comboBox.Text);
        }

        public void SetSize(int size)
        {
            this.comboBox.Text = Convert.ToString(size);
        }
    }
}
