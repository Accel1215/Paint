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
    public partial class MainWindowForm : Form
    {
        public Color solidColor;
        public Color lineColor;
        public Size canvasSize;
        public int lineWidth;

        public FigureType figureType;
        
        public bool solidColorNeed;


        public MainWindowForm()
        {
            InitializeComponent();

            solidColor = Color.White;
            lineColor = Color.Black;
            canvasSize = new Size(640, 480);
            figureType = FigureType.Line;
            lineWidth = 1;
            solidColorNeed = false;
        }
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new CanvasForm(canvasSize)
            {
                MdiParent = this,
                Text = "Picture " + MdiChildren.Length.ToString()
            };

            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;

            f.Show();
        }

        public void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CanvasForm canvas = (CanvasForm)ActiveMdiChild;

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
                formatter.Serialize(stream, canvas.workPlaceSize);
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
                CanvasForm canvas = (CanvasForm)ActiveMdiChild;

                canvas.FilePathSave = saveFileDialog.FileName;
                canvas.Text = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('\\') + 1);
                canvas.isModificated = false;

                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, canvas.Array);
                formatter.Serialize(stream, canvas.workPlaceSize);
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

            for (int i = 0; i < MdiChildren.Length; ++i) 
            {
                CanvasForm canvas = (CanvasForm)MdiChildren[i];
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
                Size size = (Size)formatter.Deserialize(stream);
                stream.Close();

                CanvasForm canvas = new CanvasForm(size)
                {
                    Array = array,
                    Text = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('\\') + 1),
                    FilePathSave = openFileDialog.FileName
                };

                Form f = canvas;
                f.MdiParent = this;

                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;

                f.Show();
            }
        }

        public void DisableSave()
        {
            if (MdiChildren.Length <= 1)
            {
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
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

        private void LineWidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineForm line = new LineForm();

            line.SetWidth(lineWidth);

            if(line.ShowDialog() == DialogResult.OK)
            {
                lineWidth = line.GetWidth();
            }
        }

        private void PictureSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanvasSizeForm canvasSize = new CanvasSizeForm(this.canvasSize);

            if(canvasSize.ShowDialog() == DialogResult.OK)
            {
                this.canvasSize = canvasSize.size;
            }
        }

        private void LineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figureType = FigureType.Line;
            solidColorNeed = false;
        }

        private void CurveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figureType = FigureType.Curve;
            solidColorNeed = false;
        }

        private void RectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figureType = FigureType.Rectangle;
            solidColorNeed = true;
        }

        private void EllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figureType = FigureType.Ellipse;
            solidColorNeed = true;
        }
    }
}
