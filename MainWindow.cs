using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Paint
{
    public partial class MainWindow : Form
    {

        public Color solidColor = Color.White;
        public Color lineColor = Color.Black;
        public int lineWidth = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Canvas
            {
                MdiParent = this,
                Text = "Picture " + this.MdiChildren.Length.ToString()
            };

            this.saveToolStripMenuItem.Enabled = true;
            this.saveAsToolStripMenuItem.Enabled = true;

            f.Show();
        }

        public void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Canvas canvas = (Canvas)this.ActiveMdiChild;

            if(canvas.FilePathSave == System.String.Empty)
            {
                SaveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                canvas.isModificated = false;

                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(canvas.FilePathSave, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, canvas.Array);
                stream.Close();
            }

        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = "p",
                Title = "Save",
                FileName = "Picture",
                InitialDirectory = Environment.CurrentDirectory
            };

            DialogResult dialogResult = saveFileDialog.ShowDialog();
            
            if(dialogResult == DialogResult.OK)
            {
                Canvas canvas = (Canvas)this.ActiveMdiChild;

                canvas.FilePathSave = saveFileDialog.FileName;
                canvas.Text = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('\\') + 1);
                canvas.isModificated = false;

                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, canvas.Array);
                stream.Close();
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory
            };

            DialogResult dialogResult = openFileDialog.ShowDialog();

            for (int i = 0; i < this.MdiChildren.Length; ++i) 
            {
                Canvas canvas = (Canvas)this.MdiChildren[i];
                if(canvas.FilePathSave == openFileDialog.FileName)
                {
                    MessageBox.Show("File with this name is already open");
                    return;
                }
            }


            if(dialogResult == DialogResult.OK)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                List<Figure> array = (List<Figure>)formatter.Deserialize(stream);
                stream.Close();

                Canvas canvas = new Canvas
                {
                    Array = array,
                    Text = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('\\') + 1),
                    FilePathSave = openFileDialog.FileName
                };

                Form f = canvas;
                f.MdiParent = this;

                this.saveToolStripMenuItem.Enabled = true;
                this.saveAsToolStripMenuItem.Enabled = true;

                f.Show();
            }
        }

        public void DisableSave()
        {
            if (this.MdiChildren.Length <= 1)
            {
                this.saveToolStripMenuItem.Enabled = false;
                this.saveAsToolStripMenuItem.Enabled = false;
            }
        }

        private void LineColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
     
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                lineColor = colorDialog.Color;
            }
        }

        private void BackgroudColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                solidColor = colorDialog.Color;
            }
        }

        private void LineSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Line line = new Line();

            line.SetWidth(this.lineWidth);

            if(line.ShowDialog() == DialogResult.OK)
            {
                this.lineWidth = line.GetWidth();
            }
        }
    }
}
