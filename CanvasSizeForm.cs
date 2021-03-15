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

        public CanvasSizeForm(Size size)
        {
            InitializeComponent();

            if ((size.Width == 320) && (size.Height == 240))
            {
                radioButton1.Checked = true;
            }
            else if ((size.Width == 640) && (size.Height == 480))
            {
                radioButton2.Checked = true;
            }
            else if ((size.Width == 800) && (size.Height == 600))
            {
                radioButton3.Checked = true;
            }
            else
            {
                textBox1.Text = Convert.ToString(size.Width);
                textBox2.Text = Convert.ToString(size.Height);
                checkBox1.Checked = true;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                size = new Size(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            }
            else
            {
                if(radioButton1.Checked == true)
                {
                    size = new Size(320, 240);
                }
                else if (radioButton2.Checked == true)
                {
                    size = new Size(640, 480);
                }
                else if(radioButton3.Checked == true)
                {
                    size = new Size(800, 600);
                }
            }
            

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                groupBox1.Enabled = false;

                textBox1.Enabled = true;
                textBox2.Enabled = true;

                label1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;

                if(System.String.IsNullOrEmpty(textBox1.Text) || System.String.IsNullOrEmpty(textBox2.Text))
                {
                    OkButton.Enabled = false;
                }
                else
                {
                    OkButton.Enabled = true;
                }
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;

                label1.Enabled = false;
                label2.Enabled = false;
                label3.Enabled = false;

                groupBox1.Enabled = true;

                OkButton.Enabled = true;

            }

        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar)) || (e.KeyChar == '\b'))
            {
                return;
            }

            e.Handled = true;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.String.IsNullOrEmpty(textBox2.Text))
            {
                OkButton.Enabled = false;
            }
            else
            {
                OkButton.Enabled = true;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.String.IsNullOrEmpty(textBox1.Text))
            {
                OkButton.Enabled = false;
            }
            else
            {
                OkButton.Enabled = true;
            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar)) || (e.KeyChar == '\b'))
            {
                return;
            }

            e.Handled = true;
        }
    }
}
