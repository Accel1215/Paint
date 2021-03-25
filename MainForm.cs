using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;


namespace Paint
{
    public partial class MainForm : Form
    {
        private Color solidColor = Color.White;
        private Color lineColor = Color.Black;
        private Size canvasSize = new Size(640, 480);
        private int lineWidth = 1;
        private FigureType figure = FigureType.Line;
        private Font canvasFont = new Font("Times New Roman", 12);
        
        public Color SolidColor { get => solidColor; }

        public Color LineColor { get => lineColor; }

        public int LineWidth { get => lineWidth; }

        public FigureType Figure { get => figure; }

        public Font CanvasFont { get => canvasFont; }


        public MainForm()
        {
            InitializeComponent();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new CanvasForm(canvasSize)
            {
                MdiParent = this,
                Text = "Picture " + MdiChildren.Length.ToString()
            };

            EnableSave();

            f.Show();
        }

        private void SaveFileClick(object sender, EventArgs e)
        {
            if (sender.Equals(saveAsToolStripMenuItem))
            {
                SaveFile(true);
            }
            else
            {
                SaveFile(false);
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
                if (canvas.FilePathSave == openFileDialog.FileName)
                {
                    MessageBox.Show("File with this name is already open");
                    return;
                }
            }

            if (dialogResult == DialogResult.OK)
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

                EnableSave();

                f.Show();
            }
        }

