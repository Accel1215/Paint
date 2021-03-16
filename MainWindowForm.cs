﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;


namespace Paint
{
    public partial class MainWindowForm : Form
    {
        public Color solidColor;
        public Color lineColor;
        public Size canvasSize;
        public int lineWidth;

        public FigureType figureType;
        

        public MainWindowForm()
        {
            InitializeComponent();

            solidColor = Color.White;
            lineColor = Color.Black;
            canvasSize = new Size(640, 480);
            figureType = FigureType.Line;
            
            
            lineWidth = 1;
            

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

            saveToolStripButton.Enabled = true;

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

                saveToolStripButton.Enabled = false;
            }
        }

        private void LineColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
     
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                lineColor = colorDialog.Color;
                DrawStatusBar();
            }
        }

        private void BackgroudColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                solidColor = colorDialog.Color;
                DrawStatusBar();
            }
        }

        private void LineWidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineForm line = new LineForm();

            line.SetWidth(lineWidth);

            if(line.ShowDialog() == DialogResult.OK)
            {
                lineWidth = line.GetWidth();
                DrawStatusBar();
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

        private void FigureChoseClick(object sender, EventArgs e)
        {
            if(sender.Equals(lineToolStripMenuItem) || sender.Equals(lineToolStripButton))
            {
                ChangeFigure(FigureType.Line);
            }
            else if(sender.Equals(curveToolStripMenuItem) || sender.Equals(curveToolStripButton))
            {
                ChangeFigure(FigureType.Curve);
            }
            else if(sender.Equals(rectangleToolStripMenuItem) || sender.Equals(rectangleToolStripButton))
            {
                ChangeFigure(FigureType.Rectangle);
            }
            else if(sender.Equals(ellipseToolStripMenuItem) || sender.Equals(ellipseToolStripButton))
            {
                ChangeFigure(FigureType.Ellipse);
            }
        }

        private void ChangeFigure(FigureType figure)
        {
            figureType = figure;

            backgroudColorToolStripMenuItem.Enabled = false;
            lineToolStripMenuItem.Checked = false;
            rectangleToolStripMenuItem.Checked = false;
            curveToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = false;

            lineToolStripButton.Checked = false;
            rectangleToolStripButton.Checked = false;
            curveToolStripButton.Checked = false;
            ellipseToolStripButton.Checked = false;

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
                        backgroudColorToolStripMenuItem.Enabled = true;
                        rectangleToolStripMenuItem.Checked = true;
                        rectangleToolStripButton.Checked = true;
                        break;
                    }
                case FigureType.Ellipse:
                    {
                        backgroudColorToolStripMenuItem.Enabled = true;
                        ellipseToolStripMenuItem.Checked = true;
                        ellipseToolStripButton.Checked = true;
                        break;
                    }
            }
        }

        private void DrawStatusBar()
        {
            penSizeStatusBarPanel.Text = "Pen size " + Convert.ToString(lineWidth);
            coordinateStatusBarPanel.Text = Convert.ToString(MousePosition.X) + "x" + Convert.ToString(MousePosition.Y);

            Graphics g = statusBar1.CreateGraphics();

            Rectangle rectangle = new Rectangle(new Point(penColorStatusBarPanel.Width + coordinateStatusBarPanel.Width + canvasSizeStatusBarPanel.Width + 20, 5)
                , new Size(15, 15));
            g.FillRectangle(new SolidBrush(lineColor), rectangle);

            rectangle = new Rectangle(new Point(penColorStatusBarPanel.Width + coordinateStatusBarPanel.Width + canvasSizeStatusBarPanel.Width + penColorStatusBarPanel.Width + 20, 5),
                new Size(15, 15));
            g.FillRectangle(new SolidBrush(solidColor), rectangle);

            if (ActiveMdiChild != null)
            {
                CanvasForm canvasForm = (CanvasForm)ActiveMdiChild;
                canvasSizeStatusBarPanel.Text = Convert.ToString(canvasForm.workPlaceSize.Width) + "x" + Convert.ToString(canvasForm.workPlaceSize.Height);
            }
            else
            {
                canvasSizeStatusBarPanel.Text = System.String.Empty;
            }
        }

        private void StatusBar1_DrawItem(object sender, StatusBarDrawItemEventArgs sbdevent)
        {
            DrawStatusBar();
        }

        private void MainWindowForm_MdiChildActivate(object sender, EventArgs e)
        {
            DrawStatusBar();
        }

    }
}
