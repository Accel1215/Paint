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
            return Convert.ToInt32(comboBox.Text);
        }

        public void SetWidth(int size)
        {
            comboBox.Text = Convert.ToString(size);
        }

        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar)) || (e.KeyChar == '\b'))
            {
                return;
            }

            e.Handled = true;
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            if (System.String.IsNullOrEmpty(comboBox.Text))
            {
                OkButton.Enabled = false;
            }
            else
            {
                OkButton.Enabled = true;
            }
        }
    }
}
