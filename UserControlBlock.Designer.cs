﻿namespace TabHeaderDemo
{
    partial class UserControlBlock

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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlBlock));
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tlpbottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnrightadd = new System.Windows.Forms.Button();
            this.btncut = new System.Windows.Forms.Button();
            this.btncopy = new System.Windows.Forms.Button();
            this.btnleftadd = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblcaption = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scatterGraph1 = new NationalInstruments.UI.WindowsForms.ScatterGraph();
            this.scatterPlot1 = new NationalInstruments.UI.ScatterPlot();
            this.xAxis1 = new NationalInstruments.UI.XAxis();
            this.yAxis1 = new NationalInstruments.UI.YAxis();
            this.yAxis2 = new NationalInstruments.UI.YAxis();
            this.tlpbottom.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "profilerdir0.ico");
            this.imageList2.Images.SetKeyName(1, "profilerdir2.ico");
            this.imageList2.Images.SetKeyName(2, "profilerdir1.ico");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "profiler5.ico");
            this.imageList1.Images.SetKeyName(1, "profiler5-b.ico");
            this.imageList1.Images.SetKeyName(2, "profiler4.ico");
            this.imageList1.Images.SetKeyName(3, "profiler4-b.ico");
            this.imageList1.Images.SetKeyName(4, "profiler6.ico");
            this.imageList1.Images.SetKeyName(5, "profiler6-b.ico");
            this.imageList1.Images.SetKeyName(6, "profiler7.ico");
            this.imageList1.Images.SetKeyName(7, "profiler7-b.ico");
            this.imageList1.Images.SetKeyName(8, "profiler10.ico");
            this.imageList1.Images.SetKeyName(9, "profiler10-b.ico");
            this.imageList1.Images.SetKeyName(10, "profiler12.ico");
            this.imageList1.Images.SetKeyName(11, "profiler12-b.ico");
            this.imageList1.Images.SetKeyName(12, "profiler11.ico");
            this.imageList1.Images.SetKeyName(13, "profiler11-b.ico");
            // 
            // tlpbottom
            // 
            resources.ApplyResources(this.tlpbottom, "tlpbottom");
            this.tlpbottom.Controls.Add(this.btnrightadd, 3, 0);
            this.tlpbottom.Controls.Add(this.btncut, 2, 0);
            this.tlpbottom.Controls.Add(this.btncopy, 1, 0);
            this.tlpbottom.Controls.Add(this.btnleftadd, 0, 0);
            this.tlpbottom.Name = "tlpbottom";
            this.toolTip1.SetToolTip(this.tlpbottom, resources.GetString("tlpbottom.ToolTip"));
            // 
            // btnrightadd
            // 
            resources.ApplyResources(this.btnrightadd, "btnrightadd");
            this.btnrightadd.FlatAppearance.BorderSize = 0;
            this.btnrightadd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnrightadd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnrightadd.Name = "btnrightadd";
            this.toolTip1.SetToolTip(this.btnrightadd, resources.GetString("btnrightadd.ToolTip"));
            this.btnrightadd.UseVisualStyleBackColor = true;
            this.btnrightadd.Click += new System.EventHandler(this.btnrightadd_Click);
            // 
            // btncut
            // 
            resources.ApplyResources(this.btncut, "btncut");
            this.btncut.FlatAppearance.BorderSize = 0;
            this.btncut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btncut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btncut.Name = "btncut";
            this.toolTip1.SetToolTip(this.btncut, resources.GetString("btncut.ToolTip"));
            this.btncut.UseVisualStyleBackColor = true;
            this.btncut.Click += new System.EventHandler(this.btncut_Click);
            // 
            // btncopy
            // 
            resources.ApplyResources(this.btncopy, "btncopy");
            this.btncopy.FlatAppearance.BorderSize = 0;
            this.btncopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btncopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btncopy.Name = "btncopy";
            this.toolTip1.SetToolTip(this.btncopy, resources.GetString("btncopy.ToolTip"));
            this.btncopy.UseVisualStyleBackColor = true;
            this.btncopy.Click += new System.EventHandler(this.btncopy_Click);
            // 
            // btnleftadd
            // 
            resources.ApplyResources(this.btnleftadd, "btnleftadd");
            this.btnleftadd.FlatAppearance.BorderSize = 0;
            this.btnleftadd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnleftadd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnleftadd.Name = "btnleftadd";
            this.toolTip1.SetToolTip(this.btnleftadd, resources.GetString("btnleftadd.ToolTip"));
            this.btnleftadd.UseVisualStyleBackColor = true;
            this.btnleftadd.Click += new System.EventHandler(this.btnleftadd_Click);
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.lblcaption, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tlpbottom, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // lblcaption
            // 
            resources.ApplyResources(this.lblcaption, "lblcaption");
            this.lblcaption.ForeColor = System.Drawing.Color.White;
            this.lblcaption.Name = "lblcaption";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.scatterGraph1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // scatterGraph1
            // 
            resources.ApplyResources(this.scatterGraph1, "scatterGraph1");
            this.scatterGraph1.Name = "scatterGraph1";
            this.scatterGraph1.PlotAreaBorder = NationalInstruments.UI.Border.None;
            this.scatterGraph1.Plots.AddRange(new NationalInstruments.UI.ScatterPlot[] {
            this.scatterPlot1});
            this.scatterGraph1.UseColorGenerator = true;
            this.scatterGraph1.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis1});
            this.scatterGraph1.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis1,
            this.yAxis2});
            this.scatterGraph1.ZoomAnimation = false;
            this.scatterGraph1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.scatterGraph1_MouseDoubleClick);
            // 
            // scatterPlot1
            // 
            this.scatterPlot1.XAxis = this.xAxis1;
            this.scatterPlot1.YAxis = this.yAxis1;
            // 
            // xAxis1
            // 
            this.xAxis1.CaptionVisible = false;
            this.xAxis1.EndLabelsAlwaysVisible = false;
            this.xAxis1.Visible = false;
            // 
            // yAxis1
            // 
            this.yAxis1.Visible = false;
            // 
            // yAxis2
            // 
            this.yAxis2.BaseLineColor = System.Drawing.Color.Blue;
            this.yAxis2.BaseLineVisible = true;
            this.yAxis2.CaptionPosition = NationalInstruments.UI.YAxisPosition.Right;
            this.yAxis2.CaptionVisible = false;
            this.yAxis2.MajorDivisions.LabelVisible = false;
            this.yAxis2.MajorDivisions.TickVisible = false;
            this.yAxis2.Position = NationalInstruments.UI.YAxisPosition.Right;
            // 
            // UserControlBlock
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "UserControlBlock";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControlStep_Paint);
            this.DoubleClick += new System.EventHandler(this.UserControlStep_DoubleClick);
            this.Enter += new System.EventHandler(this.UserControlStep_Enter);
            this.Leave += new System.EventHandler(this.UserControlStep_Leave);
            this.tlpbottom.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        public System.Windows.Forms.Label lblcaption;
        private System.Windows.Forms.TableLayoutPanel tlpbottom;
        private System.Windows.Forms.Button btnrightadd;
        private System.Windows.Forms.Button btncut;
        private System.Windows.Forms.Button btncopy;
        private System.Windows.Forms.Button btnleftadd;
        private System.Windows.Forms.Panel panel1;
        private NationalInstruments.UI.WindowsForms.ScatterGraph scatterGraph1;
        private NationalInstruments.UI.ScatterPlot scatterPlot1;
        private NationalInstruments.UI.XAxis xAxis1;
        private NationalInstruments.UI.YAxis yAxis1;
        private NationalInstruments.UI.YAxis yAxis2;
    }
}
