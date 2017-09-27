namespace TabHeaderDemo
{
    partial class UserControlGraph
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlGraph));
            this.lblcaption = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelback = new System.Windows.Forms.Panel();
            this.tableLayoutPanelCurve = new System.Windows.Forms.TableLayoutPanel();
            this.scatterGraph = new NationalInstruments.UI.WindowsForms.ScatterGraph();
            this.xyCursor1 = new NationalInstruments.UI.XYCursor();
            this.scatterPlot3 = new NationalInstruments.UI.ScatterPlot();
            this.xAxis1 = new NationalInstruments.UI.XAxis();
            this.yAxis1 = new NationalInstruments.UI.YAxis();
            this.xAxis2 = new NationalInstruments.UI.XAxis();
            this.yAxis2 = new NationalInstruments.UI.YAxis();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.legend = new NationalInstruments.UI.WindowsForms.Legend();
            this.legendItem1 = new NationalInstruments.UI.LegendItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbdefault = new System.Windows.Forms.ToolStripButton();
            this.tsbzoomin = new System.Windows.Forms.ToolStripButton();
            this.tsbzoomout = new System.Windows.Forms.ToolStripButton();
            this.tsbscreenreader = new System.Windows.Forms.ToolStripButton();
            this.tsbreader = new System.Windows.Forms.ToolStripButton();
            this.tsbselector = new System.Windows.Forms.ToolStripButton();
            this.tsbtext = new System.Windows.Forms.ToolStripButton();
            this.tsbarrow = new System.Windows.Forms.ToolStripButton();
            this.tsbline = new System.Windows.Forms.ToolStripButton();
            this.tsbrect = new System.Windows.Forms.ToolStripButton();
            this.tsbpoint = new System.Windows.Forms.ToolStripButton();
            this.tsbcontrol = new System.Windows.Forms.ToolStripButton();
            this.panelback.SuspendLayout();
            this.tableLayoutPanelCurve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xyCursor1)).BeginInit();
            this.tableLayoutPanel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.legend)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblcaption
            // 
            this.lblcaption.BackColor = System.Drawing.Color.White;
            this.lblcaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblcaption.Location = new System.Drawing.Point(0, 0);
            this.lblcaption.Name = "lblcaption";
            this.lblcaption.Size = new System.Drawing.Size(451, 25);
            this.lblcaption.TabIndex = 3;
            this.lblcaption.Text = "曲线图1";
            this.lblcaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.White;
            this.panelback.Controls.Add(this.tableLayoutPanelCurve);
            this.panelback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelback.Location = new System.Drawing.Point(0, 25);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(451, 306);
            this.panelback.TabIndex = 4;
            this.panelback.SizeChanged += new System.EventHandler(this.panelback_SizeChanged);
            this.panelback.Paint += new System.Windows.Forms.PaintEventHandler(this.panelback_Paint);
            // 
            // tableLayoutPanelCurve
            // 
            this.tableLayoutPanelCurve.ColumnCount = 2;
            this.tableLayoutPanelCurve.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCurve.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanelCurve.Controls.Add(this.scatterGraph, 0, 0);
            this.tableLayoutPanelCurve.Controls.Add(this.tableLayoutPanel15, 1, 0);
            this.tableLayoutPanelCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCurve.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelCurve.Name = "tableLayoutPanelCurve";
            this.tableLayoutPanelCurve.RowCount = 1;
            this.tableLayoutPanelCurve.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCurve.Size = new System.Drawing.Size(451, 306);
            this.tableLayoutPanelCurve.TabIndex = 6;
            this.tableLayoutPanelCurve.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanelCurve_Paint);
            // 
            // scatterGraph
            // 
            this.scatterGraph.Border = NationalInstruments.UI.Border.None;
            this.scatterGraph.Caption = "试样1";
            this.scatterGraph.CaptionBackColor = System.Drawing.Color.Transparent;
            this.scatterGraph.Cursors.AddRange(new NationalInstruments.UI.XYCursor[] {
            this.xyCursor1});
            this.scatterGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scatterGraph.Location = new System.Drawing.Point(3, 3);
            this.scatterGraph.Name = "scatterGraph";
            this.scatterGraph.PlotAreaBorder = NationalInstruments.UI.Border.Solid;
            this.scatterGraph.PlotAreaColor = System.Drawing.Color.White;
            this.scatterGraph.Plots.AddRange(new NationalInstruments.UI.ScatterPlot[] {
            this.scatterPlot3});
            this.scatterGraph.Size = new System.Drawing.Size(346, 300);
            this.scatterGraph.TabIndex = 5;
            this.scatterGraph.UseColorGenerator = true;
            this.scatterGraph.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis1,
            this.xAxis2});
            this.scatterGraph.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis1,
            this.yAxis2});
            this.scatterGraph.ZoomAnimation = false;
            this.scatterGraph.PlotDataChanged += new NationalInstruments.UI.XYPlotDataChangedEventHandler(this.scatterGraph_PlotDataChanged);
            // 
            // xyCursor1
            // 
            this.xyCursor1.LabelBackColor = System.Drawing.Color.Transparent;
            this.xyCursor1.LabelForeColor = System.Drawing.Color.Black;
            this.xyCursor1.LabelVisible = true;
            this.xyCursor1.Plot = this.scatterPlot3;
            this.xyCursor1.Visible = false;
            // 
            // scatterPlot3
            // 
            this.scatterPlot3.CanScaleXAxis = false;
            this.scatterPlot3.CanScaleYAxis = false;
            this.scatterPlot3.LineColor = System.Drawing.Color.Blue;
            this.scatterPlot3.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
            this.scatterPlot3.XAxis = this.xAxis1;
            this.scatterPlot3.YAxis = this.yAxis1;
            // 
            // xAxis1
            // 
            this.xAxis1.BaseLineVisible = true;
            this.xAxis1.Caption = "位移[mm]";
            // 
            // yAxis1
            // 
            this.yAxis1.BaseLineColor = System.Drawing.Color.Black;
            this.yAxis1.BaseLineVisible = true;
            this.yAxis1.Caption = "负荷[N]";
            this.yAxis1.LeftCaptionOrientation = NationalInstruments.UI.VerticalCaptionOrientation.TopToBottom;
            this.yAxis1.MajorDivisions.TickColor = System.Drawing.Color.Black;
            // 
            // xAxis2
            // 
            this.xAxis2.BaseLineVisible = true;
            this.xAxis2.CaptionPosition = NationalInstruments.UI.XAxisPosition.Top;
            this.xAxis2.CaptionVisible = false;
            this.xAxis2.MajorDivisions.LabelVisible = false;
            this.xAxis2.MajorDivisions.TickVisible = false;
            this.xAxis2.Position = NationalInstruments.UI.XAxisPosition.Top;
            // 
            // yAxis2
            // 
            this.yAxis2.BaseLineVisible = true;
            this.yAxis2.Caption = "负荷[N]";
            this.yAxis2.CaptionPosition = NationalInstruments.UI.YAxisPosition.Right;
            this.yAxis2.Position = NationalInstruments.UI.YAxisPosition.Right;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 1;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.Controls.Add(this.legend, 0, 1);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(355, 3);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 3;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(93, 300);
            this.tableLayoutPanel15.TabIndex = 4;
            // 
            // legend
            // 
            this.legend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.legend.Border = NationalInstruments.UI.Border.Solid;
            this.legend.CaptionBackColor = System.Drawing.Color.Transparent;
            this.legend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.legend.Items.AddRange(new NationalInstruments.UI.LegendItem[] {
            this.legendItem1});
            this.legend.ItemSize = new System.Drawing.Size(20, 3);
            this.legend.Location = new System.Drawing.Point(3, 47);
            this.legend.Name = "legend";
            this.legend.Size = new System.Drawing.Size(87, 206);
            this.legend.TabIndex = 4;
            // 
            // legendItem1
            // 
            this.legendItem1.Source = this.scatterPlot3;
            this.legendItem1.Text = "Item 0";
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbdefault,
            this.tsbzoomin,
            this.tsbzoomout,
            this.tsbscreenreader,
            this.tsbreader,
            this.tsbselector,
            this.tsbtext,
            this.tsbarrow,
            this.tsbline,
            this.tsbrect,
            this.tsbpoint,
            this.tsbcontrol});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(121, 25);
            this.toolStrip2.Stretch = true;
            this.toolStrip2.TabIndex = 10;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbdefault
            // 
            this.tsbdefault.AutoSize = false;
            this.tsbdefault.BackColor = System.Drawing.Color.Transparent;
            this.tsbdefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsbdefault.Checked = true;
            this.tsbdefault.CheckOnClick = true;
            this.tsbdefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbdefault.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbdefault.Image = ((System.Drawing.Image)(resources.GetObject("tsbdefault.Image")));
            this.tsbdefault.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbdefault.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsbdefault.Name = "tsbdefault";
            this.tsbdefault.Size = new System.Drawing.Size(23, 23);
            this.tsbdefault.Text = "指针";
            // 
            // tsbzoomin
            // 
            this.tsbzoomin.AutoSize = false;
            this.tsbzoomin.CheckOnClick = true;
            this.tsbzoomin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbzoomin.Image = ((System.Drawing.Image)(resources.GetObject("tsbzoomin.Image")));
            this.tsbzoomin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbzoomin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbzoomin.Name = "tsbzoomin";
            this.tsbzoomin.Size = new System.Drawing.Size(23, 23);
            this.tsbzoomin.Text = "放大";
            this.tsbzoomin.Click += new System.EventHandler(this.tsbzoomin_Click);
            // 
            // tsbzoomout
            // 
            this.tsbzoomout.AutoSize = false;
            this.tsbzoomout.CheckOnClick = true;
            this.tsbzoomout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbzoomout.Image = ((System.Drawing.Image)(resources.GetObject("tsbzoomout.Image")));
            this.tsbzoomout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbzoomout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbzoomout.Name = "tsbzoomout";
            this.tsbzoomout.Size = new System.Drawing.Size(23, 23);
            this.tsbzoomout.Text = "缩小";
            this.tsbzoomout.Click += new System.EventHandler(this.tsbzoomout_Click);
            // 
            // tsbscreenreader
            // 
            this.tsbscreenreader.AutoSize = false;
            this.tsbscreenreader.CheckOnClick = true;
            this.tsbscreenreader.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbscreenreader.Image = ((System.Drawing.Image)(resources.GetObject("tsbscreenreader.Image")));
            this.tsbscreenreader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbscreenreader.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbscreenreader.Name = "tsbscreenreader";
            this.tsbscreenreader.Size = new System.Drawing.Size(23, 23);
            this.tsbscreenreader.Text = "屏幕读数";
            this.tsbscreenreader.Click += new System.EventHandler(this.tsbscreenreader_Click);
            // 
            // tsbreader
            // 
            this.tsbreader.AutoSize = false;
            this.tsbreader.CheckOnClick = true;
            this.tsbreader.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbreader.Image = ((System.Drawing.Image)(resources.GetObject("tsbreader.Image")));
            this.tsbreader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbreader.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbreader.Name = "tsbreader";
            this.tsbreader.Size = new System.Drawing.Size(23, 23);
            this.tsbreader.ToolTipText = "数据读数";
            this.tsbreader.Visible = false;
            // 
            // tsbselector
            // 
            this.tsbselector.AutoSize = false;
            this.tsbselector.CheckOnClick = true;
            this.tsbselector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbselector.Image = ((System.Drawing.Image)(resources.GetObject("tsbselector.Image")));
            this.tsbselector.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbselector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbselector.Name = "tsbselector";
            this.tsbselector.Size = new System.Drawing.Size(23, 23);
            this.tsbselector.Text = "toolStripButton14";
            this.tsbselector.ToolTipText = "数据选择";
            this.tsbselector.Visible = false;
            // 
            // tsbtext
            // 
            this.tsbtext.AutoSize = false;
            this.tsbtext.CheckOnClick = true;
            this.tsbtext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtext.Image = ((System.Drawing.Image)(resources.GetObject("tsbtext.Image")));
            this.tsbtext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtext.Name = "tsbtext";
            this.tsbtext.Size = new System.Drawing.Size(23, 23);
            this.tsbtext.Text = "toolStripButton15";
            this.tsbtext.ToolTipText = "文本工具";
            this.tsbtext.Visible = false;
            // 
            // tsbarrow
            // 
            this.tsbarrow.AutoSize = false;
            this.tsbarrow.CheckOnClick = true;
            this.tsbarrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbarrow.Image = ((System.Drawing.Image)(resources.GetObject("tsbarrow.Image")));
            this.tsbarrow.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbarrow.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.tsbarrow.Name = "tsbarrow";
            this.tsbarrow.Size = new System.Drawing.Size(23, 23);
            this.tsbarrow.Text = "toolStripButton16";
            this.tsbarrow.ToolTipText = "箭头工具";
            this.tsbarrow.Visible = false;
            // 
            // tsbline
            // 
            this.tsbline.AutoSize = false;
            this.tsbline.CheckOnClick = true;
            this.tsbline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbline.Image = ((System.Drawing.Image)(resources.GetObject("tsbline.Image")));
            this.tsbline.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbline.Name = "tsbline";
            this.tsbline.Size = new System.Drawing.Size(23, 23);
            this.tsbline.Text = "toolStripButton17";
            this.tsbline.ToolTipText = "直线工具";
            this.tsbline.Visible = false;
            // 
            // tsbrect
            // 
            this.tsbrect.AutoSize = false;
            this.tsbrect.CheckOnClick = true;
            this.tsbrect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbrect.Image = ((System.Drawing.Image)(resources.GetObject("tsbrect.Image")));
            this.tsbrect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbrect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbrect.Name = "tsbrect";
            this.tsbrect.Size = new System.Drawing.Size(23, 23);
            this.tsbrect.Text = "矩形工具";
            this.tsbrect.Visible = false;
            // 
            // tsbpoint
            // 
            this.tsbpoint.CheckOnClick = true;
            this.tsbpoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbpoint.Image = ((System.Drawing.Image)(resources.GetObject("tsbpoint.Image")));
            this.tsbpoint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbpoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbpoint.Name = "tsbpoint";
            this.tsbpoint.Size = new System.Drawing.Size(23, 19);
            this.tsbpoint.ToolTipText = "标记点";
            this.tsbpoint.Visible = false;
            // 
            // tsbcontrol
            // 
            this.tsbcontrol.CheckOnClick = true;
            this.tsbcontrol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbcontrol.Image = ((System.Drawing.Image)(resources.GetObject("tsbcontrol.Image")));
            this.tsbcontrol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbcontrol.Name = "tsbcontrol";
            this.tsbcontrol.Size = new System.Drawing.Size(23, 20);
            this.tsbcontrol.Visible = false;
            // 
            // UserControlGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panelback);
            this.Controls.Add(this.lblcaption);
            this.Name = "UserControlGraph";
            this.Size = new System.Drawing.Size(451, 331);
            this.panelback.ResumeLayout(false);
            this.tableLayoutPanelCurve.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xyCursor1)).EndInit();
            this.tableLayoutPanel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.legend)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private NationalInstruments.UI.ScatterPlot scatterPlot3;
        private NationalInstruments.UI.XAxis xAxis1;
        private NationalInstruments.UI.YAxis yAxis1;
        private NationalInstruments.UI.XAxis xAxis2;
        private NationalInstruments.UI.YAxis yAxis2;
        private NationalInstruments.UI.LegendItem legendItem1;
        public NationalInstruments.UI.WindowsForms.ScatterGraph scatterGraph;
        public NationalInstruments.UI.WindowsForms.Legend legend;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanelCurve;
        private System.Windows.Forms.Timer timer1;
        private NationalInstruments.UI.XYCursor xyCursor1;
        public System.Windows.Forms.Label lblcaption;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbdefault;
        private System.Windows.Forms.ToolStripButton tsbzoomin;
        private System.Windows.Forms.ToolStripButton tsbzoomout;
        private System.Windows.Forms.ToolStripButton tsbscreenreader;
        private System.Windows.Forms.ToolStripButton tsbreader;
        private System.Windows.Forms.ToolStripButton tsbselector;
        private System.Windows.Forms.ToolStripButton tsbtext;
        private System.Windows.Forms.ToolStripButton tsbarrow;
        private System.Windows.Forms.ToolStripButton tsbline;
        private System.Windows.Forms.ToolStripButton tsbrect;
        private System.Windows.Forms.ToolStripButton tsbpoint;
        private System.Windows.Forms.ToolStripButton tsbcontrol;


    }
}
