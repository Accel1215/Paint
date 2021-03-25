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
        private Size canvasSize;

        public Size CanvasSize { get => canvasSize; }

        public CanvasSizeForm(Size size)
        {
            InitializeComponent();

            if ((size.Width == 320) && (size.Height == 240))
            {
                smallSizeRadioButton.Checked = true;
            }
            else if ((size.Width == 640) && (size.Height == 480))
            {
                mediumSizeRadioButtom.Checked = true;
            }
            else if ((size.Width == 800) && (size.Height == 600))
            {
                largeSizeRadioBottom.Checked = true;
            }
            else
            {
                widthTextBox.Text = Convert.ToString(size.Width);
                heightTextBox.Text = Convert.ToString(size.Height);
                customSizeCheckBox.Checked = true;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if(customSizeCheckBox.Checked == true)
            {
                canvasSize = new Size(Convert.ToInt32(widthTextBox.Text), Convert.ToInt32(heightTextBox.Text));
            }
            else
            {
                if(smallSizeRadioButton.Checked == true)
                {
                    canvasSize = new Size(320, 240);
                }
                else if (mediumSizeRadioButtom.Checked == true)
                {
                    canvasSize = new Size(640, 480);
                }
                else if(largeSizeRadioBottom.Checked == true)
                {
                    canvasSize = new Size(800, 600);
                }
            }
        }

        private void CustomSizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(customSizeCheckBox.Checked == true)
            {
                radioButtomGroupBox.Enabled = false;

                widthTextBox.Enabled = true;
                heightTextBox.Enabled = true;

                heightLabel.Enabled = true;
                widthLabel.Enabled = true;
                xLabel.Enabled = true;

                if(System.String.IsNullOrEmpty(widthTextBox.Text) || System.String.IsNullOrEmpty(heightTextBox.Text))
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
                widthTextBox.Enabled = false;
                heightTextBox.Enabled = false;

                heightLabel.Enabled = false;
                widthLabel.Enabled = false;
                xLabel.Enabled = false;

                radioButtomGroupBox.Enabled = true;

                OkButton.Enabled = true;
            }
        }

        private void WidthSizeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar)) || (e.KeyChar == '\b'))
            {
                return;
            }

            e.Handled = true;
        }

        private void HeightSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (System.String.IsNullOrEmpty(heightTextBox.Text))
            {
                OkButton.Enabled = false;
            }
            else
            {
                OkButton.Enabled = true;
            }
        }

        private void WidthSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (System.String.IsNullOrEmpty(widthTextBox.Text))
            {
                OkButton.Enabled = false;
            }
            else
            {
                OkButton.Enabled = true;
            }
        }

        private void HeightSizeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar)) || (e.KeyChar == '\b'))
            {
                return;
            }

            e.Handled = true;
        }
    }
}