        private void LineColorChangeClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lineColor = colorDialog.Color;
                DrawStatusBar();
            }
        }

        private void BackgroudColorChangeClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                solidColor = colorDialog.Color;
                DrawStatusBar();
            }
        }

        private void LineWidthChangeClick(object sender, EventArgs e)
        {
            LineForm line = new LineForm();

            line.SetWidth(lineWidth);

            if (line.ShowDialog() == DialogResult.OK)
            {
                lineWidth = line.GetWidth();
                DrawStatusBar();
            }
        }

        private void PictureSizeChangeClick(object sender, EventArgs e)
        {
            CanvasSizeForm canvasSize = new CanvasSizeForm(this.canvasSize);

            if (canvasSize.ShowDialog() == DialogResult.OK)
            {
                this.canvasSize = canvasSize.CanvasSize;
            }
        }

        private void FigureChooseClick(object sender, EventArgs e)
        {
            if (sender.Equals(lineToolStripMenuItem) || sender.Equals(lineToolStripButton))
            {
                ChangeFigure(FigureType.Line);
            }
            else if (sender.Equals(curveToolStripMenuItem) || sender.Equals(curveToolStripButton))
            {
                ChangeFigure(FigureType.Curve);
            }
            else if (sender.Equals(rectangleToolStripMenuItem) || sender.Equals(rectangleToolStripButton))
            {
                ChangeFigure(FigureType.Rectangle);
            }
            else if (sender.Equals(ellipseToolStripMenuItem) || sender.Equals(ellipseToolStripButton))
            {
                ChangeFigure(FigureType.Ellipse);
            }
            else if (sender.Equals(textToolStripMenuItem) || sender.Equals(textToolStripButton))
            {
                ChangeFigure(FigureType.Text);
            }
        }

        private void StatusBar_DrawItem(object sender, StatusBarDrawItemEventArgs sbdevent)
        {
            DrawStatusBar();
        }

        private void MainWindowForm_MdiChildActivate(object sender, EventArgs e)
        {
            DrawStatusBar();
        }

        private void FontChangeClick(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                canvasFont = fontDialog.Font;
            }
        }

        public void SaveFile(bool specifyPath = false)
        {
            CanvasForm canvas = (CanvasForm)ActiveMdiChild;

            if((canvas.FilePathSave == System.String.Empty) || (specifyPath == true))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    DefaultExt = "pic",
                    Title = "Save",
                    FileName = "Picture",
                    InitialDirectory = Environment.CurrentDirectory
                };

                DialogResult dialogResult = saveFileDialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    canvas.FilePathSave = saveFileDialog.FileName;
                    canvas.Text = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('\\') + 1);
                }
                else
                {
                    return;
                }
            }

            canvas.Modificated = false;

            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(canvas.FilePathSave, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, canvas.Array);
            formatter.Serialize(stream, canvas.WorkPlaceSize);
            stream.Close();
        }

        public void DisableSave()
        {
            if (MdiChildren.Length <= 1)
            {
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;

                saveToolStripButton.Enabled = false;
            }
        }

        public void EnableSave()
        {
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;

            saveToolStripButton.Enabled = true;
        }

        private void ChangeFigure(FigureType f)
        {
            figure = f;

            backgroudColorToolStripMenuItem.Enabled = false;
            lineToolStripMenuItem.Checked = false;
            rectangleToolStripMenuItem.Checked = false;
            curveToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = false;
            textToolStripMenuItem.Checked = false;

            backgroundColorToolStripButton.Enabled = false;
            lineToolStripButton.Checked = false;
            rectangleToolStripButton.Checked = false;
            curveToolStripButton.Checked = false;
            ellipseToolStripButton.Checked = false;
            textToolStripButton.Checked = false;

            switch (figure)
            {
                case FigureType.Line:
                    {
                        lineToolStripMenuItem.Checked = true;
                        lineToolStripButton.Checked = true;
                        break;
                    }
                case FigureType.Curve:
                    {
                        curveToolStripMenuItem.Checked = true;
                        curveToolStripButton.Checked = true;
                        break;
                    }
                case FigureType.Rectangle:
                    {
                        backgroundColorToolStripButton.Enabled = true;
                        backgroudColorToolStripMenuItem.Enabled = true;
                        rectangleToolStripMenuItem.Checked = true;
                        rectangleToolStripButton.Checked = true;
                        break;
                    }
                case FigureType.Ellipse:
                    {
                        backgroundColorToolStripButton.Enabled = true;
                        backgroudColorToolStripMenuItem.Enabled = true;
                        ellipseToolStripMenuItem.Checked = true;
                        ellipseToolStripButton.Checked = true;
                        break;
                    }
                case FigureType.Text:
                    {
                        textToolStripButton.Checked = true;
                        textToolStripMenuItem.Checked = true;
                        break;
                    }
            }
        }

        public void DrawStatusBar()
        {
            penSizeStatusBarPanel.Text = Convert.ToString(lineWidth);
            
            Graphics g = statusBar.CreateGraphics();

            Rectangle rectangle = new Rectangle(new Point(penSizeStatusBarPanel.Width + coordinateStatusBarPanel.Width + canvasSizeStatusBarPanel.Width + 17, 4),
                new Size(15, 15));
            g.FillRectangle(new SolidBrush(lineColor), rectangle);

            rectangle = new Rectangle(new Point(penSizeStatusBarPanel.Width + coordinateStatusBarPanel.Width + canvasSizeStatusBarPanel.Width + penColorStatusBarPanel.Width + 17, 4),
                new Size(15, 15));
            g.FillRectangle(new SolidBrush(solidColor), rectangle);

            if (ActiveMdiChild != null)
            {
                CanvasForm canvasForm = (CanvasForm)ActiveMdiChild;
                canvasSizeStatusBarPanel.Text = Convert.ToString(canvasForm.WorkPlaceSize.Width) + "x" + Convert.ToString(canvasForm.WorkPlaceSize.Height);
            }
            else
            {
                canvasSizeStatusBarPanel.Text = System.String.Empty;
                coordinateStatusBarPanel.Text = System.String.Empty;
            }
        }

        public void DrawStatusBarCoordinate(Point location)
        {
            coordinateStatusBarPanel.Text = Convert.ToString(location.X) + 'x' + Convert.ToString(location.Y);
        }

        public void DrawStatusBarFont()
        {
            fontStatusBarPanel.Text = canvasFont.Name;
            fontSizeStatusBarPanel.Text = Convert.ToString(canvasFont.Size);
        }

        public void EraseStatusBarFont()
        {
            fontSizeStatusBarPanel.Text = System.String.Empty;
            fontStatusBarPanel.Text = System.String.Empty;
        }
    }
}
