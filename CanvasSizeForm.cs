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
    public partial class CanvasSizeForm : Form
    {
        public Size size;

        public CanvasSizeForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if(this.checkBox1.Checked == true)
            {
                size = new Size(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            }
            else
            {
                if(this.radioButton1.Checked == true)
                {
                    size = new Size(320, 240);
                }
                else if (this.radioButton2.Checked == true)
                {
                    size = new Size(640, 480);
                }
                else if(this.radioButton3.Checked == true)
                {
                    size = new Size(800, 600);
                }
            }
            

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(this.checkBox1.Checked == true)
            {
                this.groupBox1.Enabled = false;

                this.textBox1.Enabled = true;
                this.textBox2.Enabled = true;

                this.label1.Enabled = true;
                this.label2.Enabled = true;
                this.label3.Enabled = true;
            }
            else
            {
                this.textBox1.Enabled = false;
                this.textBox2.Enabled = false;

                this.label1.Enabled = false;
                this.label2.Enabled = false;
                this.label3.Enabled = false;

                this.groupBox1.Enabled = true;
            }
        }

    }
}
