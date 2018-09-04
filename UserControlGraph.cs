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
        long mstartoldcount = -1;
        long mstartoldcount1 = -1;

        double msavestartime = 0;
        bool msavebool = false;

        double mdogtimelast = 0;

        double mdogstarttime = 0;

        string s_sensor5state0 = "";
        string s_sensor5state1 = "";
        string s_sensor5state2 = "";
        string s_sensor6state0 = "";
        string s_sensor6state1 = "";
        string s_sensor6state2 = "";
        string s_sensor7state0 = "";
        string s_sensor7state1 = "";
        string s_sensor7state2 = "";

        string s_sensor5state3 = "";
        string s_sensor6state3 = "";
        string s_sensor7state3 = "";
        string s_sensor5state4 = "";
        string s_sensor6state4 = "";
        string s_sensor7state4 = "";
        string s_sensor5state5 = "";
        string s_sensor6state5 = "";
        string s_sensor7state5 = "";

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
        public long tcount = 0;
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

        public void stoprun()
        {

            timer1.Enabled = false;

        }
        public bool startrun()
        {
            RawDataDataGroup d;
            mstartoldcount = -1;
            mstartoldcount1 = -1;

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


            int ll = 0;

            ll = ClsStatic.arraydata[mplot1 - 1].Read<RawDataDataGroup>(r, 0, 10);

            if (ll == 0)
            {
            }
            else
            {
                ClsStatic.arraydatacount[mplot1 - 1] = ClsStatic.arraydatacount[mplot1 - 1] - 1;
            }


            while (ll != 0)
            {
                b = new RawDataStruct();
                b.data = new double[24];


                m_Global.mycls.structcopy_RawDataStruct(r[0].rdata, ref b);


               


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


            xAxis1.Range = new NationalInstruments.UI.Range(myplotsettings.xmin, myplotsettings.xmax);


            //长时记录文件保存

            if ((mplot1 == 1))
            {


                mspefiledat = GlobeVal.mysys.SamplePath + "\\" + GlobeVal.mysys.SampleFile + "-" +
                    (CComLibrary.GlobeVal.filesave.currentspenumber + 1).ToString().Trim() + ".txt";



                if (File.Exists(mspefiledat) == true)
                {
                    DialogResult a;

                    if (CComLibrary.GlobeVal.filesave.Samplingmode == 1)
                    {
                        if (GlobeVal.mysys.language == 0)
                        {
                            a = MessageBox.Show("长时记录文件已经存在，是否覆盖当前文件", "请选择", MessageBoxButtons.YesNo);
                        }
                        else
                        {
                            a = MessageBox.Show("The long time record file already exists and whether to overwrite the current file." ,"please select", MessageBoxButtons.YesNo);
                        }

                    }
                    else
                    {
                        if (GlobeVal.mysys.language == 0)
                        {
                            a = MessageBox.Show("原始数据文件已经存在，是否覆盖当前文件", "请选择", MessageBoxButtons.YesNo);
                        }
                        else
                        {
                            a = MessageBox.Show("The original data file already exists, whether to overwrite the current file", "please select", MessageBoxButtons.YesNo);
                        }

                    }

                    if (a == DialogResult.Yes)
                    {
                        if (GlobeVal.UserControlLongRecord1 == null)
                        {

                        }
                        else
                        {
                            GlobeVal.UserControlLongRecord1.dataGridView1.Rows.Clear();
                        }

                        File.Delete(mspefiledat);




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
                    else //
                    {


                        return false;

                        //GlobeVal.UserControlLongRecord1.
                        object[] mt = new object[CComLibrary.GlobeVal.filesave.mlongdata.Count];

                        string[] st = new string[CComLibrary.GlobeVal.filesave.mlongdata.Count];
                        char[] sp = new char[2];
                        sp[0] = Convert.ToChar(" ");
                        string line = "";

                        if (GlobeVal.UserControlLongRecord1 == null)
                        {

                        }
                        else
                        {
                            GlobeVal.UserControlLongRecord1.dataGridView1.Rows.Clear();
                        }


                        using (StreamReader sr = new StreamReader(mspefiledat, Encoding.Default))
                        {

                            while ((line = sr.ReadLine()) != null)

                            {
                                if (line.Trim() == "")
                                {

                                }
                                else
                                {
                                    sp[0] = Convert.ToChar(" ");

                                    st = line.Split(sp);

                                    if (CComLibrary.GlobeVal.filesave.mlongdata.Count == st.Length)
                                    {
                                        for (int i = 0; i < st.Length - 1; i++)
                                        {
                                            mt[i] = st[i];
                                        }

                                        if (GlobeVal.UserControlLongRecord1 == null)
                                        {

                                        }
                                        else
                                        {
                                            GlobeVal.UserControlLongRecord1.dataGridView1.Rows.Add(mt);
                                        }
                                    }
                                }

                            }

                        }





                    }
                }

                else
                {
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


            }


            myarraydata.Clear();


            timer1.Enabled = true;
            return true;
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
                if (GlobeVal.mysys.language == 0)
                {
                    lblcaption.Text = "曲线图1";

                    scatterGraph.Caption = "试样1";

                }
                else
                {
                    lblcaption.Text = "Graph 1";
                    scatterGraph.Caption = "Specimen 1";
                }
                lblcaption.Tag = true;


            }

            if (plot == 2)
            {
                myplotsettings = CComLibrary.GlobeVal.filesave.mplotpara2;
                if (GlobeVal.mysys.language ==0)
                {
                    lblcaption.Text = "曲线图2";
                    scatterGraph.Caption = "试样1";
                }
                else
                {
                    lblcaption.Text = "Graph 2";
                    scatterGraph.Caption = "Specimen 1";
                }
               
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

                if (myplotsettings.dynamicdraw == true)
                {
                    mplot.HistoryCapacity = myplotsettings.dynamicpointcount;
                }
                else
                {
                    mplot.HistoryCapacity = 30000;
                }
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
                if (myplotsettings.dynamicdraw == true)
                {
                    mplot.HistoryCapacity = myplotsettings.dynamicpointcount;
                }
                else
                {
                    mplot.HistoryCapacity = 30000;
                }

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
                scatterGraph.YAxes[1].Mode = NationalInstruments.UI.AxisMode.Fixed;
            }
            else
            {
                scatterGraph.YAxes[1].Mode = NationalInstruments.UI.AxisMode.Fixed;
            }

            if (myplotsettings.ychannelzoom == true)
            {
                scatterGraph.YAxes[0].Mode = NationalInstruments.UI.AxisMode.Fixed;
            }
            else
            {
                scatterGraph.YAxes[0].Mode = NationalInstruments.UI.AxisMode.Fixed;
            }

            if (myplotsettings.xchannelzoom == true)
            {
                scatterGraph.XAxes[0].Mode = NationalInstruments.UI.AxisMode.Fixed;
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
            this.tableLayoutPanel15.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel15, true, null);
            this.tableLayoutPanelCurve.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanelCurve, true, null);

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



            while (myarraydata.Count > 1)
            {



                b = myarraydata.Dequeue();



                count = count + 1;

                tcount = tcount + 1;
                if (tcount == 100)
                {
                    tcount = 0;
                    //  Application.DoEvents();
                }

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


                    //摘除引伸计

                    if (CComLibrary.GlobeVal.filesave == null)

                    {

                    }
                    else

                    {

                        if (CComLibrary.GlobeVal.filesave.chkextremove == true)
                        {
                            if (m_Global.mycls.datalist[i].SignName == m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.Extensometer_DataChannel].SignName)
                            {
                                double mpext = Convert.ToDouble(m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.Extensometer_DataChannel].GetValueFromUnit(b.data[m_Global.mycls.datalist[i].EdcId],
                                CComLibrary.GlobeVal.filesave.Extensometer_DataValueUnit));

                                if (mpext >= CComLibrary.GlobeVal.filesave.Extensometer_DataValue)
                                {
                                    GlobeVal.UserControlSpe1.setspe(CComLibrary.GlobeVal.filesave.currentspenumber + 1, CComLibrary.TestStatus.RemoveExt);

                                    if (CComLibrary.GlobeVal.filesave.Extensometer_DataFrozen==true)
                                    {
                                        CComLibrary.GlobeVal.filesave.Extensometer_DataFrozenFlag = true;
                                    }
                                }

                            }

                        }
                    }

                }


                // if ( Math.Abs(mtime - mstarttime) >= 0.002)
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
                                scatterGraph.Plots[mk - 1].XAxis.Range = new NationalInstruments.UI.Range(xi, xi + (myplotsettings.xmax - myplotsettings.xmin));

                            }

                            if (myplotsettings.ychannelzoom == true)
                            {

                                if (yi > scatterGraph.Plots[mk - 1].YAxis.Range.Maximum)
                                {
                                    scatterGraph.Plots[mk - 1].YAxis.Range = new NationalInstruments.UI.Range(scatterGraph.Plots[mk - 1].YAxis.Range.Minimum, scatterGraph.Plots[mk - 1].YAxis.Range.Maximum
                                        + (scatterGraph.Plots[mk - 1].YAxis.Range.Maximum - scatterGraph.Plots[mk - 1].YAxis.Range.Minimum) * 0.1);


                                }

                                if (yi < scatterGraph.Plots[mk - 1].YAxis.Range.Minimum)
                                {
                                    scatterGraph.Plots[mk - 1].YAxis.Range = new NationalInstruments.UI.Range(scatterGraph.Plots[mk - 1].YAxis.Range.Minimum - (scatterGraph.Plots[mk - 1].YAxis.Range.Maximum -
                                        scatterGraph.Plots[mk - 1].YAxis.Range.Minimum) * 0.1, scatterGraph.Plots[mk - 1].YAxis.Range.Maximum);
                                }
                            }


                        }
                        else
                        {

                            /*
                            bool my1save = false;

                            for (int m = 0; m < CComLibrary.GlobeVal.filesave.chkcriteria.Length; m++)
                            {
                                if (CComLibrary.GlobeVal.filesave.chkcriteria[m] == true)
                                {


                                    if (Math.Abs(ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.cbomeasurement[m]].cvalue - CComLibrary.GlobeVal.filesave.numintervallast1[m]) >= CComLibrary.GlobeVal.filesave.numinterval[m])
                                    {
                                        CComLibrary.GlobeVal.filesave.numintervallast1[m] = ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.cbomeasurement[m]].cvalue;
                                        my1save = true;
                                    }


                                }
                            }
                            */

                            if (Math.Abs(mtime - mstarttime) >= 1/20.0)
                            //if (my1save ==true)
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
                                    scatterGraph.Plots[mk - 1].XAxis.Range = new NationalInstruments.UI.Range(myplotsettings.xmin, xi + (myplotsettings.xmax - myplotsettings.xmin));

                                }

                                if (myplotsettings.ychannelzoom == true)
                                {

                                    if (yi > scatterGraph.Plots[mk - 1].YAxis.Range.Maximum)
                                    {
                                        scatterGraph.Plots[mk - 1].YAxis.Range = new NationalInstruments.UI.Range(scatterGraph.Plots[mk - 1].YAxis.Range.Minimum, scatterGraph.Plots[mk - 1].YAxis.Range.Maximum + (
                                             scatterGraph.Plots[mk - 1].YAxis.Range.Maximum - scatterGraph.Plots[mk - 1].YAxis.Range.Minimum) * 0.1);


                                    }

                                    if (yi < scatterGraph.Plots[mk - 1].YAxis.Range.Minimum)
                                    {
                                        scatterGraph.Plots[mk - 1].YAxis.Range = new NationalInstruments.UI.Range(scatterGraph.Plots[mk - 1].YAxis.Range.Minimum -
                                            (scatterGraph.Plots[mk - 1].YAxis.Range.Maximum - scatterGraph.Plots[mk - 1].YAxis.Range.Minimum) * 0.1, scatterGraph.Plots[mk - 1].YAxis.Range.Maximum);
                                    }
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


                            }

                            if (xi > scatterGraph.Plots[0].XAxis.Range.Maximum)
                            {
                                scatterGraph.Plots[0].XAxis.Range = new NationalInstruments.UI.Range(xi, xi + (myplotsettings.xmax - myplotsettings.xmin));

                            }
                            if (myplotsettings.ychannelzoom == true)
                            {
                                if (yi > scatterGraph.Plots[0].YAxis.Range.Maximum)
                                {
                                    scatterGraph.Plots[0].YAxis.Range = new NationalInstruments.UI.Range(scatterGraph.Plots[0].YAxis.Range.Minimum, scatterGraph.Plots[0].YAxis.Range.Maximum +
                                         (scatterGraph.Plots[0].YAxis.Range.Maximum - scatterGraph.Plots[0].YAxis.Range.Minimum) * 0.1);

                                }

                                if (yi < scatterGraph.Plots[0].YAxis.Range.Minimum)
                                {
                                    scatterGraph.Plots[0].YAxis.Range = new NationalInstruments.UI.Range(scatterGraph.Plots[0].YAxis.Range.Minimum -
                                        (scatterGraph.Plots[0].YAxis.Range.Maximum - scatterGraph.Plots[0].YAxis.Range.Minimum) * 0.1, scatterGraph.Plots[0].YAxis.Range.Maximum);

                                }


                            }

                            if (myplotsettings.y1channelzoom == true)
                            {
                                if (y1i > scatterGraph.Plots[1].YAxis.Range.Maximum)
                                {
                                    scatterGraph.Plots[1].YAxis.Range = new NationalInstruments.UI.Range(scatterGraph.Plots[1].YAxis.Range.Minimum, scatterGraph.Plots[1].YAxis.Range.Maximum +
                                        (scatterGraph.Plots[1].YAxis.Range.Maximum - scatterGraph.Plots[1].YAxis.Range.Minimum) * 0.1);

                                }

                                if (y1i < scatterGraph.Plots[1].YAxis.Range.Minimum)
                                {
                                    scatterGraph.Plots[1].YAxis.Range = new NationalInstruments.UI.Range(scatterGraph.Plots[1].YAxis.Range.Minimum -
                                        (scatterGraph.Plots[1].YAxis.Range.Maximum - scatterGraph.Plots[1].YAxis.Range.Minimum) * 0.1, scatterGraph.Plots[1].YAxis.Range.Maximum);

                                }


                            }



                        }
                        else
                        {
                           
                           if (Math.Abs(mtime - mstarttime) >= 1 / 20.0)

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


                                }

                                if (xi > scatterGraph.Plots[0].XAxis.Range.Maximum)
                                {
                                    scatterGraph.Plots[0].XAxis.Range = new NationalInstruments.UI.Range(xi, xi + (myplotsettings.xmax - myplotsettings.xmin));

                                }

                                if (myplotsettings.ychannelzoom == true)
                                {
                                    if (yi > scatterGraph.Plots[0].YAxis.Range.Maximum)
                                    {
                                        scatterGraph.Plots[0].YAxis.Range = new NationalInstruments.UI.Range(scatterGraph.Plots[0].YAxis.Range.Minimum, scatterGraph.Plots[0].YAxis.Range.Maximum
                                            + (scatterGraph.Plots[0].YAxis.Range.Maximum - scatterGraph.Plots[0].YAxis.Range.Minimum) * 0.1);

                                    }

                                    if (yi < scatterGraph.Plots[0].YAxis.Range.Minimum)
                                    {
                                        scatterGraph.Plots[0].YAxis.Range = new NationalInstruments.UI.Range(scatterGraph.Plots[0].YAxis.Range.Minimum - (scatterGraph.Plots[0].YAxis.Range.Maximum -
                                            scatterGraph.Plots[0].YAxis.Range.Minimum) * 0.1, scatterGraph.Plots[0].YAxis.Range.Maximum);

                                    }


                                }

                                if (myplotsettings.y1channelzoom == true)
                                {
                                    if (y1i > scatterGraph.Plots[1].YAxis.Range.Maximum)
                                    {
                                        scatterGraph.Plots[1].YAxis.Range = new NationalInstruments.UI.Range(scatterGraph.Plots[1].YAxis.Range.Minimum, scatterGraph.Plots[1].YAxis.Range.Maximum +
                                            (scatterGraph.Plots[1].YAxis.Range.Maximum - scatterGraph.Plots[1].YAxis.Range.Minimum) * 0.1);

                                    }

                                    if (y1i < scatterGraph.Plots[1].YAxis.Range.Minimum)
                                    {
                                        scatterGraph.Plots[1].YAxis.Range = new NationalInstruments.UI.Range(scatterGraph.Plots[1].YAxis.Range.Minimum -
                                            (scatterGraph.Plots[1].YAxis.Range.Maximum - scatterGraph.Plots[1].YAxis.Range.Minimum) * 0.1, scatterGraph.Plots[1].YAxis.Range.Maximum);

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
                                    scatterGraph.Plots[k].XAxis.Range = new NationalInstruments.UI.Range(xi, xi + (myplotsettings.xmax - myplotsettings.xmin));

                                }

                                if (xi < scatterGraph.Plots[k].XAxis.Range.Minimum)
                                {
                                    scatterGraph.Plots[k].XAxis.Range = new NationalInstruments.UI.Range(xi, xi + (myplotsettings.xmax - myplotsettings.xmin));

                                }

                                if (myplotsettings.ychannelzoom == true)
                                {
                                    if (yi > scatterGraph.Plots[k].YAxis.Range.Maximum)
                                    {
                                        scatterGraph.Plots[k].YAxis.Range = new NationalInstruments.UI.Range(scatterGraph.Plots[k].YAxis.Range.Minimum, scatterGraph.Plots[k].YAxis.Range.Maximum +
                                            (scatterGraph.Plots[k].YAxis.Range.Maximum - scatterGraph.Plots[k].YAxis.Range.Minimum) * 0.1);
                                    }

                                    if (yi < scatterGraph.Plots[k].YAxis.Range.Minimum)
                                    {
                                        scatterGraph.Plots[k].YAxis.Range = new NationalInstruments.UI.Range(scatterGraph.Plots[k].YAxis.Range.Minimum -
                                            (scatterGraph.Plots[k].YAxis.Range.Maximum - scatterGraph.Plots[k].YAxis.Range.Minimum) * 0.1, scatterGraph.Plots[k].YAxis.Range.Maximum);
                                    }
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
                            /*
                            bool mysave = false;

                            for (int m = 0; m < CComLibrary.GlobeVal.filesave.chkcriteria.Length; m++)
                            {
                                if (CComLibrary.GlobeVal.filesave.chkcriteria[m] == true)
                                {


                                    if (Math.Abs(ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.cbomeasurement[m]].cvalue - CComLibrary.GlobeVal.filesave.numintervallast[m]) >= CComLibrary.GlobeVal.filesave.numinterval[m])
                                    {
                                        CComLibrary.GlobeVal.filesave.numintervallast[m] = ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.cbomeasurement[m]].cvalue;
                                        mysave = true;
                                    }


                                }
                            }
                            */
                           if (Math.Abs(mtime - mstarttime) >= 1 / 10)

                           // if (mysave ==true)
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
                                        scatterGraph.Plots[k].XAxis.Range = new NationalInstruments.UI.Range(xi, xi + (myplotsettings.xmax - myplotsettings.xmin));

                                    }

                                    if (xi < scatterGraph.Plots[k].XAxis.Range.Minimum)
                                    {
                                        scatterGraph.Plots[k].XAxis.Range = new NationalInstruments.UI.Range(xi, xi + (myplotsettings.xmax - myplotsettings.xmin));

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
                        //
                        if (mrawdatalist.Count < 200)
                        {
                            mrawdatalist.Add(mrawdata);
                        }
                        else
                        {
                            mrawdatalist.RemoveAt(0);
                            mrawdatalist.Add(mrawdata);
                        }



                        if ((GlobeVal.myarm.mcurseg >= 0) && (GlobeVal.myarm.mcurseg < CComLibrary.GlobeVal.filesave.mseglist.Count))
                        {
                            //峰值记录
                            if (CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.msavepeaktrend == true)
                            {
                                bool msb = false;

                                int mw = 0;
                                int mw1 = 0;//保存间隔次数
                                int mw2 = 0;//连续保存次数

                                for (int w = 0; w < 10; w++)
                                {
                                    if (GlobeVal.myarm.count <= CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.msavepeaktrendrow1[w])
                                    {
                                        mw = w;
                                        if (w == 0)
                                        {
                                            mw1 = CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.msavepeaktrendrow2[0];
                                            mw2 = CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.msavepeaktrendrow3[0];
                                        }
                                        else
                                        {

                                            mw1 = CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.msavepeaktrendrow2[mw - 1];
                                            mw2 = CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.msavepeaktrendrow3[mw - 1];
                                        }


                                        break;
                                    }
                                }


                                bool mst = false;

                                if (mstartoldcount != GlobeVal.myarm.count)
                                {
                                    mstartoldcount = GlobeVal.myarm.count;

                                    if (GlobeVal.myarm.count % mw1 == 0)
                                    {

                                        mst = true;
                                    }
                                }

                                if ((mtime - tstart) >= 0.1)
                                {
                                    tstart = mtime;

                                    //mstartsave = false;
                                }


                                //  if ((mtime - tstart) >= 1)

                                if (mst == true)
                                {
                                    tstart = mtime;
                                    using (StreamWriter w = File.AppendText(mspefiledat))
                                    {

                                        s = "";
                                        object[] mt = new object[CComLibrary.GlobeVal.filesave.mlongdata.Count];

                                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mlongdata.Count; i++)
                                        {
                                            DataGridViewRow m = new DataGridViewRow();


                                            for (j = 0; j < ClsStaticStation.m_Global.mycls.datalist.Count; j++)
                                            {
                                                if (ClsStaticStation.m_Global.mycls.datalist[j].SignName == CComLibrary.GlobeVal.filesave.mlongdata[i].SignName)
                                                {
                                                    k = ClsStaticStation.m_Global.mycls.datalist[j].EdcId;


                                                    double.TryParse(CComLibrary.GlobeVal.filesave.mlongdata[i].GetValueFromUnit(b.data[k],
                                                        CComLibrary.GlobeVal.filesave.mlongdata[i].cUnitsel), out v);
                                                    s = s + v.ToString("F" + CComLibrary.GlobeVal.filesave.mlongdata[i].precise.ToString()) + " ";
                                                    mt[i] = v.ToString("F" + CComLibrary.GlobeVal.filesave.mlongdata[i].precise.ToString());


                                                }
                                            }


                                        }

                                        if (GlobeVal.UserControlLongRecord1 == null)
                                        {

                                        }
                                        else
                                        {
                                            GlobeVal.UserControlLongRecord1.dataGridView1.Rows.Add(mt);
                                        }

                                        w.WriteLine(s);




                                    }
                                }
                            }

                            //曲线保存
                            if (CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.msavetracking == true)
                            {

                                int mw = 0;
                                int mw1 = 0;//保存间隔次数
                                int mw2 = 0;//连续保存次数

                                for (int w = 0; w < 10; w++)
                                {
                                    if (GlobeVal.myarm.count <= CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.msavetrackingrow1[w])
                                    {
                                        mw = w;
                                        if (w == 0)
                                        {
                                            mw1 = CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.msavetrackingrow2[0];
                                            mw2 = CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.msavetrackingrow3[0];
                                        }
                                        else
                                        {

                                            mw1 = CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.msavetrackingrow2[mw - 1];
                                            mw2 = CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.msavetrackingrow3[mw - 1];
                                        }


                                        break;
                                    }
                                }


                                bool mst = false;

                                if (mstartoldcount1 != GlobeVal.myarm.count)
                                {
                                    mstartoldcount1 = GlobeVal.myarm.count;

                                    if (GlobeVal.myarm.count % mw1 == 0)
                                    {

                                        mst = true;
                                    }
                                }


                                if (mst == true)


                                {


                                    fname = GlobeVal.mysys.SamplePath + "\\" + GlobeVal.mysys.SampleFile + "-" +
                                       (CComLibrary.GlobeVal.filesave.currentspenumber + 1).ToString().Trim() + "_" + GlobeVal.myarm.count.ToString() + ".txt";


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








                                    }

                                    fs.Close();
                                }
                            }
                        }



                    }
                    else if (CComLibrary.GlobeVal.filesave.Samplingmode == 0)//静态采集

                    {


                        if (mrawdatalist.Count < 200)
                        {
                            mrawdatalist.Add(mrawdata);
                        }
                        else
                        {
                            mrawdatalist.RemoveAt(0);
                            mrawdatalist.Add(mrawdata);
                        }

                        //静态断裂检测判断开始

                        if (CComLibrary.GlobeVal.filesave.endoftest1 == true)
                        {
                            if (CComLibrary.GlobeVal.filesave.endoftest1criteria == 0)//准则1判断
                            {
                                if (ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest1usechannel].cvalue >=
                                   CComLibrary.GlobeVal.filesave.endoftest1tempmax)
                                {
                                    CComLibrary.GlobeVal.filesave.endoftest1tempmax = ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest1usechannel].cvalue;
                                }

                                if (ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest1usechannel].cvalue >=
                                    ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest1usechannel].fullmaxbase * 1 / 100.0)
                                {
                                    CComLibrary.GlobeVal.filesave.endoftest1tempbool = true;
                                }

                                if (CComLibrary.GlobeVal.filesave.endoftest1tempbool == true)
                                {
                                    if (ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest1usechannel].cvalue <=
                                        CComLibrary.GlobeVal.filesave.endoftest1tempmax * CComLibrary.GlobeVal.filesave.endoftest1value / 100.0)
                                    {
                                        timer2.Enabled = true;
                                    }
                                }

                            }
                            if (CComLibrary.GlobeVal.filesave.endoftest1criteria == 1) //准则2判断
                            {
                                if (ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest1usechannel].cvalue >=
                                   CComLibrary.GlobeVal.filesave.endoftest1tempmax)
                                {
                                    CComLibrary.GlobeVal.filesave.endoftest1tempmax = ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest1usechannel].cvalue;
                                }

                                if (ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest1usechannel].cvalue >=
                                    ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest1usechannel].fullmaxbase * 1 / 100.0)
                                {
                                    CComLibrary.GlobeVal.filesave.endoftest1tempbool = true;
                                }

                                if (CComLibrary.GlobeVal.filesave.endoftest1tempbool == true)
                                {
                                    if (ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest1usechannel].cvalue <=
                                        CComLibrary.GlobeVal.filesave.endoftest1value)
                                    {
                                        timer2.Enabled = true;
                                    }
                                }
                            }

                            if (CComLibrary.GlobeVal.filesave.endoftest1criteria == 2) //准则3判断
                            {
                                if (ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest1usechannel].cvalue >= CComLibrary.GlobeVal.filesave.endoftest1value)
                                {
                                    timer2.Enabled = true;




                                }
                            }
                        }

                        //静态断裂检测判断开始

                        if (CComLibrary.GlobeVal.filesave.endoftest2 == true)
                        {
                            if (CComLibrary.GlobeVal.filesave.endoftest2criteria == 0)//准则1判断
                            {
                                if (ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest2usechannel].cvalue >=
                                   CComLibrary.GlobeVal.filesave.endoftest2tempmax)
                                {
                                    CComLibrary.GlobeVal.filesave.endoftest2tempmax = ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest2usechannel].cvalue;
                                }

                                if (ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest2usechannel].cvalue >=
                                    ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest2usechannel].fullmaxbase * 1 / 100.0)
                                {
                                    CComLibrary.GlobeVal.filesave.endoftest2tempbool = true;
                                }

                                if (CComLibrary.GlobeVal.filesave.endoftest2tempbool == true)
                                {
                                    if (ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest2usechannel].cvalue <=
                                        CComLibrary.GlobeVal.filesave.endoftest2tempmax * CComLibrary.GlobeVal.filesave.endoftest2value / 100.0)
                                    {
                                        timer2.Enabled = true;
                                    }
                                }
                            }
                            if (CComLibrary.GlobeVal.filesave.endoftest2criteria == 1) //准则2判断
                            {
                                if (ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest2usechannel].cvalue >=
                                  CComLibrary.GlobeVal.filesave.endoftest2tempmax)
                                {
                                    CComLibrary.GlobeVal.filesave.endoftest2tempmax = ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest2usechannel].cvalue;
                                }

                                if (ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest2usechannel].cvalue >=
                                    ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest2usechannel].fullmaxbase * 1 / 100.0)
                                {
                                    CComLibrary.GlobeVal.filesave.endoftest2tempbool = true;
                                }

                                if (CComLibrary.GlobeVal.filesave.endoftest2tempbool == true)
                                {
                                    if (ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest2usechannel].cvalue <=
                                        CComLibrary.GlobeVal.filesave.endoftest2value)
                                    {
                                        timer2.Enabled = true;
                                    }
                                }
                            }

                            if (CComLibrary.GlobeVal.filesave.endoftest2criteria == 2) //准则3判断
                            {
                                if (ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.endoftest2usechannel].cvalue >= CComLibrary.GlobeVal.filesave.endoftest2value)
                                {
                                    timer2.Enabled = true;

                                }
                            }
                        }


                        //
                        bool madvancedsave = false;

                        if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3)//高级试验
                        {
                            if ((GlobeVal.myarm.mcurseg >= 0) && (GlobeVal.myarm.mcurseg < CComLibrary.GlobeVal.filesave.mseglist.Count))
                            {






                                if (CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.samplingmode == 0)
                                {
                                    madvancedsave = false;

                                }
                                else if (CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.samplingmode == 1)
                                {
                                    bool mysegsave = false;

                                    for (int i = 0; i < 20; i++)
                                    {
                                        if (CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.chkchannel[i] == true)
                                        {
                                            if (Math.Abs(ClsStaticStation.m_Global.mycls.allsignals[i].cvalue - CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.sampleintervaltemp[i])
                                                >= CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.sampleinterval[i])
                                            {
                                                CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.sampleintervaltemp[i] = ClsStaticStation.m_Global.mycls.allsignals[i].cvalue;
                                                mysegsave = true;
                                            }
                                        }
                                    }

                                    if (mysegsave == true)
                                    {
                                        tstart = mtime;
                                        using (StreamWriter w = File.AppendText(mspefiledat))
                                        {

                                            s = "";
                                            object[] mt = new object[CComLibrary.GlobeVal.filesave.mrawdata.Count];

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
                                                        mt[i] = v.ToString("F" + CComLibrary.GlobeVal.filesave.mrawdata[i].precise.ToString());


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

                                    madvancedsave = true;



                                }
                                else if (CComLibrary.GlobeVal.filesave.mseglist[0].mseq.samplingmode == 2)
                                {
                                    madvancedsave = true;
                                }
                            }
                        }
                        else
                        {
                            madvancedsave = false;
                        }

                        //静态采集开始

                        if (madvancedsave == false)
                        {

                            bool mysave = false;

                            for (int m = 0; m < CComLibrary.GlobeVal.filesave.chkcriteria.Length; m++)
                            {
                                if (CComLibrary.GlobeVal.filesave.chkcriteria[m] == true)
                                {

                                    for (int i = 0; i < CComLibrary.GlobeVal.filesave.mrawdata.Count; i++)
                                    {
                                       
                                            if (ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.cbomeasurement[m]].SignName == CComLibrary.GlobeVal.filesave.mrawdata[i].SignName)
                                            {
                                                k = ClsStaticStation.m_Global.mycls.allsignals[CComLibrary.GlobeVal.filesave.cbomeasurement[m]].EdcId;

                                              v = b.data[k];
                                            //v = mrawdata.data[k];
                                              //  double.TryParse(CComLibrary.GlobeVal.filesave.mrawdata[i].GetValueFromUnit(b.data[k], 0 ), out v);
                                            }
                                        
                                    }
                                        if (Math.Abs( v - CComLibrary.GlobeVal.filesave.numintervallast[m]) >= CComLibrary.GlobeVal.filesave.numinterval[m])
                                    {
                                        CComLibrary.GlobeVal.filesave.numintervallast[m] = v;
                                        mysave = true;
                                    }


                                }
                            }

                            if (mysave == true)
                            {
                                tstart = mtime;
                                using (StreamWriter w = File.AppendText(mspefiledat))
                                {

                                    s = "";
                                    object[] mt = new object[CComLibrary.GlobeVal.filesave.mrawdata.Count];

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
                                                mt[i] = v.ToString("F" + CComLibrary.GlobeVal.filesave.mrawdata[i].precise.ToString());

                                                break;
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
                        else
                        {

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
                    if (GlobeVal.mysys.language == 0)
                    {
                        lblcaption.Text = "分析图1";
                    }
                    else
                    {
                        lblcaption.Text = "Figure 1";
                    }
                    tabControl1.SelectedIndex = 1;
                    toolStripLeft.Visible = false;
                }
                else
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        lblcaption.Text = "曲线图1";
                    }
                    else
                    {
                        lblcaption.Text = "Graph 1";
                    }
                    lblcaption.Tag = false;
                    tabControl1.SelectedIndex = 0;
                    toolStripLeft.Visible = true;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            GlobeVal.myarm.duanliebaohu = true;

            GlobeVal.userControltest1.btnend_Click(null, null);
        }

        private void UserControlGraph_Load(object sender, EventArgs e)
        {
            //  GlobeVal.SetThreadAffinityMask(GlobeVal.GetCurrentThread(), new UIntPtr(GlobeVal.SetCpuID(1)));
        }

        private void y轴坐标ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
