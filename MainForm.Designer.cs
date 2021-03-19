namespace Paint
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametrsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroudColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.coordinateStatusBarPanel = new System.Windows.Forms.StatusBarPanel();
            this.canvasSizeStatusBarPanel = new System.Windows.Forms.StatusBarPanel();
            this.penSizeStatusBarPanel = new System.Windows.Forms.StatusBarPanel();
            this.penColorStatusBarPanel = new System.Windows.Forms.StatusBarPanel();
            this.backgroundColorStatusBarPanel = new System.Windows.Forms.StatusBarPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.penSizeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.penColorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.backgroundColorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.canvasSizeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lineToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.curveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rectangleToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ellipseToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coordinateStatusBarPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasSizeStatusBarPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.penSizeStatusBarPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.penColorStatusBarPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColorStatusBarPanel)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.parametrsToolStripMenuItem,
            this.figureToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1288, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveFileClick);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveFileClick);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // parametrsToolStripMenuItem
            // 
            this.parametrsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineColorToolStripMenuItem,
            this.backgroudColorToolStripMenuItem,
            this.lineSizeToolStripMenuItem,
            this.pictureSizeToolStripMenuItem});
            this.parametrsToolStripMenuItem.Name = "parametrsToolStripMenuItem";
            this.parametrsToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.parametrsToolStripMenuItem.Text = "Parameters";
            // 
            // lineColorToolStripMenuItem
            // 
            this.lineColorToolStripMenuItem.Name = "lineColorToolStripMenuItem";
            this.lineColorToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.lineColorToolStripMenuItem.Text = "Line color";
            this.lineColorToolStripMenuItem.Click += new System.EventHandler(this.LineColorChangeClick);
            // 
            // backgroudColorToolStripMenuItem
            // 
            this.backgroudColorToolStripMenuItem.Enabled = false;
            this.backgroudColorToolStripMenuItem.Name = "backgroudColorToolStripMenuItem";
            this.backgroudColorToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.backgroudColorToolStripMenuItem.Text = "Backgroud color";
            this.backgroudColorToolStripMenuItem.Click += new System.EventHandler(this.BackgroudColorChangeClick);
            // 
            // lineSizeToolStripMenuItem
            // 
            this.lineSizeToolStripMenuItem.Name = "lineSizeToolStripMenuItem";
            this.lineSizeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.lineSizeToolStripMenuItem.Text = "Line size";
            this.lineSizeToolStripMenuItem.Click += new System.EventHandler(this.LineWidthChangeClick);
            // 
            // pictureSizeToolStripMenuItem
            // 
            this.pictureSizeToolStripMenuItem.Name = "pictureSizeToolStripMenuItem";
            this.pictureSizeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.pictureSizeToolStripMenuItem.Text = "Picture size";
            this.pictureSizeToolStripMenuItem.Click += new System.EventHandler(this.PictureSizeChangeClick);
            // 
            // figureToolStripMenuItem
            // 
            this.figureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem,
            this.curveToolStripMenuItem,
            this.rectangleToolStripMenuItem,
            this.ellipseToolStripMenuItem});
            this.figureToolStripMenuItem.Name = "figureToolStripMenuItem";
            this.figureToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.figureToolStripMenuItem.Text = "Figure";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Checked = true;
            this.lineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.FigureChooseClick);
            // 
            // curveToolStripMenuItem
            // 
            this.curveToolStripMenuItem.Name = "curveToolStripMenuItem";
            this.curveToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.curveToolStripMenuItem.Text = "Curve";
            this.curveToolStripMenuItem.Click += new System.EventHandler(this.FigureChooseClick);
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.FigureChooseClick);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ellipseToolStripMenuItem.Text = "Ellipse";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.FigureChooseClick);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 734);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.coordinateStatusBarPanel,
            this.canvasSizeStatusBarPanel,
            this.penSizeStatusBarPanel,
            this.penColorStatusBarPanel,
            this.backgroundColorStatusBarPanel});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(1288, 22);
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "statusBar1";
            this.statusBar.DrawItem += new System.Windows.Forms.StatusBarDrawItemEventHandler(this.StatusBar_DrawItem);
            // 
            // coordinateStatusBarPanel
            // 
            this.coordinateStatusBarPanel.Name = "coordinateStatusBarPanel";
            this.coordinateStatusBarPanel.ToolTipText = "Mouse coordinates";
            // 
            // canvasSizeStatusBarPanel
            // 
            this.canvasSizeStatusBarPanel.Name = "canvasSizeStatusBarPanel";
            this.canvasSizeStatusBarPanel.ToolTipText = "Canvas size";
            // 
            // penSizeStatusBarPanel
            // 
            this.penSizeStatusBarPanel.Name = "penSizeStatusBarPanel";
            this.penSizeStatusBarPanel.ToolTipText = "Pen size";
            this.penSizeStatusBarPanel.Width = 50;
            // 
            // penColorStatusBarPanel
            // 
            this.penColorStatusBarPanel.Name = "penColorStatusBarPanel";
            this.penColorStatusBarPanel.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
            this.penColorStatusBarPanel.ToolTipText = "Pen color";
            this.penColorStatusBarPanel.Width = 50;
            // 
            // backgroundColorStatusBarPanel
            // 
            this.backgroundColorStatusBarPanel.Name = "backgroundColorStatusBarPanel";
            this.backgroundColorStatusBarPanel.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
            this.backgroundColorStatusBarPanel.ToolTipText = "Background color";
            this.backgroundColorStatusBarPanel.Width = 50;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.newToolStripButton,
            this.openToolStripButton,
            this.toolStripSeparator1,
            this.penSizeToolStripButton,
            this.penColorToolStripButton,
            this.backgroundColorToolStripButton,
            this.toolStripSeparator2,
            this.canvasSizeToolStripButton,
            this.toolStripSeparator3,
            this.lineToolStripButton,
            this.curveToolStripButton,
            this.rectangleToolStripButton,
            this.ellipseToolStripButton});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip.Size = new System.Drawing.Size(1288, 25);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Enabled = false;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.SaveFileClick);
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "New";
            this.newToolStripButton.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "Open";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // penSizeToolStripButton
            // 
            this.penSizeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.penSizeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("penSizeToolStripButton.Image")));
            this.penSizeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.penSizeToolStripButton.Name = "penSizeToolStripButton";
            this.penSizeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.penSizeToolStripButton.Text = "Size";
            this.penSizeToolStripButton.Click += new System.EventHandler(this.LineWidthChangeClick);
            // 
            // penColorToolStripButton
            // 
            this.penColorToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.penColorToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("penColorToolStripButton.Image")));
            this.penColorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.penColorToolStripButton.Name = "penColorToolStripButton";
            this.penColorToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.penColorToolStripButton.Text = "Color";
            this.penColorToolStripButton.Click += new System.EventHandler(this.LineColorChangeClick);
            // 
            // backgroundColorToolStripButton
            // 
            this.backgroundColorToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backgroundColorToolStripButton.Enabled = false;
            this.backgroundColorToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("backgroundColorToolStripButton.Image")));
            this.backgroundColorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backgroundColorToolStripButton.Name = "backgroundColorToolStripButton";
            this.backgroundColorToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.backgroundColorToolStripButton.Text = "Fill";
            this.backgroundColorToolStripButton.Click += new System.EventHandler(this.BackgroudColorChangeClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // canvasSizeToolStripButton
            // 
            this.canvasSizeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.canvasSizeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("canvasSizeToolStripButton.Image")));
            this.canvasSizeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.canvasSizeToolStripButton.Name = "canvasSizeToolStripButton";
            this.canvasSizeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.canvasSizeToolStripButton.Text = "Canvas size";
            this.canvasSizeToolStripButton.Click += new System.EventHandler(this.PictureSizeChangeClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // lineToolStripButton
            // 
            this.lineToolStripButton.Checked = true;
            this.lineToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("lineToolStripButton.Image")));
            this.lineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineToolStripButton.Name = "lineToolStripButton";
            this.lineToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.lineToolStripButton.Text = "Line";
            this.lineToolStripButton.Click += new System.EventHandler(this.FigureChooseClick);
            // 
            // curveToolStripButton
            // 
            this.curveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.curveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("curveToolStripButton.Image")));
            this.curveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.curveToolStripButton.Name = "curveToolStripButton";
            this.curveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.curveToolStripButton.Text = "Curve";
            this.curveToolStripButton.Click += new System.EventHandler(this.FigureChooseClick);
            // 
            // rectangleToolStripButton
            // 
            this.rectangleToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rectangleToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("rectangleToolStripButton.Image")));
            this.rectangleToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangleToolStripButton.Name = "rectangleToolStripButton";
            this.rectangleToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.rectangleToolStripButton.Text = "Rectangle";
            this.rectangleToolStripButton.Click += new System.EventHandler(this.FigureChooseClick);
            // 
            // ellipseToolStripButton
            // 
            this.ellipseToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ellipseToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ellipseToolStripButton.Image")));
            this.ellipseToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ellipseToolStripButton.Name = "ellipseToolStripButton";
            this.ellipseToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ellipseToolStripButton.Text = "Ellipse";
            this.ellipseToolStripButton.Click += new System.EventHandler(this.FigureChooseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 756);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Paint";
            this.MdiChildActivate += new System.EventHandler(this.MainWindowForm_MdiChildActivate);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coordinateStatusBarPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasSizeStatusBarPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.penSizeStatusBarPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.penColorStatusBarPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColorStatusBarPanel)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametrsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroudColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pictureSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem curveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.StatusBarPanel penSizeStatusBarPanel;
        private System.Windows.Forms.StatusBarPanel penColorStatusBarPanel;
        private System.Windows.Forms.StatusBarPanel backgroundColorStatusBarPanel;
        private System.Windows.Forms.StatusBarPanel coordinateStatusBarPanel;
        private System.Windows.Forms.StatusBarPanel canvasSizeStatusBarPanel;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton penSizeToolStripButton;
        private System.Windows.Forms.ToolStripButton penColorToolStripButton;
        private System.Windows.Forms.ToolStripButton backgroundColorToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton canvasSizeToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton lineToolStripButton;
        private System.Windows.Forms.ToolStripButton curveToolStripButton;
        private System.Windows.Forms.ToolStripButton rectangleToolStripButton;
        private System.Windows.Forms.ToolStripButton ellipseToolStripButton;
    }
}

