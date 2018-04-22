using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClsStaticStation;
using System.IO;
namespace TabHeaderDemo
{
    public partial class UserControlGraph : UserControl
    {
        double msavestartime = 0;
        bool msavebool = false;

        double mdogtimelast = 0;

        double mdogstarttime = 0;

        string  s_sensor5state0 ="";
        string  s_sensor5state1 ="";
        string  s_sensor5state2 ="";
        string  s_sensor6state0 ="";
        string  s_sensor6state1 ="";
        string  s_sensor6state2 ="";
        string  s_sensor7state0 ="";
        string  s_sensor7state1 ="";
        string  s_sensor7state2 ="";

        string  s_sensor5state3 ="";
        string  s_sensor6state3 ="";
        string  s_sensor7state3 ="";
        string  s_sensor5state4 ="";
        string  s_sensor6state4 ="";
        string  s_sensor7state4 ="";
        string  s_sensor5state5 ="";
        string  s_sensor6state5 ="";
        string  s_sensor7state5 ="";

        bool m_sensor5state0 = false;
        bool m_sensor5state1 = false;
        bool m_sensor5state2 = false;
        bool m_sensor6state0 = false;
        bool m_sensor6state1 = false;
        bool m_sensor6state2 = false;
        bool m_sensor7state0 = false;
        bool m_sensor7state1 = false;
        bool m_sensor7state2 = false;

        bool m_sensor5state3 = false;
        bool m_sensor6state3 = false;
        bool m_sensor7state3 = false;
        bool m_sensor5state4 = false;
        bool m_sensor6state4 = false;
        bool m_sensor7state4 = false;
        bool m_sensor5state5 = false;
        bool m_sensor6state5 = false;
        bool m_sensor7state5 = false;


        int m_sensor5state3count = 0;
        int m_sensor6state3count = 0;
        int m_sensor7state3count = 0;

        int m_sensor5state4count = 0;
        int m_sensor6state4count = 0;
        int m_sensor7state4count = 0;

        int m_sensor5state5count = 0;
        int m_sensor6state5count = 0;
        int m_sensor7state5count = 0;

        private class rawdata
        {
            public int len;
            public double[] data;
            public rawdata()
            {
                data = new double[20];
            }
        };

        List<rawdata> mrawdatalist;
        rawdata mrawdata;

        public long count = 0;
        public CComLibrary.PlotSettings myplotsettings;
        private int mplot1;
        private RawDataDataGroup[] r = new RawDataDataGroup[1];
        private RawDataStruct b;
        public Queue<RawDataStruct> myarraydata;
        string mspefiledat;

        public double tstart;

        public double maxload;

        private double mstarttime;
        int mk = 0;
        public void RefreshCaption()
        {
            string s;
            if (mplot1 == 1)
            {
                s = myplotsettings.curvekind1_curvecaption;
                s = s.Replace("%n", (CComLibrary.GlobeVal.filesave.currentspenumber + 1).ToString());
                s = s.Replace("%m", CComLibrary.GlobeVal.filesave.mspecount.ToString());

                scatterGraph.Caption = s;
            }

            if (mplot1 == 2)
            {
                s = myplotsettings.curvekind2_curvecaption;
                s = s.Replace("%n", (CComLibrary.GlobeVal.filesave.currentspenumber + 1).ToString());
                s = s.Replace("%m", CComLibrary.GlobeVal.filesave.mspecount.ToString());

                scatterGraph.Caption = s;

            }


        }
        public void startrun()
        {
            RawDataDataGroup d;
            string s;
            count = 0;
            int mk;
            tstart = 0;
            maxload = 0;
            mstarttime = 0;

             mdogtimelast = 0;

             mdogstarttime = 0;

            mrawdatalist = new List<TabHeaderDemo.UserControlGraph.rawdata>();

            s_sensor5state0 = "";
            s_sensor6state0 = "";
            s_sensor7state0 = "";
            s_sensor5state1 = "";
            s_sensor6state1 = "";
            s_sensor7state1 = "";
            s_sensor5state2 = "";
            s_sensor6state2 = "";
            s_sensor7state2 = "";
            s_sensor5state3 = "";
            s_sensor6state3 = "";
            s_sensor7state3 = "";
            s_sensor5state4 = "";
            s_sensor6state4 = "";
            s_sensor7state4 = "";
            s_sensor5state5 = "";
            s_sensor6state5 = "";
            s_sensor7state5 = "";


            m_sensor5state0 = false;
            m_sensor5state1 = false;
            m_sensor5state2 = false;
            m_sensor6state0 = false;
            m_sensor6state1 = false;
            m_sensor6state2 = false;
            m_sensor7state0 = false;
            m_sensor7state1 = false;
            m_sensor7state2 = false;
            
            m_sensor5state3 = false;
            m_sensor5state4 = false;
            m_sensor5state5 = false;
            m_sensor5state3count = 0;
            m_sensor5state4count = 0;
            m_sensor5state5count = 0;
            m_sensor6state3 = false;
            m_sensor6state4 = false;
            m_sensor6state5 = false;
            m_sensor6state3count = 0;
            m_sensor6state4count = 0;
            m_sensor6state5count = 0;
            m_sensor7state3 = false;
            m_sensor7state4 = false;
            m_sensor7state5 = false;
            m_sensor7state3count = 0;
            m_sensor7state4count = 0;
            m_sensor7state5count = 0;

            if (myplotsettings.curvekind == 1)
            {
                scatterGraph.ClearData();
            }
            else
            {
                mk = (CComLibrary.GlobeVal.filesave.currentspenumber + 1) % myplotsettings.curvecount;
                if (mk == 0)
                {
                    mk = myplotsettings.curvecount;
                }
                if (mk == 1)
                {
                    scatterGraph.ClearData();
                }
                scatterGraph.Plots[mk - 1].ClearData();
            }



            if (mplot1 == 1)
            {
                mspefiledat = GlobeVal.mysys.SamplePath + "\\" + GlobeVal.mysys.SampleFile + "-" +
                    (CComLibrary.GlobeVal.filesave.currentspenumber + 1).ToString().Trim() + ".txt";


                if (File.Exists(mspefiledat) == true)
                {
                    File.Delete(mspefiledat);

                }

                FileStream fs = new FileStream(mspefiledat, FileMode.CreateNew);

                using (StreamWriter w = new StreamWriter(fs, System.Text.Encoding.Default))
                {

                    s = "";

                    for (int i = 0; i < CComLibrary.GlobeVal.filesave.mrawdata.Count; i++)
                    {
                        s = s + CComLibrary.GlobeVal.filesave.mrawdata[i].cName + " ";
                    }

                    w.WriteLine(s);

                    s = "";
                    for (int i = 0; i < CComLibrary.GlobeVal.filesave.mrawdata.Count; i++)
                    {
                        s = s + CComLibrary.GlobeVal.filesave.mrawdata[i].cUnits[CComLibrary.GlobeVal.filesave.mrawdata[i].cUnitsel] + " ";
                    }
                    w.WriteLine(s);


                }
                fs.Close();
            }

            myarraydata.Clear();

            timer1.Enabled = true;
        }

