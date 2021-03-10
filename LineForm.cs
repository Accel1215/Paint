using System;
using System.Windows.Forms;

namespace Paint
{
    public partial class LineForm : Form
    {
        public LineForm()
        {
            InitializeComponent();
        }

        public int GetWidth()
        {
            return Convert.ToInt32(this.comboBox.Text);
        }

        public void SetWidth(int size)
        {
            this.comboBox.Text = Convert.ToString(size);
        }

        private void comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar)) || (e.KeyChar == '\b'))
            {
                return;
            }

            e.Handled = true;
        }

        private void comboBox_TextChanged(object sender, EventArgs e)
        {
            if (System.String.IsNullOrEmpty(this.comboBox.Text))
            {
                this.OkButton.Enabled = false;
            }
            else
            {
                this.OkButton.Enabled = true;
            }
        }
    }
}
