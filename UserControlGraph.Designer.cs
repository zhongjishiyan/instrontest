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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelCurve = new System.Windows.Forms.TableLayoutPanel();
            this.scatterGraph = new NationalInstruments.UI.WindowsForms.ScatterGraph();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.x轴坐标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.y轴坐标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xyCursor1 = new NationalInstruments.UI.XYCursor();
            this.scatterPlot3 = new NationalInstruments.UI.ScatterPlot();
            this.xAxis1 = new NationalInstruments.UI.XAxis();
            this.yAxis1 = new NationalInstruments.UI.YAxis();
            this.xAxis2 = new NationalInstruments.UI.XAxis();
            this.yAxis2 = new NationalInstruments.UI.YAxis();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.legend = new NationalInstruments.UI.WindowsForms.Legend();
            this.legendItem1 = new NationalInstruments.UI.LegendItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.userGraph1 = new AppleLabApplication.UserGraph();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripLeft = new System.Windows.Forms.ToolStrip();
            this.xAxis3 = new NationalInstruments.UI.XAxis();
            this.yAxis3 = new NationalInstruments.UI.YAxis();
            this.scatterPlot1 = new NationalInstruments.UI.ScatterPlot();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanelCurve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xyCursor1)).BeginInit();
            this.tableLayoutPanel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.legend)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.toolStripLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblcaption
            // 
            resources.ApplyResources(this.lblcaption, "lblcaption");
            this.lblcaption.BackColor = System.Drawing.Color.White;
            this.lblcaption.Name = "lblcaption";
            this.lblcaption.Click += new System.EventHandler(this.lblcaption_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panelback
            // 
            resources.ApplyResources(this.panelback, "panelback");
            this.panelback.BackColor = System.Drawing.Color.White;
            this.panelback.Controls.Add(this.panel1);
            this.panelback.Controls.Add(this.tabControl1);
            this.panelback.Name = "panelback";
            this.panelback.SizeChanged += new System.EventHandler(this.panelback_SizeChanged);
            this.panelback.Paint += new System.Windows.Forms.PaintEventHandler(this.panelback_Paint);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.tableLayoutPanelCurve);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelCurve
            // 
            resources.ApplyResources(this.tableLayoutPanelCurve, "tableLayoutPanelCurve");
            this.tableLayoutPanelCurve.Controls.Add(this.tableLayoutPanel15, 1, 0);
            this.tableLayoutPanelCurve.Controls.Add(this.scatterGraph, 0, 0);
            this.tableLayoutPanelCurve.Name = "tableLayoutPanelCurve";
            // 
            // scatterGraph
            // 
            resources.ApplyResources(this.scatterGraph, "scatterGraph");
            this.scatterGraph.Border = NationalInstruments.UI.Border.None;
            this.scatterGraph.Caption = "试样1";
            this.scatterGraph.CaptionBackColor = System.Drawing.Color.Transparent;
            this.scatterGraph.ContextMenuStrip = this.contextMenuStrip1;
            this.scatterGraph.Cursors.AddRange(new NationalInstruments.UI.XYCursor[] {
            this.xyCursor1});
            this.scatterGraph.ImmediateUpdates = true;
            this.scatterGraph.Name = "scatterGraph";
            this.scatterGraph.PlotAreaBorder = NationalInstruments.UI.Border.Solid;
            this.scatterGraph.PlotAreaColor = System.Drawing.Color.White;
            this.scatterGraph.Plots.AddRange(new NationalInstruments.UI.ScatterPlot[] {
            this.scatterPlot3});
            this.scatterGraph.SelectionColor = System.Drawing.Color.Silver;
            this.scatterGraph.UseColorGenerator = true;
            this.scatterGraph.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis1,
            this.xAxis2});
            this.scatterGraph.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis1,
            this.yAxis2});
            this.scatterGraph.ZoomAnimation = false;
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x轴坐标ToolStripMenuItem,
            this.y轴坐标ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // x轴坐标ToolStripMenuItem
            // 
            resources.ApplyResources(this.x轴坐标ToolStripMenuItem, "x轴坐标ToolStripMenuItem");
            this.x轴坐标ToolStripMenuItem.Name = "x轴坐标ToolStripMenuItem";
            // 
            // y轴坐标ToolStripMenuItem
            // 
            resources.ApplyResources(this.y轴坐标ToolStripMenuItem, "y轴坐标ToolStripMenuItem");
            this.y轴坐标ToolStripMenuItem.Name = "y轴坐标ToolStripMenuItem";
            this.y轴坐标ToolStripMenuItem.Click += new System.EventHandler(this.y轴坐标ToolStripMenuItem_Click);
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
            this.scatterPlot3.PointColor = System.Drawing.Color.Black;
            this.scatterPlot3.PointStyle = NationalInstruments.UI.PointStyle.SolidCircle;
            this.scatterPlot3.SmoothUpdates = true;
            this.scatterPlot3.XAxis = this.xAxis1;
            this.scatterPlot3.YAxis = this.yAxis1;
            // 
            // xAxis1
            // 
            this.xAxis1.BaseLineVisible = true;
            this.xAxis1.Caption = "位移[mm]";
            this.xAxis1.Mode = NationalInstruments.UI.AxisMode.Fixed;
            // 
            // yAxis1
            // 
            this.yAxis1.BaseLineColor = System.Drawing.Color.Black;
            this.yAxis1.BaseLineVisible = true;
            this.yAxis1.Caption = "负荷[N]";
            this.yAxis1.LeftCaptionOrientation = NationalInstruments.UI.VerticalCaptionOrientation.TopToBottom;
            this.yAxis1.MajorDivisions.TickColor = System.Drawing.Color.Black;
            this.yAxis1.Mode = NationalInstruments.UI.AxisMode.Fixed;
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
            this.yAxis2.Mode = NationalInstruments.UI.AxisMode.Fixed;
            this.yAxis2.Position = NationalInstruments.UI.YAxisPosition.Right;
            // 
            // tableLayoutPanel15
            // 
            resources.ApplyResources(this.tableLayoutPanel15, "tableLayoutPanel15");
            this.tableLayoutPanel15.Controls.Add(this.legend, 0, 1);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            // 
            // legend
            // 
            resources.ApplyResources(this.legend, "legend");
            this.legend.Border = NationalInstruments.UI.Border.Solid;
            this.legend.CaptionBackColor = System.Drawing.Color.Transparent;
            this.legend.Items.AddRange(new NationalInstruments.UI.LegendItem[] {
            this.legendItem1});
            this.legend.ItemSize = new System.Drawing.Size(20, 3);
            this.legend.Name = "legend";
            // 
            // legendItem1
            // 
            this.legendItem1.Source = this.scatterPlot3;
            this.legendItem1.Text = "Item 0";
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.userGraph1);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // userGraph1
            // 
            resources.ApplyResources(this.userGraph1, "userGraph1");
            this.userGraph1.Name = "userGraph1";
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStripLeft
            // 
            resources.ApplyResources(this.toolStripLeft, "toolStripLeft");
            this.toolStripLeft.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.toolStripLeft.Name = "toolStripLeft";
            this.toolStripLeft.Stretch = true;
            // 
            // xAxis3
            // 
            this.xAxis3.Range = new NationalInstruments.UI.Range(0D, 0.1D);
            // 
            // yAxis3
            // 
            this.yAxis3.Range = new NationalInstruments.UI.Range(0D, 0.1D);
            // 
            // scatterPlot1
            // 
            this.scatterPlot1.LineColor = System.Drawing.Color.Red;
            this.scatterPlot1.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
            this.scatterPlot1.LineWidth = 2F;
            this.scatterPlot1.XAxis = this.xAxis3;
            this.scatterPlot1.YAxis = this.yAxis3;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tsbdefault
            // 
            resources.ApplyResources(this.tsbdefault, "tsbdefault");
            this.tsbdefault.BackColor = System.Drawing.Color.Transparent;
            this.tsbdefault.Checked = true;
            this.tsbdefault.CheckOnClick = true;
            this.tsbdefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbdefault.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbdefault.Name = "tsbdefault";
            // 
            // tsbzoomin
            // 
            resources.ApplyResources(this.tsbzoomin, "tsbzoomin");
            this.tsbzoomin.CheckOnClick = true;
            this.tsbzoomin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbzoomin.Name = "tsbzoomin";
            this.tsbzoomin.Click += new System.EventHandler(this.tsbzoomin_Click);
            // 
            // tsbzoomout
            // 
            resources.ApplyResources(this.tsbzoomout, "tsbzoomout");
            this.tsbzoomout.CheckOnClick = true;
            this.tsbzoomout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbzoomout.Name = "tsbzoomout";
            this.tsbzoomout.Click += new System.EventHandler(this.tsbzoomout_Click);
            // 
            // tsbscreenreader
            // 
            resources.ApplyResources(this.tsbscreenreader, "tsbscreenreader");
            this.tsbscreenreader.CheckOnClick = true;
            this.tsbscreenreader.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbscreenreader.Name = "tsbscreenreader";
            this.tsbscreenreader.Click += new System.EventHandler(this.tsbscreenreader_Click);
            // 
            // tsbreader
            // 
            resources.ApplyResources(this.tsbreader, "tsbreader");
            this.tsbreader.CheckOnClick = true;
            this.tsbreader.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbreader.Name = "tsbreader";
            // 
            // tsbselector
            // 
            resources.ApplyResources(this.tsbselector, "tsbselector");
            this.tsbselector.CheckOnClick = true;
            this.tsbselector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbselector.Name = "tsbselector";
            // 
            // tsbtext
            // 
            resources.ApplyResources(this.tsbtext, "tsbtext");
            this.tsbtext.CheckOnClick = true;
            this.tsbtext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtext.Name = "tsbtext";
            // 
            // tsbarrow
            // 
            resources.ApplyResources(this.tsbarrow, "tsbarrow");
            this.tsbarrow.CheckOnClick = true;
            this.tsbarrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbarrow.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.tsbarrow.Name = "tsbarrow";
            // 
            // tsbline
            // 
            resources.ApplyResources(this.tsbline, "tsbline");
            this.tsbline.CheckOnClick = true;
            this.tsbline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbline.Name = "tsbline";
            // 
            // tsbrect
            // 
            resources.ApplyResources(this.tsbrect, "tsbrect");
            this.tsbrect.CheckOnClick = true;
            this.tsbrect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbrect.Name = "tsbrect";
            // 
            // tsbpoint
            // 
            resources.ApplyResources(this.tsbpoint, "tsbpoint");
            this.tsbpoint.CheckOnClick = true;
            this.tsbpoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbpoint.Name = "tsbpoint";
            // 
            // tsbcontrol
            // 
            resources.ApplyResources(this.tsbcontrol, "tsbcontrol");
            this.tsbcontrol.CheckOnClick = true;
            this.tsbcontrol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbcontrol.Name = "tsbcontrol";
            // 
            // UserControlGraph
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripLeft);
            this.Controls.Add(this.panelback);
            this.Controls.Add(this.lblcaption);
            this.Name = "UserControlGraph";
            this.Load += new System.EventHandler(this.UserControlGraph_Load);
            this.panelback.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanelCurve.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xyCursor1)).EndInit();
            this.tableLayoutPanel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.legend)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.toolStripLeft.ResumeLayout(false);
            this.toolStripLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label lblcaption;
        private System.Windows.Forms.ToolStrip toolStripLeft;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanelCurve;
        public NationalInstruments.UI.WindowsForms.ScatterGraph scatterGraph;
        private NationalInstruments.UI.XYCursor xyCursor1;
        private NationalInstruments.UI.ScatterPlot scatterPlot3;
        private NationalInstruments.UI.XAxis xAxis1;
        private NationalInstruments.UI.YAxis yAxis1;
        private NationalInstruments.UI.XAxis xAxis2;
        private NationalInstruments.UI.YAxis yAxis2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        public NationalInstruments.UI.WindowsForms.Legend legend;
        private NationalInstruments.UI.LegendItem legendItem1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem x轴坐标ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem y轴坐标ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private NationalInstruments.UI.ScatterPlot scatterPlot1;
        private NationalInstruments.UI.XAxis xAxis3;
        private NationalInstruments.UI.YAxis yAxis3;
        public AppleLabApplication.UserGraph userGraph1;
        private System.Windows.Forms.Timer timer2;
    }
}