        public void endrun()
        {
            timer1.Enabled = false;

        }
        public void Init曲线(int plot)
        {
            userGraph1.datapath = GlobeVal.mysys.SamplePath;

            tabControl1.ItemSize = new Size(1, 1);

            if (plot == 1)
            {
                myplotsettings = CComLibrary.GlobeVal.filesave.mplotpara1;
                lblcaption.Text = "曲线图1";
                lblcaption.Tag = true;


            }

            if (plot == 2)
            {
                myplotsettings = CComLibrary.GlobeVal.filesave.mplotpara2;
                lblcaption.Text = "曲线图2";
                lblcaption.Tag = "";
            }


            if (myplotsettings.curvekind == 2)
            {
                scatterGraph.ContextMenuStrip = null;
            }
            else if (myplotsettings.curvekind == 1)
            {
                scatterGraph.ContextMenuStrip = null;
            }
            else
            {
                scatterGraph.ContextMenuStrip = contextMenuStrip1;
            }


            scatterGraph.Plots.Clear();
            legend.Items.Clear();
            NationalInstruments.UI.ScatterPlot mplot;
            NationalInstruments.UI.LegendItem mlegitem;

            if (myplotsettings.curvekind != 2)
            {

                if ((myplotsettings.ychannel[0] >= 0) && (myplotsettings.ychannel[0] < ClsStaticStation.m_Global.mycls.allsignals.Count))
                {

                }
                else
                {
                    myplotsettings.ychannel[0] = 0;
                }

                if ((myplotsettings.xchannel >= 0) && (myplotsettings.xchannel < ClsStaticStation.m_Global.mycls.allsignals.Count))
                {

                }
                else
                {
                    myplotsettings.xchannel = 0;
                }


                if ((myplotsettings.ychannelunit[0] >= 0) && (myplotsettings.ychannelunit[0] < ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[0]].cUnitCount))
                {
                }
                else
                {
                    myplotsettings.ychannelunit[0] = 0;
                }


                if ((myplotsettings.xchannelunit >= 0) && (myplotsettings.xchannelunit < ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cUnitCount))
                {
                }
                else
                {
                    myplotsettings.xchannelunit = 0;
                }

            }
            x轴坐标ToolStripMenuItem.DropDownItems.Clear();
            y轴坐标ToolStripMenuItem.DropDownItems.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.allsignals.Count; i++)
            {
                ToolStripMenuItem ts_x = new ToolStripMenuItem(ClsStaticStation.m_Global.mycls.allsignals[i].cName);
                ts_x.Tag = i;
                ts_x.Click += Ts_x_Click;

                ToolStripMenuItem ts_y = new ToolStripMenuItem(ClsStaticStation.m_Global.mycls.allsignals[i].cName);
                ts_y.Tag = i;
                ts_y.Click += Ts_y_Click;

                if (myplotsettings.xchannel == i)
                {
                    ts_x.Checked = true;
                }

                if (myplotsettings.ychannel[0] == i)
                {
                    ts_y.Checked = true;
                }

                x轴坐标ToolStripMenuItem.DropDownItems.Add(ts_x);


                y轴坐标ToolStripMenuItem.DropDownItems.Add(ts_y);
            }


            if ((myplotsettings.curvekind == 0) || (myplotsettings.curvekind == 2))
            {
                scatterGraph.YAxes[0].Visible = true;
                scatterGraph.YAxes[1].Visible = false;


                if (myplotsettings.curvekind == 2)
                {
                    scatterGraph.YAxes[0].Caption = "";
                    for (int i = 0; i < myplotsettings.curvecount; i++)
                    {
                        scatterGraph.YAxes[0].Caption = scatterGraph.YAxes[0].Caption + ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[i]].cName + "[" +
                       ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[i]].cUnits[myplotsettings.ychannelunit[i]] + "]" + ",";
                    }
                }
                else
                {
                    scatterGraph.YAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[0]].cName + "[" +
                    ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[0]].cUnits[myplotsettings.ychannelunit[0]] + "]";
                }

                scatterGraph.XAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cName + "[" +
                ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cUnits[myplotsettings.xchannelunit] + "]";


                //scatterGraph.YAxes[0].Caption =myplotsettings.
                for (int i = 0; i < myplotsettings.curvecount; i++)
                {

                    mplot = new NationalInstruments.UI.ScatterPlot();
                    mplot.LineColor = myplotsettings.PlotLineColor[i];
                    mplot.LineStyle = myplotsettings.PlotLineStyle[i];
                    mplot.PointStyle = myplotsettings.PlotLinePointStyle[i];
                    mplot.PointSize = new Size(myplotsettings.PlotLineSize[i], myplotsettings.PlotLineSize[i]);
                    mplot.PointColor = myplotsettings.PlotLinePointColor[i];
                    mplot.LineWidth = myplotsettings.PlotLinePointSize[i];
                    mplot.HistoryCapacity = 30000;
                    scatterGraph.Plots.Add(mplot);





                    mplot.ClearData();

                    mlegitem = new NationalInstruments.UI.LegendItem();
                    mlegitem.Source = mplot;
                    mlegitem.Text = (i + 1).ToString().Trim();
                    legend.Items.Add(mlegitem);


                }

                if (myplotsettings.curvecount >= 2)
                {
                    scatterGraph.Plots[1].YAxis = yAxis1;

                }
            }


            if (myplotsettings.curvekind == 1)
            {
                int i;

                i = 0;
                scatterGraph.YAxes[0].Visible = true;
                scatterGraph.YAxes[1].Visible = true;

                scatterGraph.YAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[0]].cName + "[" +
               ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[0]].cUnits[myplotsettings.ychannelunit[0]] + "]";

                scatterGraph.XAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cName + "[" +
                ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cUnits[myplotsettings.xchannelunit] + "]";

                scatterGraph.YAxes[1].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cName + "[" +
                ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cUnits[myplotsettings.y1channelunit] + "]";



                mplot = new NationalInstruments.UI.ScatterPlot();
                mplot.LineColor = myplotsettings.PlotLineColor[i];
                mplot.LineStyle = myplotsettings.PlotLineStyle[i];
                mplot.PointStyle = myplotsettings.PlotLinePointStyle[i];
                mplot.PointSize = new Size(myplotsettings.PlotLineSize[i], myplotsettings.PlotLineSize[i]);
                mplot.PointColor = myplotsettings.PlotLinePointColor[i];
                mplot.LineWidth = myplotsettings.PlotLinePointSize[i];
                mplot.HistoryCapacity = 30000;
                scatterGraph.Plots.Add(mplot);

                mplot.ClearData();

                mlegitem = new NationalInstruments.UI.LegendItem();
                mlegitem.Source = mplot;
                mlegitem.Text = (i + 1).ToString().Trim();
                legend.Items.Add(mlegitem);

                i = 1;

                mplot = new NationalInstruments.UI.ScatterPlot();
                mplot.LineColor = myplotsettings.PlotLineColor[i];
                mplot.LineStyle = myplotsettings.PlotLineStyle[i];
                mplot.PointStyle = myplotsettings.PlotLinePointStyle[i];
                mplot.PointSize = new Size(myplotsettings.PlotLineSize[i], myplotsettings.PlotLineSize[i]);
                mplot.PointColor = myplotsettings.PlotLinePointColor[i];
                mplot.LineWidth = myplotsettings.PlotLinePointSize[i];
                scatterGraph.Plots.Add(mplot);

                mplot.ClearData();

                mlegitem = new NationalInstruments.UI.LegendItem();
                mlegitem.Source = mplot;
                mlegitem.Text = (i + 1).ToString().Trim();
                legend.Items.Add(mlegitem);

                mplot.YAxis = yAxis2;


            }

            if (myplotsettings.xmin == myplotsettings.xmax)
            {
                scatterGraph.XAxes[0].Range = new NationalInstruments.UI.Range(myplotsettings.xmin, myplotsettings.xmax + 1);
            }
            else
            {
                scatterGraph.XAxes[0].Range = new NationalInstruments.UI.Range(myplotsettings.xmin, myplotsettings.xmax);
            }

            if (myplotsettings.ymin == myplotsettings.ymax)
            {
                scatterGraph.YAxes[0].Range = new NationalInstruments.UI.Range(myplotsettings.ymin, myplotsettings.ymax + 1);
            }
            else
            {
                scatterGraph.YAxes[0].Range = new NationalInstruments.UI.Range(myplotsettings.ymin, myplotsettings.ymax);
            }

            if (myplotsettings.y1min == myplotsettings.y1max)
            {
                scatterGraph.YAxes[1].Range = new NationalInstruments.UI.Range(myplotsettings.y1min, myplotsettings.y1max + 1);
            }
            else
            {
                scatterGraph.YAxes[1].Range = new NationalInstruments.UI.Range(myplotsettings.y1min, myplotsettings.y1max);
            }
            if (myplotsettings.y1channelzoom == true)
            {
                scatterGraph.YAxes[1].Mode = NationalInstruments.UI.AxisMode.AutoScaleLoose;
            }
            else
            {
                scatterGraph.YAxes[1].Mode = NationalInstruments.UI.AxisMode.Fixed;
            }

            if (myplotsettings.xchannelzoom == true)
            {
                scatterGraph.YAxes[0].Mode = NationalInstruments.UI.AxisMode.AutoScaleLoose;
            }
            else
            {
                scatterGraph.YAxes[0].Mode = NationalInstruments.UI.AxisMode.Fixed;
            }

            if (myplotsettings.xchannelzoom == true)
            {
                scatterGraph.XAxes[0].Mode = NationalInstruments.UI.AxisMode.AutoScaleLoose;
            }
            else
            {
                scatterGraph.XAxes[0].Mode = NationalInstruments.UI.AxisMode.Fixed;
            }



            xyCursor1.Plot = scatterGraph.Plots[0];

            if (myplotsettings.showdatapointer == true)
            {
                toolStripLeft.Visible = true;

            }
            else
            {
                toolStripLeft.Visible = false;
            }
            mplot1 = plot;


        }
        private void change曲线标题()
        {
            if ((myplotsettings.curvekind == 0) || (myplotsettings.curvekind == 2))
            {
                scatterGraph.YAxes[0].Visible = true;
                scatterGraph.YAxes[1].Visible = false;



                scatterGraph.YAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[0]].cName + "[" +
                ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[0]].cUnits[myplotsettings.ychannelunit[0]] + "]";

                scatterGraph.XAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cName + "[" +
                ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cUnits[myplotsettings.xchannelunit] + "]";
            }


            if (myplotsettings.curvekind == 1)
            {


                scatterGraph.YAxes[0].Visible = true;
                scatterGraph.YAxes[1].Visible = true;

                scatterGraph.YAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[0]].cName + "[" +
               ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[0]].cUnits[myplotsettings.ychannelunit[0]] + "]";

                scatterGraph.XAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cName + "[" +
                ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cUnits[myplotsettings.xchannelunit] + "]";

                scatterGraph.YAxes[1].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cName + "[" +
                ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cUnits[myplotsettings.y1channelunit] + "]";


            }
        }
        private void Ts_y_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < y轴坐标ToolStripMenuItem.DropDownItems.Count; i++)
            {
                (y轴坐标ToolStripMenuItem.DropDownItems[i] as ToolStripMenuItem).Checked = false;
            }

            int a = Convert.ToInt16((sender as ToolStripMenuItem).Tag);

            (sender as ToolStripMenuItem).Checked = true;
            myplotsettings.ychannel[0] = a;
            scatterGraph.ClearData();

            change曲线标题();
        }

        private void Ts_x_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < x轴坐标ToolStripMenuItem.DropDownItems.Count; i++)
            {
                (x轴坐标ToolStripMenuItem.DropDownItems[i] as ToolStripMenuItem).Checked = false;
            }

            int a = Convert.ToInt16((sender as ToolStripMenuItem).Tag);

            (sender as ToolStripMenuItem).Checked = true;

            myplotsettings.xchannel = a;
            scatterGraph.ClearData();

            change曲线标题();
        }

        public UserControlGraph()
        {

            InitializeComponent();
            myarraydata = new Queue<RawDataStruct>();
            mplot1 = 0;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲


            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel1, true, null);
            tabControl1.ItemSize = new Size(1, 1);

        }

        private void panelback_SizeChanged(object sender, EventArgs e)
        {

        }

        private void panelback_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanelCurve_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double sensor5 = 0;
            double sensor6 = 0;
            double sensor7 = 0;
            int j = 0;
            int k = 0;
            double xi = 0;
            double yi = 0;
            double y1i = 0;
            double mtime = 0;

            long mcount = 0;

            double v = 0;

            double mload = 0;
            string s;

            timer1.Enabled = false;
            int ll = 0;

            ll = ClsStatic.arraydata[mplot1 - 1].Read<RawDataDataGroup>(r, 0, 10);

            if (ll == 0)
            {
            }
            else
            {
                ClsStatic.arraydatacount[mplot1 - 1] = ClsStatic.arraydatacount[mplot1 - 1] - 1;
            }

           // if ((System.Environment.TickCount - mdogstarttime)>10)
             {
                //mdogstarttime = System.Environment.TickCount;

            }

            while (ll != 0)
            {
                b = new RawDataStruct();
                b.data = new double[24];


                m_Global.mycls.structcopy_RawDataStruct(r[0].rdata, ref b);


                myarraydata.Enqueue(b);


                ll = ClsStatic.arraydata[mplot1 - 1].Read<RawDataDataGroup>(r, 0, 10);

                if (ll == 0)
                {
                    break;
                }
                else
                {
                    ClsStatic.arraydatacount[mplot1 - 1] = ClsStatic.arraydatacount[mplot1 - 1] - 1;
                }
            }

            while (myarraydata.Count > 0)
            {

                b = myarraydata.Dequeue();



                count = count + 1;

                for (int i = 0; i < m_Global.mycls.datalist.Count; i++)
                {

                    if (m_Global.mycls.datalist[i].SignName == m_Global.mycls.allsignals[myplotsettings.xchannel].SignName)
                    {

                        xi = Convert.ToDouble(m_Global.mycls.allsignals[myplotsettings.xchannel].GetValueFromUnit(b.data[m_Global.mycls.datalist[i].EdcId],
                            myplotsettings.xchannelunit));

                    }

                    if (m_Global.mycls.datalist[i].SignName == ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[0]].SignName)

                    {

                        yi = Convert.ToDouble(m_Global.mycls.allsignals[myplotsettings.ychannel[0]].GetValueFromUnit(b.data[m_Global.mycls.datalist[i].EdcId],
                           myplotsettings.ychannelunit[0]));


                    }

                    if (m_Global.mycls.datalist[i].SignName == ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].SignName)
                    {

                        y1i = Convert.ToDouble(m_Global.mycls.allsignals[myplotsettings.y1channel].GetValueFromUnit(b.data[m_Global.mycls.datalist[i].EdcId],
                           myplotsettings.y1channelunit));


                    }

                    if (m_Global.mycls.datalist[i].SignName == "Ch Time")
                    {
                        mtime = b.data[m_Global.mycls.datalist[i].EdcId];
                    }

                    if (m_Global.mycls.datalist[i].SignName == "Ch Load")
                    {
                        mload = b.data[m_Global.mycls.datalist[i].EdcId];
                    }

                    if (m_Global.mycls.datalist[i].SignName == "Ch Count")
                    {
                        mcount = Convert.ToInt32(b.data[m_Global.mycls.datalist[i].EdcId]);
                    }
                }


                // if ( Math.Abs(mtime - mstarttime) >= 0.01)
                {






                    if ((myplotsettings.curvekind == 0))
                    {
                        if (CComLibrary.GlobeVal.filesave.Samplingmode == 1)//动态采集
                        {
                            mk = (CComLibrary.GlobeVal.filesave.currentspenumber + 1) % myplotsettings.curvecount;
                            if (mk == 0)
                            {
                                mk = myplotsettings.curvecount;
                            }

                            if (myplotsettings.curveoffset == 0)
                            {

                                scatterGraph.Plots[mk - 1].PlotXYAppend(xi, yi);
                            }

                            if (myplotsettings.curveoffset == 1)
                            {

                                scatterGraph.Plots[mk - 1].PlotXYAppend(xi + 0.1 * (mk - 1), yi);
                            }

                            if (myplotsettings.curveoffset == 2)
                            {

                                scatterGraph.Plots[mk - 1].PlotXYAppend(xi, yi + 0.1 * (mk - 1));
                            }

                            if (myplotsettings.curveoffset == 3)
                            {

                                scatterGraph.Plots[mk - 1].PlotXYAppend(xi + 0.1 * (mk - 1), yi + 0.1 * (mk - 1));
                            }

                            if (myplotsettings.dynamicdraw == true)
                            {
                                if (scatterGraph.Plots[mk - 1].HistoryCount >= myplotsettings.dynamicpointcount)

                                {
                                    scatterGraph.Plots[mk - 1].ClearData();
                                }
                            }

                            if (xi > scatterGraph.Plots[mk - 1].XAxis.Range.Maximum)
                            {
                                scatterGraph.Plots[mk - 1].XAxis.Range = new NationalInstruments.UI.Range(xi, xi + 10);

                            }
                        }
                        else
                        {
                            if (Math.Abs(mtime - mstarttime) >= 1 / CComLibrary.GlobeVal.filesave.SampleInterval)
                            {
                                mstarttime = mtime;

                                mk = (CComLibrary.GlobeVal.filesave.currentspenumber + 1) % myplotsettings.curvecount;
                                if (mk == 0)
                                {
                                    mk = myplotsettings.curvecount;
                                }

                                if (myplotsettings.curveoffset == 0)
                                {

                                    scatterGraph.Plots[mk - 1].PlotXYAppend(xi, yi);
                                }

                                if (myplotsettings.curveoffset == 1)
                                {

                                    scatterGraph.Plots[mk - 1].PlotXYAppend(xi + 0.1 * (mk - 1), yi);
                                }

                                if (myplotsettings.curveoffset == 2)
                                {

                                    scatterGraph.Plots[mk - 1].PlotXYAppend(xi, yi + 0.1 * (mk - 1));
                                }

                                if (myplotsettings.curveoffset == 3)
                                {

                                    scatterGraph.Plots[mk - 1].PlotXYAppend(xi + 0.1 * (mk - 1), yi + 0.1 * (mk - 1));
                                }

                                if (myplotsettings.dynamicdraw == true)
                                {
                                    if (scatterGraph.Plots[mk - 1].HistoryCount >= myplotsettings.dynamicpointcount)

                                    {
                                        scatterGraph.Plots[mk - 1].ClearData();
                                    }
                                }

                                if (xi > scatterGraph.Plots[mk - 1].XAxis.Range.Maximum)
                                {
                                    scatterGraph.Plots[mk - 1].XAxis.Range = new NationalInstruments.UI.Range(xi, xi + 10);

                                }
                            }
                        }

                    }
                    if ((myplotsettings.curvekind == 1))
                    {
                        if (CComLibrary.GlobeVal.filesave.Samplingmode == 1)//动态采集
                        {
                            scatterGraph.Plots[0].PlotXYAppend(xi, yi);
                            scatterGraph.Plots[1].PlotXYAppend(xi, y1i);

                            if (myplotsettings.dynamicdraw == true)
                            {
                                if (scatterGraph.Plots[0].HistoryCount >= myplotsettings.dynamicpointcount)

                                {
                                    scatterGraph.Plots[0].ClearData();
                                    scatterGraph.Plots[1].ClearData();
                                }

                                if (xi > scatterGraph.Plots[k].XAxis.Range.Maximum)
                                {
                                    scatterGraph.Plots[k].XAxis.Range = new NationalInstruments.UI.Range(xi, xi + 10);

                                }
                            }
                        }
                        else
                        {
                            if (Math.Abs(mtime - mstarttime) >= 1 / CComLibrary.GlobeVal.filesave.SampleInterval)
                            {
                                mstarttime = mtime;
                                scatterGraph.Plots[0].PlotXYAppend(xi, yi);
                                scatterGraph.Plots[1].PlotXYAppend(xi, y1i);

                                if (myplotsettings.dynamicdraw == true)
                                {
                                    if (scatterGraph.Plots[0].HistoryCount >= myplotsettings.dynamicpointcount)

                                    {
                                        scatterGraph.Plots[0].ClearData();
                                        scatterGraph.Plots[1].ClearData();
                                    }

                                    if (xi > scatterGraph.Plots[k].XAxis.Range.Maximum)
                                    {
                                        scatterGraph.Plots[k].XAxis.Range = new NationalInstruments.UI.Range(xi, xi + 10);

                                    }
                                }
                            }
                        }

                    }


                    if (myplotsettings.curvekind == 2)
                    {
                        if (CComLibrary.GlobeVal.filesave.Samplingmode == 1)//动态采集
                        {

                            for (k = 0; k < myplotsettings.curvecount; k++)
                            {
                                for (int i = 0; i < m_Global.mycls.datalist.Count; i++)
                                {


                                    if (m_Global.mycls.datalist[i].SignName == ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[k]].SignName)

                                    {

                                        yi = Convert.ToDouble(m_Global.mycls.allsignals[myplotsettings.ychannel[k]].GetValueFromUnit(b.data[m_Global.mycls.datalist[i].EdcId],
                                           myplotsettings.ychannelunit[k]));


                                    }
                                }

                                scatterGraph.Plots[k].PlotXYAppend(xi, yi);

                                if (xi > scatterGraph.Plots[k].XAxis.Range.Maximum)
                                {
                                    scatterGraph.Plots[k].XAxis.Range = new NationalInstruments.UI.Range(xi, xi + 10);

                                }

                                if (xi < scatterGraph.Plots[k].XAxis.Range.Minimum)
                                {
                                    scatterGraph.Plots[k].XAxis.Range = new NationalInstruments.UI.Range(xi, xi + 10);

                                }
                            }

                            if (myplotsettings.dynamicdraw == true)
                            {
                                if (scatterGraph.Plots[0].HistoryCount >= myplotsettings.dynamicpointcount)

                                {
                                    for (int i = 0; i < myplotsettings.curvecount; i++)
                                    {
                                        scatterGraph.Plots[i].ClearData();
                                    }
                                }
                            }
                        }

                        else
                        {
                            if (Math.Abs(mtime - mstarttime) >= 1 / CComLibrary.GlobeVal.filesave.SampleInterval)
                            {
                                mstarttime = mtime;
                                for (k = 0; k < myplotsettings.curvecount; k++)
                                {
                                    for (int i = 0; i < m_Global.mycls.datalist.Count; i++)
                                    {


                                        if (m_Global.mycls.datalist[i].SignName == ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[k]].SignName)

                                        {

                                            yi = Convert.ToDouble(m_Global.mycls.allsignals[myplotsettings.ychannel[k]].GetValueFromUnit(b.data[m_Global.mycls.datalist[i].EdcId],
                                               myplotsettings.ychannelunit[k]));


                                        }
                                    }

                                    scatterGraph.Plots[k].PlotXYAppend(xi, yi);

                                    if (xi > scatterGraph.Plots[k].XAxis.Range.Maximum)
                                    {
                                        scatterGraph.Plots[k].XAxis.Range = new NationalInstruments.UI.Range(xi, xi + 10);

                                    }

                                    if (xi < scatterGraph.Plots[k].XAxis.Range.Minimum)
                                    {
                                        scatterGraph.Plots[k].XAxis.Range = new NationalInstruments.UI.Range(xi, xi + 10);

                                    }
                                }

                                if (myplotsettings.dynamicdraw == true)
                                {
                                    if (scatterGraph.Plots[0].HistoryCount >= myplotsettings.dynamicpointcount)

                                    {
                                        for (int i = 0; i < myplotsettings.curvecount; i++)
                                        {
                                            scatterGraph.Plots[i].ClearData();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (mplot1 == 1)
                {
                    if (CComLibrary.GlobeVal.filesave.Samplingmode == 1)//动态采集
                    {
                        string fname = "";
                        s = "";

                        mrawdata = new rawdata();
                        mrawdata.len = CComLibrary.GlobeVal.filesave.mrawdata.Count;

                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mrawdata.Count; i++)
                        {

                            for (j = 0; j < ClsStaticStation.m_Global.mycls.datalist.Count; j++)
                            {
                                if (ClsStaticStation.m_Global.mycls.datalist[j].SignName == CComLibrary.GlobeVal.filesave.mrawdata[i].SignName)
                                {
                                    k = ClsStaticStation.m_Global.mycls.datalist[j].EdcId;


                                    double.TryParse(CComLibrary.GlobeVal.filesave.mrawdata[i].GetValueFromUnit(b.data[k],
                                        CComLibrary.GlobeVal.filesave.mrawdata[i].cUnitsel), out v);

                                    mrawdata.data[i] = v;

                                }
                            }
                        }

                        if (mrawdatalist.Count < CComLibrary.GlobeVal.filesave.SamplingCount)
                        {
                            mrawdatalist.Add(mrawdata);
                        }
                        else
                        {
                            mrawdatalist.RemoveAt(0);
                            mrawdatalist.Add(mrawdata);
                        }
                        if (Math.Abs(mtime - msavestartime) >= 10)
                        {
                            msavestartime = mtime;
                            msavebool = false;
                        }

                        if (((Convert.ToInt64(mtime) % (CComLibrary.GlobeVal.filesave.SamplingInterval * 60)) == (CComLibrary.GlobeVal.filesave.SamplingInterval * 60 - 1))
                            && (msavebool == false))
                        {
                            msavebool = true;

                            fname = GlobeVal.mysys.SamplePath + "\\" + GlobeVal.mysys.SampleFile + "-" +
                               (CComLibrary.GlobeVal.filesave.currentspenumber + 1).ToString().Trim() + "_" + mcount.ToString() + ".txt";


                            if (File.Exists(fname) == true)
                            {
                                File.Delete(fname);

                            }

                            FileStream fs = new FileStream(fname, FileMode.CreateNew);

                            using (StreamWriter w = new StreamWriter(fs, System.Text.Encoding.Default))
                            {

                                s = "";

                                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mrawdata.Count; i++)
                                {
                                    s = s + CComLibrary.GlobeVal.filesave.mrawdata[i].cName + " ";
                                }

                                w.WriteLine(s);

                                s = "";
                                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mrawdata.Count; i++)
                                {
                                    s = s + CComLibrary.GlobeVal.filesave.mrawdata[i].cUnits[CComLibrary.GlobeVal.filesave.mrawdata[i].cUnitsel] + " ";
                                }
                                w.WriteLine(s);

                                for (int i = 0; i < mrawdatalist.Count; i++)
                                {
                                    s = "";

                                    for (int jj = 0; jj < mrawdatalist[i].len; jj++)
                                    {
                                        s = s + mrawdatalist[i].data[jj].ToString() + " ";
                                    }
                                    w.WriteLine(s);
                                }



                                int m1 = 0;
                                int m2 = 0;
                                int m3 = 0;

                                
                                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mrawdata.Count; i++)
                                {
                                    if (CComLibrary.GlobeVal.filesave.mrawdata[i].cName == "测量1")
                                    {
                                        m1 = i;
                                    }

                                    if (CComLibrary.GlobeVal.filesave.mrawdata[i].cName == "测量2")
                                    {
                                        m2 = i;
                                    }

                                    if (CComLibrary.GlobeVal.filesave.mrawdata[i].cName == "测量3")
                                    {
                                        m3 = i;
                                    }

                                }

                                if ((CComLibrary.GlobeVal.filesave.Samplecheck) && (GlobeVal.myarm.m_dianyabaohucontrol = true))
                                {
                                    for (int jj = 0; jj < mrawdatalist.Count; jj++)
                                    {

                                        sensor5 = mrawdatalist[jj].data[m1];

                                        sensor6 = mrawdatalist[jj].data[m2];
                                        sensor7 = mrawdatalist[jj].data[m3];


                                        if ((sensor5 > 1.636) && (sensor5 < 1.736))
                                        {
                                           
                                            m_sensor5state3count = m_sensor5state3count + 1;

                                            if (m_sensor5state3count >= 10)
                                            {
                                                s_sensor5state3 = " 测量1 1.636-1.736";
                                                m_sensor5state3 = true;
                                            }
                                        }
                                        if ((sensor6 > 1.636) && (sensor6 < 1.736))
                                        {
                                           

                                            m_sensor6state3count = m_sensor6state3count + 1;
                                            if (m_sensor6state3count >= 10)
                                            {
                                                s_sensor6state3 = " 测量2 1.636-1.736";
                                                m_sensor6state3 = true;
                                            }
                                        }
                                        if ((sensor7 > 1.636) && (sensor7 < 1.736))
                                        {
                                           

                                            m_sensor7state3count = m_sensor7state3count + 1;
                                            if (m_sensor7state3count >= 10)
                                            {
                                                s_sensor7state3 = " 测量3 1.636-1.736";
                                                m_sensor7state3 = true;
                                            }

                                        }

                                        if ((sensor5 > 3.003) && (sensor5 < 3.203))
                                        {
                                            

                                            m_sensor5state4count = m_sensor5state4count + 1;

                                            if (m_sensor5state4count >= 10)
                                            {
                                                s_sensor5state4 = " 测量1 3.003-3.203";
                                                m_sensor5state4 = true;
                                            }
                                        }
                                        if ((sensor6 > 3.003) && (sensor6 < 3.203))
                                        {
                                           
                                            m_sensor6state4count = m_sensor6state4count + 1;
                                            if (m_sensor6state4count >= 10)
                                            {
                                                s_sensor6state4 = " 测量2 3.003-3.203";
                                                m_sensor6state4 = true;
                                            }
                                        }
                                        if ((sensor7 > 3.003) && (sensor7 < 3.203))
                                        {
                                           
                                            m_sensor7state4count = m_sensor7state4count + 1;
                                            if (m_sensor7state4count >= 10)
                                            {
                                                s_sensor7state4 = " 测量3 3.003-3.203";
                                                m_sensor7state4 = true;
                                            }

                                        }

                                        if ((sensor5 > 4.416) && (sensor5 < 4.616))
                                        {
                                           
                                            m_sensor5state5count = m_sensor5state5count + 1;

                                            if (m_sensor5state5count >= 10)
                                            {
                                                s_sensor5state5 = " 测量1 4.416-4.616";
                                                m_sensor5state5 = true;
                                            }
                                        }
                                        if ((sensor6 > 4.416) && (sensor6 < 4.616))
                                        {
                                            
                                            m_sensor6state5count = m_sensor6state5count + 1;
                                            if (m_sensor6state5count >= 10)
                                            {
                                                s_sensor6state5 = " 测量2 4.416-4.616";
                                                m_sensor6state5 = true;
                                            }
                                        }
                                        if ((sensor7 > 4.416) && (sensor7 < 4.616))
                                        {
                                           
                                            m_sensor7state5count = m_sensor7state5count + 1;
                                            if (m_sensor7state5count >= 10)
                                            {
                                                s_sensor7state5 = " 测量3 4.416-4.616";
                                                m_sensor7state5 = true;
                                            }

                                        }


                                        if ((sensor5 > 1.200) && (sensor5 < 1.400))
                                        {
                                          
                                            m_sensor5state0 = true;
                                        }

                                        if ((sensor6 > 1.200) && (sensor6 < 1.400))
                                        {
                                           
                                            m_sensor6state0 = true;
                                        }

                                        if ((sensor7 > 1.200) && (sensor7 < 1.400))
                                        {
                                          
                                            m_sensor7state0 = true;
                                        }

                                        if ((sensor5 > 1.950) && (sensor5 < 2.150))
                                        {
                                           
                                            m_sensor5state1 = true;
                                        }

                                        if ((sensor6 > 1.95) && (sensor6 < 2.15))
                                        {
                                           
                                            m_sensor6state1 = true;
                                        }

                                        if ((sensor7 > 1.95) && (sensor7 < 2.15))
                                        {
                                           
                                            m_sensor7state1 = true;
                                        }

                                        if ((sensor5 > 2.5) && (sensor5 < 2.7))
                                        {
                                        
                                           m_sensor5state2 = true;
                                        }

                                        if ((sensor6 > 2.5) && (sensor6 < 2.7))
                                        {
                                          
                                           m_sensor6state2 = true;
                                        }

                                        if ((sensor7 > 2.5) && (sensor7 < 2.7))
                                        {
                                            
                                            m_sensor7state2 = true;
                                        }

                                        m_sensor5state2 = true;
                                        m_sensor6state2 = true;
                                        m_sensor7state2 = true;
                                    }


                                    if ((m_sensor5state0 == true) && (m_sensor5state1 == true) && (m_sensor5state2 == true)
                                                   && (m_sensor6state0 == true) && (m_sensor6state1 == true) && (m_sensor6state2 == true)
                                                 && (m_sensor7state0 == true) && (m_sensor7state1 == true) && (m_sensor7state2 == true)
                                                && (m_sensor5state3 == false) && (m_sensor5state4 == false) && (m_sensor5state5 == false)
                                                 && (m_sensor6state3 == false) && (m_sensor6state4 == false) && (m_sensor6state5 == false)
                                                 && (m_sensor7state3 == false) && (m_sensor7state4 == false) && (m_sensor7state5 == false))
                                    {



                                        m_sensor5state0 = false;
                                        m_sensor5state1 = false;
                                        m_sensor5state2 = false;
                                        m_sensor6state0 = false;
                                        m_sensor6state1 = false;
                                        m_sensor6state2 = false;
                                        m_sensor7state0 = false;
                                        m_sensor7state1 = false;
                                        m_sensor7state2 = false;

                                        m_sensor5state3 = false;
                                        m_sensor5state4 = false;
                                        m_sensor5state5 = false;
                                        m_sensor5state3count = 0;
                                        m_sensor5state4count = 0;
                                        m_sensor5state5count = 0;
                                        m_sensor6state3 = false;
                                        m_sensor6state4 = false;
                                        m_sensor6state5 = false;
                                        m_sensor6state3count = 0;
                                        m_sensor6state4count = 0;
                                        m_sensor6state5count = 0;
                                        m_sensor7state3 = false;
                                        m_sensor7state4 = false;
                                        m_sensor7state5 = false;
                                        m_sensor7state3count = 0;
                                        m_sensor7state4count = 0;
                                        m_sensor7state5count = 0;
                                        s_sensor5state0 = "";
                                        s_sensor6state0 = "";
                                        s_sensor7state0 = "";
                                        s_sensor5state1 = "";
                                        s_sensor6state1 = "";
                                        s_sensor7state1 = "";
                                        s_sensor5state2 = "";
                                        s_sensor6state2 = "";
                                        s_sensor7state2 = "";
                                        s_sensor5state3 = "";
                                        s_sensor6state3 = "";
                                        s_sensor7state3 = "";
                                        s_sensor5state4 = "";
                                        s_sensor6state4 = "";
                                        s_sensor7state4 = "";
                                        s_sensor5state5 = "";
                                        s_sensor6state5 = "";
                                        s_sensor7state5 = "";


                                    }
                                    else
                                    {
                                        if (m_sensor5state0 == false)
                                        {
                                            s_sensor5state0 = "测量1 1.2-1.4";
                                        }
                                        if (m_sensor6state0==false)
                                       {
                                            s_sensor6state0 = "测量2 1.2-1.4";
                                        }

                                        if (m_sensor7state0 == false)
                                        {
                                            s_sensor7state0 = "测量3 1.2-1.4";
                                        }

                                        if (m_sensor5state1 == false)
                                        {
                                            s_sensor5state1 = "测量1 1.95-2.15";
                                        }
                                        if (m_sensor6state1 == false)
                                        {
                                            s_sensor6state1 = "测量2 1.95-2.15";
                                        }
                                        if (m_sensor7state1 == false)
                                        {
                                            s_sensor7state1 = "测量3 1.95-2.15";
                                        }

                                        if (m_sensor5state2 == false)
                                        {
                                            s_sensor5state2 = "测量1 2.5-2.7";
                                        }

                                        if (m_sensor6state2 == false)
                                        {
                                            s_sensor6state2 = "测量2 2.5-2.7";
                                        }

                                        if (m_sensor7state2 == false)
                                        {
                                            s_sensor7state2 = "测量3 2.5-2.7";
                                        }


                                        s = s_sensor5state0 + s_sensor5state1 + s_sensor5state2 + s_sensor5state3 + s_sensor5state4 + s_sensor5state5
                                            + s_sensor6state0 + s_sensor6state1 + s_sensor6state2 + s_sensor6state3 + s_sensor6state4 + s_sensor6state5
                                            + s_sensor7state0 + s_sensor7state1 + s_sensor7state2 + s_sensor7state3 + s_sensor7state4 + s_sensor7state5;
                                        w.WriteLine(s);

                                        GlobeVal.myarm.m_dianyabaohucontrol = false;
                                        GlobeVal.myarm.dianyabaohu = true;
                                    }
                                }

                            }

                            fs.Close();
                        }



                    }
                    else if (CComLibrary.GlobeVal.filesave.Samplingmode == 0)//静态采集

                    {


                        if (mrawdatalist.Count < 100)
                        {
                            mrawdatalist.Add(mrawdata);
                        }
                        else
                        {
                            mrawdatalist.RemoveAt(0);
                            mrawdatalist.Add(mrawdata);
                        }

                        if (CComLibrary.GlobeVal.filesave.SampleInterval == 0)
                        {
                            CComLibrary.GlobeVal.filesave.SampleInterval = 10;
                        }



                        if ((mtime - tstart) >= 1 / CComLibrary.GlobeVal.filesave.SampleInterval)
                        {
                            tstart = mtime;
                            using (StreamWriter w = File.AppendText(mspefiledat))
                            {

                                s = "";
                                 object[] mt = new  object[CComLibrary.GlobeVal.filesave.mrawdata.Count];

                                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mrawdata.Count; i++)
                                {
                                    DataGridViewRow m = new DataGridViewRow();

                                  
                                    for (j = 0; j < ClsStaticStation.m_Global.mycls.datalist.Count; j++)
                                    {
                                        if (ClsStaticStation.m_Global.mycls.datalist[j].SignName == CComLibrary.GlobeVal.filesave.mrawdata[i].SignName)
                                        {
                                            k = ClsStaticStation.m_Global.mycls.datalist[j].EdcId;


                                            double.TryParse(CComLibrary.GlobeVal.filesave.mrawdata[i].GetValueFromUnit(b.data[k],
                                                CComLibrary.GlobeVal.filesave.mrawdata[i].cUnitsel), out v);
                                            s = s + v.ToString("F" + CComLibrary.GlobeVal.filesave.mrawdata[i].precise.ToString()) + " ";
                                            mt[i]= v.ToString("F" + CComLibrary.GlobeVal.filesave.mrawdata[i].precise.ToString());
                                           

                                        }
                                    }
                                    

                                }

                                if (GlobeVal.UserControlRawdata1 == null)
                                {
                                }
                                else
                                {


                                    GlobeVal.UserControlRawdata1.dataGridView1.Rows.Add(mt);
                                }

                                w.WriteLine(s);




                            }
                        }
                    }
                }


            }
            /*
            if(count >5000)
            {
                scatterGraph.ClearData();
                count = 0;
            }

            lblcaption.Text = count.ToString();
            */
            timer1.Enabled = true;

        }

        private void scatterGraph_PlotDataChanged(object sender, NationalInstruments.UI.XYPlotDataChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tsbscreenreader_Click(object sender, EventArgs e)
        {
            if (xyCursor1.Visible == true)
            {
                xyCursor1.Visible = false;
            }
            else
            {
                xyCursor1.Visible = true;
            }
        }

        private void tsbzoomin_Click(object sender, EventArgs e)
        {
            scatterGraph.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.ZoomXY;
        }

        private void tsbzoomout_Click(object sender, EventArgs e)
        {
            scatterGraph.UndoZoomPan();
            scatterGraph.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;

        }

        private void lblcaption_Click(object sender, EventArgs e)
        {
            if (mplot1 == 1)
            {
                if (Convert.ToBoolean(lblcaption.Tag) == false)
                {
                    lblcaption.Tag = true;
                    lblcaption.Text = "分析图1";
                    tabControl1.SelectedIndex = 1;
                    toolStripLeft.Visible = false;
                }
                else
                {
                    lblcaption.Text = "曲线图1";
                    lblcaption.Tag = false;
                    tabControl1.SelectedIndex = 0;
                    toolStripLeft.Visible = true;
                }
            }
        }
    }
}
